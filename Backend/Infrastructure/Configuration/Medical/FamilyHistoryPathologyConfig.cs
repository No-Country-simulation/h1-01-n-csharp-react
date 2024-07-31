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
    public class FamilyHistoryPathologyConfig : IEntityTypeConfiguration<FamilyHistoryPathology>
    {
        public void Configure(EntityTypeBuilder<FamilyHistoryPathology> builder)
        {

            builder.HasKey(fp => new { fp.FamilyHistoryId, fp.PathologyId });

            builder.Ignore(fp => fp.Id);

            builder
                .HasOne(fp => fp.FamilyHistory)
                .WithMany(f => f.FamilyHistoryPathologies)
                .HasForeignKey(fp => fp.FamilyHistoryId);

            builder
                .HasOne(fp => fp.Pathology)
                .WithMany(p => p.FamilyHistoryPathologies)
                .HasForeignKey(fp => fp.PathologyId);
        }
    }
}
