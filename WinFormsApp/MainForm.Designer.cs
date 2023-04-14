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
            WorldSelector = new ComboBox();
            WorldLoadBtn = new Button();
            XNumeric = new NumericUpDown();
            YNumeric = new NumericUpDown();
            ApplyBtn = new Button();
            DataGrid = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)XNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)YNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DataGrid).BeginInit();
            SuspendLayout();
            // 
            // WorldSelector
            // 
            WorldSelector.FormattingEnabled = true;
            WorldSelector.Location = new Point(48, 42);
            WorldSelector.Name = "WorldSelector";
            WorldSelector.Size = new Size(210, 23);
            WorldSelector.TabIndex = 0;
            // 
            // WorldLoadBtn
            // 
            WorldLoadBtn.Location = new Point(48, 71);
            WorldLoadBtn.Name = "WorldLoadBtn";
            WorldLoadBtn.Size = new Size(209, 34);
            WorldLoadBtn.TabIndex = 1;
            WorldLoadBtn.Text = "Load world";
            WorldLoadBtn.UseVisualStyleBackColor = true;
            // 
            // XNumeric
            // 
            XNumeric.Location = new Point(48, 111);
            XNumeric.Name = "XNumeric";
            XNumeric.Size = new Size(95, 23);
            XNumeric.TabIndex = 2;
            // 
            // YNumeric
            // 
            YNumeric.Location = new Point(163, 111);
            YNumeric.Name = "YNumeric";
            YNumeric.Size = new Size(95, 23);
            YNumeric.TabIndex = 3;
            // 
            // ApplyBtn
            // 
            ApplyBtn.Location = new Point(49, 140);
            ApplyBtn.Name = "ApplyBtn";
            ApplyBtn.Size = new Size(209, 34);
            ApplyBtn.TabIndex = 4;
            ApplyBtn.Text = "Apply";
            ApplyBtn.UseVisualStyleBackColor = true;
            // 
            // DataGrid
            // 
            DataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGrid.Location = new Point(344, 21);
            DataGrid.Name = "DataGrid";
            DataGrid.RowTemplate.Height = 25;
            DataGrid.Size = new Size(409, 392);
            DataGrid.TabIndex = 5;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(DataGrid);
            Controls.Add(ApplyBtn);
            Controls.Add(YNumeric);
            Controls.Add(XNumeric);
            Controls.Add(WorldLoadBtn);
            Controls.Add(WorldSelector);
            Name = "MainForm";
            Text = "Travian's village lookup";
            ((System.ComponentModel.ISupportInitialize)XNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)YNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)DataGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox WorldSelector;
        private Button WorldLoadBtn;
        private NumericUpDown XNumeric;
        private NumericUpDown YNumeric;
        private Button ApplyBtn;
        private DataGridView DataGrid;
    }
}