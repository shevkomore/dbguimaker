using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbguimaker
{
    public partial class ConstantDialog : Form
    {
        public class AddConstantDialogResult 
        {
            public bool Success;
            public string Text;
        }
        private ConstantDialog(string[] defaultOptions)
        {
            InitializeComponent();
            comboBox1.Items.AddRange( defaultOptions);
        }
        public static AddConstantDialogResult Create(string[] defaultOptions)
        {
            var o = new ConstantDialog(defaultOptions);
            var d = o.ShowDialog();
            var r = new AddConstantDialogResult()
            {
                Success = d == DialogResult.OK,
                Text = d == DialogResult.OK ? o.comboBox1.Text : ""
            };
            o.Close();
            return r;
        }
    }
}
