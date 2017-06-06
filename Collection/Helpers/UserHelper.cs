using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Collection.Helpers
{
    public static class UserHelper
    {
        public static string GetUserId(this IPrincipal principal)
        {
            var claimsIdentity = principal.Identity as ClaimsIdentity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            return claim.Value;
        }
    }
}
