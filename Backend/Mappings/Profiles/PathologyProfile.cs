using AutoMapper;
using Domain.Entities.Medical;
using DTOs.Pathology;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mappings.Profiles
{
    public class PathologyProfile : Profile
    {
        public PathologyProfile()
        {
            CreateMap<Pathology, PathologyGetDto>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.PathologyCategory.Name));

            CreateMap<PathologyCategory, PathologyCategoriesGetDto>();
        }
    }
}
