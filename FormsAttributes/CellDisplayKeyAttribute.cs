using System;

namespace TatlaCas.Asp.Utils.FormsAttributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class CellDisplayKeyAttribute : Attribute
    {
        public CellDisplayKeyAttribute(string cellDisplayKey)
        {
            CellDisplayKey = cellDisplayKey;
        }

        public string CellDisplayKey { get; }
    }
}