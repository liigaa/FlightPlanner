using System;
using System.Globalization;
using FlightPlanner.Core.Models;

namespace FlightPlanner.Core.Validation
{
    public class FlightTimeValidator : IFlightValidator
    {
        public bool IsValid(Flight flight)
        {
            if (!string.IsNullOrEmpty(flight?.ArrivalTime) && 
                !string.IsNullOrEmpty(flight?.DepartureTime))
            {
                try
                {
                    var arrival = DateTime.Parse(flight.ArrivalTime);
                    var departure = DateTime.Parse(flight.DepartureTime);

                    return arrival > departure;
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
