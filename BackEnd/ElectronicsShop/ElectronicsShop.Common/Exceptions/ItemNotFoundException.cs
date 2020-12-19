using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicsShop.Common.Exceptions
{
    public class ItemNotFoundException: BaseException
    {
        public ItemNotFoundException(string message)
            : base(message)
        {

        }

        public ItemNotFoundException(int errorCode)
            : base(errorCode)
        {

        }

        public ItemNotFoundException()
            : base("ItemNotFoundException")
        {

        }
    }
}
