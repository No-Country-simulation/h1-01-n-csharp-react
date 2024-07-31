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

        #region Users
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Medic> Medics { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Healthcare> Healthcares { get; set; }
        public DbSet<Lab> Labs { get; set; }
        public DbSet<GovEnt> GovEnts { get; set; }
        public DbSet<MedicPatient> MedicPatients { get; set; }
        #endregion

        #region Medical
        public DbSet<Allergy> Allergies { get; set; }
        public DbSet<AllergyCategory> AllergyCategories { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<ClinicalHistory> ClinicalHistories { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<FamilyHistory> FamilyHistories { get; set; }
        public DbSet<FamilyHistoryPathology> FamilyHistoryPathologies { get; set; }
        public DbSet<MedDosage> MedDosages { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<MedRecord> MedRecords { get; set; }
        public DbSet<MedRecordAllergy> MedRecordAllergies { get; set; }
        public DbSet<MedRecordPathology> MedRecordPathologies { get; set; }
        public DbSet<Pathology> Pathologies { get; set; }
        public DbSet<PathologyCategory> PathologyCategories { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<SurgeryType> SurgeryTypes { get; set; }
        public DbSet<SurgicalHistory> SurgicalHistories { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        #endregion

        #region Transplant
        public DbSet<Donor> Donors { get; set; }
        public DbSet<Recipient> Recipients { get; set; }
        public DbSet<Organ> Organs { get; set; }
        public DbSet<Transplant> Transplants { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
