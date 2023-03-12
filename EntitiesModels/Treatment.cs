using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_Management_System_Web_Api.Entities
{
    public class Treatment
    {
        [Key]
        public string TreatmentId { get; set;}
        [ForeignKey("Patient")]
        public Patient PatientId { get; set; }

        [ForeignKey("PatientName")]
        public Patient PatientName { get; set;}

        [ForeignKey("Examination")]
        public PatientExamination ExaminationID { get; set; }

        [ForeignKey("Doctor")]
        public Doctor DoctorId { get; set; }

        public string Remarks { get; set; }

        //This table represents a dependent entity, having two foreign keys and its meaning is linked to other tables.
    }
}
