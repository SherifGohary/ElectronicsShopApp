using AutoMapper;
using ElectronicsShop.Common.Exceptions;
using ElectronicsShop.Core.Filters;
using ElectronicsShop.Core.IRepositories;
using ElectronicsShop.Core.IServices;
using ElectronicsShop.Core.Models;
using ElectronicsShop.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElectronicsShop.BusinessLogic.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(
            IUserRepository userRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper
            )
        {
            this._userRepository = userRepository;
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

		public GenericCollectionViewModel<UserViewModel> Get(ConditionFilter<User, long> condition)
		{
			var entityCollection = this._userRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => _mapper.Map<UserViewModel>(entity)).ToList();
			var result = new GenericCollectionViewModel<UserViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		public GenericCollectionViewModel<UserViewModel> Get(int? pageIndex, int? pageSize)
		{
			ConditionFilter<User, long> condition = new ConditionFilter<User, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize
			};
			var allCount = this._userRepository.Get().Count();
			var entityCollection = this._userRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => _mapper.Map<UserViewModel>(entity)).ToList();
			var result = new GenericCollectionViewModel<UserViewModel>
			{
				Collection = modelCollection,
				TotalCount = allCount,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}


		public UserViewModel Get(long id)
		{
			var entity = this._userRepository.Get(id);
			var model = _mapper.Map<UserViewModel>(entity);
			return model;
		}

		public UserViewModel Login(LoginViewModel model)
        {
			ConditionFilter<User, long> condition = new ConditionFilter<User, long>();
			condition.Query = (user => user.UserName == model.UserName && user.Password == model.Password);
			var entity = this._userRepository.Get(condition).FirstOrDefault();
			var result = _mapper.Map<UserViewModel>(entity);
			return result;
		}


		public IList<UserViewModel> Add(IEnumerable<UserViewModel> collection)
		{

			var entityCollection = collection.Select(model => _mapper.Map<User>(model));
			entityCollection = this._userRepository.Add(entityCollection).ToList();

			this._unitOfWork.Commit();

			var modelCollection = entityCollection.Select(entity => _mapper.Map<UserViewModel>(entity)).ToList();
			return modelCollection;
		}

		public UserViewModel Add(UserViewModel model)
		{

			var entity = _mapper.Map<User>(model);
			entity = this._userRepository.Add(entity);

			this._unitOfWork.Commit();

			model = _mapper.Map<UserViewModel>(entity);
			return model;
		}

		public IList<UserViewModel> Update(IEnumerable<UserViewModel> collection)
		{
			var entityCollection = collection.Select(model => _mapper.Map<User>(model));
			entityCollection = this._userRepository.Update(entityCollection).ToList();

			this._unitOfWork.Commit();

			var modelCollection = entityCollection.Select(entity => _mapper.Map<UserViewModel>(entity)).ToList();
			return modelCollection;
		}
		public UserViewModel Update(UserViewModel model)
		{
			var entity = this._userRepository.Get(model.Id);
			entity.FullName = model.FullName;
			//entity.UserName = model.UserName;
			//entity.Password = model.Password;
			entity.Country = model.Country;
			entity.City = model.City;
			entity.Address = model.Address;
			entity.BirthDate = model.BirthDate;
			entity.Email = model.Email;
			entity.PhoneNumber = model.PhoneNumber;


			entity = this._userRepository.Update(entity);

			this._unitOfWork.Commit();

			model = _mapper.Map<UserViewModel>(entity);
			return model;
		}

		public void Delete(IEnumerable<UserViewModel> collection)
		{
			var entityCollection = collection.Select(model => _mapper.Map<User>(model));
			this._userRepository.Delete(entityCollection);

			this._unitOfWork.Commit();
		}

		public void Delete(IEnumerable<long> collection)
		{
			this._userRepository.Delete(collection);

			this._unitOfWork.Commit();
		}

		public void Delete(UserViewModel model)
		{
			var entity = _mapper.Map<User>(model);
			this._userRepository.Delete(entity);

			this._unitOfWork.Commit();
		}

		public void Delete(long id)
		{
			var result = this._userRepository.Delete(id);

			if (result == 0)
				throw new ItemNotFoundException();

			this._unitOfWork.Commit();
		}
	}
}
