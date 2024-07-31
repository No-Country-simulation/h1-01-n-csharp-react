using Domain.Entities.Medical;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration.Medical
{
    public class SurgeryTypeConfig : IEntityTypeConfiguration<SurgeryType>
    {
        public void Configure(EntityTypeBuilder<SurgeryType> builder)
        {
            builder.HasData(
                new SurgeryType
                {
                    Id = 1,
                    Name = "Apendicectomía",
                    Description = "Extirpación quirúrgica del apéndice",
                },
                new SurgeryType
                {
                    Id = 2,
                    Name = "Colecistectomía",
                    Description = "Extirpación quirúrgica de la vesícula biliar",
                },
                new SurgeryType
                {
                    Id = 3,
                    Name = "Bypass de Arteria Coronaria (CABG)",
                    Description = "Cirugía para mejorar el flujo sanguíneo al corazón",
                },
                new SurgeryType
                {
                    Id = 4,
                    Name = "Histerectomía",
                    Description = "Extirpación quirúrgica del útero",
                },
                new SurgeryType
                {
                    Id = 5,
                    Name = "Mastectomía",
                    Description = "Extirpación quirúrgica de una o ambas mamas",
                },
                new SurgeryType
                {
                    Id = 6,
                    Name = "Reemplazo de Cadera",
                    Description = "Cirugía para reemplazar una articulación de cadera desgastada o dañada",
                },
                new SurgeryType
                {
                    Id = 7,
                    Name = "Reemplazo de Rodilla",
                    Description = "Cirugía para reemplazar una articulación de rodilla desgastada o dañada",
                },
                new SurgeryType
                {
                    Id = 8,
                    Name = "Laparotomía",
                    Description = "Incisión quirúrgica en la cavidad abdominal",
                },
                new SurgeryType
                {
                    Id = 9,
                    Name = "Cesárea",
                    Description = "Parto quirúrgico de un bebé a través de la pared abdominal",
                },
                new SurgeryType
                {
                    Id = 10,
                    Name = "Amigdalectomía",
                    Description = "Extirpación quirúrgica de las amígdalas",
                }
            );
        }
    }
}
