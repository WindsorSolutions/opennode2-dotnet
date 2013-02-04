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
using Windsor.Node2008.WNOSDomain;
using System.Text;

namespace Windsor.Node2008.WNOSProviders
{
    /// <summary>
    /// Settings provider interface.  The settings provider gives access to WNOS application settings.
    /// </summary>
    public interface ISettingsProvider
    {
        /// <summary>
        /// Return the directory path to the temporary WNOS folder
        /// </summary>
        string TempFolderPath
        {
            get;
        }
        /// <summary>
        /// Return the directory path to the Logs WNOS folder
        /// </summary>
        string LogsFolderPath
        {
            get;
        }
        /// <summary>
        /// Return a file path to a temporary WNOS file
        /// </summary>
        string NewTempFilePath();
        /// <summary>
        /// Return a file path to a temporary WNOS file with the specified extension (with a leading period)
        /// </summary>
        string NewTempFilePath(string fileExtension);
        /// <summary>
        /// Return a file path to a temporary WNOS file
        /// </summary>
        string NewTempFolderPath();
        /// <summary>
        /// Return a file path to a temporary WNOS file
        /// </summary>
        string CreateNewTempFolderPath();
        /// <summary>
        /// Return the external url to the node admin url
        /// </summary>
        string AdminUrl
        {
            get;
        }
        /// <summary>
        /// Return the external url to the node endpoint v2.0 url
        /// </summary>
        string Endpoint20Url
        {
            get;
        }
        /// <summary>
        /// Return the external url to the node endpoint v1.1 url
        /// </summary>
        string Endpoint11Url
        {
            get;
        }
        /// <summary>
        /// Return true if the node is setup in Production node, false if Test node
        /// </summary>
        bool IsProductionNode
        {
            get;
        }
        /// <summary>
        /// Return the bounding box of the node's physical location
        /// </summary>
        LatLongRectangle NodeBoundingBox
        {
            get;
        }
        /// <summary>
        /// Email address for node admin
        /// </summary>
        string NodeAdminEmail
        {
            get;
        }
        /// <summary>
        /// The NAAS id for the node
        /// </summary>
        string NodeId
        {
            get;
        }
        /// <summary>
        /// The node organization name
        /// </summary>
        string NodeOrganizationName
        {
            get;
        }
    }
}
