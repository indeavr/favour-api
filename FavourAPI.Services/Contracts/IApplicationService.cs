using FavourAPI.Services.Helpers.Result;
using System;

namespace FavourAPI.Services.Contracts
{
    public interface IApplicationService
    {
        Result<object> Accept(string applicationId);

        Result<object> ConfirmJobOffer(string applicationId);

        Result<object> Apply(string userId, string jobOfferId, string message, DateTime time);

        Result<object> Reject(string applicationId);
    }
}
