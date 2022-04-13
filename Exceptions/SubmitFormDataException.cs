using System;

namespace TatlaCas.Asp.Util.Exceptions;

public class SubmitFormDataException: ArgumentException
{
    public SubmitFormDataException(string message):base(message)
    {
            
    }
}