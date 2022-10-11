using FlightPlanner.Core.Models;

namespace FlightPlanner.Core.Validation
{
    public class AirportCountryValidator : IAirportValidator
    {
        public bool IsValid(Airport airport)
        {
            return !string.IsNullOrEmpty(airport?.Country);
        }
    }
}
