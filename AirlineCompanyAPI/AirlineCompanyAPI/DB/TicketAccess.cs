using System;
using System.Linq;
using AirlineCompanyWebAPI.Models;
using AirlineCompWebApi.Context;

namespace AirlineCompanyWebAPI.Source.Db
{
    public class TicketAccess
    {
        private readonly AppDbContext _dbContext;

        // Constructor with dependency injection for AppDbContext
        public TicketAccess(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Books a new ticket and updates the flight's booked seats
        public int BookTicket(Ticket ticket, Flight flight)
        {
            if (ticket == null)
                throw new ArgumentNullException(nameof(ticket));

            // Add ticket to database
            _dbContext.Tickets.Add(ticket);

            // Update flight's booked seats
            flight.BookedSeats += 1;
            _dbContext.Flights.Update(flight);

            // Save changes to the database
            _dbContext.SaveChanges();

            return ticket.Id;
        }

        // Marks a ticket as checked in
        public void CheckInTicket(int ticketId)
        {
            var ticket = _dbContext.Tickets.FirstOrDefault(t => t.Id == ticketId);
            if (ticket == null)
                throw new Exception($"Ticket with ID {ticketId} not found.");

            ticket.CheckedIn = true;

            // Save changes to the database
            _dbContext.SaveChanges();
        }
    }
}
