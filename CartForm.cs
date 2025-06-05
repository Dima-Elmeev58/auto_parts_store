using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace AutoStoreParts
{
    public partial class CartForm : Form
    {
        public int userId;
        public DatabaseHelper dbHelper; // Добавляем экземпляр DatabaseHelper

        public CartForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            this.dbHelper = new DatabaseHelper();

            if (!dbHelper.TestConnection())
            {
                MessageBox.Show("ОШИБКА ПОДКЛЮЧЕНИЯ К БАЗЕ ДАННЫХ!", "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            LoadCartItems();
        }

        public void LoadCartItems()
        {
            try
            {
                var dt = new DataTable();

                using (var conn = dbHelper.GetConnection())
                {
                    string query = @"SELECT ci.ID as CartItemID, p.Name as ProductName, 
                   p.Price as Price, ci.Quantity as Quantity 
                   FROM CartItems ci 
                   INNER JOIN Products p ON ci.ProductID = p.ID 
                   WHERE ci.UserID = @userId";

                    using (var cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        conn.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            dt.Load(reader);
                        }
                    }
                }

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Корзина пуста или товары не найдены", "Информация",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Настройка DataGridView
                dataGridViewCart.AutoGenerateColumns = false;
                dataGridViewCart.Columns.Clear();

                // Добавляем ВСЕ необходимые колонки, включая CartItemID (но можно сделать его невидимым)
                dataGridViewCart.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    Name = "CartItemID",
                    HeaderText = "ID",
                    DataPropertyName = "CartItemID",
                    Visible = false // Скрываем, но оставляем для доступа
                });

                dataGridViewCart.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    Name = "ProductName",
                    HeaderText = "Название товара",
                    DataPropertyName = "ProductName"
                });

                dataGridViewCart.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    Name = "Price",
                    HeaderText = "Цена",
                    DataPropertyName = "Price"
                });

                dataGridViewCart.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    Name = "Quantity",
                    HeaderText = "Количество",
                    DataPropertyName = "Quantity"
                });

                dataGridViewCart.DataSource = dt;

                decimal total = 0;
                foreach (DataRow row in dt.Rows)
                {
                    total += Convert.ToDecimal(row["Price"]) * Convert.ToInt32(row["Quantity"]);
                }
                lblTotal.Text = $"Общая сумма: {total:C2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки корзины: {ex.Message}", "Ошибка",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void btnBuy_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверка на пустую корзину
                if (dataGridViewCart.Rows.Count == 0)
                {
                    MessageBox.Show("Ваша корзина пуста!", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Подтверждение покупки
                var result = MessageBox.Show("Вы уверены, что хотите оформить заказ?", "Подтверждение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    return;

                using (var conn = dbHelper.GetConnection()) // Используем экземпляр dbHelper
                {
                    conn.Open();
                    string deleteQuery = "DELETE FROM CartItems WHERE UserID = @userId";
                    var cmd = new OleDbCommand(deleteQuery, conn);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Заказ успешно оформлен! Спасибо за покупку.", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();

                        // Возвращаемся в каталог
                        CatalogForm catalogForm = new CatalogForm(userId);
                        catalogForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Не удалось оформить заказ.", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при оформлении заказа: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            CatalogForm catalogForm = new CatalogForm(userId);
            catalogForm.Show();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Показываем форму каталога при закрытии
                CatalogForm catalogForm = new CatalogForm(userId);
                catalogForm.Show();
            }
        }

        public void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewCart.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите товар для удаления", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // Получаем ID из скрытого столбца
                int cartItemId = Convert.ToInt32(dataGridViewCart.SelectedRows[0].Cells["CartItemID"].Value);

                using (var conn = dbHelper.GetConnection())
                {
                    conn.Open();
                    string deleteQuery = "DELETE FROM CartItems WHERE ID = @cartItemId";
                    var cmd = new OleDbCommand(deleteQuery, conn);
                    cmd.Parameters.AddWithValue("@cartItemId", cartItemId);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Товар удален из корзины", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadCartItems();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении товара: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CartForm_Load(object sender, EventArgs e)
        {
            // Метод загрузки формы
        }

        public void dataGridViewCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Теперь CartItemID доступен, даже если столбец скрыт
                int cartItemId = Convert.ToInt32(dataGridViewCart.Rows[e.RowIndex].Cells["CartItemID"].Value);
                string productName = dataGridViewCart.Rows[e.RowIndex].Cells["ProductName"].Value.ToString();
                MessageBox.Show($"Вы выбрали: {productName} (ID: {cartItemId})", "Информация о товаре");
            }
        }
    }
}