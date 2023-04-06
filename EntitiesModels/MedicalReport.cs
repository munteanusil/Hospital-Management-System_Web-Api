using CsvHelper;
using Hospital_Management_System_Web_Api.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Hospital_Management_System_Web_Api.EntitiesModels
{
    public class MedicalReport : BaseEntity
    {
        public string InvestigationsMade { get; set; }
        public string Findings { get; set; }

        public string Diagnosis { get; set; }
        //the diagnosis is based on several results obtained from examinations
        [ForeignKey("Treatment")]
        public Treatment TreatmentId { get; set; }

        public string Treatment { get; set; }

        [ForeignKey("Appointment")]
        public Guid AppointmentId { get; set; }

        public Appointment Appointment { get; set; }

        [ForeignKey("DoctorId")]
        public string DoctorId { get; set; }
       
    }
}
