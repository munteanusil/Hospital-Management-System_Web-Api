using Microsoft.EntityFrameworkCore.Storage;
using Hospital_Management_System_Web_Api.Hospital.Repository.Repositories.Contracts;
using Hospital_Management_System_Web_Api.Hospital.Repository.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hospital_Management_System_Web_Api.Hospital.Repository.UnitofWork
{
    public abstract class UnitOfWork : IUnitOfWork
    {
        readonly HospitalDbContext _context;
        public IAppointmentsRepository AppointmentsRepository { get; private set; }
        public IDoctorsRepository DoctorsRepository { get; private set; }
        public IMedicalReportsRepository MedicalReportsRepository { get; private set; }
        public IPatientsRepository PatientsRepository { get; private set; }
        public ISpecialtiesRepository SpecialtiesRepository { get; private set; }
        public IDoctorSpecialtiesRepository DoctorSpecialtiesRepository { get; private set; }

        IDbContextTransaction _transaction;

        public UnitOfWork(HospitalDbContext context)
        {
            _context = context;
            AppointmentsRepository = new AppointmentsRepository(context);
            DoctorsRepository = new DoctorsRepository(context);
            MedicalReportsRepository = new MedicalReportsRepository(context);
            PatientsRepository = new PatientsRepository(context);
            SpecialtiesRepository = new SpecialtiesRepository(context);
            DoctorSpecialtiesRepository = new DoctorSpecialtiesRepository(context);
        }

        public async Task BeginTransactionAsync()
        {
            if (_transaction == null)
            {
                _transaction = await _context.Database.BeginTransactionAsync();
            }
            else
            {
                throw new Exception("Transaction already in progress");
            }
        }

        public async Task CommitTransactionAsync()
        {
            if (_transaction == null)
            {
                throw new Exception("No transaction to commit");
            }

            await _transaction.CommitAsync();
            await _transaction.DisposeAsync();
        }

        public async Task RollBackTransactionAsync()
        {
            if (_transaction == null)
            {
                throw new Exception("no transaction to rollback");
            }

            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            AppointmentsRepository?.Dispose();
            DoctorsRepository?.Dispose();
            MedicalReportsRepository?.Dispose();
            PatientsRepository?.Dispose();
            SpecialtiesRepository?.Dispose();
        }
    }
}

