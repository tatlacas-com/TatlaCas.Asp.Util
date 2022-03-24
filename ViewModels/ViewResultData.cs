using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text.Json.Serialization;
using TatlaCas.Asp.Core.Util.FormsAttributes;
using TatlaCas.Asp.Core.Util.Resources;

namespace TatlaCas.Asp.Core.Util.ViewModels;

public class ViewResultData
{
    public int Total { get; set; }
    public object Data { get; set; }
    public List<ItemsDisplayColumns> Columns { get; set; }

    public void ProcessDisplayColumns<TResource>(TResource resource) where TResource : IResource, new()
    {
        Columns = new List<ItemsDisplayColumns>();
        var properties = resource.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
        foreach (var property in properties)
        {
            if (property.GetCustomAttribute<JsonIgnoreAttribute>() is {} ||
                property.GetCustomAttribute<DisplayIgnoreAttribute>() is {})
                continue;
            if (property.GetCustomAttribute<HiddenFieldAttribute>() is {} hide && !hide.DisplayShow)
                continue;
            var field = new ItemsDisplayColumns();
            if (property.GetCustomAttribute<EmailAddressAttribute>() != null)
                field.DataType = FieldTypes.Email;
            else if (property.GetCustomAttribute<PhoneAttribute>() != null)
                field.DataType = FieldTypes.Phone;
            else if (property.PropertyType == typeof(int))
                field.DataType = FieldTypes.Integer;
            else if (property.PropertyType == typeof(bool))
                field.DataType = FieldTypes.Checkbox;
            else
                field.DataType = FieldTypes.Text;

            field.Title = property.GetCustomAttribute<DisplayNameAttribute>() is {} displayNameAttribute
                ? displayNameAttribute.DisplayName
                : property.Name;

            field.ColumnId = property.Name;
            Columns.Add(field);
        }
    }
}