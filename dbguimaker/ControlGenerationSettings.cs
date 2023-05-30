using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbguimaker
{
    internal class ControlGenerationSettings
    {
        private static ControlGenerationSettings instance;
        //Singleton
        public static ControlGenerationSettings Instance
        {
            get
            {
                if(instance == null)
                    instance = new ControlGenerationSettings();
                return instance;
            }
        }

        public Font DefaultFont { get; } = new Font(FontFamily.GenericSansSerif, 14);
        public OpenFileDialog OpenDataFileDialog { get; } = new OpenFileDialog();
        public OpenFileDialog OpenDatabaseFileDialog { get; } = new OpenFileDialog();
        public SaveFileDialog SaveViewFileDialog { get; } = new SaveFileDialog();

        private ControlGenerationSettings()
        {
            //
            //  OpenDataFileDialog
            //
            OpenDataFileDialog.Filter =
                "Database View File|*.dbgui";
            OpenDataFileDialog.CheckFileExists = true;
            OpenDataFileDialog.Title = "Select a file";
            //
            //  OpenDatabaseFileDialog
            //
            OpenDatabaseFileDialog.Filter =
               "Database File|*.db";
            OpenDatabaseFileDialog.CheckFileExists = true;
            OpenDatabaseFileDialog.Title = "Select a database";
            //
            //  SaveViewFileDialog
            //
            SaveViewFileDialog.Title = "Save view to...";
            SaveViewFileDialog.DefaultExt = ".dbgui";
            SaveViewFileDialog.FileName = "view";
            SaveViewFileDialog.AddExtension = true;
            SaveViewFileDialog.CheckPathExists = true;
        }
    }
}
