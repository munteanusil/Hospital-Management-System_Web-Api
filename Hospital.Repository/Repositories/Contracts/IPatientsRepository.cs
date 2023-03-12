using Hospital_Management_System_Web_Api.Entities;

namespace Hospital_Management_System_Web_Api.Hospital.Repository.Repositories.Contracts
{
    public interface IPatientsRepository : IBaseRepository<Patient>
    {
        Task<Patient> RegisterAsync(Patient entity, byte[] passwordHash, byte[] passwordSalt);
    }
}
