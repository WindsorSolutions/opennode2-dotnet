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
using Windsor.Node2008.WNOSUtility;
using Windsor.Node2008.WNOSProviders;
using Windsor.Node2008.WNOSDomain;
using Windsor.Commons.Core;

namespace Windsor.Node2008.WNOS.Utilities
{
    public class SettingsProvider : ISettingsProvider
    {
        private string _tempFolderPath;
        private string _logsFolderPath;
        private string _endpoint11Url;
        private string _endpoint20Url;
        private string _adminUrl;
        private string _nodeAdminEmail;
        private string _nodeId;
        private string _nodeOrganizationName;
        private bool _isDemoNode;
        private bool _isProductionNode;
        private LatLongRectangle _nodeBoundingBox;

        public void Init()
        {
            if (string.IsNullOrEmpty(_tempFolderPath))
            {
                _tempFolderPath = Path.GetTempPath();
            }
            if (!Directory.Exists(_tempFolderPath))
            {
                throw new DirectoryNotFoundException(string.Format("The node temporary folder does not exist: {0}",
                                                                   _tempFolderPath));
            }
            if (!Directory.Exists(_logsFolderPath))
            {
                throw new DirectoryNotFoundException(string.Format("The node logs folder does not exist: {0}",
                                                                   _logsFolderPath));
            }
            FieldNotInitializedException.ThrowIfEmptyString(this, ref _nodeOrganizationName);
            FieldNotInitializedException.ThrowIfEmptyString(this, ref _nodeAdminEmail);
            FieldNotInitializedException.ThrowIfEmptyString(this, ref _nodeId);
            FieldNotInitializedException.ThrowIfEmptyString(this, ref _endpoint11Url);
            FieldNotInitializedException.ThrowIfEmptyString(this, ref _endpoint20Url);
            FieldNotInitializedException.ThrowIfEmptyString(this, ref _adminUrl);
            FieldNotInitializedException.ThrowIfNull(this, ref _nodeBoundingBox);
        }

        public LatLongRectangle NodeBoundingBox
        {
            get { return _nodeBoundingBox; }
            set { _nodeBoundingBox = value; }
        }

        public string NodeAdminEmail
        {
            get { return _nodeAdminEmail; }
            set { _nodeAdminEmail = value; }
        }

        public string AdminUrl
        {
            get { return _adminUrl; }
            set { _adminUrl = value; }
        }

        public string Endpoint11Url
        {
            get { return _endpoint11Url; }
            set { _endpoint11Url = value; }
        }

        public string Endpoint20Url
        {
            get { return _endpoint20Url; }
            set { _endpoint20Url = value; }
        }

        public string NodeId
        {
            get { return _nodeId; }
            set { _nodeId = value; }
        }

        public string NodeOrganizationName
        {
            get { return _nodeOrganizationName; }
            set { _nodeOrganizationName = value; }
        }

        public bool IsDemoNode
        {
            get { return _isDemoNode; }
            set { _isDemoNode = value; }
        }

        public bool IsProductionNode
        {
            get { return _isProductionNode; }
            set { _isProductionNode = value; }
        }

        public string TempFolderPath
        { 
            get {
                return _tempFolderPath;
            }
            set
            {
                _tempFolderPath = value;
            }
        }
        public string LogsFolderPath
        {
            get
            {
                return _logsFolderPath;
            }
            set
            {
                _logsFolderPath = value;
            }
        }
        public string NewTempFilePath(string fileExtension)
        {
            return Path.ChangeExtension(Path.Combine(TempFolderPath, Guid.NewGuid().ToString()), fileExtension);
        }
        public string NewTempFilePath()
        {
            return NewTempFilePath(".tmp");
        }
        public string NewTempFolderPath()
        {
            return Path.Combine(TempFolderPath, Guid.NewGuid().ToString());
        }
        public string CreateNewTempFolderPath()
        {
            string newTempFolderPath = NewTempFolderPath();
            Directory.CreateDirectory(newTempFolderPath);
            return newTempFolderPath;
        }
    }
}
