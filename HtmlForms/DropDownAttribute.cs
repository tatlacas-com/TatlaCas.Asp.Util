using System;
using System.Collections.Generic;

namespace TatlaCas.Asp.Utils.HtmlForms
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class DropDownAttribute : Attribute
    {
        public List<object> Options { get; set; }
    }
}