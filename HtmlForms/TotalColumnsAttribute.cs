using System;

namespace TatlaCas.Asp.Utils.HtmlForms
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class TotalColumnsAttribute : Attribute
    {
        public int ColumnsCount { get; }

        public TotalColumnsAttribute(int columnsCount)
        {
            ColumnsCount = columnsCount;
        }
    }
}