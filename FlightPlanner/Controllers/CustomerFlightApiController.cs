using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlightPlanner.Controllers
{
    [Route("api")]
    [ApiController]
    public class CustomerFlightApiController : ControllerBase
    {
        private readonly FlightPlannerDbContext _context;

        public CustomerFlightApiController(FlightPlannerDbContext context)
        {
            _context = context;
        }

        [Route("airports")]
        [HttpGet]
        public IActionResult GetAirports(string search)
        {
            var flightsList = _context.Flights
                .Include(f => f.From)
                .Include(f => f.To)
                .ToList();
            var airports = FlightStorage.GetAirports(search, flightsList);

            return Ok(airports);
        }

        [Route("flights/search")]
        [HttpPost]
        public IActionResult GetFlights(FlightRequest request)
        {
            if (string.IsNullOrEmpty(request.From) ||
                string.IsNullOrEmpty(request.To) ||
                string.IsNullOrEmpty(request.DepartureDate) || 
                request.From.ToLower().Trim() == request.To.ToLower().Trim())
            {
                return BadRequest();
            }

            var flightsList = _context.Flights
                .Include(f => f.From)
                .Include(f => f.To)
                .ToList();

            return Ok(new PageResult(FlightStorage.GetFlights(request, flightsList)));
        }

        [Route("flights/{id}")]
        [HttpGet]
        public IActionResult GetFlightById(int id)
        {
            var flight = _context.Flights
                .Include(f => f.From)
                .Include(f => f.To)
                .FirstOrDefault(f => f.Id == id);

            if (flight == null)
            {
                return NotFound();
            }

            return Ok(flight);
        }
    }
}
