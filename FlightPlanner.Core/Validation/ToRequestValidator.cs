using FlightPlanner.Core.Models;

namespace FlightPlanner.Core.Validation
{
    public class ToRequestValidator : IRequestValidator
    {
        public bool IsValid(Request request)
        {
            return !string.IsNullOrEmpty(request?.To);
        }
    }
}
