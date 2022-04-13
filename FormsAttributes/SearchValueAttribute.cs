using System;

namespace TatlaCas.Asp.Util.FormsAttributes;

[AttributeUsage(AttributeTargets.Property)]
public class SearchValueAttribute: Attribute
{
    public string SearchPage { get; }
    public string Source { get; }
    public string Destination { get; }
    public string SourceDisplayable { get; }

    public SearchValueAttribute(string searchPage,string source,string destination,string sourceDisplayable=null)
    {
        SearchPage = searchPage;
        Source = source;
        Destination = destination;
        SourceDisplayable = sourceDisplayable;
    }
}