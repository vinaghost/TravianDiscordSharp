using MainCore.Helper;
using MainCore.Models;
using MongoDB.Driver;
using System.Text.Json;

namespace WinFormsApp
{
    public partial class MainForm : Form
    {
        private readonly List<World> worlds = new();
        private readonly List<VillageLite> villages = new();

        public MainForm()
        {
            InitializeComponent();
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
            villages.AddRange(databaseVillages.Select(x => new VillageLite(x.Name, x.PlayerName, x.AllyName, new(x.X, x.Y), x.Pop)).ToList());

            WorldLoadBtn.Enabled = true;
        }

        private void ApplyBtn_Click(object sender, EventArgs e)
        {
            var x = (int)XNumeric.Value;
            var y = (int)YNumeric.Value;

            var coord = new Coordinates(x, y);

            Parallel.ForEach(villages, village =>
            {
                village.Distance = coord.Distance(village.Coord);
            });
            villages.Sort();
            DataGrid.DataSource = villages.ToList();
        }
    }
}