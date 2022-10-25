using FlightPlanner.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace FlightPlanner.Controllers
{
    [Route("testing-api")]
    [ApiController]
    public class TestingApiController : ControllerBase
    {
        private readonly IDeleteAllRecordsService _service;

        public TestingApiController(IDeleteAllRecordsService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("clear")]
        public IActionResult Clear()
        {
            _service.DeleteAllRecords();

            return Ok();
        }
    }
}
