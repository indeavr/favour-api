using System;
using System.Linq;
using FavourAPI.Dtos;
using AutoMapper;
using FavourAPI.Data.Models;
using FavourAPI.Data;
using Microsoft.AspNetCore.Mvc;
using FavourAPI.Services.Contracts;
using FavourAPI.Services.Helpers;
using System.Threading.Tasks;
using System.Text;
using System.Collections.Generic;
using FavourAPI.Data.Dtos.Favour;
using FavourAPI.Data.Dtos.Offerings;
using FavourAPI.Data.Models.Offerings;

namespace FavourAPI.Services
{
    public class ProviderService : IProviderService
    {
        private readonly WorkFavourDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IBlobService blobService;

        public ProviderService(WorkFavourDbContext dbContext, IMapper mapper, [FromServices]IBlobService blobService)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.blobService = blobService;
        }

        public async Task<ProviderDto> AddProvider(string userId, ProviderDto providerData)
        {
            //var currentUserInfo = this.dbContext.Consumers.SingleOrDefault(u => u.Id == Guid.Parse(userId));

            // TODO Check if positions and skills are correct
            var dbProvider = this.mapper.Map<Provider>(providerData);
            var correctSkills = this.dbContext.Skills.Where(s => dbProvider.Skills.Any(dbcS => dbcS.Name == s.Name)).ToArray();
            var correctPositions = this.dbContext.Positions.Where(s => dbProvider.DesiredPositions.Any(dbcP => dbcP.Name == s.Name)).ToArray();
            var correctSexDb = this.dbContext.Sexes.FirstOrDefault(s => s.Value == providerData.Sex);

            // TODO
            //if (!string.IsNullOrEmpty(providerData.ProfilePhoto))
            //{
            //    var profilePhoto = new Image() { ContentType = ContentTypes.JPG_IMAGE, Name = Guid.NewGuid(), Size = providerData.ProfilePhoto.Length };
            //    profilePhoto.Uri = await this.blobService.UploadImage(profilePhoto.Name, providerData.ProfilePhoto, profilePhoto.ContentType);
            //    dbProvider.ProfilePhoto = profilePhoto;
            //}

            dbProvider.Sex = correctSexDb ?? this.dbContext.Sexes.First();
            dbProvider.Skills = correctSkills;
            dbProvider.DesiredPositions = correctPositions;
            dbProvider.Id = Guid.Parse(userId);
            dbProvider.ActiveOfferings = new List<ActiveOffering>();
            dbProvider.OngoingOfferings = new List<OngoingOffering>();
            dbProvider.CompletedOfferings = new List<CompletedOffering>();

            this.dbContext.Providers.Add(dbProvider);

            await dbContext.SaveChangesAsync();

            return this.mapper.Map<ProviderDto>(dbProvider);
        }

        // Add for now
        public async Task<ProviderDto> AddOrUpdateProvider(string userId, ProviderDto consumerData)
        {
            var currentUserInfo = this.dbContext.Providers.SingleOrDefault(u => u.Id == Guid.Parse(userId));
            var dbConsumer = mapper.Map<Provider>(consumerData);
            var correctSexDb = this.dbContext.Sexes.First(s => s.Value == dbConsumer.Sex.Value);
            var correctSkills = this.dbContext.Skills.Where(s => dbConsumer.Skills.Any(dbcS => dbcS.Name == s.Name)).ToArray();
            var correctPositions = this.dbContext.Positions.Where(s => dbConsumer.DesiredPositions.Any(dbcP => dbcP.Name == s.Name)).ToArray();

            // TODO
            //if (!string.IsNullOrEmpty(consumerData.ProfilePhoto))
            //{
            //    var profilePhoto = new Image() { ContentType = ContentTypes.JPG_IMAGE, Name = Guid.NewGuid(), Size = consumerData.ProfilePhoto.Length };
            //    profilePhoto.Uri = await this.blobService.UploadImage(profilePhoto.Name, consumerData.ProfilePhoto, profilePhoto.ContentType);
            //    dbConsumer.ProfilePhoto = profilePhoto;
            //}

            dbConsumer.Sex = correctSexDb;
            dbConsumer.Skills = correctSkills;
            dbConsumer.DesiredPositions = correctPositions;
            dbConsumer.Id = Guid.Parse(userId);

            var phoneNumberDb = this.dbContext.PhoneNumbers.FirstOrDefault(number => number.Label == consumerData.PhoneNumber);
            if (phoneNumberDb != null)
            {
                dbConsumer.PhoneNumber = phoneNumberDb;
            }

            Guid guidUserId = Guid.Parse(userId);
            var currentUser = this.dbContext.Users.SingleOrDefault(u => u.Id == guidUserId);
            //currentUser.PermissionMy.HasSufficientInfoConsumer = true;

            if (currentUser != null)
            {
                this.dbContext.Users.Update(currentUser);
            }

            if (currentUserInfo != null)
            {
                //currentUserInfo.FirstName = dbConsumer.FirstName;
                //currentUserInfo.LastName = dbConsumer.LastName;
                currentUserInfo.Location = dbConsumer.Location;
                currentUserInfo.PhoneNumber = dbConsumer.PhoneNumber;
                // TODO
                //currentUserInfo.ProfilePhoto = dbConsumer.ProfilePhoto;
                currentUserInfo.Sex = dbConsumer.Sex;
                currentUserInfo.Skills.Where(s => dbConsumer.Skills.Any(s1 => s1.Name == s.Name));
                //currentUserInfo.Experiences = currentUserInfo.Experiences.Where(e => dbConsumer.Experiences.Any(e1 => e.Start == e1.Start && e.End == e1.End))
                //    .Concat(dbConsumer.Experiences)
                //    .Distinct()
                //    .ToList();
                currentUserInfo.Sex = dbConsumer.Sex;

                this.dbContext.Providers.Update(currentUserInfo);
            }
            else
            {
                this.dbContext.Providers.Add(dbConsumer);
            }


            await dbContext.SaveChangesAsync();

            return this.mapper.Map<ProviderDto>(dbConsumer);
            //return CheckForLoginProceedPermission(dbConsumer);
        }

