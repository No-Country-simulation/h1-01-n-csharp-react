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
    public class PathologyCategoryConfig : IEntityTypeConfiguration<PathologyCategory>
    {
        public void Configure(EntityTypeBuilder<PathologyCategory> builder)
        {
            builder.HasData(
                new PathologyCategory
                {
                    Id = 1,
                    Name = "Cardiovasculares",
                    Description = "Enfermedades relacionadas con el corazón y los vasos sanguíneos",
                    Color = "#FF0000",
                },
                new PathologyCategory
                {
                    Id = 2,
                    Name = "Respiratorias",
                    Description = "Enfermedades relacionadas con los pulmones y el sistema respiratorio",
                    Color = "#00FF00",
                },
                new PathologyCategory
                {
                    Id = 3,
                    Name = "Neurológicas",
                    Description = "Trastornos que afectan el cerebro y el sistema nervioso",
                    Color = "#0000FF",
                },
                new PathologyCategory
                {
                    Id = 4,
                    Name = "Gastrointestinales",
                    Description = "Enfermedades que afectan el tracto gastrointestinal",
                    Color = "#FFFF00",
                },
                new PathologyCategory
                {
                    Id = 5,
                    Name = "Infecciosas",
                    Description = "Enfermedades causadas por microorganismos patógenos",
                    Color = "#FF00FF",
                },
                new PathologyCategory
                {
                    Id = 6,
                    Name = "Renales",
                    Description = "Enfermedades que afectan los riñones",
                    Color = "#8A2BE2",
                },
                new PathologyCategory
                {
                    Id = 7,
                    Name = "Trastornos Hematológicos",
                    Description = "Enfermedades que afectan la sangre y los órganos hematopoyéticos",
                    Color = "#DC143C",
                },
                new PathologyCategory
                {
                    Id = 8,
                    Name = "Trastornos Autoinmunes",
                    Description = "Enfermedades causadas por una respuesta inmune hiperactiva contra las propias células del cuerpo",
                    Color = "#FF6347",
                },
                new PathologyCategory
                {
                    Id = 9,
                    Name = "Trastornos Endocrinos",
                    Description = "Enfermedades que afectan las glándulas endocrinas y las hormonas",
                    Color = "#FFD700",
                },
                new PathologyCategory
                {
                    Id = 10,
                    Name = "Trastornos Musculoesqueléticos",
                    Description = "Enfermedades que afectan los huesos, músculos y articulaciones",
                    Color = "#00CED1",
                }
            );
        }
    }
}
