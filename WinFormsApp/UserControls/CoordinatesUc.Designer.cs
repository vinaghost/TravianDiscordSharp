namespace WinFormsApp.UserControls
{
    partial class CoordinatesUc
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LayoutPanel = new TableLayoutPanel();
            labelY = new Label();
            NumericY = new NumericUpDown();
            NumericX = new NumericUpDown();
            labelX = new Label();
            LayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NumericY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumericX).BeginInit();
            SuspendLayout();
            // 
            // LayoutPanel
            // 
            LayoutPanel.ColumnCount = 4;
            LayoutPanel.ColumnStyles.Add(new ColumnStyle());
            LayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            LayoutPanel.ColumnStyles.Add(new ColumnStyle());
            LayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            LayoutPanel.Controls.Add(labelY, 2, 0);
            LayoutPanel.Controls.Add(NumericY, 3, 0);
            LayoutPanel.Controls.Add(NumericX, 1, 0);
            LayoutPanel.Controls.Add(labelX, 0, 0);
            LayoutPanel.Dock = DockStyle.Fill;
            LayoutPanel.Location = new Point(0, 0);
            LayoutPanel.Name = "LayoutPanel";
            LayoutPanel.RowCount = 1;
            LayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            LayoutPanel.Size = new Size(266, 27);
            LayoutPanel.TabIndex = 0;
            // 
            // labelY
            // 
            labelY.AutoSize = true;
            labelY.Dock = DockStyle.Fill;
            labelY.Location = new Point(136, 0);
            labelY.Name = "labelY";
            labelY.Size = new Size(14, 27);
            labelY.TabIndex = 4;
            labelY.Text = "Y";
            labelY.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // NumericY
            // 
            NumericY.Dock = DockStyle.Fill;
            NumericY.Location = new Point(156, 3);
            NumericY.Maximum = new decimal(new int[] { 400, 0, 0, 0 });
            NumericY.Minimum = new decimal(new int[] { 400, 0, 0, int.MinValue });
            NumericY.Name = "NumericY";
            NumericY.Size = new Size(107, 23);
            NumericY.TabIndex = 2;
            // 
            // NumericX
            // 
            NumericX.Dock = DockStyle.Fill;
            NumericX.Location = new Point(23, 3);
            NumericX.Maximum = new decimal(new int[] { 400, 0, 0, 0 });
            NumericX.Minimum = new decimal(new int[] { 400, 0, 0, int.MinValue });
            NumericX.Name = "NumericX";
            NumericX.Size = new Size(107, 23);
            NumericX.TabIndex = 0;
            // 
            // labelX
            // 
            labelX.AutoSize = true;
            labelX.Dock = DockStyle.Fill;
            labelX.Location = new Point(3, 0);
            labelX.Name = "labelX";
            labelX.Size = new Size(14, 27);
            labelX.TabIndex = 3;
            labelX.Text = "X";
            labelX.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // CoordinatesUc
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(LayoutPanel);
            Name = "CoordinatesUc";
            Size = new Size(266, 27);
            LayoutPanel.ResumeLayout(false);
            LayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NumericY).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumericX).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel LayoutPanel;
        private Label labelY;
        private NumericUpDown NumericY;
        private NumericUpDown NumericX;
        private Label labelX;
    }
}
