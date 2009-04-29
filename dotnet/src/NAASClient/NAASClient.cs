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
using System.ComponentModel;
using System.Diagnostics;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;
using System.Threading;

namespace Windsor.Node2008.NAASClient
{

    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name = "NetworkSecurityBinding3", Namespace = "http://www.exchangenetwork.net/wsdl/auth/3")]
    public partial class NAASClient : System.Web.Services.Protocols.SoapHttpClientProtocol
    {

        private System.Threading.SendOrPostCallback AuthenticateOperationCompleted;
        private System.Threading.SendOrPostCallback CentralAuthOperationCompleted;
        private System.Threading.SendOrPostCallback ValidateOperationCompleted;

        public NAASClient(string naasEndpointUrl)
        {
            SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap12;
            Url = naasEndpointUrl;
            Timeout = 300000;
            AllowAutoRedirect = true;
            Proxy = null;
        }


        public event AuthenticateCompletedEventHandler AuthenticateCompleted;
        public event CentralAuthCompletedEventHandler CentralAuthCompleted;
        public event ValidateCompletedEventHandler ValidateCompleted;

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("AuthenticateResponse", Namespace = "http://www.exchangenetwork.net/schema/auth/3")]
        public AuthenticateResponse Authenticate([System.Xml.Serialization.XmlElementAttribute("Authenticate", Namespace = "http://www.exchangenetwork.net/schema/auth/3")] Authenticate Authenticate1)
        {
            object[] results = this.Invoke("Authenticate", new object[] {
                    Authenticate1});
            return ((AuthenticateResponse)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginAuthenticate(Authenticate Authenticate1, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("Authenticate", new object[] {
                    Authenticate1}, callback, asyncState);
        }

        /// <remarks/>
        public AuthenticateResponse EndAuthenticate(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((AuthenticateResponse)(results[0]));
        }

        /// <remarks/>
        public void AuthenticateAsync(Authenticate Authenticate1)
        {
            this.AuthenticateAsync(Authenticate1, null);
        }

        /// <remarks/>
        public void AuthenticateAsync(Authenticate Authenticate1, object userState)
        {
            if ((this.AuthenticateOperationCompleted == null))
            {
                this.AuthenticateOperationCompleted = new System.Threading.SendOrPostCallback(this.OnAuthenticateOperationCompleted);
            }
            this.InvokeAsync("Authenticate", new object[] {
                    Authenticate1}, this.AuthenticateOperationCompleted, userState);
        }

        private void OnAuthenticateOperationCompleted(object arg)
        {
            if ((this.AuthenticateCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.AuthenticateCompleted(this, new AuthenticateCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("CentralAuthResponse", Namespace = "http://www.exchangenetwork.net/schema/auth/3")]
        public CentralAuthResponse CentralAuth([System.Xml.Serialization.XmlElementAttribute("CentralAuth", Namespace = "http://www.exchangenetwork.net/schema/auth/3")] CentralAuth CentralAuth1)
        {
            object[] results = this.Invoke("CentralAuth", new object[] {
                    CentralAuth1});
            return ((CentralAuthResponse)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginCentralAuth(CentralAuth CentralAuth1, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("CentralAuth", new object[] {
                    CentralAuth1}, callback, asyncState);
        }

        /// <remarks/>
        public CentralAuthResponse EndCentralAuth(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((CentralAuthResponse)(results[0]));
        }

        /// <remarks/>
        public void CentralAuthAsync(CentralAuth CentralAuth1)
        {
            this.CentralAuthAsync(CentralAuth1, null);
        }

        /// <remarks/>
        public void CentralAuthAsync(CentralAuth CentralAuth1, object userState)
        {
            if ((this.CentralAuthOperationCompleted == null))
            {
                this.CentralAuthOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCentralAuthOperationCompleted);
            }
            this.InvokeAsync("CentralAuth", new object[] {
                    CentralAuth1}, this.CentralAuthOperationCompleted, userState);
        }

        private void OnCentralAuthOperationCompleted(object arg)
        {
            if ((this.CentralAuthCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CentralAuthCompleted(this, new CentralAuthCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("ValidateResponse", Namespace = "http://www.exchangenetwork.net/schema/auth/3")]
        public ValidateResponse Validate([System.Xml.Serialization.XmlElementAttribute("Validate", Namespace = "http://www.exchangenetwork.net/schema/auth/3")] Validate Validate1)
        {
            object[] results = this.Invoke("Validate", new object[] {
                    Validate1});
            return ((ValidateResponse)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginValidate(Validate Validate1, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("Validate", new object[] {
                    Validate1}, callback, asyncState);
        }

        /// <remarks/>
        public ValidateResponse EndValidate(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((ValidateResponse)(results[0]));
        }

        /// <remarks/>
        public void ValidateAsync(Validate Validate1)
        {
            this.ValidateAsync(Validate1, null);
        }

        /// <remarks/>
        public void ValidateAsync(Validate Validate1, object userState)
        {
            if ((this.ValidateOperationCompleted == null))
            {
                this.ValidateOperationCompleted = new System.Threading.SendOrPostCallback(this.OnValidateOperationCompleted);
            }
            this.InvokeAsync("Validate", new object[] {
                    Validate1}, this.ValidateOperationCompleted, userState);
        }

        private void OnValidateOperationCompleted(object arg)
        {
            if ((this.ValidateCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ValidateCompleted(this, new ValidateCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        public new void CancelAsync(object userState)
        {
            base.CancelAsync(userState);
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.exchangenetwork.net/schema/auth/3")]
    public partial class Authenticate
    {

        private string userIdField;

        private string credentialField;

        private DomainTypeCode domainField;

        private string authenticationMethodField;

        /// <remarks/>
        public string userId
        {
            get
            {
                return this.userIdField;
            }
            set
            {
                this.userIdField = value;
            }
        }

        /// <remarks/>
        public string credential
        {
            get
            {
                return this.credentialField;
            }
            set
            {
                this.credentialField = value;
            }
        }

        /// <remarks/>
        public DomainTypeCode domain
        {
            get
            {
                return this.domainField;
            }
            set
            {
                this.domainField = value;
            }
        }

        /// <remarks/>
        public string authenticationMethod
        {
            get
            {
                return this.authenticationMethodField;
            }
            set
            {
                this.authenticationMethodField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/auth/3")]
    public enum DomainTypeCode
    {

        /// <remarks/>
        @default,

        /// <remarks/>
        IAMLdap,

        /// <remarks/>
        DEVLdap,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.exchangenetwork.net/schema/auth/3")]
    public partial class AuthenticateResponse
    {

        private string returnField;

        /// <remarks/>
        public string @return
        {
            get
            {
                return this.returnField;
            }
            set
            {
                this.returnField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.exchangenetwork.net/schema/auth/3")]
    public partial class CentralAuth
    {

        private string userIdField;

        private string credentialField;

        private DomainTypeCode domainField;

        private string authenticationMethodField;

        private string clientIpField;

        private string resourceURIField;

        /// <remarks/>
        public string userId
        {
            get
            {
                return this.userIdField;
            }
            set
            {
                this.userIdField = value;
            }
        }

        /// <remarks/>
        public string credential
        {
            get
            {
                return this.credentialField;
            }
            set
            {
                this.credentialField = value;
            }
        }

        /// <remarks/>
        public DomainTypeCode domain
        {
            get
            {
                return this.domainField;
            }
            set
            {
                this.domainField = value;
            }
        }

        /// <remarks/>
        public string authenticationMethod
        {
            get
            {
                return this.authenticationMethodField;
            }
            set
            {
                this.authenticationMethodField = value;
            }
        }

        /// <remarks/>
        public string clientIp
        {
            get
            {
                return this.clientIpField;
            }
            set
            {
                this.clientIpField = value;
            }
        }

        /// <remarks/>
        public string resourceURI
        {
            get
            {
                return this.resourceURIField;
            }
            set
            {
                this.resourceURIField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.exchangenetwork.net/schema/auth/3")]
    public partial class CentralAuthResponse
    {

        private string returnField;

        /// <remarks/>
        public string @return
        {
            get
            {
                return this.returnField;
            }
            set
            {
                this.returnField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.exchangenetwork.net/schema/auth/3")]
    public partial class Validate
    {

        private string userIdField;

        private string credentialField;

        private DomainTypeCode domainField;

        private string securityTokenField;

        private string clientIpField;

        private string resourceURIField;

        /// <remarks/>
        public string userId
        {
            get
            {
                return this.userIdField;
            }
            set
            {
                this.userIdField = value;
            }
        }

        /// <remarks/>
        public string credential
        {
            get
            {
                return this.credentialField;
            }
            set
            {
                this.credentialField = value;
            }
        }

        /// <remarks/>
        public DomainTypeCode domain
        {
            get
            {
                return this.domainField;
            }
            set
            {
                this.domainField = value;
            }
        }

        /// <remarks/>
        public string securityToken
        {
            get
            {
                return this.securityTokenField;
            }
            set
            {
                this.securityTokenField = value;
            }
        }

        /// <remarks/>
        public string clientIp
        {
            get
            {
                return this.clientIpField;
            }
            set
            {
                this.clientIpField = value;
            }
        }

        /// <remarks/>
        public string resourceURI
        {
            get
            {
                return this.resourceURIField;
            }
            set
            {
                this.resourceURIField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.exchangenetwork.net/schema/auth/3")]
    public partial class ValidateResponse
    {

        private string returnField;

        /// <remarks/>
        public string @return
        {
            get
            {
                return this.returnField;
            }
            set
            {
                this.returnField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    public delegate void AuthenticateCompletedEventHandler(object sender, AuthenticateCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class AuthenticateCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal AuthenticateCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState)
            :
                base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public AuthenticateResponse Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((AuthenticateResponse)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    public delegate void CentralAuthCompletedEventHandler(object sender, CentralAuthCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CentralAuthCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal CentralAuthCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState)
            :
                base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public CentralAuthResponse Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((CentralAuthResponse)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    public delegate void ValidateCompletedEventHandler(object sender, ValidateCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.42")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ValidateCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal ValidateCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState)
            :
                base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public ValidateResponse Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((ValidateResponse)(this.results[0]));
            }
        }
    }

}