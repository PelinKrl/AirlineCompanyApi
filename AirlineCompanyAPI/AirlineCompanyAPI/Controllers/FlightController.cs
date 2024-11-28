using AirlineCompanyWebAPI.Services;
using AirlineCompWebApi.DTOs;
using AirlineCompWebApi.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirlineCompanyWebAPI.Controllers
{
    [ApiController]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")] // Specify the version for this controller
    public class FlightController : ControllerBase
    {
        private readonly FlightService _flightService;

        public FlightController(FlightService flightService)
        {
            _flightService = flightService; // Replace with DI in production
        }

        // POST: api/Flight/InsertFlight
        [HttpPost("InsertFlight")]
        [Authorize]
        
        public IActionResult InsertFlight([FromBody] FlightRequestDTO flightRequest)
        {
            try
            {
                var flightId = _flightService.AddFlight(flightRequest);
                return Ok(new ResponseDTO { Status = "Success", Message = "Flight created successfully.", Data = flightId });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDTO { Status = "Error", Message = ex.Message });
            }
        }

        // GET: api/Flight/QueryFlights
        [HttpGet("QueryFlights")]
        public IActionResult QueryFlights([FromQuery] string from, [FromQuery] string to, [FromQuery] string date, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var flights = _flightService.GetAvailableFlightsWithPaging(from, to, date, pageNumber, pageSize);
                return Ok(new ResponseDTO { Status = "Success", Message = "Flights retrieved successfully.", Data = flights });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDTO { Status = "Error", Message = ex.Message });
            }
        }

        // GET: api/Flight/ReportFlights
        [HttpGet("ReportFlights")]
        [Authorize]
       
        public IActionResult ReportFlights([FromQuery] string from, [FromQuery] string to, [FromQuery] string date, [FromQuery] int capacity, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var flights = _flightService.GetFlightsReportWithPaging(from, to, date, capacity, pageNumber, pageSize);
                return Ok(new ResponseDTO { Status = "Success", Message = "Flights retrieved successfully.", Data = flights });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDTO { Status = "Error", Message = ex.Message });
            }
        }
    }
}
