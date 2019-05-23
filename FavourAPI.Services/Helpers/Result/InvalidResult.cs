using System;
using System.Collections.Generic;
using System.Text;

namespace FavourAPI.Services.Helpers.Result
{
    public class InvalidResult<T> : Result<T>
    {
        private string errors;
        public InvalidResult(string errors)
        {
            this.errors = errors;
        }

        public override ResultType Type => ResultType.Invalid;

        public override List<string> Errors => new List<string> { this.errors ?? "The input was invalid." };

        public override T Data => default(T);
    }
}
