using BusSpeaker.DAL.Intefaces;
using BusSpeaker.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusSpeaker.DAL
{
    public class RoutRepository : IRoutRepository
    {
        private DBContext _context;
        public RoutRepository(DBContext context)
        {
            _context = context;
        }

        public Task<List<Rout>> GetAllRouts()
        {
            throw new NotImplementedException();
        }

        public  Rout GetRoutById(int id)
        {
            return  _context.Routs
                .Include(s => s.StopPoints)
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
