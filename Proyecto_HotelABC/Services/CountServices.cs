using Microsoft.EntityFrameworkCore;
using Proyecto_HotelABC.Context;
using Proyecto_HotelABC.Entities;
using Proyecto_HotelABC.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Proyecto_HotelABC.Services
{
    public class CountServices
    {
        public void AddCount(Count request)
        {
            try
            {
                if (InputValidator.IsObjectNull(request))
                {
                    MessageBox.Show("Por favor, llene todos los campos");
                    return;
                }

                using (var _context = new ApplicationDbContext())
                {
                    Count res = new Count();

                    res.Name = request.Name;
                    res.Lastname = request.Lastname;
                    res.Mail = request.Mail;
                    res.PhoneNumber = request.PhoneNumber;
                    res.Password = request.Password;
                    res.FkRole = request.FkRole;

                    _context.Counts.Add(res);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error (AddLibrarian)" + ex.Message);
            }
        }

        public void UptadeCount(Count request)
        {
            try
            {
                if (InputValidator.IsObjectNull(request))
                {
                    MessageBox.Show("Por favor, llene todos los campos");
                    return;
                }

                using (var _context = new ApplicationDbContext())
                {
                    Count res = new Count();
                    res = _context.Counts.Find(request.PkCount);

                    res.Name = request.Name;
                    res.Lastname = request.Lastname;
                    res.Mail = request.Mail;
                    res.PhoneNumber = request.PhoneNumber;
                    res.Password = request.Password;
                    res.FkRole = request.FkRole;

                    _context.Update(res);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error (UpdateLibrarian)" + ex.Message);
            }
        }

        public void DeleteCount(int pkCount)
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    Count res = _context.Counts.Find(pkCount);
                    if (InputValidator.IsObjectNull(res))
                    {
                        MessageBox.Show("No se encontró el registro");
                        return;
                    }
                    _context.Counts.Remove(res);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error (DeleteLibrarian)" + ex.Message);
            }
        }

        public List<Count> GetCounts()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Count> employes = _context.Counts.Include(x => x.Roles).ToList();
                    if (employes.Count > 0)
                    {
                        return employes;
                    }
                    return employes;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error (GetLibrarians)" + ex.Message);
            }
        }

        public List<Role> GetRoles()
        {
            try
            {
                using (var _context = new ApplicationDbContext())
                {
                    List<Role> roles = _context.Roles.ToList();
                    return roles;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error (GetRoles)" + ex.Message);
            }
        }
    }
}
