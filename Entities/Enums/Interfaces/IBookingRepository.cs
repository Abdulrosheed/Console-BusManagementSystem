using System;
using System.Collections.Generic;
using BusManagementSystem.DTOs;

namespace BusManagementSystem.Entities.Enums.Interfaces
{
    public interface IBookingRepository
    {
        void CreateListOfBooking(List<Booking> booking);
        void CreateOneBooking (Booking booking); 
        void Update(Booking booking);
        void DeleteBooking(Booking booking);
        List <BookingDto> GetAllBooking();
        List <BookingDto> GetCurrentBooking(DateTime date);
        BookingDto GetBookingByReferenceNumberReturningBookingObjectBookingDto(string referenceNumber);
        
        Booking GetBookingByReferenceNumberReturningBookingObject(string referenceNumber);
        
    }
}