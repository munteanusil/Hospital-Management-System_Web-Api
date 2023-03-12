using Hospital_Management_System_Web_Api.RequiredData.GetDataTo;
using Hospital_Management_System_Web_Api.RequiredData.PostDataTo;

namespace Hospital_Management_System_Web_Api.Hospital.Services.DataServices.Contracts
{
    public interface IDoctorsService
    {
        Task DeleteAsync(Guid? Id);
        GetResponse<DoctorGetDto> Get(int? skip, string filter, bool includeDeleted);
        GetResponse<MedicalReportGetDto> GetDoctorMedicalRepoerts(Guid id, int? skip, int? take, string filter, bool includeDeleted);
        GetResponse<AppointmentGetDto> GetDoctorAppointments(Guid id, int? skip, int? take, string filter, bool includeDeleted);
        GetResponse<SpecialtyGetDto> GetDoctorSpecialties(Guid id, int? skip, int? take, string filter, bool includeDeleted);
        Task<DoctorGetDto> GetByIdAsync(Guid? Id);
        Task UpdateAsync(DoctorPostDto item, Guid Id);

        //In C#.NET, the task is basically used to implement Asynchronous Programming i.e. executing operations asynchronously and it was introduced with . NET Framework 4.0.
    }


}
