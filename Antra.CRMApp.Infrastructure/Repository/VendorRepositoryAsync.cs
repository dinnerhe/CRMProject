using System;
using Antra.CRMApp.Core.Contract.Repository;
using Antra.CRMApp.Core.Entity;
using Antra.CRMApp.Infrastructure.Data;

namespace Antra.CRMApp.Infrastructure.Repository
{
	public class VendorRepositoryAsync: BaseRepository<Vendor>, IVendorRepositoryAsync
	{
		public VendorRepositoryAsync(CrmDbContext _context): base(_context)
		{
		}
	}
}

