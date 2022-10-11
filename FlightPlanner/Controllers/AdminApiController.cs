using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using AutoMapper;
using FlightPlanner.Core.Models;
using FlightPlanner.Core.Services;
using FlightPlanner.Core.Validation;
using Microsoft.AspNetCore.Cors;

namespace FlightPlanner.Controllers
{
    [Route("admin-api")]
    [ApiController, Authorize, EnableCors("MyPolicy")]
    public class AdminApiController : ControllerBase
    {
        private readonly IFlightService _flightService;
        private readonly IEnumerable<IFlightValidator> _flightValidators;
        private readonly IEnumerable<IAirportValidator> _airportValidators;
        private readonly IMapper _mapper;

        public AdminApiController(IFlightService flightService,
            IEnumerable<IFlightValidator> flightValidators,
            IEnumerable<IAirportValidator> airportValidators,
            IMapper mapper)
        {
            _flightService = flightService;
            _flightValidators = flightValidators;
            _airportValidators = airportValidators;
            _mapper = mapper;
        }

        [Route("flights/{id}")]
        [HttpGet]
        public IActionResult GetFlight(int id)
        {
            var flight = _flightService.GetCompleteFlightById(id);

            if (flight == null)
            {
                return NotFound();
            } 

            return Ok(flight);
        }

        [Route("flights")]
        [HttpPut]
        public IActionResult PutFlight(FlightRequest request)
        {
            var flight = _mapper.Map<Flight>(request);

            if (!_flightValidators.All(f => f.IsValid(flight)) ||
                !_airportValidators.All(f => f.IsValid(flight?.From)) ||
                !_airportValidators.All(f => f.IsValid(flight?.To)))
            {
                return BadRequest();
            }

            if (_flightService.Exists(flight))
            {
                return Conflict();
            }

            _flightService.Create(flight);

            request = _mapper.Map<FlightRequest>(flight);

            return Created("", request);
        }

        [Route("flights/{id}")]
        [HttpDelete]
        public IActionResult DeleteFlight(int id)
        {
            var flight = _flightService.GetById(id);

            if(flight != null)
            {
                _flightService.Delete(flight);
            }

            return Ok();
        }
    }
}
