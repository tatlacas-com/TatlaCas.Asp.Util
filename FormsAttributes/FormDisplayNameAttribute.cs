using System;
using System.ComponentModel;

namespace TatlaCas.Asp.Utils.FormsAttributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class FormDisplayNameAttribute : DisplayNameAttribute
    {
        public string Placeholder { get; set; }

        public FormDisplayNameAttribute(string displayName, string placeholder) : base(displayName)
        {
            Placeholder = placeholder;
        }
    }
}