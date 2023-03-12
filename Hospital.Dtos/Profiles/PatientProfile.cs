using AutoMapper;
using Hospital_Management_System_Web_Api.Entities;
using Hospital_Management_System_Web_Api.RequiredData.GetDataTo;
using Hospital_Management_System_Web_Api.RequiredData.PostDataTo;

namespace Hospital_Management_System_Web_Api.RequiredData.Profiles
{
    public class PatientProfile : Profile
    {
        public PatientProfile()
        {
            CreateMap<Patient, PatientGetDto>();
            CreateMap<Patient, PatientPostDto>();
            CreateMap<PatientPostDto, Patient>();
        }
    }
}
