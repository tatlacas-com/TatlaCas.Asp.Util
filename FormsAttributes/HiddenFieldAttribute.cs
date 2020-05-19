using System;

namespace TatlaCas.Asp.Core.Util.FormsAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class HiddenFieldAttribute : Attribute
    {
        public bool EditorShow { get; }
        public bool DisplayShow { get; }

        public HiddenFieldAttribute(bool editorShow = false,bool displayShow=false)
        {
            EditorShow = editorShow;
            DisplayShow = displayShow;
        }
    }
    [AttributeUsage(AttributeTargets.Property)]
    public class DisabledFieldAttribute : Attribute
    {
    }
}