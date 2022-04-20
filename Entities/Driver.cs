using System.Collections.Generic;

namespace BusManagementSystem.Entities
{
    public class Driver : User
    {
        public string LicenseNumber {get;set;}
        public virtual List<Trip> trips {get;set;} = new List<Trip>();
    }
}