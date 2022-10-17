using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FlightPlanner.Core.Models;
using FlightPlanner.Core.Services;
using FlightPlanner.Core.Validation;
using FlightPlanner.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlightPlanner.Controllers
{
    [Route("api")]
    [ApiController]
    public class CustomerFlightApiController : ControllerBase
    {
        private readonly IFlightService _flightService;
        private readonly IAirportService _airportService;
        private readonly IEnumerable<IRequestValidator> _requestValidators;
        private readonly IMapper _mapper;

        public CustomerFlightApiController(
            IFlightService flightService,
            IAirportService airportService,
            IEnumerable<IRequestValidator> requestValidator,
            IMapper mapper)
        {
            _flightService = flightService;
            _airportService = airportService;
            _requestValidators = requestValidator;
            _mapper = mapper;
        }

        [Route("airports")]
        [HttpGet]
        public IActionResult GetAirports(string search)
        {
            var airports = _airportService.GetAirports(search);
            var newAirports = _mapper.Map<List<AirportRequest>>(airports);

            return Ok(newAirports);
        }

        [Route("flights/search")]
        [HttpPost]
        public IActionResult GetFlights(Request request)
        {
            if (!_requestValidators.All(f => f.IsValid(request)) ||
                request.From.ToLower().Trim() == request.To.ToLower().Trim())
            {
                return BadRequest();
            }

            return Ok(new PageResult(_flightService.GetFlights(request)));
        }

        [Route("flights/{id}")]
        [HttpGet]
        public IActionResult GetFlightById(int id)
        {
            var flight = _flightService.GetCompleteFlightById(id);

            if (flight == null)
            {
                return NotFound();
            }
            var response = _mapper.Map<FlightRequest>(flight);

            return Ok(response);
        }
    }
}
