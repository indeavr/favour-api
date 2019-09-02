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
    [Migration("20190731214040_experiences")]
    partial class experiences
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

            modelBuilder.Entity("FavourAPI.Data.Models.Experience", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CompanyName");

                    b.Property<Guid?>("ConsumerId");

                    b.Property<bool>("CurrentlyWorking");

                    b.Property<string>("Description");

                    b.Property<DateTime>("End");

                    b.Property<Guid?>("PositionId");

                    b.Property<DateTime>("Start");

                    b.HasKey("Id");

                    b.HasIndex("ConsumerId");

                    b.HasIndex("PositionId");

                    b.ToTable("Experiences");
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
                            Id = new Guid("ccdb8e70-fc1a-4b5b-85e7-3c81f2f6bb3e"),
                            Name = "Test industry 1"
                        },
                        new
                        {
                            Id = new Guid("31649137-c730-440a-adf9-66408d40e0b5"),
                            Name = "Test industry 2"
                        },
                        new
                        {
                            Id = new Guid("a9f33af7-b07b-48bd-9642-f893ad5950fe"),
                            Name = "Test industry 3"
                        },
                        new
                        {
                            Id = new Guid("a71d6fdc-94ea-468f-948a-af5238aca71c"),
                            Name = "Test industry 4"
                        },
                        new
                        {
                            Id = new Guid("59cd3ae8-80b1-4bbf-8877-65bab77a6886"),
                            Name = "Test industry 5"
                        },
                        new
                        {
                            Id = new Guid("08fa6477-205c-47d8-bca5-32653e8bc092"),
                            Name = "Test industry 6"
                        },
                        new
                        {
                            Id = new Guid("9b66ffce-2380-4e5d-8575-ef450fbe3a57"),
                            Name = "Test industry 7"
                        },
                        new
                        {
                            Id = new Guid("24906b82-3665-4405-89e1-1beef734964e"),
                            Name = "Test industry 8"
                        },
                        new
                        {
                            Id = new Guid("7d97fe69-40dc-4f58-8805-7419c8aa0068"),
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
                            Id = new Guid("ecbe3889-3f30-4149-b466-e9771cd5f13c"),
                            Name = "Test position 1"
                        },
                        new
                        {
                            Id = new Guid("a72443c7-d61d-4ce9-bb6e-a6796cec9ce3"),
                            Name = "Test position 2"
                        },
                        new
                        {
                            Id = new Guid("45be74d3-425d-4b35-84f7-d0d0be667421"),
                            Name = "Test position 3"
                        },
                        new
                        {
                            Id = new Guid("d3113932-28bf-4069-a81f-f11e14060440"),
                            Name = "Test position 4"
                        },
                        new
                        {
                            Id = new Guid("84ab9449-cc67-4759-a87b-e6e21b548f58"),
                            Name = "Test position 5"
                        },
                        new
                        {
                            Id = new Guid("351c4899-2df1-4bfb-99e0-b3add2f980b0"),
                            Name = "Test position 6"
                        },
                        new
                        {
                            Id = new Guid("dc5171a2-5725-499d-9b08-3c2f608f7472"),
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

            modelBuilder.Entity("FavourAPI.Data.Models.ProviderViewTime", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Applications");

                    b.Property<DateTime>("OngoingJobOffers");

                    b.HasKey("Id");

                    b.ToTable("ProviderViewTimes");
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

            modelBuilder.Entity("FavourAPI.Data.Models.Experience", b =>
                {
                    b.HasOne("FavourAPI.Data.Models.Consumer", "Consumer")
                        .WithMany("Experiences")
                        .HasForeignKey("ConsumerId");

                    b.HasOne("FavourAPI.Data.Models.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId");
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