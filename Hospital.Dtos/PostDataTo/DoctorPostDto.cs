namespace Hospital_Management_System_Web_Api.RequiredData.PostDataTo
{
    public class DoctorPostDto
    {
            public string Name { get; set; }
            public string Username { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string Phone { get; set; }
            public IEnumerable<DoctorSpecialtyPostDto> DoctorSpecialties { get; set; }
        
    }
}
