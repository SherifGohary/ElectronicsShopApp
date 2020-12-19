using ElectronicsShop.Common.Interfaces;
using ElectronicsShop.Core.Filters;
using ElectronicsShop.Core.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ElectronicsShop.DataAccess.Repositories
{
    public class BaseRepository<TEntity, TEntityIdentity> : IBaseRepository<TEntity, TEntityIdentity>
        where TEntity : class, IEntityIdentity<TEntityIdentity>
    {
		private DbContext _context;
		public BaseRepository(DbContext context)
		{
			this.Context = context;
		}


		public long GetCount()
		{
			var result = this.Entities.LongCount();
			return result;
		}
		public long GetCount(Expression<Func<TEntity, bool>> expression)
		{
			var result = this.Entities.LongCount(expression);
			return result;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="condition"></param>
		/// <returns></returns>
		public IQueryable<TEntity> Get(ConditionFilter<TEntity, TEntityIdentity> condition = null)
		{
			var result = this.Entities.AsQueryable();

			if (condition != null)
			{
				foreach (var item in condition.NavigationProperties)
				{
					result.Include(item);
				}

				if (condition.Query != null)
					result = result.Where(condition.Query);

				condition.Count = result.LongCount();

				if (condition.PageIndex.HasValue &&
					condition.PageSize.HasValue)
				{
					result = result
						.Skip(condition.PageIndex.Value * condition.PageSize.Value)
						.Take(condition.PageSize.Value);
				}
			}

			return result;
		}
		public TEntity Get(TEntityIdentity id)
		{
			var result = this.Entities.Find(id);
			return result;
		}

		public IEnumerable<TEntity> Add(IEnumerable<TEntity> entityCollection)
		{
			if (entityCollection != null)
			{
				DateTime now = DateTime.Now;

				foreach (var entity in entityCollection)
				{
					if (entity is IEntityDateTimeSignature)
					{
						var entityDate = ((IEntityDateTimeSignature)entity);
						entityDate.CreationDate = now;
					}
					//if (entity is IEntityUserSignature)
					//{
					//	var entityUser = ((IEntityUserSignature)entity);
					//	entityUser.CreatedByUserId = this._currentUserService.CurrentUserId;
					//}
					this.Context.Entry<TEntity>(entity).State = EntityState.Added;
				}
			}
			return entityCollection;
		}
		public virtual TEntity Add(TEntity entity)
		{
			if (entity != null)
			{
				DateTime now = DateTime.Now;

				if (entity is IEntityDateTimeSignature)
				{
					var entityDate = ((IEntityDateTimeSignature)entity);
					entityDate.CreationDate = now;
				}
				//if (entity is IEntityUserSignature)
				//{
				//	var entityUser = ((IEntityUserSignature)entity);
				//	entityUser.CreatedByUserId = this._currentUserService.CurrentUserId;
				//}
				this.Context.Entry<TEntity>(entity).State = EntityState.Added;
			}
			return entity;
		}

		public IEnumerable<TEntity> Update(IEnumerable<TEntity> entityCollection)
		{
			if (entityCollection != null)
			{
				DateTime now = DateTime.Now;

				foreach (var entity in entityCollection)
				{
					if (entity is IEntityDateTimeSignature)
					{
						var entityDate = ((IEntityDateTimeSignature)entity);

						entityDate.ModificationDate = now;
					}
					//if (entity is IEntityUserSignature)
					//{
					//	var entityUser = ((IEntityUserSignature)entity);
					//	entityUser.ModifiedByUserId = this._currentUserService.CurrentUserId;
					//}
					this.Context.Entry<TEntity>(entity).State = EntityState.Modified;
				}
			}
			return entityCollection;
		}
		public TEntity Update(TEntity entity)
		{
			if (entity != null)
			{
				DateTime now = DateTime.Now;

				if (entity is IEntityDateTimeSignature)
				{
					var entityDate = ((IEntityDateTimeSignature)entity);

					entityDate.ModificationDate = now;
				}
				//if (entity is IEntityUserSignature)
				//{
				//	var entityUser = ((IEntityUserSignature)entity);
    //                entityUser.ModifiedByUserId = this._currentUserService.CurrentUserId;
    //            }
				this.Context.Entry<TEntity>(entity).State = EntityState.Modified;
			}
			return entity;
		}

		public void Delete(IEnumerable<TEntity> entityCollection)
		{
			if (entityCollection != null)
			{
				foreach (var entity in entityCollection)
				{
					if (entity != null)
					{
						if (entity is IVirtualDelete)
						{
							var virtualDeleteEntity = (IVirtualDelete)entity;

							virtualDeleteEntity.IsDeleted = true;
							virtualDeleteEntity.LastDeletedDate = DateTime.Now;
							this.Context.Entry<TEntity>(entity).State = EntityState.Modified;
						}
						else
						{
							this.Context.Entry<TEntity>(entity).State = EntityState.Deleted;
						}
					}
				}
			}
		}
		public void Delete(TEntity entity)
		{
			if (entity != null)
			{
				if (entity is IVirtualDelete)
				{
					var virtualDeleteEntity = (IVirtualDelete)entity;

					virtualDeleteEntity.IsDeleted = true;
					virtualDeleteEntity.LastDeletedDate = DateTime.Now;
					this.Context.Entry<TEntity>(entity).State = EntityState.Modified;
				}
				else
				{
					this.Context.Entry<TEntity>(entity).State = EntityState.Deleted;
				}
			}
		}

		public void Delete(IEnumerable<TEntityIdentity> idCollection)
		{
			if (idCollection != null)
			{
				foreach (var id in idCollection)
				{
					var entity = this.Entities.Find(id);

					if (entity is IVirtualDelete)
					{
						var virtualDeleteEntity = (IVirtualDelete)entity;

						virtualDeleteEntity.IsDeleted = true;
						virtualDeleteEntity.LastDeletedDate = DateTime.Now;
						this.Context.Entry<TEntity>(entity).State = EntityState.Modified;
					}
					else
					{
						this.Context.Entry<TEntity>(entity).State = EntityState.Deleted;
					}
				}
			}
		}
		public int Delete(TEntityIdentity id)
		{
			var entity = this.Entities.Find(id);

			if (entity == null)
				return 0;


			if (entity is IVirtualDelete)
			{
				var virtualDeleteEntity = (IVirtualDelete)entity;

				virtualDeleteEntity.IsDeleted = true;
				virtualDeleteEntity.LastDeletedDate = DateTime.Now;
				this.Context.Entry<TEntity>(entity).State = EntityState.Modified;
			}
			else
			{
				this.Context.Entry<TEntity>(entity).State = EntityState.Deleted;
			}

			return 1;
		}

		protected DbContext Context
		{
			get { return this._context; }
			private set
			{
				this._context = value;
				this.Entities = this._context.Set<TEntity>();
			}
		}
		protected DbSet<TEntity> Entities { get; private set; }
	}
}
