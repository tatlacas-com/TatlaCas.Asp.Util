using System.Collections.Generic;
using TatlaCas.Asp.Utils.HtmlForms;

namespace TatlaCas.Asp.Utils.Resources
{
    public interface IResource
    {
        Dictionary<string, List<IResourceOption>> Options { get; set; }
        bool AddAnotherAfterSave { get; set; }
        bool ShowAddAnotherAfterSave { get; set; }
    }
}