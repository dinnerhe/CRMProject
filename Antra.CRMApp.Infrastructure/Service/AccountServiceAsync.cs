using System;
using Antra.CRMApp.Core.Contract.Repository;
using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;
using Microsoft.AspNetCore.Identity;

namespace Antra.CRMApp.Infrastructure.Service
{
	public class AccountServiceAsync: IAccountServiceAsync
	{
        private readonly IAccountRepositoryAsync accountRepositoryAsync;
		public AccountServiceAsync(IAccountRepositoryAsync repo)
		{
            accountRepositoryAsync = repo;
		}

        public async Task<IdentityResult> SingUpAsync(SignupModel model)
        {
            return await accountRepositoryAsync.SignUpAsync(model);
        }
    }
}

