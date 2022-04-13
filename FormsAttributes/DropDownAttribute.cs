using System;
using System.Collections.Generic;

namespace TatlaCas.Asp.Util.FormsAttributes;

[AttributeUsage(AttributeTargets.Property)]
public sealed class DropDownAttribute : Attribute
{
    public List<object> Options { get; set; }
}