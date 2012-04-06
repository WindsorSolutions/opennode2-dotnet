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

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.Diagnostics;
using System.Data.Common;
using System.Reflection;
using System.Data.SqlClient;

namespace Windsor.Commons.Core
{
    public static class DatabaseMdfUtils
    {
        private const string DataDirectoryString = "DataDirectory";
        private const string PipedDataDirectoryString = "|" + DataDirectoryString + "|";
        private const string MdfString = ".MDF";

        public static string GetMdfFilePath(string databaseConnectionString)
        {
            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder(databaseConnectionString);
            if (string.IsNullOrEmpty(connectionStringBuilder.AttachDBFilename))
            {
                return null;
            }
            string attachFileName = connectionStringBuilder.AttachDBFilename.Trim();
            string mdfFilePath;
            if (attachFileName.Replace(" ", "").IndexOf(PipedDataDirectoryString, StringComparison.OrdinalIgnoreCase) == 0)
            {
                string databaseSubPath = attachFileName.Substring(attachFileName.IndexOf('|') + 1);
                databaseSubPath = databaseSubPath.Substring(databaseSubPath.IndexOf('|') + 1).Trim();
                if ( string.IsNullOrEmpty(databaseSubPath) || !databaseSubPath.ToUpper().EndsWith(MdfString) )
                {
                    throw new ArgumentException(string.Format("Invalid AttachDBFilename specified: {0}", connectionStringBuilder.AttachDBFilename));
                }
                object dataDirectory = AppDomain.CurrentDomain.GetData(DataDirectoryString);
                if ((dataDirectory == null) || string.IsNullOrEmpty(dataDirectory.ToString()))
                {
                    if (databaseSubPath[0] != '\\')
                    {
                        databaseSubPath = "\\" + databaseSubPath;
                    }
                    mdfFilePath = Path.GetFullPath("." + databaseSubPath);
                }
                else
                {
                    if (databaseSubPath[0] == '\\')
                    {
                        databaseSubPath = databaseSubPath.Substring(1);
                    }
                    mdfFilePath = Path.Combine(dataDirectory.ToString(), databaseSubPath);
                }
            }
            else
            {
                mdfFilePath = Path.GetFullPath(connectionStringBuilder.AttachDBFilename);
            }
            return mdfFilePath;
        }
        public static string ChangeAttachMdfFileName(string databaseConnectionString, string newMdfFileName)
        {
            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder(databaseConnectionString);
            if (string.IsNullOrEmpty(connectionStringBuilder.AttachDBFilename))
            {
                return null;
            }
            if (string.IsNullOrEmpty(newMdfFileName) || !newMdfFileName.ToUpper().EndsWith(MdfString))
            {
                throw new ArgumentException(string.Format("Invalid AttachDBFilename specified: {0}", newMdfFileName));
            }
            string attachFileName = connectionStringBuilder.AttachDBFilename.Trim();
            if (attachFileName.Replace(" ", "").IndexOf(PipedDataDirectoryString, StringComparison.OrdinalIgnoreCase) == 0)
            {
                string databaseSubPath = attachFileName.Substring(attachFileName.IndexOf('|') + 1);
                databaseSubPath = databaseSubPath.Substring(databaseSubPath.IndexOf('|') + 1).Trim();
                if (string.IsNullOrEmpty(databaseSubPath) || !databaseSubPath.ToUpper().EndsWith(MdfString))
                {
                    throw new ArgumentException(string.Format("Invalid AttachDBFilename specified: {0}", connectionStringBuilder.AttachDBFilename));
                }
                string parentFolder = Path.GetDirectoryName(databaseSubPath);
                if (string.IsNullOrEmpty(parentFolder))
                {
                    databaseSubPath = newMdfFileName;
                }
                else
                {
                    databaseSubPath = Path.Combine(parentFolder, newMdfFileName);
                }
                connectionStringBuilder.AttachDBFilename = PipedDataDirectoryString + databaseSubPath;
            }
            else
            {
                string databaseSubPath = attachFileName;
                string parentFolder = Path.GetDirectoryName(databaseSubPath);
                if (string.IsNullOrEmpty(parentFolder))
                {
                    databaseSubPath = newMdfFileName;
                }
                else
                {
                    databaseSubPath = Path.Combine(parentFolder, newMdfFileName);
                }
                connectionStringBuilder.AttachDBFilename = PipedDataDirectoryString + "\\" + databaseSubPath;
            }
            return connectionStringBuilder.ConnectionString;
        }
    }
}
