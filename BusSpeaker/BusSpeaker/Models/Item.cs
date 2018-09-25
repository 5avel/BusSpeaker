using System;
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