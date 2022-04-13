using System;
using System.ComponentModel;

namespace TatlaCas.Asp.Util.FormsAttributes;

[AttributeUsage(AttributeTargets.Property)]
public sealed class FormDisplayNameAttribute : DisplayNameAttribute
{
    public string Placeholder { get; set; }

    public FormDisplayNameAttribute(string displayName, string placeholder) : base(displayName)
    {
        Placeholder = placeholder;
    }
}