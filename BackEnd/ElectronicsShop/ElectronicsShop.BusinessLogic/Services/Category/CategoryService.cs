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
    public class CategoryService: ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(
            ICategoryRepository categoryRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper
            )
        {
            this._categoryRepository = categoryRepository;
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

		public GenericCollectionViewModel<CategoryViewModel> Get(ConditionFilter<Category, long> condition)
		{
			var entityCollection = this._categoryRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => _mapper.Map<CategoryViewModel>(entity)).ToList();
			var result = new GenericCollectionViewModel<CategoryViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		public GenericCollectionViewModel<CategoryViewModel> Get(int? pageIndex, int? pageSize)
		{
			ConditionFilter<Category, long> condition = new ConditionFilter<Category, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize
			};
			var allCount = this._categoryRepository.Get().Count();
			var entityCollection = this._categoryRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => _mapper.Map<CategoryViewModel>(entity)).ToList();
			var result = new GenericCollectionViewModel<CategoryViewModel>
			{
				Collection = modelCollection,
				TotalCount = allCount,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}


		public CategoryViewModel Get(long id)
		{
			var entity = this._categoryRepository.Get(id);
			var model = _mapper.Map<CategoryViewModel>(entity);
			return model;
		}


		public IList<CategoryViewModel> Add(IEnumerable<CategoryViewModel> collection)
		{

			var entityCollection = collection.Select(model => _mapper.Map<Category>(model));
			entityCollection = this._categoryRepository.Add(entityCollection).ToList();

			this._unitOfWork.Commit();

			var modelCollection = entityCollection.Select(entity => _mapper.Map<CategoryViewModel>(entity)).ToList();
			return modelCollection;
		}

		public CategoryViewModel Add(CategoryViewModel model)
		{

			var entity = _mapper.Map<Category>(model);
			entity = this._categoryRepository.Add(entity);

			this._unitOfWork.Commit();

			model = _mapper.Map<CategoryViewModel>(entity);
			return model;
		}

		public IList<CategoryViewModel> Update(IEnumerable<CategoryViewModel> collection)
		{
			var entityCollection = collection.Select(model => _mapper.Map<Category>(model));
			entityCollection = this._categoryRepository.Update(entityCollection).ToList();

			this._unitOfWork.Commit();

			var modelCollection = entityCollection.Select(entity => _mapper.Map<CategoryViewModel>(entity)).ToList();
			return modelCollection;
		}
		public CategoryViewModel Update(CategoryViewModel model)
		{
			var entity = this._categoryRepository.Get(model.Id);
			entity.Name = model.Name;

			entity = this._categoryRepository.Update(entity);

			this._unitOfWork.Commit();

			model = _mapper.Map<CategoryViewModel>(entity);
			return model;
		}

		public void Delete(IEnumerable<CategoryViewModel> collection)
		{
			var entityCollection = collection.Select(model => _mapper.Map<Category>(model));
			this._categoryRepository.Delete(entityCollection);

			this._unitOfWork.Commit();
		}

		public void Delete(IEnumerable<long> collection)
		{
			this._categoryRepository.Delete(collection);

			this._unitOfWork.Commit();
		}

		public void Delete(CategoryViewModel model)
		{
			var entity = _mapper.Map<Category>(model);
			this._categoryRepository.Delete(entity);

			this._unitOfWork.Commit();
		}

		public void Delete(long id)
		{
			var result = this._categoryRepository.Delete(id);

			if (result == 0)
				throw new ItemNotFoundException();

			this._unitOfWork.Commit();
		}

    }
}
