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
using System.Collections.Generic;
using System.Reflection;
using System.Data;
using System.Collections;
using System.Xml.Serialization;
using System.ComponentModel;
using Windsor.Commons.Core;

namespace Windsor.Commons.XsdOrm2.Implementations
{
    public class MemberInfoWrapper
    {
        protected MemberInfoWrapper()
        {
        }
        public MemberInfoWrapper(MemberInfo member, MemberInfo isSpecifiedMember)
        {
            if (member != null)
            {
                m_MemberPropertyInfo = member as PropertyInfo;
                m_MemberFieldInfo = member as FieldInfo;
                if ((m_MemberPropertyInfo == null) && (m_MemberFieldInfo == null))
                {
                    throw new MappingException("The input member instance cannot be mapped to PropertyInfo or FieldInfo: {0}.{1}",
                                               member.ReflectedType.ToString(), member.Name);
                }
                if (m_MemberPropertyInfo != null)
                {
                    m_MemberType = m_MemberPropertyInfo.PropertyType;
                }
                else
                {
                    m_MemberType = m_MemberFieldInfo.FieldType;
                }
            }
            m_IsSpecifiedMemberInfo = isSpecifiedMember;
            if (m_IsSpecifiedMemberInfo != null)
            {
                //if (ReflectionUtils.GetFieldOrPropertyValueType(m_IsSpecifiedMemberInfo) != typeof(bool))
                //{
                //    throw new MappingException("isSpecifiedMember must have a value type of \"bool\"");
                //}
            }
            if ((m_MemberType != null) && ReflectionUtils.IsNullableType(m_MemberType))
            {
                m_NullableConverter = new NullableConverter(m_MemberType);
            }
        }
        public override string ToString()
        {
            return ReflectionUtils.GetPublicPropertiesString(this);
        }
        public string MemberName
        {
            get
            {
                return m_MemberType.Name;
            }
        }
        public MemberInfo MemberInfo
        {
            get
            {
                return (m_MemberPropertyInfo != null) ? (MemberInfo)m_MemberPropertyInfo : (MemberInfo)m_MemberFieldInfo;
            }
        }
        public Type MemberType
        {
            get
            {
                return m_MemberType;
            }
        }
        public MemberInfo IsSpecifiedMemberInfo
        {
            get
            {
                return m_IsSpecifiedMemberInfo;
            }
        }
        public virtual object GetMemberValue<T>(T instance)
        {
            if (instance == null)
            {
                return null;
            }
            if (m_IsSpecifiedMemberInfo != null)
            {
                if (ReflectionUtils.GetFieldOrPropertyValue<bool>(instance, m_IsSpecifiedMemberInfo) == false)
                {
                    return null;
                }
            }
            return GetActualMemberValue(instance);
        }
        protected virtual object GetActualMemberValue(object instance)
        {
            object value;
            if (m_MemberFieldInfo != null)
            {
                value = m_MemberFieldInfo.GetValue(instance);
            }
            else
            {
                value = m_MemberPropertyInfo.GetValue(instance, null);
            }
            return value;
        }
        public virtual IEnumerable GetMemberEnumerable<T>(T instance)
        {
            IEnumerable value = GetMemberValue(instance) as IEnumerable;
            return (value != null) ? value : s_EmptyEnumerable;
        }
        public virtual object GetSetMemberValue(object value)
        {
            if (value != null)
            {
                Type valueType = value.GetType();
                if (m_MemberType != valueType)
                {
                    if (m_MemberType.IsEnum)
                    {
                        if (valueType == typeof(string))
                        {
                            try
                            {
                                value = Enum.Parse(m_MemberType, value.ToString(), true);
                            }
                            catch (Exception e)
                            {
                                throw new MappingException(e, "Failed to convert value \"{0}\" to enum type \"{1}\" for member \"{2}\"",
                                                           value, m_MemberType.FullName, MemberName);
                            }
                        }
                        else
                        {
                            throw new MappingException("Type \"{0}\" cannot be cast to type \"{1}\" for member \"{2}\"",
                                                       valueType.FullName, m_MemberType.FullName, MemberName);
                        }
                    }
                    else if (m_MemberType == typeof(DateTime))
                    {
                        if (valueType == typeof(string))
                        {
                            try
                            {
                                if (string.IsNullOrEmpty((string)value))
                                {
                                    value = null;
                                }
                                else
                                {
                                    value = DateTime.Parse((string)value);
                                }
                            }
                            catch (Exception e)
                            {
                                throw new MappingException(e, "Failed to convert value \"{0}\" to DateTime for member \"{1}\"",
                                                           value, MemberName);
                            }
                        }
                        else
                        {
                            throw new MappingException("Type \"{0}\" cannot be cast to type \"{1}\" for member \"{2}\"",
                                                       valueType.FullName, m_MemberType.FullName, MemberName);
                        }
                    }
                    else if (m_NullableConverter != null)
                    {
                        value = m_NullableConverter.ConvertFrom(value);
                    }
                    else
                    {
                        ICollection collection = value as ICollection;
                        if ((collection != null) && typeof(ICollection).IsAssignableFrom(m_MemberType))
                        {
                            value = CollectionUtils.CreateCollectionFromCollection(m_MemberType, collection);
                        }
                        else
                        {
                            try
                            {
                                if (m_MemberType != typeof(object))
                                {
                                    value = Convert.ChangeType(value, m_MemberType);
                                }
                                else
                                {
                                }
                            }
                            catch (Exception e)
                            {
                                throw new MappingException(e, "Failed to convert value \"{0}\" to type \"{1}\" for member \"{2}\"",
                                                           value, m_MemberType.FullName, MemberName);
                            }
                        }
                    }
                }
            }
            return value;
        }
        public virtual void SetMemberValue<T>(T instance, object value)
        {
            if (instance == null)
            {
                return;
            }

            value = GetSetMemberValue(value);

            if (m_IsSpecifiedMemberInfo != null)
            {
                ReflectionUtils.SetFieldOrPropertyValue(instance, m_IsSpecifiedMemberInfo, (value != null));
            }
            SetActualMemberValue(instance, value);
        }
        protected virtual void SetActualMemberValue(object instance, object value)
        {
            try
            {
                if (m_MemberFieldInfo != null)
                {
                    m_MemberFieldInfo.SetValue(instance, value);
                }
                else
                {
                    m_MemberPropertyInfo.SetValue(instance, value, null);
                }
            }
            catch (Exception)
            {
                DebugUtils.CheckDebuggerBreak();
                throw;
            }
        }
        protected PropertyInfo m_MemberPropertyInfo;
        protected FieldInfo m_MemberFieldInfo;
        protected Type m_MemberType;
        protected MemberInfo m_IsSpecifiedMemberInfo;
        protected NullableConverter m_NullableConverter;
        protected static readonly object[] s_EmptyEnumerable = new object[0];
    }
}
