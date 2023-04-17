using MainCore.Helper;
using MainCore.Models;
using MongoDB.Driver;
using System.Data;
using System.Diagnostics;
using System.Text.Json;
using WinFormsApp.Models;

namespace WinFormsApp
{
    public partial class MainForm : Form
    {
        private readonly List<World> worlds = new();
        private readonly List<VillageDistance> villages = new();
        private readonly List<AllyItem> allys = new();

        private int villageIndex = -1;

        public MainForm()
        {
            InitializeComponent();
            GenerateColumn();
            DataGrid.DataSource = bindingSource;
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            var databaseWorlds = await MongoHelper.GetWorldCollection();
            worlds.AddRange(databaseWorlds);
            WorldSelector.DataSource = databaseWorlds.Select(x => x.Url).ToList();
            if (File.Exists("data.json"))
            {
                var json = File.ReadAllText("data.json");
                var data = JsonSerializer.Deserialize<Data>(json);
                WorldSelector.SelectedIndex = data.WorldId;
                XNumeric.Value = data.X;
                YNumeric.Value = data.Y;
            }
            else
            {
                WorldSelector.SelectedIndex = 0;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var data = new Data(WorldSelector.SelectedIndex, (int)XNumeric.Value, (int)YNumeric.Value);
            var json = JsonSerializer.Serialize(data);
            File.WriteAllText("data.json", json);
        }

        private async void WorldLoadBtn_Click(object sender, EventArgs e)
        {
            WorldLoadBtn.Enabled = false;

            var world = worlds[WorldSelector.SelectedIndex];

            villages.Clear();
            var databaseVillages = await MongoHelper.GetVillageCollection(world.Url);
            villages.AddRange(databaseVillages.Select(x => new VillageDistance(x)));

            allys.Clear();
            allys.AddRange(databaseVillages.DistinctBy(x => x.AllyId).Select(x => new AllyItem(x.AllyId, x.AllyName)));
            allyIgnore.BeginUpdate(); // antilag for world has a lot of ally
            allyIgnore.Items.Clear();
            foreach (var ally in allys)
            {
                allyIgnore.Items.Add(ally);
            }
            allyIgnore.EndUpdate();

            WorldLoadBtn.Enabled = true;
        }

        private void ApplyBtn_Click(object sender, EventArgs e)
        {
            var checkedItems = allyIgnore.CheckedItems.Cast<AllyItem>().Select(x => x.Id).ToList();
            var filteredVillages = villages.Where(x => !checkedItems.Contains(x.AllyId));

            var x = (int)XNumeric.Value;
            var y = (int)YNumeric.Value;

            var coord = new Coordinates(x, y);

            Parallel.ForEach(filteredVillages, village =>
            {
                village.Distance = coord.Distance(new Coordinates(village.X, village.Y));
            });

            villages.Sort();
            bindingSource.DataSource = filteredVillages;
        }

        private void DataGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            var dataGridView = (sender as DataGridView);
            var r = dataGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
            var p = new Point(r.X + r.Width, r.Y + r.Height);

            var data = bindingSource.DataSource as IEnumerable<VillageDistance>;
            villageIndex = data.ElementAt(e.RowIndex).Id;
            contextMenu.Show(DataGrid, p);
        }

        private void CheckPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var village = villages.Find(x => x.Id == villageIndex);
            stopWatch.Stop();
            MessageBox.Show($"Found {village.Name} in {stopWatch.ElapsedMilliseconds}ms");
        }

        private void IngorePlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var village = villages.Find(x => x.Id == villageIndex);
            MessageBox.Show("IngorePlayer");
        }

        private void IgnoreAllyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var village = villages.Find(x => x.Id == villageIndex);
            var ally = allys.IndexOf(allys.Find(x => x.Id == village.AllyId));
            allyIgnore.SetItemChecked(ally, true);

            var checkedItems = allyIgnore.CheckedItems.Cast<AllyItem>().Select(x => x.Id).ToList();
            var filteredVillages = villages.Where(x => !checkedItems.Contains(x.AllyId));

            var x = (int)XNumeric.Value;
            var y = (int)YNumeric.Value;

            var coord = new Coordinates(x, y);

            Parallel.ForEach(filteredVillages, village =>
            {
                village.Distance = coord.Distance(new Coordinates(village.X, village.Y));
            });

            villages.Sort();
            bindingSource.DataSource = filteredVillages;
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