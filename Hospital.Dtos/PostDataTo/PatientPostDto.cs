namespace Hospital_Management_System_Web_Api.RequiredData.PostDataTo
{
    public class PatientPostDto
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public string MedicalHistory { get; set; }
    }
}
