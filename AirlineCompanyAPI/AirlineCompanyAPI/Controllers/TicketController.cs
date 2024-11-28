using AirlineCompanyWebAPI.Models;
using AirlineCompWebApi.Models.DTOs;
using AirlineCompanyWebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using AirlineCompWebApi.DTOs;

namespace AirlineCompanyWebAPI.Controllers
{
    [ApiController]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")] // Specify the version for this controller
    public class TicketController : ControllerBase
    {
        private readonly TicketService _ticketService;

        public TicketController(TicketService ticketService) // Use Dependency Injection
        {
            _ticketService = ticketService;
        }

        // POST: api/Ticket/Book
        [HttpPost("Book")]
        public IActionResult BookTicket([FromBody] TicketRequestDTO ticketRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResponseDTO { Status = "Error", Message = "Invalid ticket data." });

            try
            {
                var ticketId = _ticketService.BookTicket(ticketRequest);
                return Ok(new ResponseDTO { Status = "Success", Message = "Ticket booked successfully.", Data = ticketId });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDTO { Status = "Error", Message = ex.Message });
            }
        }

        // POST: api/Ticket/CheckIn
        [HttpPost("CheckIn")]
        public IActionResult CheckInTicket([FromBody] int ticketId)
        {
            try
            {
                _ticketService.CheckInTicket(ticketId);
                return Ok(new ResponseDTO { Status = "Success", Message = "Ticket checked in successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseDTO { Status = "Error", Message = ex.Message });
            }
        }
    }
}
