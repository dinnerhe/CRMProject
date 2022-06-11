using System;
using Antra.CRMApp.Core.Model;

namespace Antra.CRMApp.Core.Contract.Service
{
	public interface IVendorServiceAsync
	{
		Task<IEnumerable<VendorResponseModel>> GetAllAsync();
		Task<int> AddVendorAsync(VendorRequestModel model);
		Task<VendorResponseModel> GetByIdAsync(int id);
		Task<VendorRequestModel> GetVendorForEditAsync(int id);
		Task<int> UpdateVendorAsync(VendorRequestModel model);
		Task<int> DeleteVendorAsync(int id);
	}
}

