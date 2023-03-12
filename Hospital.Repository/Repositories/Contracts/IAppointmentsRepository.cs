using Hospital_Management_System_Web_Api.Entities;
using Hospital_Management_System_Web_Api.Hospital.Repository.Repositories.Implementations;

namespace Hospital_Management_System_Web_Api.Hospital.Repository.Repositories.Contracts
{
    public interface IAppointmentsRepository : IBaseRepository<Appointment>
    {
        public void Dispose()
        {

        }
    }
}
