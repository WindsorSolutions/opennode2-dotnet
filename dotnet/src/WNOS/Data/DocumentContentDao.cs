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
using System.Data;
using System.Data.Common;
using System.Reflection;
using System.IO;

using Spring.Data.Generic;
using Spring.Data.Common;
using Spring.Transaction.Support;

using Common.Logging;

using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSConnector.Provider;
using Windsor.Node2008.WNOSUtility;

namespace Windsor.Node2008.WNOS.Data
{
    /// <summary>
    /// Should be implementing interface but for now just use the raw object
    /// </summary>
    public class DocumentContentDao : BaseDao, IDocumentContentDao
    {
        public const string TABLE_NAME = "NDocumentContent";

        #region Init

        new public void Init()
        {
            base.Init();
		}

        #endregion

        #region Methods
		/// <summary>
		/// Get the document content from the DB.
		/// </summary>
        public byte[] GetDocumentContent(string transactionId, string id)
        {
            byte[] content =
                DoSimpleQueryForObjectDelegate<byte[]>(
                    TABLE_NAME, "DocumentId", id, "Data",
                    delegate(IDataReader reader, int rowNum)
                    {
                        object value = reader.GetValue(0);
                        return (byte[])value;
                    });
            return content;
        }
        /// <summary>
        /// Get the document content size from the DB.
        /// </summary>
        public int GetDocumentContentSize(string transactionId, string id)
        {
            string lengthQuery = this.IsOracleDatabase ? "LENGTH (Data)" : "DATALENGTH (Data)";
            int size = 0;
            DoSimpleQueryWithRowCallbackDelegate(TABLE_NAME, 
                "DocumentId", id, null, lengthQuery,
                delegate(IDataReader reader)
                {
                    size = int.Parse(reader.GetValue(0).ToString());
                });
            return size;
        }
        public void AddDocumentContent(string transactionId, string id, byte[] content, 
                                       bool overwriteExisting)
        {
            try
            {
                DoInsert(TABLE_NAME, "DocumentId;Data", id, content);
            }
            catch (Spring.Dao.DataIntegrityViolationException)
            {
                if (overwriteExisting)
                {
                    DoSimpleUpdateOne(TABLE_NAME, "DocumentId", new object[] { id },
                                      "Data", content);
                }
                else
                {
                    throw;
                }
            }
        }
        public void DeleteAllDocuments(string transactionId)
		{
            // NOP for now: By default, this is a cascade delete when the parent document is deleted
        }
        public void DeleteDocument(string id)
        {
            // NOP for now: By default, this is a cascade delete when the parent document is deleted
        }
        #endregion

        #region Properties

        #endregion
    }
}
