using Hospital_Management_System_Web_Api.EntitiesModels;
using Hospital_Management_System_Web_Api.Hospital.Repository.Repositories.Contracts;
using Hospital_Management_System_Web_Api.Hospital.Repository.UnitofWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hospital_Management_System_Web_Api.Hospital.Repository.Repositories.Implementations
{
    public class MedicalReportsRepository : BaseRepository<MedicalReport>, IMedicalReportsRepository
    {
        public MedicalReportsRepository(HospitalDbContext context) : base(context)
        {

        }
    }
}
