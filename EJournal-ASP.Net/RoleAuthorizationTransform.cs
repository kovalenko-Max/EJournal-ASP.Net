using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace EJournal_ASP.Net
{
    public class RoleAuthorizationTransform : IClaimsTransformation
    {
        private static readonly string RoleClaimType = $"http://{typeof(RoleAuthorizationTransform).FullName.Replace('.', '/')}/role";
        private readonly IRoleProvider _roleProvider;

        public RoleAuthorizationTransform(IRoleProvider roleProvider)
        {
            _roleProvider = roleProvider ?? throw new ArgumentNullException(nameof(roleProvider));
        }

        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            var oldIdentity = (ClaimsIdentity)principal.Identity;

            var newIdentity = new ClaimsIdentity(
                oldIdentity.Claims,
                oldIdentity.AuthenticationType,
                oldIdentity.NameClaimType,
                RoleClaimType);

            var roles = await _roleProvider.GetUserRolesAsync(newIdentity.Name);
            newIdentity.AddClaims(roles.Select(r => new Claim(RoleClaimType, r)));

            return new ClaimsPrincipal(newIdentity);
        }
    }
}
