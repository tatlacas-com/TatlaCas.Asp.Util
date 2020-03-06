using System.Collections.Generic;
using System.ComponentModel;
using TatlaCas.Asp.Utils.HtmlForms;

namespace TatlaCas.Asp.Utils.Resources
{
    public abstract class BaseResource : IResource
    {
        [HtmlFormIgnore] public Dictionary<string, List<IResourceOption>> Options { get; set; }
        [HtmlFormIgnore] [DisplayName("Add another")]  public bool AddAnotherAfterSave { get; set; }
        /// <summary>
        /// Will cause form to show "Add Another" checkbox. Set to false if you don't want to see this checkbox
        /// </summary>
        [HtmlFormIgnore] public bool ShowAddAnotherAfterSave { get; set; } = true;
    }
}