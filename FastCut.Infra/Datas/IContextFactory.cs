using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastCut.Infra.Datas
{
    public interface IContextFactory
    {
        DbContext DbContexto { get; }
    }
}
