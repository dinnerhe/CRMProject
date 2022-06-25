using System;
using Microsoft.AspNetCore.Identity;
namespace Antra.CRMApp.Core.Entity
{
	public class ApplicationUser: IdentityUser
	{
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

