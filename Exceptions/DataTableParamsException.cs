using System;

namespace TatlaCas.Asp.Util.Exceptions;

public class DataTableParamsException: ArgumentException
{
    public DataTableParamsException(string message):base(message)
    {
    }
}