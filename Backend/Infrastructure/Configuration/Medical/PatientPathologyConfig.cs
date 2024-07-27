using Domain.Entities.Medical;
using Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration.Medical
{
    public class PatientPathologyConfig : IEntityTypeConfiguration<PatientPathology>
    {
        public void Configure(EntityTypeBuilder<PatientPathology> builder)
        {

            builder.HasKey(pp => new { pp.PatientId, pp.PathologyId });

            builder.Ignore(pp => pp.Id);

            builder
                .HasOne(pp => pp.Patient)
                .WithMany(p => p.PatientPathologies)
                .HasForeignKey(pp => pp.PatientId);

            builder
                .HasOne(pp => pp.Patient)
                .WithMany(p => p.PatientPathologies)
                .HasForeignKey(pp => pp.PatientId);
        }
    }
}
