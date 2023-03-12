using CsvHelper;
using Hospital_Management_System_Web_Api.Entities;
using Hospital_Management_System_Web_Api.Interface;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Hospital_Management_System_Web_Api.EntitiesModels
{
    public class MedicalReport : BaseEntity
    {
        public string InvestigationMade { get; set; }
        public string Findigns { get; set; }

        public string Diagnosis { get; set; }
        //the diagnosis is based on several results obtained from examinations
        [ForeignKey("Treatment")]
        public Treatment TreatmentId { get; set; }

        [ForeignKey("Appointment")]
        public Guid AppointmentId { get; set; }

        public Appointment Appointment { get; set; }





    }
}
