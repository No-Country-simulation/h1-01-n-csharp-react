using AutoMapper;
using Domain.Entities.Medical;
using DTOs.MedRecord;
using DTOs.Pathology;
using DTOs.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mappings.Profiles
{
    public class MedRecordProfile : Profile
    {
        public MedRecordProfile()
        {
            CreateMap<MedRecord, MedRecordGetDto>()
                .ForMember(dest => dest.Patient, opt => opt.MapFrom(src => new MedicPatientsGetDto
                {
                    Id = src.Patient.Id,
                    MedRecordId = src.Id,
                    FirstName = src.Patient.FirstName,
                    LastName = src.Patient.LastName,
                    DNI = src.Patient.DNI,
                    BirthDate = src.Patient.BirthDate,
                    ParentName = src.Patient.ParentName,
                    Address = src.Patient.ApplicationUser.Address,
                    PhoneNumber = src.Patient.ApplicationUser.PhoneNumber == null? "" : src.Patient.ApplicationUser.PhoneNumber,
                    BloodType = src.Patient.BloodType.ToString(),
                    ImgSrc = src.Patient.ImgSrc
                }))
                .ForMember(dest => dest.MedRecordAllergies, opt => opt.MapFrom(src => src.MedRecordAllergies
                    .Select(mra => new MedRecordAllergiesGetDto
                    {
                        Id = mra.AllergyId,
                        IsActive = mra.IsActive,
                        Name = mra.Allergy.Name,
                        Category = mra.Allergy.AllergyCategory.Name,
                        Color = mra.Allergy.AllergyCategory.Color
                    }).ToList()))
                .ForMember(dest => dest.FamilyHistories, opt => opt.MapFrom(src => src.FamilyHistories
                    .Select(fh => new MedRecordFamilyHistoriesGetDto
                    {
                        Id = fh.Id,
                        Details = fh.Details,
                        FamilyRelation = fh.FamilyRelation.ToString(),
                        Pathologies = fh.FamilyHistoryPathologies
                            .Select(fhp => new RecordPathologyGetDto
                            {
                                Id = fhp.Pathology.Id,
                                Name = fhp.Pathology.Name,
                                Category = fhp.Pathology.PathologyCategory.Name,
                                Color = fhp.Pathology.PathologyCategory.Color
                            }).ToList()
                    }).ToList()))
                .ForMember(dest => dest.SurgicalHistories, opt => opt.MapFrom(src => src.SurgicalHistories
                    .Select(sh => new MedRecordSurgicalHistoriesGetDto
                    {
                        Id = sh.Id,
                        SurgeonName = sh.SurgeonName,
                        Hospital = sh.Hospital,
                        Details = sh.Details,
                        SurgeryDate = sh.SurgeryDate,
                        CreatorName = sh.CreatorName,
                        CreatorSpecialty = sh.CreatorSpecialty,
                        SurgeryType = sh.SurgeryType.Name
                    }).ToList()))
                .ForMember(dest => dest.ClinicalHistories, opt => opt.MapFrom(src => src.ClinicalHistories
                    .Select(ch => new MedRecordClinicalHistoriesGetDto
                    {
                        Id = ch.Id,
                        MedicName = ch.MedicName,
                        Details = ch.Details,
                        DiagnosisDate = ch.DiagnosisDate,
                        CreatorName = ch.CreatorName,
                        CreatorSpecialty = ch.CreatorSpecialty,
                        PathologyName = ch.Pathology.Name,
                        PathologyCategory = ch.Pathology.PathologyCategory.Name,
                        Color = ch.Pathology.PathologyCategory.Color,
                        IsActive = ch.IsActive,
                    }).ToList()));
        }
    }
}
