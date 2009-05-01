#region License
/*
Copyright (c) 2009, The Environmental Council of the States (ECOS)
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions
are met:

 * Redistributions of source code must retain the above copyright
   notice, this list of conditions and the following disclaimer.
 * Redistributions in binary form must reproduce the above copyright
   notice, this list of conditions and the following disclaimer in the
   documentation and/or other materials provided with the distribution.
 * Neither the name of the ECOS nor the names of its contributors may
   be used to endorse or promote products derived from this software
   without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
"AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS
FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE
COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT,
INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING,
BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT
LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN
ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
POSSIBILITY OF SUCH DAMAGE.
*/
#endregion

using System;
using System.Collections;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace Windsor.Commons.Core
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ToStringQualifierAttribute : Attribute
    {
        private bool _ignore;
        private bool _collectionCountOnly;

        public ToStringQualifierAttribute() { }

        /// <summary>
        /// Ignore this property in the string output
        /// </summary>
        public bool Ignore
        {
            get { return _ignore; }
            set { _ignore = value; }
        }
        /// <summary>
        /// Only output ICollection.Count, not any of the elements in the string output
        /// </summary>
        public bool CollectionCountOnly
        {
            get { return _collectionCountOnly; }
            set { _collectionCountOnly = value; }
        }
    }

    /// <summary>
    /// Basic helper functions for dealing with reflection.
    /// </summary>
    public static class ReflectionUtils
    {
        /// <summary>
        /// This works around an issue in .NET where Type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | 
        /// BindingFlags.Instance) does not return private, inherited fields!
        /// </summary>
        public static IList<FieldInfo> GetAllPublicAndPrivateInstanceFields(Type inType)
        {
            List<FieldInfo> fieldInfoList = new List<FieldInfo>();
            Type curType = inType;
            do
            {
                FieldInfo[] fieldInfoArray = curType.GetFields(BindingFlags.Public | BindingFlags.NonPublic |
                                                               BindingFlags.Instance | BindingFlags.DeclaredOnly);
                fieldInfoList.AddRange(fieldInfoArray);
                curType = curType.BaseType;
            } while (curType != null);
            return fieldInfoList;
        }
        /// <summary>
        /// This works around an issue in .NET where Type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | 
        /// BindingFlags.Instance) does not return private, inherited fields!
        /// </summary>
        public static FieldInfo GetFieldByName(Type inType, string fieldName)
        {
            List<FieldInfo> fieldInfoList = new List<FieldInfo>();
            Type curType = inType;
            do
            {
                FieldInfo fieldInfo = curType.GetField(fieldName, BindingFlags.Public | BindingFlags.NonPublic |
                                                                  BindingFlags.Instance | BindingFlags.DeclaredOnly);
                if (fieldInfo != null)
                {
                    return fieldInfo;
                }
                curType = curType.BaseType;
            } while (curType != null);
            return null;
        }
        public static string GetPublicPropertiesString(object obj)
        {
            return GetPublicPropertiesString(obj, 4096);
        }
        public static void SetFieldValue(object obj, string fieldName, object fieldValue)
        {
            FieldInfo field = GetFieldByName(obj.GetType(), fieldName);
            if (field == null)
            {
                throw new ArgumentException(string.Format("The field {0} was not found for the object {1}", fieldName, obj.GetType().FullName));
            }
            field.SetValue(obj, fieldValue);
        }
        public static void SetFieldOrPropertyValue(object obj, MemberInfo memberInfo, object value)
        {
            PropertyInfo propertyInfo = (memberInfo as PropertyInfo);
            if (propertyInfo != null)
            {
                propertyInfo.SetValue(obj, value, null);
                return;
            }
            FieldInfo fieldInfo = (memberInfo as FieldInfo);
            if (fieldInfo != null)
            {
                fieldInfo.SetValue(obj, value);
                return;
            }
            throw new ArgumentException("memberInfo must be either a PropertyInfo or FieldInfo instance");
        }
        public static Type GetFieldOrPropertyValueType(MemberInfo memberInfo)
        {
            PropertyInfo propertyInfo = (memberInfo as PropertyInfo);
            if (propertyInfo != null)
            {
                return propertyInfo.PropertyType;
            }
            FieldInfo fieldInfo = (memberInfo as FieldInfo);
            if (fieldInfo != null)
            {
                return fieldInfo.FieldType;
            }
            throw new ArgumentException("memberInfo must be either a PropertyInfo or FieldInfo instance");
        }
        public static T GetFieldOrPropertyValue<T>(object obj, MemberInfo memberInfo)
        {
            PropertyInfo propertyInfo = (memberInfo as PropertyInfo);
            if (propertyInfo != null)
            {
                return (T)propertyInfo.GetValue(obj, null);
            }
            FieldInfo fieldInfo = (memberInfo as FieldInfo);
            if (fieldInfo != null)
            {
                return (T)fieldInfo.GetValue(obj);
            }
            throw new ArgumentException("memberInfo must be either a PropertyInfo or FieldInfo instance");
        }
        public static T GetFieldOrPropertyValueByName<T>(object obj, string memberName)
        {
            Type objectType = obj.GetType();
            PropertyInfo propertyInfo = objectType.GetProperty(memberName);
            if (propertyInfo != null)
            {
                return (T)propertyInfo.GetValue(obj, null);
            }
            FieldInfo fieldInfo = objectType.GetField(memberName);
            if (fieldInfo != null)
            {
                return (T)fieldInfo.GetValue(obj);
            }
            throw new ArgumentException(string.Format("The object {0} does not contain a property or field with the name {1}",
                                                      objectType.FullName, memberName));
        }
        public static string GetPublicPropertiesString(object obj, int maxNumChars)
        {
            if (IsCurGetPublicPropertiesStringObject(obj))
            {
                return "*repeat*";
            }
            try
            {
                StringBuilder sb = new StringBuilder();
                if (obj == null)
                {
                    sb.Append("null");
                }
                else
                {
                    try
                    {
                        Type type = obj.GetType();
                        PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                        foreach (PropertyInfo prop in properties)
                        {
                            ToStringQualifierAttribute qualifier = null;
                            if (prop.IsDefined(typeof(ToStringQualifierAttribute), false))
                            {
                                object[] qualifiers = prop.GetCustomAttributes(typeof(ToStringQualifierAttribute), false);
                                if (qualifiers.Length > 0)
                                {
                                    qualifier = qualifiers[0] as ToStringQualifierAttribute;
                                    if (qualifier != null)
                                    {
                                        if (qualifier.Ignore)
                                        {
                                            continue;
                                        }
                                    }
                                }
                            }
                            if (sb.Length >= maxNumChars)
                            {
                                break;
                            }
                            if (sb.Length > 0)
                            {
                                sb.Append("; ");
                            }
                            sb.AppendFormat("{0}=\"", prop.Name);
                            try
                            {
                                object value = prop.GetValue(obj, null);
                                if (value == null)
                                {
                                    sb.Append("null");
                                }
                                else
                                {
                                    ICollection collection = value as ICollection;
                                    if (collection != null)
                                    {
                                        if ((qualifier != null) && qualifier.CollectionCountOnly)
                                        {
                                            AppendCollectionCountString(collection, maxNumChars, sb);
                                        }
                                        else
                                        {
                                            AppendCollectionString(collection, maxNumChars, sb);
                                        }
                                    }
                                    else
                                    {
                                        sb.Append(value.ToString());
                                    }
                                }
                            }
                            catch (Exception e2)
                            {
                                sb.Append("ERROR: " + e2.Message);
                            }
                            sb.Append("\"");
                        }
                        ICollection mainCollection = obj as ICollection;
                        if (mainCollection != null)
                        {
                            sb.Append(" ");
                            AppendEnumerableString(mainCollection, maxNumChars, 16, sb);
                        }
                    }
                    catch (Exception e)
                    {
                        sb.Append("EXCEPTION: " + e.Message);
                    }
                }
                if (sb.Length > maxNumChars)
                {
                    sb.Remove(maxNumChars, sb.Length - maxNumChars);
                }
                return sb.ToString();
            }
            catch (Exception)
            {
                return "EXCEPTION";
            }
            finally
            {
                RemoveCurGetPublicPropertiesStringObject(obj);
            }
        }
        public static void AppendCollectionString(ICollection collection, int maxNumChars,
                                                   StringBuilder sb)
        {
            sb.AppendFormat("Count={0} ", collection.Count.ToString());
            AppendEnumerableString(collection, maxNumChars, 16, sb);
        }
        public static void AppendCollectionCountString(ICollection collection, int maxNumChars,
                                                        StringBuilder sb)
        {
            sb.AppendFormat("Count={0} ", collection.Count.ToString());
            AppendEnumerableString(collection, maxNumChars, 0, sb);
        }
        public static void AppendEnumerableString(IEnumerable collection, int maxNumChars, int maxNumElements,
                                                   StringBuilder sb)
        {
            sb.Append("[");
            int i = 0;
            foreach (object item in collection)
            {
                if (sb.Length >= maxNumChars)
                {
                    break;
                }
                if (i > 0)
                {
                    sb.Append(",");
                }
                if (i >= maxNumElements)
                {
                    sb.Append("...");
                    break;
                }
                else
                {
                    sb.Append(item.ToString());
                }
                i++;
            }
            sb.Append("]");
        }
        public static string GetDescription(ICustomAttributeProvider obj)
        {
            object[] descriptionAttributes = obj.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (!CollectionUtils.IsNullOrEmpty(descriptionAttributes))
            {
                return ((DescriptionAttribute)descriptionAttributes[0]).Description;
            }
            return null;
        }
        /// <summary>
        /// Check if a string is already being generated for this object ... if so, this would cause a stack-overflow, so
        /// exit the string generation code early.
        /// </summary>
        private static bool IsCurGetPublicPropertiesStringObject(object obj)
        {
            try
            {
                if (s_CurGetPublicPropertiesStringObjects != null)
                {
                    foreach (object testObj in s_CurGetPublicPropertiesStringObjects)
                    {
                        if (object.ReferenceEquals(obj, testObj))
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    s_CurGetPublicPropertiesStringObjects = new List<object>();
                }
                s_CurGetPublicPropertiesStringObjects.Add(obj);
                return false;
            }
            catch (Exception)
            {
                return true;
            }
        }
        private static void RemoveCurGetPublicPropertiesStringObject(object obj)
        {
            try
            {
                int index;
                for (index = s_CurGetPublicPropertiesStringObjects.Count - 1; index >= 0; --index)
                {
                    if (object.ReferenceEquals(obj, s_CurGetPublicPropertiesStringObjects[index]))
                    {
                        break;
                    }
                }
                if (index >= 0)
                {
                    s_CurGetPublicPropertiesStringObjects.RemoveAt(index);
                }
                else
                {
                    DebugUtils.CheckDebuggerBreak();
                }
            }
            catch (Exception)
            {
            }
        }

        [ThreadStatic]
        private static List<object> s_CurGetPublicPropertiesStringObjects;
    }
}
