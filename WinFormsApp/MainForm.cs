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
            var databaseWorlds = await GetWorldsFromDatabase();
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

        private static async Task<List<World>> GetWorldsFromDatabase()
        {
            var client = MongoHelper.GetClient();
            var collection = client.GetDatabase("TravianWorldDatabase").GetCollection<World>("TravianOfficial");
            return await collection.AsQueryable().ToListAsync();
        }

        private async void WorldLoadBtn_Click(object sender, EventArgs e)
        {
            WorldLoadBtn.Enabled = false;

            var world = worlds[WorldSelector.SelectedIndex];
            villages.Clear();
            await Task.Run(() =>
            {
                var databaseVillages = GetVillagesFromDatabase(world.Url);
                villages.AddRange(databaseVillages);
            });
            WorldLoadBtn.Enabled = true;
        }

        private static List<VillageLite> GetVillagesFromDatabase(string world)
        {
            var client = MongoHelper.GetClient();
            var collection = client.GetDatabase("TravianOfficialWorld").GetCollection<Village>(world);
            return collection.AsQueryable().Select(x => new VillageLite(x.Name, x.PlayerName, x.AllyName, x.X, x.Y, x.Pop)).ToList();
        }

        private void ApplyBtn_Click(object sender, EventArgs e)
        {
            var x = (int)XNumeric.Value;
            var y = (int)YNumeric.Value;

            Parallel.ForEach(villages, village =>
            {
                village.Distance = Distance(x, y, village.X, village.Y);
            });
            villages.Sort();
            DataGrid.DataSource = villages.ToList();
        }

        private static double Distance(int x1, int y1, int x2, int y2)
        {
            var x = Delta(x1, x2);
            var y = Delta(y1, y2);
            return Math.Round(Math.Sqrt(x * x + y * y), 2);
        }

        private static double Delta(int c1, int c2)
        {
            return (c1 - c2 + (3 * 200 + 1)) % (2 * 200 + 1) - 200;
        }
    }
}