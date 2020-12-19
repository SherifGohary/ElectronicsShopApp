using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicsShop.Core.Models
{
    public class GenericCollectionViewModel<TViewModel> where TViewModel : BaseViewModel
    {
        public GenericCollectionViewModel()
        {

        }

        public GenericCollectionViewModel(IList<TViewModel> collection, long totalCount, int? pageIndex, int? pageSize)
        {
            this.Collection = collection;
            this.TotalCount = totalCount;
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
        }      

        public IList<TViewModel> Collection { get; set; }
        public long TotalCount { get; set; }
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
    }
}
