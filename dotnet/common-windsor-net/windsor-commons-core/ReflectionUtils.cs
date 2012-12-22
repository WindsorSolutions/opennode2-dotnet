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
using System.Reflection.Emit;
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

        public ToStringQualifierAttribute()
        {
        }

        /// <summary>
        /// Ignore this property in the string output
        /// </summary>
        public bool Ignore
        {
            get
            {
                return _ignore;
            }
            set
            {
                _ignore = value;
            }
        }
        /// <summary>
        /// Only output ICollection.Count, not any of the elements in the string output
        /// </summary>
        public bool CollectionCountOnly
        {
            get
            {
                return _collectionCountOnly;
            }
            set
            {
                _collectionCountOnly = value;
            }
        }
    }

    /// <summary>
    /// Basic helper functions for dealing with reflection.
    /// </summary>
    public static class ReflectionUtils
    {
        public delegate bool ForEachProperty(PropertyInfo propertyInfo);
        public delegate bool ForEachPropertyDescriptor(PropertyDescriptor propertyDescriptor);

        public static void ProcessPublicInstanceProperties(object obj, ForEachProperty forEach)
        {
            if (obj == null)
            {
                return;
            }
            ProcessPublicInstanceProperties(obj.GetType(), forEach);
        }
        public static void ProcessPublicInstancePropertyDescriptors(object obj, ForEachPropertyDescriptor forEach)
        {
            if (obj == null)
            {
                return;
            }
            ProcessPublicInstancePropertyDescriptors(obj.GetType(), forEach);
        }
        public static void ProcessPublicInstanceProperties(Type type, ForEachProperty forEach)
        {
            ProcessPublicInstanceProperties(type, forEach, false);
        }
        public static void ProcessPublicInstancePropertyDescriptors(Type type, ForEachPropertyDescriptor forEach)
        {
            ProcessPublicInstancePropertyDescriptors(type, forEach, false);
        }
        public static List<PropertyInfo> GetPublicInstanceProperties(Type type)
        {
            return GetPublicInstanceProperties(type, false);
        }
        public static List<PropertyInfo> GetPublicInstanceProperties(Type type, bool baseClassPropertiesFirst)
        {
            List<PropertyInfo> propertyList = new List<PropertyInfo>();
            Type curType = type;
            do
            {
                PropertyInfo[] properties = curType.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                if (baseClassPropertiesFirst)
                {
                    CollectionUtils.Reverse(properties);
                }
                propertyList.AddRange(properties);
                curType = curType.BaseType;
            } while (curType != null);
            if (baseClassPropertiesFirst)
            {
                propertyList.Reverse();
            }
            return propertyList;
        }
        public static void ProcessPublicInstanceProperties(Type type, ForEachProperty forEach, bool baseClassPropertiesFirst)
        {
            List<PropertyInfo> propertyList = GetPublicInstanceProperties(type, baseClassPropertiesFirst);
            foreach (PropertyInfo property in propertyList)
            {
                if (!forEach(property))
                {
                    return;
                }
            }
        }
        public static void ProcessPublicInstancePropertyDescriptors(Type type, ForEachPropertyDescriptor forEach, bool baseClassPropertiesFirst)
        {
            PropertyDescriptorCollection propertyDescriptors = TypeDescriptor.GetProperties(type);
            foreach (PropertyDescriptor propertyDescriptor in propertyDescriptors)
            {
                if (!forEach(propertyDescriptor))
                {
                    return;
                }
            }
        }

        public delegate bool ForEachPropertyWithSingleAttribute<T>(PropertyInfo propertyInfo, T attribute) where T : Attribute;
        public delegate bool ForEachPropertyDescriptorWithSingleAttribute<T>(PropertyDescriptor propertyDescriptor, T attribute) where T : Attribute;

        public static void ProcessPublicInstancePropertiesWithSingleAttribute<T>(Type type, ForEachPropertyWithSingleAttribute<T> forEach) where T : Attribute
        {
            ProcessPublicInstancePropertiesWithSingleAttribute<T>(type, forEach, false);
        }
        public static void ProcessPublicInstancePropertiesWithSingleAttribute<T>(Type type, ForEachPropertyDescriptorWithSingleAttribute<T> forEach) where T : Attribute
        {
            ProcessPublicInstancePropertyDescriptorsWithSingleAttribute<T>(type, forEach, false);
        }
        public static void ProcessPublicInstancePropertiesWithSingleAttribute<T>(Type type, ForEachPropertyWithSingleAttribute<T> forEach,
                                                                                 bool baseClassPropertiesFirst) where T : Attribute
        {
            ProcessPublicInstanceProperties(type, delegate(PropertyInfo propertyInfo)
            {
                object[] attributes = propertyInfo.GetCustomAttributes(true);
                T attribute = null;
                foreach (object curAttribute in attributes)
                {
                    T assignAttribute = curAttribute as T;
                    if (assignAttribute != null)
                    {
                        if (attribute != null)
                        {
                            return true; // More than one, don't call delegate for any!
                        }
                        attribute = assignAttribute;
                    }
                }
                if (attribute != null)
                {
                    return forEach(propertyInfo, attribute);
                }
                return true;
            }, baseClassPropertiesFirst);
        }
        public static void ProcessPublicInstancePropertyDescriptorsWithSingleAttribute<T>(Type type, ForEachPropertyDescriptorWithSingleAttribute<T> forEach,
                                                                                          bool baseClassPropertiesFirst) where T : Attribute
        {
            ProcessPublicInstancePropertyDescriptors(type, delegate(PropertyDescriptor propertyDescriptor)
            {
                AttributeCollection attributes = propertyDescriptor.Attributes;
                T attribute = null;
                foreach (Attribute curAttribute in attributes)
                {
                    T assignAttribute = curAttribute as T;
                    if (assignAttribute != null)
                    {
                        if (attribute != null)
                        {
                            return true; // More than one, don't call delegate for any!
                        }
                        attribute = assignAttribute;
                    }
                }
                if (attribute != null)
                {
                    return forEach(propertyDescriptor, attribute);
                }
                return true;
            }, baseClassPropertiesFirst);
        }
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
        public static object GetPublicOrPrivatePropertyValue(object obj, string propertyName, bool declaredOnly)
        {
            BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
            if (declaredOnly)
            {
                flags |= BindingFlags.DeclaredOnly;
            }
            PropertyInfo propInfo = obj.GetType().GetProperty(propertyName, flags);
            if (propInfo == null)
            {
                throw new ArgumentException(string.Format("The property {0} was not found for the object {1}",
                                                          propertyName, obj.GetType().FullName));
            }
            return propInfo.GetValue(obj, null);
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
        public static void SetStaticFieldValue(Type objType, string fieldName, object fieldValue)
        {
            FieldInfo fieldInfo = objType.GetField(fieldName, BindingFlags.Public | BindingFlags.NonPublic |
                                                              BindingFlags.Static | BindingFlags.DeclaredOnly);
            if (fieldInfo == null)
            {
                throw new ArgumentException(string.Format("The field {0} was not found for the object {1}", fieldName, objType.FullName));
            }
            fieldInfo.SetValue(null, fieldValue);
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
        public static Type GetFieldOrPropertyValueTypeByName<T>(string memberName)
        {
            MemberInfo memberInfo = GetInstanceMember<T>(memberName);
            return GetFieldOrPropertyValueType(memberInfo);
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
            return (T)GetFieldOrPropertyValueObject(obj, memberInfo);
        }
        public static object GetFieldOrPropertyValueObject(object obj, MemberInfo memberInfo)
        {
            PropertyInfo propertyInfo = (memberInfo as PropertyInfo);
            if (propertyInfo != null)
            {
                return propertyInfo.GetValue(obj, null);
            }
            FieldInfo fieldInfo = (memberInfo as FieldInfo);
            if (fieldInfo != null)
            {
                return fieldInfo.GetValue(obj);
            }
            throw new ArgumentException("memberInfo must be either a PropertyInfo or FieldInfo instance");
        }
        public static T GetFieldOrPropertyValueByName<T>(object obj, string memberName)
        {
            return (T)GetFieldOrPropertyValueObjectByName(obj, memberName);
        }
        public static object GetFieldOrPropertyValueObjectByName(object obj, string memberName)
        {
            Type objectType = obj.GetType();
            PropertyInfo propertyInfo = objectType.GetProperty(memberName);
            if (propertyInfo != null)
            {
                return propertyInfo.GetValue(obj, null);
            }
            FieldInfo fieldInfo = objectType.GetField(memberName);
            if (fieldInfo != null)
            {
                return fieldInfo.GetValue(obj);
            }
            throw new ArgumentException(string.Format("The object {0} does not contain a property or field with the name {1}",
                                                      objectType.FullName, memberName));
        }
        private static bool BuildMemberString(int maxNumChars, MemberInfo prop, object obj, StringBuilder sb)
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
                            return true;
                        }
                    }
                }
            }
            if (sb.Length >= maxNumChars)
            {
                return false;
            }
            if (sb.Length > 0)
            {
                sb.Append("; ");
            }
            sb.AppendFormat("{0}=\"", prop.Name);
            try
            {
                object value;
                PropertyInfo propInfo = prop as PropertyInfo;
                if (prop != null)
                {
                    value = propInfo.GetValue(obj, null);
                }
                else
                {
                    value = ((FieldInfo)prop).GetValue(obj);
                }
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
            return true;
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
                            if (!BuildMemberString(maxNumChars, prop, obj, sb))
                            {
                                break;
                            }
                        }
                        FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);
                        foreach (FieldInfo field in fields)
                        {
                            if (!BuildMemberString(maxNumChars, field, obj, sb))
                            {
                                break;
                            }
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
        public static bool IsNullableType(Type type)
        {
            return (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>));
        }
        public static Type GetNullableUnderlyingType(Type type)
        {
            return new NullableConverter(type).UnderlyingType;
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
        public static MemberInfo FindFirstPublicPropertyOrFieldWithAttribute(Type objectType, Type attributeToFind)
        {
            if (!typeof(Attribute).IsAssignableFrom(attributeToFind))
            {
                throw new ArgumentException("attributeToFind must be an Attribute type");
            }
            PropertyInfo[] properties = objectType.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            foreach (PropertyInfo prop in properties)
            {
                object[] qualifiers = prop.GetCustomAttributes(attributeToFind, true);
                foreach (object qualifier in qualifiers)
                {
                    if (attributeToFind.IsAssignableFrom(qualifier.GetType()))
                    {
                        return prop;
                    }
                }
            }
            FieldInfo[] fieldInfoArray = objectType.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            foreach (FieldInfo fieldInfo in fieldInfoArray)
            {
                object[] qualifiers = fieldInfo.GetCustomAttributes(attributeToFind, true);
                foreach (object qualifier in qualifiers)
                {
                    if (attributeToFind.IsAssignableFrom(qualifier.GetType()))
                    {
                        return fieldInfo;
                    }
                }
            }
            return null;
        }
        public static MemberInfo GetInstanceMember(Type objType, string memberName)
        {
            return GetInstanceMember(objType, memberName, true, true);
        }
        public static MemberInfo GetInstanceMember<T>(string memberName)
        {
            return GetInstanceMember<T>(memberName, true, true);
        }
        public static MemberInfo GetInstanceMember<T>(string memberName, bool includeInheritedMembers,
                                                      bool includeNonPublicMembers)
        {
            return GetInstanceMember(typeof(T), memberName, includeInheritedMembers, includeNonPublicMembers);
        }
        public static MemberInfo GetInstanceMember(Type objType, string memberName, bool includeInheritedMembers,
                                                   bool includeNonPublicMembers)
        {
            ExceptionUtils.ThrowIfEmptyString(memberName, "memberName");

            BindingFlags flags = BindingFlags.Instance | BindingFlags.Public;
            if (!includeInheritedMembers)
            {
                flags |= BindingFlags.DeclaredOnly;
            }
            if (includeNonPublicMembers)
            {
                flags |= BindingFlags.NonPublic;
            }

            PropertyInfo property = objType.GetProperty(memberName, flags);
            if (property == null)
            {
                FieldInfo field = objType.GetField(memberName, flags);
                if (field == null)
                {
                    throw new ArgumentException(string.Format("Did not find member \"{0}\" on type \"{1}\"", memberName,
                                                              objType.FullName));
                }
                return field;
            }
            return property;
        }
        public static object CallMethod<T>(T objInstance, string methodName, params object[] parameters)
        {
            MethodInfo methodInfo = GetInstanceMethod<T>(methodName);
            return methodInfo.Invoke(objInstance, parameters);
        }
        public static object CallMethod(object objInstance, string methodName, params object[] parameters)
        {
            MethodInfo methodInfo = GetInstanceMethod(objInstance, methodName);
            return methodInfo.Invoke(objInstance, parameters);
        }
        /// <summary>
        /// Call a virtual method non-virtually - like Reflection's MethodInfo.Invoke, 
        /// but doesn't do virtual dispatch.
        /// </summary>
        /// <param name="method">The method to invoke</param>
        /// <param name="args">The arguments to pass (including 'this')</param>
        /// <returns>The return value from the call</returns>
        public static object CallMethodNonVirtual<T>(T objInstance, string methodName, params object[] parameters)
        {
            // Reflection doesn't seem to have a way directly (eg. custom binders are 
            // only used for ambiguities).  Using a delegate also always seems to do 
            // virtual dispatch.

            // Use LCG to generate a temporary method that uses a 'call' instruction to
            // invoke the supplied method non-virtually.
            // Doing a non-virtual call on a virtual method outside the class that 
            // defines it will normally generate a VerificationException (PEVerify 
            // says "The 'this' parameter to the call must be the callng method's 
            // 'this' parameter.").  By associating the method with a type ("Program") 
            // in a full-trust assembly, we tell the JIT to skip this verification step.
            // Alternately we might want to associate it with method.DeclaringType - the
            // verification might then pass even if it's not skipped (eg. partial trust).
            MethodInfo methodInfo = GetInstanceMethod<T>(methodName);
            List<Type> paramTypes = new List<Type>();
            paramTypes.Add(methodInfo.DeclaringType);
            foreach (ParameterInfo paramInfo in methodInfo.GetParameters())
            {
                paramTypes.Add(paramInfo.ParameterType);
            }
            DynamicMethod dm = new DynamicMethod(
                "NonVirtualInvoker",    // name
                methodInfo.ReturnType,      // same return type as method we're calling 
                paramTypes.ToArray(),   // same parameter types as method we're calling
                typeof(T));       // associates with this full-trust code
            ILGenerator il = dm.GetILGenerator();
            for (int i = 0; i < paramTypes.Count; i++)
            {
                il.Emit(OpCodes.Ldarg, i);              // load all args
            }
            il.EmitCall(OpCodes.Call, methodInfo, null);   // call the method non-virtually
            il.Emit(OpCodes.Ret);                       // return what the call returned

            List<object> callParams = new List<object>(1 + parameters.Length);
            callParams.Add(objInstance);
            callParams.AddRange(parameters);

            // Call the emitted method, which in turn will call the method requested
            return dm.Invoke(null, callParams.ToArray());
        }

        public static void SetFieldOrProperty(object objInstance, string fieldOrPropertyName, object value)
        {
            SetFieldOrPropertyValue(objInstance, GetInstanceMember(objInstance.GetType(), fieldOrPropertyName), value);
        }
        public static MethodInfo GetInstanceMethod<T>(string methodName)
        {
            Type type = typeof(T);

            return GetInstanceMethod(type, methodName);
        }
        public static MethodInfo GetInstanceMethod(object objInstance, string methodName)
        {
            Type type = objInstance.GetType();

            return GetInstanceMethod(type, methodName);
        }
        public static MethodInfo GetInstanceMethod(Type type, string methodName)
        {
            ExceptionUtils.ThrowIfEmptyString(methodName, "methodName");

            BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

            MethodInfo methodInfo = type.GetMethod(methodName, flags);
            if (methodInfo == null)
            {
                throw new ArgumentException(string.Format("Did not find method \"{0}\" on type \"{1}\"", methodName,
                                                          type.FullName));
            }
            return methodInfo;
        }
        public static List<T> GetAttributesOfTypeForMember<T>(MemberInfo member) where T : Attribute
        {
            return CollectionUtils.ToList<T, object>(member.GetCustomAttributes(typeof(T), true));
        }
        public static List<AttribType> GetAttributesOfTypeForMember<AttribType, ObjectType>(string memberName) where AttribType : Attribute
        {
            return GetAttributesOfTypeForMember<AttribType>(GetInstanceMember<ObjectType>(memberName));
        }
        public static AttribType GetFirstAttributeOfTypeForMember<AttribType, ObjectType>(string memberName) where AttribType : Attribute
        {
            List<AttribType> list = GetAttributesOfTypeForMember<AttribType, ObjectType>(memberName);
            return CollectionUtils.IsNullOrEmpty(list) ? null : list[0];
        }

        [ThreadStatic]
        private static List<object> s_CurGetPublicPropertiesStringObjects;
    }
    public class ToStringClass
    {
        public override string ToString()
        {
            return ReflectionUtils.GetPublicPropertiesString(this);
        }
    }
}
