using FlightPlanner.Core.Services;
using FlightPlanner.Data;

namespace FlightPlanner.Services
{
    public class DeleteAllRecordsService : IDeleteAllRecordsService
    {
        private readonly IFlightPlannerDbContext _context;

        public DeleteAllRecordsService(IFlightPlannerDbContext context)
        {
            _context = context;
        }

        public void DeleteAllRecords()
        {
            _context.Flights.RemoveRange(_context.Flights);
            _context.Airports.RemoveRange(_context.Airports);
            _context.SaveChanges();
        }
    }
}
