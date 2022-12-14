using FlightPlanner.Core.Models;

namespace FlightPlanner.Core.Validation
{
    public class AirportCodeValidator : IAirportValidator
    {
        public bool IsValid(Airport airport)
        {
            return !string.IsNullOrEmpty(airport?.AirportCode);
        }
    }
}
