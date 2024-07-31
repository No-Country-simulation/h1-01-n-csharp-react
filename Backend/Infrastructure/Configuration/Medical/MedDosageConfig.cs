using Domain.Entities.Medical;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration.Medical
{
    public class MedDosageConfig : IEntityTypeConfiguration<MedDosage>
    {
        public void Configure(EntityTypeBuilder<MedDosage> builder)
        {

            builder.HasKey(md => new { md.TreatmentId, md.MedicineId });

            builder.Ignore(md => md.Id);

            builder
                .HasOne(md => md.Treatment)
                .WithMany(t => t.MedDosages)
                .HasForeignKey(md => md.TreatmentId);

            builder
                .HasOne(md => md.Medicine)
                .WithMany(m => m.MedDosages)
                .HasForeignKey(md => md.MedicineId);
        }
    }
}
