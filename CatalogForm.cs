
using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace AutoStoreParts
{
    public partial class CatalogForm : Form
    {
        public int userId;
        public DatabaseHelper dbHelper;

        public CatalogForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            this.dbHelper = new DatabaseHelper(); // Инициализация DatabaseHelper
            LoadProducts();
        }

        public void LoadProducts()
        {
            try
            {
                using (var conn = dbHelper.GetConnection()) // Используем экземпляр dbHelper
                {
                    string query = "SELECT ID, Name, Description, Price, Quantity FROM Products";
                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridViewProducts.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке товаров: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (dataGridViewProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите товар", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow selectedRow = dataGridViewProducts.SelectedRows[0];
            int productId = Convert.ToInt32(selectedRow.Cells["ID"].Value);
            string productName = selectedRow.Cells["Name"].Value.ToString();
            int quantity = (int)numericQuantity.Value;
            int availableQuantity = Convert.ToInt32(selectedRow.Cells["Quantity"].Value);

            // Проверка на нулевое количество товара на складе
            if (availableQuantity <= 0)
            {
                MessageBox.Show($"Товар '{productName}' отсутствует на складе", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (quantity <= 0)
            {
                MessageBox.Show("Укажите количество больше нуля", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (quantity > availableQuantity)
            {
                MessageBox.Show($"Недостаточно товара на складе. Доступно: {availableQuantity}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = dbHelper.GetConnection())
                {
                    conn.Open();

                    // Проверяем, есть ли уже такой товар в корзине
                    string checkQuery = "SELECT Quantity FROM CartItems WHERE UserID = @userId AND ProductID = @productId";
                    OleDbCommand checkCmd = new OleDbCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@userId", userId);
                    checkCmd.Parameters.AddWithValue("@productId", productId);
                    object result = checkCmd.ExecuteScalar();

                    if (result != null)
                    {
                        // Обновляем количество, если товар уже в корзине
                        int currentQty = Convert.ToInt32(result);
                        string updateQuery = "UPDATE CartItems SET Quantity = @quantity WHERE UserID = @userId AND ProductID = @productId";
                        OleDbCommand updateCmd = new OleDbCommand(updateQuery, conn);
                        updateCmd.Parameters.AddWithValue("@quantity", currentQty + quantity);
                        updateCmd.Parameters.AddWithValue("@userId", userId);
                        updateCmd.Parameters.AddWithValue("@productId", productId);
                        updateCmd.ExecuteNonQuery();
                    }
                    else
                    {
                        // Добавляем новый товар в корзину
                        string insertQuery = "INSERT INTO CartItems (UserID, ProductID, Quantity) VALUES (@userId, @productId, @quantity)";
                        OleDbCommand insertCmd = new OleDbCommand(insertQuery, conn);
                        insertCmd.Parameters.AddWithValue("@userId", userId);
                        insertCmd.Parameters.AddWithValue("@productId", productId);
                        insertCmd.Parameters.AddWithValue("@quantity", quantity);
                        insertCmd.ExecuteNonQuery();
                    }

                    // Уменьшаем количество товара на складе
                    string updateStockQuery = "UPDATE Products SET Quantity = Quantity - @quantity WHERE ID = @productId";
                    OleDbCommand updateStockCmd = new OleDbCommand(updateStockQuery, conn);
                    updateStockCmd.Parameters.AddWithValue("@quantity", quantity);
                    updateStockCmd.Parameters.AddWithValue("@productId", productId);
                    updateStockCmd.ExecuteNonQuery();

                    // Обновляем отображение количества товара в DataGridView
                    selectedRow.Cells["Quantity"].Value = availableQuantity - quantity;

                    MessageBox.Show($"{productName} добавлен в корзину (x{quantity})", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении в корзину: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void btnViewCart_Click(object sender, EventArgs e)
        {
            CartForm cartForm = new CartForm(userId);
            cartForm.Show();
            this.Hide();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.UserClosing)
            {
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
        }

        public void CatalogForm_Load(object sender, EventArgs e)
        {
            // Метод загрузки формы
        }

        public void dataGridViewProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Обработчик клика по ячейке DataGridView
        }

        public void numericQuantity_ValueChanged(object sender, EventArgs e)
        {
            // Обработчик изменения значения NumericUpDown
        }
    }
}