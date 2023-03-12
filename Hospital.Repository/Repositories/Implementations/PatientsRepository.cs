using Hospital_Management_System_Web_Api.Entities;
using Hospital_Management_System_Web_Api.Hospital.Repository.Repositories.Contracts;

namespace Hospital_Management_System_Web_Api.Hospital.Repository.Repositories.Implementations
{
    public class PatientsRepository : BaseRepository<Patient>, IPatientsRepository
    {
        public PatientsRepository(HospitalDbContext context) : base(context)
        {

        }

        public async Task<Patient> RegisterAsync(Patient entity, byte[] passwordHash, byte[] passwordSalt)
        {
            entity.PasswordHash = passwordHash;
            entity.PasswordSalt = passwordSalt;

            var result = await _dbSet.AddAsync(entity);

            return result.Entity;
        }
    }
}
