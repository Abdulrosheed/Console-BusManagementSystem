using System.Collections.Generic;
using BusManagementSystem.DTOs;

namespace BusManagementSystem.Entities.Enums.Interfaces
{
    public interface IPassengerService
    {
        string Create(CreatePassengerRequestModel model);
        PassengerDto GetPassengerById (int id);
        List <PassengerDto> GetAllPassenger();
        PassengerDto GetPassengerByPassWord (string passWord);
        void Update(UpdatePassengerRequestModel model , string passWord);
        void Delete ( string password);
        bool Login (LoginPassengerModel model); 
    }
}