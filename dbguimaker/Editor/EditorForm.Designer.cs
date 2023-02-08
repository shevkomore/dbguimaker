namespace dbguimaker
{
    partial class EditorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorForm));
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripRefreshButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.columnsListBox = new System.Windows.Forms.ListBox();
            this.tablesListBox = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.viewsLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(765, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripRefreshButton,
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripRefreshButton
            // 
            this.toolStripRefreshButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripRefreshButton.Image = ((System.Drawing.Image)(resources.GetObject("toolStripRefreshButton.Image")));
            this.toolStripRefreshButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripRefreshButton.Name = "toolStripRefreshButton";
            this.toolStripRefreshButton.Size = new System.Drawing.Size(23, 22);
            this.toolStripRefreshButton.Text = "Refresh (text)";
            this.toolStripRefreshButton.ToolTipText = "Refresh";
            this.toolStripRefreshButton.Click += new System.EventHandler(this.toolStripRefreshButton_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.ToolTipText = "Create New Element";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.ToolTipText = "Change Connections";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "toolStripButton3";
            this.toolStripButton3.ToolTipText = "Delete Element";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.columnsListBox);
            this.groupBox1.Controls.Add(this.tablesListBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(206, 425);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tables / Fields";
            // 
            // columnsListBox
            // 
            this.columnsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.columnsListBox.FormattingEnabled = true;
            this.columnsListBox.Items.AddRange(new object[] {
            "a"});
            this.columnsListBox.Location = new System.Drawing.Point(3, 111);
            this.columnsListBox.Name = "columnsListBox";
            this.columnsListBox.Size = new System.Drawing.Size(200, 311);
            this.columnsListBox.TabIndex = 1;
            this.columnsListBox.SelectedIndexChanged += new System.EventHandler(this.columnsListBox_SelectedIndexChanged);
            // 
            // tablesListBox
            // 
            this.tablesListBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.tablesListBox.FormattingEnabled = true;
            this.tablesListBox.HorizontalScrollbar = true;
            this.tablesListBox.Location = new System.Drawing.Point(3, 16);
            this.tablesListBox.Name = "tablesListBox";
            this.tablesListBox.Size = new System.Drawing.Size(200, 95);
            this.tablesListBox.TabIndex = 0;
            this.tablesListBox.SelectedIndexChanged += new System.EventHandler(this.tablesListBox_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.AllowDrop = true;
            this.panel1.AutoScroll = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.viewsLayoutPanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(206, 25);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(594, 425);
            this.panel1.TabIndex = 3;
            // 
            // viewsLayoutPanel
            // 
            this.viewsLayoutPanel.ColumnCount = 1;
            this.viewsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.viewsLayoutPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.viewsLayoutPanel.Location = new System.Drawing.Point(437, 0);
            this.viewsLayoutPanel.Name = "viewsLayoutPanel";
            this.viewsLayoutPanel.RowCount = 2;
            this.viewsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.viewsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.viewsLayoutPanel.Size = new System.Drawing.Size(157, 425);
            this.viewsLayoutPanel.TabIndex = 0;
            // 
            // EditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "EditorForm";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditorForm_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox columnsListBox;
        private System.Windows.Forms.ListBox tablesListBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripButton toolStripRefreshButton;
        private System.Windows.Forms.TableLayoutPanel viewsLayoutPanel;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
    }
}