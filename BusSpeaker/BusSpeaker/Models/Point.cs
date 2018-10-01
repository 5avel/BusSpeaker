namespace BusSpeaker.Models
{
    public class Point
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Sound { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool IsVisited { get; set; }
    }
}
