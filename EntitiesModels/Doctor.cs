using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Hospital_Management_System_Web_Api.EntitiesModels;
using Hospital_Management_System_Web_Api.Interface;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Hospital_Management_System_Web_Api.Entities
{
    public class Doctor : BaseEntity
    {
        [Key]
        public string DoctorId { get; set; }   
        public string DoctorName { get; set; }
        public string Username { get; set; }    
        public byte [] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set;}
          
        public string PhoneNumber { get; set; }
      
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<DoctorSpecialty> DoctorSpeciality { get; set;}
      
        //https://www.techtarget.com/searchsecurity/definition/salt*/*/
        //when a password is hashed and stored as a byte array, it is often more secure and resistant to attacks,
        //as the hash function will produce a unique and fixed-length output, which makes it more difficult for an
        //attacker to reverse-engineer the original password.

        //This table is an independent entity/principal entity, also called core, they are the backbone of the database.
        //These tables are what other tables are based on. 

    }
}
