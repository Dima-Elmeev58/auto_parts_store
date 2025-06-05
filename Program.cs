
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoStoreParts
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Добавьте перед Application.Run()
            Thread.CurrentThread.CurrentCulture = new CultureInfo("ru-RU");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru-RU");
            Application.Run(new LoginForm());
        }
    }
}
