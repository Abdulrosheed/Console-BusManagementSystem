using System.Collections.Generic;

namespace BusManagementSystem.Entities
{
    public class Passenger : User
    {
       public virtual List <Booking> bookings {get;set;} = new List<Booking>();
    }
}