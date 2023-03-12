using Hospital_Management_System_Web_Api.RequiredData.PostDataTo;

namespace Hospital_Management_System_Web_Api.RequiredData.GetDataTo
{
    public class MedicalReportGetDto : MedicalReportPostDto
    {
        public Guid Id { get; set; }
        public AppointmentGetDto Appointment { get; set; }
    }
}
