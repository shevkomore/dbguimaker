namespace dbguimaker
{
    partial class NewProjectForm
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
            this.DatabaseTextBox = new System.Windows.Forms.TextBox();
            this.DatabaseFileDialogButton = new System.Windows.Forms.Button();
            this.DatabaseSelectLabel = new System.Windows.Forms.Label();
            this.NameSelectLabel = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.ContinueButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DatabaseTextBox
            // 
            this.DatabaseTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DatabaseTextBox.Location = new System.Drawing.Point(210, 24);
            this.DatabaseTextBox.Name = "DatabaseTextBox";
            this.DatabaseTextBox.Size = new System.Drawing.Size(332, 26);
            this.DatabaseTextBox.TabIndex = 0;
            this.DatabaseTextBox.Text = "default.db";
            // 
            // DatabaseFileDialogButton
            // 
            this.DatabaseFileDialogButton.Location = new System.Drawing.Point(562, 24);
            this.DatabaseFileDialogButton.Name = "DatabaseFileDialogButton";
            this.DatabaseFileDialogButton.Size = new System.Drawing.Size(27, 26);
            this.DatabaseFileDialogButton.TabIndex = 1;
            this.DatabaseFileDialogButton.Text = "...";
            this.DatabaseFileDialogButton.UseVisualStyleBackColor = true;
            this.DatabaseFileDialogButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // DatabaseSelectLabel
            // 
            this.DatabaseSelectLabel.AutoSize = true;
            this.DatabaseSelectLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DatabaseSelectLabel.Location = new System.Drawing.Point(84, 26);
            this.DatabaseSelectLabel.Name = "DatabaseSelectLabel";
            this.DatabaseSelectLabel.Size = new System.Drawing.Size(93, 24);
            this.DatabaseSelectLabel.TabIndex = 2;
            this.DatabaseSelectLabel.Text = "Database:";
            // 
            // NameSelectLabel
            // 
            this.NameSelectLabel.AutoSize = true;
            this.NameSelectLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameSelectLabel.Location = new System.Drawing.Point(84, 96);
            this.NameSelectLabel.Name = "NameSelectLabel";
            this.NameSelectLabel.Size = new System.Drawing.Size(66, 24);
            this.NameSelectLabel.TabIndex = 3;
            this.NameSelectLabel.Text = "Name:";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameTextBox.Location = new System.Drawing.Point(210, 94);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(332, 26);
            this.NameTextBox.TabIndex = 4;
            this.NameTextBox.Text = "view1";
            // 
            // ContinueButton
            // 
            this.ContinueButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContinueButton.Location = new System.Drawing.Point(510, 166);
            this.ContinueButton.Name = "ContinueButton";
            this.ContinueButton.Size = new System.Drawing.Size(79, 39);
            this.ContinueButton.TabIndex = 5;
            this.ContinueButton.Text = "Create";
            this.ContinueButton.UseVisualStyleBackColor = true;
            this.ContinueButton.Click += new System.EventHandler(this.ContinueButton_Click);
            // 
            // NewProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ContinueButton);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.NameSelectLabel);
            this.Controls.Add(this.DatabaseSelectLabel);
            this.Controls.Add(this.DatabaseFileDialogButton);
            this.Controls.Add(this.DatabaseTextBox);
            this.Name = "NewProjectForm";
            this.Text = "NewProjectForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.NewProjectForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox DatabaseTextBox;
        private System.Windows.Forms.Button DatabaseFileDialogButton;
        private System.Windows.Forms.Label DatabaseSelectLabel;
        private System.Windows.Forms.Label NameSelectLabel;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Button ContinueButton;
    }
}