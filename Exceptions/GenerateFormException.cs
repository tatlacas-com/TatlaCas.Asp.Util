using System;

namespace TatlaCas.Asp.Util.Exceptions;

public class GenerateFormException: ArgumentException
{
    public GenerateFormException(string message):base(message)
    {
            
    }
}