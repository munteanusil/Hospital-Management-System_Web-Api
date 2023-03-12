using AutoMapper;
using Hospital_Management_System_Web_Api.Entities;
using Hospital_Management_System_Web_Api.Hospital.Repository.UnitofWork;
using Hospital_Management_System_Web_Api.Hospital.Services.DataServices.Contracts;
using Hospital_Management_System_Web_Api.RequiredData.GetDataTo;
using Hospital_Management_System_Web_Api.RequiredData.PostDataTo;

namespace Hospital_Management_System_Web_Api.Hospital.Services.DataServices.Implementations
{
        public class PatientsService : IPatientsService
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public PatientsService(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public GetResponse<PatientGetDto> Get(int? skip, int? take, string filter, bool includeDeleted)
            {
                var result = _unitOfWork.PatientsRepository.Get();

                var totalCount = result.Count();

                if (filter != null)
                {
                    result = result.Where(x => x.Name.Contains(filter) || x.Username.Contains(filter) || x.Email.Contains(filter) || x.Address.Contains(filter) || x.Phone.Contains(filter));
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

                var response = new GetResponse<PatientGetDto>
                {
                    ItemsCount = $"{currentCount} of {totalCount}",
                    Items = result.Select(x => _mapper.Map<PatientGetDto>(x))
                };

                return response;
            }

            public GetResponse<AppointmentGetDto> GetPatientAppointments(Guid id, int? skip, int? take, string filter, bool includeDeleted)
            {
                var result = _unitOfWork.AppointmentsRepository.Get(filter: f => f.PatientId == id);

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

            public GetResponse<MedicalReportGetDto> GetPatientMedicalReports(Guid id, int? skip, int? take, string filter, bool includeDeleted)
            {
                var result = _unitOfWork.MedicalReportsRepository.Get(include: i => i.Include(x => x.Appointment).ThenInclude(x => x.Doctor),
                                                                             filter: f => f.Appointment.PatientId == id);

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

            public async Task<PatientGetDto> GetByIdAsync(Guid? Id)
            {
                var result = await _unitOfWork.PatientsRepository.SingleOrDefaultAsync(filter: f => f.Id == Id);
                return _mapper.Map<PatientGetDto>(result);
            }

            public async Task UpdateAsync(PatientPostDto item, Guid Id)
            {
                Patient entity = await _unitOfWork.PatientsRepository.SingleOrDefaultAsync(filter: f => f.Id == Id);
                _mapper.Map(item, entity);
                _unitOfWork.PatientsRepository.Update(entity);
                await _unitOfWork.SaveAsync();
            }

            public async Task DeleteAsync(Guid? Id)
            {
                var entity = await _unitOfWork.PatientsRepository.SingleOrDefaultAsync(filter: f => f.Id == Id);
                _unitOfWork.PatientsRepository.Delete(entity);
                await _unitOfWork.SaveAsync();
            }
        }
    }

