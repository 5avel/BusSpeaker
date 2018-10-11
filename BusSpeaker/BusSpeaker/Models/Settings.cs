using System;
using System.Collections.Generic;
using System.Text;

namespace BusSpeaker.Models
{
    public class Settings
    {
        public int Id { get; set; }
        public int CurrentRoutId { get; set; }
        public double DinstanceToStopPoint { get; set; }
    }
}
