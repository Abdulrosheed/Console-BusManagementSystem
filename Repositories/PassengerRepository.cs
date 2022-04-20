using System.Collections.Generic;
using System.Linq;
using BusManagementSystem.DTOs;
using BusManagementSystem.Entities;
using BusManagementSystem.Entities.Context;
using BusManagementSystem.Entities.Enums.Interfaces;

namespace BusManagementSystem.Repositories
{
    public class PassengerRepository : IPassengerRepository
    {
        private readonly  BusManagementSystemDbContext  _context;
        public PassengerRepository()
        {
            _context = new BusManagementSystemDbContext();
        }
        public string Create(Passenger passenger)
        {
               _context.Passengers.Add(passenger);
            _context.SaveChanges();
            return "Sucesssfuly created a passenger";
        }

        public void Delete(Passenger passenger)
        {
            _context.Passengers.Remove(passenger);
            _context.SaveChanges();
        }

        public bool ExistById(int id)
        {
            return _context.Passengers.Any(Passenger => Passenger.Id == id);
        }

        public bool ExistsByPassWord(string passWord)
        {
            return _context.Passengers.Any(passenger => passenger.Password == passWord);
        }

        public List<PassengerDto> GetAllPassenger()
        {
            return _context.Passengers.Select(Passengers => new PassengerDto 
            {
                FirstName = Passengers.FirstName,
                LastName = Passengers.LastName,
                Email = Passengers.Email,
                PhoneNumber = Passengers.PhoneNumber,
                Address = Passengers.Address,
            }).ToList();
        }

        public Passenger GetPassengerByEmailReturningObjectPassenger(string email)
        {
            return _context.Passengers.SingleOrDefault(x => x.Email == email);
        }

        public Passenger GetPassengerByIdReturningObjectPassenger(int id)
        {
            return _context.Passengers.SingleOrDefault(passenger => passenger.Id == id);
        }

        public PassengerDto GetPassengerByIdReturningObjectPassengerDto(int id)
        {
            var passenger = _context.Passengers.Find(id); 
            return new PassengerDto
            {
                FirstName =  passenger.FirstName,
                LastName =  passenger.LastName,
                Email =  passenger.Email,
                PhoneNumber =  passenger.PhoneNumber,
                Address =  passenger.Address,
            };
        }

        public Passenger GetPassengerByPassWordReturningObjectPassenger(string passWord)
        {
            return _context.Passengers.SingleOrDefault(passenger => passenger.Password == passWord);
        }

        public PassengerDto GetPassengerByPassWordReturningObjectPassengerDto(string passWord)
        {
            var passenger = _context.Passengers.SingleOrDefault(passenger => passenger.Password == passWord);
            return new PassengerDto
            {
                FirstName =  passenger.FirstName,
                LastName =  passenger.LastName,
                Email =  passenger.Email,
                PhoneNumber =  passenger.PhoneNumber,
                Address =  passenger.Address,
            };
        }

        public string Update(Passenger passenger)
        {
            _context.Passengers.Update(passenger);
            _context.SaveChanges();
            return $"Successfully updated";
        }
    }
}