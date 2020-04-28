using System;

namespace TatlaCas.Asp.Utils.FormsAttributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class UniqueAttribute : Attribute
    {
        public UniqueAttribute()
        {
        }
    }
}