using SQLite;

namespace BusSpeaker.Models
{
    [Table("Points")]
    public class Point
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Sound { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool IsVisited { get; set; }
    }
}
