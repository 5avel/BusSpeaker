using System.Collections.Generic;
namespace BusSpeaker.Models
{
    public class Rout
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Point> DirectDirectionPoints { get; set; }
        public List<Point> ReverseDirectionPoints { get; set; }
        public bool IsDirectDirection { get; set; }
    }
}