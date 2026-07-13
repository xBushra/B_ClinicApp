using System;
using System.Collections.Generic;

namespace ClinicApp.Models
{
    public class Data
    {

        public static List<Patient> Patient { get; set; } = new List<Patient>() {
            new Patient
            {
                Id = 1,
                Name = "Ahmed Ali",
                HireDate = new DateTime(2020, 3, 15),
                Salary = 18000
            },
            new Patient
            {
                Id = 2,
                Name = "Sara Mohamed",
                HireDate = new DateTime(2019, 7, 10),
                Salary = 22000
            },
            new Patient
            {
                Id = 3,
                Name = "Khaled Hassan",
                HireDate = new DateTime(2021, 1, 5),
                Salary = 16500
            },
            new Patient
            {
                Id = 4,
                Name = "Mona Ibrahim",
                HireDate = new DateTime(2018, 11, 20),
                Salary = 25000
            },
            new Patient
            {
                Id = 5,
                Name = "Omar Salem",
                HireDate = new DateTime(2022, 6, 1),
                Salary = 14500
            }
        };
    }
}