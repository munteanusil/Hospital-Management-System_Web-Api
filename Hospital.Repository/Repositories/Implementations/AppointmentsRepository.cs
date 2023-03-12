using Hospital_Management_System_Web_Api.EntitiesModels;
using Hospital_Management_System_Web_Api.Hospital.Repository.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using Hospital_Management_System_Web_Api.Entities;
using Hospital_Management_System_Web_Api.Hospital.Repository.UnitofWork;

namespace Hospital_Management_System_Web_Api.Hospital.Repository.Repositories.Implementations
{
    public class AppointmentsRepository : BaseRepository<Appointment>, IAppointmentsRepository
    {
        public AppointmentsRepository(HospitalDbContext context) : base(context)
        {

        }
    }
}
