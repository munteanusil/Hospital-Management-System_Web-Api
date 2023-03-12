using AutoMapper;
using Hospital_Management_System_Web_Api.EntitiesModels;
using Hospital_Management_System_Web_Api.RequiredData.GetDataTo;
using Hospital_Management_System_Web_Api.RequiredData.PostDataTo;

namespace Hospital_Management_System_Web_Api.RequiredData.Profiles
{
    public class MedicalReportProfile : Profile
    {
        public MedicalReportProfile()
        {
            CreateMap<MedicalReport, MedicalReportGetDto>();
            CreateMap<MedicalReport, MedicalReportPostDto>();
            CreateMap<MedicalReportPostDto, MedicalReport>();
        }
    }
}
