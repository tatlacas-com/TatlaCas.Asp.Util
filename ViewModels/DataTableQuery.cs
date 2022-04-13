
using System.Text.Json;

namespace TatlaCas.Asp.Util.ViewModels;

public class DataTableQuery
{
    public string GeneralSearch { get; set; }
    public string QueryId { get; set; }
    public JsonElement QueryObject { get; set; }
}