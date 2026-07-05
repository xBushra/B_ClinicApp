using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.ClinicModels {
    public class Doctor {
        
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public DateTime HireDate { get; set; }

        public double Salary { get; set; }

    }
}
