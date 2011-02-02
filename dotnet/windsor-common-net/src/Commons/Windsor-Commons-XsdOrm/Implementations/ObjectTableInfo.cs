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
    public class ObjectTableInfo
    {
        public ObjectTableInfo(string tableName)
        {
            m_TableName = tableName;
        }
        public void AddColumn(Column column)
        {
            if (column.Table.TableName != m_TableName)
            {
                throw new ArgumentException(string.Format("The input column does not belong to this table: \"{0}\" vs. \"{1}\"",
                                                          column.Table.TableName, m_TableName));
            }
            if (ContainsColumn(column.ColumnName))
            {
                throw new ArgumentException(string.Format("This table already contains a column with the same name: \"{0}\"",
                                                          column.ColumnName));
            }
            m_Columns.Add(column);
            PrimaryKeyColumn primaryKeyColumn = column as PrimaryKeyColumn;
            if (primaryKeyColumn != null)
            {
                m_PrimaryKeyColumns.Add(primaryKeyColumn);
            }
        }
        public bool TryGetColumn(string columnName, out Column column)
        {
            column = null;
            foreach (Column testColumn in m_Columns)
            {
                if (testColumn.ColumnName == columnName)
                {
                    column = testColumn;
                    return true;
                }
            }
            return false;
        }
        public bool ContainsColumn(string columnName)
        {
            Column column;
            return TryGetColumn(columnName, out column);
        }
        public string TableName
        {
            get { return m_TableName; }
        }
        public ICollection<Column> Columns
        {
            get { return m_Columns; }
        }
        public List<PrimaryKeyColumn> PrimaryKeyColumns
        {
            get { return m_PrimaryKeyColumns; }
        }
        public override string ToString()
        {
            return ReflectionUtils.GetPublicPropertiesString(this);
        }
        private string m_TableName;
        private List<Column> m_Columns = new List<Column>();
        private List<PrimaryKeyColumn> m_PrimaryKeyColumns = new List<PrimaryKeyColumn>();
    }
}
