using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace IdSvrHostBC.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string SubjectId { get; set; }
      
        // Summary:
        //     Gets or sets the provider name.
        public string ProviderName { get; set; }
        //
        // Summary:
        //     Gets or sets the provider subject identifier.
        public string ProviderSubjectId { get; set; }
        //
        // Summary:
        //     Gets or sets if the user is active.
        public bool IsActive { get; set; }
        //
        // Summary:
        //     Gets or sets the claims.
      //  public ICollection<Claim> Claims { get; set; }
    }
}
