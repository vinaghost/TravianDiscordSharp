namespace MainCore.Models
{
    public class VillageLite : IComparable<VillageLite>
    {
        public VillageLite(string villageName, string playerName, string allyName, int x, int y, int pop)
        {
            VillageName = villageName;
            PlayerName = playerName;
            AllyName = allyName;
            X = x;
            Y = y;
            Pop = pop;
        }

        public string VillageName { get; set; }

        public string PlayerName { get; set; }
        public string AllyName { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Pop { get; set; }
        public double Distance { get; set; }

        public int CompareTo(VillageLite other)
        {
            if (other is null)
                return 1;
            if (Distance > other.Distance)
                return 1;
            else if (Distance < other.Distance)
                return -1;
            else
                return 0;
        }
    }
}