using System;

namespace TatlaCas.Asp.Core.Util.Exceptions
{
    public class DataTableParamsException: ArgumentException
    {
        public DataTableParamsException(string message):base(message)
        {
        }
    }
}