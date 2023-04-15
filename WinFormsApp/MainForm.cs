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
        private readonly List<string> allys = new();
        private readonly ContextMenuStrip contextMenu;

        public MainForm()
        {
            InitializeComponent();

            contextMenu = new ContextMenuStrip();
            contextMenu.Width = 500;
            var item = new ToolStripLabel() { Text = "Click me, oh baby", AutoSize = true };
            item.Click += item_Click;
            contextMenu.Items.Add(item);
        }

        private void item_Click(object sender, EventArgs e)
        {
            MessageBox.Show((sender as ToolStripItem).Text);
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
            villages.AddRange(databaseVillages.Select(x => new VillageLite(x.Name, x.PlayerName, x.AllyName, new(x.X, x.Y), x.Pop)));

            allys.Clear();
            allys.AddRange(databaseVillages.Select(x => x.AllyName).Distinct());
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
            var checkedItems = allyIgnore.CheckedItems.Cast<string>().ToList();
            var filteredVillages = villages.Where(x => !checkedItems.Contains(x.AllyName));

            var x = (int)XNumeric.Value;
            var y = (int)YNumeric.Value;

            var coord = new Coordinates(x, y);

            Parallel.ForEach(filteredVillages, village =>
            {
                village.Distance = coord.Distance(village.Coord);
            });

            villages.Sort();
            DataGrid.DataSource = filteredVillages.ToList();
        }

        private void DataGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            var dataGridView = (sender as DataGridView);
            var r = dataGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
            var p = new Point(r.X, r.Y + r.Height);
            contextMenu.Show(DataGrid, p);
            //System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
            //messageBoxCS.AppendFormat("{0} = {1}", "ColumnIndex", e.ColumnIndex);
            //messageBoxCS.AppendLine();
            //messageBoxCS.AppendFormat("{0} = {1}", "RowIndex", e.RowIndex);
            //messageBoxCS.AppendLine();
            //messageBoxCS.AppendFormat("{0} = {1}", "Button", e.Button);
            //messageBoxCS.AppendLine();
            //messageBoxCS.AppendFormat("{0} = {1}", "Clicks", e.Clicks);
            //messageBoxCS.AppendLine();
            //messageBoxCS.AppendFormat("{0} = {1}", "X", e.X);
            //messageBoxCS.AppendLine();
            //messageBoxCS.AppendFormat("{0} = {1}", "Y", e.Y);
            //messageBoxCS.AppendLine();
            //messageBoxCS.AppendFormat("{0} = {1}", "Delta", e.Delta);
            //messageBoxCS.AppendLine();
            //messageBoxCS.AppendFormat("{0} = {1}", "Location", e.Location);
            //messageBoxCS.AppendLine();
            //MessageBox.Show(messageBoxCS.ToString(), "CellMouseClick Event");
        }
    }
}