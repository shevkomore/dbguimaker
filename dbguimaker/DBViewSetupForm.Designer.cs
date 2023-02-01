namespace dbguimaker
{
    partial class DBViewSetupForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataPathTextBox = new System.Windows.Forms.TextBox();
            this.databasePathTextBox = new System.Windows.Forms.TextBox();
            this.useFixedPathCheckBox = new System.Windows.Forms.CheckBox();
            this.dataPathDialogButton = new System.Windows.Forms.Button();
            this.databasePathDialogButton = new System.Windows.Forms.Button();
            this.continueButton = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(85, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "File Path:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(85, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Database Path:";
            // 
            // dataPathTextBox
            // 
            this.dataPathTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataPathTextBox.Location = new System.Drawing.Point(296, 86);
            this.dataPathTextBox.Name = "dataPathTextBox";
            this.dataPathTextBox.Size = new System.Drawing.Size(335, 27);
            this.dataPathTextBox.TabIndex = 2;
            // 
            // databasePathTextBox
            // 
            this.databasePathTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.databasePathTextBox.Location = new System.Drawing.Point(296, 128);
            this.databasePathTextBox.Name = "databasePathTextBox";
            this.databasePathTextBox.Size = new System.Drawing.Size(335, 27);
            this.databasePathTextBox.TabIndex = 3;
            // 
            // useFixedPathCheckBox
            // 
            this.useFixedPathCheckBox.AutoSize = true;
            this.useFixedPathCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.useFixedPathCheckBox.Checked = true;
            this.useFixedPathCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.useFixedPathCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.useFixedPathCheckBox.Location = new System.Drawing.Point(296, 161);
            this.useFixedPathCheckBox.Name = "useFixedPathCheckBox";
            this.useFixedPathCheckBox.Size = new System.Drawing.Size(179, 21);
            this.useFixedPathCheckBox.TabIndex = 4;
            this.useFixedPathCheckBox.Text = "Use file\'s database path";
            this.useFixedPathCheckBox.UseVisualStyleBackColor = true;
            this.useFixedPathCheckBox.CheckedChanged += new System.EventHandler(this.useFixedPathCheckBox_CheckedChanged);
            // 
            // dataPathDialogButton
            // 
            this.dataPathDialogButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataPathDialogButton.Location = new System.Drawing.Point(656, 86);
            this.dataPathDialogButton.Name = "dataPathDialogButton";
            this.dataPathDialogButton.Size = new System.Drawing.Size(30, 27);
            this.dataPathDialogButton.TabIndex = 5;
            this.dataPathDialogButton.Text = "...";
            this.dataPathDialogButton.UseVisualStyleBackColor = true;
            this.dataPathDialogButton.Click += new System.EventHandler(this.dataPathDialogButton_Click);
            // 
            // databasePathDialogButton
            // 
            this.databasePathDialogButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.databasePathDialogButton.Location = new System.Drawing.Point(656, 128);
            this.databasePathDialogButton.Name = "databasePathDialogButton";
            this.databasePathDialogButton.Size = new System.Drawing.Size(30, 27);
            this.databasePathDialogButton.TabIndex = 6;
            this.databasePathDialogButton.Text = "...";
            this.databasePathDialogButton.UseVisualStyleBackColor = true;
            this.databasePathDialogButton.Click += new System.EventHandler(this.databasePathDialogButton_Click);
            // 
            // continueButton
            // 
            this.continueButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.continueButton.Location = new System.Drawing.Point(618, 337);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(91, 35);
            this.continueButton.TabIndex = 7;
            this.continueButton.Text = "Open";
            this.continueButton.UseVisualStyleBackColor = true;
            this.continueButton.Click += new System.EventHandler(this.continueButton_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // DBViewSetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.continueButton);
            this.Controls.Add(this.databasePathDialogButton);
            this.Controls.Add(this.dataPathDialogButton);
            this.Controls.Add(this.useFixedPathCheckBox);
            this.Controls.Add(this.databasePathTextBox);
            this.Controls.Add(this.dataPathTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "DBViewSetupForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox dataPathTextBox;
        private System.Windows.Forms.TextBox databasePathTextBox;
        private System.Windows.Forms.CheckBox useFixedPathCheckBox;
        private System.Windows.Forms.Button dataPathDialogButton;
        private System.Windows.Forms.Button databasePathDialogButton;
        private System.Windows.Forms.Button continueButton;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}