//using ClinicApp.Helpers;
using ClinicApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp.ViewModels
    {
        public class PatientCreateVM
    {

            [MaxLength(100)]
            public string Name { get; set; }

            //[NotFutureDate(ErrorMessage = "Hiredate can't be a furture date")]
            [Display(Name = "Hire Date")]
            public DateTime HireDate { get; set; } = DateTime.Now;

            [Range(0, 100_000)]
            public double Salary { get; set; }


            public Patient ToPatient()
            {
                return new Patient
                {
                    Name = Name,
                    HireDate = HireDate,
                    Salary = Salary
                };
            }
        }
    }