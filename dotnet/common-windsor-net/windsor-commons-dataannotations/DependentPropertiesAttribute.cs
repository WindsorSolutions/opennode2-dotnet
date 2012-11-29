using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web;
using Windsor.Commons.Core;

namespace Windsor.Commons.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public abstract class DependentPropertiesAttribute : ValidationAttribute
    {
        public DependentPropertiesAttribute(params string[] otherPropertyNames)
        {
            ExceptionUtils.ThrowIfNullOrEmpty(otherPropertyNames);
            ExceptionUtils.ThrowIfContainsNullOrEmptyStrings(otherPropertyNames);
            OtherPropertyNames = otherPropertyNames;
            QuotePropertyNamesInErrorMessage = true;
        }
        protected virtual List<KeyValuePair<string, object>> GetOtherPropertyValues(ValidationContext validationContext)
        {
            ExceptionUtils.ThrowIfNull(validationContext.ObjectInstance);
            Func<object> func = () => validationContext.ObjectInstance;

            var otherValues = new List<KeyValuePair<string, object>>(OtherPropertyNames.Length);

            foreach (var otherPropertyName in OtherPropertyNames)
            {
                PropertyInfo propertyInfo = validationContext.ObjectType.GetProperty(otherPropertyName);
                ExceptionUtils.ThrowIfNull(propertyInfo);
                object otherValue = propertyInfo.GetValue(validationContext.ObjectInstance, null);
                string otherDisplayName = GetDisplayNameForProperty(validationContext.ObjectType, otherPropertyName);
                if (string.IsNullOrEmpty(otherDisplayName))
                {
                    otherDisplayName = otherPropertyName;
                }
                otherValues.Add(new KeyValuePair<string, object>(otherDisplayName, otherValue));
            }
            return otherValues;
        }
        protected virtual string GetDisplayNameForProperty(Type containerType, string propertyName)
        {
            ICustomTypeDescriptor typeDescriptor = GetTypeDescriptor(containerType);
            PropertyDescriptor propertyDescriptor = typeDescriptor.GetProperties().Find(propertyName, true);
            if (propertyDescriptor == null)
            {
                throw new ArgumentException(string.Format("Property not found", new object[]
                {
                    containerType.FullName,
                    propertyName
                }));
            }
            IEnumerable<Attribute> source = propertyDescriptor.Attributes.Cast<Attribute>();
            DisplayAttribute displayAttribute = source.OfType<DisplayAttribute>().FirstOrDefault<DisplayAttribute>();
            if (displayAttribute != null)
            {
                return displayAttribute.GetName();
            }
            DisplayNameAttribute displayNameAttribute = source.OfType<DisplayNameAttribute>().FirstOrDefault<DisplayNameAttribute>();
            if (displayNameAttribute != null)
            {
                return displayNameAttribute.DisplayName;
            }
            return propertyName;
        }
        protected virtual ICustomTypeDescriptor GetTypeDescriptor(Type type)
        {
            return new AssociatedMetadataTypeTypeDescriptionProvider(type).GetTypeDescriptor(type);
        }
        protected virtual bool IsValueSpecified(object value)
        {
            return (value != null) && (value.ToString().Length > 0);
        }
        protected virtual bool IsAnyValueSpecified(IEnumerable<KeyValuePair<string, object>> list)
        {
            foreach (var pair in list)
            {
                if (IsValueSpecified(pair.Value))
                {
                    return true;
                }
            }
            return false;
        }
        protected virtual List<string> GetSpecifiedPropertyDisplayNames(IEnumerable<KeyValuePair<string, object>> list)
        {
            List<string> names = null;
            foreach (var pair in list)
            {
                if (IsValueSpecified(pair.Value))
                {
                    CollectionUtils.Add(pair.Key, ref names);
                }
            }
            return names;
        }
        protected virtual List<string> GetUnspecifiedPropertyDisplayNames(IEnumerable<KeyValuePair<string, object>> list)
        {
            List<string> names = null;
            foreach (var pair in list)
            {
                if (!IsValueSpecified(pair.Value))
                {
                    CollectionUtils.Add(pair.Key, ref names);
                }
            }
            return names;
        }
        private string[] OtherPropertyNames
        {
            get;
            set;
        }
        public bool QuotePropertyNamesInErrorMessage
        {
            get;
            set;
        }
    }
}