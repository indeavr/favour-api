using FavourAPI.Data.Models.Enums;
using Microsoft.EntityFrameworkCore;
using FavourAPI.Data.Models;
using System;

namespace FavourAPI.Data
{
    public class WorkFavourDbContext : DbContext
    {
        public WorkFavourDbContext(DbContextOptions<WorkFavourDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }

        public DbSet<PersonProvider> PersonProvider { get; set; }

        public DbSet<CompanyProvider> CompanyProvider { get; set; }

        public DbSet<Office> Office { get; set; }

        public DbSet<Industry> Industry { get; set; }

        public DbSet<Position> Position { get; set; }

        public DbSet<Skill> Skill { get; set; }

        public DbSet<Email> Email { get; set; }

        public DbSet<PhoneNumber> PhoneNumber { get; set; }

        public DbSet<Consumer> Consumer { get; set; }

        public DbSet<JobOffer> JobOffer { get; set; }

        public DbSet<JobPhoto> JobPhoto { get; set; }

        public DbSet<Application> Application { get; set; }

        public DbSet<Period> Period { get; set; }

        public DbSet<SexDb> Sex { get; set; }

        public DbSet<JobOfferStateDb> JobOfferState { get; set; }

        public DbSet<ApplicationStateDb> ApplicationState { get; set; }

        public DbSet<PermissionMy> PermissionMy { get; set; }

        public DbSet<CompletionResult> Result { get; set; }

        public DbSet<PositionSkills> PositionSkill { get; set; }

        public DbSet<IndustryPosition> IndustryPosition { get; set; }

        public DbSet<OfficeIndustry> OfficeIndustry { get; set; }

        public DbSet<ConsumerJobOffer> ConsumerJobOffer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuring one-to-one relation
            modelBuilder.Entity<User>().HasOne<CompanyProvider>(u => u.CompanyProvider).WithOne(cp => cp.User).HasForeignKey<CompanyProvider>(cp => cp.Id);

            // Configuring the many-to-many realtions
            modelBuilder.Entity<IndustryPosition>().HasKey(ip => new { ip.IndustryId, ip.PositionId });
            modelBuilder.Entity<PositionSkills>().HasKey(ps => new { ps.SkillId, ps.PositionId });
            modelBuilder.Entity<OfficeIndustry>().HasKey(ps => new { ps.IndustryId, ps.OfficeId });
            modelBuilder.Entity<ConsumerJobOffer>().HasKey(cjo => new { cjo.ConsumerId, cjo.JobOfferId });

            // Setting autogenerating PK GUIDs 
            //modelBuilder.Entity<Application>().Property(a => a.Id).HasColumnType("uniqueidentifier");//.HasDefaultValueSql("NEWID()");

            // Start TODO: Find a better way to load this data (like JSON or something)
            // Loding the enums data into the tables in database
            modelBuilder.Entity<JobOfferStateDb>().HasData(new JobOfferStateDb()
            {
                Value = nameof(Models.Enums.JobOfferState.Available)
            });
            modelBuilder.Entity<JobOfferStateDb>().HasData(new JobOfferStateDb()
            {
                Value = nameof(Models.Enums.JobOfferState.Expired)
            });
            modelBuilder.Entity<JobOfferStateDb>().HasData(new JobOfferStateDb()
            {
                Value = nameof(Models.Enums.JobOfferState.Failed)
            });
            modelBuilder.Entity<JobOfferStateDb>().HasData(new JobOfferStateDb()
            {
                Value = nameof(Models.Enums.JobOfferState.Finished)
            });
            modelBuilder.Entity<JobOfferStateDb>().HasData(new JobOfferStateDb()
            {
                Value = nameof(Models.Enums.JobOfferState.Ongoing),
            });

            modelBuilder.Entity<ApplicationStateDb>().HasData(new ApplicationStateDb()
            {
                Value = nameof(Models.Enums.ApplicationState.Pending)
            });
            modelBuilder.Entity<ApplicationStateDb>().HasData(new ApplicationStateDb()
            {
                Value = nameof(Models.Enums.ApplicationState.Accepted)
            });
            modelBuilder.Entity<ApplicationStateDb>().HasData(new ApplicationStateDb()
            {
                Value = nameof(Models.Enums.ApplicationState.Rejected)
            });
            // End TODO

