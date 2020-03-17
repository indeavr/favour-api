using FavourAPI.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FavourAPI.Data.Models
{
    public class Application
    {
        [Key]
        //[Column(TypeName = "uniqueidentifier")]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataType("uniqueidentifier")]
        public Guid Id { get; set; }

        public string Message { get; set; }

        public virtual List<Period> Time { get; set; }

        public DateTime ApplyTime { get; set; }

        public virtual ActiveJobOffer ActiveJobOffer { get; set; }

        public virtual PersonConsumer PersonConsumer { get; set; }

        public virtual ApplicationStateDb State { get; set; }

        public virtual Offering Offering { get; set; }
    }
}
