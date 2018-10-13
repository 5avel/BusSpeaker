

using PropertyChanged;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusSpeaker.Models
{
    [AddINotifyPropertyChangedInterface]
    public class StopPoint
    {
        public int Id { get; set; }

        public int RoutId { get; set; }
        public Rout Rout { get; set; }

        public bool IsDirectDirection { get; set; }

        public int Number { get; set; }

        public string Name { get; set; }
        public string Sound { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public bool IsLastStopPoint { get; set; }

        [NotMapped]
        public double Distance { get; set; }
        [NotMapped]
        public bool IsVisited { get; set; }
        [NotMapped]
        public bool IsCurrentStopPoint { get; set; }

    }
}
