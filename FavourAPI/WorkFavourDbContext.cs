using FavourAPI.Models;
using FavourAPI.Models.enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI
{
    public class WorkFavourDbContext : DbContext
    {
        public WorkFavourDbContext(DbContextOptions<WorkFavourDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasOne<CompanyProvider>(u => u.CompanyProvider).WithOne(cp => cp.User).HasForeignKey<CompanyProvider>(cp => cp.Id);

            modelBuilder.Entity<IndustryPosition>().HasKey(ip => new { ip.IndustryId, ip.PositionId });
            modelBuilder.Entity<PositionSkills>().HasKey(ps => new { ps.SkillId, ps.PositionId });
            modelBuilder.Entity<OfficeIndustry>().HasKey(ps => new { ps.IndustryId, ps.OfficeId });
            modelBuilder.Entity<ConsumerJobOffer>().HasKey(cjo => new { cjo.ConsumerId, cjo.JobOfferId });


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
                Value = nameof(JobOfferState.Ongoing)
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

        public DbSet<Application> Applications { get; set; }

        public DbSet<Period> Periods { get; set; }

        public DbSet<SexDb> Sexes { get; set; }

        public DbSet<JobOfferStateDb> JobOfferStates { get; set; }

        public DbSet<ApplicationStateDb> ApplicationStates { get; set; }

        public DbSet<PermissionMy> PermissionMys { get; set; }

        public DbSet<CompletionResult> Results { get; set; }

        public DbSet<PositionSkills> PositionSkills { get; set; }

        public DbSet<IndustryPosition> IndustryPositions { get; set; }

        public DbSet<OfficeIndustry> OfficeIndustries { get; set; }

        public DbSet<ConsumerJobOffer> ConsumerJobOffers { get; set; }
    }


}