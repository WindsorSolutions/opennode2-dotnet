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
    public static class DataAnnotationsHelper
    {
        public static string GetDisplayNameForProperty(Type containerType, string propertyName)
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
        public static ICustomTypeDescriptor GetTypeDescriptor(Type type)
        {
            return new AssociatedMetadataTypeTypeDescriptionProvider(type).GetTypeDescriptor(type);
        }
    }
}