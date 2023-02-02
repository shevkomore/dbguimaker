using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace dbguimaker.Serialization
{
    /// <summary>
    /// Describes an object that contains all data for creating a database view
    /// </summary>
    public partial class DatabaseGUIData
    {
        internal static Font defaultFont = new Font(FontFamily.GenericSansSerif, 14);
        internal static OpenFileDialog OpenDataFileDialog = new OpenFileDialog();
        internal static OpenFileDialog OpenDatabaseFileDialog = new OpenFileDialog();
        internal static SaveFileDialog SaveViewFileDialog = new SaveFileDialog();
        static DatabaseGUIData()
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
        public DatabaseGUIData() { }
        public DatabaseGUIData(string database_name)
        {
            this.databasePath = database_name;
            this.views = new List<DatabaseGUIView>();
        }

        public static string CreateRelativePath(string start, string target)
        {
            //I think there's a cleaner way to do this, so for now I've explained what I'm doing.
            start = Path.GetDirectoryName(Path.GetFullPath(start))+Path.DirectorySeparatorChar;
            target = Path.GetFullPath(target);
            /*
             * Remove all unnecessary (matching) path elements from both strings
             * 
             * for example,
             * "C:/Users/l/Desktop/f"
             * "C:/Users/l/Documents"
             * 
             * should return
             * "Desktop/f"
             * "Documents"
             */
            int compared = start.IndexOf(Path.DirectorySeparatorChar)+1;
            while (compared != 0 & target.StartsWith(start.Substring(0, compared)))
            {
                start = start.Remove(0, compared);
                target = target.Remove(0, compared);
                compared = start.IndexOf(Path.DirectorySeparatorChar)+1;
            }
            /*
             * Return back once per directory left in start
             * 
             * for example,
             * "Documents/folder"
             * 
             * should return
             * "../.."
             */
            string path = "";
            compared = start.IndexOf(Path.DirectorySeparatorChar)+1;
            while (compared != 0)
            {
                start = start.Remove(0, compared);
                path += ".."+Path.DirectorySeparatorChar;
                compared = start.IndexOf(Path.DirectorySeparatorChar)+1;
            }
            return path + target;
        }
        public static string FollowRelativePath(string start, string relative_path)
        => Path.GetFullPath(Path.Combine(Path.GetDirectoryName(start), relative_path));
        public bool IsCompatibleWith(DatabaseConnection database)
        {
            foreach (DatabaseGUIView e in this.views)
                if (!e.IsCompatibleWith(database.GetTableInfo(e.tableName))) return false;

            return true;
        }

    }
}