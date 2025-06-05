
using System;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AutoStoreParts
{
    public partial class RegisterForm : Form
    {
        public DatabaseHelper dbHelper; // Изменил на public

        public RegisterForm()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
        }

        public void btnRegister_Click(object sender, EventArgs e) // Изменил на public
        {
            string login = txtLogin.Text;
            string password = txtPassword.Text;
            string name = txtName.Text;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Все поля должны быть заполнены", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = dbHelper.GetConnection())
                {
                    conn.Open();

                    // Проверка на существование логина
                    string checkQuery = "SELECT COUNT(*) FROM Users WHERE Login = @login";
                    OleDbCommand checkCmd = new OleDbCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@login", login);
                    int userCount = (int)checkCmd.ExecuteScalar();

                    if (userCount > 0)
                    {
                        MessageBox.Show("Пользователь с таким логином уже существует", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Регистрация нового пользователя
                    string insertQuery = "INSERT INTO Users (Login, [Password], UserName, IsAdmin) VALUES (@login, @password, @username, False)";
                    OleDbCommand insertCmd = new OleDbCommand(insertQuery, conn);
                    insertCmd.Parameters.AddWithValue("@login", login);
                    insertCmd.Parameters.AddWithValue("@password", password);
                    insertCmd.Parameters.AddWithValue("@name", name);

                    int rowsAffected = insertCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Регистрация успешна!", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Hide();
                        LoginForm loginForm = new LoginForm();
                        loginForm.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при регистрации: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RegisterForm_FormClosing(object sender, FormClosingEventArgs e) // Изменил на public
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
        }

        public void btnBack_Click(object sender, EventArgs e) // Изменил на public
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        public void RegisterForm_Load(object sender, EventArgs e) // Изменил на public
        {
            // Пустая загрузка формы (можно оставить как есть)
        }
    }
}