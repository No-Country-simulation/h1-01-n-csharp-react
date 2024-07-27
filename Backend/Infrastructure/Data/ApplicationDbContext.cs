using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Domain.Entities.Users;
using Domain.Entities.Medical;
using Domain.Entities.Transplants;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        //Users
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Medic> Medics { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Healthcare> Healthcares { get; set; }
        public DbSet<Lab> Labs { get; set; }
        public DbSet<GovEnt> GovEnts { get; set; }
        public DbSet<MedicPatient> MedicPatients { get; set; }
        //Medical
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<Pathology> Pathologies { get; set; }
        public DbSet<PatientPathology> PatientPathologies { get; set; }
        public DbSet<MedRecord> MedRecords { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<MedDosage> MedDosages { get; set; }
        public DbSet<MedCheck> MedChecks { get; set; }
        public DbSet<Document> Documents { get; set; }
        //Transplant
        public DbSet<Donor> Donors { get; set; }
        public DbSet<Recipient> Recipients { get; set; }
        public DbSet<Organ> Organs { get; set; }
        public DbSet<Transplant> Transplants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
