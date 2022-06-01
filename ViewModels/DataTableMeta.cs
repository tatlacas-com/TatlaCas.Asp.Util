
using System;

namespace TatlaCas.Asp.Util.ViewModels;

/// <summary>
/// Meta object should contain the metadata that required for the datatable pagination to work.
/// </summary>
public class DataTableMeta
{
    /// <summary>
    /// The current page number.
    /// </summary>
    public int Page { get; set; }
    /// <summary>
    /// Total number of pages available in the server.
    /// </summary>
    public int Pages { get; set; }
    /// <summary>
    /// Total records per page.
    /// </summary>
    public int PerPage { get; set; }
    /// <summary>
    /// Total all records number available in the server
    /// </summary>
    public int Total { get; set; }

    public DateTime? OffsetDateTime { get; set; }
    public string OffsetRef { get; set; }
       
}