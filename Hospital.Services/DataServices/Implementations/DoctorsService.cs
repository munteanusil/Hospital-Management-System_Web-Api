using AutoMapper;
using Hospital_Management_System_Web_Api.Entities;
using Hospital_Management_System_Web_Api.Hospital.Repository.UnitofWork;
using Hospital_Management_System_Web_Api.Hospital.Services.DataServices.Contracts;
using Hospital_Management_System_Web_Api.RequiredData.GetDataTo;
using Hospital_Management_System_Web_Api.RequiredData.PostDataTo;

namespace Hospital_Management_System_Web_Api.Hospital.Services.DataServices.Implementations
{
    public class DoctorsService : IDoctorsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DoctorsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public GetResponse<DoctorGetDto> Get(int? skip, int? take, string filter, bool includeDeleted)
        {
            var result = _unitOfWork.DoctorsRepository.Get();

            var totalCount = result.Count();

            if (filter != null)
            {
                result = result.Where(x => x.Name.Contains(filter) || x.Username.Contains(filter) || x.Email.Contains(filter) || x.Phone.Contains(filter));
            }

            if (!includeDeleted)
            {
                result = result.Where(x => x.IsDeleted == includeDeleted);
            }

            if (skip.HasValue)
            {
                result = result.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                result = result.Take(take.Value);
            }

            var currentCount = result.Count();

            var response = new GetResponse<DoctorGetDto>
            {
                ItemsCount = $"{currentCount} of {totalCount}",
                Items = result.Select(x => _mapper.Map<DoctorGetDto>(x))
            };

            return response;
        }

        public GetResponse<MedicalReportGetDto> GetDoctorMedicalReports(Guid id, int? skip, int? take, string filter, bool includeDeleted)
        {
            var result = _unitOfWork.MedicalReportsRepository.Get(include: i => i.Include(x => x.Appointment),
                                                                   filter: f => f.Appointment.Doctor == id);

            var totalCount = result.Count();

            if (filter != null)
            {
                result = result.Where(x => x.InvestigationsMade.Contains(filter) || x.Findings.Contains(filter) || x.Diagnosis.Contains(filter) || x.Treatment.Contains(filter));
            }

            if (!includeDeleted)
            {
                result = result.Where(x => x.IsDeleted == includeDeleted);
            }

            if (skip.HasValue)
            {
                result = result.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                result = result.Take(take.Value);
            }

            var currentCount = result.Count();

            var response = new GetResponse<MedicalReportGetDto>
            {
                ItemsCount = $"{currentCount} of {totalCount}",
                Items = result.Select(x => _mapper.Map<MedicalReportGetDto>(x))
            };

            return response;
        }

        public GetResponse<SpecialtyGetDto> GetDoctorSpecialties(Guid id, int? skip, int? take, string filter, bool includeDeleted)
        {
            var doctorSpecialties = _unitOfWork.DoctorSpecialtiesRepository.Get(include: i => i.Include(x => x.Specialty),
                                                                                 filter: f => f.Id == id);

            var result = doctorSpecialties.Select(s => s.Specialty);

            var totalCount = result.Count();

            if (filter != null)
            {
                if (filter.Equals("Surgical", StringComparison.OrdinalIgnoreCase))
                {
                    result = result.Where(x => x.Surgical == true);
                }
                else if (filter.Equals("Therapeutic", StringComparison.OrdinalIgnoreCase))
                {
                    result = result.Where(x => x.Therapeutic == true);
                }
                else
                {
                    result = result.Where(x => x.Name.Contains(filter));
                }
            }

            if (!includeDeleted)
            {
                result = result.Where(x => x.IsDeleted == includeDeleted);
            }

            if (skip.HasValue)
            {
                result = result.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                result = result.Take(take.Value);
            }

            var currentCount = result.Count();

            var response = new GetResponse<SpecialtyGetDto>
            {
                ItemsCount = $"{currentCount} of {totalCount}",
                Items = result.Select(x => _mapper.Map<SpecialtyGetDto>(x))
            };

            return response;
        }

        public GetResponse<AppointmentGetDto> GetDoctorAppointments(Guid id, int? skip, int? take, string filter, bool includeDeleted)
        {
            var result = _unitOfWork.AppointmentsRepository.Get(filter: f => f.Doctor == id);

            var totalCount = result.Count();

            if (filter != null)
            {
                result = result.Where(x => x.Symptoms.Contains(filter));
            }

            if (!includeDeleted)
            {
                result = result.Where(x => x.IsDeleted == includeDeleted);
            }

            if (skip.HasValue)
            {
                result = result.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                result = result.Take(take.Value);
            }

            var currentCount = result.Count();

            var response = new GetResponse<AppointmentGetDto>
            {
                ItemsCount = $"{currentCount} of {totalCount}",
                Items = result.Select(x => _mapper.Map<AppointmentGetDto>(x))
            };

            return response;
        }

        public async Task<DoctorGetDto> GetByIdAsync(Guid? Id)
        {
            var result = await _unitOfWork.DoctorsRepository.SingleOrDefaultAsync(filter: f => f.Id == Id);
            return _mapper.Map<DoctorGetDto>(result);
        }

        public async Task UpdateAsync(DoctorPostDto item, Guid Id)
        {
            Doctor entity = await _unitOfWork.DoctorsRepository.SingleOrDefaultAsync(filter: f => f.Id == Id);
            _mapper.Map(item, entity);
            _unitOfWork.DoctorsRepository.Update(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(Guid? Id)
        {
            var entity = await _unitOfWork.DoctorsRepository.SingleOrDefaultAsync(include: i => i.Include(x => x.DoctorSpecialties),
                                                                                   filter: f => f.Id == Id);

            foreach (var doctorSpecialty in entity.DoctorSpecialties)
            {
                doctorSpecialty.IsDeleted = true;
            }

            _unitOfWork.DoctorsRepository.Delete(entity);
            await _unitOfWork.SaveAsync();
        }

        public GetResponse<DoctorGetDto> Get(int? skip, string filter, bool includeDeleted)
        {
            throw new NotImplementedException();
        }

        public GetResponse<MedicalReportGetDto> GetDoctorMedicalRepoerts(Guid id, int? skip, int? take, string filter, bool includeDeleted)
        {
            throw new NotImplementedException();
        }
    }
}

