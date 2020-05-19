namespace TatlaCas.Asp.Core.Util.ViewModels
{
    public class DataTableSort
    {
        /// <summary>
        /// Field name which the sort should be applied to.
        /// </summary>
        public string Field { get; set; }
        /// <summary>
        /// Sort type asc for ascending and desc for descending.
        /// </summary>
        public string Sort { get; set; }
    }
}