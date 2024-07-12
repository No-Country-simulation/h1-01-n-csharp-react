using JustinaBack.Models.Entities.Users;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustinaBack.DAL.Configurations.Users
{
    public class ApplicationUserConfig : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasOne(au => au.Admin)
                .WithOne(c => c.ApplicationUser)
                .HasForeignKey<ApplicationUser>(au => au.AdminId);

            builder.HasOne(au => au.Medic)
                .WithOne(c => c.ApplicationUser)
                .HasForeignKey<ApplicationUser>(au => au.MedicId);

            builder.HasOne(au => au.Patient)
                .WithOne(c => c.ApplicationUser)
                .HasForeignKey<ApplicationUser>(au => au.PatientId);

            builder.HasOne(au => au.Healthcare)
                .WithOne(c => c.ApplicationUser)
                .HasForeignKey<ApplicationUser>(au => au.HealthcareId);

            builder.HasOne(au => au.Lab)
                .WithOne(c => c.ApplicationUser)
                .HasForeignKey<ApplicationUser>(au => au.LabId);

            builder.HasOne(au => au.GovEnt)
                .WithOne(c => c.ApplicationUser)
                .HasForeignKey<ApplicationUser>(au => au.GovEntId);
        }
    }
}
