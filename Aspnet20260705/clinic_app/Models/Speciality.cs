
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp.Models
{
    public class Speciality
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;


        public List<Patient> Patients { get; set; } = null!;
    }
}