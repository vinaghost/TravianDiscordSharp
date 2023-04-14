namespace MainCore.Models
{
    public class VillageLite : IComparable<VillageLite>
    {
        public VillageLite(string villageName, string playerName, string allyName, Coordinates coord, int pop)
        {
            VillageName = villageName;
            PlayerName = playerName;
            AllyName = allyName;
            Coord = coord;
            Pop = pop;
        }

        public string VillageName { get; set; }

        public string PlayerName { get; set; }
        public string AllyName { get; set; }
        public Coordinates Coord { get; set; }
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