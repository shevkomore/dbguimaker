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
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.addLabelToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.addFieldToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.addTextboxToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.addConstantToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.addComparisonToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripDeleteButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tablesListBox = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.viewsLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.InputsLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
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
            this.toolStripSeparator1,
            this.addLabelToolStripButton,
            this.addFieldToolStripButton,
            this.addTextboxToolStripButton,
            this.toolStripSeparator4,
            this.addConstantToolStripButton,
            this.addComparisonToolStripButton,
            this.toolStripSeparator3,
            this.ToolStripDeleteButton,
            this.toolStripSeparator2,
            this.toolStripButton4,
            this.toolStripButton1});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.Size = new System.Drawing.Size(989, 25);
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // addLabelToolStripButton
            // 
            this.addLabelToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addLabelToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("addLabelToolStripButton.Image")));
            this.addLabelToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addLabelToolStripButton.Name = "addLabelToolStripButton";
            this.addLabelToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.addLabelToolStripButton.Text = "toolStripButton1";
            this.addLabelToolStripButton.ToolTipText = "Create a Label";
            this.addLabelToolStripButton.Click += new System.EventHandler(this.addLabelToolStripButton_Click);
            // 
            // addFieldToolStripButton
            // 
            this.addFieldToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addFieldToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("addFieldToolStripButton.Image")));
            this.addFieldToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addFieldToolStripButton.Name = "addFieldToolStripButton";
            this.addFieldToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.addFieldToolStripButton.Text = "toolStripButton1";
            this.addFieldToolStripButton.ToolTipText = "Add a Text Field";
            this.addFieldToolStripButton.Click += new System.EventHandler(this.addFieldToolStripButton_Click);
            // 
            // addTextboxToolStripButton
            // 
            this.addTextboxToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addTextboxToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("addTextboxToolStripButton.Image")));
            this.addTextboxToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addTextboxToolStripButton.Name = "addTextboxToolStripButton";
            this.addTextboxToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.addTextboxToolStripButton.Text = "toolStripButton1";
            this.addTextboxToolStripButton.ToolTipText = "Add a Checkbox";
            this.addTextboxToolStripButton.Click += new System.EventHandler(this.addTextboxToolStripButton_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // addConstantToolStripButton
            // 
            this.addConstantToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addConstantToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("addConstantToolStripButton.Image")));
            this.addConstantToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addConstantToolStripButton.Name = "addConstantToolStripButton";
            this.addConstantToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.addConstantToolStripButton.Text = "toolStripButton1";
            this.addConstantToolStripButton.ToolTipText = "Add a Constant";
            this.addConstantToolStripButton.Click += new System.EventHandler(this.addConstantToolStripButton_Click);
            // 
            // addComparisonToolStripButton
            // 
            this.addComparisonToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addComparisonToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("addComparisonToolStripButton.Image")));
            this.addComparisonToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addComparisonToolStripButton.Name = "addComparisonToolStripButton";
            this.addComparisonToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.addComparisonToolStripButton.Text = "toolStripButton1";
            this.addComparisonToolStripButton.ToolTipText = "Add a Comparison";
            this.addComparisonToolStripButton.Click += new System.EventHandler(this.addComparisonToolStripButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // ToolStripDeleteButton
            // 
            this.ToolStripDeleteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripDeleteButton.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripDeleteButton.Image")));
            this.ToolStripDeleteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripDeleteButton.Name = "ToolStripDeleteButton";
            this.ToolStripDeleteButton.Size = new System.Drawing.Size(23, 22);
            this.ToolStripDeleteButton.Text = "Delete Element";
            this.ToolStripDeleteButton.ToolTipText = "Delete Element";
            this.ToolStripDeleteButton.Click += new System.EventHandler(this.ToolStripDeleteButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "toolStripSaveButton";
            this.toolStripButton4.ToolTipText = "Save created form";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripSaveButton_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.InputsLayoutPanel);
            this.groupBox1.Controls.Add(this.tablesListBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(206, 585);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tables / Fields";
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
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.viewsLayoutPanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(989, 585);
            this.panel1.TabIndex = 3;
            // 
            // viewsLayoutPanel
            // 
            this.viewsLayoutPanel.ColumnCount = 1;
            this.viewsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.viewsLayoutPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.viewsLayoutPanel.Location = new System.Drawing.Point(707, 0);
            this.viewsLayoutPanel.Name = "viewsLayoutPanel";
            this.viewsLayoutPanel.RowCount = 2;
            this.viewsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.viewsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.viewsLayoutPanel.Size = new System.Drawing.Size(282, 585);
            this.viewsLayoutPanel.TabIndex = 0;
            // 
            // InputsLayoutPanel
            // 
            this.InputsLayoutPanel.AutoScroll = true;
            this.InputsLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InputsLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.InputsLayoutPanel.Location = new System.Drawing.Point(3, 111);
            this.InputsLayoutPanel.Name = "InputsLayoutPanel";
            this.InputsLayoutPanel.Size = new System.Drawing.Size(200, 471);
            this.InputsLayoutPanel.TabIndex = 1;
            this.InputsLayoutPanel.WrapContents = false;
            this.InputsLayoutPanel.Scroll += new System.Windows.Forms.ScrollEventHandler(this.InputsLayoutPanel_Scroll);
            // 
            // EditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 610);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
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
        private System.Windows.Forms.ListBox tablesListBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripButton toolStripRefreshButton;
        private System.Windows.Forms.TableLayoutPanel viewsLayoutPanel;
        private System.Windows.Forms.ToolStripButton ToolStripDeleteButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton addLabelToolStripButton;
        private System.Windows.Forms.ToolStripButton addFieldToolStripButton;
        private System.Windows.Forms.ToolStripButton addTextboxToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton addConstantToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton addComparisonToolStripButton;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.FlowLayoutPanel InputsLayoutPanel;
    }
}