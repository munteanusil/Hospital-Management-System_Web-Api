using Hospital_Management_System_Web_Api.Abstractions;
using Hospital_Management_System_Web_Api.EntitiesModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_Management_System_Web_Api.EntitiesModels
{
    public class DoctorSpecialty : BaseEntity
    {
        [Key]
        public Guid SpecialityId { get; set; }

        [ForeignKey("DoctordID")]
        public Doctor DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public Specialty Specialty { get; set; }

        public Specialty NameSpeciality { get; set; }
        public string[] Licenses { get; set; }

        public byte[] DoctorCertification { get; set; }

       
        public byte[] DoctorResume { get; set; }

        public string YearsOfExperience { get; set; }

        public string Linces { get; set; }

        public string AcdemicQualification { get; set; }

        public string Work { get; set; }

        public string Training { get; set; }

        public ICollection<DoctorSpecialty> DoctorSpecialties { get; set; }
        public ICollection<DoctorPortofolio> ClinicalCase { get; set; }
       
    
    }
}
