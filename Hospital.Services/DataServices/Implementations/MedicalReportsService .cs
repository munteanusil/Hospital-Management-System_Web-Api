using AutoMapper;
using Hospital_Management_System_Web_Api.EntitiesModels;
using Hospital_Management_System_Web_Api.Hospital.Repository.UnitofWork;
using Hospital_Management_System_Web_Api.Hospital.Services.DataServices.Contracts;
using Hospital_Management_System_Web_Api.RequiredData.GetDataTo;
using Hospital_Management_System_Web_Api.RequiredData.PostDataTo;

namespace Hospital_Management_System_Web_Api.Hospital.Services.DataServices.Implementations
{
    public class MedicalReportsService : IMedicalReportsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MedicalReportsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public GetResponse<MedicalReportGetDto> Get(int? skip, int? take, DateTimeOffset? startDate, DateTimeOffset? endDate, string filter, bool includeDeleted)
        {
            var result = _unitOfWork.MedicalReportsRepository.Get(include: i => i.Include(x => x.Appointment));

            var totalCount = result.Count();

            if (filter != null)
            {
                result = result.Where(x => x.InvestigationsMade.Contains(filter) || x.Findings.Contains(filter) || x.Diagnosis.Contains(filter) || x.Treatment.Contains(filter));
            }

            if (!includeDeleted)
            {
                result = result.Where(x => x.IsDeleted == includeDeleted);
            }

            if (startDate.HasValue)
            {
                result = result.Where(x => x.Appointment.Date >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                result = result.Where(x => x.Appointment.Date <= endDate.Value);
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

        public async Task<MedicalReportGetDto> GetByIdAsync(Guid? Id)
        {
            var result = await _unitOfWork.MedicalReportsRepository.SingleOrDefaultAsync(filter: f => f.Id == Id);
            return _mapper.Map<MedicalReportGetDto>(result);
        }

        public async Task<MedicalReportPostDto> AddAsync(MedicalReportPostDto item)
        {
            MedicalReport entity = _mapper.Map<MedicalReport>(item);
            MedicalReport result = await _unitOfWork.MedicalReportsRepository.InsertAsync(entity);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<MedicalReportPostDto>(result);
        }

        public async Task UpdateAsync(MedicalReportPostDto item, Guid Id)
        {
            MedicalReport entity = await _unitOfWork.MedicalReportsRepository.SingleOrDefaultAsync(filter: f => f.Id == Id);
            _mapper.Map(item, entity);
            _unitOfWork.MedicalReportsRepository.Update(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(Guid? Id)
        {
            var entity = await _unitOfWork.MedicalReportsRepository.SingleOrDefaultAsync(filter: f => f.Id == Id);
            _unitOfWork.MedicalReportsRepository.Delete(entity);
            await _unitOfWork.SaveAsync();
        }
    }
}

