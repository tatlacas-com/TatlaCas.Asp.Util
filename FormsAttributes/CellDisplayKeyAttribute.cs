using System;

namespace TatlaCas.Asp.Util.FormsAttributes;

[AttributeUsage(AttributeTargets.Property)]
public sealed class CellDisplayKeyAttribute : Attribute
{
    public CellDisplayKeyAttribute(string cellDisplayKey)
    {
        CellDisplayKey = cellDisplayKey;
    }

    public string CellDisplayKey { get; }
}