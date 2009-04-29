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

namespace Windsor.Commons.XsdOrm.Implementations
{
    public class MemberInfoWrapper
    {
        public MemberInfoWrapper(MemberInfo member, string memberPath, MemberInfo isSpecifiedMember)
        {
            ExceptionUtils.ThrowIfNull(member, "member");
            ExceptionUtils.ThrowIfEmptyString(memberPath, "memberPath");

            m_MemberPropertyInfo = member as PropertyInfo;
            m_MemberFieldInfo = member as FieldInfo;
            m_MemberInfoPath = memberPath;
            m_IsSpecifiedMemberInfo = isSpecifiedMember;
            if ((m_MemberPropertyInfo == null) && (m_MemberFieldInfo == null))
            {
                throw new ArgumentException(string.Format("The input member instance cannot be mapped to PropertyInfo or FieldInfo: {0}.{1}",
                                                          member.DeclaringType.ToString(), member.Name));
            }
            if (m_IsSpecifiedMemberInfo != null)
            {
                if (ReflectionUtils.GetFieldOrPropertyValueType(m_IsSpecifiedMemberInfo) != typeof(bool))
                {
                    throw new ArgumentException("isSpecifiedMember must have a value type of \"bool\"");
                }
            }
            if (m_MemberPropertyInfo != null)
            {
                m_MemberType = m_MemberPropertyInfo.PropertyType;
            }
            else if (m_MemberFieldInfo != null)
            {
                m_MemberType = m_MemberFieldInfo.FieldType;
            }
            else
            {
                throw new ArgumentException("member must be either a PropertyInfo or FieldInfo instance");
            }
            m_ParentInfoPath = Utils.GetTypePathParent(m_MemberInfoPath);
        }

