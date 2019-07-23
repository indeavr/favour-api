using System;
using System.Collections.Generic;
using System.Text;

namespace FavourAPI.Services.Helpers.Result
{
    public class CorrectResult<T> : Result<T>
    {
        private readonly T data;
        public CorrectResult(T data)
        {
            this.data = data;
        }

        public override ResultType Type => ResultType.Ok;

        public override List<string> Errors => new List<string>();

        public override T Data => this.data;
    }
}
