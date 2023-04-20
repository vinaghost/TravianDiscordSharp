namespace MainCore.Models
{
    public class VillageDistance : Village, IComparable<VillageDistance>
    {
        public VillageDistance(Village village) : base(village.MapId, village.X, village.Y, village.Tribe, village.Id, village.Name, village.PlayerId, village.PlayerName, village.AllyId, village.AllyName, village.Pop, village.Region, village.IsCapital, village.IsCity, village.VictoryPoints)
        {
        }

        public VillageDistance(Village village, double distance) : this(village)
        {
            Distance = distance;
        }

        public double Distance { get; set; }

        public int CompareTo(VillageDistance other)
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