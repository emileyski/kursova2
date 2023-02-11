using RialtoLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RialtoCompanyAdmin
{
    internal static class Program
    {
        public static readonly RialtoEntities rialtoEntities = new RialtoEntities();

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //rialtoEntities = new RialtoEntities();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainAdminForm());
        }
    }
}
