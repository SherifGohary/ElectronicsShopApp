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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }


		[Route("get-by-condition")]
		[HttpPost]
		public GenericCollectionViewModel<CategoryViewModel> Get(ConditionFilter<Category, long> condition)
		{
			var result = this._categoryService.Get(condition);
			return result;
		}

		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		public GenericCollectionViewModel<CategoryViewModel> Get(int? pageIndex, int? pageSize)
		
		{
			var result = this._categoryService.Get(pageIndex, pageSize);
			return result;
		}

		[Route("get/{id}")]
		[HttpGet]
		public CategoryViewModel Get(long id)
		{
			var result = this._categoryService.Get(id);
			return result;
		}

		[Route("add-collection")]
		[HttpPost]
		public IList<CategoryViewModel> Add([FromBody] IEnumerable<CategoryViewModel> collection)
		{
			var result = this._categoryService.Add(collection);
			return result;
		}

		[Route("add")]
		[HttpPost]
		public CategoryViewModel Add([FromBody] CategoryViewModel model)
		{
			var result = this._categoryService.Add(model);
			return result;
		}

		[Route("update-collection")]
		[HttpPost]
		public IList<CategoryViewModel> Update([FromBody] IEnumerable<CategoryViewModel> collection)
		{
			var result = this._categoryService.Update(collection);
			return result;
		}

		[Route("update")]
		[HttpPost]
		public CategoryViewModel Update([FromBody] CategoryViewModel model)
		{
			var result = this._categoryService.Update(model);
			return result;
		}

		[Route("delete-collection")]
		[HttpPost]
		public void Delete([FromBody] IEnumerable<CategoryViewModel> collection)
		{
			this._categoryService.Delete(collection);
		}

		[Route("delete-id-collection")]
		[HttpPost]
		public void Delete([FromBody] IEnumerable<long> collection)
		{
			this._categoryService.Delete(collection);
		}

		[Route("delete")]
		[HttpPost]
		public void Delete([FromBody] CategoryViewModel model)
		{
			this._categoryService.Delete(model);
		}

		[Route("delete/{id}")]
		[HttpPost]
		public void Delete(long id)
		{
			this._categoryService.Delete(id);
		}
	}
}
