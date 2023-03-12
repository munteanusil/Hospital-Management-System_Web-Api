using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital_Management_System_Web_Api.Entities;
using Hospital_Management_System_Web_Api.Hospital.Repository.Repositories.Contracts;

namespace Hospital_Management_System_Web_Api.Hospital.Repository.Repositories.Implementations
{
    public class DoctorsRepository : BaseRepository<Doctor>, IDoctorsRepository
    {
        public DoctorsRepository(HospitalDbContext context) : base(context)
        {

        }

        public async Task<Doctor> RegisterAsync(Doctor entity, byte[] passwordHash, byte[] passwordSalt)
        {
            entity.PasswordHash = passwordHash;
            entity.PasswordSalt = passwordSalt;

            var result = await _dbSet.AddAsync(entity);

            return result.Entity;
        }
    }
}
