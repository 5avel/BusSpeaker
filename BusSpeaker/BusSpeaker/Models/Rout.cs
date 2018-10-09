using System.Collections.Generic;
using PropertyChanged;

namespace BusSpeaker.Models
{
    [AddINotifyPropertyChangedInterface]
    public class Rout
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<StopPoint> StopPoints { get; set; }
    }
}