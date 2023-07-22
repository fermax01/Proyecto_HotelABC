using Microsoft.EntityFrameworkCore;
using Proyecto_HotelABC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_HotelABC.Context
{
    internal class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySQL("server = localhost; database = HotelABC; user = root; password =");
        }

        public DbSet<Count> Counts { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
