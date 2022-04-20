using System;
using System.Collections.Generic;
using System.Linq;
using BusManagementSystem.DTOs;
using BusManagementSystem.Entities;
using BusManagementSystem.Entities.Context;
using BusManagementSystem.Entities.Enums;
using BusManagementSystem.Entities.Enums.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BusManagementSystem.Repositories
{
    public class TripRepository : ITripRepository
    {
        private readonly BusManagementSystemDbContext _context2 = new BusManagementSystemDbContext();

        public Trip CreateTrip(Trip trip)
        {
            _context2.Trips.Add(trip);
            _context2.SaveChanges();
            return trip;

        }


        public void DeleteTripByReferenceNumber(string ReferenceNumber)
        {
            var trip = _context2.Trips.SingleOrDefault(trip => trip.TripReferenceNumber == ReferenceNumber);
            _context2.Trips.Remove(trip);
            _context2.SaveChanges();

        }

        public bool ExistsById(int id)
        {
            return _context2.Trips.Any(r => r.Id == id);
        }

        public bool ExistsByReferenceNumber(string referenceNumber)
        {
            return _context2.Trips.Any(trip => trip.TripReferenceNumber == referenceNumber);
        }

        public List<TripDto> GetAllTrip()
        {
            return _context2.Trips.Include(r => r.Bus).Include(r => r.Driver).Select(trip => new TripDto
            {

                
                
                DriverFullName = $"{trip.Driver.FirstName} {trip.Driver.LastName}",
                BusModel = trip.Bus.Model,
                BusRegistrationNumber = trip.Bus.RegistrationNumber,
                AvailableSeat = trip.AvailableSeat,
                LandingPoint = trip.LandingPoint,
                TakeOffPoint = trip.TakeOffPoint,
                TripReferenceNumber = trip.TripReferenceNumber,
                TakeOffTime = trip.TakeOffTime,
                LandingTime = trip.LandingTime,
                Status = trip.tripStatusType

            }).ToList();
        }

        public List<TripDto> GetAvailableTrips(Location from, Location to, DateTime date)
        {
            return _context2.Trips.Include(r => r.Bus).Include(r => r.Driver).Where(r => r.TakeOffPoint == from && r.LandingPoint == to && r.TakeOffTime.Date == date).Select(trip => new TripDto
            {
            
            
                DriverFullName = $"{trip.Driver.FirstName} {trip.Driver.LastName}",
        
                BusModel = trip.Bus.Model,
                BusRegistrationNumber = trip.Bus.RegistrationNumber,
                AvailableSeat = trip.AvailableSeat,
                LandingPoint = trip.LandingPoint,
                TakeOffPoint = trip.TakeOffPoint,
                TripReferenceNumber = trip.TripReferenceNumber,
                TakeOffTime = trip.TakeOffTime,
                LandingTime = trip.LandingTime,
                Status = trip.tripStatusType
            }).ToList();
        }

        public List<TripDto> GetCancelledTrips()
        {
            return _context2.Trips.Include(trip => trip.Bus).Include(trip => trip.Driver).Where(trip => trip.tripStatusType == TripStatusType.Cancelled).Select(trip => new TripDto
            {
                
                
                DriverFullName = $"{trip.Driver.FirstName} {trip.Driver.LastName}",
        
                BusModel = trip.Bus.Model,
                BusRegistrationNumber = trip.Bus.RegistrationNumber,
                AvailableSeat = trip.AvailableSeat,
                LandingPoint = trip.LandingPoint,
                TakeOffPoint = trip.TakeOffPoint,
                TripReferenceNumber = trip.TripReferenceNumber,
                TakeOffTime = trip.TakeOffTime,
                LandingTime = trip.LandingTime,
                Status = trip.tripStatusType
            }).ToList();
        }

        public List<TripDto> GetCancelledTripsByDate(DateTime date)
        {
            return _context2.Trips.Include(trip => trip.Bus).Include(trip => trip.Driver).Where(trip => trip.TakeOffTime.Date == date).Select(trip => new TripDto
            {
        
                
                DriverFullName = $"{trip.Driver.FirstName} {trip.Driver.LastName}",
                
                BusModel = trip.Bus.Model,
                BusRegistrationNumber = trip.Bus.RegistrationNumber,
                AvailableSeat = trip.AvailableSeat,
                LandingPoint = trip.LandingPoint,
                TakeOffPoint = trip.TakeOffPoint,
                TripReferenceNumber = trip.TripReferenceNumber,
                TakeOffTime = trip.TakeOffTime,
                LandingTime = trip.LandingTime,
                Status = trip.tripStatusType
            }).ToList();
        }

        public List<TripDto> GetCompletedTrips()
        {
            return _context2.Trips.Include(t => t.Bus).Include(x => x.Driver).Where(x => x.tripStatusType == TripStatusType.Completed).Select(trip => new TripDto
            {

                
                DriverFullName = $"{trip.Driver.FirstName} {trip.Driver.LastName}",
            
                BusModel = trip.Bus.Model,
                BusRegistrationNumber = trip.Bus.RegistrationNumber,
                AvailableSeat = trip.AvailableSeat,
                LandingPoint = trip.LandingPoint,
                TakeOffPoint = trip.TakeOffPoint,
                TripReferenceNumber = trip.TripReferenceNumber,
                TakeOffTime = trip.TakeOffTime,
                LandingTime = trip.LandingTime,
                Status = trip.tripStatusType
            }).ToList();
        }

        public List<TripDto> GetInitialisedTrips()
        {
            return _context2.Trips.Include(t => t.Bus).Include(x => x.Driver).Where(x => x.tripStatusType == TripStatusType.Initialize).Select(trip => new TripDto
            {
                
                DriverFullName = $"{trip.Driver.FirstName} {trip.Driver.LastName}",
    
                BusModel = trip.Bus.Model,
                BusRegistrationNumber = trip.Bus.RegistrationNumber,
                AvailableSeat = trip.AvailableSeat,
                LandingPoint = trip.LandingPoint,
                TakeOffPoint = trip.TakeOffPoint,
                TripReferenceNumber = trip.TripReferenceNumber,
                TakeOffTime = trip.TakeOffTime,
                LandingTime = trip.LandingTime,
                Status = trip.tripStatusType
            }).ToList();
        }

        public List<TripDto> GetTripByDriver(int driverId)
        {
            return _context2.Trips.Include(t => t.Bus).Include(t => t.Driver).Where(t => t.Driver.Id == driverId).Select(trip => new TripDto
            {
    
        
                DriverFullName = $"{trip.Driver.FirstName} {trip.Driver.LastName}",
    
                BusModel = trip.Bus.Model,
                BusRegistrationNumber = trip.Bus.RegistrationNumber,
                AvailableSeat = trip.AvailableSeat,
                LandingPoint = trip.LandingPoint,
                TakeOffPoint = trip.TakeOffPoint,
                TripReferenceNumber = trip.TripReferenceNumber,
                TakeOffTime = trip.TakeOffTime,
                LandingTime = trip.LandingTime,
                Status = trip.tripStatusType
            }).ToList();
        }

        public TripDto GetTripByIdReturningObjectTripDto(int id)
        {

            var trip = _context2.Trips.Include(trip => trip.Bus).Include(trip => trip.Driver).SingleOrDefault(t => t.Id == id);
            return new TripDto
            {
                
                DriverFullName = $"{trip.Driver.FirstName} {trip.Driver.LastName}",
            
                BusModel = trip.Bus.Model,
                BusRegistrationNumber = trip.Bus.RegistrationNumber,
                AvailableSeat = trip.AvailableSeat,
                LandingPoint = trip.LandingPoint,
                TakeOffPoint = trip.TakeOffPoint,
                TripReferenceNumber = trip.TripReferenceNumber,
                TakeOffTime = trip.TakeOffTime,
                LandingTime = trip.LandingTime,
                Status = trip.tripStatusType
            };


        }

        public Trip GetTripByIdReturningObjectTrip(int id)
        {
            return _context2.Trips.Find(id);
        }

        public TripDto GetTripByReferenceNumberReturningObjectTripDto(string reference)
        {
            var trip = _context2.Trips.Include(trip => trip.Bus).Include(trip => trip.Driver).SingleOrDefault(t => t.TripReferenceNumber == reference);
            return new TripDto
            {
                 Id = trip.Id,
                DriverId = trip.DriverId,
                DriverFullName = $"{trip.Driver.FirstName} {trip.Driver.LastName}",
                BusId = trip.BusId,
                BusModel = trip.Bus.Model,
                BusRegistrationNumber = trip.Bus.RegistrationNumber,
                AvailableSeat = trip.AvailableSeat,
                LandingPoint = trip.LandingPoint,
                TakeOffPoint = trip.TakeOffPoint,
                TripReferenceNumber = trip.TripReferenceNumber,
                TakeOffTime = trip.TakeOffTime,
                LandingTime = trip.LandingTime,
                Status = trip.tripStatusType
            };

        }

        public Trip GetTripByReferenceNumberReturningObjectTrip(string reference)
        {
            return _context2.Trips.SingleOrDefault(trip => trip.TripReferenceNumber == reference);
        }

        public List<TripDto> GetTripsByBus(string registrationNumber)
        {
            return _context2.Trips.Include(y => y.Bus).Include(y => y.Driver).Where(t => t.Bus.RegistrationNumber == registrationNumber).Select(trip => new TripDto
            {
                Id = trip.Id,
                DriverId = trip.DriverId,
                DriverFullName = $"{trip.Driver.FirstName} {trip.Driver.LastName}",
                BusId = trip.BusId,
                BusModel = trip.Bus.Model,
                BusRegistrationNumber = trip.Bus.RegistrationNumber,
                AvailableSeat = trip.AvailableSeat,
                LandingPoint = trip.LandingPoint,
                TakeOffPoint = trip.TakeOffPoint,
                TripReferenceNumber = trip.TripReferenceNumber,
                TakeOffTime = trip.TakeOffTime,
                LandingTime = trip.LandingTime,
                Status = trip.tripStatusType
            }).ToList();
        }

        public List<TripDto> GetTripsByDate(DateTime date)
        {
            return _context2.Trips.Include(y => y.Bus).Include(y => y.Driver).Where(t => t.TakeOffTime.Date == date).Select(trip => new TripDto
            {
                Id = trip.Id,
                DriverId = trip.DriverId,
                DriverFullName = $"{trip.Driver.FirstName} {trip.Driver.LastName}",
                BusId = trip.BusId,
                BusModel = trip.Bus.Model,
                BusRegistrationNumber = trip.Bus.RegistrationNumber,
                AvailableSeat = trip.AvailableSeat,
                LandingPoint = trip.LandingPoint,
                TakeOffPoint = trip.TakeOffPoint,
                TripReferenceNumber = trip.TripReferenceNumber,
                TakeOffTime = trip.TakeOffTime,
                LandingTime = trip.LandingTime,
                Status = trip.tripStatusType
            }).ToList();
        }

        public List<TripDto> GetTripsByDateAndLocation(Location from, Location to, DateTime date)
        {
            return _context2.Trips.Include(y => y.Bus).Include(y => y.Driver).Where(t => t.TakeOffPoint == from && t.LandingPoint == to && t.TakeOffTime.Date == date).Select(trip => new TripDto
            {
                Id = trip.Id,
                DriverId = trip.DriverId,
                DriverFullName = $"{trip.Driver.FirstName} {trip.Driver.LastName}",
                BusId = trip.BusId,
                BusModel = trip.Bus.Model,
                BusRegistrationNumber = trip.Bus.RegistrationNumber,
                AvailableSeat = trip.AvailableSeat,
                LandingPoint = trip.LandingPoint,
                TakeOffPoint = trip.TakeOffPoint,
                TripReferenceNumber = trip.TripReferenceNumber,
                TakeOffTime = trip.TakeOffTime,
                LandingTime = trip.LandingTime,
                Status = trip.tripStatusType
            }).ToList();
        }
        public Trip GetTripsByDateAndLocationReturningTripObject(Location from, Location to, DateTime date)
        {
            var trip = _context2.Trips.Include(y => y.Bus).Include(y => y.Driver).SingleOrDefault(t => t.TakeOffPoint == from && t.LandingPoint == to && t.TakeOffTime.Date == date);
            return trip;
        }

        public string Update(Trip trip)
        {

            _context2.Trips.Update(trip);
            _context2.SaveChanges();
            return "Updated Successfully";

        }


    }
}