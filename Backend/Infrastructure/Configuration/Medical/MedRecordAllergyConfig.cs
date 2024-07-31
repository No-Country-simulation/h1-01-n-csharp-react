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
    public class MedRecordAllergyConfig : IEntityTypeConfiguration<MedRecordAllergy>
    {
        public void Configure(EntityTypeBuilder<MedRecordAllergy> builder)
        {

            builder.HasKey(ma => new { ma.MedRecordId, ma.AllergyId });

            builder.Ignore(ma => ma.Id);

            builder
                .HasOne(ma => ma.MedRecord)
                .WithMany(m => m.MedRecordAllergies)
                .HasForeignKey(ma => ma.MedRecordId);

            builder
                .HasOne(ma => ma.Allergy)
                .WithMany(a => a.MedRecordAllergies)
                .HasForeignKey(ma => ma.AllergyId);
        }
    }
}
