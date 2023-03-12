using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital_Management_System_Web_Api.Entities;
using Hospital_Management_System_Web_Api.RequiredData.GetDataTo;
using Hospital_Management_System_Web_Api.RequiredData.PostDataTo;
using Hospital_Management_System_Web_Api.Entities;
using Hospital_Management_System_Web_Api.RequiredData.GetDataTo;
using Hospital_Management_System_Web_Api.RequiredData.PostDataTo;

namespace Hospital_Management_System_Web_Api.RequiredData.Profiles
{
    public class DoctorProfile : Profile
    {
        public DoctorProfile()
        {
            CreateMap<Doctor, DoctorGetDto>();
            CreateMap<Doctor, DoctorPostDto>();
            CreateMap<DoctorPostDto, Doctor>()
                .ForMember(dst => dst.DoctorSpeciality, map => map.MapFrom(src => src.DoctorSpecialties == null ? null : src.DoctorSpecialties));
        }
    }
}
