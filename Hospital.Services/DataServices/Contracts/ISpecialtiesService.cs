using Hospital_Management_System_Web_Api.RequiredData.GetDataTo;
using Hospital_Management_System_Web_Api.RequiredData.PostDataTo;

namespace Hospital_Management_System_Web_Api.Hospital.Services.DataServices.Contracts
{
    public interface ISpecialtiesService
    {
        Task<SpecialtyPostDto> AddAsync(SpecialtyPostDto item);
        Task DeleteAsync(Guid? Id);
        GetResponse<SpecialtyGetDto> Get(int? skip, int? take, string filter, bool includeDeleted);
        Task<SpecialtyGetDto> GetByIdAsync(Guid? Id);
        Task UpdateAsync(SpecialtyPostDto item, Guid Id);
    }
}
