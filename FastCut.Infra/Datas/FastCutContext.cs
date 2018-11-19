using FastCut.Infra.Datas.Mapping;
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
           base.Database.EnsureCreated();
        }

 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookingMapping());
            modelBuilder.ApplyConfiguration(new EmployeeMapping());
            modelBuilder.ApplyConfiguration(new ServiceMapping());
            modelBuilder.ApplyConfiguration(new RequestServiceMapping());
            modelBuilder.ApplyConfiguration(new ServiceEmployeeMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
