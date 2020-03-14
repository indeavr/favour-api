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
    public class FavourService: IFavourService
    {
        private readonly WorkFavourDbContext dbContext;
        private readonly IMapper mapper;

        public FavourService(WorkFavourDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<FavourDto> AddFavour(string userId, FavourDto favourDto)
        {
            favourDto.Id = null;
            favourDto.Location.Id = null;
            // Job Offer State is Ignored
            var favour = mapper.Map<Favour>(favourDto);
            Guid guidUserId = Guid.Parse(userId);
            var position = dbContext.Positions.SingleOrDefault(p => p.Name == favourDto.Title);

            var provider = dbContext.PersonConsumers.SingleOrDefault(u => u.Id == guidUserId);

            // TODO: remove comments
            //favour.Title = position.Name;
            //provider.Favours.Add(favour);

            // TODO: review may be redundant
            this.dbContext.Favours.Add(favour);

            await this.dbContext.SaveChangesAsync();

            await this.dbContext.ActiveFavours.AddAsync(new ActiveFavour()
            {
                Favour = favour,
                Id = favour.Id,
                Applications = new List<Application>()
            });

            await this.dbContext.SaveChangesAsync();

            return this.mapper.Map<FavourDto>(favour);
        }

        public async Task AddApplication(string consumerId, string jobOfferId, ApplicationDto applicationDto)
        {
            var application = mapper.Map<Application>(applicationDto);

            Guid guidUserId = Guid.Parse(consumerId);
            Guid guidJobOfferId = Guid.Parse(jobOfferId);

            var consumer = this.dbContext.Providers.SingleOrDefault(c => c.Id == guidUserId);
            var jobOffer = this.dbContext.ActiveJobOffers.SingleOrDefault(job => job.Id == guidJobOfferId);

            application.Provider = consumer;
            application.State = new ApplicationStateDb()
            {
                Value = nameof(ApplicationState.Pending)
            };

            jobOffer.Applications.Add(application);

            await this.dbContext.SaveChangesAsync();
        }

        public List<FavourDto> GetAllFavours()
        {
            // TODO: must be Active in the future when we store them correctly
            var favours = dbContext.Favours
                .ToList();

            // mahni neshta ot job modela- . inache se polzva samo DTO-to 

            return favours.Select(o => mapper.Map<FavourDto>(o)).ToList();
        }

        public async Task<FavourDto> GetById(string favourId)
        {
            var idAsGuid = Guid.Parse(favourId);
            var favourDb = await this.dbContext.JobOffers.FindAsync(favourId);

            return this.mapper.Map<FavourDto>(favourDb);
        }
    }
}
