namespace WinFormsApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            WorldSelector = new ComboBox();
            WorldLoadBtn = new Button();
            XNumeric = new NumericUpDown();
            YNumeric = new NumericUpDown();
            ApplyBtn = new Button();
            DataGrid = new DataGridView();
            allyIgnore = new CheckedListBox();
            contextMenu = new ContextMenuStrip(components);
            checkPlayerToolStripMenuItem = new ToolStripMenuItem();
            ingorePlayerToolStripMenuItem = new ToolStripMenuItem();
            ignoreAllyToolStripMenuItem = new ToolStripMenuItem();
            bindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)XNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)YNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DataGrid).BeginInit();
            contextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource).BeginInit();
            SuspendLayout();
            // 
            // WorldSelector
            // 
            WorldSelector.FormattingEnabled = true;
            WorldSelector.Location = new Point(11, 12);
            WorldSelector.Name = "WorldSelector";
            WorldSelector.Size = new Size(211, 23);
            WorldSelector.TabIndex = 0;
            // 
            // WorldLoadBtn
            // 
            WorldLoadBtn.Location = new Point(11, 41);
            WorldLoadBtn.Name = "WorldLoadBtn";
            WorldLoadBtn.Size = new Size(211, 34);
            WorldLoadBtn.TabIndex = 1;
            WorldLoadBtn.Text = "Load world";
            WorldLoadBtn.UseVisualStyleBackColor = true;
            WorldLoadBtn.Click += WorldLoadBtn_Click;
            // 
            // XNumeric
            // 
            XNumeric.Location = new Point(11, 81);
            XNumeric.Maximum = new decimal(new int[] { 400, 0, 0, 0 });
            XNumeric.Minimum = new decimal(new int[] { 400, 0, 0, int.MinValue });
            XNumeric.Name = "XNumeric";
            XNumeric.Size = new Size(95, 23);
            XNumeric.TabIndex = 2;
            // 
            // YNumeric
            // 
            YNumeric.Location = new Point(128, 81);
            YNumeric.Maximum = new decimal(new int[] { 400, 0, 0, 0 });
            YNumeric.Minimum = new decimal(new int[] { 400, 0, 0, int.MinValue });
            YNumeric.Name = "YNumeric";
            YNumeric.Size = new Size(94, 23);
            YNumeric.TabIndex = 3;
            // 
            // ApplyBtn
            // 
            ApplyBtn.Location = new Point(11, 404);
            ApplyBtn.Name = "ApplyBtn";
            ApplyBtn.Size = new Size(210, 34);
            ApplyBtn.TabIndex = 4;
            ApplyBtn.Text = "Apply";
            ApplyBtn.UseVisualStyleBackColor = true;
            ApplyBtn.Click += ApplyBtn_Click;
            // 
            // DataGrid
            // 
            DataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGrid.Location = new Point(227, 12);
            DataGrid.Name = "DataGrid";
            DataGrid.RowTemplate.Height = 25;
            DataGrid.Size = new Size(561, 426);
            DataGrid.TabIndex = 5;
            DataGrid.CellMouseClick += DataGrid_CellMouseClick;
            // 
            // allyIgnore
            // 
            allyIgnore.FormattingEnabled = true;
            allyIgnore.Location = new Point(10, 110);
            allyIgnore.Name = "allyIgnore";
            allyIgnore.Size = new Size(211, 292);
            allyIgnore.TabIndex = 6;
            // 
            // contextMenu
            // 
            contextMenu.Items.AddRange(new ToolStripItem[] { checkPlayerToolStripMenuItem, ingorePlayerToolStripMenuItem, ignoreAllyToolStripMenuItem });
            contextMenu.Name = "contextMenuStrip1";
            contextMenu.RenderMode = ToolStripRenderMode.System;
            contextMenu.Size = new Size(144, 70);
            // 
            // checkPlayerToolStripMenuItem
            // 
            checkPlayerToolStripMenuItem.Name = "checkPlayerToolStripMenuItem";
            checkPlayerToolStripMenuItem.Size = new Size(143, 22);
            checkPlayerToolStripMenuItem.Text = "Check player";
            checkPlayerToolStripMenuItem.Click += CheckPlayerToolStripMenuItem_Click;
            // 
            // ingorePlayerToolStripMenuItem
            // 
            ingorePlayerToolStripMenuItem.Name = "ingorePlayerToolStripMenuItem";
            ingorePlayerToolStripMenuItem.Size = new Size(143, 22);
            ingorePlayerToolStripMenuItem.Text = "Ingore player";
            ingorePlayerToolStripMenuItem.Click += IngorePlayerToolStripMenuItem_Click;
            // 
            // ignoreAllyToolStripMenuItem
            // 
            ignoreAllyToolStripMenuItem.Name = "ignoreAllyToolStripMenuItem";
            ignoreAllyToolStripMenuItem.Size = new Size(143, 22);
            ignoreAllyToolStripMenuItem.Text = "Ignore ally";
            ignoreAllyToolStripMenuItem.Click += IgnoreAllyToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(allyIgnore);
            Controls.Add(DataGrid);
            Controls.Add(ApplyBtn);
            Controls.Add(YNumeric);
            Controls.Add(XNumeric);
            Controls.Add(WorldLoadBtn);
            Controls.Add(WorldSelector);
            Name = "MainForm";
            Text = "Travian's village lookup";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)XNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)YNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)DataGrid).EndInit();
            contextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)bindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox WorldSelector;
        private Button WorldLoadBtn;
        private NumericUpDown XNumeric;
        private NumericUpDown YNumeric;
        private Button ApplyBtn;
        private DataGridView DataGrid;
        private CheckedListBox allyIgnore;
        private ContextMenuStrip contextMenu;
        private ToolStripMenuItem checkPlayerToolStripMenuItem;
        private ToolStripMenuItem ingorePlayerToolStripMenuItem;
        private ToolStripMenuItem ignoreAllyToolStripMenuItem;
        private BindingSource bindingSource;
        private DataGridViewTextBoxColumn villageNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn playerNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn allyNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn coordDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn popDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn distanceDataGridViewTextBoxColumn;
    }
}