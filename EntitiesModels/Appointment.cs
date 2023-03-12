using Hospital_Management_System_Web_Api.EntitiesModels;
using Hospital_Management_System_Web_Api.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_Management_System_Web_Api.Entities
{
    public class Appointment : IBaseEntity
    {
        [Key]
        public Guid AppointmentId { get; set;}

        [ForeignKey("DoctordID")]
        public Doctor Doctor { get; set;}
       
        public string AppointmentName { get; set;}

        public Guid PatientId { get; set; }

        public Patient PatientName { get; set; }
       
        public Doctor DoctorName { get; set;}

        public PatientExamination Examination { get; set;}

        public MedicalReport MedicalReport { get; set;}

        public string Summary { get; set;}

        public DateTimeOffset Date { get; set; }
        public Guid Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTimeOffset CreatedAt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTimeOffset UpdatedAt { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsDeleted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
