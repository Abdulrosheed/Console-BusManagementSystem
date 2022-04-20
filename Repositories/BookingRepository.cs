using System;
using System.Collections.Generic;
using System.Linq;
using BusManagementSystem.DTOs;
using BusManagementSystem.Entities;
using BusManagementSystem.Entities.Context;
using BusManagementSystem.Entities.Enums.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BusManagementSystem.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly  BusManagementSystemDbContext _context3 = new BusManagementSystemDbContext();

        public void CreateListOfBooking(List<Booking> booking)
        {
            _context3.Bookings.AddRange(booking);
            _context3.SaveChanges();
        }

        public void CreateOneBooking(Booking booking)
        {
            _context3.Bookings.Add(booking);
            _context3.SaveChanges();
        }

        public void DeleteBooking(Booking booking)
        {
            _context3.Bookings.Remove(booking);
            _context3.SaveChanges();
        }

        public List<BookingDto> GetAllBooking()
        {
            return _context3.Bookings
            .Include(booking => booking.Passenger)
            .Include(booking => booking.Trip)
            .ThenInclude(t => t.Bus)
            .Include(booking => booking.Trip)
            .ThenInclude(t => t.Driver).Select(b => new BookingDto 
            {
                BusPlateNumber =  b.Trip.Bus.PlateNumber,
                PassengerFullName = $"{b.Passenger.FirstName} {b.Passenger.LastName}",
                BookingReference = b.BookingReference,
                DriverFullName = $"{b.Trip.Driver.FirstName} {b.Trip.Driver.LastName}",
                TripLandingPoint = b.TripLandingPoint,
                TripTakeOffPoint = b.TripTakeOffPoint,
                TripLandingTime = b.Trip.LandingTime,
                TripTakeOffTime = b.Trip.TakeOffTime,
                SeatNumber = b.SeatNumber,
                NumberOfPassenger = b.Trip.Bus.Capacity,
                BookingDate = b.BookingTime.Date,
                busType = b.Trip.Bus.BusType,
                BookingStatus = b.BookingStatus,
                



                
            }).ToList();
        }
        public BookingDto GetBookingByReferenceNumberReturningBookingObjectBookingDto(string referenceNumber)
        {
            var b = _context3.Bookings.Include(booking => booking.Passenger).Include(booking => booking.Trip).ThenInclude(x => x.Bus).Include(d => d.Trip).ThenInclude(f => f.Driver).SingleOrDefault(b => b.BookingReference == referenceNumber);
            return new BookingDto 
            {
                BusPlateNumber =  b.Trip.Bus.PlateNumber,
                PassengerFullName = $"{b.Passenger.FirstName} {b.Passenger.LastName}",
                BookingReference = b.BookingReference,
                DriverFullName = $"{b.Trip.Driver.FirstName} {b.Trip.Driver.LastName}",
                TripLandingPoint = b.TripLandingPoint,
                TripTakeOffPoint = b.TripTakeOffPoint,
                TripLandingTime = b.Trip.LandingTime,
                TripTakeOffTime = b.Trip.TakeOffTime,
                SeatNumber = b.SeatNumber,
                NumberOfPassenger = b.Trip.Bus.Capacity,
                BookingDate = b.BookingTime.Date,
                busType = b.Trip.Bus.BusType,
                BookingStatus = b.BookingStatus,
            };
        }

        public Booking GetBookingByReferenceNumberReturningBookingObject(string referenceNumber)
        {
            return _context3.Bookings.SingleOrDefault(booking => booking.BookingReference == referenceNumber);
        }

        
        public void Update(Booking booking)
        {
            _context3.Bookings.Update(booking);
            _context3.SaveChanges();
        }

        public List<BookingDto> GetCurrentBooking(DateTime date)
        {
            return _context3.Bookings
            .Include(b => b.Passenger)
            .Include(c => c.Trip)
            .ThenInclude(d => d.Bus)
            .Include(e => e.Trip)
            .ThenInclude(f => f.Driver)
            .Where(booking => booking.BookingTime.Date == date).Select(b => new BookingDto 
            {
                BusPlateNumber =  b.Trip.Bus.PlateNumber,
                PassengerFullName = $"{b.Passenger.FirstName} {b.Passenger.LastName}",
                BookingReference = b.BookingReference,
                DriverFullName = $"{b.Trip.Driver.FirstName} {b.Trip.Driver.LastName}",
                TripLandingPoint = b.TripLandingPoint,
                TripTakeOffPoint = b.TripTakeOffPoint,
                TripLandingTime = b.Trip.LandingTime,
                TripTakeOffTime = b.Trip.TakeOffTime,
                SeatNumber = b.SeatNumber,
                NumberOfPassenger = b.Trip.Bus.Capacity,
                BookingDate = b.BookingTime.Date,
                busType = b.Trip.Bus.BusType,
                BookingStatus = b.BookingStatus,
            }).ToList();
        }
    }
}