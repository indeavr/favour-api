using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace FavourAPI.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class ConsumerController : ControllerBase
    {
        //private readonly IMapper mapper;

        //public ConsumerController(IConsumerService consumerService, IMapper mapper)
        //{
        //    this.mapper = mapper;
        //}

        //public ActionResult<ConsumerDto> GetConsumer()
        //{

        //}
    }
}