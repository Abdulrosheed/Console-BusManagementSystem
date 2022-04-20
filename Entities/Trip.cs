using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BusManagementSystem.Entities.Enums;

namespace BusManagementSystem.Entities
{
    public class Trip
    {
        public int Id {get;set;}
        public int BusId {get;set;}
        public Bus Bus {get;set;}
        public Location TakeOffPoint {get;set;}
        public Location LandingPoint {get;set;}
        public DateTime TakeOffTime {get;set;}
        public DateTime LandingTime {get;set;}
        public int DriverId {get;set;}
        public Driver Driver {get;set;}
        public TripStatusType tripStatusType {get;set;}
        public string TripReferenceNumber {get;set;}
  
        public decimal price {get;set;}
        public int AvailableSeat {get ; set;}
        public virtual List <Booking> Bookings {get;set;} = new List<Booking>();
    }
}