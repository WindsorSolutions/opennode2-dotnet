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
using System.Xml.Serialization;
using System.ComponentModel;
using Windsor.Commons.Core;

namespace Windsor.Commons.XsdOrm3.Implementations
{
    public class SameTableElementInfo : MemberInfoWrapper
    {
        public SameTableElementInfo(Table parentTable, Type valueType, MemberInfo member, SameTableElementInfo parentSameTableElementInfo)
            : base(member, null)
        {
            ParentTable = parentTable;
            ValueType = valueType;
            ParentSameTableElementInfo = parentSameTableElementInfo;
        }
        public ICollection<SameTableElementInfo> ChildSameTableElements
        {
            get
            {
                return m_ChildSameTableElements;
            }
            set
            {
                m_ChildSameTableElements = value;
                m_AllColumns = null;
            }
        }
        public ICollection<Column> AllColumns
        {
            get
            {
                if (m_AllColumns == null)
                {
                    m_AllColumns = new List<Column>(DirectColumns);

                    if (m_ChildSameTableElements != null)
                    {
                        foreach (SameTableElementInfo sameTableElementInfo in m_ChildSameTableElements)
                        {
                            m_AllColumns.AddRange(sameTableElementInfo.AllColumns);
                        }
                    }
                }
                return m_AllColumns;
            }
        }
        public ICollection<Column> DirectColumns
        {
            get
            {
                return m_DataColumns;
            }
        }
        public Column AddDataColumn(MemberInfo member, MemberInfo isSpecifiedMember,
                                    ColumnAttribute columnAttribute)
        {
            ExceptionUtils.ThrowIfTrue((columnAttribute is PrimaryKeyAttribute) || (columnAttribute is ForeignKeyAttribute),
                                       "(columnAttribute is PrimaryKeyAttribute) || (columnAttribute is ForeignKeyAttribute)");
            Column column = new Column(ParentTable, member, isSpecifiedMember, columnAttribute);
            CollectionUtils.Add(column, ref m_DataColumns);
            m_AllColumns = null;
            return column;
        }
        public override string ToString()
        {
            string text = MemberName;
            text += ", " + ParentTable.TableName;
            return text;
        }
        public Type ValueType;
        public bool NotNull = false;
        public Table ParentTable;
        public SameTableElementInfo ParentSameTableElementInfo;
        private List<Column> m_DataColumns = new List<Column>();
        private List<Column> m_AllColumns = null;
        private ICollection<SameTableElementInfo> m_ChildSameTableElements;
    }
    public class ChildRelationInfo : MemberInfoWrapper
    {
        public ChildRelationInfo(Type parentValueType, Type valueType, MemberInfo member, string elementMemberName, MemberInfo choiceMember,
                                 string description, bool isOneToMany, SameTableElementInfo sameTableElementInfo) :
            base(member, choiceMember)
        {
            ExceptionUtils.ThrowIfNull(parentValueType, "parentValueType");
            ExceptionUtils.ThrowIfNull(valueType, "valueType");
            Description = description;
            IsOneToMany = isOneToMany;
            ParentValueType = parentValueType;
            ValueType = valueType;
            ElementMemberName = elementMemberName;    // This may be different from member.Name if a XmlElementAttribute is used for "public object[] Items"
            if (sameTableElementInfo != null)
            {
                ParentToMemberChain = new List<SameTableElementInfo>();
                SameTableElementInfo nextSameTableElementInfo = sameTableElementInfo;
                do
                {
                    ParentToMemberChain.Add(nextSameTableElementInfo);
                    nextSameTableElementInfo = nextSameTableElementInfo.ParentSameTableElementInfo;
                } while (nextSameTableElementInfo != null);
                ParentToMemberChain.Reverse();
            }
        }
        public override string ToString()
        {
            string text = MemberName;
            if (!string.IsNullOrEmpty(ElementMemberName))
            {
                text += ", " + ElementMemberName;
            }
            if (ChildTable != null)
            {
                text += ", " + ChildTable.TableName;
            }
            return text;
        }

        public bool IsOneToMany;
        public string Description;
        public Type ParentValueType;
        public Type ValueType;
        public string ElementMemberName;
        public Table ChildTable;
        public List<SameTableElementInfo> ParentToMemberChain;
    }
}
