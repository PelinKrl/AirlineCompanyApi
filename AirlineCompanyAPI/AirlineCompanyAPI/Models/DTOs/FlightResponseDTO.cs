namespace AirlineCompWebApi.Models.DTOs
{
    public class FlightResponseDTO
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string AvailableDates { get; set; } // e.g., "2024-12-01,2024-12-02"
        public string Days { get; set; } // e.g., "Mon,Wed,Fri"
        public int Capacity { get; set; }
        public int AvailableSeats { get; set; } // Calculated as Capacity - BookedSeats
    }
}
