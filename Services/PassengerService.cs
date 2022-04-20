using System;
using System.Collections.Generic;
using BusManagementSystem.DTOs;
using BusManagementSystem.Entities;
using BusManagementSystem.Entities.Enums.Interfaces;
using BusManagementSystem.Repositories;

namespace BusManagementSystem.Services
{
    public class PassengerService : IPassengerService
    {
          private readonly PassengerRepository _passengerRepository;

        public PassengerService()
        {
            _passengerRepository = new PassengerRepository();
        }
        public string Create(CreatePassengerRequestModel model)
        {
            var passenger = new Passenger
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
                Password = Guid.NewGuid().ToString().Substring(0,7).ToUpper().Replace("-" , ""),
                
            };
            _passengerRepository.Create(passenger);
            return $"Passenger created Successfully";
        }

        public void Delete(string passWord)
        {
            var passenger = _passengerRepository.GetPassengerByPassWordReturningObjectPassenger(passWord);
           if(passenger == null)
           {
               throw new NotFoundException ($"Passenger with password {passWord} doesn't exist");
           }
           _passengerRepository.Delete(passenger);
        }

        public List<PassengerDto> GetAllPassenger()
        {
            var passenger = _passengerRepository.GetAllPassenger();
            if(passenger == null)
            {
                throw new NotFoundException ($"No passenger has been recorded");
            }
            return passenger;
        }

        public PassengerDto GetPassengerById(int id)
        {
            var passenger = _passengerRepository.GetPassengerByIdReturningObjectPassengerDto(id);
            if(passenger == null)
            {
                throw new NotFoundException ($"Passsenger with id {id} doesn't exist");
            }
            
            return passenger;
        }

        public PassengerDto GetPassengerByPassWord(string passWord)
        {
            var passenger = _passengerRepository.GetPassengerByPassWordReturningObjectPassengerDto(passWord);
            if(passenger == null)
            {
                throw new NotFoundException ($"Passsenger with id {passWord} doesn't exist");
            }
            return passenger;
        }

        public bool Login(LoginPassengerModel model)
        {
            var passenger = _passengerRepository.GetPassengerByEmailReturningObjectPassenger(model.Email);
            if(passenger == null || passenger.Password != model.PassWord)
            {
                throw new NotFoundException("Email or Password is invalid");
            }
            return true;
        }

        public void Update(UpdatePassengerRequestModel model, string passWord)
        {
            if(!(_passengerRepository.ExistsByPassWord(passWord)))
           {
                throw new NotFoundException ($"Passenger with password {passWord} doesn't exist");
           }
           var passenger = _passengerRepository.GetPassengerByPassWordReturningObjectPassenger(passWord);
           passenger.LastName = model.LastName ?? passenger.LastName;
           passenger.Address = model.Address ?? passenger.Address;
           passenger.FirstName = model.FirstName ?? passenger.FirstName;
           passenger.PhoneNumber = model.FirstName?? passenger.FirstName;
           passenger.Email = model.Email?? passenger.Email;
           _passengerRepository.Update(passenger);
        }
    }
}