using FavourAPI.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FavourAPI.Services.Helpers.Exceptions
{
    public class InvalidJobOfferStateException : Exception
    {
        public InvalidJobOfferStateException(string currentState, JobOfferState expectedState)
            : base($"For this operation the job offer state should be {nameof(expectedState)} but it actually is {currentState}")
        { }
    }
}
