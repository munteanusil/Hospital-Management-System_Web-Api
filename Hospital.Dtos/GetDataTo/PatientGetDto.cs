using Hospital_Management_System_Web_Api.RequiredData.PostDataTo;

namespace Hospital_Management_System_Web_Api.RequiredData.GetDataTo
{
    public class PatientGetDto : PatientPostDto
    {
        public Guid Id { get; set; }
    }
}
