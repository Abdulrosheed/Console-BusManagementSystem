using System;
using BusManagementSystem.Entities.Enums;

namespace BusManagementSystem.DTOs
{
    public class BookingDto
    {
        public int Id {get;set;}
        public int PassengerId {get;set;}
        public int NumberOfPassenger {get;set;}
        public string PassengerFullName {get;set;}
        public string DriverFullName {get;set;}
        public Location TripTakeOffPoint {get;set;}
        public Location TripLandingPoint {get;set;}
        public DateTime TripTakeOffTime {get;set;}
        public DateTime TripLandingTime {get;set;}
        public string BusPlateNumber {get;set;}
        public int SeatNumber {get;set;}
        public BusType busType {get;set;}
        public int  TripId {get;set;}
        public string BookingReference {get;set;}
        public DateTime BookingDate {get ; set;}
        public BookingStatus BookingStatus{get;set;}
        public bool IsPaid {get;set;}
    }
    public class CreateBookingRequestModel
    {
        
        public Location TripTakeOffPoint {get;set;}
        public Location TripLandingPoint {get;set;}
    
        public DateTime BookingDate {get ; set;}
    }
    public class UpdateBookingRequestModel
    {
        
        public Location TripTakeOffPoint {get;set;}
        public Location TripLandingPoint {get;set;}
        public int NumberOfBookings {get;set;}
        public DateTime BookingDate {get ; set;}
    }
    
}