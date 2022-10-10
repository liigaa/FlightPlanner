using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using FlightPlanner.Validation;
using Microsoft.AspNetCore.Cors;

namespace FlightPlanner.Controllers
{
    [Route("admin-api")]
    [ApiController, Authorize, EnableCors("MyPolicy")]
    public class AdminApiController : ControllerBase
    {
        public readonly FlightPlannerDbContext _context;
        private static readonly object lockName = new();

        public AdminApiController(FlightPlannerDbContext context)
        {
            _context = context;
        }

        [Route("flights/{id}")]
        [HttpGet]
        public IActionResult GetFlight(int id)
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

        [Route("flights")]
        [HttpPut]
        public IActionResult PutFlight(Flight flight)
        {
            lock (lockName)
            {
                if (Validator.IsValueEmptyOrNull(flight) ||
                    Validator.IsSameAirport(flight) ||
                    Validator.IsCorrectDateFormat(flight))
                {
                    return BadRequest();
                }

                var flightsList = _context.Flights
                    .Include(f => f.From)
                    .Include(f => f.To)
                    .ToList();

                if (Validator.IsSameFlight(flight, flightsList))
                {
                    return Conflict();
                }

                _context.Flights.Add(flight);
                _context.SaveChanges();

                return Created("", flight);
            }
        }

        [Route("flights/{id}")]
        [HttpDelete]
        public IActionResult DeleteFlight(int id)
        {
            var flight = _context.Flights.FirstOrDefault(f => f.Id == id);

            if(flight != null)
            {
                _context.Flights.Remove(flight);
                _context.SaveChanges();
            }

            return Ok();
        }
    }
}
