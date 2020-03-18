using System;
using System.Linq;
using AutoMapper;
using FavourAPI.Data;
using FavourAPI.Dtos;
using FavourAPI.Data.Models;
using System.Threading.Tasks;
using FavourAPI.Services.Contracts;
using FavourAPI.Services.Helpers;
using System.Text;
using System.Collections.Generic;

namespace FavourAPI.Services
{
    public class PersonConsumerService : IPersonConsumerService
    {
        private readonly WorkFavourDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IOfficeService officeService;
        private readonly IBlobService blobService;

        public PersonConsumerService(WorkFavourDbContext dbContext, IMapper mapper, IOfficeService officeService, IBlobService blobService)
        {
            this.mapper = mapper;
            this.officeService = officeService;
            this.dbContext = dbContext;
            this.blobService = blobService;
        }

        public async Task<PersonConsumerDto> AddPersonConsumer(string userId, PersonConsumerDto personProvider)
        {
            var dbModel = mapper.Map<PersonConsumer>(personProvider);
            dbModel.Id = Guid.Parse(userId);

            if (personProvider.Photos.Count != 0)
            {
                // TODO
                //foreach (var photoStr in personProvider.Photos)
                //{
                //    var photo = new Image() { ContentType = ContentTypes.JPG_IMAGE, Name = Guid.NewGuid(), Size = photoStr.Length };
                //    var photoName = photo.Name.ToString();
                //    photo.Uri = await this.blobService.UploadImage(photoName, personProvider.ProfilePhoto, profilePhoto.ContentType);
                //    dbModel.ProfilePhoto = profilePhoto;
                //}
            }
            var dbModelInDb = this.dbContext.PersonConsumers.SingleOrDefault(cp => cp.Id == dbModel.Id);

            if (dbModelInDb != null)
            {
                // TODO
                dbModelInDb.Description = dbModel.Description ?? dbModelInDb.Description;
                //this.dbContext.CompanyConsumers.Update(dbModelInDb);
            }
            else
            {
                this.dbContext.PersonConsumers.Add(dbModel);
            }

            await this.dbContext.SaveChangesAsync();

            return mapper.Map<PersonConsumerDto>(dbModel);
        }

        public async Task<PersonConsumerDto> GetById(string userId, bool withPhoto = false)
        {
            Guid userIdGuid = Guid.Parse(userId);
            var consumer = await this.dbContext.PersonConsumers.ToAsyncEnumerable().SingleOrDefault(cp => cp.Id == userIdGuid);
            var consumerDto = this.mapper.Map<PersonConsumerDto>(consumer);
            if (withPhoto)
            {
                // TODO
                //var buffer = await this.blobService.GetImage(consumer.ProfilePhoto.Name.ToString(), consumer.ProfilePhoto.Size);
                //consumerDto.ProfilePhoto = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
            }

            return consumerDto;
        }

        public async Task<string> GetProfilePhoto(string userdId)
        {
            var idAsGuid = Guid.Parse(userdId);

            var user = this.dbContext.CompanyConsumers.SingleOrDefault(u => u.Id == idAsGuid);

            var buffer = await this.blobService.GetImage(user.ProfilePhoto.Name.ToString(), user.ProfilePhoto.Size);

            return Encoding.UTF8.GetString(buffer);
        }

        public ConsumerViewTimeDto GetViewTime(string userId)
        {
            // TODO
            var idAsGuid = Guid.Parse(userId);

            var viewTime = this.dbContext.ConsumerViewTime.SingleOrDefault(vt => vt.Id == idAsGuid);

            return this.mapper.Map<ConsumerViewTimeDto>(viewTime);
        }

        public async Task AddOrUpdateViewTime(string userId, ConsumerViewTimeDto viewTime)
        {
            var idAsGuid = Guid.Parse(userId);

            var currentViewTime = this.dbContext.ConsumerViewTime.FirstOrDefault(vt => vt.Id == idAsGuid);

            if (currentViewTime != null)
            {
                currentViewTime.Applications = viewTime.Applications;
                currentViewTime.OngoingJobOffers = viewTime.OngoingJobOffers;
            }
            else
            {
                var newViewTime = new ConsumerViewTime()
                {
                    Applications = viewTime.Applications,
                    OngoingJobOffers = viewTime.OngoingJobOffers
                };

                await this.dbContext.AddAsync(newViewTime);
            }

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<PersonConsumerDto>> GetAll()
        {
            var allConsumers = await this.dbContext.PersonConsumers.ToAsyncEnumerable().ToArray();
            return allConsumers.Select(cp => mapper.Map<PersonConsumerDto>(cp));
        }

        public async Task<List<ApplicationDto>> GetApplications(string userId)
        {
            PersonConsumerDto consumer = await this.GetById(userId);

            return consumer.Applications;
        }

    }
}
