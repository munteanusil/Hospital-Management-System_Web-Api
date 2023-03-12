using Hospital_Management_System_Web_Api.RequiredData.GetDataTo;
using Hospital_Management_System_Web_Api.RequiredData.PostDataTo;

namespace Hospital_Management_System_Web_Api.Hospital.Services.DataServices.Contracts
{
    public interface IMedicalReportsService
    {
        Task<MedicalReportPostDto> AddAsync(MedicalReportPostDto item);
        Task DeleteAsync(Guid? Id);
        GetResponse<MedicalReportGetDto> Get(int? skip, int? take, DateTimeOffset? startDate, DateTimeOffset? endDate, string filter, bool includeDeleted);
        Task<MedicalReportGetDto> GetByIdAsync(Guid? Id);
        Task UpdateAsync(MedicalReportPostDto item, Guid Id);
    }
}
