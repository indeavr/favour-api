using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace FavourAPI.Data.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly WorkFavourDbContext dbContext;
        protected readonly IMapper mapper;

        public BaseRepository(WorkFavourDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
    }
}
