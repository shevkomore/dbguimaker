using dbguimaker.DatabaseGUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace dbguimaker
{
    public partial class ComparisonDialog : Form
    {
        public Comparison.OperationType SelectedOption = Comparison.OperationType.Equals;
        public class AddComparisonDialogResult
        {
            public bool Success;
            public Comparison.OperationType Result;
        }
        private ComparisonDialog()
        {
            InitializeComponent();
        }
        public static AddComparisonDialogResult Create()
        {
            var o = new ComparisonDialog();
            var d = o.ShowDialog();
            var r = new AddComparisonDialogResult()
            {
                Success = d == DialogResult.OK,
                Result = d == DialogResult.OK ? o.SelectedOption : Comparison.OperationType.Equals
            };
            o.Close();
            return r;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            SelectedOption = Comparison.OperationType.GreaterThan;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            SelectedOption = Comparison.OperationType.Equals;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            SelectedOption = Comparison.OperationType.LessThan;
        }
    }
}
