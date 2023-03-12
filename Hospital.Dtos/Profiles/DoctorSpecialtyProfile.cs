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
using Hospital_Management_System_Web_Api.EntitiesModels;
using Hospital_Management_System_Web_Api.RequiredData.PostDataTo;

namespace Hospital_Management_System_Web_Api.RequiredData.Profiles
{
    public class DoctorSpecialtyProfile
    {
        public DoctorSpecialtyProfile()
        {
            CreateMap<DoctorSpecialty, DoctorSpecialtyPostDto>();
            CreateMap<DoctorSpecialtyPostDto, DoctorSpecialty>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(x => (Guid.NewGuid())));
        }
    }
}
