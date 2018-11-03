using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace FastCut.Api.Filters
{
    public class HeaderTenantOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
            {
                operation.Parameters = new List<IParameter>();
            }

            operation.Parameters.Add(new NonBodyParameter
            {

                Name = "TenantId",
                In = "header",
                Description = "Id Tenant",
                Required = true,
                Type = "string",
            });
        }
    }
}

