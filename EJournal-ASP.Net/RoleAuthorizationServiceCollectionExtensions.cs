using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace EJournal_ASP.Net
{
    public static class RoleAuthorizationServiceCollectionExtensions
    {
        public static void AddRoleAuthorization<TRoleProvider>(this IServiceCollection services)
            where TRoleProvider : class, IRoleProvider
        {
            services.AddScoped<IRoleProvider, TRoleProvider>();
            services.AddScoped<IClaimsTransformation, RoleAuthorizationTransform>();
        }
    }
}
