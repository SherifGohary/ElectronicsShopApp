using ElectronicsShop.Common.Interfaces;
using ElectronicsShop.Core.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ElectronicsShop.Core.IRepositories
{
    public interface IBaseRepository<TEntity, TEntityIdentity>
		where TEntity : class, IEntityIdentity<TEntityIdentity>
	{
		long GetCount();
		long GetCount(Expression<Func<TEntity, bool>> expression);
		IQueryable<TEntity> Get(ConditionFilter<TEntity, TEntityIdentity> condition = null);
		TEntity Get(TEntityIdentity id);
		IEnumerable<TEntity> Add(IEnumerable<TEntity> entityCollection);
		TEntity Add(TEntity entity);
		IEnumerable<TEntity> Update(IEnumerable<TEntity> entityCollection);
		TEntity Update(TEntity entity);
		void Delete(IEnumerable<TEntity> entityCollection);
		void Delete(TEntity entity);
		void Delete(IEnumerable<TEntityIdentity> idCollection);
		int Delete(TEntityIdentity id);
	}
}
