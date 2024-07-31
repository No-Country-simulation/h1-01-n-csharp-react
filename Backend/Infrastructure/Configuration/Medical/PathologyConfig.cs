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
    public class PathologyConfig : IEntityTypeConfiguration<Pathology>
    {
        public void Configure(EntityTypeBuilder<Pathology> builder)
        {
            builder.HasData(
                new Pathology
                {
                    Id = 1,
                    Code = "A87",
                    Name = "Meningitis Vírica",
                    Description = "Inflamación de los tejidos que rodean el cerebro y la médula espinal.",
                    PathologyCategoryId = 3 //Neurológica
                },
                new Pathology
                {
                    Id = 2,
                    Code = "N17",
                    Name = "Insuficiencia renal aguda",
                    Description = "Pérdida súbita de la capacidad de los riñones para eliminar desechos y equilibrar líquidos y electrolitos.",
                    PathologyCategoryId = 6 //Renal
                },
                new Pathology
                {
                    Id = 3,
                    Code = "N18",
                    Name = "Insuficiencia renal crónica",
                    Description = "Pérdida gradual y permanente de la función renal a lo largo del tiempo.",
                    PathologyCategoryId = 6 //Renal
                },
                new Pathology
                {
                    Id = 4,
                    Code = "I42",
                    Name = "Cardiomiopatía",
                    Description = "Enfermedad del músculo cardíaco que afecta la capacidad del corazón para bombear sangre.",
                    PathologyCategoryId = 1 //Cardiovascular
                },
                new Pathology
                {
                    Id = 5,
                    Code = "C91",
                    Name = "Leucemia linfoide",
                    Description = "Cáncer de los linfocitos, un tipo de glóbulo blanco.",
                    PathologyCategoryId = 7 //Trastorno hematológico
                },
                new Pathology
                {
                    Id = 6,
                    Code = "C92",
                    Name = "Leucemia mieloide",
                    Description = "Cáncer de las células mieloides, que producen glóbulos rojos, algunos tipos de glóbulos blancos y plaquetas.",
                    PathologyCategoryId = 7 //Trastorno hematológico
                },
                new Pathology
                {
                    Id = 7,
                    Code = "D50",
                    Name = "Anemia por deficiencia de hierro",
                    Description = "Disminución de la cantidad de glóbulos rojos debido a la falta de hierro.",
                    PathologyCategoryId = 7 //Trastorno hematológico
                },
                new Pathology
                {
                    Id = 8,
                    Code = "D51",
                    Name = "Anemia por deficiencia de vitamina B12",
                    Description = "Disminución de glóbulos rojos causada por la falta de vitamina B12.",
                    PathologyCategoryId = 7 //Trastorno hematológico
                },
                new Pathology
                {
                    Id = 9,
                    Code = "M05",
                    Name = "Artritis reumatoide seropositiva",
                    Description = "Enfermedad autoinmune que causa inflamación crónica de las articulaciones.",
                    PathologyCategoryId = 8 //Trastorno autoinmune
                },
                new Pathology
                {
                    Id = 10,
                    Code = "J20",
                    Name = "Bronquitis aguda",
                    Description = "Inflamación de las vías respiratorias principales en los pulmones.",
                    PathologyCategoryId = 2 //Respiratoria
                }
            );
        }
    }
}
