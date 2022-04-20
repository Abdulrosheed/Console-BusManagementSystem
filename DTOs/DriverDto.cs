namespace BusManagementSystem.DTOs
{
    public class DriverDto
    {
        public int Id {get;set;}
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public string Email {get;set;}
        public string Password {get;set;}
        public string PhoneNumber {get;set;}
        public string Address {get;set;}
        public string LicenseNumber {get;set;}
    }
    public class CreateDriverRequestModel
    {
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public string Email {get;set;}
        
        public string PhoneNumber {get;set;}
        public string Address {get;set;}
        public string LicenseNumber {get;set;}
    }
    public class UpdateDriverRequestModel
    {
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public string Email {get;set;}
        public string PhoneNumber {get;set;}
        public string Address {get;set;}
        public string LicenseNumber {get;set;}
    }
    public class LoginDriverModel
    {
        public string PassWord {get;set;}
        public string Email {get;set;}
    }
}