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
    public class AllergyConfig : IEntityTypeConfiguration<Allergy>
    {
        public void Configure(EntityTypeBuilder<Allergy> builder)
        {
            builder.HasData(
                new Allergy { Id = 1, Name = "Alergia al maní", Description = "Reacción alérgica severa al maní.", AllergyCategoryId = 1 },
                new Allergy { Id = 2, Name = "Alergia a los mariscos", Description = "Reacción alérgica a los mariscos como camarones, cangrejos y langostas.", AllergyCategoryId = 1 },
                new Allergy { Id = 3, Name = "Alergia a la penicilina", Description = "Reacción alérgica al antibiótico penicilina.", AllergyCategoryId = 2 },
                new Allergy { Id = 4, Name = "Alergia a la aspirina", Description = "Reacción alérgica al medicamento antiinflamatorio aspirina.", AllergyCategoryId = 2 },
                new Allergy { Id = 5, Name = "Alergia a las picaduras de abejas", Description = "Reacción alérgica severa a las picaduras de abejas.", AllergyCategoryId = 3 },
                new Allergy { Id = 6, Name = "Alergia a las picaduras de avispas", Description = "Reacción alérgica severa a las picaduras de avispas.", AllergyCategoryId = 3 },
                new Allergy { Id = 7, Name = "Alergia al polen", Description = "Reacción alérgica al polen de flores y plantas.", AllergyCategoryId = 4 },
                new Allergy { Id = 8, Name = "Alergia al polvo", Description = "Reacción alérgica a los ácaros del polvo.", AllergyCategoryId = 4 },
                new Allergy { Id = 9, Name = "Alergia a los gatos", Description = "Reacción alérgica al pelo y la caspa de los gatos.", AllergyCategoryId = 5 },
                new Allergy { Id = 10, Name = "Alergia a los perros", Description = "Reacción alérgica al pelo y la caspa de los perros.", AllergyCategoryId = 5 }
            );
        }
    }
}
