using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project2
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string filePath = @"..\ABBV_daily.csv";
            Application.Run(new Form_display(filePath, new DateTime(2021, 1, 28), new DateTime(2021, 2, 28)));
        }
    }
}
