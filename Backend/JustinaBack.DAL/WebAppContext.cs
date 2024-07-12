using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System.Data;
using JustinaBack.Models;
using JustinaBack.Models.Entities.Users;
using JustinaBack.Models.Entities.Medical;
using JustinaBack.Models.Entities.Transplants;
using System.Reflection;

namespace JustinaBack.DAL
{
    public class WebAppContext : IdentityDbContext<UserEF, Role, int>
    {
        public WebAppContext(DbContextOptions<WebAppContext> options) : base(options)
        {
        }

        //Users
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Medic> Medics { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Healthcare> Healthcares { get; set; }
        public DbSet<Lab> Labs { get; set; }
        public DbSet<GovEnt> GovEnts { get; set; }
        //Medical
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<Pathology> Pathologies { get; set; }
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

        #region Entities
        public new DbSet<UserEF>? Users { get; set; }
        public DbSet<ContactEF>? Contacts { get; set; }               
        public DbSet<CustomerEF>? Customers { get; set; }
        #endregion

        #region Configuration        
        //https://www.learnentityframeworkcore.com/configuration/fluent-api
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var useMySql = true;
     
            //modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        #endregion

        #region Methods        
        public string? GetConnectionString()
        {
            return base.Database.GetConnectionString();
        }

        public void SoftDelete(IAuditEntity auditEntity, string? email = null)
        {
            var userId = 1;
            if (email != null)
            {
                var connectionString = base.Database.GetConnectionString();
                if (connectionString is null) throw new Exception("Empty connectionString in WebAppContext");
                var securityDAC = new SecurityDACGF(connectionString);
                var user = securityDAC.GetUserByEmail(email);
                userId = user.Id;
            }

            auditEntity.Deleted = DateTime.Now;
            auditEntity.DeletedBy = userId;
        }

        public override int SaveChanges()
        {
            ProcessSave();
            return base.SaveChanges();
        }

        public int SaveChanges(string email)
        {
            var connectionString = base.Database.GetConnectionString();
            if (connectionString is null) throw new Exception("Empty connectionString in WebAppContext");
            var securityDAC = new SecurityDACGF(connectionString);
            var user = securityDAC.GetUserByEmail(email);
            ProcessSave(user.Id);
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ProcessSave();
            return base.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> SaveChangesAsync(string email)
        {
            var connectionString = base.Database.GetConnectionString();
            if (connectionString is null) throw new Exception("Empty connectionString in WebAppContext");
            var securityDAC = new SecurityDACGF(connectionString);
            var user = securityDAC.GetUserByEmail(email);
            ProcessSave(user.Id);
            return await base.SaveChangesAsync();
        }

        private void ProcessSave(int? userId = null)
        {
            var currentTime = DateTime.Now;

            foreach (var item in ChangeTracker.Entries().Where(e => e.State == EntityState.Added && e.Entity is IAuditEntity))
            {
                var auditEntity = item.Entity as IAuditEntity;
                if (auditEntity is not null)
                {
                    auditEntity.Created = currentTime;
                    auditEntity.CreatedBy = userId.HasValue ? userId.Value : 1;
                    auditEntity.Modified = currentTime;
                    auditEntity.ModifiedBy = userId.HasValue ? userId.Value : 1;
                }

                var entityPublicKey = item.Entity as IPublicKeyEntity;

                if (entityPublicKey is not null)
                {
                    var newGuid = Guid.Parse("00000000-0000-0000-0000-000000000000");

                    if (entityPublicKey.EntityPublicKey.Equals(newGuid))
                    {
                        entityPublicKey.EntityPublicKey = Guid.NewGuid();
                    }
                }
            }

            foreach (var item in ChangeTracker.Entries().Where(e => e.State == EntityState.Modified && e.Entity is IAuditEntity))
            {
                var entity = item.Entity as IAuditEntity;
                if (entity is not null)
                {
                    entity.Modified = currentTime;
                    entity.ModifiedBy = userId.HasValue ? userId.Value : 1;
                }
            }
        }
        #endregion


    }
}
