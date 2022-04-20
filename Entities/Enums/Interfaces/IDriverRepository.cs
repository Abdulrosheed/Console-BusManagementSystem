using System.Collections.Generic;
using BusManagementSystem.DTOs;

namespace BusManagementSystem.Entities.Enums.Interfaces
{
    public interface IDriverRepository
    {
        string Create(Driver driver);
        Driver GetDriverByIdByReturningObjectDriver(int id);
        DriverDto GetDriverByIdByReturningObjectDriverDto(int id);
        List <DriverDto> GetAllDriver();
        Driver GetDriverByPassWordReturningObjectDriver (string passWord);
        Driver GetDriverByEmailReturningObjectDriver (string email);
        DriverDto GetDriverByPassWordReturningObjectDriverDto (string passWord);
        Driver GetDriverByLicenseNumberReturningObjectDriver(string  licenseNumber);
        DriverDto GetDriverByLicenseNumberReturningObjectDriverDto(string  licenseNumber);
        string Update(Driver driver);
        void Delete (Driver driver);
        bool ExistById (int id);
        bool ExistsByLicenseNumber (string licenseNumber);
    }
}