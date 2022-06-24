using System;
using Microsoft.AspNetCore.Identity;
namespace Antra.CRMApp.Core.Entity
{
	public class ApplicationUser: IdentityUser
	{
		public string firstName { get; set; }
		public string lastName { get; set; }
		public ApplicationUser()
		{
			
		}
	}
}

