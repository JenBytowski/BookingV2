using Microsoft.AspNetCore.Authorization;

namespace BookinV2API.Controllers
{
    internal class JwtBearerAuthorizationAttribute : AuthorizeAttribute
    {
        public JwtBearerAuthorizationAttribute()
            : base()
        {
            this.AuthenticationSchemes = "Bearer";
        }

        public JwtBearerAuthorizationAttribute(string policy)
            : base(policy)
        {
            this.AuthenticationSchemes = "Bearer";
        }
    }
}
