using System;
using System.Collections.Generic;
using System.Text;

namespace BusSpeaker.Models
{
    [Flags]
    public enum StopPointState
    {
        Visited = 0x1,
        Current = 0x2
    }
}
