using System;
using System.Collections.Generic;
using BusManagementSystem.DTOs;
using BusManagementSystem.Entities;
using BusManagementSystem.Entities.Enums.Interfaces;
using BusManagementSystem.Repositories;


namespace BusManagementSystem.Services
{
    
    public class DriverService : IDriverService
    {
        private readonly DriverRepository   _driverRepository;
        public DriverService()
        {
            _driverRepository = new DriverRepository();
        }

        public string Create(CreateDriverRequestModel driver)
        {
            var drivers = new Driver
            {
                FirstName = driver.FirstName,
                LastName = driver.LastName,
                Email = driver.Email,
                PhoneNumber = driver.PhoneNumber,
                Address = driver.Address,
                LicenseNumber = driver.LicenseNumber,
                userType = Entities.Enums.UserType.Driver,
                Password = Guid.NewGuid().ToString().Substring(0,7).ToUpper().Replace("-" , ""),
                
            };
            _driverRepository.Create(drivers);
            return $"Driver created Successfully";

        }

        public void Delete(string passWord)
        {
           var driver = _driverRepository.GetDriverByPassWordReturningObjectDriver(passWord);
           if(driver == null)
           {
               throw new NotFoundException ($"Driver with password {passWord} doesn't exist");
           }
           _driverRepository.Delete(driver);
           
        }

        

        public List<DriverDto> GetAllDriver()
        {
            var driver = _driverRepository.GetAllDriver();
            if(driver == null)
            {
                throw new NotFoundException ($"No driver has been recorded");
            }
            return driver;
        }

        public DriverDto GetByLicenseNumber(string licenseNumber)
        {
            var driver = _driverRepository.GetDriverByLicenseNumberReturningObjectDriverDto(licenseNumber);
            if(driver == null)
            {
                throw new NotFoundException ($"Driver with license number {licenseNumber} doesn't exist");
            }
           return driver;
        }

        public DriverDto GetDriverById(int id)
        {
            var driver = _driverRepository.GetDriverByIdByReturningObjectDriverDto(id);
            if(driver == null)
            {
                throw new NotFoundException ($"Driver with id {id} doesn't exist");
            }
            
            return driver;
        }

        public bool Login(LoginDriverModel model)
        {
            var driver = _driverRepository.GetDriverByEmailReturningObjectDriver(model.Email);
            if(driver == null || driver.Password != model.PassWord)
            {
                throw new NotFoundException("Email or Password is invalid");
            }
            return true;
        }

        public void Update(UpdateDriverRequestModel model , string licenseNumber)
        {
           
           if(!(_driverRepository.ExistsByLicenseNumber(licenseNumber)))
           {
                throw new NotFoundException ($"Driver with license number {licenseNumber} doesn't exist");
           }
           var driver = _driverRepository.GetDriverByLicenseNumberReturningObjectDriver(licenseNumber);
           driver.LastName = model.LastName ?? driver.LastName;
           driver.Address = model.Address ?? driver.Address;
           driver.FirstName = model.FirstName ?? driver.FirstName;
           driver.Address = model.Address ?? driver.Address;
           driver.PhoneNumber = model.FirstName ?? driver.PhoneNumber;
           driver.Email = model.Email??driver.Email;
           _driverRepository.Update(driver);


        }

        
    }
}