using System;

namespace TatlaCas.Asp.Core.Util.FormsAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ImageFileAttribute: Attribute
    {
        public string MimeTypeField { get; }

        public ImageFileAttribute(string mimeTypeField)
        {
            MimeTypeField = mimeTypeField;
        }
    }
}