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
using Common.Logging;
using Windsor.Node2008.WNOSUtility;
using Windsor.Node2008.WNOS.Data;
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSPlugin;
using Windsor.Node2008.WNOSConnector.Provider;
using Windsor.Node2008.WNOSConnector.Logic;
using Windsor.Commons.Core;
using Windsor.Commons.Logging;

namespace Windsor.Node2008.WNOS.Logic
{
    public class DatabaseBasedContentManager : IDocumentContentManager
    {
        private static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());
        private IdProvider _idProvider;
        private IDocumentContentDao _documentContentDao;

        public void Init()
        {
            FieldNotInitializedException.ThrowIfNull(this, ref _idProvider);
            FieldNotInitializedException.ThrowIfNull(this, ref _documentContentDao);
		}

		#region IDocumentContentManager Members

		public byte[] GetDocumentContent(string transactionId, string id)
        {
            LOG.Debug(string.Format("GetDocumentContent({0}, {1})", transactionId, id));

            return _documentContentDao.GetDocumentContent(transactionId, id);
        }

        public int GetDocumentContentSize(string transactionId, string id)
        {
            return _documentContentDao.GetDocumentContentSize(transactionId, id);
        }

        public void SaveDocumentContent(string transactionId, string id, byte[] content,
										bool overwriteExisting)
        {
            LOG.Debug(string.Format("SaveDocumentContent({0}, {1}, byte[])", transactionId, id));

            _documentContentDao.AddDocumentContent(transactionId, id, content, overwriteExisting);
        }
       
        public void DeleteAllDocuments(string transactionId)
        {
            // NOP for now: By default, this is a cascade delete when the parent document is deleted
        }
        public void DeleteDocument(string transactionId, string id)
        {
            // NOP for now: By default, this is a cascade delete when the parent document is deleted
        }
        #endregion


        #region Private Methods

        #endregion

        public IDocumentContentDao DocumentContentDao
        {
            get { return _documentContentDao; }
            set { _documentContentDao = value; }
        }

        public IdProvider IdProvider
        {
            get { return _idProvider; }
            set { _idProvider = value; }
        }

    }
}
