using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_Management_System_Web_Api.Entities
{
    public class Patient_Visits
    {
        [Key]
        public string VisitatorId { get; set; }
        public string VisitatorName { get; set; }

        [ForeignKey("Patient")]
        public Patient PatientId { get; set; }

        [ForeignKey("PatientName")]
        public Patient PatientName { get; set; }
        public DateTimeOffset VisitDate { get; set; }

        public int NumberVisits { get; set; }
        // This table represents a dependent entity, having two foreign keys and its meaning is linked to other tables.
        //The foreign key in this table refers to the primary key in the "Patient" table.
        //The relationship implemented between the two tables is one to many because a patient can have several visits.
    }
}
