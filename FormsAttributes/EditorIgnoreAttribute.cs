using System;

namespace TatlaCas.Asp.Utils.FormsAttributes
{
    /// <summary>Prevents a property from being shown on an editor form as field.</summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class EditorIgnoreAttribute : Attribute
    {
    }
}