using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using TatlaCas.Asp.Core.Util.FormsAttributes;
using TatlaCas.Asp.Core.Util.Resources;

namespace TatlaCas.Asp.Core.Util.ViewModels
{
    public class DisplayFormModel : IResource
    {
        public bool IsForDisplayView { get; set; } = true;
        public string ViewKey { get; set; }
        public string UniqueKey { get; set; }
        public Dictionary<string, List<IResourceOption>> Options { get; set; }
        public bool AddAnotherAfterSave { get; set; }
        public bool ShowAddAnotherAfterSave { get; set; }
        public bool IgnoreNullFields { get; set; }

        public bool IsValid()
        {
            throw new System.NotImplementedException();
        }

        public List<FieldResource> Fields { get; set; }
        public string CellViewType { get; set; }

        protected virtual void SetEditProperties(FieldResource field, PropertyInfo property,
            DisplayNameAttribute displayNameAttr)
        {
        }


        protected virtual void SetPlaceholder(DisplayNameAttribute displayNameAttr, FieldResource field)
        {
        }

        public static IResource GenerateForm<TResource>(TResource res) where TResource : IResource
        {
            throw new System.NotImplementedException();
        }
    }

    public class EditFormModel : DisplayFormModel
    {
        public string SubmitText { get; set; }
        public bool HasCancel { get; set; }
        public string CancelText { get; set; }
        public string SubmitToController { get; set; }
        public string SubmitToAction { get; set; }
        public PostResult Result { get; set; }

        public EditFormModel() : base()
        {
            IsForDisplayView = false;
        }

        public new static IResource GenerateForm<TResource>(TResource res) where TResource : IResource
        {
            var form = new EditFormModel();
            form.Process(res);
            return form;
        }

        protected override void SetEditProperties(FieldResource field, PropertyInfo property,
            DisplayNameAttribute displayNameAttr)
        {
            field.Placeholder = property.Name;
            field.Required = property.GetCustomAttribute<RequiredAttribute>() != null;
            field.Name = property.Name;
            if (property.GetCustomAttribute<DisabledFieldAttribute>() is { })
                field.Disabled = true;
            if (property.GetCustomAttribute<ReadOnlyAttribute>() is { } readOnlyAttribute &&
                readOnlyAttribute.IsReadOnly)
                field.ReadOnly = true;
            if (property.GetCustomAttribute<MinLengthAttribute>() is { } minLengthAttribute)
                field.MinLength = minLengthAttribute.Length;
            if (property.GetCustomAttribute<MaxLengthAttribute>() is { } maxLengthAttribute)
                field.MaxLength = maxLengthAttribute.Length;
        }

        public void Process(IResource resource)
        {
            Fields = new List<FieldResource>();
            var properties = resource.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (var property in properties)
            {
                if (property.GetGetMethod() == null) continue;
                if (property.GetCustomAttribute<HtmlFormIgnoreAttribute>() is {} ||
                    property.GetCustomAttribute<EditorIgnoreAttribute>() is {})
                    continue;

                var field = new FieldResource
                {
                    FieldType = FieldTypes.Text,
                    DisplayName = property.Name,
                    Value = property.GetValue(resource, null)
                };
                var displayNameAttr = property.GetCustomAttribute<DisplayNameAttribute>();
                SetEditProperties(field, property, displayNameAttr);

                if (property.GetCustomAttribute<SearchValueAttribute>() is {} searchValueAttribute)
                {
                    field.FieldType = FieldTypes.Search;
                    field.SearchPage = searchValueAttribute.SearchPage;
                    field.Source = searchValueAttribute.Source;
                    field.SourceDisplayable = searchValueAttribute.SourceDisplayable;
                    field.Destination = searchValueAttribute.Destination;
                }
                else if (property.GetCustomAttribute<EmailAddressAttribute>() != null)
                    field.FieldType = FieldTypes.Email;
                else if (property.GetCustomAttribute<PhoneAttribute>() != null)
                    field.FieldType = FieldTypes.Phone;
                else if (property.GetCustomAttribute<HiddenFieldAttribute>() is {} hide && !hide.EditorShow)
                    field.Hidden = true;
                else
                {
                    if (property.GetCustomAttribute<DropDownAttribute>() != null)
                    {
                        field.FieldType = FieldTypes.DropDown;
                        field.Options = resource.Options[property.Name];
                    }
                    else if (property.PropertyType == typeof(int) || property.PropertyType == typeof(int?))
                        field.FieldType = FieldTypes.Integer;
                    else if (property.PropertyType == typeof(bool) || property.PropertyType == typeof(bool?))
                    {
                        field.FieldType = FieldTypes.Checkbox;
                        field.Value = property.GetValue(resource, null);
                    }
                }

                if (displayNameAttr != null)
                {
                    field.DisplayName = displayNameAttr.DisplayName;
                    SetPlaceholder(displayNameAttr, field);
                }

                Fields.Add(field);
            }
        }


        protected override void SetPlaceholder(DisplayNameAttribute displayNameAttr, FieldResource field)
        {
            if (displayNameAttr is FormDisplayNameAttribute fd)
                field.Placeholder = fd.Placeholder;
            else field.Placeholder = displayNameAttr.DisplayName;
        }
    }

    public class FieldResource
    {
        public string DisplayName { get; set; }
        public object Value { get; set; }
        public FieldTypes FieldType { get; set; }

        public int? MinLength { get; set; }
        public int? MaxLength { get; set; }
        public bool? Required { get; set; }
        public bool? Hidden { get; set; }
        public bool? ReadOnly { get; set; }
        public bool? Disabled { get; set; }
        public string Name { get; set; }
        public string Placeholder { get; set; }
        public List<IResourceOption> Options { get; set; }
        public string SearchPage { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string SourceDisplayable { get; set; }
    }

    public enum FieldTypes
    {
        Text,
        Email,
        Phone,
        Integer,
        Checkbox,
        RadioButton,
        DropDown,
        Button,
        Search
    }
}