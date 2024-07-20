using Domain.Entities.Medical;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Transplants;

namespace Infrastructure.Configuration.Transplants
{
    public class TransplantConfig : IEntityTypeConfiguration<Transplant>
    {
        public void Configure(EntityTypeBuilder<Transplant> builder)
        {
            builder.HasOne(t => t.Donor)
                .WithMany(d => d.Transplants)
                .HasForeignKey(t => t.DonorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Recipient)
                .WithMany(r => r.Transplants)
                .HasForeignKey(t => t.RecipientId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
