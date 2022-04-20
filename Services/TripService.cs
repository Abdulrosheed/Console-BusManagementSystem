using System;
using System.Collections.Generic;
using System.Linq;
using BusManagementSystem.DTOs;
using BusManagementSystem.Entities;
using BusManagementSystem.Entities.Enums;
using BusManagementSystem.Entities.Enums.Interfaces;
using BusManagementSystem.Repositories;

namespace BusManagementSystem.Services
{
    public class TripService : ITripService
    {
        private readonly TripRepository _tripRepository;
        private readonly BusRepository _busRepository;
        private readonly DriverRepository _driverRepository;
        

        public TripService()
        {
            _busRepository = new BusRepository();
            _driverRepository = new DriverRepository();
            _tripRepository = new TripRepository(); 
            
        }

        public void DeleteByReference(string tripReferenceNumber)
        {
            if(_tripRepository.ExistsByReferenceNumber(tripReferenceNumber))
            {
                _tripRepository.DeleteTripByReferenceNumber(tripReferenceNumber);
                Console.WriteLine($"Trip with reference number {tripReferenceNumber} successfully deleted");
            }
            else
            {
                Console.WriteLine($"Trip with reference number {tripReferenceNumber} doesn't exist");
            }
        }

        public List<TripDto> GetAllTrips()
        {
            var trips =  _tripRepository.GetAllTrip();
            if(trips == null)
            {
                throw new NotFoundException($"No trip have been recorded");
            }
            return trips;
        }

        public List<TripDto> GetAvailableTrips(Location from, Location to, DateTime date)
        {
            return _tripRepository.GetAvailableTrips(from , to , date);
        }

        public List<TripDto> GetCancelledTrips()
        {
           var trips = _tripRepository.GetCancelledTrips();
           if(trips == null) 
           {
               throw new NotFoundException($"No Cancelled trip have been recorded");
           }
           return trips;
        }

        public List<TripDto> GetCancelledTripsByDate(DateTime date)
        {
            var trips = _tripRepository.GetCancelledTripsByDate(date);
            if(trips == null)
            {
                throw new NotFoundException($"No Cancelled trip have been recorded");
            }
            return trips;
        }

        public List<TripDto> GetCompletedTrips()
        {
            var trips = _tripRepository.GetCompletedTrips();
            if(trips == null)
            {
                throw new NotFoundException($"No Completed trip have been recorded");
            }
            return trips;
        }

        public List<TripDto> GetInitialisedTrips()
        {
            var trips = _tripRepository.GetInitialisedTrips();
            if(trips == null)
            {
                throw new NotFoundException($"No Initialised trip have been recorded");
            }
            return trips;
        }

        public TripDto GetTripById(int id)
        {
            var trip = _tripRepository.GetTripByIdReturningObjectTripDto(id);
            if(trip == null)
            {
                throw new NotFoundException($"Trip with id number{id} not found");
            }
            return trip;
         
        }

        public TripDto GetTripByReference(string referenceNumber)
        {
            var trip = _tripRepository.GetTripByReferenceNumberReturningObjectTripDto(referenceNumber);
            if(trip == null)
            {
                throw new NotFoundException($"Trip with reference number{referenceNumber} not found");
            }
            return trip;
          
        }

        public List<TripDto> GetTripsByBus(string registrationNumber)
        {
            var trips = _tripRepository.GetTripsByBus(registrationNumber);
            if(trips == null)
            {
                throw new NotFoundException($"Bus with registration number {registrationNumber} is not attached to any trip ");
            } 
            return trips;
        }

        public List<TripDto> GetTripsByDate(DateTime date)
        {
            var trips = _tripRepository.GetTripsByDate(date);
            if(trips == null)
            {
                throw new NotFoundException($"Trips with this date {date} doesn't exist");
            }
            return trips;
        }

        public List<TripDto> GetTripsByDateAndLocation(Location from, Location to, DateTime date)
        {
            var trips = _tripRepository.GetTripsByDateAndLocation(from , to , date);
            if(trips == null)
            {
                throw new NotFoundException($"Trips with this date {date} , taking off point {from} , landing point {to} doesn't exist");
            }
            return trips; 
        }

        public List<TripDto> GetTripsByDriver(int driverId)
        {
            if(!(_driverRepository.ExistById(driverId)))
            {
                throw new NotFoundException($"Driver id {driverId} doesn't exist");
            }
            return _tripRepository.GetTripByDriver(driverId);
        }

        public TripDto RescheduleTrip(UpdateTripRequestModel model, string tripReferenceNumber)
        {
            var trip = _tripRepository.GetTripByReferenceNumberReturningObjectTrip(tripReferenceNumber);
            if(trip == null)
            {
                throw new NotFoundException($"Trip with reference number{tripReferenceNumber} not found");
            }
            if(model.price != 0)trip.price = model.price  ;
            if((int)model.TakeOffPoint != 0)trip.TakeOffPoint = model.TakeOffPoint;
            if(model.TakeOffTime != DateTime.Parse("01/01/0001"))trip.TakeOffTime = model.TakeOffTime ;
            if((int)model.LandingPoint != 0)trip.LandingPoint = model.LandingPoint;
            if(model.TakeOffTime != DateTime.Parse("01/01/0001"))trip.LandingTime = model.LandingTime;
            if(model.BusId != 0)trip.BusId = model.BusId;
             if(model.DriverId != 0)trip.DriverId = model.DriverId;

            _tripRepository.Update(trip);
          return _tripRepository.GetTripByReferenceNumberReturningObjectTripDto(tripReferenceNumber);
        }

        

        public TripDto Schedule(CreateTripRequestModel model)
        {
           var bus = _busRepository.GetBusReturningBusObject(model.BusId); 
           if(bus == null)
           {
               throw new NotFoundException ($"The bus with id {model.BusId} not found");
           }
            var trip = new Trip
            {
                BusId = model.BusId,
                TakeOffPoint = model.TakeOffPoint,
                LandingPoint = model.LandingPoint,
                TakeOffTime  = model.TakeOffTime,
                LandingTime = model.LandingTime,
                DriverId = model.DriverId,
                tripStatusType = model.tripStatus,
                TripReferenceNumber = Guid.NewGuid().ToString().Replace("-" , "").Substring(0 , 10).ToUpper(),
                price = model.price,
                AvailableSeat = bus.Capacity,
            };
            _tripRepository.CreateTrip(trip);
            var tripDto = _tripRepository.GetTripByIdReturningObjectTripDto(trip.Id);
            return tripDto;
        }

        public TripDto UpdateTripStatus(string tripReferenceNumber, TripStatusType tripStatus)
        {
            var trip = _tripRepository.GetTripByReferenceNumberReturningObjectTrip(tripReferenceNumber);
            if(trip == null)
            {
                throw new NotFoundException ($"Trip reference number {tripReferenceNumber} not found");
            }
            if((int)tripStatus != 0)trip.tripStatusType = tripStatus;
            
            _tripRepository.Update(trip);
            return _tripRepository.GetTripByReferenceNumberReturningObjectTripDto(tripReferenceNumber);
        

        }
    }
}