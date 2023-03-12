using Hospital_Management_System_Web_Api.Entities;

namespace Hospital_Management_System_Web_Api.Hospital.Repository.Repositories.Contracts
{
    public interface IDoctorsRepository : IBaseRepository<Doctor>
    { 
        Task<Doctor> RegisterAsync(Doctor entity, byte[] passwordHash, byte[] passwordSalt);
    }
}

