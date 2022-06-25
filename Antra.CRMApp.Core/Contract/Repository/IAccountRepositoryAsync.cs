using System;
using Antra.CRMApp.Core.Model;
using Microsoft.AspNetCore.Identity;

namespace Antra.CRMApp.Core.Contract.Repository
{
	public interface IAccountRepositoryAsync
	{
		Task<IdentityResult> SignUpAsync(SignupModel model);
	}
}

