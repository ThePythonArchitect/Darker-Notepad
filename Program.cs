using System;
using System.Windows.Forms;

namespace DarkerNotepad
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            string fileToOpen = "";
            if (args.Length > 0)
            {
                fileToOpen = args[0];
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(fileToOpen));
        }
    }
}
