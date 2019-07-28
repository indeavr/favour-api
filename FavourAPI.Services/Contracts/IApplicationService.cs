using FavourAPI.Dtos;
using FavourAPI.Services.Helpers.Result;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FavourAPI.Services.Contracts
{
    public interface IApplicationService
    {
        Task<Result<object>> Accept(string applicationId);

        Task<Result<object>> ConfirmJobOffer(string applicationId);

        Task<Result<object>> Apply(string userId, string jobOfferId, string message, DateTime time);

        Task<Result<object>> Reject(string applicationId);

        List<ApplicationDto> Get(string jobOfferId);
    }
}
