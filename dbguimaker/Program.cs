using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbguimaker
{
    internal static class Program
    {
        public static InitMenu mainMenu;
        public static EditorForm currentEditor;
        public static List<DBViewForm> viewForms = new List<DBViewForm>();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mainMenu = new InitMenu();
            Application.Run(mainMenu);
        }
    }
}
