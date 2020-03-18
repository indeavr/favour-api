using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FavourAPI.Data.Models
{
    public class Period
    {
        [Key]
        [Column(TypeName = "uniqueidentifier")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public DateTime StartTime { get; set; } // The aggregation of StartDate + StartHour

        public DateTime EndTime { get; set; } // The aggregation of EndDate + EndHour

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public TimeSpan StartHour { get; set; }

        public TimeSpan EndHour { get; set; }

        public virtual JobOffer JobOffer { get; set; }

        public virtual Offering Offering { get; set; }

        public virtual Application Application { get; set; }
    }
}
