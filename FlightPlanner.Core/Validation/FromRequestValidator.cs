using FlightPlanner.Core.Models;

namespace FlightPlanner.Core.Validation
{
    public class FromRequestValidator : IRequestValidator
    {
        public bool IsValid(Request request)
        {
            return !string.IsNullOrEmpty(request?.From);
        }
    }
}
