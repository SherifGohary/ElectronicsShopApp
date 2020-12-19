using ElectronicsShop.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ElectronicsShop.Core.Filters
{
    public class ConditionFilter<TEntity, TEntityIdentity> where TEntity : IEntityIdentity<TEntityIdentity>
    {
		public ConditionFilter()
		{
			this.NavigationProperties = new List<string>();
		}

		public IList<string> NavigationProperties { get; set; }
		public Expression<Func<TEntity, bool>> Query { get; set; }
		public string QueryString { get; set; }
		public IList<object> FilterParams { get; set; }
		public long Count { get; set; }
		public int? PageIndex { get; set; }
		public int? PageSize { get; set; }
	}
}
