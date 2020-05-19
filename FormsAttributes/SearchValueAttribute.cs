using System;

namespace TatlaCas.Asp.Core.Util.FormsAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SearchValueAttribute: Attribute
    {
        public string SearchFormKey { get; }
        public string Source { get; }
        public string Destination { get; }
        public string SourceDisplayable { get; }

        public SearchValueAttribute(string searchFormKey,string source,string destination,string sourceDisplayable)
        {
            SearchFormKey = searchFormKey;
            Source = source;
            Destination = destination;
            SourceDisplayable = sourceDisplayable;
        }
    }
}