using AutoMapper;
using FavourAPI.Data;
using FavourAPI.Data.Dtos.Favour;
using FavourAPI.Data.Models;
using FavourAPI.Data.Models.Enums;
using FavourAPI.Dtos;
using FavourAPI.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavourAPI.Services.Services
{
    public class OfferingService : IOfferingService //TODO: remove IOfferService
    {
        private readonly WorkFavourDbContext dbContext;
        private readonly IMapper mapper;

        public OfferingService(WorkFavourDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<OfferingDto> AddOffering(string userId, OfferingDto offeringDto)
        {
            offeringDto.Id = null;
            offeringDto.Location.Id = null;
            // Job Offer State is Ignored
            var offering = mapper.Map<Offering>(offeringDto);
            Guid guidUserId = Guid.Parse(userId);
            var position = dbContext.Positions.SingleOrDefault(p => p.Name == offeringDto.Title);

            var provider = dbContext.Providers.SingleOrDefault(u => u.Id == guidUserId);
            offering.Provider = provider;

            // TODO: remove comments
            //favour.Title = position.Name;
            //provider.Favours.Add(favour);

            // TODO: review may be redundant
            this.dbContext.Offerings.Add(offering);

            await this.dbContext.SaveChangesAsync();

            //await this.dbContext.ActiveFavours.AddAsync(new ActiveFavour()
            //{
            //    Off = offering,
            //    Id = offering.Id,
            //    Applications = new List<Application>()
            //});

            await this.dbContext.SaveChangesAsync();

            return this.mapper.Map<OfferingDto>(offering);
        }

        public async Task AddApplication(string consumerId, string offeringId, ApplicationDto applicationDto)
        {
            var application = mapper.Map<Application>(applicationDto);

            Guid guidUserId = Guid.Parse(consumerId);
            Guid guidOfferingId= Guid.Parse(offeringId);

            var consumer = this.dbContext.PersonConsumers.SingleOrDefault(c => c.Id == guidUserId);
            Offering offering= this.dbContext.Offerings.SingleOrDefault(of => of.Id == guidOfferingId);

            application.PersonConsumer = consumer;
            //application.State = new ApplicationStateDb()
            //{
            //    Value = nameof(ApplicationState.Pending)
            //}

            offering.Applications.Add(application);

            await this.dbContext.SaveChangesAsync();
        }

        public List<OfferingDto> GetAllOfferings()
        {
            // TODO: must be Active in the future when we store them correctly
            var offerings = dbContext.Offerings
                .ToList();

            // mahni neshta ot job modela- . inache se polzva samo DTO-to 

            return offerings.Select(o => mapper.Map<OfferingDto>(o)).ToList();
        }

        public async Task<OfferingDto> GetById(string offeringId)
        {
            var idAsGuid = Guid.Parse(offeringId);
            var offeringDb = await this.dbContext.Offerings.FindAsync(offeringId);

            return this.mapper.Map<OfferingDto>(offeringDb);
        }
    }
}
