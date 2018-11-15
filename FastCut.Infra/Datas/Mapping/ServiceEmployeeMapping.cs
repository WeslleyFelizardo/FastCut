using FastCut.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastCut.Infra.Datas.Mapping
{
    public sealed class ServiceEmployeeMapping : IEntityTypeConfiguration<ServiceEmployee>
    {
        public void Configure(EntityTypeBuilder<ServiceEmployee> builder)
        {
            builder.HasKey(se => new { se.ServiceId, se.EmployeeId });
            builder.HasOne(se => se.Employee);
            builder.HasOne(se => se.Service);
        }
    }
}
