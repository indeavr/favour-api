﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.Models
{
    public class Industry
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public ICollection<Position> Positions { get; set; }
    }
}
