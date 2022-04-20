using BusManagementSystem.Entities.Enums;

namespace BusManagementSystem.Entities
{
    public abstract class User
    {
        public int Id {get;set;}
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public string Email {get;set;}
        public string Password {get;set;}
        public string PhoneNumber {get;set;}
        public string Address {get;set;}
        public UserType userType {get;set;}        
        
    }
}