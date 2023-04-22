using MainCore.Models;
using MongoDB.Driver;
using System.Data;
using System.Text.Json;
using WinFormsApp.Helper;
using WinFormsApp.Models;

namespace WinFormsApp
{
    public partial class MainForm : Form
    {
        private readonly List<World> _worlds = new();
        private readonly List<VillageDistance> _villages = new();
        private readonly List<AllyItem> _allys = new();

        private int villageIndex = -1;

        public MainForm()
        {
            InitializeComponent();
            GenerateColumn();
            DataGrid.DataSource = bindingSource;
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            ApiHelper.InitHttpClient();
            var databaseWorlds = await ApiHelper.GetWorlds();
            _worlds.AddRange(databaseWorlds);
            WorldSelector.DataSource = databaseWorlds.Select(x => x.Url).ToList();
            if (File.Exists("data.json"))
            {
                var json = File.ReadAllText("data.json");
                var data = JsonSerializer.Deserialize<Data>(json);
                WorldSelector.SelectedIndex = data.WorldId;

                coordinatesUc.SetValue(data.X, data.Y);
            }
            else
            {
                WorldSelector.SelectedIndex = 0;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ApiHelper.Dispose();
            var coordinate = coordinatesUc.Coordinates;
            var data = new Data(WorldSelector.SelectedIndex, coordinate.X, coordinate.Y);
            var json = JsonSerializer.Serialize(data);
            File.WriteAllText("data.json", json);
        }

        private async void WorldLoadBtn_Click(object sender, EventArgs e)
        {
            WorldLoadBtn.Enabled = false;

            var world = _worlds[WorldSelector.SelectedIndex];
            var allyAPI = await ApiHelper.GetAlliances(world.Url);
            _allys.Clear();
            _allys.AddRange(allyAPI.Select(x => new AllyItem(x.Id, x.Name)));

            allyIgnore.BeginUpdate(); // antilag for world has a lot of ally
            allyIgnore.Items.Clear();
            foreach (var ally in _allys)
            {
                allyIgnore.Items.Add(ally);
            }
            allyIgnore.EndUpdate();

            WorldLoadBtn.Enabled = true;
        }

        private async void ApplyBtn_Click(object sender, EventArgs e)
        {
            ApplyBtn.Enabled = false;
            var checkedItems = allyIgnore.CheckedItems.Cast<AllyItem>().Select(x => x.Id).ToList();

            var coord = coordinatesUc.Coordinates;
            var villagesAPI = await ApiHelper.GetDistanceVillages(_worlds[WorldSelector.SelectedIndex].Url, coord.X, coord.Y);

            _villages.Clear();
            _villages.AddRange(villagesAPI);
            var filteredVillages = _villages.Where(x => !checkedItems.Contains(x.AllyId));

            bindingSource.DataSource = filteredVillages;
            ApplyBtn.Enabled = true;
        }

        private void DataGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            var dataGridView = (sender as DataGridView);
            var r = dataGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
            var p = new Point(r.X + r.Width / 2, r.Y + r.Height);

            var data = bindingSource.DataSource as IEnumerable<VillageDistance>;
            villageIndex = data.ElementAt(e.RowIndex).Id;
            contextMenu.Show(DataGrid, p);
        }

        private async void CheckPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var village = _villages.Find(x => x.Id == villageIndex);

            var playerVillages = await ApiHelper.GetPlayerVillages(_worlds[WorldSelector.SelectedIndex].Url, village.PlayerId);

            using var playerForm = new PlayerForm(village.PlayerName, village.AllyName, playerVillages);
            playerForm.ShowDialog();
        }

        private void IngorePlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var village = _villages.Find(x => x.Id == villageIndex);

            var data = bindingSource.DataSource as IEnumerable<VillageDistance>;
            var filteredData = data.Where(x => x.PlayerId != village.PlayerId).ToList();

            bindingSource.DataSource = filteredData;
        }

        private void IgnoreAllyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var village = _villages.Find(x => x.Id == villageIndex);

            var ally = _allys.IndexOf(_allys.Find(x => x.Id == village.AllyId));
            allyIgnore.SetItemChecked(ally, true);

            var data = bindingSource.DataSource as IEnumerable<VillageDistance>;
            var filteredData = data.Where(x => x.AllyId != village.AllyId).ToList();

            bindingSource.DataSource = filteredData;
        }

        private void GenerateColumn()
        {
            DataGrid.AutoGenerateColumns = false;

            var columns = new List<DataGridViewTextBoxColumn>()
            {
                new () { Name = "VillageName", HeaderText = "Village name", DataPropertyName = "Name" },
                new () { Name = "PlayerName", HeaderText = "Player name", DataPropertyName = "PlayerName" },
                new () { Name = "AllyName", HeaderText = "Ally name", DataPropertyName = "AllyName" },
                new () { Name = "Coordinates", HeaderText = "Coordinates", DataPropertyName = "Coordinates" },
                new () { Name = "Population", HeaderText = "Population", DataPropertyName = "Pop" },
                new () { Name = "Distance", HeaderText = "Distance", DataPropertyName = "Distance" },
            };

            DataGrid.Columns.AddRange(columns.ToArray());
        }
    }
}