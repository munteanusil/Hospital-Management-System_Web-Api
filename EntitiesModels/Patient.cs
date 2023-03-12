using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_System_Web_Api.Entities
{
    public class Patient
    {
      public Patient()
        {
            Appointments = new HashSet<Appointment>();
        }
        [Key]
        public string PatientId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }

        public string Email { get; set; }   

        public byte[] PasswordHash { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Gender { get; set; }

        public DateTimeOffset DateOfBirth { get; set; }

        //If you need to store birthdays with a specific date and time, along with the time zone offset,
        //then you should use a DateTimeOffset in C#. 
        public string MedicalHistory { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public byte[] PasswordSalt { get; internal set; }
        //Collection navigation property: A navigation property that contains references to many related entities.

        //This table is an independent entity/principal entity, also called core, they are the backbone of the database.
        //These tables are what other tables are based on. 

    }
}
