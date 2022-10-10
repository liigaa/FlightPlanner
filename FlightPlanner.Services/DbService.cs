using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightPlanner.Core.Models;
using FlightPlanner.Core.Services;

namespace FlightPlanner.Services
{
    public class DbService : IDbService
    {
        protected FlightPlannerDbContext _context;

        public void Create<T>(T entity) where T : Entity
        {
            _context.Set<T>().Remove(entity);
        }


    }
}
