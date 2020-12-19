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
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            this._productService = productService;
        }

		[Route("get-by-condition")]
		[HttpPost]
		public GenericCollectionViewModel<ProductViewModel> Get(ConditionFilter<Product, long> condition)
		{
			var result = this._productService.Get(condition);
			return result;
		}

		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		public GenericCollectionViewModel<ProductViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._productService.Get(pageIndex, pageSize);
			return result;
		}

		[Route("get/{id}")]
		[HttpGet]
		public ProductViewModel Get(long id)
		{
			var result = this._productService.Get(id);
			return result;
		}

		[Route("add-collection")]
		[HttpPost]
		public IList<ProductViewModel> Add([FromBody] IEnumerable<ProductViewModel> collection)
		{
			var result = this._productService.Add(collection);
			return result;
		}

		[Route("add")]
		[HttpPost]
		public ProductViewModel Add([FromBody] ProductViewModel model)
		{
			var result = this._productService.Add(model);
			return result;
		}

		[Route("update-collection")]
		[HttpPost]
		public IList<ProductViewModel> Update([FromBody] IEnumerable<ProductViewModel> collection)
		{
			var result = this._productService.Update(collection);
			return result;
		}

		[Route("update")]
		[HttpPost]
		public ProductViewModel Update([FromBody] ProductViewModel model)
		{
			var result = this._productService.Update(model);
			return result;
		}

		[Route("delete-collection")]
		[HttpPost]
		public void Delete([FromBody] IEnumerable<ProductViewModel> collection)
		{
			this._productService.Delete(collection);
		}

		[Route("delete-id-collection")]
		[HttpPost]
		public void Delete([FromBody] IEnumerable<long> collection)
		{
			this._productService.Delete(collection);
		}

		[Route("delete")]
		[HttpPost]
		public void Delete([FromBody] ProductViewModel model)
		{
			this._productService.Delete(model);
		}

		[Route("delete/{id}")]
		[HttpPost]
		public void Delete(long id)
		{
			this._productService.Delete(id);
		}
	}
}
