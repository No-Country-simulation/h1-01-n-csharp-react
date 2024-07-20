using Domain.Entities.Medical;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration.Medical
{
    public class SpecialtyConfig : IEntityTypeConfiguration<Specialty>
    {
        public void Configure(EntityTypeBuilder<Specialty> builder)
        {

            builder.HasData(
                new Specialty { Id = 1, Type = "Cardiología" },
                new Specialty { Id = 2, Type = "Odontología" },
                new Specialty { Id = 3, Type = "Kinesiología" },
                new Specialty { Id = 4, Type = "Fonoaudiología" },
                new Specialty { Id = 5, Type = "Cirugía" },
                new Specialty { Id = 6, Type = "Obstetricia" },
                new Specialty { Id = 7, Type = "Enfermería" },
                new Specialty { Id = 8, Type = "Oftalmología" },
                new Specialty { Id = 9, Type = "Dermatología" },
                new Specialty { Id = 10, Type = "Neurología" }

            );
        }
    }
}
