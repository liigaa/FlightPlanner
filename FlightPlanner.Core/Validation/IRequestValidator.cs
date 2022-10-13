using FlightPlanner.Core.Models;

namespace FlightPlanner.Core.Validation
{
    public interface IRequestValidator
    {
        bool IsValid(Request request);
    }
}
