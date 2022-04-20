using System;
using System.Collections.Generic;
using BusManagementSystem.DTOs;

namespace BusManagementSystem.Entities.Enums.Interfaces
{
    public interface IBookingService
    {
        BookingDto ScheduleABooking(CreateBookingRequestModel model , LoginPassengerModel template);
        void ScheduleMultipleBooking(List <CreateBookingRequestModel> model,LoginPassengerModel template);
        string ResheduleAbooking(UpdateBookingRequestModel model , string bookingReference);
        string DeleteBooking (string bookingReference);
        List<BookingDto> GetAllBooking();
        List<BookingDto> GetCurrentBooking(DateTime date);
        BookingDto GetBookingByBookingReference(string bookingReference);
        

    }
}