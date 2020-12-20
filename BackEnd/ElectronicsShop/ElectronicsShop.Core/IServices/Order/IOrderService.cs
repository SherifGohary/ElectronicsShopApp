using ElectronicsShop.Core.Filters;
using ElectronicsShop.Core.Models;
using ElectronicsShop.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicsShop.Core.IServices
{
    public interface IOrderService : IBaseService
    {
		GenericCollectionViewModel<OrderViewModel> Get(ConditionFilter<Order, long> condition);

		GenericCollectionViewModel<OrderViewModel> Get(int? pageIndex, int? pageSize);

		OrderViewModel Get(long id);

		IList<OrderViewModel> Add(IEnumerable<OrderViewModel> collection);

		OrderViewModel Add(OrderViewModel model);

		IList<OrderViewModel> Update(IEnumerable<OrderViewModel> collection);

		OrderViewModel Update(OrderViewModel model);

		void Delete(IEnumerable<OrderViewModel> collection);

		void Delete(IEnumerable<long> collection);

		void Delete(OrderViewModel model);

		void Delete(long id);
	}
}
