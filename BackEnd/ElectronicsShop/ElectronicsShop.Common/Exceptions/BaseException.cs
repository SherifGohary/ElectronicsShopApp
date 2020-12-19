using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicsShop.Common.Exceptions
{
    public class BaseException: ApplicationException
    {
        public int ErrorCode { get; set; }

        public BaseException()
        {

        }

        public BaseException(string message)
            : base(message)
        {

        }

        public BaseException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        public BaseException(int errorCode)
            : base(errorCode.ToString())
        {
            this.ErrorCode = errorCode;
        }

    }
}
