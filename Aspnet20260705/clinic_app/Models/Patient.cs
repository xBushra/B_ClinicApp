using ClinicApp.ViewModels;
using System;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp.Models
{
    public class Patient
    {

        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public DateTime HireDate { get; set; }

        public double Salary { get; set; }
        public string? UserId { get; set; }

        public List<Appointment> Appointments { get; set; } = new();
        public List<Speciality> Specialities { get; set; } = new();
        public IdentityUser? User { get; set; }

        public PatientReadVM ToPatientReadVM()
        {
            return new PatientReadVM
            {
                Id = Id,
                Name = Name,
                HireDate = HireDate,
                Salary = Salary,
                Specialities = Specialities.Select(s => s.ToSpecialityReadVM()).ToList(),
            };
        }

        public PatientUpdateVM ToPatientUpdateVM()
        {
            return new PatientUpdateVM
            {
                Name = Name,
                HireDate = HireDate,
                Salary = Salary,
                SelectedSpecialityIds = Specialities.Select(s => s.Id).ToList(),
            };
        }
    }
}