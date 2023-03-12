using Hospital_Management_System_Web_Api.Entities;
using Hospital_Management_System_Web_Api.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_Management_System_Web_Api.EntitiesModels
{
    public class DoctorSpecialty : IBaseEntity
    {
        [Key]
        public Guid SpecialityId { get; set; }

        [ForeignKey("DoctordID")]
        public Doctor DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public DoctorSpecialty DoctorSpecialities { get; set; }

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
        public Guid Id { get => ((IBaseEntity)DoctorSpecialities).Id; set => ((IBaseEntity)DoctorSpecialities).Id = value; }
        public DateTimeOffset CreatedAt { get => ((IBaseEntity)DoctorSpecialities).CreatedAt; set => ((IBaseEntity)DoctorSpecialities).CreatedAt = value; }
        public DateTimeOffset UpdatedAt { get => ((IBaseEntity)DoctorSpecialities).UpdatedAt; set => ((IBaseEntity)DoctorSpecialities).UpdatedAt = value; }
        public bool IsDeleted { get => ((IBaseEntity)DoctorSpecialities).IsDeleted; set => ((IBaseEntity)DoctorSpecialities).IsDeleted = value; }
    }
}
