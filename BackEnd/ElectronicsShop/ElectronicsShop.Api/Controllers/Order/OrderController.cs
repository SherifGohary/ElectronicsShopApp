using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectronicsShop.Core.Filters;
using ElectronicsShop.Core.IServices;
using ElectronicsShop.Core.Models;
using ElectronicsShop.Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicsShop.Api.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class OrderController : BaseController
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            this._orderService = orderService;
        }

		[Route("get-by-condition")]
		[HttpPost]
		public GenericCollectionViewModel<OrderViewModel> Get(ConditionFilter<Order, long> condition)
		{
			var result = this._orderService.Get(condition);
			return result;
		}

		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		public GenericCollectionViewModel<OrderViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._orderService.Get(pageIndex, pageSize);
			return result;
		}

		[Route("get/{id}")]
		[HttpGet]
		public OrderViewModel Get(long id)
		{
			var result = this._orderService.Get(id);
			return result;
		}

		[Route("add-collection")]
		[HttpPost]
		public IList<OrderViewModel> Add([FromBody] IEnumerable<OrderViewModel> collection)
		{
			var result = this._orderService.Add(collection);
			return result;
		}

		[Route("add")]
		[HttpPost]
		public OrderViewModel Add([FromBody] OrderViewModel model)
		{
			var result = this._orderService.Add(model);
			return result;
		}

		[Route("update-collection")]
		[HttpPost]
		public IList<OrderViewModel> Update([FromBody] IEnumerable<OrderViewModel> collection)
		{
			var result = this._orderService.Update(collection);
			return result;
		}

		[Route("update")]
		[HttpPost]
		public OrderViewModel Update([FromBody] OrderViewModel model)
		{
			var result = this._orderService.Update(model);
			return result;
		}

		[Route("delete-collection")]
		[HttpPost]
		public void Delete([FromBody] IEnumerable<OrderViewModel> collection)
		{
			this._orderService.Delete(collection);
		}

		[Route("delete-id-collection")]
		[HttpPost]
		public void Delete([FromBody] IEnumerable<long> collection)
		{
			this._orderService.Delete(collection);
		}

		[Route("delete")]
		[HttpPost]
		public void Delete([FromBody] OrderViewModel model)
		{
			this._orderService.Delete(model);
		}

		[Route("delete/{id}")]
		[HttpPost]
		public void Delete(long id)
		{
			this._orderService.Delete(id);
		}
	}
}
