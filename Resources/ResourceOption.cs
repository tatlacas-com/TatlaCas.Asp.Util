namespace TatlaCas.Asp.Util.Resources;

public class ResourceOption : IResourceOption
{
    public ResourceOption(string fieldId, string fullName)
    {
        FieldId = fieldId;
        DisplayValue = fullName;
    }

    public string FieldId { get; }

    public string DisplayValue { get; }
}