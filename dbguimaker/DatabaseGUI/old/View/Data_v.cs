using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace dbguimaker.DatabaseGUI
{
    /// <summary>
    /// Describes an object that contains all data for creating a database view
    /// </summary>
    public partial class Data
    {
        internal static Font DefaultViewFont = new Font(FontFamily.GenericSansSerif, 14);
        internal static OpenFileDialog OpenDataFileDialog = new OpenFileDialog();
        internal static OpenFileDialog OpenDatabaseFileDialog = new OpenFileDialog();
        internal static SaveFileDialog SaveViewFileDialog = new SaveFileDialog();
        static Data()
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
        /// <summary>
        /// Generates a path that can be used to get from folder that contains start to target.
        /// The path is compatible with <see cref="Path.GetFullPath(string)"/> if combined with start's directory.
        /// </summary>
        /// <param name="start">a full path to the file from whose folder the path is constructed</param>
        /// <param name="target">a full path to the file the constructed path should point to</param>
        /// <returns>
        /// a string that, when used in console or <see cref="File"/> from start's directory,
        /// would open the same file as target if the directory structure isn't changed;
        /// but will open the same file if the directory structure is changed from root
        /// to first common folder between these files.
        /// </returns>
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
        /// <summary>
        /// Creates an absolute path which points to the same file as the relative_path if
        /// it were called from start's directory.
        /// </summary>
        /// <param name="start">a full path to the file from whose folder the path was constructed</param>
        /// <param name="relative_path">a relative path to the file the full path should point to</param>
        /// <returns>The path for which:
        /// <code>FollowRelativePath(start, CreateRelativePath(start, target)) == target</code>
        /// returns true.
        /// </returns>
        public static string FollowRelativePath(string start, string relative_path)
            => Path.GetFullPath(Path.Combine(Path.GetDirectoryName(start), relative_path));

        public bool IsCompatibleWith(DatabaseConnection database)
            => views.TrueForAll(e => e.IsCompatibleWith(database));

    }
}