using System;
using Antra.CRMApp.Core.Contract.Repository;
using Antra.CRMApp.Core.Entity;
using Antra.CRMApp.Infrastructure.Data;

namespace Antra.CRMApp.Infrastructure.Repository
{
	public class CustomerRepositoryAsync: BaseRepository<Customer>, ICustomerRepositoryAsync
	{
		public CustomerRepositoryAsync(CrmDbContext _dbContext): base(_dbContext)
		{
		}
	}
}

