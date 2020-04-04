using AutoMapper;
using FavourAPI.Data;
using FavourAPI.Data.Dtos.Favour;
using FavourAPI.Data.Models;
using FavourAPI.Data.Models.Enums;
using FavourAPI.Data.Models.Offerings;
using FavourAPI.Dtos;
using FavourAPI.Helpers;
using FavourAPI.Services.Contracts;
using FavourAPI.Services.Helpers.Exceptions;
using FirebaseAdmin.Messaging;
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
        private readonly INotificationManager notificationManager;

        public OfferingService(WorkFavourDbContext dbContext, IMapper mapper, INotificationManager notificationManager)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.notificationManager = notificationManager;
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

            await this.dbContext.ActiveOfferings.AddAsync(new ActiveOffering()
            {
                Offering = offering,
                Id = offering.Id,
                IsDeleted = false,
                Applications = new List<Application>()
            });

            await this.dbContext.SaveChangesAsync();

            return this.mapper.Map<OfferingDto>(offering);
        }

        public async Task AddApplication(string consumerId, string offeringId, ApplicationDto applicationDto)
        {
            var application = mapper.Map<Application>(applicationDto);
            var state = await this.dbContext.ApplicationStates
                .ToAsyncEnumerable()
                .Single(a => a.Value == nameof(ApplicationState.Pending));

            application.State = state;
            application.ApplyTime = DateTime.Now;

            var consumer = this.dbContext.PersonConsumers.SingleOrDefault(c => c.Id == Guid.Parse(consumerId));
            ActiveOffering activeOffering = await this.dbContext.ActiveOfferings
                .ToAsyncEnumerable()
                .SingleOrDefault(of => of.Id == Guid.Parse(offeringId));

            application.PersonConsumer = consumer;

            activeOffering.Applications.Add(application);

            await this.dbContext.SaveChangesAsync();

            // See documentation on defining a message payload.
            var notification = new Notification()
            {
                Title = "You have 1 new application",
                Body = $"{consumer.User.FirstName} applyed for {activeOffering.Offering.Title}"
            };

            var data = new Dictionary<string, string>()
            {

            };

            string firebaseId = activeOffering.Offering.Provider.User.FirebaseId;

            await this.notificationManager.SendNotification(notification, data, firebaseId);
        }

        public async Task ConfirmApplication(string applicationId, List<PeriodDto> finalPeriodsDto)
        {
            var guidId = Guid.Parse(applicationId);
            var application = await this.dbContext.Applications
                .ToAsyncEnumerable()
                .Single(a => a.Id == guidId);

            var activeOffering = application.ActiveOffering;
            if (activeOffering == null)
            {
                throw new InvalidJobOfferStateException("The confirmed job offer was not active");
            }

            var finalPeriods = finalPeriodsDto.Select((periodDto) => this.mapper.Map<Period>(periodDto));

            await this.dbContext.OngoingOfferings.AddAsync(new OngoingOffering()
            {
                PersonConsumer = application.PersonConsumer,
                Offering = activeOffering.Offering,
                FinalPeriods = finalPeriods
            });

            await this.ChangeApplicationState(application, ApplicationState.Accepted);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task Reject(string applicationId)
        {
            var guidId = Guid.Parse(applicationId);
            var application = await this.dbContext.Applications.ToAsyncEnumerable().Single(a => a.Id == guidId);

            await this.ChangeApplicationState(application, ApplicationState.Rejected);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<List<OfferingDto>> GetAllActiveOfferings()
        {
            var activeOfferings = await this.dbContext.ActiveOfferings
                .ToAsyncEnumerable()
                .ToList();

            var offerings = activeOfferings
                .Select((active) => mapper.Map<OfferingDto>(active.Offering))
                .ToList();

            return offerings;
        }

        public async Task<OfferingDto> GetById(string offeringId)
        {
            var idAsGuid = Guid.Parse(offeringId);
            var offeringDb = await this.dbContext.Offerings.FindAsync(offeringId);

            return this.mapper.Map<OfferingDto>(offeringDb);
        }

        // Note that SaveChangesAsync isnt called !
        private async Task ChangeApplicationState(Application application, ApplicationState newState)
        {
            var newStateDb = await this.dbContext.ApplicationStates
                .ToAsyncEnumerable()
                .Single(aps => aps.Value == newState.ToString());

            application.State = newStateDb;
            this.dbContext.Applications.Update(application);
        }
    }
}
