using AutoMapper;
using Hospital_Management_System_Web_Api.Entities;
using Hospital_Management_System_Web_Api.Hospital.Repository.UnitofWork;
using Hospital_Management_System_Web_Api.Hospital.Services.DataServices.Contracts;
using Hospital_Management_System_Web_Api.RequiredData.GetDataTo;
using Hospital_Management_System_Web_Api.RequiredData.PostDataTo;

namespace Hospital_Management_System_Web_Api.Hospital.Services.DataServices.Implementations
{
        public class SpecialtiesService : ISpecialtiesService
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public SpecialtiesService(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public GetResponse<SpecialtyGetDto> Get(int? skip, int? take, string filter, bool includeDeleted)
            {
                var result = _unitOfWork.SpecialtiesRepository.Get();

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

            //Get all doctors by specialty
            //var result = _unitOfWork.DoctorsRepository.Get(include: i => i.Include(x => x.DoctorSpecialties).ThenInclude(y => y.Specialty));

            //get all subspecialities of speciality

            public async Task<SpecialtyGetDto> GetByIdAsync(Guid? Id)
            {
                var result = await _unitOfWork.SpecialtiesRepository.SingleOrDefaultAsync(filter: f => f.Id == Id);
                return _mapper.Map<SpecialtyGetDto>(result);
            }

            public async Task<SpecialtyPostDto> AddAsync(SpecialtyPostDto item)
            {
                Specialty entity = _mapper.Map<Specialty>(item);
                Specialty result = await _unitOfWork.SpecialtiesRepository.InsertAsync(entity);
                await _unitOfWork.SaveAsync();
                return _mapper.Map<SpecialtyPostDto>(result);
            }

            public async Task UpdateAsync(SpecialtyPostDto item, Guid Id)
            {
                Specialty entity = await _unitOfWork.SpecialtiesRepository.SingleOrDefaultAsync(filter: f => f.Id == Id);
                _mapper.Map(item, entity);
                _unitOfWork.SpecialtiesRepository.Update(entity);
                await _unitOfWork.SaveAsync();
            }

            public async Task DeleteAsync(Guid? Id)
            {
                var entity = await _unitOfWork.SpecialtiesRepository.SingleOrDefaultAsync(filter: f => f.Id == Id);
                _unitOfWork.SpecialtiesRepository.Delete(entity);
                await _unitOfWork.SaveAsync();
            }
        }
    }

