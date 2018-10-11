using BusSpeaker.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusSpeaker.DAL.Intefaces
{
    public interface ISettingsRepository
    {
        Settings GetSettings();
    }
}
