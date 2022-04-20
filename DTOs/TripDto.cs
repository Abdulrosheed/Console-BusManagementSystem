using System;
using BusManagementSystem.Entities.Enums;

namespace BusManagementSystem.DTOs
{
    public class TripDto
    {
        public Location TakeOffPoint {get;set;}
        public Location LandingPoint {get;set;}
        public DateTime TakeOffTime {get;set;}
        public DateTime LandingTime {get;set;}
        public decimal price {get;set;}
        public string TripReferenceNumber {get;set;}
        public string  BusRegistrationNumber {get;set;}
        public string  BusModel {get;set;}
        public string  DriverFullName {get;set;}
        public TripStatusType  Status {get;set;}
        public int  AvailableSeat {get;set;}
        public int Id {get;set;}
        public int BusId {get;set;}
        public int DriverId {get;set;}
    }
    public class CreateTripRequestModel
    {
         public Location TakeOffPoint {get;set;}
        public Location LandingPoint {get;set;}
        public DateTime TakeOffTime {get;set;}
        public DateTime LandingTime {get;set;}
        public decimal price {get;set;}
        public int DriverId {get;set;}
        public int BusId {get;set;}
        public TripStatusType tripStatus {get;set;}
    }
    public class UpdateTripRequestModel
    {
        public decimal price {get;set;}
        public int BusId {get;set;}
        public int DriverId {get;set;}
        public Location TakeOffPoint {get;set;}
        public Location LandingPoint {get;set;}
        public DateTime TakeOffTime {get;set;}
        public DateTime LandingTime {get;set;}
    }
}