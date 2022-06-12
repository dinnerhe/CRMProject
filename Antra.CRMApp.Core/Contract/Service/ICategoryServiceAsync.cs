using System;
using Antra.CRMApp.Core.Model;

namespace Antra.CRMApp.Core.Contract.Service
{
	public interface ICategoryServiceAsync
	{
		Task<IEnumerable<CategoryModel>> GetAllAsync();
		Task<int> AddCategoeyAsync(CategoryModel model);
		Task<CategoryModel> GetByIdAsync(int id);
		Task<CategoryModel> GetCategoryForEditAsync(int id);
		Task<int> UpdateCategoryAsync(CategoryModel model);
		Task<int> DeleteCategoryAsync(int id);
	}
}

