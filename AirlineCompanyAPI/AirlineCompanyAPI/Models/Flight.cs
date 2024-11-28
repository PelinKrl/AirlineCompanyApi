using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineCompanyWebAPI.Models
{
    public class Flight
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string From { get; set; }

        [Required, MaxLength(100)]
        public string To { get; set; }

        [Required]
        public string AvailableDates { get; set; } // Stored as JSON string in the DB

        [Required]
        public string Days { get; set; } // Stored as JSON string in the DB

        [Required, Range(1, int.MaxValue)]
        public int Capacity { get; set; }

        [Required, Range(0, int.MaxValue)]
        public int BookedSeats { get; set; }
    }
}
