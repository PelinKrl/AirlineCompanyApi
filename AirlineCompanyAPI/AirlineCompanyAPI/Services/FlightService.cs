using AirlineCompanyWebAPI.Models;
using AirlineCompanyWebAPI.Source.Db;
using AirlineCompWebApi.Models.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace AirlineCompanyWebAPI.Services
{
    public class FlightService
    {
        private readonly FlightAccess _flightAccess;

        public FlightService(FlightAccess flightAccess)
        {
            _flightAccess = flightAccess; // Replace with dependency injection in production
        }

        public int AddFlight(FlightRequestDTO flightRequest)
        {
            var flight = new Flight
            {
                From = flightRequest.From,
                To = flightRequest.To,
                AvailableDates = flightRequest.AvailableDates,
                Days = flightRequest.Days,
                Capacity = flightRequest.Capacity,
                BookedSeats = 0
            };

            return _flightAccess.InsertFlight(flight);
        }

        public List<FlightResponseDTO> GetFlightsReportWithPaging(string from, string to, string date, int capacity, int pageNumber, int pageSize)
        {
            var flights = _flightAccess.ReportFlights(from, to, date, capacity);

            // Apply paging
            var pagedFlights = flights
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return pagedFlights.Select(f => new FlightResponseDTO
            {
                Id = f.Id,
                From = f.From,
                To = f.To,
                AvailableDates = f.AvailableDates,
                Days = f.Days,
                Capacity = f.Capacity,
                AvailableSeats = f.Capacity - f.BookedSeats
            }).ToList();
        }

        public List<FlightResponseDTO> GetAvailableFlightsWithPaging(string from, string to, string date, int pageNumber, int pageSize)
        {
            var flights = _flightAccess.QueryFlights(from, to, date);

            // Apply paging
            var pagedFlights = flights
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return pagedFlights.Select(f => new FlightResponseDTO
            {
                Id = f.Id,
                From = f.From,
                To = f.To,
                AvailableDates = f.AvailableDates,
                Days = f.Days,
                Capacity = f.Capacity,
                AvailableSeats = f.Capacity - f.BookedSeats
            }).ToList();
        }
    }
}
