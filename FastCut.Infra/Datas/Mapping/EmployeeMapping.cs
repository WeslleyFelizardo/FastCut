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
            builder.Property(e => e.Brithdate);
            builder.OwnsOne(e => e.Address, address =>
            {
                address.Property(a => a.ZipCode);
                address.Property(a => a.Neighborhood);
                address.Property(a => a.Street);
                address.Property(a => a.City);
                address.Property(a => a.State);
                address.Property(a => a.Country);
                address.Ignore(a => a.Notifications);
            });
            builder.OwnsOne(e => e.Email, email =>
            {
                email.Property(e => e.Address);
                email.Ignore(e => e.Notifications);
            });

            builder.Ignore(e => e.Notifications);
                
        }
    }
}
