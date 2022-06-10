using System;
using Antra.CRMApp.Core.Contract.Repository;
using Antra.CRMApp.Core.Entity;
using Antra.CRMApp.Infrastructure.Data;

namespace Antra.CRMApp.Infrastructure.Repository
{
	public class OrderRepositoryAsync: BaseRepository<Order>, IOrderRepositoryAsync
	{
		public OrderRepositoryAsync(CrmDbContext _dbContext): base(_dbContext)
		{
		}
	}
}

