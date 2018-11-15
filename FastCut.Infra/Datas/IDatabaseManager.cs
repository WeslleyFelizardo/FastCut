using FastCut.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastCut.Infra.Datas
{
    public interface IDatabaseManager
    {
        Tenant GetTenantById(string idTenant);

        IList<Tenant> GetAllTenants();
    }
}
