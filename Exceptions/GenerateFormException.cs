using System;

namespace TatlaCas.Asp.Core.Util.Exceptions;

public class GenerateFormException: ArgumentException
{
    public GenerateFormException(string message):base(message)
    {
            
    }
}