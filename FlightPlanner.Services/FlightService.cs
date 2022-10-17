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
        
        public List<Flight> GetFlights(Request request)
        {
            return _context.Flights.Where(f =>
                f.From.AirportCode == request.From &&
                f.To.AirportCode == request.To &&
                f.DepartureTime.Substring(0, 10) == request.DepartureDate.Substring(0, 10)).ToList();
        }
    }
}
