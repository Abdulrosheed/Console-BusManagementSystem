using System.Collections.Generic;
using System.Linq;
using BusManagementSystem.DTOs;
using BusManagementSystem.Entities;
using BusManagementSystem.Entities.Context;
using BusManagementSystem.Entities.Enums.Interfaces;

namespace BusManagementSystem.Repositories
{
    public class DriverRepository : IDriverRepository
    {
        private readonly  BusManagementSystemDbContext  _context;

        public DriverRepository()
        {
            _context = new BusManagementSystemDbContext();
        }

        public string Create(Driver driver)
        {
            _context.Drivers.Add(driver);
            _context.SaveChanges();
            return "Sucesssfuly created a driver";
        }

        public void Delete(Driver driver)
        {
            _context.Drivers.Remove(driver);
            _context.SaveChanges();
        }

        public bool ExistById(int id)
        {
            return _context.Drivers.Any(driver => driver.Id == id);
        }

        public bool ExistsByLicenseNumber(string licenseNumber)
        {
            return _context.Drivers.Any(driver => driver.LicenseNumber == licenseNumber);
        }

        

        public List<DriverDto> GetAllDriver()
        {
            return _context.Drivers.Select(driver => new DriverDto 
            {
                FirstName = driver.FirstName,
                LastName = driver.LastName,
                Email = driver.Email,
                PhoneNumber = driver.PhoneNumber,
                Address = driver.Address,
            }).ToList();
        }

        public Driver GetDriverByLicenseNumberReturningObjectDriver(string licenseNumber)
        {
            return _context.Drivers.SingleOrDefault(driver => driver.LicenseNumber == licenseNumber);
        }

        

        public Driver GetDriverByIdByReturningObjectDriver(int id)
        {
            return _context.Drivers.SingleOrDefault(driver => driver.Id == id);
        }

        public Driver GetDriverByPassWordReturningObjectDriver(string passWord)
        {
            return _context.Drivers.SingleOrDefault(driver => driver.Password == passWord);
        }

        public string Update(Driver driver)
        {
            _context.Drivers.Update(driver);
            _context.SaveChanges();
            return $"Successfully updated";
        }

        public DriverDto GetDriverByIdByReturningObjectDriverDto(int id)
        {
            var driver =  _context.Drivers.SingleOrDefault(driver => driver.Id == id); 
            return new DriverDto
            {
                FirstName = driver.FirstName,
                LastName = driver.LastName,
                Email = driver.Email,
                PhoneNumber = driver.PhoneNumber,
                Address = driver.Address,

            };
        }

        public DriverDto GetDriverByPassWordReturningObjectDriverDto(string passWord)
        {
              return _context.Drivers.Select(driver => new DriverDto 
            {
                FirstName = driver.FirstName,
                LastName = driver.LastName,
                Email = driver.Email,
                PhoneNumber = driver.PhoneNumber,
                Address = driver.Address,

            }).SingleOrDefault(driver => driver.Password == passWord);
        }

        public DriverDto GetDriverByLicenseNumberReturningObjectDriverDto(string licenseNumber)
        {
            var driver =  _context.Drivers.SingleOrDefault(driver => driver.LicenseNumber == licenseNumber);
            return new DriverDto
            {
                FirstName = driver.FirstName,
                LastName = driver.LastName,
                Email = driver.Email,
                PhoneNumber = driver.PhoneNumber,
                Address = driver.Address,

            };
        }

        public Driver GetDriverByEmailReturningObjectDriver(string email)
        {
            return _context.Drivers.SingleOrDefault(driver => driver.Email == email);
        }
    }
}