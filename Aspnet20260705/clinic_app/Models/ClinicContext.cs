using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp.Models {
    public class ClinicContext : DbContext {

        public DbSet<Patient> Patient { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Speciality> Specialities { get; set; }


        public ClinicContext(DbContextOptions<ClinicContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Appointment>()
                .Property(a => a.AllocationDate)
                .HasDefaultValueSql("GetDate()");

            modelBuilder.Entity<Speciality>()
                .HasMany(d => d.Patients)
                .WithMany(s => s.Specialities)
                .UsingEntity<PatientSpeciality>();


            modelBuilder.Entity<Patient>()
                .HasData([
                    new Patient {Id =1, Name= "Ahmed", Salary=20000},
                    new Patient {Id=2, Name= "Wael", Salary=10000},
                    new Patient {Id=3, Name= "Fahad", Salary=25000},
                    ]);

            modelBuilder.Entity<Speciality>()
                .HasData([
                        new Speciality { Id = 1, Name = "Pediatric" },
                        new Speciality { Id = 2, Name = "ENT" },
                        new Speciality { Id = 3, Name = "Cardiology" },
                        new Speciality { Id = 4, Name = "OB-Obge" },

                    ]);

            modelBuilder.Entity<PatientSpeciality>()
                .HasData([
                        new PatientSpeciality { PatientId = 1, SpecialityId = 2 },
                        new PatientSpeciality { PatientId = 1, SpecialityId = 3 },
                        new PatientSpeciality { PatientId = 2, SpecialityId = 3 },
                        new PatientSpeciality { PatientId = 2, SpecialityId = 2 },
                    ]);



        }
    }
}
