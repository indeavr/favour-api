using System;
using System.Globalization;

namespace FavourAPI.Services.Helpers.Exceptions
{
    public class EmailAppException : AppException
    {
        public EmailAppException() : base() { }

        public EmailAppException(string message) : base(message) { }

        public EmailAppException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
