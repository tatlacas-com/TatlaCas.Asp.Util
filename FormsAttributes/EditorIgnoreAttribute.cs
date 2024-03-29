using System;

namespace TatlaCas.Asp.Util.FormsAttributes;

/// <summary>Prevents a property from being shown on an editor form as field.</summary>
[AttributeUsage(AttributeTargets.Property)]
public sealed class EditorIgnoreAttribute : Attribute
{
}