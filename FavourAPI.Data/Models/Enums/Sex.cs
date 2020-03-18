﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.Data.Models.Enums
{
    public enum Sex
    {
        Male,
        Female,
        Pederas,
        Lesbi,
        Slave
    }

    public class SexDb
    {
        [Key]
        public string Value { get; set; }

        public virtual ICollection<Provider> Providers { get; set; }

        public virtual ICollection<PersonConsumer> PersonConsumers { get; set; }

        //public virtual ICollection<Consumer> Consumer { get; set; }
    }
}
