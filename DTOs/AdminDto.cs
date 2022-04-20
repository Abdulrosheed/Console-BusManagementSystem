namespace BusManagementSystem.DTOs
{
    public class AdminDto
    {
           public int Id {get;set;}
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public string Email {get;set;}
        public string Password {get;set;}
        public string PhoneNumber {get;set;}
        public string Address {get;set;}
    }
    public class UpdateAdminRequestModel
    {
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public string Email {get;set;}
        public string PhoneNumber {get;set;}
        public string Address {get;set;}
        public string LicenseNumber {get;set;}
    }
    public class CreateAdminRequestModel
    {
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public string Email {get;set;}
        public string PhoneNumber {get;set;}
        public string Address {get;set;}
        
    }
    public class LoginAdminModel
    {
        public string PassWord {get;set;}
        public string Email {get;set;}
    }
    
}