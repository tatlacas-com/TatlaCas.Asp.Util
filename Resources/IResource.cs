using System.Collections.Generic;

namespace TatlaCas.Asp.Core.Util.Resources
{
    public interface IResource
    {
        public string ViewKey { get; set; }
        public string UniqueKey { get; set; }
        public string CellViewType { get; set; }
        Dictionary<string, List<IResourceOption>> Options { get; set; }
        bool IsValid();
    }
}