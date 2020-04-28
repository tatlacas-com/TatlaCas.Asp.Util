using System;
using System.ComponentModel;

namespace TatlaCas.Asp.Utils.FormsAttributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class FormDisplayNameAttribute : DisplayNameAttribute
    {
        private string _placeholder;

        public string Placeholder
        {
            get => _placeholder ?? DisplayName;
            private set => _placeholder = value;
        }

        public FormDisplayNameAttribute(string displayName, string placeholder = null) : base(displayName)
        {
            Placeholder = placeholder;
        }
    }
}