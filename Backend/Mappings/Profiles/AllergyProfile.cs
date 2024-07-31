using AutoMapper;
using Domain.Entities.Medical;
using DTOs.Allergy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mappings.Profiles
{
    public class AllergyProfile : Profile
    {
        public AllergyProfile()
        {
            CreateMap<Allergy, AllergiesGetDto>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.AllergyCategory.Name));

            CreateMap<AllergyCategory, AllergyCategoriesGetDto>();
        }
    }
}
