using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightPlanner.Core.Models;

namespace FlightPlanner.Core.Validation
{
    public class CarrierValidator : IFlightValidator
    {
        public bool IsValid(Flight flight)
        {
            return !string.IsNullOrEmpty(flight?.Carrier);
        }
    }
}
