using FlightPlanner.Core.Models;

namespace FlightPlanner.Core.Validation
{
    public interface IAirportValidator
    {
        bool IsValid(Airport airport);
    }
}
