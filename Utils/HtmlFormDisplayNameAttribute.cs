using System;
using System.ComponentModel;

namespace TatlaCas.Asp.Utils.Utils
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class HtmlFormDisplayNameAttribute : DisplayNameAttribute
    {
        private string _placeholder;

        public string Placeholder
        {
            get => _placeholder ?? DisplayName;
            private set => _placeholder = value;
        }

        public HtmlFormDisplayNameAttribute(string displayName, string placeholder = null) : base(displayName)
        {
            Placeholder = placeholder;
        }
    }
}