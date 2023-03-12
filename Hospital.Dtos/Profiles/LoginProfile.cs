using AutoMapper;
using Hospital_Management_System_Web_Api.Entities;
using Hospital_Management_System_Web_Api.RequiredData.PostDataTo;

namespace Hospital_Management_System_Web_Api.RequiredData.Profiles
{
    public class LoginProfile : Profile
    {
        public LoginProfile()
        {
            CreateMap<LoginPostDto, Doctor>();
            CreateMap<LoginPostDto, Patient>();
        }
    }
}
