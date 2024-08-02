using AutoMapper;
using Domain.Entities.Medical;
using DTOs.Document;
using DTOs.Medicine;
using DTOs.MedRecord;
using DTOs.Pathology;
using DTOs.Treatment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Mappings.Profiles
{
    public class TreatmentProfile : Profile
    {
        public TreatmentProfile()
        {
            CreateMap<Treatment, TreatmentGetDto>()
                .ForMember(dest => dest.TreatmentPathology, opt => opt.MapFrom(src => new RecordPathologyGetDto
                {
                    Id = src.Pathology.Id,
                    Name = src.Pathology.Name,
                    Category = src.Pathology.PathologyCategory.Name,
                    Color = src.Pathology.PathologyCategory.Color
                }))
                .ForMember(dest => dest.MedDosages, opt => opt.MapFrom(src => src.MedDosages
                    .Select(md => new MedDosageGetDto
                    {
                        MedicineId = md.Medicine.Id,
                        Name = md.Medicine.Name,
                        Description = md.Medicine.Description,
                        CurrentDosage = md.CurrentDosage,
                        Instructions = md.Instructions,
                    }).ToList()))
                .ForMember(dest => dest.Documents, opt => opt.MapFrom(src => src.Documents
                    .Select(d => new DocumentGetDto
                    {
                        Id = d.Id,
                        DocSrc = d.DocSrc,
                        Description = d.Description,
                    }).ToList()));
        }
    }
}
