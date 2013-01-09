using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication13
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
            //Application.Run(new Form1());

            Loader loader = new Loader();
            Application.Run(loader);
            //Thread.Sleep(1000);
            Application.Exit();

            loader.Dispose();

            Application.Run(new Form1());

            
            
        }
    }
}
