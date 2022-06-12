using System;
using Antra.CRMApp.Core.Contract.Repository;
using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Entity;
using Antra.CRMApp.Core.Model;

namespace Antra.CRMApp.Infrastructure.Service
{
	public class CategoryServiceAsync: ICategoryServiceAsync
	{
        private readonly ICategoryRepositoryAsync categoryRepository;

		public CategoryServiceAsync(ICategoryRepositoryAsync repo)
		{
            categoryRepository = repo;
		}

        public async Task<int> AddCategoeyAsync(CategoryModel model)
        {
            Category category = new Category();
            category.Description = model.Description;
            category.Name = model.Name;
            return await categoryRepository.InsertAsync(category);
        }

        public async Task<int> DeleteCategoryAsync(int id)
        {
            return await categoryRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CategoryModel>> GetAllAsync()
        {
            var collection = await categoryRepository.GetAllAsync();
            if (collection != null) {
                List<CategoryModel> categories = new List<CategoryModel>();
                foreach (var item in collection) {
                    CategoryModel model = new CategoryModel();
                    model.Id = item.Id;
                    model.Name = item.Name;
                    model.Description = item.Description;
                    categories.Add(model);
                }
                return categories;
            }
            return null;
        }

        public async Task<CategoryModel> GetByIdAsync(int id)
        {
            var item = await categoryRepository.GetByIdAsync(id);
            if (item != null) {
                CategoryModel model = new CategoryModel();
                model.Id = item.Id;
                model.Name = item.Name;
                model.Description = item.Description;
                return model;
            }
            return null;
        }

        public async Task<CategoryModel> GetCategoryForEditAsync(int id)
        {
            return await GetByIdAsync(id);
        }

        public async Task<int> UpdateCategoryAsync(CategoryModel model)
        {
            Category category = new Category();
            category.Id = model.Id;
            category.Description = model.Description;
            category.Name = model.Name;
            return await categoryRepository.UpdateAsync(category);
        }
    }
}

