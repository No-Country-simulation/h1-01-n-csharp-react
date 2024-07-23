using AutoMapper;
using Domain.Entities.Users;
using DTOs.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mappings.Profiles
{
    public class PatientProfile : Profile
    {
        public PatientProfile()
        {
            CreateMap<Patient, PatientGetDto>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.ApplicationUser.Address))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.ApplicationUser.Email))
                .ForMember(dest => dest.BloodType, opt => opt.MapFrom(src => src.BloodType.ToString()));
        }
    }
}
