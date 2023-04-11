using MongoDB.Bson;

namespace MainCore.Models
{
    public class World
    {
        public World(string url, DateTime startDate)
        {
            Url = url;
            StartDate = startDate;
        }

        public ObjectId Id { get; set; }
        public string Url { get; set; }
        public DateTime StartDate { get; set; }

        public override string ToString()
        {
            return $"{Url} - {StartDate.ToShortDateString()}";
        }
    }
}