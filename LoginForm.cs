
using System;
using System.Data;

using System.Windows.Forms;

namespace AutoStoreParts
{
    public partial class LoginForm : Form
    {
        public DatabaseHelper dbHelper;
        public LoginForm()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
        }

        public void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин и пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка администратора
            if (login == "Admin" && password == "Admin")
            {
                AdminForm adminForm = new AdminForm();
                adminForm.Show();
                this.Hide();
                return;
            }
            // Проверка обычного пользователя
            string query = $"SELECT * FROM Users WHERE Login = '{login}' AND Password = '{password}'";
            DataTable dt = dbHelper.ExecuteQuery(query);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                User currentUser = new User
                {
                    Id = Convert.ToInt32(row["ID"]),
                    Login = row["Login"].ToString(),
                    UserName = row["UserName"].ToString(),

                };

                CatalogForm userCabinet = new CatalogForm(currentUser.Id);
                userCabinet.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }

        public void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        public void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string UserName { get; set; }
        public bool IsAdmin { get; set; }
    }
}