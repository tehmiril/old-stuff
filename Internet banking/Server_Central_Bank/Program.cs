using System;
using System.Collections.Generic;
//using System.Linq;
using System.Windows.Forms;

using InternetBanking_Interface;

namespace Server_Central_Bank
{

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Server_form());
        }
    }
}
