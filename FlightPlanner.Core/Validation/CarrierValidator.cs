﻿using FlightPlanner.Core.Models;

namespace FlightPlanner.Core.Validation
{
    public class CarrierValidator : IFlightValidator
    {
        public bool IsValid(Flight flight)
        {
            return !string.IsNullOrEmpty(flight?.Carrier);
        }
    }
}
