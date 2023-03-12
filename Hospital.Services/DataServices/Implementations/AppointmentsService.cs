
using AutoMapper;
using Hospital_Management_System_Web_Api.Hospital.Services.DataServices.Contracts;
using Hospital_Management_System_Web_Api.Hospital.Repository.UnitofWork;
using Hospital_Management_System_Web_Api.RequiredData.GetDataTo;
using System.Text;
using Hospital_Management_System_Web_Api.RequiredData.PostDataTo;
using Hospital_Management_System_Web_Api.Entities;
using Hospital_Management_System_Web_Api.Hospital.Repository.Repositories.Implementations;
using System.Data.Entity;

namespace Hospital_Management_System_Web_Api.Hospital.Services.DataServices.Implementations
{
    public class AppointmentsService : IAppointmentsService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AppointmentsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public GetResponse<AppointmentGetDto> Get(int? skip, int? take, DateTimeOffset? startDate, DateTimeOffset? endDate, string filter, bool includeDeleted)
        {
            var result = _unitOfWork.AppointmentsRepository
                .Get(include: i => i.Include(a => a.Doctor)
                .Include(x => x.Patient));
            //Prin intermediul metodei "include" se specifică proprietățile Doctor și Patient ale entității de programare, astfel încât
            //să fie incluse în rezultat.
            var totalCount = result.Count();
            if (filter != null)
            {
                result = result.Where(x => x.Symptoms.Contains(filter));
            }
            if (!includeDeleted)
            {
                result = result.Where(x => x.IsDeleted == includeDeleted);
            }

            if (startDate.HasValue)
            {
                result = result.Where(x => x.Date >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                result = result.Where(x => x.Date <= endDate.Value);
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
        public async Task<AppointmentGetDto> GetByIdAsync(Guid? Id)
        {
            var result = await _unitOfWork.AppointmentsRepository.SingleOrDefaultAsync(filter: f => f.Id == Id);
            return _mapper.Map<AppointmentGetDto>(result);
        }

        public async Task<AppointmentPostDto> AddAsync(AppointmentPostDto item)
        {
            Appointment entity = _mapper.Map<Appointment>(item);
            Appointment result = await _unitOfWork.AppointmentsRepository.InsertAsync(entity);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<AppointmentPostDto>(result);
        }

        public async Task UpdateAsync(AppointmentPostDto item, Guid Id)
        {
            Appointment entity = await _unitOfWork.AppointmentsRepository.SingleOrDefaultAsync(filter: f => f.Id == Id);
            _mapper.Map(item, entity);
            _unitOfWork.AppointmentsRepository.Update(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(Guid? Id)
        {
            var entity = await _unitOfWork.AppointmentsRepository.SingleOrDefaultAsync(filter: a => a.Id == Id);
            _unitOfWork.AppointmentsRepository.Delete(entity);
            await _unitOfWork.SaveAsync();
        }
    }
        //Parametrii includ:"skip" și "take" pentru a selecta o anumită pagină din rezultate(de exemplu, pagina 1 cu 10 înregistrări pe pagină)
        //"startDate" și "endDate" pentru a filtra întâlnirile într-un anumit interval de timp
        //"filter" pentru a căuta întâlniri care conțin un anumit cuvânt cheie
        //"includeDeleted" pentru a decide dacă să includă sau nu întâlnirile marcate ca șterse(deleted) în rezultatele returnate.
 }


