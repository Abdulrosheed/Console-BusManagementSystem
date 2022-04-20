using System;
using System.Collections.Generic;
using BusManagementSystem.DTOs;

namespace BusManagementSystem.Entities.Enums.Interfaces
{
    public interface ITripService
    {
        TripDto Schedule(CreateTripRequestModel model);

        TripDto GetTripById(int id);

        TripDto GetTripByReference(string referenceNumber);

        List<TripDto> GetAllTrips();

        List<TripDto> GetTripsByDate(DateTime date);

        List<TripDto> GetTripsByDateAndLocation(Location from, Location to, DateTime date);

        List<TripDto> GetAvailableTrips(Location from, Location to, DateTime date);

        List<TripDto> GetCancelledTripsByDate(DateTime date);

        List<TripDto> GetCompletedTrips();

        List<TripDto> GetTripsByBus(string registrationNumber);

        List<TripDto> GetTripsByDriver(int driverId);

        List<TripDto> GetInitialisedTrips();

        List<TripDto> GetCancelledTrips();

        TripDto RescheduleTrip(UpdateTripRequestModel model, string tripReferenceNumber);

        void DeleteByReference(string tripReferenceNumber);

        TripDto UpdateTripStatus(string tripReferenceNumber, TripStatusType tripStatus);
 
 
        
    }
}