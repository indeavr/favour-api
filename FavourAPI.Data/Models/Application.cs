using FavourAPI.Data.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FavourAPI.Data.Models
{
    public class Application
    {
        [Key]
        [DataType("uniqueidentifier")]
        public Guid Id { get; set; }

        public string Message { get; set; }
        public DateTime Time { get; set; }

        public Guid JobOfferId { get; set; }
        public Guid ConsumerId { get; set; }
        public string StateId { get; set; }

        public virtual JobOffer JobOffer { get; set; }
        public virtual Consumer Consumer { get; set; }
        public virtual ApplicationStateDb State { get; set; }
    }
}
