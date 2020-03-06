using System;

namespace TatlaCas.Asp.Utils.HtmlForms
{
    /// <summary>Prevents a property from being shown on an html form as field.</summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class HtmlFormIgnoreAttribute : Attribute
    {
    }
}