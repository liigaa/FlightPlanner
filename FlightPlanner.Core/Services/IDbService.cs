using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightPlanner.Core.Models;

namespace FlightPlanner.Core.Services
{
    public interface IDbService
    {
        void Create<T>(T entity) where T : Entity;
    }
}
