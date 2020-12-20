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
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace ElectronicsShop.BusinessLogic.Services
{
    public class ProductService: IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

		public ProductService(
            IProductRepository productRepository,
            IUnitOfWork unitOfWork,
			IMapper mapper
			)
        {
            this._productRepository = productRepository;
            this._unitOfWork = unitOfWork;
			this._mapper = mapper;
        }

		public GenericCollectionViewModel<ProductViewModel> Get(ConditionFilter<Product, long> condition)
		{
			var entityCollection = this._productRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => _mapper.Map<ProductViewModel>(entity)).ToList();
			var result = new GenericCollectionViewModel<ProductViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		public GenericCollectionViewModel<ProductViewModel> Get(int? pageIndex, int? pageSize)
		{
			ConditionFilter<Product, long> condition = new ConditionFilter<Product, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize
			};
			condition.NavigationProperties.Add("Category");
			var entityCollection = this._productRepository.Get(condition).Include(i=>i.Category).ToList();
			var allCount = this._productRepository.Get().Count();
			var modelCollection = entityCollection.Select(entity => _mapper.Map<ProductViewModel>(entity)).ToList();
			var result = new GenericCollectionViewModel<ProductViewModel>
			{
				Collection = modelCollection,
				TotalCount = allCount,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}


		public ProductViewModel Get(long id)
		{
			var entity = this._productRepository.Get(id);
			var model = _mapper.Map<ProductViewModel>(entity);
			return model;
		}


		public IList<ProductViewModel> Add(IEnumerable<ProductViewModel> collection)
		{

			var entityCollection = collection.Select(model => _mapper.Map<Product>(model));
			entityCollection = this._productRepository.Add(entityCollection).ToList();

			this._unitOfWork.Commit();

			var modelCollection = entityCollection.Select(entity => _mapper.Map<ProductViewModel>(entity)).ToList();
			return modelCollection;
		}

		public ProductViewModel Add(ProductViewModel model)
		{

			var entity = _mapper.Map<Product>(model);
			entity = this._productRepository.Add(entity);

			this._unitOfWork.Commit();

			model = _mapper.Map<ProductViewModel>(entity);
			return model;
		}

		public IList<ProductViewModel> Update(IEnumerable<ProductViewModel> collection)
		{
			var entityCollection = collection.Select(model => _mapper.Map<Product>(model));
			entityCollection = this._productRepository.Update(entityCollection).ToList();

			this._unitOfWork.Commit();

			var modelCollection = entityCollection.Select(entity => _mapper.Map<ProductViewModel>(entity)).ToList();
			return modelCollection;
		}
		public ProductViewModel Update(ProductViewModel model)
		{
			var entity = this._productRepository.Get(model.Id);
			entity.Count = model.Count;
			entity.TwoPiecesDiscount = model.TwoPiecesDiscount;
			entity.Price = model.Price;
			entity.Name = model.Name;
			entity.Description = model.Description;

			entity = this._productRepository.Update(entity);

			this._unitOfWork.Commit();

			model = _mapper.Map<ProductViewModel>(entity);
			return model;
		}

		public void Delete(IEnumerable<ProductViewModel> collection)
		{
			var entityCollection = collection.Select(model => _mapper.Map<Product>(model));
			this._productRepository.Delete(entityCollection);

			this._unitOfWork.Commit();
		}

		public void Delete(IEnumerable<long> collection)
		{
			this._productRepository.Delete(collection);

			this._unitOfWork.Commit();
		}

		public void Delete(ProductViewModel model)
		{
			var entity = _mapper.Map<Product>(model);
			this._productRepository.Delete(entity);

			this._unitOfWork.Commit();
		}

		public void Delete(long id)
		{
			var result = this._productRepository.Delete(id);

			if (result == 0)
				throw new ItemNotFoundException();

			this._unitOfWork.Commit();
		}

	}
}
