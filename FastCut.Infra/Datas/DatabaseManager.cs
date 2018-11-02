using FastCut.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FastCut.Infra.Datas
{
    public class DatabaseManager : IDatabaseManager
    {
        /// <summary>
        /// IMPORTANT NOTICE: The solution uses simple dictionary for demo purposes.
        /// The Best "Real-life" solutions would be creating 'RootDataBase' with 
        /// all Tenants Parameters/Options like: TenantName, DatabaseName, other configuration.
        /// </summary>
        private readonly IList<Tenant> inquilinos = new List<Tenant>
        {
            new Tenant()
            {
                Id = Guid.Parse("b0ed668d-7ef2-4a23-a333-94ad278f45d7"),
                Name = "Salao1",
                ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=Salao1;Trusted_Connection=True;MultipleActiveResultSets=true"
            },
            new Tenant()
            {
                Id = Guid.Parse("e7e73238-662f-4da2-b3a5-89f4abb87969"),
                Name =  "Salao2",
                ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=Salao2;Trusted_Connection=True;MultipleActiveResultSets=true"
            },
            new Tenant()
            {
                Id = Guid.NewGuid(),
                Name =  "Salao3",
                ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=Salao3;Trusted_Connection=True;MultipleActiveResultSets=true"
            }
        };

        public Tenant GetTenantById(string tenantId)
        {
            var tenant = this.inquilinos.FirstOrDefault(i => i.Id == Guid.Parse(tenantId));

            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }

            return tenant;
        }
    }
}
