using System;
using System.Collections.Generic;
using System.Text;

namespace BusSpeaker.Services.Intefaces
{
    public interface ISQLite
    {
        string GetDatabasePath(string filename);
    }
}
