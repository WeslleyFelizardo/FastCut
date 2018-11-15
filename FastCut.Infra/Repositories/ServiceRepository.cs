using FastCut.Domain.Entities;
using FastCut.Domain.Repositories;
using FastCut.Infra.Datas;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastCut.Infra.Repositories
{
    public class ServiceRepository : BaseRepository<Service>, IServiceRepository
    {
        private readonly DbContext _context;

        public ServiceRepository(IContextFactory contextFactory) : base(contextFactory)
        {
        }

    }
}
