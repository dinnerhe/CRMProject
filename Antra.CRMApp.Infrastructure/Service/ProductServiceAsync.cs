using Antra.CRMApp.Core.Contract.Repository;
using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Entity;
using Antra.CRMApp.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.CRMApp.Infrastructure.Service
{
    public class ProductServiceAsync : IProductServiceAsync
    {
        private readonly IProductRepositoryAsync productRepositoryAsync;
        private readonly IVendorRepositoryAsync vendorRepository;
        private readonly ICategoryRepositoryAsync categoryRepository;
        public ProductServiceAsync(IProductRepositoryAsync _productRepositoryAsync, IVendorRepositoryAsync _vendor, ICategoryRepositoryAsync _category)
        {
           productRepositoryAsync = _productRepositoryAsync;
            vendorRepository = _vendor;
            categoryRepository = _category;
        }

        public async Task<int> AddProductAsync(ProductRequestModel model)
        {
            Product product = new Product();
            //model.Id = item.Id;
            product.Name = model.Name;
            product.VendorId = model.VendorId;
            product.CategoryId = model.CategoryId;
            product.QuantityPerUnit = model.QuantityPerUnit;
            product.UnitPrice = model.UnitPrice;
            product.UnitsInStock = model.UnitsInStock;
            product.UnitsOnOrder = model.UnitsOnOrder;
            product.ReorderLevel = model.ReorderLevel;
            product.Discontinued = model.Discontinued;
            return await productRepositoryAsync.InsertAsync(product);
        }

        public async Task<int> DeleteProductAsync(int id)
        {
            return await productRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProductResponseModel>> GetAllAsync()
        {
            var collection = await productRepositoryAsync.GetAllAsync();
            if (collection != null)
            {
                List<ProductResponseModel> lst = new List<ProductResponseModel>();
                foreach (var item in collection)
                {
                    ProductResponseModel model = new ProductResponseModel();
                    model.Id = item.Id;
                    model.Name = item.Name;
                    model.VendorId = item.VendorId;
                    model.CategoryId = item.CategoryId;
                    model.QuantityPerUnit = item.QuantityPerUnit;
                    model.UnitPrice = item.UnitPrice;
                    model.UnitsInStock = item.UnitsInStock;
                    model.UnitsOnOrder = item.UnitsOnOrder;
                    model.ReorderLevel = item.ReorderLevel;
                    model.Discontinued = item.Discontinued;
                    var vendorItem = await vendorRepository.GetByIdAsync(item.VendorId);
                    model.vendorResponseModel = new VendorResponseModel() {
                        Id = vendorItem.Id,
                        Name = vendorItem.Name,
                        City = vendorItem.City,
                        Country = vendorItem.Country,
                        Mobile = vendorItem.Mobile,
                        EmailId = vendorItem.EmailId,
                        IsActive = vendorItem.IsActive

                    };
                    var categoryItem = await categoryRepository.GetByIdAsync(item.CategoryId);

                    lst.Add(model);
                }
                return lst;
            }
            return null;
        }

        public async Task<ProductResponseModel> GetByIdAsync(int id)
        {
            var item = await productRepositoryAsync.GetByIdAsync(id);
            if (item != null) {
                ProductResponseModel model = new ProductResponseModel();
                model.Id = item.Id;
                model.Name = item.Name;
                model.VendorId = item.VendorId;
                model.CategoryId = item.CategoryId;
                model.QuantityPerUnit = item.QuantityPerUnit;
                model.UnitPrice = item.UnitPrice;
                model.UnitsInStock = item.UnitsInStock;
                model.UnitsOnOrder = item.UnitsOnOrder;
                model.ReorderLevel = item.ReorderLevel;
                model.Discontinued = item.Discontinued;
                return model;
       
            }
            return null;
        }

        public async Task<ProductRequestModel> GetProductForEditAsync(int id)
        {
            var item = await productRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                ProductRequestModel model = new ProductRequestModel();
                model.Id = item.Id;
                model.Name = item.Name;
                model.VendorId = item.VendorId;
                model.CategoryId = item.CategoryId;
                model.QuantityPerUnit = item.QuantityPerUnit;
                model.UnitPrice = item.UnitPrice;
                model.UnitsInStock = item.UnitsInStock;
                model.UnitsOnOrder = item.UnitsOnOrder;
                model.ReorderLevel = item.ReorderLevel;
                model.Discontinued = item.Discontinued;
                return model;

            }
            return null;
        }

        public async Task<int> UpdateProductAsync(ProductRequestModel model)
        {
            Product product = new Product();
            product.Id = model.Id;
            product.Name = model.Name;
            product.VendorId = model.VendorId;
            product.CategoryId = model.CategoryId;
            product.QuantityPerUnit = model.QuantityPerUnit;
            product.UnitPrice = model.UnitPrice;
            product.UnitsInStock = model.UnitsInStock;
            product.UnitsOnOrder = model.UnitsOnOrder;
            product.ReorderLevel = model.ReorderLevel;
            product.Discontinued = model.Discontinued;
            return await productRepositoryAsync.UpdateAsync(product);
        }
    }
}
