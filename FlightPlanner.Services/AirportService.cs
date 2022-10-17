using FlightPlanner.Core.Models;
using FlightPlanner.Data;
using System.Collections.Generic;
using System.Linq;
using FlightPlanner.Core.Services;

namespace FlightPlanner.Services
{
    public class AirportService : EntityService<Airport>, IAirportService
    {
        public AirportService(IFlightPlannerDbContext context) : base(context)
        {
        }

        public List<Airport> GetAirports(string phrase)
        {
            var lowPhrase = phrase.ToLower().Trim();

            return _context.Airports.Where(airport =>
                 airport.AirportCode.ToLower().Contains(lowPhrase) ||
                 airport.City.ToLower().Contains(lowPhrase) ||
                 airport.Country.ToLower().Contains(lowPhrase)).ToList();
        }
    }
}
