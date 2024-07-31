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
    public class MedRecordPathologyConfig : IEntityTypeConfiguration<MedRecordPathology>
    {
        public void Configure(EntityTypeBuilder<MedRecordPathology> builder)
        {

            builder.HasKey(mp => new { mp.MedRecordId, mp.PathologyId });

            builder.Ignore(mp => mp.Id);

            builder
                .HasOne(mp => mp.MedRecord)
                .WithMany(m => m.MedRecordPathologies)
                .HasForeignKey(mp => mp.MedRecordId);

            builder
                .HasOne(mp => mp.Pathology)
                .WithMany(p => p.MedRecordPathologies)
                .HasForeignKey(mp => mp.PathologyId);
        }
    }
}
