using FastCut.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastCut.Infra.Datas.Mapping
{
    public sealed class BookingMapping : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Created);
            builder.Property(b => b.IdUser);
            builder.Property(b => b.UserName);
            builder.Ignore(b => b.Notifications);

            builder.HasMany(b => b.RequestServices);
            
        }
    }
}
