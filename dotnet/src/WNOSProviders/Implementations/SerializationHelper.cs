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
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.Xml.Serialization;
using System.IO;
using System.Reflection;
using Windsor.Node2008.WNOSProviders;
using Windsor.Node2008.WNOSUtility;
using Windsor.Commons.Core;

namespace Windsor.Node2008.WNOSProviders.Implementation
{
    [Serializable]
    public class SerializationHelper : SerializationUtils, ISerializationHelper
    {

        private string _tempDir;



        public void Init()
        {
            FieldNotInitializedException.ThrowIfNull(this, ref _tempDir);
            FieldNotInitializedException.ThrowIfDirectoryDoesNotExist(_tempDir);
        }

        #region ISerializationHelper Members


        public string SerializeToTempFile(object obj)
        {
            Init();
            string tempPath = Path.Combine(_tempDir, string.Format("{0}.xml", Guid.NewGuid()));
            Serialize(obj, tempPath);
            return tempPath;
        }

        #endregion

        public string TempDir
        {
            set { _tempDir = value; }
        }
    }
}
