using System;
using System.Linq;
using AutoMapper;
using FavourAPI.Data;
using FavourAPI.Dtos;
using FavourAPI.Data.Models;
using System.Threading.Tasks;
using System.Text;
using FavourAPI.Services.Contracts;
using FavourAPI.Services.Helpers;
using System.Collections.Generic;

namespace FavourAPI.Services
{
    public class CompanyProviderService : ICompanyConsumerService
    {
        private readonly WorkFavourDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IOfficeService officeService;
        private readonly IBlobService blobService;

        public CompanyProviderService(WorkFavourDbContext dbContext, IMapper mapper, IOfficeService officeService, IBlobService blobService)
        {
            this.mapper = mapper;
            this.officeService = officeService;
            this.dbContext = dbContext;
            this.blobService = blobService;
        }

        public async Task<CompanyConsumerDto> AddCompanyConsumer(string userId, CompanyConsumerDto companyProvider)
        {
            var dbModel = mapper.Map<CompanyConsumer>(companyProvider);
            dbModel.Id = Guid.Parse(userId);

            if (!string.IsNullOrEmpty(companyProvider.ProfilePhoto))
            {
                var profilePhoto = new Image() { ContentType = ContentTypes.JPG_IMAGE, Name = Guid.NewGuid(), Size = companyProvider.ProfilePhoto.Length };
                var photoName = profilePhoto.Name.ToString();
                profilePhoto.Uri = await this.blobService.UploadImage(photoName, companyProvider.ProfilePhoto, profilePhoto.ContentType);
                dbModel.ProfilePhoto = profilePhoto;
            }
            var dbModelInDb = this.dbContext.CompanyConsumers.SingleOrDefault(cp => cp.Id == dbModel.Id);

            if (dbModelInDb != null)
            {
                dbModelInDb.Name = dbModel.Name ?? dbModelInDb.Name;
                dbModelInDb.NumberOfEmployees = dbModel.NumberOfEmployees;
                dbModelInDb.ProfilePhoto = dbModel.ProfilePhoto ?? dbModelInDb.ProfilePhoto;
                dbModelInDb.FoundedYear = dbModel.FoundedYear;
                dbModelInDb.Description = dbModel.Description ?? dbModelInDb.Description;
                dbModelInDb.Bulstat = dbModel.Bulstat ?? dbModelInDb.Bulstat;
                dbModelInDb.Industries.Where(i => dbModel.Industries.Any(dbMI => dbMI.Name == i.Name));

                this.dbContext.CompanyConsumers.Update(dbModelInDb);
            }
            else
            {
                this.dbContext.CompanyConsumers.Add(dbModel);
            }

            await this.dbContext.SaveChangesAsync();


            foreach (var office in dbModel.Offices)
            {
                await this.officeService.AddIndustriesForOffice(office);
            }

            return mapper.Map<CompanyConsumerDto>(dbModel);
        }

        public async Task<CompanyConsumerDto> GetConsumer(string userId, bool withPhoto)
        {
            Guid userIdGuid = Guid.Parse(userId);
            var provider = this.dbContext.CompanyConsumers.SingleOrDefault(cp => cp.Id == userIdGuid);
            var providerDto = this.mapper.Map<CompanyConsumerDto>(provider);
            if (withPhoto)
            {
                var buffer = await this.blobService.GetImage(provider.ProfilePhoto.Name.ToString(), provider.ProfilePhoto.Size);
                providerDto.ProfilePhoto = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
            }
            if (providerDto != null)
            {
                providerDto.Offices = providerDto.Offices.Select(o =>
                {
                    o.Industries = this.dbContext.OfficeIndustries
                    .Where(oi => oi.OfficeId == new Guid(o.Id))
                    .Select(oi => mapper.Map<IndustryDto>(oi.Industry)).ToArray();
                    return o;
                }).ToArray();
            }


            return providerDto;
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
            var idAsGuid = Guid.Parse(userId);

            var viewTime = this.dbContext.ProviderViewTimes.SingleOrDefault(vt => vt.Id == idAsGuid);

            return this.mapper.Map<ConsumerViewTimeDto>(viewTime);
        }

        public async Task AddOrUpdateViewTime(string userId, ConsumerViewTimeDto viewTime)
        {
            var idAsGuid = Guid.Parse(userId);

            var currentViewTime = this.dbContext.ProviderViewTimes.FirstOrDefault(vt => vt.Id == idAsGuid);

            if (currentViewTime != null)
            {
                currentViewTime.Applications = viewTime.Applications;
                currentViewTime.OngoingJobOffers = viewTime.OngoingJobOffers;
            }
            else
            {
                var newViewTime = new ProviderViewTime()
                {
                    Applications = viewTime.Applications,
                    OngoingJobOffers = viewTime.OngoingJobOffers
                };

                await this.dbContext.AddAsync(newViewTime);
            }

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<CompanyConsumerDto>> GetAll()
        {
            var allProviders = await this.dbContext.CompanyConsumers.ToAsyncEnumerable().ToArray();
            return allProviders.Select(cp => mapper.Map<CompanyConsumerDto>(cp));
        }
    }
}
