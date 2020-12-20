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
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

		[Route("get-by-condition")]
		[HttpPost]
		public GenericCollectionViewModel<UserViewModel> Get(ConditionFilter<User, long> condition)
		{
			var result = this._userService.Get(condition);
			return result;
		}

		[Route("get-by-pagger/{pageIndex}/{pageSize}")]
		[HttpGet]
		public GenericCollectionViewModel<UserViewModel> Get(int? pageIndex, int? pageSize)
		{
			var result = this._userService.Get(pageIndex, pageSize);
			return result;
		}

		[Route("get/{id}")]
		[HttpGet]
		public UserViewModel Get(long id)
		{
			var result = this._userService.Get(id);
			return result;
		}

		[Route("login")]
		[HttpPost]
		public UserViewModel Login(LoginViewModel model)
        {
			var result = this._userService.Login(model);
			return result;
		}

		[Route("add-collection")]
		[HttpPost]
		public IList<UserViewModel> Add([FromBody] IEnumerable<UserViewModel> collection)
		{
			var result = this._userService.Add(collection);
			return result;
		}

		[Route("add")]
		[HttpPost]
		public UserViewModel Add([FromBody] UserViewModel model)
		{
			var result = this._userService.Add(model);
			return result;
		}

		[Route("update-collection")]
		[HttpPost]
		public IList<UserViewModel> Update([FromBody] IEnumerable<UserViewModel> collection)
		{
			var result = this._userService.Update(collection);
			return result;
		}

		[Route("update")]
		[HttpPost]
		public UserViewModel Update([FromBody] UserViewModel model)
		{
			var result = this._userService.Update(model);
			return result;
		}

		[Route("delete-collection")]
		[HttpPost]
		public void Delete([FromBody] IEnumerable<UserViewModel> collection)
		{
			this._userService.Delete(collection);
		}

		[Route("delete-id-collection")]
		[HttpPost]
		public void Delete([FromBody] IEnumerable<long> collection)
		{
			this._userService.Delete(collection);
		}

		[Route("delete")]
		[HttpPost]
		public void Delete([FromBody] UserViewModel model)
		{
			this._userService.Delete(model);
		}

		[Route("delete/{id}")]
		[HttpPost]
		public void Delete(long id)
		{
			this._userService.Delete(id);
		}
	}
}
