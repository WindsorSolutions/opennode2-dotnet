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

namespace Windsor.Commons.XsdOrm.Implementations 
{
    public abstract class Relation : MemberInfoWrapper
    {
        public Relation(Table parentTable, Table childTable,
                        MemberInfo member, string memberPath,
                        Type memberValueType, RelationAttribute relationAttribute) :
                        base(member, memberPath, null)
        {
            ExceptionUtils.ThrowIfNull(parentTable, "parentTable");
            ExceptionUtils.ThrowIfNull(relationAttribute, "relationAttribute");

            m_ParentTable = parentTable;
            m_ChildTable = childTable;
            m_MemberValueType = memberValueType;
            m_ChildForeignKeyColumnName = relationAttribute.ChildForeignKeyColumnName;
            m_ParentColumnName = relationAttribute.ParentColumnName;
        }

        public override string ToString()
        {
            return ReflectionUtils.GetPublicPropertiesString(this);
        }
        public Table ParentTable
        {
            get { return m_ParentTable; }
            set { m_ParentTable = value; }
        }
        public Table ChildTable
        {
            get { return m_ChildTable; }
            set { m_ChildTable = value; }
        }
        public string ParentColumnName
        {
            get { return m_ParentColumnName; }
            set { m_ParentColumnName = value; }
        }
        public Column ParentColumn
        {
            get { return m_ParentColumn; }
            set { m_ParentColumn = value; }
        }
        public string ChildForeignKeyColumnName
        {
            get { return m_ChildForeignKeyColumnName; }
            set { m_ChildForeignKeyColumnName = value; }
        }
        public ForeignKeyColumn ChildForeignKeyColumn
        {
            get { return m_ChildForeignKeyColumn; }
            set { m_ChildForeignKeyColumn = value; }
        }
        public Type MemberValueType
        {
            get { return m_MemberValueType; }
            set { m_MemberValueType = value; }
        }
        public int DatabaseInsertOrder
        {
            get
            {
                return m_DatabaseInsertOrder;
            }
            set
            {
                m_DatabaseInsertOrder = value;
            }
        }
        private Table m_ParentTable;
        private Table m_ChildTable;
        private string m_ParentColumnName;
        private string m_ChildForeignKeyColumnName;
        private Type m_MemberValueType;
        private ForeignKeyColumn m_ChildForeignKeyColumn;
        private Column m_ParentColumn;
        private int m_DatabaseInsertOrder = InvalidDatabaseInsertOrder;
        public const int InvalidDatabaseInsertOrder = int.MaxValue;
    }

    public class OneToManyRelation : Relation
    {
        public OneToManyRelation(Table parentTable, Table childTable, MemberInfo member, 
                                 string memberPath, Type memberValueType,
                                 OneToManyAttribute relationAttribute) :
            base(parentTable, childTable, member, memberPath, memberValueType, relationAttribute)
        {
        }
    }
    public class OneToOneRelation : Relation
    {
        public OneToOneRelation(Table parentTable, Table childTable, MemberInfo member, 
                                string memberPath, Type memberValueType,
                                OneToOneAttribute relationAttribute) :
            base(parentTable, childTable, member, memberPath, memberValueType, relationAttribute)
        {
        }
    }
    public class ManyToManyRelation : Relation
    {
        public ManyToManyRelation(Table parentTable, Table childTable, MemberInfo member, 
                                  string memberPath, Type memberValueType,
                                  ManyToManyAttribute relationAttribute) :
            base(parentTable, childTable, member, memberPath, memberValueType, relationAttribute)
        {
        }
    }
}
