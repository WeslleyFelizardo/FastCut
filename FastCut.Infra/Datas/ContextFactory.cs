using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace FastCut.Infra.Datas
{
    public class ContextFactory : IContextFactory
    {
        private const string TenantIdFieldName = "TenantId";
        private const string DatabaseFieldKeyword = "Database";
        private readonly HttpContext _httpContext;
        private readonly IOptions<ConnectionString> _connectionOptions;
        private readonly IDatabaseManager _databaseManager;
        public ContextFactory(
         IHttpContextAccessor httpContentAccessor,
         IOptions<ConnectionString> connectionOptions,
         IDatabaseManager databaseManager)
        {
            this._httpContext = httpContentAccessor.HttpContext;
            this._connectionOptions = connectionOptions;
            this._databaseManager = databaseManager;
        }
        public DbContext DbContexto => new FastCutContext(ChangeDatabaseNameInConnectionString(this.TenantId).Options);

        // Gets tenant id from HTTP header
        private string TenantId
        {
            get
            {
                if (this._httpContext == null)
                {
                    throw new ArgumentNullException(nameof(this._httpContext));
                }
                string tenantId = this._httpContext.Request.Headers[TenantIdFieldName].ToString();
                if (tenantId == null)
                {
                    throw new ArgumentNullException(nameof(tenantId));
                }
                return tenantId;
            }
        }
        private SqlConnectionStringBuilder MudarBancoDeDadosNaStringConexao()
        {
            var sqlConnectionBuilder = new SqlConnectionStringBuilder(this._connectionOptions.Value.DefaultConnection);
            var tenant = this._databaseManager.GetTenantById(this.TenantId);
            if (tenant == null)
            {
                throw new ArgumentNullException(nameof(tenant));
            }
            // Remove old DataBase name from connection string AND add new one
            sqlConnectionBuilder.Remove(DatabaseFieldKeyword);
            sqlConnectionBuilder.Add(DatabaseFieldKeyword, tenant.Name);

            return sqlConnectionBuilder;
        }

        private DbContextOptionsBuilder<FastCutContext> ChangeDatabaseNameInConnectionString(string tenantId)
        {
            ValidateDefaultConnection();

            // 1. Create Connection String Builder using Default connection string
            var sqlConnectionBuilder = new SqlConnectionStringBuilder(this._connectionOptions.Value.DefaultConnection);

            // 2. Remove old Database Name from connection string
            sqlConnectionBuilder.Remove(DatabaseFieldKeyword);

            // 3. Obtain Database name from DataBaseManager and Add new DB name to 
            sqlConnectionBuilder.Add(DatabaseFieldKeyword, this._databaseManager.GetTenantById(tenantId).Name);

            // 4. Create DbContextOptionsBuilder with new Database name
            var contextOptionsBuilder = new DbContextOptionsBuilder<FastCutContext>();

            contextOptionsBuilder.UseSqlServer(sqlConnectionBuilder.ConnectionString);


            return contextOptionsBuilder;
        }

        private void ValidateDefaultConnection()
        {
            if (string.IsNullOrEmpty(this._connectionOptions.Value.DefaultConnection))
            {
                throw new ArgumentNullException(nameof(this._connectionOptions.Value.DefaultConnection));
            }
        }

        private void ValidateHttpContext()
        {
            if (this._httpContext == null)
            {
                throw new ArgumentNullException(nameof(this._httpContext));
            }
        }

        private static void ValidateTenantId(string tenantId)
        {
            if (tenantId == null)
            {
                throw new ArgumentNullException(nameof(tenantId));
            }

            if (!Guid.TryParse(tenantId, out Guid tenantGuid))
            {
                throw new ArgumentNullException(nameof(tenantId));
            }
        }
    }
}
