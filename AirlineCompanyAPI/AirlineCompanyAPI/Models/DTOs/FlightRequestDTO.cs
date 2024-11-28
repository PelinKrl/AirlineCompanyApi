using System.ComponentModel.DataAnnotations;

namespace AirlineCompWebApi.Models.DTOs
{
    public class FlightRequestDTO
    {
        [Required, MaxLength(100)]
        public string From { get; set; }

        [Required, MaxLength(100)]
        public string To { get; set; }

        [Required]
        public string AvailableDates { get; set; } // Format: "2024-12-01,2024-12-02"

        [Required]
        public string Days { get; set; } // Format: "Mon,Wed,Fri"

        [Required, Range(1, int.MaxValue)]
        public int Capacity { get; set; }
    }
}
