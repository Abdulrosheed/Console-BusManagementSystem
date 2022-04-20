using System;
using System.Collections.Generic;
using BusManagementSystem.Entities.Enums;

namespace BusManagementSystem.DTOs
{
    public class BusDTo
    {
        public int Id {get;set;}
        public string Model {get;set;}
        public BusType BusType {get;set;}
        public string RegistrationNumber {get;set;}
        public int Capacity {get;set;}
        public bool AvailabilityStatus {get;set;}
        public string PlateNumber {get;set;}
        public bool TripStatus {get ; set;}
        
        public List<TripDto> Trips {get; set;} = new List<TripDto>();
        
        public override string ToString()
        {
            return $" {RegistrationNumber} , {AvailabilityStatus} , {TripStatus} , {Capacity}";
        }

        
    }
    public class CreateBusRequestModel
    {
        public string Model { get; set; }

        public BusType BusType { get; set; }

        public string PlateNumber { get; set; }

        public int Capacity { get; set; }
        public UserType userType {get;set;}    
    }
    public class UpdateBusRequestModel
    {
        
        public BusType BusType {get;set;}
        public string PlateNumber {get;set;}

        
        
    }
}