namespace TatlaCas.Asp.Core.Util.Resources
{
    public class ResourceOption : IResourceOption
    {
        public ResourceOption(string fieldId, string displayValue)
        {
            FieldId = fieldId;
            DisplayValue = displayValue;
        }

        public string FieldId { get; }

        public string DisplayValue { get; }
    }
}