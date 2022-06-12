using System;
using Antra.CRMApp.Core.Contract.Repository;
using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Entity;
using Antra.CRMApp.Core.Model;

namespace Antra.CRMApp.Infrastructure.Service
{
	public class VendorServiceAsync: IVendorServiceAsync
	{
        private readonly IVendorRepositoryAsync vendorRepository;
		public VendorServiceAsync(IVendorRepositoryAsync repo)
		{
            vendorRepository = repo;
		}

        public async Task<int> AddVendorAsync(VendorRequestModel model)
        {
            Vendor vendor = new Vendor();
            vendor.Name = model.Name;
            vendor.City = model.City;
            vendor.Country = model.Country;
            vendor.Mobile = model.Mobile;
            vendor.EmailId = model.EmailId;
            vendor.IsActive = model.IsActive;
            return await vendorRepository.InsertAsync(vendor);
        }

        public async Task<int> DeleteVendorAsync(int id)
        {
            return await vendorRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<VendorResponseModel>> GetAllAsync()
        {
            var colleciton = await vendorRepository.GetAllAsync();
            if (colleciton != null) {
                List<VendorResponseModel> vendorList = new List<VendorResponseModel>();

                foreach (var item in colleciton) {
                    VendorResponseModel vendorModel = new VendorResponseModel();
                    vendorModel.Id = item.Id;
                    vendorModel.Name = item.Name;
                    vendorModel.City = item.City;
                    vendorModel.Country = item.Country;
                    vendorModel.Mobile = item.Mobile;
                    vendorModel.EmailId = item.EmailId;
                    vendorModel.IsActive = item.IsActive;
                    vendorList.Add(vendorModel);
                }
                return vendorList;

            }
            return null;
        }

        public async Task<VendorResponseModel> GetByIdAsync(int id)
        {
            var item = await vendorRepository.GetByIdAsync(id);
            if (item != null) {
                VendorResponseModel vendorModel = new VendorResponseModel();
                vendorModel.Id = item.Id;
                vendorModel.Name = item.Name;
                vendorModel.City = item.City;
                vendorModel.Country = item.Country;
                vendorModel.Mobile = item.Mobile;
                vendorModel.EmailId = item.EmailId;
                vendorModel.IsActive = item.IsActive;
                return vendorModel;
            }
            return null;
        }

        public async Task<VendorRequestModel> GetVendorForEditAsync(int id)
        {
            var item = await vendorRepository.GetByIdAsync(id);
            if (item != null)
            {
                VendorRequestModel vendorModel = new VendorRequestModel();
                vendorModel.Id = item.Id;
                vendorModel.Name = item.Name;
                vendorModel.City = item.City;
                vendorModel.Country = item.Country;
                vendorModel.Mobile = item.Mobile;
                vendorModel.EmailId = item.EmailId;
                vendorModel.IsActive = item.IsActive;
                return vendorModel;
            }
            return null;
        }

        public async Task<int> UpdateVendorAsync(VendorRequestModel model)
        {
            Vendor vendor = new Vendor();
            vendor.Id = model.Id;
            vendor.Name = model.Name;
            vendor.City = model.City;
            vendor.Country = model.Country;
            vendor.Mobile = model.Mobile;
            vendor.EmailId = model.EmailId;
            vendor.IsActive = model.IsActive;
            return await vendorRepository.UpdateAsync(vendor);
        }
    }
}

