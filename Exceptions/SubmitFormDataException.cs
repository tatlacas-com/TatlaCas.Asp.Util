using System;

namespace TatlaCas.Asp.Core.Util.Exceptions
{
    public class SubmitFormDataException: ArgumentException
    {
        public SubmitFormDataException(string message):base(message)
        {
            
        }
    }
}