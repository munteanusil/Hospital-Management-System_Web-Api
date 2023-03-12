using Hospital_Management_System_Web_Api.EntitiesModels;
using Hospital_Management_System_Web_Api.Hospital.Repository.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System_Web_Api.Hospital.Repository.Repositories.Implementations
{
    public class DoctorSpecialtiesRepository : BaseRepository<DoctorSpecialty>, IDoctorSpecialtiesRepository
    {
        public DoctorSpecialtiesRepository(HospitalDbContext context) : base(context)
        {

        }
    }
}
