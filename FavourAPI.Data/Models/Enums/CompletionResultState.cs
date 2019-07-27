using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FavourAPI.Data.Models.Enums
{
    public enum CompletionResultState
    {
        Success,
        Fail
    }

    public class CompletionResultStateDb
    {
        [Key]
        public string Value { get; set; }

        public virtual ICollection<CompletionResult> CompletionResults { get; set; }
    }
}
