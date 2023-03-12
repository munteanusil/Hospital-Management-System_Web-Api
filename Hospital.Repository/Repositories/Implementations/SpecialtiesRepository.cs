using Hospital_Management_System_Web_Api.Entities;
using Hospital_Management_System_Web_Api.Hospital.Repository.Repositories.Contracts;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Hospital_Management_System_Web_Api.Hospital.Repository.Repositories.Implementations
{
        public class SpecialtiesRepository : BaseRepository<Specialty>, ISpecialtiesRepository
        {
            public SpecialtiesRepository(HospitalDbContext context) : base(context)
            {

            }
        }
    }



