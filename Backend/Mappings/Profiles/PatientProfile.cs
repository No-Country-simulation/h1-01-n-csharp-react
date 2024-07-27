using AutoMapper;
using Domain.Entities.Users;
using DTOs.Pathology;
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

            CreateMap<Patient, PatientEmailGetDto>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.ApplicationUser.Email));

            CreateMap<Patient, MedicPatientsGetDto>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.ApplicationUser.Address))
                .ForMember(dest => dest.BloodType, opt => opt.MapFrom(src => src.BloodType.ToString()))
                .ForMember(dest => dest.Pathologies, opt => opt.MapFrom(src => src.PatientPathologies.Select(pp => new PathologyNameGetDto
                {
                    Name = pp.Pathology.Name,
                    IsActive = pp.IsActive,
                }).ToList()));
        }
    }
}
