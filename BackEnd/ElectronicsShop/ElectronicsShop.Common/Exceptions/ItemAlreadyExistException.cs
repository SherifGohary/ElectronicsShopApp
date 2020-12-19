using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicsShop.Common.Exceptions
{
    public class ItemAlreadyExistException: BaseException
    {
        public ItemAlreadyExistException(string message)
            : base(message)
        {

        }

        public ItemAlreadyExistException(int errorCode)
            : base(errorCode)
        {

        }

        public ItemAlreadyExistException()
            : base("ItemAlreadyExistException")
        {

        }
    }
}
