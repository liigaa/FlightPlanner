
using FlightPlanner.Core.Models;

namespace FlightPlanner.Core.Validation
{
    public interface IFlightValidator
    {
        bool IsValid(Flight flight);
    }
}
