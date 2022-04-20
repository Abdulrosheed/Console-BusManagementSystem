using System.Collections.Generic;
using System.Linq;
using BusManagementSystem.DTOs;
using BusManagementSystem.Entities;
using BusManagementSystem.Entities.Context;
using BusManagementSystem.Entities.Enums.Interfaces;

namespace BusManagementSystem.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly  BusManagementSystemDbContext  _context;
        public AdminRepository()
        {
            _context = new BusManagementSystemDbContext();
        }
        public string Create(Admin admin)
        {
            _context.Admins.Add(admin);
            _context.SaveChanges();
            return "Sucesssfuly created an admin";
        }

        public void Delete(Admin admin)
        {
            _context.Admins.Remove(admin);
            _context.SaveChanges();
        }

        public bool ExistById(int id)
        {
            return _context.Admins.Any(admin => admin.Id == id);
        }

        public bool ExistsByPassWord(string passWord)
        {
            return _context.Admins.Any(admin => admin.Password == passWord); 
        }

        public List<AdminDto> GetAllAdmin()
        {
               return _context.Admins.Select(admins => new AdminDto 
            {
                FirstName = admins.FirstName,
                LastName = admins.LastName,
                Email = admins.Email,
                PhoneNumber = admins.PhoneNumber,
                Address = admins.Address,
            }).ToList();
        }

        public Admin GetAdminByIdReturningAdminObject(int id)
        {
            return _context.Admins.SingleOrDefault(admin => admin.Id == id);
        }

        public Admin GetAdminByPassWordReturningAdminObject(string passWord)
        {
            return _context.Admins.SingleOrDefault(admin => admin.Password == passWord);
        }

        public string Update(Admin admin)
        {
            _context.Admins.Update(admin);
            _context.SaveChanges();
            return $"Successfully updated";
        }

        

        public AdminDto GetAdminByIdReturningAdminDtoObject(int id)
        {
            var admin =  _context.Admins.SingleOrDefault(admin => admin.Id == id); 
            return new AdminDto
            {
                FirstName = admin.FirstName,
                LastName = admin.LastName,
                Email = admin.Email,
                PhoneNumber = admin.PhoneNumber,
                Address = admin.Address,
            };
        }

        

        public AdminDto GetAdminByPassWordReturningAdminDtoObject(string passWord)
        {
            var admin =  _context.Admins.SingleOrDefault(admin => admin.Password == passWord);
            return new AdminDto
            {
                FirstName = admin.FirstName,
                LastName = admin.LastName,
                Email = admin.Email,
                PhoneNumber = admin.PhoneNumber,
                Address = admin.Address,
            };
        }

        public Admin GetAdminByEmailReturningAdminObject(string email)
        {
            return _context.Admins.SingleOrDefault(admin => admin.Email == email);
        }
    }
}