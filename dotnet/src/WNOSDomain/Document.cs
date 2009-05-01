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

using Windsor.Node2008.WNOSUtility;
using Windsor.Commons.Core;

namespace Windsor.Node2008.WNOSDomain
{
    [Serializable]
    public class Document : SimpleContent
    {
        private string _id;             // Database Id
        private string _documentId;
        private string _documentName;
        private int _contentByteSize;

        public Document() {
        }
		public Document(string documentId, string documentName, CommonContentType type)
			: this(documentId, documentName, type, null) {
		
		}
		public Document(string documentId, string documentName, CommonContentType type,
						byte[] content) :
						base(type, content)
		{
			_documentId = documentId;
			_documentName = documentName;
            _contentByteSize = (content == null) ? 0 : content.Length;
		}
		public Document(string documentName, CommonContentType type, byte[] content)
			: base(type, content)
		{

			_documentName = documentName;
            _contentByteSize = (content == null) ? 0 : content.Length;
        }

        public bool IsZipFile
        {
            get
            {
                return ((Type == CommonContentType.ZIP) ||
                        (CommonContentAndFormatProvider.GetFileTypeFromName(DocumentName) == CommonContentType.ZIP));
            }
        }
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string DocumentName
        {
            get { return _documentName; }
            set { _documentName = value; }
        }

        public string DocumentId
        {
            get { return _documentId; }
            set { _documentId = value; }
        }
        [ToStringQualifier(CollectionCountOnly = true)]
        public new byte[] Content
        {
            get { return base.Content; }
            set
            {
                base.Content = value;
                _contentByteSize = (value == null) ? 0 : value.Length;
            }
        }
        // This value matches Content.Length, whether or not Content is actually set
        public int ContentByteSize
        {
            get { return _contentByteSize; }
            set { _contentByteSize = value; }
        }
    }
}
