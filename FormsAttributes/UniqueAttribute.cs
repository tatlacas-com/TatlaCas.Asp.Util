using System;

namespace TatlaCas.Asp.Util.FormsAttributes;

[AttributeUsage(AttributeTargets.Property)]
public sealed class UniqueAttribute : Attribute
{
    public UniqueAttribute()
    {
    }
}