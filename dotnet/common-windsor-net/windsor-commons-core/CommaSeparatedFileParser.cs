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
using System.Text;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using Microsoft.VisualBasic.FileIO;

namespace Windsor.Commons.Core
{
    /// <summary>
    /// Helper class for dealing with comma-separated files in a type-safe and column-order-independent manner.
    /// 
    /// Usage:
    /// 
    ///     using (CommaSeparatedFileParser parser = new CommaSeparatedFileParser(path))
    ///     {
    ///         while ( parser.NextLine() ) 
    ///         {
    ///             int myValue;
    ///             if ( parser.GetValue("MyColumnName", out myValue) ) 
    ///             {
    ///                 // Do something
    ///             }
    ///             int myValue2 = parser.GetValue&lt;int&gt;("MyColumnName2");
    ///         }
    ///     }
    /// </summary>
    public class CommaSeparatedFileParser : TextFieldParser
    {
        public CommaSeparatedFileParser(Stream stream)
            : base(stream)
        {
            Init();
        }
        public CommaSeparatedFileParser(TextReader reader)
            : base(reader)
        {
            Init();
        }
        public CommaSeparatedFileParser(string path)
            : base(path)
        {
            Init();
        }
        public CommaSeparatedFileParser(Stream stream, Encoding defaultEncoding)
            : base(stream, defaultEncoding)
        {
            Init();
        }
        public CommaSeparatedFileParser(string path, Encoding defaultEncoding)
            : base(path, defaultEncoding)
        {
            Init();
        }
        public CommaSeparatedFileParser(Stream stream, Encoding defaultEncoding, bool detectEncoding)
            : base(stream, defaultEncoding, detectEncoding)
        {
            Init();
        }
        public CommaSeparatedFileParser(string path, Encoding defaultEncoding, bool detectEncoding)
            : base(path, defaultEncoding, detectEncoding)
        {
            Init();
        }
        public CommaSeparatedFileParser(Stream stream, Encoding defaultEncoding, bool detectEncoding, bool leaveOpen)
            : base(stream, defaultEncoding, detectEncoding, leaveOpen)
        {
            Init();
        }

        /// <summary>
        /// Returns true if there is another input line to process.
        /// </summary>
        public virtual bool NextLine()
        {
            m_NextValues = ReadFields();
            if (CollectionUtils.IsNullOrEmpty(m_NextValues))
            {
                return false;
            }
            if (m_NextValues.Length != m_ColumnNameToIndexMap.Count)
            {
                throw new InvalidDataException(string.Format("Row number {0} contains {1} element(s), but it should contain {2} element(s): \"{3}\"",
                                                             LineNumber, m_NextValues.Length.ToString(), m_ColumnNameToIndexMap.Count.ToString(),
                                                             GetLine()));
            }
            return true;
        }
        /// <summary>
        /// Returns true if the stream contains the specified column.
        /// </summary>
        public virtual bool HasColumn(string columnName)
        {
            return m_ColumnNameToIndexMap.ContainsKey(columnName.ToUpper());
        }

        /// <summary>
        /// Indexer for column name
        /// </summary>
        public virtual string this[string columnName]
        {
            get
            {
                return GetColumnString(columnName);
            }
        }
        public IList<string> CurrentRowValues
        {
            get
            {
                return m_NextValues;
            }
        }

        /// <summary>
        /// Returns true and column value if the current row's column value is a non-empty string, otherwise
        /// returns false and the default value for T.
        /// </summary>
        public virtual bool GetValue<T>(string columnName, out T value)
        {
            string strValue = GetColumnString(columnName);
            if (string.IsNullOrEmpty(strValue))
            {
                value = default(T);
                return false;
            }
            else
            {
                value = ChangeType<T>(strValue);
                return true;
            }
        }
        /// <summary>
        /// Returns column value if the current row's column value is a non-empty string, otherwise
        /// returns the default value for T.
        /// </summary>
        public virtual T GetValue<T>(string columnName)
        {
            string strValue = GetColumnString(columnName);
            if (string.IsNullOrEmpty(strValue))
            {
                return default(T);
            }
            else
            {
                return ChangeType<T>(strValue);
            }
        }
        public virtual string GetLine()
        {
            if (m_NextValues != null)
            {
                return StringUtils.Join(COMMA.ToString(), m_NextValues);
            }
            else
            {
                return string.Empty;
            }
        }
        public virtual int GetColumnIndex(string columnName)
        {
            int index;
            if (!m_ColumnNameToIndexMap.TryGetValue(columnName.ToUpper(), out index))
            {
                throw new ArgumentException(string.Format("The file does not contain a column with the name \"{0}\"", columnName));
            }
            return index;
        }
        protected virtual string GetColumnString(string columnName)
        {
            return m_NextValues[GetColumnIndex(columnName)];
        }
        protected virtual T ChangeType<T>(string strValue)
        {
            if (typeof(T).IsEnum)
            {
                return (T)Enum.Parse(typeof(T), strValue);
            }
            else
            {
                return (T)Convert.ChangeType(strValue, typeof(T));
            }
        }
        protected virtual char Delimiter
        {
            get
            {
                return COMMA;
            }
        }
        protected virtual void Init()
        {
            TextFieldType = FieldType.Delimited;
            Delimiters = new string[] { Delimiter.ToString() };

            // Get column header fields
            string[] columnNames = ReadFields();
            if (CollectionUtils.IsNullOrEmpty(columnNames))
            {
                throw new InvalidDataException(string.Format("The file does not contain valid column headers"));
            }
            m_ColumnNameToIndexMap = new Dictionary<string, int>();
            for (int i = 0; i < columnNames.Length; ++i)
            {
                string columnName = columnNames[i].ToUpper();
                if (m_ColumnNameToIndexMap.ContainsKey(columnName))
                {
                    throw new InvalidDataException(string.Format("The file contains duplicate column headers: \"{0}.\"  Column headers are case-insensitive",
                                                                 columnNames[i]));
                }
                m_ColumnNameToIndexMap.Add(columnName, i);
            }
        }

        private Dictionary<string, int> m_ColumnNameToIndexMap;
        private string[] m_NextValues;
        private const char COMMA = ',';
    }
    public class TabSeparatedFileParser : CommaSeparatedFileParser
    {
        public TabSeparatedFileParser(Stream stream)
            : base(stream)
        {
        }
        public TabSeparatedFileParser(TextReader reader)
            : base(reader)
        {
        }
        public TabSeparatedFileParser(string path)
            : base(path)
        {
        }
        public TabSeparatedFileParser(Stream stream, Encoding defaultEncoding)
            : base(stream, defaultEncoding)
        {
        }
        public TabSeparatedFileParser(string path, Encoding defaultEncoding)
            : base(path, defaultEncoding)
        {
        }
        public TabSeparatedFileParser(Stream stream, Encoding defaultEncoding, bool detectEncoding)
            : base(stream, defaultEncoding, detectEncoding)
        {
        }
        public TabSeparatedFileParser(string path, Encoding defaultEncoding, bool detectEncoding)
            : base(path, defaultEncoding, detectEncoding)
        {
        }
        public TabSeparatedFileParser(Stream stream, Encoding defaultEncoding, bool detectEncoding, bool leaveOpen)
            : base(stream, defaultEncoding, detectEncoding, leaveOpen)
        {
        }

        protected override char Delimiter
        {
            get
            {
                return TAB;
            }
        }
        private const char TAB = '\t';
    }
}
