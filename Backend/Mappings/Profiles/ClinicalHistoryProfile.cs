using AutoMapper;
using Domain.Entities.Medical;
using DTOs.ClinicalHistory;
using DTOs.Pathology;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Mappings.Profiles
{
    public class ClinicalHistoryProfile : Profile
    {
        public ClinicalHistoryProfile()
        {
            CreateMap<ClinicalHistory, ClinicalHistoryGetDto>()
                .ForMember(dest => dest.RecordPathology, opt => opt.MapFrom(src => new RecordPathologyGetDto
                {
                    Id = src.Pathology.Id,
                    Name = src.Pathology.Name,
                    Category = src.Pathology.PathologyCategory.Name,
                    Color = src.Pathology.PathologyCategory.Color
                }));
        }
    }
}
