using ApptmentmentScheduler.Models.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApptmentmentScheduler.DataAccessLayer.Data
{
    public class AppDbContext: IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Appointment>Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           // modelBuilder.Entity<Appointment>().HasData
           //(
           //  new Appointment {Id = 1, Name = "Abu Ghalib", Description= "Meet with the Marketing team", DateTime = DateTime.Now },
           //  new Appointment { Id = 2, Name="john", Description="Meeting with CEO Of LexCorp", DateTime=  DateTime.Now }   
            
           //);

        }

    }
}
