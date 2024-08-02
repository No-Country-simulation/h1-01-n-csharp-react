using AutoMapper;
using Domain.Entities.Users;
using DTOs.Medic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mappings.Profiles
{
    public class MedicProfile : Profile
    {
        public MedicProfile()
        {
            CreateMap<Medic, MedicGetDto>()
                .ForMember(dest => dest.Specialty, opt => opt.MapFrom(src => src.Specialty.Type))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.ApplicationUser.Email));

            CreateMap<Medic, PatientMedicsGetDto>()
                .ForMember(dest => dest.Specialty, opt => opt.MapFrom(src => src.Specialty.Type))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.ApplicationUser.Address))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.ApplicationUser.PhoneNumber));
        }
    }
}
