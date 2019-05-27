﻿// <auto-generated />
using System;
using FavourAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FavourAPI.Data.Migrations
{
    [DbContext(typeof(WorkFavourDbContext))]
    [Migration("20190526193234_removedSkillId")]
    partial class removedSkillId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FavourAPI.Data.Models.Application", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("ConsumerId");

                    b.Property<Guid?>("JobOfferId");

                    b.Property<string>("Message");

                    b.Property<string>("StateValue");

                    b.Property<DateTime>("Time");

                    b.HasKey("Id");

                    b.HasIndex("ConsumerId");

                    b.HasIndex("JobOfferId");

                    b.HasIndex("StateValue");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("FavourAPI.Data.Models.CompanyProvider", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description");

                    b.Property<DateTime>("FoundedYear");

                    b.Property<string>("Name");

                    b.Property<int>("NumberOfEmployees");

                    b.Property<byte[]>("Picture");

                    b.HasKey("Id");

                    b.ToTable("CompanyProviders");
                });

            modelBuilder.Entity("FavourAPI.Data.Models.CompletionResult", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ConsumerId");

                    b.Property<string>("Review");

                    b.HasKey("Id");

                    b.HasIndex("ConsumerId");

                    b.ToTable("Results");
                });

            modelBuilder.Entity("FavourAPI.Data.Models.Consumer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("CV");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<Guid?>("LocationId");

                    b.Property<Guid?>("PhoneNumberId");

                    b.Property<string>("SexValue");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("PhoneNumberId");

                    b.HasIndex("SexValue");

                    b.ToTable("Consumers");
                });

            modelBuilder.Entity("FavourAPI.Data.Models.ConsumerJobOffer", b =>
                {
                    b.Property<Guid>("ConsumerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("JobOfferId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ConsumerId", "JobOfferId");

                    b.HasIndex("JobOfferId");

                    b.ToTable("ConsumerJobOffers");
                });

            modelBuilder.Entity("FavourAPI.Data.Models.Email", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EmailAddress");

                    b.Property<string>("Label");

                    b.Property<Guid?>("OfficeId");

                    b.Property<Guid?>("PersonProviderId");

                    b.HasKey("Id");

                    b.HasIndex("OfficeId");

                    b.HasIndex("PersonProviderId");

                    b.ToTable("Emails");
                });

            modelBuilder.Entity("FavourAPI.Data.Models.Enums.ApplicationStateDb", b =>
                {
                    b.Property<string>("Value")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Value");

                    b.ToTable("ApplicationStates");

                    b.HasData(
                        new
                        {
                            Value = "Pending"
                        },
                        new
                        {
                            Value = "Accepted"
                        },
                        new
                        {
                            Value = "Rejected"
                        });
                });

            modelBuilder.Entity("FavourAPI.Data.Models.Enums.JobOfferStateDb", b =>
                {
                    b.Property<string>("Value")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Value");

                    b.ToTable("JobOfferStates");

                    b.HasData(
                        new
                        {
                            Value = "Available"
                        },
                        new
                        {
                            Value = "Expired"
                        },
                        new
                        {
                            Value = "Failed"
                        },
                        new
                        {
                            Value = "Finished"
                        },
                        new
                        {
                            Value = "Ongoing"
                        });
                });

            modelBuilder.Entity("FavourAPI.Data.Models.Enums.SexDb", b =>
                {
                    b.Property<string>("Value")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Value");

                    b.ToTable("Sexes");
                });

            modelBuilder.Entity("FavourAPI.Data.Models.Industry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CompanyProviderId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CompanyProviderId");

                    b.ToTable("Industries");
                });

            modelBuilder.Entity("FavourAPI.Data.Models.IndustryPosition", b =>
                {
                    b.Property<Guid>("IndustryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PositionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IndustryId", "PositionId");

                    b.HasIndex("PositionId");

                    b.ToTable("IndustryPositions");
                });

            modelBuilder.Entity("FavourAPI.Data.Models.JobOffer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description");

                    b.Property<double>("Money");

                    b.Property<Guid?>("ProviderId");

                    b.Property<Guid?>("ResultId");

                    b.Property<string>("StateValue");

                    b.Property<DateTime>("TimePosted");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("ProviderId");

                    b.HasIndex("ResultId");

                    b.HasIndex("StateValue");

                    b.ToTable("JobOffers");
                });

            modelBuilder.Entity("FavourAPI.Data.Models.JobOfferLocation", b =>
                {
                    b.Property<Guid>("JobOfferId");

                    b.Property<Guid>("LocationId");

                    b.Property<Guid?>("JobOfferId1");

                    b.HasKey("JobOfferId", "LocationId");

                    b.HasIndex("JobOfferId1");

                    b.HasIndex("LocationId");

                    b.ToTable("JobOfferLocations");
                });

            modelBuilder.Entity("FavourAPI.Data.Models.JobPhoto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("JobOfferId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("Photo");

                    b.HasKey("Id");

                    b.HasIndex("JobOfferId");

                    b.ToTable("JobPhotos");
                });

            modelBuilder.Entity("FavourAPI.Data.Models.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Country");

                    b.Property<string>("CustomInfo");

                    b.Property<Guid?>("JobOfferId");

                    b.Property<double?>("Latitude");

                    b.Property<double?>("Longitude");

                    b.Property<string>("Region");

                    b.Property<string>("StreetAddress");

                    b.Property<string>("Town");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.HasIndex("JobOfferId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("FavourAPI.Data.Models.Office", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CompanyProviderId");

                    b.Property<Guid?>("LocationId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CompanyProviderId");

                    b.HasIndex("LocationId");

                    b.ToTable("Offices");
                });

            modelBuilder.Entity("FavourAPI.Data.Models.OfficeIndustry", b =>
                {
                    b.Property<Guid>("IndustryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OfficeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IndustryId", "OfficeId");

                    b.HasIndex("OfficeId");

                    b.ToTable("OfficeIndustries");
                });

            modelBuilder.Entity("FavourAPI.Data.Models.Period", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDate");

                    b.Property<DateTime>("EndHour");

                    b.Property<Guid?>("JobOfferId");

                    b.Property<DateTime>("StartDate");

                    b.Property<DateTime>("StartHour");

                    b.HasKey("Id");

                    b.HasIndex("JobOfferId");

                    b.ToTable("Periods");
                });

            modelBuilder.Entity("FavourAPI.Data.Models.PermissionMy", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("CanApplyConsumer");

                    b.Property<bool>("HasSufficientInfoConsumer");

                    b.Property<bool>("HasSufficientInfoProvider");

                    b.HasKey("Id");

                    b.ToTable("PermissionMys");
                });

            modelBuilder.Entity("FavourAPI.Data.Models.PersonProvider", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description");

                    b.Property<string>("FirstName");

                    b.Property<byte[]>("Image");

                    b.Property<string>("LastName");

                    b.Property<Guid?>("LocationId");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("PersonProviders");
                });

            modelBuilder.Entity("FavourAPI.Data.Models.PhoneNumber", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Label");

                    b.Property<string>("Number");

                    b.Property<Guid?>("OfficeId");

                    b.Property<Guid?>("PersonProviderId");

                    b.HasKey("Id");

                    b.HasIndex("OfficeId");

                    b.HasIndex("PersonProviderId");

                    b.ToTable("PhoneNumbers");
                });

            modelBuilder.Entity("FavourAPI.Data.Models.Position", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CompanyProviderId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CompanyProviderId");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("FavourAPI.Data.Models.PositionSkill", b =>
                {
                    b.Property<Guid>("SkillId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PositionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SkillName");

                    b.HasKey("SkillId", "PositionId");

                    b.HasAlternateKey("PositionId", "SkillId");

                    b.HasIndex("SkillName");

                    b.ToTable("PositionSkills");
                });

            modelBuilder.Entity("FavourAPI.Data.Models.Skill", b =>
                {
                    b.Property<string>("Name")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("ConsumerId");

                    b.Property<Guid?>("JobOfferId");

                    b.HasKey("Name");

                    b.HasIndex("ConsumerId");

                    b.HasIndex("JobOfferId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("FavourAPI.Data.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email");

                    b.Property<string>("Password");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("Token");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FavourAPI.Data.Models.Application", b =>
                {
                    b.HasOne("FavourAPI.Data.Models.Consumer", "Consumer")
                        .WithMany("Applications")
                        .HasForeignKey("ConsumerId");

                    b.HasOne("FavourAPI.Data.Models.JobOffer", "JobOffer")
                        .WithMany("Applications")
                        .HasForeignKey("JobOfferId");

                    b.HasOne("FavourAPI.Data.Models.Enums.ApplicationStateDb", "State")
                        .WithMany("Applications")
                        .HasForeignKey("StateValue");
                });

            modelBuilder.Entity("FavourAPI.Data.Models.CompanyProvider", b =>
                {
                    b.HasOne("FavourAPI.Data.Models.User", "User")
                        .WithOne("CompanyProvider")
                        .HasForeignKey("FavourAPI.Data.Models.CompanyProvider", "Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FavourAPI.Data.Models.CompletionResult", b =>
                {
                    b.HasOne("FavourAPI.Data.Models.Consumer", "Consumer")
                        .WithMany("CompletedJobs")
                        .HasForeignKey("ConsumerId");
                });

            modelBuilder.Entity("FavourAPI.Data.Models.Consumer", b =>
                {
                    b.HasOne("FavourAPI.Data.Models.User", "User")
                        .WithOne("Consumer")
                        .HasForeignKey("FavourAPI.Data.Models.Consumer", "Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FavourAPI.Data.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");

                    b.HasOne("FavourAPI.Data.Models.PhoneNumber", "PhoneNumber")
                        .WithMany()
                        .HasForeignKey("PhoneNumberId");

                    b.HasOne("FavourAPI.Data.Models.Enums.SexDb", "Sex")
                        .WithMany("Consumers")
                        .HasForeignKey("SexValue");
                });

            modelBuilder.Entity("FavourAPI.Data.Models.ConsumerJobOffer", b =>
                {
                    b.HasOne("FavourAPI.Data.Models.Consumer", "Consumer")
                        .WithMany("ConsumerJobOffers")
                        .HasForeignKey("ConsumerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FavourAPI.Data.Models.JobOffer", "JobOffer")
                        .WithMany("ConsumerJobOffers")
                        .HasForeignKey("JobOfferId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FavourAPI.Data.Models.Email", b =>
                {
                    b.HasOne("FavourAPI.Data.Models.Office")
                        .WithMany("Emails")
                        .HasForeignKey("OfficeId");

                    b.HasOne("FavourAPI.Data.Models.PersonProvider")
                        .WithMany("Emails")
                        .HasForeignKey("PersonProviderId");
                });

            modelBuilder.Entity("FavourAPI.Data.Models.Industry", b =>
                {
                    b.HasOne("FavourAPI.Data.Models.CompanyProvider")
                        .WithMany("Industries")
                        .HasForeignKey("CompanyProviderId");
                });

            modelBuilder.Entity("FavourAPI.Data.Models.IndustryPosition", b =>
                {
                    b.HasOne("FavourAPI.Data.Models.Industry", "Industry")
                        .WithMany("IndustryPositions")
                        .HasForeignKey("IndustryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FavourAPI.Data.Models.Position", "Position")
                        .WithMany("IndustryPositions")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FavourAPI.Data.Models.JobOffer", b =>
                {
                    b.HasOne("FavourAPI.Data.Models.CompanyProvider", "Provider")
                        .WithMany("Offers")
                        .HasForeignKey("ProviderId");

                    b.HasOne("FavourAPI.Data.Models.CompletionResult", "Result")
                        .WithMany()
                        .HasForeignKey("ResultId");

                    b.HasOne("FavourAPI.Data.Models.Enums.JobOfferStateDb", "State")
                        .WithMany("JobOffers")
                        .HasForeignKey("StateValue");
                });

            modelBuilder.Entity("FavourAPI.Data.Models.JobOfferLocation", b =>
                {
                    b.HasOne("FavourAPI.Data.Models.JobOffer", "JobOffer")
                        .WithMany()
                        .HasForeignKey("JobOfferId1");

                    b.HasOne("FavourAPI.Data.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FavourAPI.Data.Models.JobPhoto", b =>
                {
                    b.HasOne("FavourAPI.Data.Models.JobOffer", "JobOffer")
                        .WithMany("Photos")
                        .HasForeignKey("JobOfferId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FavourAPI.Data.Models.Location", b =>
                {
                    b.HasOne("FavourAPI.Data.Models.JobOffer")
                        .WithMany("Locations")
                        .HasForeignKey("JobOfferId");
                });

            modelBuilder.Entity("FavourAPI.Data.Models.Office", b =>
                {
                    b.HasOne("FavourAPI.Data.Models.CompanyProvider", "CompanyProvider")
                        .WithMany("Offices")
                        .HasForeignKey("CompanyProviderId");

                    b.HasOne("FavourAPI.Data.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");
                });

            modelBuilder.Entity("FavourAPI.Data.Models.OfficeIndustry", b =>
                {
                    b.HasOne("FavourAPI.Data.Models.Industry", "Industry")
                        .WithMany("OfficeIndustries")
                        .HasForeignKey("IndustryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FavourAPI.Data.Models.Office", "Office")
                        .WithMany("OfficeIndustries")
                        .HasForeignKey("OfficeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FavourAPI.Data.Models.Period", b =>
                {
                    b.HasOne("FavourAPI.Data.Models.JobOffer", "JobOffer")
                        .WithMany("Periods")
                        .HasForeignKey("JobOfferId");
                });

            modelBuilder.Entity("FavourAPI.Data.Models.PermissionMy", b =>
                {
                    b.HasOne("FavourAPI.Data.Models.User", "User")
                        .WithOne("PermissionMy")
                        .HasForeignKey("FavourAPI.Data.Models.PermissionMy", "Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FavourAPI.Data.Models.PersonProvider", b =>
                {
                    b.HasOne("FavourAPI.Data.Models.User", "User")
                        .WithOne("PersonProvider")
                        .HasForeignKey("FavourAPI.Data.Models.PersonProvider", "Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FavourAPI.Data.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");
                });

            modelBuilder.Entity("FavourAPI.Data.Models.PhoneNumber", b =>
                {
                    b.HasOne("FavourAPI.Data.Models.Office")
                        .WithMany("PhoneNumbers")
                        .HasForeignKey("OfficeId");

                    b.HasOne("FavourAPI.Data.Models.PersonProvider")
                        .WithMany("PhoneNumbers")
                        .HasForeignKey("PersonProviderId");
                });

            modelBuilder.Entity("FavourAPI.Data.Models.Position", b =>
                {
                    b.HasOne("FavourAPI.Data.Models.CompanyProvider")
                        .WithMany("TargetedPositions")
                        .HasForeignKey("CompanyProviderId");
                });

            modelBuilder.Entity("FavourAPI.Data.Models.PositionSkill", b =>
                {
                    b.HasOne("FavourAPI.Data.Models.Position", "Position")
                        .WithMany("PositionSkills")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FavourAPI.Data.Models.Skill", "Skill")
                        .WithMany("PositionSkills")
                        .HasForeignKey("SkillName");
                });

            modelBuilder.Entity("FavourAPI.Data.Models.Skill", b =>
                {
                    b.HasOne("FavourAPI.Data.Models.Consumer", "Consumer")
                        .WithMany("Skills")
                        .HasForeignKey("ConsumerId");

                    b.HasOne("FavourAPI.Data.Models.JobOffer")
                        .WithMany("RequiredSkills")
                        .HasForeignKey("JobOfferId");
                });
#pragma warning restore 612, 618
        }
    }
}
