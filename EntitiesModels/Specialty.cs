using Hospital_Management_System_Web_Api.EntitiesModels;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_Management_System_Web_Api.Entities
{
    public class Specialty : BaseEntity
    {
        public Specialty()
        {
            DoctorSpecialites = new HashSet<DoctorSpecialty>();
        }

        public string SpecialtyName { get; set; }

        [ForeignKey("SpecialtyId")]
        public DoctorSpecialty SpecialtyId { get; set;  }

        public string AgeRange { get; set; }
        //age range in which he practiced as a doctor

        public string PhysicalTherapy { get; set; }
        public string Cardiology { get; set; }
        public string Laboratory { get; set; }
       
        public bool Surgical { get; set; }
        //here you can say more about the doctor's specialization and his experience in surgery

        public bool Therapeutic { get; set; }

        public Guid MainSpecialtyId { get; set; }

        public Specialty MainSpecialty { get; set; }

        public ICollection<DoctorSpecialty> DoctorSpecialites { get; set;}


    } 
    }

