using System.Collections.Generic;
using System.Data.SQLite;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbguimaker
{
    /// <summary>
    /// Describes a view of one table
    /// </summary>
    public partial class DatabaseGUIView
    {
        protected Control container;
        protected SQLiteDataReader dataReader;
        protected bool canLoadNext = false;
        public bool CanLoadNext{ get { return canLoadNext; } }
        public DatabaseGUIView() { }
        public DatabaseGUIView(string table_name)
        {
            this.tableName = table_name;
            this.elements = new List<DatabaseGUIViewElement>();
        }
        public bool IsCompatibleWith(List<DatabaseConnection.TableColumn> table_data)
            => elements.TrueForAll(e => e.IsCompatibleWith(table_data));
        public void Setup(DatabaseConnection database, Control container)
        {
            this.dataReader = database.GetTable(tableName);
            this.container = container;
            Next();
        }
        private async void Next()
        {
            canLoadNext =  dataReader!=null & await dataReader.ReadAsync();
        }
        public void Generate()
        {
            if (dataReader == null || !canLoadNext) return;
            Control[] controls = new Control[elements.Count];
            FlowLayoutPanel flowLayoutPanel = null;
            Parallel.Invoke(
                () => flowLayoutPanel = LoadPanel(),
                () => Parallel.For(0, elements.Count,
                    i => controls[i] = elements[i].Generate(dataReader))
            );
            flowLayoutPanel.Controls.AddRange(controls);
            container.Controls.Add(flowLayoutPanel);
            Next();
        }
        public void Generate(int max_amount)
        {
            while(max_amount > 0 && canLoadNext)
            {
                Generate();
                --max_amount;
            }
        }
        protected static FlowLayoutPanel LoadPanel()
        {
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.AutoSize = true;
            flowLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel.BorderStyle = BorderStyle.FixedSingle;
            return flowLayoutPanel;
        }
    }
}