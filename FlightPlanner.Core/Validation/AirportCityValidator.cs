using FlightPlanner.Core.Models;

namespace FlightPlanner.Core.Validation
{
    public class AirportCityValidator : IAirportValidator
    {
        public bool IsValid(Airport airport)
        {
            return !string.IsNullOrEmpty(airport?.City);
        }
    }
}
