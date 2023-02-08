using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbguimaker.DatabaseGUI
{
    /// <summary>
    /// Describes a view of one table
    /// </summary>
    public partial class View
    {
        protected Control container;
        protected SQLiteDataReader dataReader;
        protected bool canLoadNext = false;//
        public bool CanLoadNext{ get { return canLoadNext; } }//
        protected Dictionary<TableColumn, object> currentRow
            = new Dictionary<TableColumn, object>();
        public bool IsCompatibleWith(DatabaseConnection database)
        {
            List<TableColumn> table_data = database.GetTableInfo(tableName);
            return elements.TrueForAll(e => e.IsCompatibleWith(table_data));
        }
        public void Setup(DatabaseConnection database, Control container)
        {
            this.dataReader = database.GetTable(tableName);
            this.container = container;

            List<TableColumn> columns = new List<TableColumn>();
            int temp = 1; // because null would've deleted the element
            foreach (var el in elements) columns.AddRange(el.GetRequiredColumns());
            foreach (var col in columns) currentRow[col] = temp;
            Next();
        }
        private async void Next()
        {
            canLoadNext = dataReader!=null & await dataReader.ReadAsync();
            if (!canLoadNext) return;
            List<TableColumn> columns = currentRow.Keys.ToList<TableColumn>();
            ParallelEnumerable.ForAll(
                columns.AsParallel(), 
                column => currentRow[column] = dataReader.GetValue(dataReader.GetOrdinal(column.Name))
                );
        }
        public void Generate()
        {
            if (dataReader == null || !canLoadNext) return;
            Control[] controls = new Control[elements.Count];
            FlowLayoutPanel flowLayoutPanel = null;
            Parallel.Invoke(
                () => flowLayoutPanel = LoadPanel(),
                () => Parallel.For(0, elements.Count,
                    i => controls[i] = elements[i].Generate(currentRow))
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
            flowLayoutPanel.Dock = DockStyle.Top;
            return flowLayoutPanel;
        }

        /*
         * Methods for creating database requests
         */
    }
}