using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using DateTime = System.DateTime;

namespace FlightPlanner
{
    public class FlightStorage
    {
        private static List<Flight> _flights = new();
        private static int _id = 1;
        private static readonly object lockName = new();

        public static Flight AddFlight(Flight flight)
        {
            lock (lockName)
            {
                flight.Id = _id++;
                _flights.Add(flight);

                return flight;
            }
        }

        public static List<Flight> AllFlights()
        {
            return _flights;
        }
        public static Flight GetFlight(int id)
        {
            lock (lockName)
            {
              return _flights.FirstOrDefault(flight => flight.Id == id);
            }
        }

        public static void Clear()
        {
            _flights.Clear();
            _id = 1;
        }

        public static void DeleteFlight(int id)
        {
            lock (lockName)
            {
                var flight = GetFlight(id);

                if (flight == null)
                {
                    return;
                }

                _flights.Remove(flight);
            }
        }

        public static List<Airport> GetAirports(string phrase, List<Flight> flights)
        {
            var airports = new List<Airport>();
            var lowPhrase = phrase.ToLower().Trim();

            lock (lockName)
            {
                foreach (var flight in flights)
                {
                    if (flight.From.AirportCode.ToLower().Contains(lowPhrase) ||
                        flight.From.City.ToLower().Contains(lowPhrase) ||
                        flight.From.Country.ToLower().Contains(lowPhrase))
                    {
                        airports.Add(flight.From);
                    }

                    if (flight.To.AirportCode.ToLower().Contains(lowPhrase) ||
                        flight.To.City.ToLower().Contains(lowPhrase) ||
                        flight.To.Country.ToLower().Contains(lowPhrase))
                    {
                        airports.Add(flight.To);
                    }
                }

                return airports;
            }
        }

        public static List<Flight> GetFlights(FlightRequest request, List<Flight> flights)
        {
            return flights.Where(f =>
                    f.From.AirportCode == request.From &&
                    f.To.AirportCode == request.To &&
                    f.DepartureTime[..10] == request.DepartureDate).ToList();
            
        }
    }
}
