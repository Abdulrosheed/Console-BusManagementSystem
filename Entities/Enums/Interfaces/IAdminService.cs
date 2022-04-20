using System.Collections.Generic;
using BusManagementSystem.DTOs;

namespace BusManagementSystem.Entities.Enums.Interfaces
{
    public interface IAdminService
    {
        string Create(CreateAdminRequestModel model);
        AdminDto GetAdminById (int id);
        List <AdminDto> GetAllAdmin();
        AdminDto GetAdminByPassWord (string passWord);
        void Update(UpdateAdminRequestModel model , string passWord);
        void Delete ( string password); 
        bool Login (LoginAdminModel model);
    }
}