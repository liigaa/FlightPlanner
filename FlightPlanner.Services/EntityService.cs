using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightPlanner.Core.Models;
using FlightPlanner.Core.Services;

namespace FlightPlanner.Services
{
    public class EntityService<T> : DbService, IEntityService<T> where T : Entity
    {
        public void Update(T entity)
        {
            Update<T>(entity);
        }
    }
}
