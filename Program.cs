using System;
using System.Collections.Generic;
using BusManagementSystem.DTOs;
using BusManagementSystem.Entities;
using BusManagementSystem.Entities.Enums;
using BusManagementSystem.Repositories;
using BusManagementSystem.Services;

namespace BusManagementSystem
{
  
    class Program
    {
        static BusService _busService = new BusService();
        static TripService _tripService = new TripService();
        static DriverService _driverService = new DriverService();
        static PassengerService _passengerService = new PassengerService();
        static AdminService _adminService = new AdminService();
        static BookingService _bookingService = new BookingService();
        static void Main(string[] args)
        {
          var trip = new CreateBookingRequestModel 
          {
            TripLandingPoint = Location.Ibadan,
            TripTakeOffPoint =  Location.Lagos,
            BookingDate = DateTime.Parse("2018-08-18")
             
          };
          var login = new LoginPassengerModel
          {
              PassWord = "4D391B9",
              Email = "koladeJimoh@gmail.com",
          };
          var trip2 = new CreateAdminRequestModel 
          {
            FirstName = "BossToheeb",
            LastName = "SearchOnline",
            Email = "BossToheebSearchOnline@gmail.com",
            PhoneNumber = "08087435217",
            Address = "Oshogbo",
          };
          var trip3 = new UpdateAdminRequestModel 
          {
              FirstName = "Rashford",
          };

            // _driverService.Update(resultv , "DF3245");
    
            // var x= _bookingService.DeleteBooking("94F1C80DB");
            // Console.WriteLine(x);
            var buses = _busService.GetAvailableBuses();


            //var y = _tripService.Schedule(trip2);
           // var result = _driverService.Create(driver3);
            foreach (var item in buses)
            {
              var trips = item.Trips;
              foreach(var tr in trips)
              {
                   Console.WriteLine($"{tr.Id} {tr.price}");
              }
            }
            
          // Console.WriteLine(result);
            
           // Console.WriteLine(y.DriverFullName);
            //Console.WriteLine(x.DriverFullName);
            
          
            
        }
    }
}
