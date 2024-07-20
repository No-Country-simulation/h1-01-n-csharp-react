using Domain.Entities.Medical;
using Domain.Entities.Transplants;
using Domain.Entities.Users;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration.Users
{
    public class PatientConfig : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasOne(p => p.MedRecord)
                .WithOne(m => m.Patient)
                .HasForeignKey<MedRecord>(m => m.PatientId);

            builder.HasOne(p => p.Donor)
                .WithOne(m => m.Patient)
                .HasForeignKey<Donor>(m => m.PatientId);

            builder.HasOne(p => p.Recipient)
                .WithOne(m => m.Patient)
                .HasForeignKey<Recipient>(m => m.PatientId);
        }
    }
}
