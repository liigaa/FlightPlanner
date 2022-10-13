using FlightPlanner.Core.Models;

namespace FlightPlanner.Core.Validation
{
    public class DateRequestValidator : IRequestValidator
    {
        public bool IsValid(Request request)
        {
            return !string.IsNullOrEmpty(request?.DepartureDate);
        }
    }
}
