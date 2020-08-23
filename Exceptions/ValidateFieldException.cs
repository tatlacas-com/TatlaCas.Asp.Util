using System;

namespace TatlaCas.Asp.Core.Util.Exceptions
{
    public class ValidateFieldException: ArgumentException
    {
        public ValidateFieldException(string message):base(message)
        {
            
        }
    }
}