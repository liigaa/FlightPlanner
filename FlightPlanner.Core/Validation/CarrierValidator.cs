using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightPlanner.Core.Validation
{
    public class CarrierValidator : IFlightValidator
    {
        public bool isValid(Flight flight)
        {
            return true;
        }
    }
}
