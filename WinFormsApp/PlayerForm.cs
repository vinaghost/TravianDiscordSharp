using MainCore.Models;

namespace WinFormsApp
{
    public partial class PlayerForm : Form
    {
        public PlayerForm(string playerName, string playerAlly, List<VillageDistance> villages)
        {
            InitializeComponent();
            GenerateColumn();
            DataGrid.DataSource = BindingSource;
            BindingSource.DataSource = villages;
            Text = $"Player: {playerName} ({playerAlly})";
        }

        private void GenerateColumn()
        {
            DataGrid.AutoGenerateColumns = false;

            var columns = new List<DataGridViewTextBoxColumn>()
            {
                new () { Name = "VillageName", HeaderText = "Village name", DataPropertyName = "Name" },
                new () { Name = "Coordinates", HeaderText = "Coordinates", DataPropertyName = "Coordinates" },
                new () { Name = "Population", HeaderText = "Population", DataPropertyName = "Pop" },
            };

            DataGrid.Columns.AddRange(columns.ToArray());
        }
    }
}