namespace AirlineCompWebApi.Models.DTOs
{
    public class CheckInResponseDTO
    {
        public int TicketId { get; set; }
        public string Status { get; set; } // "Success" or "Error"
        public string Message { get; set; } // Detailed message if needed
    }
}
