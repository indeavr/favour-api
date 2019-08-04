using FavourAPI.Data.Models.Enums;
using Microsoft.EntityFrameworkCore;
using FavourAPI.Data.Models;
using System;
using System.Linq;

namespace FavourAPI.Data
{
    public class WorkFavourDbContext : DbContext
    {
        public WorkFavourDbContext(DbContextOptions<WorkFavourDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<PersonProvider> PersonProviders { get; set; }

        public DbSet<CompanyProvider> CompanyProviders { get; set; }

        public DbSet<Office> Offices { get; set; }

        public DbSet<Industry> Industries { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<Email> Emails { get; set; }

        public DbSet<PhoneNumber> PhoneNumbers { get; set; }

        public DbSet<Consumer> Consumers { get; set; }

        public DbSet<JobOffer> JobOffers { get; set; }

        public DbSet<JobPhoto> JobPhotos { get; set; }

        public DbSet<Application> Applications { get; set; }

        public DbSet<Period> Periods { get; set; }

        public DbSet<SexDb> Sexes { get; set; }

        public DbSet<ApplicationStateDb> ApplicationStates { get; set; }

        public DbSet<PermissionMy> PermissionMys { get; set; }

        public DbSet<CompletionResult> Results { get; set; }

        public DbSet<PositionSkill> PositionSkills { get; set; }

        public DbSet<IndustryPosition> IndustryPositions { get; set; }

        public DbSet<OfficeIndustry> OfficeIndustries { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<JobOfferLocation> JobOfferLocations { get; set; }

        public DbSet<PermissionName> PermissionNames { get; set; }

        public DbSet<Permission> Permissions { get; set; }

        public DbSet<PermissionTransaction> PermissionTransactions { get; set; }

        public DbSet<Subscription> Subscriptions { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<ProviderViewTime> ProviderViewTimes { get; set; }

        public DbSet<Experience> Experiences { get; set; }

        public DbSet<Education> Educations { get; set; }

        public DbSet<FieldOfStudy> FieldsOfStudy { get; set; }

        public DbSet<ActiveJobOffer> ActiveJobOffers { get; set; }

        public DbSet<OngoingJobOffer> OngoingJobOffers { get; set; }

        public DbSet<CompletedJobOffer> CompletedJobOffers { get; set; }

        public DbSet<SavedJobOffer> SavedJobOffers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuring one-to-one relation
            modelBuilder.Entity<User>().HasOne<CompanyProvider>(u => u.CompanyProvider).WithOne(cp => cp.User).HasForeignKey<CompanyProvider>(cp => cp.Id);
            modelBuilder.Entity<Permission>().HasIndex(p => new { p.UserId, p.PermissionNameId }).IsUnique();

            // Configuring the many-to-many realtions
            modelBuilder.Entity<IndustryPosition>().HasKey(ip => new { ip.IndustryId, ip.PositionId });
            modelBuilder.Entity<PositionSkill>().HasKey(ps => new { ps.SkillId, ps.PositionId });
            modelBuilder.Entity<OfficeIndustry>().HasKey(ps => new { ps.IndustryId, ps.OfficeId });
            modelBuilder.Entity<SavedJobOffer>().HasKey(cjo => new { cjo.ConsumerId, cjo.JobOfferId });
            modelBuilder.Entity<OngoingJobOffer>().HasKey(cjo => new { cjo.ConsumerId, cjo.JobOfferId });
            modelBuilder.Entity<JobOfferLocation>().HasKey(jol => new { jol.JobOfferId, jol.LocationId });

            // Setting autogenerating PK GUIDs 
            //modelBuilder.Entity<Application>().Property(a => a.Id).HasColumnType("uniqueidentifier");//.HasDefaultValueSql("NEWID()");

            // Start TODO: Find a better way to load this data (like JSON or something)
            // Loding the enums data into the tables in database
            //modelBuilder.Entity<JobOfferStateDb>().HasData(new JobOfferStateDb()
            //{
            //    Value = nameof(JobOfferState.Active)
            //});
            //modelBuilder.Entity<JobOfferStateDb>().HasData(new JobOfferStateDb()
            //{
            //    Value = nameof(JobOfferState.Expired)
            //});
            //modelBuilder.Entity<JobOfferStateDb>().HasData(new JobOfferStateDb()
            //{
            //    Value = nameof(JobOfferState.Completed)
            //});
            //modelBuilder.Entity<JobOfferStateDb>().HasData(new JobOfferStateDb()
            //{
            //    Value = nameof(JobOfferState.Ongoing),
            //});

            modelBuilder.Entity<ApplicationStateDb>().HasData(new ApplicationStateDb()
            {
                Value = nameof(ApplicationState.Pending)
            });
            modelBuilder.Entity<ApplicationStateDb>().HasData(new ApplicationStateDb()
            {
                Value = nameof(ApplicationState.Accepted)
            });
            modelBuilder.Entity<ApplicationStateDb>().HasData(new ApplicationStateDb()
            {
                Value = nameof(ApplicationState.Rejected)
            });
            // End TODO


            modelBuilder.Entity<SexDb>().HasData(
                new SexDb() { Value = nameof(Sex.Male) },
                new SexDb() { Value = nameof(Sex.Female) });

            modelBuilder.Entity<Position>().HasData(new Position() { Id = Guid.NewGuid(), Name = "Test position 1" },
                new Position() { Id = Guid.NewGuid(), Name = "Test position 2" },
                new Position() { Id = Guid.NewGuid(), Name = "Test position 3" },
                new Position() { Id = Guid.NewGuid(), Name = "Test position 4" },
                new Position() { Id = Guid.NewGuid(), Name = "Test position 5" },
                new Position() { Id = Guid.NewGuid(), Name = "Test position 6" },
                new Position() { Id = Guid.NewGuid(), Name = "Test position 7" });

            modelBuilder.Entity<Industry>().HasData(new Industry() { Id = Guid.NewGuid(), Name = "Test industry 1" },
                new Industry() { Id = Guid.NewGuid(), Name = "Test industry 2" },
                new Industry() { Id = Guid.NewGuid(), Name = "Test industry 3" },
                new Industry() { Id = Guid.NewGuid(), Name = "Test industry 4" },
                new Industry() { Id = Guid.NewGuid(), Name = "Test industry 5" },
                new Industry() { Id = Guid.NewGuid(), Name = "Test industry 6" },
                new Industry() { Id = Guid.NewGuid(), Name = "Test industry 7" },
                new Industry() { Id = Guid.NewGuid(), Name = "Test industry 8" },
                new Industry() { Id = Guid.NewGuid(), Name = "Test industry 9" });

            modelBuilder.Entity<Skill>().HasData(new Skill() { Name = "Test skill 1" },
                new Skill() { Name = "Test skill 2" },
                new Skill() { Name = "Test skill 3" },
                new Skill() { Name = "Test skill 4" },
                new Skill() { Name = "Test skill 5" });

            /* Hack
            * In indexMagic 5 migration we make the time posted column a clustedred index
            * If you want to change any relations for JobOffer you have to add them there
            */

        }
    }
}