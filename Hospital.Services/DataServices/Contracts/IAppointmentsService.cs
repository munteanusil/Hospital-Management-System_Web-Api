using Hospital_Management_System_Web_Api.RequiredData.GetDataTo;
using Hospital_Management_System_Web_Api.RequiredData.PostDataTo;

namespace Hospital_Management_System_Web_Api.Hospital.Services.DataServices.Contracts
{
    public interface IAppointmentsService
    {
        GetResponse<AppointmentGetDto> Get(int? skip, int? take, DateTimeOffset? startDate, DateTimeOffset? endDate, string filter, bool includeDeleted);
        Task<AppointmentGetDto> GetByIdAsync(Guid? Id);
        Task<AppointmentPostDto> AddAsync(AppointmentPostDto item);
        Task UpdateAsync(AppointmentPostDto item, Guid Id);
        Task DeleteAsync(Guid? Id);
    }
}
