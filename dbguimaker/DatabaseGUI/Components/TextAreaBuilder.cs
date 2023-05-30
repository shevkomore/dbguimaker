using dbguimaker.data;
using dbguimaker.DatabaseGUI.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbguimaker.DatabaseGUI.Components
{
    internal class TextAreaBuilder : ITableViewBuilder
    {
        public IDictionary<string, TableColumn> Fields
        {
            get
            {
                var res = new Dictionary<string, TableColumn>();
                res["Label"] = new TableColumn("", "", true);
                res["Text"] = new TableColumn("", "", true);
                return res;
            }
        }

        public Control Build(IEnumerable<KeyValuePair<TableColumn, object>> row)
        {
            TableLayoutPanel layout = new TableLayoutPanel();
            layout.AutoSize = true;
            layout.ColumnCount = 2;
            layout.ColumnStyles.Add(new ColumnStyle());
            System.Windows.Forms.Label label = new System.Windows.Forms.Label();
            label.AutoSize = true;
            label.Font = ControlGenerationSettings.Instance.DefaultFont;
            label.Text = row.First(o => o.Key.Equals(Fields["Label"])).ToString();
            layout.Controls.Add(label);
            TextBox textBox = new TextBox();
            textBox.Text = row.First(o => o.Key.Equals(Fields["Text"])).ToString();
            textBox.AutoSize = true;
            textBox.Font = ControlGenerationSettings.Instance.DefaultFont;
            textBox.Width = TextRenderer.MeasureText(textBox.Text, textBox.Font).Width;
            textBox.ReadOnly = true;
            layout.Controls.Add(textBox);
            return layout;
        }
    }
}
