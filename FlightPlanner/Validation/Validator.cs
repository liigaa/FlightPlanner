using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace FlightPlanner.Validation
{
    public class Validator
    {
        public static bool IsSameFlight(Flight flight, List<Flight> flights)
        {
            if (flights.Any(f =>
                    f.From.AirportCode.ToLower().Trim() == flight.From.AirportCode.ToLower().Trim() &&
                    f.From.City.ToLower().Trim() == flight.From.City.ToLower().Trim() &&
                    f.From.Country.ToLower().Trim() == flight.From.Country.ToLower().Trim() &&
                    f.To.AirportCode.ToLower().Trim() == flight.To.AirportCode.ToLower().Trim() &&
                    f.To.City.ToLower().Trim() == flight.To.City.ToLower().Trim() &&
                    f.To.Country.ToLower().Trim() == flight.To.Country.ToLower().Trim() &&
                    f.Carrier.ToLower().Trim() == flight.Carrier.ToLower().Trim() &&
                    f.DepartureTime.ToLower().Trim() == flight.DepartureTime.ToLower().Trim() &&
                    f.ArrivalTime.ToLower().Trim() == flight.ArrivalTime.ToLower().Trim()))
            {
                return true;
            }

            return false;
        }

        public static bool IsValueEmptyOrNull(Flight flight)
        {
            if (flight.From == null || flight.To == null ||
                string.IsNullOrEmpty(flight.From.AirportCode) ||
                string.IsNullOrEmpty(flight.To.AirportCode) ||
                string.IsNullOrEmpty(flight.From.City) || string.IsNullOrEmpty(flight.To.City) ||
                string.IsNullOrEmpty(flight.From.Country) || string.IsNullOrEmpty(flight.To.Country) ||
                string.IsNullOrEmpty(flight.Carrier) ||
                string.IsNullOrEmpty(flight.DepartureTime) || string.IsNullOrEmpty(flight.ArrivalTime))
            {
                return true;
            }
            return false;
        }

        public static bool IsSameAirport(Flight flight)
        {
            return flight.From.AirportCode.ToLower().Trim() == flight.To.AirportCode.ToLower().Trim();
        }

        public static bool IsCorrectDateFormat(Flight flight)
        {

            var arrivalTime = flight.ArrivalTime;
            var departureTime = flight.DepartureTime;
            DateTime.TryParse(arrivalTime, CultureInfo.CurrentCulture, DateTimeStyles.AdjustToUniversal, out var arrivalDate);
            DateTime.TryParse(departureTime, CultureInfo.CurrentCulture, DateTimeStyles.AdjustToUniversal, out var departureDate);

            return departureDate >= arrivalDate;
        }
    }
}
