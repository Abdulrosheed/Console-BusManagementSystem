using System.Collections.Generic;
using BusManagementSystem.DTOs;

namespace BusManagementSystem.Entities.Enums.Interfaces
{
    public interface IDriverService
    {
        string Create(CreateDriverRequestModel driver);
        DriverDto GetDriverById (int id);
        List <DriverDto> GetAllDriver();
        DriverDto GetByLicenseNumber (string licenseNumber);
        void Update(UpdateDriverRequestModel driver , string licenseNumber);
        void Delete ( string password);
        bool Login (LoginDriverModel model);
    }
}