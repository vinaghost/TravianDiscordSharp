namespace WinFormsApp
{
    public class Data
    {
        public Data(int worldId, int x, int y)
        {
            WorldId = worldId;
            X = x;
            Y = y;
        }

        public int WorldId { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}