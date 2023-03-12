using Hospital_Management_System_Web_Api.RequiredData.GetDataTo;
using Hospital_Management_System_Web_Api.RequiredData.PostDataTo;

namespace Hospital_Management_System_Web_Api.Hospital.Services.DataServices.Contracts
{
    public interface IPatientsService
    {
        Task DeleteAsync(Guid? Id);
        GetResponse<PatientGetDto> Get(int? skip, int? take, string filter, bool includeDeleted);
        GetResponse<AppointmentGetDto> GetPatientAppointments(Guid id, int? skip, int? take, string filter, bool includeDeleted);
        public GetResponse<MedicalReportGetDto> GetPatientMedicalReports(Guid id, int? skip, int? take, string filter, bool includeDeleted);
        Task<PatientGetDto> GetByIdAsync(Guid? Id);
        Task UpdateAsync(PatientPostDto item, Guid Id);
    }
}
