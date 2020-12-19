using ElectronicsShop.Core.Filters;
using ElectronicsShop.Core.Models;
using ElectronicsShop.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicsShop.Core.IServices
{
    public interface IProductService: IBaseService
    {

		GenericCollectionViewModel<ProductViewModel> Get(ConditionFilter<Product, long> condition);

		GenericCollectionViewModel<ProductViewModel> Get(int? pageIndex, int? pageSize);

		ProductViewModel Get(long id);

		IList<ProductViewModel> Add(IEnumerable<ProductViewModel> collection);

		ProductViewModel Add(ProductViewModel model);

		IList<ProductViewModel> Update(IEnumerable<ProductViewModel> collection);

		ProductViewModel Update(ProductViewModel model);

		void Delete(IEnumerable<ProductViewModel> collection);

		void Delete(IEnumerable<long> collection);

		void Delete(ProductViewModel model);

		void Delete(long id);
	}
}
