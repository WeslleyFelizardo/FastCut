using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastCut.Infra.Datas
{
    public class FastCutContext : DbContext, IDbContext
    {
        public FastCutContext(DbContextOptions<FastCutContext> options)
            : base(options)
        {
        }
    }
}
