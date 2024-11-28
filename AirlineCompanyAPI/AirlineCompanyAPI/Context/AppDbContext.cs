using AirlineCompanyWebAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace AirlineCompWebApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Flight> Flights { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    }
}
