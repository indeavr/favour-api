﻿// <auto-generated />
using System;
using FavourAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FavourAPI.Data.Migrations
{
    [DbContext(typeof(WorkFavourDbContext))]
    partial class WorkFavourDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("Bulstat");

                    b.Property<string>("Description");

                    b.Property<DateTime>("FoundedYear");

                    b.Property<string>("Name");

                    b.Property<int>("NumberOfEmployees");

                    b.Property<Guid?>("ProfilePhotoName");

                    b.HasKey("Id");

                    b.HasIndex("ProfilePhotoName");

                    b.ToTable("CompanyProviders");
                });

            modelBuilder.Entity("FavourAPI.Data.Models.CompletionResult", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ConsumerId");

                    b.Property<string>("ReviewForConsumer");

                    b.Property<string>("ReviewForProvider");

                    b.Property<string>("StateValue");

                    b.HasKey("Id");

                    b.HasIndex("ConsumerId");

                    b.HasIndex("StateValue");

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

                    b.Property<Guid?>("ProfilePhotoName");

                    b.Property<string>("SexValue");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("PhoneNumberId");

                    b.HasIndex("ProfilePhotoName");

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

            modelBuilder.Entity("FavourAPI.Data.Models.Enums.CompletionResultStateDb", b =>
                {
                    b.Property<string>("Value")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Value");

                    b.ToTable("CompletionResultStateDb");
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
                            Value = "Active"
                        },
                        new
                        {
                            Value = "Expired"
                        },
                        new
                        {
                            Value = "Completed"
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

                    b.HasData(
                        new
                        {
                            Value = "Male"
                        },
                        new
                        {
                            Value = "Female"
                        });
                });

            modelBuilder.Entity("FavourAPI.Data.Models.Image", b =>
                {
                    b.Property<Guid>("Name")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ContentType");

                    b.Property<int>("Size");

                    b.Property<string>("Uri");

                    b.HasKey("Name");

                    b.ToTable("Images");
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

                    b.HasData(
                        new
                        {
                            Id = new Guid("48ffce08-54ed-4c5c-9b9c-79300f297098"),
                            Name = "Test industry 1"
                        },
                        new
                        {
                            Id = new Guid("a0066260-96e9-49bc-aa2b-6fdffe00482c"),
                            Name = "Test industry 2"
                        },
                        new
                        {
                            Id = new Guid("e9a2ddf7-9450-4f15-952f-f2fa717e4f5c"),
                            Name = "Test industry 3"
                        },
                        new
                        {
                            Id = new Guid("f67736a5-d6a1-44b6-859c-480c3726192b"),
                            Name = "Test industry 4"
                        },
                        new
                        {
                            Id = new Guid("1478f59a-a2b1-485a-bef5-f1c7025cf358"),
                            Name = "Test industry 5"
                        },
                        new
                        {
                            Id = new Guid("67f03807-e019-4df2-b9b7-7129bc65e876"),
                            Name = "Test industry 6"
                        },
                        new
                        {
                            Id = new Guid("6076e068-1588-4b6b-ba01-182f743b033d"),
                            Name = "Test industry 7"
                        },
                        new
                        {
                            Id = new Guid("db4f5b7f-2c52-4852-bdf7-36529946fa9b"),
                            Name = "Test industry 8"
                        },
                        new
                        {
                            Id = new Guid("931092ff-e7c0-4698-b4be-4ca258cc4ec4"),
                            Name = "Test industry 9"
                        });
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

                    b.HasKey("JobOfferId", "LocationId");

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

                    b.Property<double?>("Latitude");

                    b.Property<double?>("Longitude");

                    b.Property<string>("Region");

                    b.Property<string>("StreetAddress");

                    b.Property<string>("Town");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

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

            modelBuilder.Entity("FavourAPI.Data.Models.Permission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CurrentCount");

                    b.Property<string>("PermissionNameId");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("PermissionNameId");

                    b.HasIndex("UserId", "PermissionNameId")
                        .IsUnique()
                        .HasFilter("[PermissionNameId] IS NOT NULL");

                    b.ToTable("Permissions");
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

            modelBuilder.Entity("FavourAPI.Data.Models.PermissionName", b =>
                {
                    b.Property<string>("Name")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("RoleId");

                    b.HasKey("Name");

                    b.HasIndex("RoleId");

                    b.ToTable("PermissionNames");
                });

            modelBuilder.Entity("FavourAPI.Data.Models.PermissionTransaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date");

                    b.Property<int>("ItemCount");

                    b.Property<double>("MoneyPerItem");

                    b.Property<string>("PermissionName");

                    b.Property<Guid?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("PermissionName");

                    b.HasIndex("UserId");

                    b.ToTable("PermissionTransactions");
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

                    b.HasData(
                        new
                        {
                            Id = new Guid("b46e6e07-a7b6-472b-9a1d-7429f3797202"),
                            Name = "Test position 1"
                        },
                        new
                        {
                            Id = new Guid("d645894b-7820-4bcd-85f4-7bec4ba190f2"),
                            Name = "Test position 2"
                        },
                        new
                        {
                            Id = new Guid("b4728651-382d-4d3d-96c2-a93cbd72e980"),
                            Name = "Test position 3"
                        },
                        new
                        {
                            Id = new Guid("b21037fe-57bd-4b3d-bdb5-e9553dd60531"),
                            Name = "Test position 4"
                        },
                        new
                        {
                            Id = new Guid("40889d94-f0dd-46b4-b7f3-dded74735e07"),
                            Name = "Test position 5"
                        },
                        new
                        {
                            Id = new Guid("41116f1e-b861-41a7-8b12-1bddf27c2088"),
                            Name = "Test position 6"
                        },
                        new
                        {
                            Id = new Guid("d567b94b-3689-453c-af9a-f79be23c2933"),
                            Name = "Test position 7"
                        });
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

            modelBuilder.Entity("FavourAPI.Data.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueIdentifier");

                    b.Property<string>("Name1");

                    b.HasKey("Id");

                    b.HasIndex("Name1");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("FavourAPI.Data.Models.RoleName", b =>
                {
                    b.Property<string>("Name")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Name");

                    b.ToTable("RoleName");
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

                    b.HasData(
                        new
                        {
                            Name = "Test skill 1"
                        },
                        new
                        {
                            Name = "Test skill 2"
                        },
                        new
                        {
                            Name = "Test skill 3"
                        },
                        new
                        {
                            Name = "Test skill 4"
                        },
                        new
                        {
                            Name = "Test skill 5"
                        });
                });

            modelBuilder.Entity("FavourAPI.Data.Models.Subscription", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Amount");

                    b.Property<DateTime>("End");

                    b.Property<Guid?>("RoleId");

                    b.Property<DateTime>("Start");

                    b.Property<Guid?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("Subscriptions");
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

                    b.HasOne("FavourAPI.Data.Models.Image", "ProfilePhoto")
                        .WithMany()
                        .HasForeignKey("ProfilePhotoName");
                });

            modelBuilder.Entity("FavourAPI.Data.Models.CompletionResult", b =>
                {
                    b.HasOne("FavourAPI.Data.Models.Consumer", "Consumer")
                        .WithMany("CompletedJobs")
                        .HasForeignKey("ConsumerId");

                    b.HasOne("FavourAPI.Data.Models.Enums.CompletionResultStateDb", "State")
                        .WithMany("CompletionResults")
                        .HasForeignKey("StateValue");
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

                    b.HasOne("FavourAPI.Data.Models.Image", "ProfilePhoto")
                        .WithMany()
                        .HasForeignKey("ProfilePhotoName");

                    b.HasOne("FavourAPI.Data.Models.Enums.SexDb", "Sex")
                        .WithMany("Consumers")
                        .HasForeignKey("SexValue");
                });

            modelBuilder.Entity("FavourAPI.Data.Models.ConsumerJobOffer", b =>
                {
                    b.HasOne("FavourAPI.Data.Models.Consumer", "Consumer")
                        .WithMany("SavedJobOffers")
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
                        .WithMany("Locations")
                        .HasForeignKey("JobOfferId")
                        .OnDelete(DeleteBehavior.Cascade);

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

            modelBuilder.Entity("FavourAPI.Data.Models.Permission", b =>
                {
                    b.HasOne("FavourAPI.Data.Models.PermissionName", "PermissionName")
                        .WithMany()
                        .HasForeignKey("PermissionNameId");

                    b.HasOne("FavourAPI.Data.Models.User", "User")
                        .WithMany("Permissions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FavourAPI.Data.Models.PermissionMy", b =>
                {
                    b.HasOne("FavourAPI.Data.Models.User", "User")
                        .WithOne("PermissionMy")
                        .HasForeignKey("FavourAPI.Data.Models.PermissionMy", "Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FavourAPI.Data.Models.PermissionName", b =>
                {
                    b.HasOne("FavourAPI.Data.Models.Role")
                        .WithMany("PermissionsForRole")
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("FavourAPI.Data.Models.PermissionTransaction", b =>
                {
                    b.HasOne("FavourAPI.Data.Models.PermissionName", "Permission")
                        .WithMany()
                        .HasForeignKey("PermissionName");

                    b.HasOne("FavourAPI.Data.Models.User", "User")
                        .WithMany("Transactions")
                        .HasForeignKey("UserId");
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

            modelBuilder.Entity("FavourAPI.Data.Models.Role", b =>
                {
                    b.HasOne("FavourAPI.Data.Models.RoleName", "Name")
                        .WithMany()
                        .HasForeignKey("Name1");
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

            modelBuilder.Entity("FavourAPI.Data.Models.Subscription", b =>
                {
                    b.HasOne("FavourAPI.Data.Models.Role", "Role")
                        .WithMany("Subscriptions")
                        .HasForeignKey("RoleId");

                    b.HasOne("FavourAPI.Data.Models.User", "User")
                        .WithMany("Subscriptions")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
