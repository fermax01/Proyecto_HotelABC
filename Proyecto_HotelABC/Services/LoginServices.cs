using Microsoft.EntityFrameworkCore;
using Proyecto_HotelABC.Context;
using Proyecto_HotelABC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_HotelABC.Services
{
    public class LoginServices
    {
        public void GenerateSuperAdmin()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    bool superAdminExists = _context.Counts.Any(librarian => librarian.Roles.PkRole == 1);

                    if (!superAdminExists)
                    {
                        var superAdmin = new Count
                        {
                            Name = "Dominic",
                            Lastname = "Vargas",
                            Mail = "test@gmail.com",
                            PhoneNumber = "123456789",
                            Password = "sa123",
                            FkRole = 1
                        };

                        _context.Counts.Add(superAdmin);
                        _context.SaveChanges();
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error (GenerateSA) " + ex.Message);
            }
        }

        public void GenerateRoles()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    bool superAdminRoleExists = _context.Roles.Any(role => role.Name == "Gerente");
                    bool EmployeeExists = _context.Roles.Any(role => role.Name == "Empleado");
                    bool GuestExists = _context.Roles.Any(role => role.Name == "Huesped");


                    if (!superAdminRoleExists)
                    {
                        var superAdminRole = new Role
                        {
                            Name = "Gerente"
                        };

                        _context.Roles.Add(superAdminRole);
                        _context.SaveChanges();
                    }

                    if (!EmployeeExists)
                    {
                        var EmployeeRole = new Role
                        {
                            Name = "Empleado"
                        };

                        _context.Roles.Add(EmployeeRole);
                        _context.SaveChanges();
                    }

                    if (!GuestExists)
                    {
                        var GuestRole = new Role
                        {
                            Name = "Huesped"
                        };

                        _context.Roles.Add(GuestRole);
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error (GenerateRoles) " + ex.Message);
            }
        }

        public Count Login(string mail, string password)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    var response = _context.Counts.Include(y => y.Roles).FirstOrDefault(x => x.Mail == mail && x.Password == password);
                    return response;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error (Login) " + ex.Message);
            }
        }
    }
}
