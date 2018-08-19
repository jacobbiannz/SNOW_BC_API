using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdSvrHostBC.Models
{
    public class UserStore
    {
        public UserStore(List<ApplicationUser> users)
        {

        }
        public UserStore()
        {

        }
        public ApplicationUser AutoProvisionUser(string provider, string userId, List<Claim> claims)
        {
            return null;
        }
        public ApplicationUser FindByExternalProvider(string provider, string userId)
        {
            return null;
        }
    }
}
