﻿using System;
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

namespace FavourAPI.Services
{
    public class ConsumerService : IConsumerService
    {
        private readonly WorkFavourDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IBlobService blobService;

        public ConsumerService(WorkFavourDbContext dbContext, IMapper mapper, [FromServices]IBlobService blobService)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.blobService = blobService;
        }

        // Add for now
        public async Task<bool> AddOrUpdateConsumer(string userId, ConsumerDto consumerData)
        {
            var currentUserInfo = GetConsumer(Guid.Parse(userId));

            var dbConsumer = mapper.Map<Consumer>(consumerData);
            var correctSexDb = this.dbContext.Sexes.First(s => s.Value == dbConsumer.Sex.Value);
            var correctSkills = this.dbContext.Skills.Where(s => dbConsumer.Skills.Any(dbcS => dbcS.Name == s.Name)).ToArray();

            var profilePhoto = new Image() { ContentType = ContentTypes.JPG_IMAGE, Name = Guid.NewGuid(), Size = consumerData.ProfilePhoto.Length };
            profilePhoto.Uri = await this.blobService.UploadImage(profilePhoto.Name.ToString(), Encoding.Default.GetBytes(consumerData.ProfilePhoto), profilePhoto.ContentType);

            dbConsumer.Sex = correctSexDb;
            dbConsumer.Skills = correctSkills;
            dbConsumer.Id = Guid.Parse(userId);
            dbConsumer.ProfilePhoto = profilePhoto;

            var phoneNumberDb = this.dbContext.PhoneNumbers.FirstOrDefault(number => number.Label == consumerData.PhoneNumber);
            if (phoneNumberDb != null)
            {
                dbConsumer.PhoneNumber = phoneNumberDb;
            }

            Guid guidUserId = Guid.Parse(userId);
            var currentUser = this.dbContext.Users.SingleOrDefault(u => u.Id == guidUserId);
            currentUser.PermissionMy.HasSufficientInfoConsumer = true;

            dbContext.Consumers.Add(dbConsumer);

            await dbContext.SaveChangesAsync();
            return CheckForLoginProceedPermission(dbConsumer);
        }

        public async Task<ConsumerDto> GetById(string userId)
        {
            return await this.GetById(userId, true);
        }

        private Consumer GetConsumer(Guid userId)
        {
            return dbContext.Consumers.SingleOrDefault(c => c.Id == userId);
        }

        public async Task<string> GetProfilePhoto(string userdId)
        {
            var idAsGuid = Guid.Parse(userdId);
            var user = this.dbContext.Consumers.SingleOrDefault(u => u.Id == idAsGuid);
            if (user?.ProfilePhoto != null)
            {
                var buffer = await this.blobService.GetImage(user.ProfilePhoto.Name.ToString(), user.ProfilePhoto.Size);
                return Encoding.UTF8.GetString(buffer);
            }
            else
            {
                return null;
            }
        }

        public bool CheckForLoginProceedPermission(Consumer consumer)
        {
            return consumer.FirstName != null && consumer.LastName != null && consumer.PhoneNumber != null;
        }

        public void SaveJobOffer(string userId, string jobOfferId)
        {
            this.dbContext.ConsumerJobOffers.Add(new ConsumerJobOffer()
            {
                JobOfferId = Guid.Parse(jobOfferId),
                ConsumerId = Guid.Parse(userId)
            });

            this.dbContext.SaveChanges();
        }

        public async Task<ConsumerDto> GetById(string userId, bool withPhoto)
        {
            Guid guidUserId = Guid.Parse(userId);
            var consumerDb = GetConsumer(guidUserId);
            var dto = this.mapper.Map<ConsumerDto>(consumerDb);

            if (withPhoto)
            {
                var buffer = await this.blobService.GetImage(consumerDb.ProfilePhoto.Name.ToString(), consumerDb.ProfilePhoto.Size);
                dto.ProfilePhoto = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
            }

            return dto;
        }
    }
}