            //modelBuilder.Entity<Skill>().HasData(new CompanyProvider()
            //{
            //    Id = "8bfc8f4b-050b-41af-a7a2-b15eeb6e0f2e",
            //    Name = "Dao",
            //    Description = "KOt",
            //    FoundedYear = new DateTime(),
            //    NumberOfEmployees = 100,
            //    //Industries = 

            //});

            //var user = new User()
            //{
            //    Id = "consumer",
            //    Email = "gosho",
            //    Password = "dasds"
            //};

            //var sex = new SexDb()
            //{
            //    Value = Sex.Slave.ToString(),
            //    Consumers = new List<Consumer>()
            //    {
            //        new Consumer()
            //        {
            //            Id = "consumer"
            //        }
            //    }
            //};

            //var pn = new PhoneNumber()
            //{
            //    Id = "phone",
            //    Label = "Tilifon",
            //    Number = "1219412"
            //};

            //var skills = new List<Skill>();

            //skills.Add(new Skill()
            //{
            //    Id = "skill",
            //    Name = "Gucha",
            //});

            //var offerState = new JobOfferStateDb()
            //{
            //    Value = JobOfferState.Available.ToString(),
            //    JobOffers = new List<JobOffer>()
            //    {
            //        new JobOffer()
            //        {
            //            Id = "jobOffer"
            //        }
            //    }
            //};

            //var jobOffer = new JobOffer()
            //{
            //    Id = "jobOffer",
            //    Description = "adsadass",
            //    Location = "Sofia",
            //    Money = 3000,
            //    Title = "Anakondioto",
            //    TimePosted = new DateTime(),

            //};

            //var periods = new List<Period>()
            //{
            //    new Period()
            //    {
            //        Id= "period",
            //        StartDate =new DateTime(),
            //        EndDate=new DateTime(),
            //        StartHour =new DateTime(),
            //        EndHour =new DateTime(),
            //        JobOffer =  jobOffer
            //    }
            //};

            //var consumer = new Consumer()
            //{
            //    Id = "consumer",
            //    FirstName = "Dao",
            //    LastName = "KOt",
            //    Location = "Sofia",
            //    // Offers = offers,
            //};

            //var applicationState = new ApplicationStateDb()
            //{
            //    Value = ApplicationState.Pending.ToString(),
            //    Applications = new List<Application>()
            //    {
            //        new Application()
            //        {
            //            Id = "application",
            //        }
            //    }
            //};

            //var applic = new Application()
            //{
            //    Id = "application",
            //    Time = new DateTime(),
            //};

            //var applications = new List<Application>()
            //{
            //   applic
            //};


            //var offers = new List<JobOffer>()
            //{
            //    jobOffer
            //};


            //modelBuilder.Entity<SexDb>().HasData(sex);
            //modelBuilder.Entity<PhoneNumber>().HasData(pn);
            //modelBuilder.Entity<Skill>().HasData(skills);

            //modelBuilder.Entity<Consumer>().HasData(consumer);


            //modelBuilder.Entity<JobOfferStateDb>().HasData(offerState);

            //modelBuilder.Entity<ApplicationStateDb>().HasData(applicationState);
            //modelBuilder.Entity<Application>().HasData(applications);

            //modelBuilder.Entity<JobOffer>().HasData(offers);
            //modelBuilder.Entity<Period>().HasData(periods);




            //modelBuilder.Entity<CompanyProvider>().HasData(new CompanyProvider()
            //{
            //    Id = "68b67c4b-bc66-4d31-b672-47a8d55f6145",
            //    Name = "Dao",
            //});

            //int count = 101011;
            //for (int i = 0; i < 50; i++)
            //{
            //    modelBuilder.Entity<JobOffer>().HasData(new JobOffer
            //    {
            //        Id = count++.ToString(),
            //        Title = "Nasa Hacker" + count,
            //        Description = "Nasa Hacker" + count,
            //        Money = count,
            //        TimePosted = new DateTime(),
            //        Location = "Sofia",

            //    });
            //}

            /* Hack
            * In indexMagic 5 migration we make the time posted column a clustedred index
            * If you want to change any relations for JobOffer you have to add them there
            */

        }
    }
}