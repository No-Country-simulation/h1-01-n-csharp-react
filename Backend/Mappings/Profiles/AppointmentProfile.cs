using AutoMapper;
using Domain.Entities.Medical;
using DTOs.Appointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Mappings.Profiles
{
    public class AppointmentProfile : Profile
    {
        public AppointmentProfile()
        {
            CreateMap<Appointment, AppointmentGetDto>()
                .ForMember(dest => dest.MedicName, opt => opt.MapFrom(src => $"{src.Medic.FirstName} {src.Medic.LastName}"))
                .ForMember(dest => dest.MedicSpecialty, opt => opt.MapFrom(src => src.Medic.Specialty.Type))
                .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => $"{src.MedRecord.Patient.FirstName} {src.MedRecord.Patient.LastName}"));

        }
    }
}
