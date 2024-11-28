using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineCompanyWebAPI.Models
{
    public class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Flight")]
        public int FlightId { get; set; }

        public Flight Flight { get; set; }

        [Required, MaxLength(200)]
        public string PassengerFullName { get; set; }

        [Required]
        public bool CheckedIn { get; set; }

        [Required]
        public DateTime BookingDate { get; set; }
    }
}
