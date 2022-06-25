using System;
using Antra.CRMApp.Core.Contract.Repository;
using Antra.CRMApp.Core.Entity;
using Antra.CRMApp.Core.Model;
using Antra.CRMApp.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;

namespace Antra.CRMApp.Infrastructure.Repository
{
    public class AccountRepositoryAsync : IAccountRepositoryAsync
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly CrmDbContext db;

        public AccountRepositoryAsync(CrmDbContext _dbContext, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            db = _dbContext;
        }

        public async Task<IdentityResult> SignUpAsync(SignupModel model)
        {
            ApplicationUser user = new ApplicationUser();
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.EmailId;
            user.UserName = model.EmailId;
            return await _userManager.CreateAsync(user, model.Password);
        }
    }

    
	
}

