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
            DataGrid = new DataGridView();
            contextMenu = new ContextMenuStrip(components);
            checkPlayerToolStripMenuItem = new ToolStripMenuItem();
            ingorePlayerToolStripMenuItem = new ToolStripMenuItem();
            ignoreAllyToolStripMenuItem = new ToolStripMenuItem();
            bindingSource = new BindingSource(components);
            MainLayoutPanel = new TableLayoutPanel();
            LeftLayoutPanel = new TableLayoutPanel();
            ApplyBtn = new Button();
            allyIgnore = new CheckedListBox();
            coordinatesUc = new UserControls.CoordinatesUc();
            WorldLoadBtn = new Button();
            WorldSelector = new ComboBox();
            LabelChooseWorld = new Label();
            LabelIgnoreAlly = new Label();
            ((System.ComponentModel.ISupportInitialize)DataGrid).BeginInit();
            contextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource).BeginInit();
            MainLayoutPanel.SuspendLayout();
            LeftLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // DataGrid
            // 
            DataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGrid.Dock = DockStyle.Fill;
            DataGrid.Location = new Point(203, 3);
            DataGrid.Name = "DataGrid";
            DataGrid.RowTemplate.Height = 25;
            DataGrid.Size = new Size(594, 444);
            DataGrid.TabIndex = 5;
            DataGrid.CellMouseClick += DataGrid_CellMouseClick;
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
            // MainLayoutPanel
            // 
            MainLayoutPanel.ColumnCount = 2;
            MainLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            MainLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            MainLayoutPanel.Controls.Add(LeftLayoutPanel, 0, 0);
            MainLayoutPanel.Controls.Add(DataGrid, 1, 0);
            MainLayoutPanel.Dock = DockStyle.Fill;
            MainLayoutPanel.Location = new Point(0, 0);
            MainLayoutPanel.Name = "MainLayoutPanel";
            MainLayoutPanel.RowCount = 1;
            MainLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            MainLayoutPanel.Size = new Size(800, 450);
            MainLayoutPanel.TabIndex = 7;
            // 
            // LeftLayoutPanel
            // 
            LeftLayoutPanel.ColumnCount = 1;
            LeftLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            LeftLayoutPanel.Controls.Add(ApplyBtn, 0, 6);
            LeftLayoutPanel.Controls.Add(allyIgnore, 0, 5);
            LeftLayoutPanel.Controls.Add(coordinatesUc, 0, 3);
            LeftLayoutPanel.Controls.Add(WorldLoadBtn, 0, 2);
            LeftLayoutPanel.Controls.Add(WorldSelector, 0, 1);
            LeftLayoutPanel.Controls.Add(LabelChooseWorld, 0, 0);
            LeftLayoutPanel.Controls.Add(LabelIgnoreAlly, 0, 4);
            LeftLayoutPanel.Dock = DockStyle.Fill;
            LeftLayoutPanel.Location = new Point(3, 3);
            LeftLayoutPanel.Name = "LeftLayoutPanel";
            LeftLayoutPanel.RowCount = 7;
            LeftLayoutPanel.RowStyles.Add(new RowStyle());
            LeftLayoutPanel.RowStyles.Add(new RowStyle());
            LeftLayoutPanel.RowStyles.Add(new RowStyle());
            LeftLayoutPanel.RowStyles.Add(new RowStyle());
            LeftLayoutPanel.RowStyles.Add(new RowStyle());
            LeftLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            LeftLayoutPanel.RowStyles.Add(new RowStyle());
            LeftLayoutPanel.Size = new Size(194, 444);
            LeftLayoutPanel.TabIndex = 0;
            // 
            // ApplyBtn
            // 
            ApplyBtn.Dock = DockStyle.Fill;
            ApplyBtn.Location = new Point(3, 411);
            ApplyBtn.Name = "ApplyBtn";
            ApplyBtn.Size = new Size(188, 30);
            ApplyBtn.TabIndex = 12;
            ApplyBtn.Text = "Apply";
            ApplyBtn.UseVisualStyleBackColor = true;
            ApplyBtn.Click += ApplyBtn_Click;
            // 
            // allyIgnore
            // 
            allyIgnore.Dock = DockStyle.Fill;
            allyIgnore.FormattingEnabled = true;
            allyIgnore.Location = new Point(3, 131);
            allyIgnore.Name = "allyIgnore";
            allyIgnore.Size = new Size(188, 274);
            allyIgnore.TabIndex = 11;
            // 
            // coordinatesUc
            // 
            coordinatesUc.Location = new Point(3, 83);
            coordinatesUc.Name = "coordinatesUc";
            coordinatesUc.Size = new Size(188, 27);
            coordinatesUc.TabIndex = 9;
            // 
            // WorldLoadBtn
            // 
            WorldLoadBtn.Dock = DockStyle.Fill;
            WorldLoadBtn.Location = new Point(3, 47);
            WorldLoadBtn.Name = "WorldLoadBtn";
            WorldLoadBtn.Size = new Size(188, 30);
            WorldLoadBtn.TabIndex = 2;
            WorldLoadBtn.Text = "Load world";
            WorldLoadBtn.UseVisualStyleBackColor = true;
            WorldLoadBtn.Click += WorldLoadBtn_Click;
            // 
            // WorldSelector
            // 
            WorldSelector.Dock = DockStyle.Fill;
            WorldSelector.FormattingEnabled = true;
            WorldSelector.Location = new Point(3, 18);
            WorldSelector.Name = "WorldSelector";
            WorldSelector.Size = new Size(188, 23);
            WorldSelector.TabIndex = 1;
            // 
            // LabelChooseWorld
            // 
            LabelChooseWorld.AutoSize = true;
            LabelChooseWorld.Dock = DockStyle.Fill;
            LabelChooseWorld.Location = new Point(3, 0);
            LabelChooseWorld.Name = "LabelChooseWorld";
            LabelChooseWorld.Size = new Size(188, 15);
            LabelChooseWorld.TabIndex = 0;
            LabelChooseWorld.Text = "Choose world";
            LabelChooseWorld.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LabelIgnoreAlly
            // 
            LabelIgnoreAlly.AutoSize = true;
            LabelIgnoreAlly.Dock = DockStyle.Fill;
            LabelIgnoreAlly.Location = new Point(3, 113);
            LabelIgnoreAlly.Name = "LabelIgnoreAlly";
            LabelIgnoreAlly.Size = new Size(188, 15);
            LabelIgnoreAlly.TabIndex = 10;
            LabelIgnoreAlly.Text = "Ignore ally";
            LabelIgnoreAlly.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(MainLayoutPanel);
            Name = "MainForm";
            Text = "Travian's village lookup";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)DataGrid).EndInit();
            contextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)bindingSource).EndInit();
            MainLayoutPanel.ResumeLayout(false);
            LeftLayoutPanel.ResumeLayout(false);
            LeftLayoutPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView DataGrid;
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
        private TableLayoutPanel MainLayoutPanel;
        private TableLayoutPanel LeftLayoutPanel;
        private Button ApplyBtn;
        private CheckedListBox allyIgnore;
        private UserControls.CoordinatesUc coordinatesUc;
        private Button WorldLoadBtn;
        private ComboBox WorldSelector;
        private Label LabelChooseWorld;
        private Label LabelIgnoreAlly;
    }
}