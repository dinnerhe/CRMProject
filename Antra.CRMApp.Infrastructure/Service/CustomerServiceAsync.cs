using System;
using Antra.CRMApp.Core.Contract.Repository;
using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;
using Antra.CRMApp.Core.Entity;

namespace Antra.CRMApp.Infrastructure.Service
{
	public class CustomerServiceAsync: ICustomerServiceAsync
	{
        private readonly ICustomerRepositoryAsync customerRepository;
		public CustomerServiceAsync(ICustomerRepositoryAsync repo)
		{
            customerRepository = repo;
		}

        public async Task<int> AddCustomerAsync(CustomerRequestModel customer)
        {
            Customer c = new Customer();
            c.Name = customer.Name;
            c.Title = customer.Title;
            c.Address = customer.Address;
            c.City = customer.City;
            c.RegionId = customer.RegionId;
            c.PostalCode = customer.PostalCode;
            c.Country = customer.Country;
            c.Phone = customer.Phone;
            return await customerRepository.InsertAsync(c);
        }

        public async Task<int> DeleteCustomerAsync(int id)
        {
            return await customerRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CustomerResponseModel>> GetAllAsync()
        {
            var collection = await customerRepository.GetAllAsync();
            if (collection != null) {
                List<CustomerResponseModel> customerModels = new List<CustomerResponseModel>();
                foreach (var item in collection) {
                    CustomerResponseModel model = new CustomerResponseModel();
                    model.Id = item.Id;
                    model.Name = item.Name;
                    model.Title = item.Title;
                    model.Address = item.Address;
                    model.City = item.City;
                    model.RegionId = item.RegionId;
                    model.PostalCode = item.PostalCode;
                    model.Country = item.Country;
                    model.Phone = item.Phone;
                    customerModels.Add(model);
                }
                return customerModels;
            }
            return null;
        }

        public async Task<CustomerResponseModel> GetByIdAsync(int id)
        {
            var customer = await customerRepository.GetByIdAsync(id);
            if (customer != null) {
                CustomerResponseModel model = new CustomerResponseModel();
                model.Id = customer.Id;
                model.Name = customer.Name;
                model.Title = customer.Title;
                model.Address = customer.Address;
                model.City = customer.City;
                model.RegionId = customer.RegionId;
                model.PostalCode = customer.PostalCode;
                model.Country = customer.Country;
                model.Phone = customer.Phone;
                return model;
            }
            return null;
        }

        public async Task<CustomerRequestModel> GetCustomerForEditAsync(int id)
        {
            var customer = await customerRepository.GetByIdAsync(id);
            if (customer != null)
            {
                CustomerRequestModel model = new CustomerRequestModel();
                model.Id = customer.Id;
                model.Name = customer.Name;
                model.Title = customer.Title;
                model.Address = customer.Address;
                model.RegionId = customer.RegionId;
                model.PostalCode = customer.PostalCode;
                model.Country = customer.Country;
                model.Phone = customer.Phone;
                model.City = customer.City;
                return model;
            }
            return null;
        }

        public async Task<int> UpdateCustomerAsync(CustomerRequestModel customer)
        {
            Customer c = new Customer();
            c.Id = customer.Id;
            c.Name = customer.Name;
            c.Title = customer.Title;
            c.Address = customer.Address;
            c.City = customer.City;
            c.RegionId = customer.RegionId;
            c.PostalCode = customer.PostalCode;
            c.Country = customer.Country;
            c.Phone = customer.Phone;
            return await customerRepository.UpdateAsync(c);
        }
    }
}

