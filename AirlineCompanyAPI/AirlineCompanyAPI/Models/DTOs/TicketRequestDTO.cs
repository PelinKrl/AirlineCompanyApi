using System;
using System.ComponentModel.DataAnnotations;

namespace AirlineCompWebApi.Models.DTOs
{
    public class TicketRequestDTO
    {
        public int FlightId { get; set; }
        public string PassengerFullName { get; set; }
        public DateTime? BookingDate { get; set; } // Nullable DateTime
    }
}
