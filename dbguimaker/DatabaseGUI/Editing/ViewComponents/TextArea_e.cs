using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Windows.Forms;

namespace dbguimaker.DatabaseGUI
{
    public partial class TextArea
    {
        public override Operation[] Inputs => new Operation[2] { this.label, this.data };
        public override void SetInput(int index, Operation operation)
        {
            switch (index)
            {
                case 0:
                    label = operation;
                    return;
                case 1:
                    data = operation;
                    return;
                default:
                    throw new IndexOutOfRangeException();
            }
        }

        public override string[] InputTexts => new string[2] { "Label", "Value" };

        protected override Control GenerateEditorRepresentation()
        {
            TableLayoutPanel layout = new TableLayoutPanel();
            layout.AutoSize = true;
            layout.ColumnCount = 2;
            layout.ColumnStyles.Add(new ColumnStyle());
            System.Windows.Forms.Label label = new System.Windows.Forms.Label();
            label.AutoSize = true;
            label.Font = Data.DefaultRepresentationFont;
            label.Text = "\"Label\"";
            layout.Controls.Add(label);
            TextBox textBox = new TextBox();
            textBox.Text = "\"Value\"";
            textBox.AutoSize = true;
            textBox.Font = Data.DefaultRepresentationFont;
            textBox.Width = TextRenderer.MeasureText(textBox.Text, textBox.Font).Width;
            textBox.ReadOnly = true;
            layout.Controls.Add(textBox);
            return layout;
        }
    }
}