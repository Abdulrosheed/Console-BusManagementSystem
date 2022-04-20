using System;
using BusManagementSystem.Entities.Enums;

namespace BusManagementSystem.Entities
{
    public class Booking
    {
        public int Id {get;set;}
        public int PassengerId {get;set;}
        public int NumberOfPassenger {get;set;}
        public Passenger Passenger {get;set;}
        public int  TripId {get;set;}
        public int  SeatNumber {get;set;}
        public Trip Trip {get;set;}
        public string BookingReference {get;set;}
        public DateTime BookingTime {get ; set;}
        public BookingStatus BookingStatus {get;set;}
        public Location TripTakeOffPoint {get;set;}
        public Location TripLandingPoint {get;set;}
    
        public bool IsPaid {get;set;}
        
    }
}