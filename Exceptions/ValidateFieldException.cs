using System;

namespace TatlaCas.Asp.Util.Exceptions;

public class ValidateFieldException: ArgumentException
{
    public ValidateFieldException(string message):base(message)
    {
            
    }
}