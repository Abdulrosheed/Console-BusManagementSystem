using System;
using System.Collections.Generic;
using BusManagementSystem.DTOs;

namespace BusManagementSystem.Entities.Enums.Interfaces
{
    public interface ITripRepository
    {
        Trip CreateTrip(Trip trip);
        
        string Update(Trip trip);
        void DeleteTripByReferenceNumber(string ReferenceNumber);
        List <TripDto> GetAllTrip ();
        TripDto GetTripByIdReturningObjectTripDto(int id);
        Trip GetTripByIdReturningObjectTrip(int id);
        TripDto GetTripByReferenceNumberReturningObjectTripDto(string reference);
        Trip GetTripByReferenceNumberReturningObjectTrip(string reference);
        bool ExistsById (int id);
        List <TripDto> GetTripsByDateAndLocation(Location from , Location to , DateTime date);
        List <TripDto> GetAvailableTrips(Location from, Location to , DateTime date );
        List <TripDto> GetTripByDriver (int driverId);
        List <TripDto> GetInitialisedTrips();
        List<TripDto> GetTripsByBus(string registrationNumber);
        List <TripDto> GetTripsByDate(DateTime date);
        List <TripDto> GetCompletedTrips();
        List <TripDto> GetCancelledTrips();
        List <TripDto> GetCancelledTripsByDate(DateTime date);
        bool ExistsByReferenceNumber (string referenceNumber);


    }
}