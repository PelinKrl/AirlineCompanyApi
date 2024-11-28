using System;
using System.Collections.Generic;
using System.Linq;
using AirlineCompanyWebAPI.Models;
using AirlineCompWebApi.Context;

namespace AirlineCompanyWebAPI.Source.Db
{
    public class FlightAccess
    {
        private readonly AppDbContext _dbContext;

        // Constructor with dependency injection for AppDbContext
        public FlightAccess(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Inserts a new flight
        public int InsertFlight(Flight flight)
        {
            ValidateFlight(flight);
            _dbContext.Flights.Add(flight); // Add flight to the database
            _dbContext.SaveChanges();      // Save changes to the database
            return flight.Id;
        }

        // Reports flights with capacity
        public List<Flight> ReportFlights(string from, string to, string date, int capacity)
        {
            var flights = _dbContext.Flights
                .Where(f => f.From.Equals(from, StringComparison.OrdinalIgnoreCase) &&
                            f.To.Equals(to, StringComparison.OrdinalIgnoreCase) &&
                            f.Capacity >= capacity)
                .ToList(); // Retrieve data from the database first

            return flights
                .Where(f => f.AvailableDates.Split(',').Contains(date)) // Apply split logic in memory
                .ToList();
        }


        // Retrieves a flight by ID
        public Flight GetFlightById(int flightId)
        {
            return _dbContext.Flights.FirstOrDefault(f => f.Id == flightId);
        }

        // Queries flights for mobile app
        public List<Flight> QueryFlights(string from, string to, string date)
        {
            var flights = _dbContext.Flights
                .Where(f => f.From.Equals(from, StringComparison.OrdinalIgnoreCase) &&
                            f.To.Equals(to, StringComparison.OrdinalIgnoreCase) &&
                            f.Capacity > f.BookedSeats)
                .ToList(); // Retrieve data from the database first

            return flights
                .Where(f => f.AvailableDates.Split(',').Contains(date)) // Apply split logic in memory
                .ToList();
        }


        // Validates the flight data
        private void ValidateFlight(Flight flight)
        {
            if (string.IsNullOrEmpty(flight.From) || string.IsNullOrEmpty(flight.To))
                throw new Exception("From and To fields are required.");

            if (flight.Capacity <= 0)
                throw new Exception("Capacity must be greater than 0.");
        }
    }
}
