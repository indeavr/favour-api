using FavourAPI.Data.Models.Enums;
using Microsoft.EntityFrameworkCore;
using FavourAPI.Data.Models;
using System;
using FavourAPI.Data.JsonSeed;

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

        public DbSet<JobOfferStateDb> JobOfferStates { get; set; }

        public DbSet<ApplicationStateDb> ApplicationStates { get; set; }

        public DbSet<PermissionMy> PermissionMys { get; set; }

        public DbSet<CompletionResult> Results { get; set; }

        public DbSet<PositionSkill> PositionSkills { get; set; }

        public DbSet<IndustryPosition> IndustryPositions { get; set; }

        public DbSet<OfficeIndustry> OfficeIndustries { get; set; }

        public DbSet<ConsumerJobOffer> ConsumerJobOffers { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<JobOfferLocation> JobOfferLocations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuring one-to-one relation
            modelBuilder.Entity<User>().HasOne<CompanyProvider>(u => u.CompanyProvider).WithOne(cp => cp.User).HasForeignKey<CompanyProvider>(cp => cp.Id);

            // Configuring the many-to-many realtions
            modelBuilder.Entity<IndustryPosition>().HasKey(ip => new { ip.IndustryId, ip.PositionId });
            modelBuilder.Entity<PositionSkill>().HasKey(ps => new { ps.SkillId, ps.PositionId });
            modelBuilder.Entity<OfficeIndustry>().HasKey(ps => new { ps.IndustryId, ps.OfficeId });
            modelBuilder.Entity<ConsumerJobOffer>().HasKey(cjo => new { cjo.ConsumerId, cjo.JobOfferId });
            modelBuilder.Entity<JobOfferLocation>().HasKey(jol => new { jol.JobOfferId, jol.LocationId });

            // Seeding the database (the old variant)
            //var jsonManager = new JsonSeeder(modelBuilder);
            //jsonManager.RegisterJson<User>("users.json");
            //jsonManager.RegisterJson<Consumer>("consumers.json");
            //jsonManager.RegisterJson<Consumer>("application.json");
            //jsonManager.RegisterJson<Consumer>("company_providers.json");
            //jsonManager.RegisterJson<Consumer>("completition_results.json");
            //jsonManager.RegisterJson<Consumer>("jobofferes.json");
            //jsonManager.RegisterJson<Consumer>("permissions.json");
            //jsonManager.RegisterJson<Consumer>("person_providers.json");

            // Loding the enums data into the tables in database
            modelBuilder.Entity<JobOfferStateDb>().HasData(new JobOfferStateDb()
            {
                Value = nameof(JobOfferState.Available)
            });
            modelBuilder.Entity<JobOfferStateDb>().HasData(new JobOfferStateDb()
            {
                Value = nameof(JobOfferState.Expired)
            });
            modelBuilder.Entity<JobOfferStateDb>().HasData(new JobOfferStateDb()
            {
                Value = nameof(JobOfferState.Failed)
            });
            modelBuilder.Entity<JobOfferStateDb>().HasData(new JobOfferStateDb()
            {
                Value = nameof(JobOfferState.Finished)
            });
            modelBuilder.Entity<JobOfferStateDb>().HasData(new JobOfferStateDb()
            {
                Value = nameof(JobOfferState.Ongoing),
            });

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

            /* Hack
            * In indexMagic 5 migration we make the time posted column a clustedred index
            * If you want to change any relations for JobOffer you have to add them there
            */
        }
    }
}