﻿using System.Collections.Generic;
using System.Windows.Forms;

namespace dbguimaker.DatabaseGUI
{
    public partial class CheckBox
    {
        public override Operation[] Inputs => new Operation[2] {this.label, this.data};

        public override string[] InputTexts => new string[2] { "Label", "Value" };

        protected override Control GenerateEditorRepresentation()
        {
            System.Windows.Forms.CheckBox repr = new System.Windows.Forms.CheckBox();
            repr.AutoSize = true;
            repr.Font = Data.DefaultRepresentationFont;
            repr.Text = "\"Label\"";
            repr.Checked = true;
            return repr;
        }
    }
}