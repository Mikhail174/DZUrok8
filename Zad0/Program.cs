using System;
using System.Windows.Forms;

namespace Zad0
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
       {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }
    }
}
