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
    public class AllergyCategoryConfig : IEntityTypeConfiguration<AllergyCategory>
    {
        public void Configure(EntityTypeBuilder<AllergyCategory> builder)
        {
            builder.HasData(
                new AllergyCategory
                {
                    Id = 1,
                    Name = "Alergias Alimentarias",
                    Description = "Alergias causadas por ciertos alimentos",
                    Color = "#FFA500",
                },
                new AllergyCategory
                {
                    Id = 2,
                    Name = "Alergias a Medicamentos",
                    Description = "Alergias causadas por ciertos medicamentos",
                    Color = "#800080",
                },
                new AllergyCategory
                {
                    Id = 3,
                    Name = "Alergias a Insectos",
                    Description = "Alergias causadas por picaduras o mordeduras de insectos",
                    Color = "#008000",
                },
                new AllergyCategory
                {
                    Id = 4,
                    Name = "Alergias Ambientales",
                    Description = "Alergias causadas por factores ambientales como el polen o el polvo",
                    Color = "#000080",
                },
                new AllergyCategory
                {
                    Id = 5,
                    Name = "Alergias a Animales",
                    Description = "Alergias causadas por animales",
                    Color = "#FF69B4",
                }
            );
        }
    }
}
