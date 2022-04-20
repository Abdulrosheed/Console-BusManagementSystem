using Microsoft.EntityFrameworkCore;

namespace BusManagementSystem.Entities.Context
{
    public class BusManagementSystemDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL ("server=localhost;database=BusinessManagementDataBase;user=root;password=Ayomide012345");
            
        }
        public DbSet<Admin> Admins {get;set;}
        public DbSet<Passenger> Passengers {get;set;}
        public DbSet<Driver> Drivers {get;set;}
        public DbSet<Trip> Trips {get;set;}
        public DbSet<Bus> Buses {get;set;}
        public DbSet<Booking> Bookings {get;set;}
    }
}