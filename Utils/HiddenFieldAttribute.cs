using System;

namespace TatlaCas.Asp.Utils.Utils
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class HiddenFieldAttribute : Attribute
    {
    }
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DisabledFieldAttribute : Attribute
    {
    }
}