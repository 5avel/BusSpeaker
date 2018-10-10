using BusSpeaker.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusSpeaker.DAL.Intefaces
{
    public interface IRoutRepository
    {
        Task<List<Rout>> GetAllRouts();
        Rout GetRoutById(int id);
    }
}
