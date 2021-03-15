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
using System.IO;
using System.Data;
using System.Data.Common;
using System.Data.ProviderBase;
using Windsor.Node2008.WNOSPlugin;
using System.Diagnostics;
using System.Reflection;
using Windsor.Node2008.WNOSUtility;
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSProviders;
using Spring.Data.Common;
using Spring.Transaction.Support;
using Spring.Data.Core;
using System.ComponentModel;
using Windsor.Commons.Core;
using Windsor.Commons.Spring;
using Windsor.Commons.XsdOrm;
using Windsor.Node2008.WNOSPlugin.WQX3XsdOrm;
using Microsoft.VisualBasic.FileIO;

namespace Windsor.Node2008.WNOSPlugin.WQX3
{
    [Serializable]
    public abstract class WQXBaseAuthorizationPlugin : BaseWNOSPlugin
    {
        #region fields
        protected const string AUTHORIZATION_FILE_PATH_KEY = "Authorization CSV File Path";

        protected Dictionary<string, List<string>> _authorizedWqxUsers;
        #endregion

        public WQXBaseAuthorizationPlugin()
        {
            ConfigurationArguments.Add(AUTHORIZATION_FILE_PATH_KEY, null);
        }
        protected virtual void LazyInit()
        {
            AppendAuditLogEvent("Initializing {0} plugin ...", this.GetType().Name);

            LoadWQXAuthorizationFile();
        }
        public static Dictionary<string, List<string>> LoadWQXAuthorizationFile(BaseWNOSPlugin plugin, string filePath)
        {
            Dictionary<string, List<string>> authorizedWqxUsers = null;
            if (!string.IsNullOrEmpty(filePath))
            {
                try
                {
                    using (TextFieldParser parser = new TextFieldParser(filePath))
                    {
                        parser.TextFieldType = FieldType.Delimited;
                        parser.Delimiters = new string[] { "," };
                        authorizedWqxUsers = new Dictionary<string, List<string>>();
                        for (; ; )
                        {
                            long lineNumber = parser.LineNumber;
                            string[] values = parser.ReadFields();
                            if (CollectionUtils.IsNullOrEmpty(values))
                            {
                                break;
                            }
                            string wqxOrgId = values[0].Trim().ToUpper();
                            if (string.IsNullOrEmpty(wqxOrgId))
                            {
                                throw new ArgumentException(string.Format("Missing WQX Org Id on line: {0}", lineNumber));
                            }
                            if (wqxOrgId.StartsWith("//"))
                            {
                                // Comment, so ignore line
                            }
                            else
                            {
                                List<string> usernames = null;
                                if (!authorizedWqxUsers.TryGetValue(wqxOrgId, out usernames))
                                {
                                    usernames = new List<string>();
                                    authorizedWqxUsers[wqxOrgId] = usernames;
                                }
                                for (int i = 1; i < values.Length; ++i)
                                {
                                    string username = values[i].Trim().ToUpper();
                                    if (!usernames.Contains(username))
                                    {
                                        usernames.Add(username);
                                    }
                                }
                            }
                        }
                        plugin.AppendAuditLogEvent("Found {0} organizations in authorization file", authorizedWqxUsers.Count);
                    }
                }
                catch (Exception e)
                {
                    plugin.AppendAuditLogEvent("Failed to load WQX authorization file: {0}", e.Message);
                    throw;
                }
            }
            else
            {
                plugin.AppendAuditLogEvent("A WQX authorization file was not specified.");
            }
            return authorizedWqxUsers;
        }
        private void LoadWQXAuthorizationFile()
        {
            string filePath = null;
            TryGetConfigParameter(AUTHORIZATION_FILE_PATH_KEY, ref filePath);
            _authorizedWqxUsers = LoadWQXAuthorizationFile(this, filePath);
        }
    }
}