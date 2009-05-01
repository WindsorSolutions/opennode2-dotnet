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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Windows.Forms;
using System.Reflection;
using System.Configuration;
using System.IO;
using System.Xml;

using Windsor.Node2008.WNOS;
using Windsor.Node2008.WNOSUtility;
using Windsor.Commons.Core;
using Windsor.Commons.Spring;

namespace Windsor.Node2008.WNOSServiceApp
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }
        public override void Install(IDictionary stateSaver)
        {
            Init(true);
            base.Install(stateSaver);
        }
        public override void Uninstall(IDictionary savedState)
        {
            Init(false);
            base.Uninstall(savedState);
        }
        protected void Init(bool isInstall)
        {
            string serviceDescription, serviceDisplayName, serviceServiceName;
            GetDeploymentConfigItems(out serviceDescription, out serviceDisplayName, out serviceServiceName);

            this.serviceInstaller1.Description = serviceDescription;
            this.serviceInstaller1.DisplayName = serviceDisplayName;
            this.serviceInstaller1.ServiceName = serviceServiceName;
            if (MessageBox.Show(string.Format("Description: {0}{1}DisplayName: {2}{3}ServiceName: {4}",
                                               this.serviceInstaller1.Description, Environment.NewLine,
                                               this.serviceInstaller1.DisplayName, Environment.NewLine,
                                               this.serviceInstaller1.ServiceName),
                                               isInstall ? "Installing WNOS service" : "Uninstalling WNOS service",
                                               MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                throw new OperationCanceledException();
            }
        }
        public static void GetDeploymentConfigItems(out string serviceDescription, out string serviceDisplayName,
                                                    out string serviceServiceName)
        {
            string path = Path.GetDirectoryName(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            path += @"\Config\Deployment.config";
            IDictionary<string, string> configItems = SpringConfigParser.ParseFile(path);
            serviceDescription = configItems["wnos.service.description"];
            serviceDisplayName = configItems["wnos.service.display.name"];
            serviceServiceName = configItems["wnos.service.service.name"];
        }
    }
}
