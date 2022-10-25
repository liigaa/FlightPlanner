using System;
using FlightPlanner.Core.Models;

namespace FlightPlanner.Core.Validation
{
    public class DateRequestValidator : IRequestValidator
    {
        public bool IsValid(Request request)
        {
            if (!string.IsNullOrEmpty(request?.DepartureDate))
            {
                try
                {
                    DateTime.Parse(request.DepartureDate);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
    }
}
