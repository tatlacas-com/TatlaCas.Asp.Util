using System;

namespace TatlaCas.Asp.Util.FormsAttributes;

[AttributeUsage(AttributeTargets.Property)]
public class ErrorMessagesAttribute: Attribute
{
    public string ErrorMessage { get; }

    public ErrorMessagesAttribute(string errorMessage)
    {
        ErrorMessage = errorMessage;
    }
}