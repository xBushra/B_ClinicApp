using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicApp.Models
{

    [Table("PatientSpecialities")]
    [PrimaryKey(nameof(PatientId), nameof(SpecialityId))]
    public class PatientSpeciality
    {
        public int PatientId { get; set; }
        public int SpecialityId { get; set; }


    }
}