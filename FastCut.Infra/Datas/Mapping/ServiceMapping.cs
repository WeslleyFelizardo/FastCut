using FastCut.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastCut.Infra.Datas.Mapping
{
    public sealed class ServiceMapping : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Name).HasMaxLength(100);
            builder.Property(s => s.Description).HasMaxLength(200);
            builder.Property(s => s.Price).HasColumnType("money");
            builder.Property(s => s.Active);
            builder.Property(s => s.Available);
            builder.Ignore(s => s.Notifications);
        }
    }
}
