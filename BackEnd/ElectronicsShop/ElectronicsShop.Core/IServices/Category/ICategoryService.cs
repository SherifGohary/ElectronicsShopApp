using ElectronicsShop.Core.Filters;
using ElectronicsShop.Core.Models;
using ElectronicsShop.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicsShop.Core.IServices
{
    public interface ICategoryService : IBaseService
    {

		GenericCollectionViewModel<CategoryViewModel> Get(ConditionFilter<Category, long> condition);

		GenericCollectionViewModel<CategoryViewModel> Get(int? pageIndex, int? pageSize);

		CategoryViewModel Get(long id);

		IList<CategoryViewModel> Add(IEnumerable<CategoryViewModel> collection);

		CategoryViewModel Add(CategoryViewModel model);

		IList<CategoryViewModel> Update(IEnumerable<CategoryViewModel> collection);

		CategoryViewModel Update(CategoryViewModel model);

		void Delete(IEnumerable<CategoryViewModel> collection);

		void Delete(IEnumerable<long> collection);

		void Delete(CategoryViewModel model);

		void Delete(long id);

	}
}
