using AirlineCompanyWebAPI.Models;
using AirlineCompanyWebAPI.Source.Db;
using AirlineCompWebApi.Models.DTOs;
using System;

namespace AirlineCompanyWebAPI.Services
{
    public class TicketService
    {
        private readonly TicketAccess _ticketAccess;
        private readonly FlightAccess _flightAccess;

        public TicketService(TicketAccess ticketAccess, FlightAccess flightAccess)
        {
            _ticketAccess = ticketAccess;  // Replace with dependency injection in production
            _flightAccess = flightAccess; // Replace with dependency injection in production
        }

        public int BookTicket(TicketRequestDTO ticketRequest)
        {
            // Fetch the flight by its ID
            var flight = _flightAccess.GetFlightById(ticketRequest.FlightId);
            if (flight == null)
                throw new Exception("Flight not found.");

            // Check if seats are available
            if (flight.Capacity <= flight.BookedSeats)
                throw new Exception("No available seats on this flight.");

            // Create a new ticket
            var ticket = new Ticket
            {
                FlightId = ticketRequest.FlightId,
                PassengerFullName = ticketRequest.PassengerFullName,
                BookingDate = ticketRequest.BookingDate ?? DateTime.Now, // Handle null value
                CheckedIn = false
            };

            // Save the ticket and update the flight's booked seats
            return _ticketAccess.BookTicket(ticket, flight);
        }


        public void CheckInTicket(int ticketId)
        {
            _ticketAccess.CheckInTicket(ticketId);
        }
    }
}
