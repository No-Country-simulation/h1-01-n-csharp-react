using JustinaBack.Models.Entities.Medical;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustinaBack.DAL.Configurations.Users
{
    public class PathologyConfig : IEntityTypeConfiguration<Pathology>
    {
        public void Configure(EntityTypeBuilder<Pathology> builder)
        {
            builder.HasData(
                new Pathology { Id = 1, Code = "A87", Name = "Meningitis Vírica", Description = "Inflamación de los tejidos que rodean el cerebro y la médula espinal." },
                new Pathology { Id = 2, Code = "N17", Name = "Insuficiencia renal aguda", Description = "Pérdida súbita de la capacidad de los riñones para eliminar desechos y equilibrar líquidos y electrolitos." },
                new Pathology { Id = 3, Code = "N18", Name = "Insuficiencia renal crónica", Description = "Pérdida gradual y permanente de la función renal a lo largo del tiempo." },
                new Pathology { Id = 4, Code = "I42", Name = "Cardiomiopatía", Description = "Enfermedad del músculo cardíaco que afecta la capacidad del corazón para bombear sangre." },
                new Pathology { Id = 5, Code = "C91", Name = "Leucemia linfoide", Description = "Cáncer de los linfocitos, un tipo de glóbulo blanco." },
                new Pathology { Id = 6, Code = "C92", Name = "Leucemia mieloide", Description = "Cáncer de las células mieloides, que producen glóbulos rojos, algunos tipos de glóbulos blancos y plaquetas." },
                new Pathology { Id = 7, Code = "D50", Name = "Anemia por deficiencia de hierro", Description = "Disminución de la cantidad de glóbulos rojos debido a la falta de hierro." },
                new Pathology { Id = 8, Code = "D51", Name = "Anemia por deficiencia de vitamina B12", Description = "Disminución de glóbulos rojos causada por la falta de vitamina B12." },
                new Pathology { Id = 9, Code = "M05", Name = "Artritis reumatoide seropositiva", Description = "Enfermedad autoinmune que causa inflamación crónica de las articulaciones." },
                new Pathology { Id = 10, Code = "J20", Name = "Bronquitis aguda", Description = "Inflamación de las vías respiratorias principales en los pulmones." }
            );
        }
    }

}
