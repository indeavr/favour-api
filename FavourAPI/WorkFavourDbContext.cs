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

            //modelBuilder.Entity<Skill>().HasData(new CompanyProvider()
            //{
            //    Id = "8bfc8f4b-050b-41af-a7a2-b15eeb6e0f2e",
            //    Name = "Dao",
            //    Description = "KOt",
            //    FoundedYear = new DateTime(),
            //    NumberOfEmployees = 100,
            //    //Industries = 

            //});

            var user = new User()
            {
                Id="43",
                Email = "gosho",
                Password = "dasds"
            };

            var sex = new SexDb()
            {
                Value = Sex.Slave.ToString()
            };

            var pn = new PhoneNumber()
            {
                Label = "Tilifon",
                Number = "1219412"
            };

            var skills = new List<Skill>();

            skills.Add(new Skill()
            {
                Name = "Gucha",
            });

            var offerState = new JobOfferStateDb()
            {
                Value = JobOfferState.Available.ToString()
            };

            var periods = new List<Period>()
            {
                new Period()
                {
                    StartDate =new DateTime(),
                    EndDate=new DateTime(),
                    StartHour =new DateTime(),
                    EndHour =new DateTime(),
                }
            };

            var applicationState = new ApplicationStateDb()
            {
                Value = ApplicationState.Pending.ToString(),
            };
            var applicationState2 = new ApplicationStateDb()
            {
                Value = ApplicationState.Accepted.ToString(),
            };
            var applicationState3 = new ApplicationStateDb()
            {
                Value = ApplicationState.Rejected.ToString(),
            };

            modelBuilder.Entity<ApplicationStateDb>().HasData(applicationState);
            modelBuilder.Entity<ApplicationStateDb>().HasData(applicationState2);
            modelBuilder.Entity<ApplicationStateDb>().HasData(applicationState3);

            var applications = new List<Application>()
            {
                new Application()
                {
                    Time = new DateTime(),
                    State = applicationState,
                }
            };
            var offers = new List<JobOffer>()
            {
                new JobOffer()
                {
                    Description = "adsadass",
                    Location = "Sofia",
                    Money = 3000,
                    State = offerState,
                    Title = "Anakondioto",
                    TimePosted = new DateTime(),
                    Periods = periods,
                    RequiredSkills = skills,
                    Applications = applications,
                }
            };

            modelBuilder.Entity<SexDb>().HasData(sex);
            modelBuilder.Entity<PhoneNumber>().HasData(pn);
            modelBuilder.Entity<Skill>().HasData(skills);
            modelBuilder.Entity<Application>().HasData(applications);
            modelBuilder.Entity<JobOfferStateDb>().HasData(offerState);
            modelBuilder.Entity<Period>().HasData(periods);
            modelBuilder.Entity<JobOffer>().HasData(offers);


            modelBuilder.Entity<Consumer>().HasData(new Consumer()
            {
                Id = "43",
                FirstName = "Dao",
                LastName = "KOt",
                Sex = sex,
                Location = "Sofia",
                PhoneNumber = pn,
                Skills = skills,
                // Offers = offers,
                Applications = applications
            });

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

    }


}