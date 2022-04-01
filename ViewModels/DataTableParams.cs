using System.Collections.Generic;
using System.Text.Json;

namespace TatlaCas.Asp.Core.Util.ViewModels;

public class DataTableParams
{
    public string UniqueKey { get; set; }
    public DataTableMeta Pagination { get; set; }
    public DataTableQuery Query { get; set; }
    public List<DataTableSort> Sort { get; set; }
    public bool PartialResults { get; set; }

    public bool HasQuery => Query?.QueryObject != null
                            && Query?.QueryObject.ValueKind != JsonValueKind.Undefined
                            && Query?.QueryObject.ValueKind != JsonValueKind.Null;

    public string QueryJson => Query.QueryObject.GetRawText();
}