        public override string ToString()
        {
            return ReflectionUtils.GetPublicPropertiesString(this);
        }
        public string MemberInfoPath
        {
            get { return m_MemberInfoPath; }
        }
        public MemberInfo MemberInfo
        {
            get { return (m_MemberPropertyInfo != null) ? (MemberInfo)m_MemberPropertyInfo : (MemberInfo)m_MemberFieldInfo; }
        }
        public Type MemberType
        {
            get { return m_MemberType; }
        }
        public MemberInfo IsSpecifiedMemberInfo
        {
            get { return m_IsSpecifiedMemberInfo; }
        }
        public IList<MemberInfo> ParentToMemberChain
        {
            get { return m_ParentToMemberChain; }
            set { m_ParentToMemberChain = value; }
        }
        public string ParentInfoPath
        {
            get { return m_ParentInfoPath; }
            set { m_ParentInfoPath = value; }
        }
        protected virtual void SetCachedValue(object primaryKey, object secondaryKey, object value)
        {
        }
        protected virtual bool GetCachedValue(object primaryKey, object secondaryKey, out object value)
        {
            value = null;
            return false;
        }
        protected virtual object GetActualGetInstance<T>(T instance)
        {
            if (m_ParentToMemberChain != null)
            {
                object getInstance;
                if (!GetCachedValue(m_ParentToMemberChain, instance, out getInstance))
                {
                    getInstance = instance;
                    foreach (MemberInfo memberInfo in m_ParentToMemberChain)
                    {
                        FieldInfo fieldInfo = memberInfo as FieldInfo;
                        if (fieldInfo != null)
                        {
                            getInstance = fieldInfo.GetValue(getInstance);
                        }
                        else
                        {
                            PropertyInfo propertyInfo = memberInfo as PropertyInfo;
                            getInstance = propertyInfo.GetValue(getInstance, null);
                        }
                        if (getInstance == null)
                        {
                            break;
                        }
                    }
                    SetCachedValue(m_ParentToMemberChain, instance, getInstance);
                }
                return getInstance;
            }
            else
            {
                return instance;
            }
        }
        protected virtual object GetActualSetInstance<T>(T instance, object value)
        {
            if (m_ParentToMemberChain != null)
            {
                object getInstance;
                if (!GetCachedValue(m_ParentToMemberChain, instance, out getInstance))
                {
                    getInstance = instance;
                    foreach (MemberInfo memberInfo in m_ParentToMemberChain)
                    {
                        FieldInfo fieldInfo = memberInfo as FieldInfo;
                        PropertyInfo propertyInfo = null;
                        object nextInstance;
                        if (fieldInfo != null)
                        {
                            nextInstance = fieldInfo.GetValue(getInstance);
                        }
                        else
                        {
                            propertyInfo = memberInfo as PropertyInfo;
                            nextInstance = propertyInfo.GetValue(getInstance, null);
                        }
                        if (nextInstance == null)
                        {
                            if (value == null)
                            {
                                return null;  // Don't create a new object if the value to set is null
                            }
                            else
                            {
                                Type createType = (fieldInfo != null) ? fieldInfo.FieldType : propertyInfo.PropertyType;
                                nextInstance = Activator.CreateInstance(createType);
                                if (fieldInfo != null)
                                {
                                    fieldInfo.SetValue(getInstance, nextInstance);
                                }
                                else
                                {
                                    propertyInfo.SetValue(getInstance, nextInstance, null);
                                }
                            }
                        }
                        getInstance = nextInstance;
                    }
                    if (getInstance != null)
                    {
                        SetCachedValue(m_ParentToMemberChain, instance, getInstance);
                    }
                }
                return getInstance;
            }
            else
            {
                return instance;
            }
        }
        public virtual object GetMemberValue<T>(T instance)
        {
            object getInstance = GetActualGetInstance(instance);
            if (getInstance == null)
            {
                return null;
            }
            if (m_IsSpecifiedMemberInfo != null)
            {
                if (ReflectionUtils.GetFieldOrPropertyValue<bool>(getInstance, m_IsSpecifiedMemberInfo) == false)
                {
                    return null;
                }
            }
            object value;
            if (m_MemberPropertyInfo != null)
            {
                value = m_MemberPropertyInfo.GetValue(getInstance, null);
            }
            else
            {
                value = m_MemberFieldInfo.GetValue(getInstance);
            }
            return value;
        }
        public virtual IEnumerable GetMemberEnumerable<T>(T instance)
        {
            object getInstance = GetActualGetInstance(instance);
            IEnumerable value = GetMemberValue(getInstance) as IEnumerable;
            return (value != null) ? value : new object[0];
        }
        public virtual void SetMemberValue<T>(T instance, object value)
        {
            object setInstance = GetActualSetInstance(instance, value);
            if (setInstance == null)
            {
                return;
            }

            if (value != null)
            {
                Type valueType = value.GetType();
                if (m_MemberType != valueType)
                {
                    if (m_MemberType.IsEnum)
                    {
                        if (valueType == typeof(string))
                        {
                            value = Enum.Parse(m_MemberType, value.ToString(), true);
                        }
                        else
                        {
                            throw new InvalidCastException(string.Format("Type \"{0}\" cannot be cast to type \"{1}\" for member \"{2}\"",
                                                                         valueType.FullName, m_MemberType.FullName, m_MemberInfoPath));
                        }
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
                            value = Convert.ChangeType(value, m_MemberType);
                        }
                    }
                }
                if (m_IsSpecifiedMemberInfo != null)
                {
                    ReflectionUtils.SetFieldOrPropertyValue(setInstance, m_IsSpecifiedMemberInfo, true);
                }
            }
            else if (m_IsSpecifiedMemberInfo != null)
            {
                ReflectionUtils.SetFieldOrPropertyValue(setInstance, m_IsSpecifiedMemberInfo, false);
            }
            if (m_MemberPropertyInfo != null)
            {
                m_MemberPropertyInfo.SetValue(setInstance, value, null);
            }
            else
            {
                m_MemberFieldInfo.SetValue(setInstance, value);
            }
        }
        protected string m_MemberInfoPath;
        protected PropertyInfo m_MemberPropertyInfo;
        protected FieldInfo m_MemberFieldInfo;
        protected Type m_MemberType;
        protected MemberInfo m_IsSpecifiedMemberInfo;
        protected IList<MemberInfo> m_ParentToMemberChain;
        protected string m_ParentInfoPath;
    }
}
