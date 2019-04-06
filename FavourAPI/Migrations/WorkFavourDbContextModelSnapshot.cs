﻿// <auto-generated />
using System;
using FavourAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FavourAPI.Migrations
{
    [DbContext(typeof(WorkFavourDbContext))]
    partial class WorkFavourDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FavourAPI.Models.Application", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConsumerId");

                    b.Property<string>("JobOfferId");

                    b.Property<string>("Message");

                    b.Property<string>("StateValue");

                    b.Property<DateTime>("Time");

                    b.HasKey("Id");

                    b.HasIndex("ConsumerId");

                    b.HasIndex("JobOfferId");

                    b.HasIndex("StateValue");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("FavourAPI.Models.CompanyProvider", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("Description");

                    b.Property<DateTime>("FoundedYear");

                    b.Property<string>("Name");

                    b.Property<int>("NumberOfEmployees");

                    b.Property<byte[]>("Picture");

                    b.HasKey("Id");

                    b.ToTable("CompanyProviders");
                });

            modelBuilder.Entity("FavourAPI.Models.CompletionResult", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConsumerId");

                    b.Property<string>("Review");

                    b.HasKey("Id");

                    b.HasIndex("ConsumerId");

                    b.ToTable("Results");
                });

            modelBuilder.Entity("FavourAPI.Models.Consumer", b =>
                {
                    b.Property<string>("Id");

                    b.Property<byte[]>("CV");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Location");

                    b.Property<string>("PhoneNumberId");

                    b.Property<string>("SexValue");

                    b.HasKey("Id");

                    b.HasIndex("PhoneNumberId");

                    b.HasIndex("SexValue");

                    b.ToTable("Consumers");
                });

            modelBuilder.Entity("FavourAPI.Models.ConsumerJobOffer", b =>
                {
                    b.Property<string>("ConsumerId");

                    b.Property<string>("JobOfferId");

                    b.HasKey("ConsumerId", "JobOfferId");

                    b.HasIndex("JobOfferId");

                    b.ToTable("ConsumerJobOffers");
                });

            modelBuilder.Entity("FavourAPI.Models.Email", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EmailAddress");

                    b.Property<string>("Label");

                    b.Property<string>("OfficeId");

                    b.Property<string>("PersonProviderId");

                    b.HasKey("Id");

                    b.HasIndex("OfficeId");

                    b.HasIndex("PersonProviderId");

                    b.ToTable("Emails");
                });

            modelBuilder.Entity("FavourAPI.Models.Industry", b =>
                {
                    b.Property<string>("Name")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompanyProviderId");

                    b.HasKey("Name");

                    b.HasIndex("CompanyProviderId");

                    b.ToTable("Industries");
                });

            modelBuilder.Entity("FavourAPI.Models.IndustryPosition", b =>
                {
                    b.Property<string>("IndustryId");

                    b.Property<string>("PositionId");

                    b.HasKey("IndustryId", "PositionId");

                    b.HasIndex("PositionId");

                    b.ToTable("IndustryPositions");
                });

            modelBuilder.Entity("FavourAPI.Models.JobOffer", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Location");

                    b.Property<double>("Money");

                    b.Property<string>("ProviderId");

                    b.Property<string>("ResultId");

                    b.Property<string>("StateValue");

                    b.Property<DateTime>("TimePosted");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("ProviderId");

                    b.HasIndex("ResultId");

                    b.HasIndex("StateValue");

                    b.ToTable("JobOffers");
                });

            modelBuilder.Entity("FavourAPI.Models.Office", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompanyProviderId");

                    b.Property<string>("Location");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CompanyProviderId");

                    b.ToTable("Offices");
                });

            modelBuilder.Entity("FavourAPI.Models.OfficeIndustry", b =>
                {
                    b.Property<string>("IndustryId");

                    b.Property<string>("OfficeId");

                    b.HasKey("IndustryId", "OfficeId");

                    b.HasIndex("OfficeId");

                    b.ToTable("OfficeIndustries");
                });

            modelBuilder.Entity("FavourAPI.Models.Period", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EndDate");

                    b.Property<DateTime>("EndHour");

                    b.Property<string>("JobOfferId");

                    b.Property<DateTime>("StartDate");

                    b.Property<DateTime>("StartHour");

                    b.HasKey("Id");

                    b.HasIndex("JobOfferId");

                    b.ToTable("Periods");
                });

            modelBuilder.Entity("FavourAPI.Models.PermissionMy", b =>
                {
                    b.Property<string>("Id");

                    b.Property<bool>("CanApplyConsumer");

                    b.Property<bool>("HasSufficientInfoConsumer");

                    b.Property<bool>("HasSufficientInfoProvider");

                    b.HasKey("Id");

                    b.ToTable("PermissionMys");
                });

            modelBuilder.Entity("FavourAPI.Models.PersonProvider", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("Description");

                    b.Property<string>("FirstName");

                    b.Property<byte[]>("Image");

                    b.Property<string>("LastName");

                    b.Property<string>("Location");

                    b.HasKey("Id");

                    b.ToTable("PersonProviders");
                });

            modelBuilder.Entity("FavourAPI.Models.PhoneNumber", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Label");

                    b.Property<string>("Number");

                    b.Property<string>("OfficeId");

                    b.Property<string>("PersonProviderId");

                    b.HasKey("Id");

                    b.HasIndex("OfficeId");

                    b.HasIndex("PersonProviderId");

                    b.ToTable("PhoneNumbers");
                });

            modelBuilder.Entity("FavourAPI.Models.Position", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompanyProviderId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CompanyProviderId");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("FavourAPI.Models.PositionSkills", b =>
                {
                    b.Property<string>("SkillId");

                    b.Property<string>("PositionId");

                    b.HasKey("SkillId", "PositionId");

                    b.HasIndex("PositionId");

                    b.ToTable("PositionSkills");
                });

            modelBuilder.Entity("FavourAPI.Models.SexDb", b =>
                {
                    b.Property<string>("Value")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Value");

                    b.ToTable("Sexes");
                });

            modelBuilder.Entity("FavourAPI.Models.Skill", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConsumerId");

                    b.Property<string>("JobOfferId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("ConsumerId");

                    b.HasIndex("JobOfferId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("FavourAPI.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Password");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("Token");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FavourAPI.Models.enums.ApplicationStateDb", b =>
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

            modelBuilder.Entity("FavourAPI.Models.enums.JobOfferStateDb", b =>
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

            modelBuilder.Entity("FavourAPI.Models.Application", b =>
                {
                    b.HasOne("FavourAPI.Models.Consumer", "Consumer")
                        .WithMany("Applications")
                        .HasForeignKey("ConsumerId");

                    b.HasOne("FavourAPI.Models.JobOffer", "JobOffer")
                        .WithMany("Applications")
                        .HasForeignKey("JobOfferId");

                    b.HasOne("FavourAPI.Models.enums.ApplicationStateDb", "State")
                        .WithMany("Applications")
                        .HasForeignKey("StateValue");
                });

            modelBuilder.Entity("FavourAPI.Models.CompanyProvider", b =>
                {
                    b.HasOne("FavourAPI.Models.User", "User")
                        .WithOne("CompanyProvider")
                        .HasForeignKey("FavourAPI.Models.CompanyProvider", "Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FavourAPI.Models.CompletionResult", b =>
                {
                    b.HasOne("FavourAPI.Models.Consumer", "Consumer")
                        .WithMany("CompletedJobs")
                        .HasForeignKey("ConsumerId");
                });

            modelBuilder.Entity("FavourAPI.Models.Consumer", b =>
                {
                    b.HasOne("FavourAPI.Models.User", "User")
                        .WithOne("Consumer")
                        .HasForeignKey("FavourAPI.Models.Consumer", "Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FavourAPI.Models.PhoneNumber", "PhoneNumber")
                        .WithMany()
                        .HasForeignKey("PhoneNumberId");

                    b.HasOne("FavourAPI.Models.SexDb", "Sex")
                        .WithMany("Consumers")
                        .HasForeignKey("SexValue");
                });

            modelBuilder.Entity("FavourAPI.Models.ConsumerJobOffer", b =>
                {
                    b.HasOne("FavourAPI.Models.Consumer", "Consumer")
                        .WithMany("ConsumerJobOffers")
                        .HasForeignKey("ConsumerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FavourAPI.Models.JobOffer", "JobOffer")
                        .WithMany("ConsumerJobOffers")
                        .HasForeignKey("JobOfferId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FavourAPI.Models.Email", b =>
                {
                    b.HasOne("FavourAPI.Models.Office")
                        .WithMany("Emails")
                        .HasForeignKey("OfficeId");

                    b.HasOne("FavourAPI.Models.PersonProvider")
                        .WithMany("Emails")
                        .HasForeignKey("PersonProviderId");
                });

            modelBuilder.Entity("FavourAPI.Models.Industry", b =>
                {
                    b.HasOne("FavourAPI.Models.CompanyProvider")
                        .WithMany("Industries")
                        .HasForeignKey("CompanyProviderId");
                });

            modelBuilder.Entity("FavourAPI.Models.IndustryPosition", b =>
                {
                    b.HasOne("FavourAPI.Models.Industry", "Industry")
                        .WithMany("IndustryPositions")
                        .HasForeignKey("IndustryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FavourAPI.Models.Position", "Position")
                        .WithMany("IndustryPositions")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FavourAPI.Models.JobOffer", b =>
                {
                    b.HasOne("FavourAPI.Models.CompanyProvider", "Provider")
                        .WithMany("Offers")
                        .HasForeignKey("ProviderId");

                    b.HasOne("FavourAPI.Models.CompletionResult", "Result")
                        .WithMany()
                        .HasForeignKey("ResultId");

                    b.HasOne("FavourAPI.Models.enums.JobOfferStateDb", "State")
                        .WithMany("JobOffers")
                        .HasForeignKey("StateValue");
                });

            modelBuilder.Entity("FavourAPI.Models.Office", b =>
                {
                    b.HasOne("FavourAPI.Models.CompanyProvider", "CompanyProvider")
                        .WithMany("Offices")
                        .HasForeignKey("CompanyProviderId");
                });

            modelBuilder.Entity("FavourAPI.Models.OfficeIndustry", b =>
                {
                    b.HasOne("FavourAPI.Models.Industry", "Industry")
                        .WithMany("OfficeIndustries")
                        .HasForeignKey("IndustryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FavourAPI.Models.Office", "Office")
                        .WithMany("OfficeIndustries")
                        .HasForeignKey("OfficeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FavourAPI.Models.Period", b =>
                {
                    b.HasOne("FavourAPI.Models.JobOffer", "JobOffer")
                        .WithMany("Periods")
                        .HasForeignKey("JobOfferId");
                });

            modelBuilder.Entity("FavourAPI.Models.PermissionMy", b =>
                {
                    b.HasOne("FavourAPI.Models.User", "User")
                        .WithOne("PermissionMy")
                        .HasForeignKey("FavourAPI.Models.PermissionMy", "Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FavourAPI.Models.PersonProvider", b =>
                {
                    b.HasOne("FavourAPI.Models.User", "User")
                        .WithOne("PersonProvider")
                        .HasForeignKey("FavourAPI.Models.PersonProvider", "Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FavourAPI.Models.PhoneNumber", b =>
                {
                    b.HasOne("FavourAPI.Models.Office")
                        .WithMany("PhoneNumbers")
                        .HasForeignKey("OfficeId");

                    b.HasOne("FavourAPI.Models.PersonProvider")
                        .WithMany("PhoneNumbers")
                        .HasForeignKey("PersonProviderId");
                });

            modelBuilder.Entity("FavourAPI.Models.Position", b =>
                {
                    b.HasOne("FavourAPI.Models.CompanyProvider")
                        .WithMany("TargetedPositions")
                        .HasForeignKey("CompanyProviderId");
                });

            modelBuilder.Entity("FavourAPI.Models.PositionSkills", b =>
                {
                    b.HasOne("FavourAPI.Models.Position", "Position")
                        .WithMany("PositionSkills")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FavourAPI.Models.Skill", "Skill")
                        .WithMany("PositionSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FavourAPI.Models.Skill", b =>
                {
                    b.HasOne("FavourAPI.Models.Consumer", "Consumer")
                        .WithMany("Skills")
                        .HasForeignKey("ConsumerId");

                    b.HasOne("FavourAPI.Models.JobOffer")
                        .WithMany("RequiredSkills")
                        .HasForeignKey("JobOfferId");
                });
#pragma warning restore 612, 618
        }
    }
}
