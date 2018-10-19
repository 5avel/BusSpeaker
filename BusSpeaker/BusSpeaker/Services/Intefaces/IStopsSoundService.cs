using System;
using System.Collections.Generic;
using System.Text;

namespace BusSpeaker.Services.Intefaces
{
    public interface IStopsSoundService
    {
        void PlaySound(string soundName);
    }
}
