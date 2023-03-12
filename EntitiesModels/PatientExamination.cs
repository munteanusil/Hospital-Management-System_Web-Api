using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_Management_System_Web_Api.Entities
{
    public class PatientExamination
    {
        [Key]
        public string ExaminationID{get; set;}

        [ForeignKey("Patient")]
        public Patient PatientId { get; set;}

        public string Symptoms { get; set; }

        public string Result { get; set;}


    }
}
