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
   
    public class BusRepository : IBusRepository
    {
        // it wont allow anyone to change data and have access to it
        //private readonly  BusManagementSystemDbContext _context;
         private readonly BusManagementSystemDbContext _context = new BusManagementSystemDbContext();
        // creating an instance of a dbcontext
        // public BusRepository()
        // {
        //     _context = new BusManagementSystemDbContext();
        // }

        public Bus CreateBus(Bus bus)
        {
            _context.Buses.Add(bus);
            _context.SaveChanges();
            return bus;
        }

        public void DeleteBus(Bus bus)
        {
            _context.Buses.Remove(bus);
            _context.SaveChanges();
            
        }

        public bool ExistsById(int id)
        {
            return _context.Buses.Any(bus => bus.Id == id);
        }

        public bool ExistsByRegistarationNumber(string registrationNumber)
        {
            return _context.Buses.Any(bus => bus.RegistrationNumber == registrationNumber);
        }

        public List<BusDTo> GetAll()
        {
            return _context.Buses.Select(bus =>new BusDTo 
            {
                PlateNumber = bus.PlateNumber,
                RegistrationNumber = bus.RegistrationNumber,
                BusType = bus.BusType,
                Model = bus.Model,
                TripStatus = bus.TripStatus,
                AvailabilityStatus = bus.AvailabilityStatus,
            }).ToList();
        }

        public List<BusDTo> GetAvailableBuses()
        {
            return _context.Buses.Include(b => b.Trips).Where(bus => bus.AvailabilityStatus == true).Select(bus =>new BusDTo 
            {
                PlateNumber = bus.PlateNumber,
                RegistrationNumber = bus.RegistrationNumber,
                BusType = bus.BusType,
                Model = bus.Model,
                TripStatus = bus.TripStatus,
                AvailabilityStatus = bus.AvailabilityStatus,
                Trips = bus.Trips.Select(t => new TripDto
                {
                    Id = t.Id,
                    AvailableSeat = t.AvailableSeat,
                    price = t.price,
                    
                }).ToList()
            }).ToList();
        }

        public Bus GetBusReturningBusObject(int id)
        {
            var bus = _context.Buses.Find(id);
            return bus;
        }

        

        public Bus GetByRegistrationNumberReturningBusObject(string registrationNumber)
        {
            var bus = _context.Buses.SingleOrDefault(x=>x.RegistrationNumber == registrationNumber);
            return bus;
        }

        

        public void Update( Bus bus)
        {
            var buses = _context.Buses.Find(bus.Id);
            _context.Buses.Update(buses);
            _context.SaveChanges();
            
        }

        public BusDTo GetBusReturningBusDtoObject(int id)
        {
            var bus = _context.Buses.SingleOrDefault(bus => bus.Id == id);

            return new BusDTo{
               
                PlateNumber = bus.PlateNumber,
                RegistrationNumber = bus.RegistrationNumber,
                BusType = bus.BusType,
                Model = bus.Model,
                TripStatus = bus.TripStatus,
                AvailabilityStatus = bus.AvailabilityStatus,
                Capacity = bus.Capacity,
       
            };
        }

        

        public BusDTo GetByRegistrationNumberReturningBusDtoObject(string registrationNumber)
        {
            var bus = _context.Buses.SingleOrDefault(trip => trip.RegistrationNumber == registrationNumber);
            return new BusDTo 
            {
                PlateNumber = bus.PlateNumber,
                RegistrationNumber = bus.RegistrationNumber,
                BusType = bus.BusType,
                Model = bus.Model,
                TripStatus = bus.TripStatus,
                AvailabilityStatus = bus.AvailabilityStatus,
                Capacity = bus.Capacity,
            };
         }

        
    }
}