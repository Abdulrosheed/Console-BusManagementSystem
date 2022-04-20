using System.Collections.Generic;
using BusManagementSystem.DTOs;

namespace BusManagementSystem.Entities.Enums.Interfaces
{
    public interface IPassengerRepository
    {
        string Create(Passenger passenger);
        Passenger GetPassengerByIdReturningObjectPassenger (int id);
        Passenger GetPassengerByEmailReturningObjectPassenger (string email);
        PassengerDto GetPassengerByIdReturningObjectPassengerDto (int id);
        List <PassengerDto> GetAllPassenger();
        Passenger GetPassengerByPassWordReturningObjectPassenger(string passWord);
        PassengerDto GetPassengerByPassWordReturningObjectPassengerDto(string passWord);
        string Update(Passenger passenger);
        void Delete (Passenger passenger);
        bool ExistById (int id);
        bool ExistsByPassWord (string passWord);
    }
}