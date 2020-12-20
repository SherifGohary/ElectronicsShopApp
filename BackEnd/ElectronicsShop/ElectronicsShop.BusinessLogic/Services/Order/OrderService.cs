using AutoMapper;
using ElectronicsShop.Common.Exceptions;
using ElectronicsShop.Core.Filters;
using ElectronicsShop.Core.IRepositories;
using ElectronicsShop.Core.IServices;
using ElectronicsShop.Core.Models;
using ElectronicsShop.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElectronicsShop.BusinessLogic.Services
{
    public class OrderService: IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
		private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderService(
            IOrderRepository orderRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
			IProductRepository productRepository
			)
        {
            this._orderRepository = orderRepository;
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
			this._productRepository = productRepository;
        }

		public GenericCollectionViewModel<OrderViewModel> Get(ConditionFilter<Order, long> condition)
		{
			var entityCollection = this._orderRepository.Get(condition).ToList();
			var modelCollection = entityCollection.Select(entity => _mapper.Map<OrderViewModel>(entity)).ToList();
			var result = new GenericCollectionViewModel<OrderViewModel>
			{
				Collection = modelCollection,
				TotalCount = modelCollection.Count,
				PageIndex = condition.PageIndex,
				PageSize = condition.PageSize
			};

			return result;
		}

		public GenericCollectionViewModel<OrderViewModel> Get(int? pageIndex, int? pageSize)
		{
			ConditionFilter<Order, long> condition = new ConditionFilter<Order, long>
			{
				PageIndex = pageIndex,
				PageSize = pageSize
			};
			var allCount = this._orderRepository.Get().Count();
			var entityCollection = this._orderRepository.Get(condition)
				.Include(i=>i.User)
				.Include(i=>i.Product)
				.ToList();
			var modelCollection = entityCollection.Select(entity => _mapper.Map<OrderViewModel>(entity)).ToList();
			var result = new GenericCollectionViewModel<OrderViewModel>
			{
				Collection = modelCollection,
				TotalCount = allCount,
				PageIndex = pageIndex,
				PageSize = pageSize
			};

			return result;
		}


		public OrderViewModel Get(long id)
		{
			ConditionFilter<Order, long> condition = new ConditionFilter<Order, long>();
			condition.Query = i => i.Id == id;
			var entity = this._orderRepository.Get(condition).Include(i=>i.Product).FirstOrDefault();
			var model = _mapper.Map<OrderViewModel>(entity);
			return model;
		}


		public IList<OrderViewModel> Add(IEnumerable<OrderViewModel> collection)
		{

			var entityCollection = collection.Select(model => _mapper.Map<Order>(model));
			entityCollection = this._orderRepository.Add(entityCollection).ToList();

			this._unitOfWork.Commit();

			var modelCollection = entityCollection.Select(entity => _mapper.Map<OrderViewModel>(entity)).ToList();
			return modelCollection;
		}

		public OrderViewModel Add(OrderViewModel model)
		{
			var product = this._productRepository.Get(model.ProductId);
			if (product.Count > model.NumberOfItems)
				product.Count = product.Count - model.NumberOfItems;
			this._productRepository.Update(product);

			var entity = _mapper.Map<Order>(model);
			entity = this._orderRepository.Add(entity);

			this._unitOfWork.Commit();

			model = _mapper.Map<OrderViewModel>(entity);
			return model;
		}

		public IList<OrderViewModel> Update(IEnumerable<OrderViewModel> collection)
		{
			var entityCollection = collection.Select(model => _mapper.Map<Order>(model));
			entityCollection = this._orderRepository.Update(entityCollection).ToList();

			this._unitOfWork.Commit();

			var modelCollection = entityCollection.Select(entity => _mapper.Map<OrderViewModel>(entity)).ToList();
			return modelCollection;
		}
		public OrderViewModel Update(OrderViewModel model)
		{
			var entity = this._orderRepository.Get(model.Id);
			entity.NumberOfItems = model.NumberOfItems;

			entity = this._orderRepository.Update(entity);

			this._unitOfWork.Commit();

			model = _mapper.Map<OrderViewModel>(entity);
			return model;
		}

		public void Delete(IEnumerable<OrderViewModel> collection)
		{
			var entityCollection = collection.Select(model => _mapper.Map<Order>(model));
			this._orderRepository.Delete(entityCollection);

			this._unitOfWork.Commit();
		}

		public void Delete(IEnumerable<long> collection)
		{
			this._orderRepository.Delete(collection);

			this._unitOfWork.Commit();
		}

		public void Delete(OrderViewModel model)
		{
			var entity = _mapper.Map<Order>(model);
			this._orderRepository.Delete(entity);

			this._unitOfWork.Commit();
		}

		public void Delete(long id)
		{
			var result = this._orderRepository.Delete(id);

			if (result == 0)
				throw new ItemNotFoundException();

			this._unitOfWork.Commit();
		}
	}
}
