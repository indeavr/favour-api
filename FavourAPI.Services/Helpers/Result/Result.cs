using System;
using System.Collections.Generic;
using System.Text;

namespace FavourAPI.Services.Helpers.Result
{
    public abstract class Result<T>
    {
        public abstract ResultType Type { get; }

        public abstract List<string> Errors { get; }

        public abstract T Data { get; }
    }
}
