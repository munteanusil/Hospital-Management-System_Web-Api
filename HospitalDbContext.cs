using Hospital_Management_System_Web_Api.Entities;
using Hospital_Management_System_Web_Api.EntitiesModels;
using Hospital_Management_System_Web_Api.Interface;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System_Web_Api
{
    public class HospitalDbContext : DbContext
    {
        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options)
        { }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<MedicalReport> MedicalReports { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<DoctorSpecialty> DoctorSpecialties { get; set; }

        public DbSet<DoctorPortofolio> doctorPortofolio { get; set; }

        public DbSet<Patient_Visits> patient_visits { get; set; }

        public DbSet<PatientExamination> patientExaminations { get; set; }

        public DbSet<Specialty> specialties { get; set; }

        public DbSet<Treatment> treatment { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>()
                .HasOne<MedicalReport>(a => a.MedicalReport)
                .WithOne(m => m.Appointment)
                .HasForeignKey<MedicalReport>(m => m.AppointmentId)
                .HasConstraintName("FK_Appointment_MedicalReport");

            modelBuilder.Entity<Doctor>()
                .HasMany<Appointment>(d => d.Appointments)
                .WithOne(a => a.DoctorName)
                .HasForeignKey(a => a.Doctor)
                .HasConstraintName("FK_Doctor_Appointments");

            modelBuilder.Entity<Patient>()
                .HasMany<Appointment>(p => p.Appointments)
                .WithOne(a => a.PatientName)
                .HasForeignKey(a => a.PatientId)
                .HasConstraintName("FK_Patient_Appointments");


            modelBuilder.Entity<DoctorSpecialty>()
                .HasOne<Doctor>(ds => ds.Doctor)
                .WithMany(d => d.DoctorSpeciality)
                .HasForeignKey(ds => ds.DoctorId)
                .HasConstraintName("FK_Doctor_DoctorSpecialties");

            modelBuilder.Entity<DoctorSpecialty>()
                .HasOne<Specialty>(ds => ds.NameSpeciality)
                .WithMany(s => s.DoctorSpecialites)
                .HasForeignKey(ds => ds.SpecialityId)
                .HasConstraintName("FK_Specialty_Doctorspecialties");
        }

        ////https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-operator
            ///

              public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AddAuditInfo();

            return await base.SaveChangesAsync(cancellationToken);
        }
        private void AddAuditInfo()
        {
            var entities = ChangeTracker.Entries<IBaseEntity>().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            var utcNow = DateTimeOffset.UtcNow;

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    entity.Entity.CreatedAt = utcNow;
                }
                
                if (entity.State == EntityState.Modified)
                {
                    entity.Entity.UpdatedAt = utcNow;
                }
            }

        }
    
    }
}
