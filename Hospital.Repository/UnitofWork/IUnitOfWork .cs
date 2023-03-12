using Hospital_Management_System_Web_Api.Hospital.Repository.Repositories.Contracts;
using System;
using System.Threading.Tasks;
namespace Hospital_Management_System_Web_Api.Hospital.Repository.UnitofWork
{
    public interface IUnitOfWork : IDisposable
    {
        public IAppointmentsRepository AppointmentsRepository { get; }
        public IDoctorsRepository DoctorsRepository { get; }
        public IMedicalReportsRepository MedicalReportsRepository { get; }
        public IPatientsRepository PatientsRepository { get; }
        public ISpecialtiesRepository SpecialtiesRepository { get; }
        public IDoctorSpecialtiesRepository DoctorSpecialtiesRepository { get; }

        public Task BeginTransactionAsync();

        public Task CommitTransactionAsync();
        public Task RollBackTransactionAsync();
        public Task SaveAsync();
    }
}
