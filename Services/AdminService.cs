using System;
using System.Collections.Generic;
using BusManagementSystem.DTOs;
using BusManagementSystem.Entities;
using BusManagementSystem.Entities.Enums.Interfaces;
using BusManagementSystem.Repositories;

namespace BusManagementSystem.Services
{
    public class AdminService : IAdminService
    {
        private readonly AdminRepository _adminRepository;

        public AdminService()
        {
            _adminRepository = new AdminRepository();
        }

        public string Create(CreateAdminRequestModel model)
        {
                var admin = new Admin
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
                Password = Guid.NewGuid().ToString().Substring(0,7).ToUpper().Replace("-" , ""),
                
            };
            _adminRepository.Create(admin);
            return $"Admin created Successfully";
        }

        public void Delete(string passWord)
        {
            var admin = _adminRepository.GetAdminByPassWordReturningAdminObject(passWord);
           if(admin == null)
           {
               throw new NotFoundException ($"Admin with password {passWord} doesn't exist");
           }
           _adminRepository.Delete(admin);
        }

        public List<AdminDto> GetAllAdmin()
        {
            var admin = _adminRepository.GetAllAdmin();
            if(admin == null)
            {
                throw new NotFoundException ($"No Admin has been recorded");
            }
            return admin;
        }

        public AdminDto GetAdminById(int id)
        {
            var admin = _adminRepository.GetAdminByIdReturningAdminDtoObject(id);
            if(admin == null)
            {
                throw new NotFoundException ($"Admin with id {id} doesn't exist");
            }
            
            return admin;
        }

        public AdminDto GetAdminByPassWord(string passWord)
        {
            var admin = _adminRepository.GetAdminByPassWordReturningAdminDtoObject(passWord);
            if(admin == null)
            {
                throw new NotFoundException ($"Admin with id {passWord} doesn't exist");
            }
            return admin;
        }

        public void Update(UpdateAdminRequestModel model, string passWord)
        {
                 if(!(_adminRepository.ExistsByPassWord(passWord)))
           {
                throw new NotFoundException ($"Admin with password {passWord} doesn't exist");
           }
           var admin = _adminRepository.GetAdminByPassWordReturningAdminObject(passWord);
            admin.LastName = model.LastName ?? admin.LastName;
            admin.Address = model.Address;
            admin.FirstName = model.FirstName;
            admin.Address = model.Address;
            admin.PhoneNumber = model.FirstName;
            admin.Email = model.Email;
           _adminRepository.Update(admin);
        }

        public bool Login(LoginAdminModel model)
        {
            var admin = _adminRepository.GetAdminByEmailReturningAdminObject(model.Email);
            if(admin == null || admin.Password != model.PassWord)
            {
                throw new NotFoundException("Email or Password is invalid");
            }
            return true;

        }
    }
}