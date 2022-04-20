using System.Collections.Generic;
using BusManagementSystem.DTOs;

namespace BusManagementSystem.Entities.Enums.Interfaces
{
    public interface IBusRepository 
    {
        Bus CreateBus (Bus bus);
        
        BusDTo GetBusReturningBusDtoObject(int id);
        Bus GetBusReturningBusObject(int id);
        BusDTo GetByRegistrationNumberReturningBusDtoObject(string registrationNumber);
        Bus GetByRegistrationNumberReturningBusObject(string registrationNumber);
        List<BusDTo> GetAll();
        List<BusDTo> GetAvailableBuses();
        void DeleteBus (Bus bus);
        void Update(Bus bus);
        bool ExistsById(int id);
        bool ExistsByRegistarationNumber(string registrationNumber);
        
    }
}