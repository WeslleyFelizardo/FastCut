using FastCut.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastCut.Infra.Datas.Mapping
{
    public sealed class EmployeeMapping : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name);
            builder.Property(e => e.Phone);
            //builder.OwnsOne(e => e.Address.City);
            //builder.OwnsOne(e => e.Address.ZipCode);
            //builder.OwnsOne(e => e.Address.Neighborhood);
            //builder.OwnsOne(e => e.Address.Country);
            //builder.OwnsOne(e => e.Address.Street);
            //builder.OwnsOne(e => e.Address.State);
            //builder.OwnsOne(e => e.Email.Address);

            builder.HasMany(e => e.Services);
                
        }
    }
}
