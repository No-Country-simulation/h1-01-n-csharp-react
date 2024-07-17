using JustinaBack.Models.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustinaBack.DAL.Configurations.Users
{
    public class MedicPatientConfig : IEntityTypeConfiguration<MedicPatient>
    {
        public void Configure(EntityTypeBuilder<MedicPatient> builder)
        {
            builder.HasKey(mp => new { mp.MedicId, mp.PatientId });

            builder.Ignore(mp => mp.Id);

            builder
                .HasOne(mp => mp.Medic)
                .WithMany(m => m.MedicPatients)
                .HasForeignKey(mp => mp.MedicId);

            builder
                .HasOne(mp => mp.Patient)
                .WithMany(p => p.MedicPatients)
                .HasForeignKey(mp => mp.PatientId);
        }
    }
}
