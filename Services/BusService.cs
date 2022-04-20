using System;
using System.Collections.Generic;
using System.Linq;
using BusManagementSystem.DTOs;
using BusManagementSystem.Entities;
using BusManagementSystem.Entities.Enums.Interfaces;
using BusManagementSystem.Repositories;

namespace BusManagementSystem.Services
{
    public class BusService : IBusService
    {
        private readonly BusRepository _busRepository = new BusRepository();
        public bool ChangeAvailabilityStatus(string registrationNumber, bool tripAvailabilityStatus)
        {
            var bus = _busRepository.GetByRegistrationNumberReturningBusObject(registrationNumber);
            if(bus == null)
            {
                throw new NotFoundException($"{registrationNumber} not found");
            }
            bus.AvailabilityStatus = tripAvailabilityStatus;
            _busRepository.Update(bus);
            return true;
        }

        public bool ChangeTripStatus(string registrationNumber, bool tripStatus)
        {
            var bus = _busRepository.GetByRegistrationNumberReturningBusObject(registrationNumber);
            if(bus == null)
            {
                throw new NotFoundException($"{registrationNumber} not found");
            }
            bus.TripStatus = tripStatus;
            _busRepository.Update(bus);
            return true;
        }

        public string Delete(string registrationNumber)
        {
            var bus = _busRepository.GetByRegistrationNumberReturningBusObject(registrationNumber);
            if(bus == null)
            {
                throw new NotFoundException($"{registrationNumber} not found");
            }
            _busRepository.DeleteBus(bus);
            return $"Bus sucessfully deleted";
        }

        public IList<BusDTo> GetAllBuses()
        {
            var bus = _busRepository.GetAll() ;
           if(bus == null)
           {
                throw new NotFoundException($"No available bus found");
           }
            return bus;
        }

        public IList<BusDTo> GetAvailableBuses()
        {
            var bus = _busRepository.GetAvailableBuses();
            if(bus == null)
            {
                throw new NotFoundException($"No available bus found");
            }
            return bus;
        }

        public BusDTo GetById(int id)
        {
            var bus = _busRepository.GetBusReturningBusDtoObject(id);
            if(bus == null)
            {
                throw new NotFoundException($"{id} not found");
            }
            return bus;
        
        }

        public BusDTo GetByRegistrationNumber(string registrationNumber)
        {
            var bus = _busRepository.GetByRegistrationNumberReturningBusDtoObject(registrationNumber);
            if(bus == null)
            {
                throw new NotFoundException($"{registrationNumber} not found");
            }
            return bus;
            
            
        }

        public string Register(CreateBusRequestModel model)
        {
            var bus = new Bus
            {
                AvailabilityStatus = true,
                Capacity = model.Capacity,
                BusType = model.BusType,
                Model = model.Model,
                PlateNumber = model.PlateNumber,
                TripStatus = false,
                RegistrationNumber = Guid.NewGuid().ToString().Substring(0, 11).Replace("-", "").ToUpper(),

            };
            _busRepository.CreateBus(bus);
            return $"You have successfully register a bus";
        }

        public bool UpdateByRegistrationNumber(string registrationNumber, UpdateBusRequestModel model)
        {
            var bus = _busRepository.GetByRegistrationNumberReturningBusObject(registrationNumber);
            if(bus == null)
            {
                throw new NotFoundException ($"{registrationNumber} not found");
            }
            bus.PlateNumber = model.PlateNumber ?? bus.PlateNumber;
            if((int)model.BusType != 0) bus.BusType = model.BusType;
            _busRepository.Update(bus);
            return true;
            
        }
    }
}