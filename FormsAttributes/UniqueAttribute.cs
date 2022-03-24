using System;

namespace TatlaCas.Asp.Core.Util.FormsAttributes;

[AttributeUsage(AttributeTargets.Property)]
public sealed class UniqueAttribute : Attribute
{
    public UniqueAttribute()
    {
    }
}