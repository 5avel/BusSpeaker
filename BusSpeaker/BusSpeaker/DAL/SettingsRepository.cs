using BusSpeaker.DAL.Intefaces;
using BusSpeaker.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusSpeaker.DAL
{
    public class SettingsRepository : ISettingsRepository
    {
        public Settings GetSettings()
        {
            return new Settings { Id = 1, CurrentRoutId = 1, DinstanceToStopPoint = 0.01 };
        }

    }
}
