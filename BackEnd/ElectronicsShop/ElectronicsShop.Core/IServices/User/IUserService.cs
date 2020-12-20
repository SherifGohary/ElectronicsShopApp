using ElectronicsShop.Core.Filters;
using ElectronicsShop.Core.Models;
using ElectronicsShop.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicsShop.Core.IServices
{
    public interface IUserService : IBaseService
    {
		GenericCollectionViewModel<UserViewModel> Get(ConditionFilter<User, long> condition);

		GenericCollectionViewModel<UserViewModel> Get(int? pageIndex, int? pageSize);

		UserViewModel Get(long id);
		UserViewModel Login(LoginViewModel model);

		IList<UserViewModel> Add(IEnumerable<UserViewModel> collection);

		UserViewModel Add(UserViewModel model);

		IList<UserViewModel> Update(IEnumerable<UserViewModel> collection);

		UserViewModel Update(UserViewModel model);

		void Delete(IEnumerable<UserViewModel> collection);

		void Delete(IEnumerable<long> collection);

		void Delete(UserViewModel model);

		void Delete(long id);
	}
}
