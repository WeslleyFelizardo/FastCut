using FastCut.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastCut.Infra.Datas.Mapping
{
    public sealed class RequestServiceMapping : IEntityTypeConfiguration<RequestService>
    {
        public void Configure(EntityTypeBuilder<RequestService> builder)
        {
            builder.HasKey(rs => rs.Id);
            builder.Property(rs => rs.Created);
            
            builder.Ignore(rs => rs.Notifications);
        }
    }
}
