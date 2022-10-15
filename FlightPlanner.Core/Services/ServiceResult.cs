using System.Collections.Generic;
using FlightPlanner.Core.Interfaces;
using FlightPlanner.Core.Models;

namespace FlightPlanner.Core.Services
{
    public class ServiceResult
    {
        public bool Success { get; private set; }
        public IEntity Entity { get; private set; }
        public IList<string> Errors { get; private set; }
        public string FormattedErrors => string.Join(",", Errors);

        public ServiceResult(bool success)
        {
            Success = success;
            Errors = new List<string>();
        }

        public ServiceResult SetEntity(IEntity entity)
        {
            Entity = entity;
            return this;
        }

        public ServiceResult AddError(string error)
        {
            Errors.Add(error);
            return this;
        }

    }
}
