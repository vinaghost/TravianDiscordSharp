namespace MainCore.Models
{
    public class TravianObject
    {
        public TravianObject(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}