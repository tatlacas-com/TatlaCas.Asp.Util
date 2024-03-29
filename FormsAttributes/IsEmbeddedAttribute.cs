using System;

namespace TatlaCas.Asp.Util.FormsAttributes;

[AttributeUsage(AttributeTargets.Property)]
public class IsEmbeddedAttribute : Attribute
{
    public bool LeftEmbedded { get; }

    public IsEmbeddedAttribute(bool leftEmbedded=true)
    {
        LeftEmbedded = leftEmbedded;
    }
}