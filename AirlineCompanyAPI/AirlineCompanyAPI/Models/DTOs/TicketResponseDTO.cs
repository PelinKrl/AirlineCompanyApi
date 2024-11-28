namespace AirlineCompWebApi.Models.DTOs
{
    public class TicketResponseDTO
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public string PassengerFullName { get; set; }
        public DateTime BookingDate { get; set; }

    }
}
