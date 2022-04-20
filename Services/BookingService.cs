using System;
using System.Collections.Generic;
using BusManagementSystem.DTOs;
using BusManagementSystem.Entities;
using BusManagementSystem.Entities.Enums.Interfaces;
using BusManagementSystem.Repositories;

namespace BusManagementSystem.Services
{
    public class BookingService : IBookingService
    {
        private readonly TripRepository _tripRepository = new TripRepository();
        private readonly PassengerRepository _passengerRepository = new PassengerRepository();
        private readonly BookingRepository _bookingRepository = new BookingRepository();
        public string DeleteBooking(string bookingReference)
        {
            var booking = _bookingRepository.GetBookingByReferenceNumberReturningBookingObject(bookingReference);
            if(booking == null)
            {
                throw new NotFoundException ($"Invalid booking reference Number");
            }
            var trip= _tripRepository.GetTripByIdReturningObjectTrip(booking.TripId);
            trip.AvailableSeat++;
            _tripRepository.Update(trip);
            _bookingRepository.DeleteBooking(booking);
            return $"Booking  successfully deleted";
        }

        public List<BookingDto> GetAllBooking()
        {
            var booking = _bookingRepository.GetAllBooking();
            if(booking == null)
            {
                throw new NotFoundException ($"No booking available");
            }
            return booking;

        }

        public BookingDto GetBookingByBookingReference(string bookingReference)
        {
            var booking = _bookingRepository.GetBookingByReferenceNumberReturningBookingObjectBookingDto(bookingReference);
            if(booking == null)
            {
                throw new NotFoundException ($"Invalid booking reference Number");
            }
            return booking;
        }

        public List<BookingDto> GetCurrentBooking(DateTime date)
        {
            var booking = _bookingRepository.GetCurrentBooking(date);
            if(booking == null)
            {
                throw new NotFoundException ($"No available booking at {date}");
            }
            return booking;
        }

        public string ResheduleAbooking(UpdateBookingRequestModel model, string bookingReference)
        {
           var booking = _bookingRepository.GetBookingByReferenceNumberReturningBookingObject(bookingReference);
           
           if(booking == null && booking.BookingStatus != Entities.Enums.BookingStatus.InActive)
           {
               throw new NotFoundException ($"Invalid Booking reference");
           }
           booking.BookingStatus = Entities.Enums.BookingStatus.Rescheduled;
           booking.BookingTime = model.BookingDate;
           booking.TripLandingPoint = model.TripLandingPoint;
           booking.TripTakeOffPoint = model.TripTakeOffPoint;
           _bookingRepository.Update(booking);
           return $"Successfully Rescheduled";
           
           
           
        }

        public BookingDto ScheduleABooking(CreateBookingRequestModel model,LoginPassengerModel template)
        {
            var availableTrips = _tripRepository.GetTripsByDate(DateTime.Now);
            var passenger = _passengerRepository.GetPassengerByEmailReturningObjectPassenger(template.Email);
            foreach(var item in availableTrips)
            {
                Console.WriteLine(item);
            }
            var trip = _tripRepository.GetTripsByDateAndLocationReturningTripObject(model.TripTakeOffPoint , model.TripLandingPoint,model.BookingDate);
            if(trip == null)
            {
                throw new NotFoundException("No available trip");
            }
            if(trip.AvailableSeat <= 2)
            {
                throw new NotFoundException("No available seat");
            }
            
        
            
            var booking = new Booking
            {
                PassengerId = passenger.Id ,
                NumberOfPassenger = trip.AvailableSeat - 2,
                TripId = trip.Id,
                BookingReference = Guid.NewGuid().ToString().Substring(0,10).ToUpper().Replace("-" , ""),
                BookingTime = DateTime.Now, 
                BookingStatus =Entities.Enums.BookingStatus.Active ,
                TripLandingPoint = trip.LandingPoint,
                TripTakeOffPoint = trip.TakeOffPoint,
                IsPaid  = true,
                SeatNumber = trip.AvailableSeat,

            };
            trip.AvailableSeat--;
            _tripRepository.Update(trip);
            _bookingRepository.CreateOneBooking(booking);

            var bookingDto = _bookingRepository.GetBookingByReferenceNumberReturningBookingObjectBookingDto(booking.BookingReference);
            return bookingDto;
        
            
        }

        public void ScheduleMultipleBooking(List <CreateBookingRequestModel> model,LoginPassengerModel template)
        {
            //  var availableTrips = _tripRepository.GetTripsByDate(DateTime.Now);
            // var passenger = _passengerRepository.GetPassengerByEmailReturningObjectPassenger(template.Email);
            // foreach(var item in availableTrips)
            // {
            //     Console.WriteLine(availableTrips);
            // }
            // var trip = _tripRepository.GetTripsByDateAndLocationReturningTripObject(model.TripTakeOffPoint , model.TripLandingPoint,model.BookingDate);
            // if(trip.AvailableSeat <= trip.AvailableSeat - 2 && trip != null)
            // {
            //     var booking = new Booking
            //     {
            //         PassengerId = passenger.Id ,
            //         NumberOfPassenger = trip.AvailableSeat - 2,
            //         TripId = trip.Id,
            //         BookingReference = Guid.NewGuid().ToString().Substring(0,10).ToUpper().Replace("-" , ""),
            //         BookingTime = DateTime.Now, 
            //         BookingStatus =Entities.Enums.BookingStatus.Active ,
            //         IsPaid  = true,

            //     };
            //     trip.AvailableSeat--;
            //     _bookingRepository.CreateOneBooking(booking);
            

            // }
        }
    }
}