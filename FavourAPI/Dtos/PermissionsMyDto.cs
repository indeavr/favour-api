using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourAPI.Dtos
{
    public class PermissionsMyDto
    {
        public bool HasSufficientInfoConsumer { get; set; }

        public bool HasSufficientInfoProvider { get; set; }

        public bool CanApplyConsumer { get; set; }
    }
}
