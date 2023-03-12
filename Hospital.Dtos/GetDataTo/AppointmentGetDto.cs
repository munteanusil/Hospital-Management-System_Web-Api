
using Hospital_Management_System_Web_Api.RequiredData.PostDataTo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hospital_Management_System_Web_Api.RequiredData.GetDataTo
{
    public class AppointmentGetDto : AppointmentPostDto
    {
        public Guid Id { get; set; }

        //This class will return to the front end the ID code  generated for the programming appearing in the database
    }
}
