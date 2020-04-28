using System;

namespace TatlaCas.Asp.Utils.FormsAttributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class IsEmbeddedAttribute : Attribute
    {
        public bool LeftEmbedded { get; }

        public IsEmbeddedAttribute(bool leftEmbedded=true)
        {
            LeftEmbedded = leftEmbedded;
        }
    }
}