﻿using AutoMapper;
using Domain.Entities.Medical;
using DTOs.Surgical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mappings.Profiles
{
    public class SurgicalProfile : Profile
    {
        public SurgicalProfile()
        {
            CreateMap<SurgeryType, SurgeryTypesGetDto>();
        }
    }
}