        public async Task<ProviderDto> GetById(string userId)
        {
            var consumer = await this.GetById(userId, true);
            return consumer;
        }



        public async Task<string> GetProfilePhoto(string userdId)
        {
            //var idAsGuid = Guid.Parse(userdId);
            //var user = this.dbContext.Providers.SingleOrDefault(u => u.Id == idAsGuid);

            //if (user?.ProfilePhoto == null)
            //{
            //    return null;
            //}

            //var buffer = await this.blobService.GetImage(user.ProfilePhoto.Name.ToString(), user.ProfilePhoto.Size);

            //return Encoding.UTF8.GetString(buffer);

            return "#Svetlio";
        }

        public bool CheckForLoginProceedPermission(Provider provider)
        {
            // TODO: make it more buletproof
            return provider.PhoneNumber != null && provider.Location != null;
        }

        public async Task SaveJobOffer(string userId, string jobOfferId)
        {
            this.dbContext.SavedJobOffers.Add(new SavedJobOffer()
            {
                JobOfferId = Guid.Parse(jobOfferId),
                ConsumerId = Guid.Parse(userId),
            });

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<ProviderDto> GetById(string userId, bool withPhoto)
        {
            Guid guidUserId = Guid.Parse(userId);
            var providerDb = dbContext.Providers.SingleOrDefault(c => c.Id == guidUserId);

            if (providerDb == null)
            {
                // Log this somewhere
                return null;
            }

            var dto = this.mapper.Map<ProviderDto>(providerDb);

            var completedJobs = ReduceCompletedJobsInformation(dto.CompletedJobOffers);
            dto.CompletedJobOffers = completedJobs;

            // TODO
            //if (withPhoto && providerDb.ProfilePhoto != null)
            //{
            //    try
            //    {
            //        var buffer = await this.blobService.GetImage(providerDb.ProfilePhoto.Name.ToString(), providerDb.ProfilePhoto.Size);
            //        dto.ProfilePhoto = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
            //    }
            //    catch (NullReferenceException e)
            //    {

            //    }
            //}

            return dto;
        }

        private CompletedJobOfferDto[] ReduceCompletedJobsInformation(CompletedJobOfferDto[] completionResults)
        {
            // to be used in future for reducing the amount of data being sent back to the frontend
            return completionResults;
        }

        public async Task<IEnumerable<ProviderDto>> GetAll()
        {
            var providers = await this.dbContext.Providers.ToAsyncEnumerable().ToArray();

            return providers.Select(c => this.mapper.Map<ProviderDto>(c));
        }

        public List<ActiveOfferingDto> GetAllActiveOfferings(string providerId)
        {
            var provider = this.dbContext.Providers.SingleOrDefault(p => p.Id == Guid.Parse(providerId));

            if (provider == null)
            {
                // TODO
            }

            var offeringDtos = provider?.ActiveOfferings?.Select(of => this.mapper.Map<ActiveOfferingDto>(of)).ToList();

            return offeringDtos;
        }

        //Task<ApplicationDto> GetAllApplications(string providerId)
        //{
        //    var provider = this.dbContext.Providers.SingleOrDefault(p => p.Id == Guid.Parse(providerId));

        //    var offerings = provider.Offerings;

        //    var applications = offerings.Select(of => of.Applications)
        //}

        // Only for admins
        //public async Task<ConsumerDto> GetFull()
        //{

        //}

    }
}
