using FavourAPI.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FavourAPI.Services.Helpers.Exceptions
{
    public class InvalidJobOfferStateException : Exception
    {
        public InvalidJobOfferStateException(string currentState, string expectedState)
            : base($"For this operation the job offer state should be {expectedState} but it actually is {currentState}")
        { }

        public InvalidJobOfferStateException(string message)
          : base(message)
        { }
    }
}
