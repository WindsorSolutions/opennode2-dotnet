using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Windsor.Commons.Core
{
    /// <summary>
    /// Extension methods on objects to support deep copying
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Copies all value properties from one object to another
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static T CopyValuePropertiesTo<T>(this T from, T to)
        {
            return CopyValuePropertiesTo(from, to, new List<PropertyInfo>());
        }

        /// <summary>
        /// Copies all value properties from one object to another
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="except">List of properties to skip while copying</param>
        /// <returns></returns>
        public static T CopyValuePropertiesTo<T>(this T from, T to, IEnumerable<PropertyInfo> except)
        {
            foreach (var propertyInfo in from.GetType().GetProperties().Where(p => p.PropertyType.IsValueType || p.PropertyType == typeof(string)).Except(except)) {
                propertyInfo.SetValue(to, propertyInfo.GetValue(from, null), null);
            }

            return to;
        }

        /// <summary>
        /// Copies all value properties from one object to another
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="except">List of properties to skip while copying</param>
        /// <returns></returns>
        public static T CopyValuePropertiesTo<T>(this T from, T to, IEnumerable<string> except)
        {
            return CopyValuePropertiesTo(from, to, from.GetType().GetProperties().Where(p => except.Any(exception => p.Name == exception)));
        }

        /// <summary>
        /// Performs deep copy of an arbitrary object.  Beware of circular references
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T Copy<T>(this T obj)
        {
            return obj.Copy(null);
        }

        /// <summary>
        /// Performs deep copy of an arbitrary object.  Beware of circular references
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="transforms">List of transformations to peform on various properties (e.g. use DateTime.Now for ChangeDate instead of copying it over)</param>
        /// <returns></returns>
        public static T Copy<T>(this T obj, IEnumerable<Func<PropertyInfo, Func<object, object>>> transforms)
        {
            if (object.Equals(obj, default(T))) return default(T);
            var workingType = obj.GetType();
            if (workingType.IsValueType || obj is string) return obj;
            var enumerableObj = obj as IList;
            var isEnumerable = enumerableObj != null;
            var copy = (T)Activator.CreateInstance(workingType);
            transforms = transforms ?? new List<Func<PropertyInfo, Func<object, object>>>();
            if (!isEnumerable) CopyNormalObject(obj, transforms, copy);
            else CopyEnumerable(enumerableObj, transforms, (IList)copy);
            return copy;
        }

        private static void CopyEnumerable(IEnumerable enumerableObj, IEnumerable<Func<PropertyInfo, Func<object, object>>> values, IList copy)
        {
            foreach (var item in enumerableObj)
                copy.Add(item.Copy(values));
        }

        private static void CopyNormalObject<T>(T obj, IEnumerable<Func<PropertyInfo, Func<object, object>>> values, T copy)
        {
            foreach (var propertyInfo in obj.GetType().GetProperties()) {
                if (propertyInfo.CanWrite) {
                    bool foundTransform = false;
                    foreach (var value in values) {
                        var transform = value(propertyInfo);
                        if (transform != null) {
                            foundTransform = true;
                            propertyInfo.SetValue(copy, transform(obj), null);
                            break;
                        }
                    }
                    if (!foundTransform)
                        propertyInfo.SetValue(copy, propertyInfo.GetValue(obj, null).Copy(values), null);
                }
            }
        }

        /// <summary>
        /// "Unwraps" an object by creating a new object based on the base type of that object and unwrapping
        /// all properties over from the derived object to its base object.  Avoid circular object graphs by
        /// avoiding objects with circular object graphs or by ignoring properties with an attribute such as
        /// System.Web.Script.Serialization.ScriptIgnoreAttribute.
        /// 
        /// This is especially useful for dynamic proxy objects created by systems like NHibernate
        /// </summary>
        /// <param name="value">Object to unwrap</param>
        /// <param name="excludingStartingNamespace">Namespaces that should not be processed.  Any type with a full name starting with a value in these parameters will be ignored.</param>
        /// <param name="shouldExcludeAnonymousTypes">Determines whether anonymous types should also be included</param>
        /// <returns>Unwrapped object.  The type will be the base type of the original.</returns>
        public static object Unwrap(this object value, bool shouldExcludeAnonymousTypes, params string[] excludingStartingNamespace)
        {
            return Unwrap(value, null, shouldExcludeAnonymousTypes, excludingStartingNamespace);
        }

        /// <summary>
        /// "Unwraps" an object by creating a new object based on the base type of that object and unwrapping
        /// all properties over from the derived object to its base object.  Avoid circular object graphs by
        /// avoiding objects with circular object graphs or by ignoring properties with an attribute such as
        /// System.Web.Script.Serialization.ScriptIgnoreAttribute.
        /// 
        /// This is especially useful for dynamic proxy objects created by systems like NHibernate
        /// </summary>
        /// <param name="value">Object to unwrap</param>
        /// <param name="ignoreAttribute">Attribute that, if present, will be skipped during processing</param>
        /// <param name="excludingStartingNamespace">Namespaces that should not be processed.  Any type with a full name starting with a value in these parameters will be ignored.</param>
        /// <param name="shouldExcludeAnonymousTypes">Determines whether anonymous types should also be included</param>
        /// <returns>Unwrapped object.  The type will be the base type of the original.</returns>
        public static object Unwrap(this object value, Type ignoreAttribute, bool shouldExcludeAnonymousTypes, params string[] excludingStartingNamespace)
        {
            if (value == null) return null;

            var type = value.GetType();
            var isExcluded = ValueShouldBeExcluded(type, shouldExcludeAnonymousTypes, excludingStartingNamespace);

            // Deal with anonymous types
            if (type.IsAnonymousType()) 
                return UnwrapAnonymousType(value, ignoreAttribute, shouldExcludeAnonymousTypes, excludingStartingNamespace, type);

            // Find the proper type to create
            var unwrappedType = isExcluded ? type : type.BaseType;

            // Get an instance of the type for copying
            object rc = unwrappedType == typeof(string)
                ? value.ToString()
                : Activator.CreateInstance(unwrappedType);

            if (unwrappedType.IsValueType) rc = value;

            // Unwrap all the properties of the type
            foreach (var propertyInfo in unwrappedType.GetProperties())
                UnwrapProperty(propertyInfo, value, rc, ignoreAttribute, shouldExcludeAnonymousTypes, excludingStartingNamespace);
            var enumerable = value as IList;
            if (enumerable != null)
                UnwrapEnumerable(ignoreAttribute, shouldExcludeAnonymousTypes, excludingStartingNamespace, enumerable, (IList)rc);

            return rc;
        }

        private static object UnwrapAnonymousType(object value, Type ignoreAttribute, bool shouldExcludeAnonymousTypes, string[] excludingStartingNamespace, Type type)
        {
            var props = new Dictionary<PropertyInfo, object>();
            foreach (var prop in type.GetProperties())
                props.Add(prop, Unwrap(prop.GetValue(value, null), ignoreAttribute, shouldExcludeAnonymousTypes, excludingStartingNamespace));
            return Activator.CreateInstance(type, props.Values.ToArray());
        }

        private static void UnwrapProperty(PropertyInfo property, object source, object destination, Type ignoreAttribute, bool shouldExcludeAnonymousTypes, params string[] excludingStartingNamespace)
        {
            try {
                if (property.DeclaringType == typeof(string) && property.Name == "Chars")
                    return;
                if (ignoreAttribute != null &&
                    Attribute.GetCustomAttribute(property, ignoreAttribute) != null)
                    return; 
                var propertyValue = property.GetValue(source, null);
                var enumerable = propertyValue as System.Collections.IEnumerable;
                if (!property.CanWrite && enumerable == null)
                    return;
                if (enumerable == null || propertyValue is string)
                    property.SetValue(destination, Unwrap(propertyValue, ignoreAttribute, shouldExcludeAnonymousTypes, excludingStartingNamespace), null);
                else
                    UnwrapEnumerable(ignoreAttribute, shouldExcludeAnonymousTypes, excludingStartingNamespace, destination, property, enumerable);
            }
            catch (Exception ex) {
                // ignore for now
                System.Diagnostics.Debug.WriteLine("Error setting property " + property.Name + ": " + ex.Message);
            }

        }

        private static void UnwrapEnumerable(Type ignoreAttribute, bool shouldExcludeAnonymousTypes, string[] excludingStartingNamespace, object rc, PropertyInfo propertyInfo, IEnumerable enumerable)
        {
            var newList = NewCollectionBasedOn(propertyInfo.PropertyType);

            if (propertyInfo.CanWrite) {
                UnwrapEnumerable(ignoreAttribute, shouldExcludeAnonymousTypes, excludingStartingNamespace, enumerable, newList);
                propertyInfo.SetValue(rc, newList, null);
            }
        }

        private static void UnwrapEnumerable(Type ignoreAttribute, bool shouldExcludeAnonymousTypes, string[] excludingStartingNamespace, IEnumerable enumerable, IList newList)
        {
            foreach (var item in enumerable)
                newList.Add(Unwrap(item, ignoreAttribute, shouldExcludeAnonymousTypes, excludingStartingNamespace));
        }

        private static System.Collections.IList NewCollectionBasedOn(Type type)
        {
            if (type == null) throw new ArgumentNullException("type");
            return type.IsGenericType
                          ? (System.Collections.IList)
                            Activator.CreateInstance(typeof(List<>).MakeGenericType(type.GetGenericArguments()[0]))
                          : new System.Collections.ArrayList();
        }


        private static bool ValueShouldBeExcluded(Type type, bool shouldExcludeAnonymousTypes, params string[] excludingStartingNamespace)
        {
            return
                (shouldExcludeAnonymousTypes && type.IsAnonymousType()) ||
                excludingStartingNamespace.Any(s => type.FullName.StartsWith(s)) ||
                type.BaseType == null;
        }

        /// <summary>
        /// Gets the value of a property by name rather than traditional compile-time checked property access.
        /// There is no way to have compile-time checking on this as we're using reflection, so beware
        /// </summary>
        /// <param name="obj">Object to access</param>
        /// <param name="propertyName">Name of property to access.  Currently this must be a public property.  Sub properties (Prop1.SubProp.SubSubProp) are supported</param>
        /// <returns>Value of the property</returns>
        public static object ValueOfPropertyByName(this object obj, string propertyName)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            if (string.IsNullOrEmpty(propertyName)) throw new ArgumentNullException("propertyName");

            object currProp = obj;
            foreach (var propPart in propertyName.Split('.')) {
                var objectType = currProp.GetType();
                var propertyInfo = objectType.GetProperty(propPart);
                if (propertyInfo == null) throw new ArgumentOutOfRangeException("propertyName", "Property '" + propPart + "' not found on object of type: " + objectType.FullName);
                currProp = propertyInfo.GetValue(currProp, null);
            }
            return currProp;
        }

    }
}
