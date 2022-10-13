using System.Collections.Generic;
using System.Linq;
using FlightPlanner.Core.Models;
using FlightPlanner.Core.Services;
using FlightPlanner.Data;
using Microsoft.EntityFrameworkCore;

namespace FlightPlanner.Services
{
    public class FlightService : EntityService<Flight>, IFlightService
    {
        public FlightService(IFlightPlannerDbContext context) : base(context)
        {
        }

        public Flight GetCompleteFlightById(int id)
        {
           return _context.Flights
               .Include(f => f.From)
               .Include(f => f.To)
               .SingleOrDefault(f => f.Id == id);
        }

        public bool Exists(Flight flight)
        {
           return _context.Flights.Any(f => f.ArrivalTime == flight.ArrivalTime &&
                                      f.DepartureTime == flight.DepartureTime &&
                                      f.Carrier == flight.Carrier &&
                                      f.From.AirportCode == flight.From.AirportCode &&
                                      f.To.AirportCode == flight.To.AirportCode);
        }

        public void DeleteById(int id)
        {
            var flight = GetById(id);

            if (flight != null)
            {
                Delete(flight);
            }
        }

        public List<Flight> GetAllFlights()
        {
            return _context.Flights
                .Include(f => f.From)
                .Include(f => f.To).ToList();
        }

        public List<Airport> GetAirports(string phrase)
        {
            var airports = new List<Airport>();
            var flights = GetAllFlights();
            var lowPhrase = phrase.ToLower().Trim();

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

        public List<Flight> GetFlights(Request request)
        {
            var flights = GetAllFlights();

            return flights.Where(f =>
                f.From.AirportCode == request.From &&
                f.To.AirportCode == request.To &&
                f.DepartureTime[..10] == request.DepartureDate).ToList();

        }
    }
}
