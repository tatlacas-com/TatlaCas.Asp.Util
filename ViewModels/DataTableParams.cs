namespace TatlaCas.Asp.Core.Util.ViewModels
{
    public class DataTableParams
    {
        public string UniqueKey { get; set; }
        public DataTableMeta Pagination { get; set; }
        public DataTableQuery Query { get; set; }
        public DataTableSort Sort { get; set; }
    }
}