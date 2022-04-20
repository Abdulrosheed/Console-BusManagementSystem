using System.Collections.Generic;
using BusManagementSystem.DTOs;

namespace BusManagementSystem.Entities.Enums.Interfaces
{
    public interface IAdminRepository
    {
        string Create(Admin admin);
        Admin GetAdminByIdReturningAdminObject (int id);
        AdminDto GetAdminByIdReturningAdminDtoObject (int id);
        List <AdminDto> GetAllAdmin();
        Admin GetAdminByPassWordReturningAdminObject(string passWord);
        Admin GetAdminByEmailReturningAdminObject(string email);
        AdminDto GetAdminByPassWordReturningAdminDtoObject(string passWord);
        string Update(Admin admin);
        void Delete (Admin admin);
        bool ExistById (int id);
        bool ExistsByPassWord (string passWord);
    }
}