using System;
using System.Globalization;

namespace FavourAPI.Services.Helpers.Exceptions
{
    public class PasswordAppException : AppException
    {
        public PasswordAppException() : base() { }

        public PasswordAppException(string message) : base(message) { }

        public PasswordAppException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
