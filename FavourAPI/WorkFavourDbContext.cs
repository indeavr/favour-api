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