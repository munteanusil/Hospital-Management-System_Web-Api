using Hospital_Management_System_Web_Api.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_Management_System_Web_Api.EntitiesModels
{
    public class DoctorPortofolio
    {
        [Key]
        public string DoctorPortofolioId { get; set;}

        [ForeignKey("DoctordID")]
        public string DoctorID { get; set;}

        public string DescriptionofCase { get; set;}

        public PatientExamination Symptoms { get; set;}

        public bool Surgery { get; set;}

        public string DescriptionOfSurgery { get; set;}

        public string BestPractice { get; set;}

    }
}
