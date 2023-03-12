using Hospital_Management_System_Web_Api.Entities;
using Hospital_Management_System_Web_Api.EntitiesModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_Management_System_Web_Api.RequiredData.PostDataTo
{
    public class SpecialtyPostDto
    {
        public string SpecialtyName { get; set; }

        public string AgeRange { get; set; }
        

        public string PhysicalTherapy { get; set; }
        public string Cardiology { get; set; }
        public string Laboratory { get; set; }

        public string Surgical { get; set; }
        
        public bool Therapeutic { get; set; }

        public Guid MainSpecialtyId { get; set; }

        public Specialty MainSpecialty { get; set; }
    }
}
