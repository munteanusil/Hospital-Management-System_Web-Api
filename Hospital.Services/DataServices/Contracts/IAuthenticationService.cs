using Hospital_Management_System_Web_Api.RequiredData.PostDataTo;

namespace Hospital_Management_System_Web_Api.Hospital.Services.DataServices.Contracts
{
    public interface IAuthenticationService
    {
        Task<DoctorPostDto> RegisterAsync(DoctorPostDto item);
        Task<PatientPostDto> RegisterAsync(PatientPostDto item);
        Task<string> DoctorLoginAsync(LoginPostDto item);
        Task<string> PatientLoginAsync(LoginPostDto item);
    }
}
