using System.Collections.Generic;
using BusManagementSystem.DTOs;

namespace BusManagementSystem.Entities.Enums.Interfaces
{
    public interface IBusService
    {
        string Register(CreateBusRequestModel model);
        bool UpdateByRegistrationNumber(string registrationNumber , UpdateBusRequestModel model);
        bool ChangeTripStatus(string registrationNumber , bool IsDone);
        bool ChangeAvailabilityStatus(string registrationNumber , bool tripAvailabilityStatus);
        string Delete(string registrationNumber);
        BusDTo GetByRegistrationNumber(string registrationNumber);
        BusDTo GetById(int id);
        IList<BusDTo> GetAllBuses();
        IList<BusDTo> GetAvailableBuses();
        
    }
}