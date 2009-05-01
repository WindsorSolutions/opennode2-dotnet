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

﻿using System.Diagnostics;
using System.Web.Services;
using System.ComponentModel;
using System.Web.Services.Protocols;
using System;
using System.Xml.Serialization;


namespace Windsor.Node2008.NAASUserMgr2
{

  
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="UserMgrBinding", Namespace="http://neien.org/schema/usermgr.wsdl")]
    [System.Xml.Serialization.SoapIncludeAttribute(typeof(UserInfo))]
    [System.Xml.Serialization.SoapIncludeAttribute(typeof(UserProperty))]
    public partial class UserMgr2 : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback AddUserOperationCompleted;
        
        private System.Threading.SendOrPostCallback DeleteUserOperationCompleted;
        
        private System.Threading.SendOrPostCallback UpdateUserOperationCompleted;
        
        private System.Threading.SendOrPostCallback SetUserPropertyOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetUserPropertyOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetUserListOperationCompleted;
        
        private System.Threading.SendOrPostCallback ChangePwdOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;

        public UserMgr2()
        {
            this.EnableDecompression = false;
            this.SoapVersion = System.Web.Services.Protocols.SoapProtocolVersion.Soap11;
        }
        /// <remarks/>
        public UserMgr2(string url) : this() {
            this.Url = url;
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event AddUserCompletedEventHandler AddUserCompleted;
        
        /// <remarks/>
        public event DeleteUserCompletedEventHandler DeleteUserCompleted;
        
        /// <remarks/>
        public event UpdateUserCompletedEventHandler UpdateUserCompleted;
        
        /// <remarks/>
        public event SetUserPropertyCompletedEventHandler SetUserPropertyCompleted;
        
        /// <remarks/>
        public event GetUserPropertyCompletedEventHandler GetUserPropertyCompleted;
        
        /// <remarks/>
        public event GetUserListCompletedEventHandler GetUserListCompleted;
        
        /// <remarks/>
        public event ChangePwdCompletedEventHandler ChangePwdCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("", RequestNamespace="http://neien.org/schema/usermgr.xsd", ResponseNamespace="http://neien.org/schema/usermgr.xsd")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public string AddUser(string adminName, string adminPwd, string userEmail, UserType userType, string userPwd, string confirmUserPwd, string affiliate) {
            object[] results = this.Invoke("AddUser", new object[] {
                        adminName,
                        adminPwd,
                        userEmail,
                        userType,
                        userPwd,
                        confirmUserPwd,
                        affiliate});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void AddUserAsync(string adminName, string adminPwd, string userEmail, UserType userType, string userPwd, string confirmUserPwd, StateId affiliate) {
            this.AddUserAsync(adminName, adminPwd, userEmail, userType, userPwd, confirmUserPwd, affiliate, null);
        }
        
        /// <remarks/>
        public void AddUserAsync(string adminName, string adminPwd, string userEmail, UserType userType, string userPwd, string confirmUserPwd, StateId affiliate, object userState) {
            if ((this.AddUserOperationCompleted == null)) {
                this.AddUserOperationCompleted = new System.Threading.SendOrPostCallback(this.OnAddUserOperationCompleted);
            }
            this.InvokeAsync("AddUser", new object[] {
                        adminName,
                        adminPwd,
                        userEmail,
                        userType,
                        userPwd,
                        confirmUserPwd,
                        affiliate}, this.AddUserOperationCompleted, userState);
        }
        
        private void OnAddUserOperationCompleted(object arg) {
            if ((this.AddUserCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.AddUserCompleted(this, new AddUserCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("", RequestNamespace="http://neien.org/schema/usermgr.xsd", ResponseNamespace="http://neien.org/schema/usermgr.xsd")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public string DeleteUser(string adminName, string adminPwd, string userEmail) {
            object[] results = this.Invoke("DeleteUser", new object[] {
                        adminName,
                        adminPwd,
                        userEmail});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void DeleteUserAsync(string adminName, string adminPwd, string userEmail) {
            this.DeleteUserAsync(adminName, adminPwd, userEmail, null);
        }
        
        /// <remarks/>
        public void DeleteUserAsync(string adminName, string adminPwd, string userEmail, object userState) {
            if ((this.DeleteUserOperationCompleted == null)) {
                this.DeleteUserOperationCompleted = new System.Threading.SendOrPostCallback(this.OnDeleteUserOperationCompleted);
            }
            this.InvokeAsync("DeleteUser", new object[] {
                        adminName,
                        adminPwd,
                        userEmail}, this.DeleteUserOperationCompleted, userState);
        }
        
        private void OnDeleteUserOperationCompleted(object arg) {
            if ((this.DeleteUserCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.DeleteUserCompleted(this, new DeleteUserCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("", RequestNamespace="http://neien.org/schema/usermgr.xsd", ResponseNamespace="http://neien.org/schema/usermgr.xsd")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public string UpdateUser(string adminName, string adminPwd, string userEmail, UserType userType, string userPwd, string owner, StateId affiliate) {
            object[] results = this.Invoke("UpdateUser", new object[] {
                        adminName,
                        adminPwd,
                        userEmail,
                        userType,
                        userPwd,
                        owner,
                        affiliate});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void UpdateUserAsync(string adminName, string adminPwd, string userEmail, UserType userType, string userPwd, string owner, StateId affiliate) {
            this.UpdateUserAsync(adminName, adminPwd, userEmail, userType, userPwd, owner, affiliate, null);
        }
        
        /// <remarks/>
        public void UpdateUserAsync(string adminName, string adminPwd, string userEmail, UserType userType, string userPwd, string owner, StateId affiliate, object userState) {
            if ((this.UpdateUserOperationCompleted == null)) {
                this.UpdateUserOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUpdateUserOperationCompleted);
            }
            this.InvokeAsync("UpdateUser", new object[] {
                        adminName,
                        adminPwd,
                        userEmail,
                        userType,
                        userPwd,
                        owner,
                        affiliate}, this.UpdateUserOperationCompleted, userState);
        }
        
        private void OnUpdateUserOperationCompleted(object arg) {
            if ((this.UpdateUserCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UpdateUserCompleted(this, new UpdateUserCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("", RequestNamespace="http://neien.org/schema/usermgr.xsd", ResponseNamespace="http://neien.org/schema/usermgr.xsd")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public string SetUserProperty(
                    string adminName, 
                    string adminPwd, 
                    string UserId, 
                    string CommonName, 
                    string Organization, 
                    string OrganizationUnit, 
                    string Address, 
                    string City, 
                    StateId State, 
                    string ZipCode, 
                    string Phone, 
                    string Supervisor, 
                    string SupervisorPhone, 
                    string UserData, 
                    string SecurityLevel, 
                    string CertificateStatus, 
                    string LastChange) {
            object[] results = this.Invoke("SetUserProperty", new object[] {
                        adminName,
                        adminPwd,
                        UserId,
                        CommonName,
                        Organization,
                        OrganizationUnit,
                        Address,
                        City,
                        State,
                        ZipCode,
                        Phone,
                        Supervisor,
                        SupervisorPhone,
                        UserData,
                        SecurityLevel,
                        CertificateStatus,
                        LastChange});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void SetUserPropertyAsync(
                    string adminName, 
                    string adminPwd, 
                    string UserId, 
                    string CommonName, 
                    string Organization, 
                    string OrganizationUnit, 
                    string Address, 
                    string City, 
                    StateId State, 
                    string ZipCode, 
                    string Phone, 
                    string Supervisor, 
                    string SupervisorPhone, 
                    string UserData, 
                    string SecurityLevel, 
                    string CertificateStatus, 
                    string LastChange) {
            this.SetUserPropertyAsync(adminName, adminPwd, UserId, CommonName, Organization, OrganizationUnit, Address, City, State, ZipCode, Phone, Supervisor, SupervisorPhone, UserData, SecurityLevel, CertificateStatus, LastChange, null);
        }
        
        /// <remarks/>
        public void SetUserPropertyAsync(
                    string adminName, 
                    string adminPwd, 
                    string UserId, 
                    string CommonName, 
                    string Organization, 
                    string OrganizationUnit, 
                    string Address, 
                    string City, 
                    StateId State, 
                    string ZipCode, 
                    string Phone, 
                    string Supervisor, 
                    string SupervisorPhone, 
                    string UserData, 
                    string SecurityLevel, 
                    string CertificateStatus, 
                    string LastChange, 
                    object userState) {
            if ((this.SetUserPropertyOperationCompleted == null)) {
                this.SetUserPropertyOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSetUserPropertyOperationCompleted);
            }
            this.InvokeAsync("SetUserProperty", new object[] {
                        adminName,
                        adminPwd,
                        UserId,
                        CommonName,
                        Organization,
                        OrganizationUnit,
                        Address,
                        City,
                        State,
                        ZipCode,
                        Phone,
                        Supervisor,
                        SupervisorPhone,
                        UserData,
                        SecurityLevel,
                        CertificateStatus,
                        LastChange}, this.SetUserPropertyOperationCompleted, userState);
        }
        
        private void OnSetUserPropertyOperationCompleted(object arg) {
            if ((this.SetUserPropertyCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SetUserPropertyCompleted(this, new SetUserPropertyCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("", RequestNamespace="http://neien.org/schema/usermgr.xsd", ResponseNamespace="http://neien.org/schema/usermgr.xsd")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public UserProperty[] GetUserProperty(string adminName, string adminPwd, string userEmail) {
            object[] results = this.Invoke("GetUserProperty", new object[] {
                        adminName,
                        adminPwd,
                        userEmail});
            return ((UserProperty[])(results[0]));
        }
        
        /// <remarks/>
        public void GetUserPropertyAsync(string adminName, string adminPwd, string userEmail) {
            this.GetUserPropertyAsync(adminName, adminPwd, userEmail, null);
        }
        
        /// <remarks/>
        public void GetUserPropertyAsync(string adminName, string adminPwd, string userEmail, object userState) {
            if ((this.GetUserPropertyOperationCompleted == null)) {
                this.GetUserPropertyOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetUserPropertyOperationCompleted);
            }
            this.InvokeAsync("GetUserProperty", new object[] {
                        adminName,
                        adminPwd,
                        userEmail}, this.GetUserPropertyOperationCompleted, userState);
        }
        
        private void OnGetUserPropertyOperationCompleted(object arg) {
            if ((this.GetUserPropertyCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetUserPropertyCompleted(this, new GetUserPropertyCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("", RequestNamespace="http://neien.org/schema/usermgr.xsd", ResponseNamespace="http://neien.org/schema/usermgr.xsd")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public UserInfo[] GetUserList(string adminName, string adminPwd, string userEmail, string userState, [System.Xml.Serialization.SoapElementAttribute(DataType="integer")] string rowId, [System.Xml.Serialization.SoapElementAttribute(DataType="integer")] string maxRows) {
            object[] results = this.Invoke("GetUserList", new object[] {
                        adminName,
                        adminPwd,
                        userEmail,
                        userState,
                        rowId,
                        maxRows});
            return ((UserInfo[])(results[0]));
        }
        
        /// <remarks/>
        public void GetUserListAsync(string adminName, string adminPwd, string userEmail, StateId userState, string rowId, string maxRows) {
            this.GetUserListAsync(adminName, adminPwd, userEmail, userState, rowId, maxRows, null);
        }
        
        /// <remarks/>
        public void GetUserListAsync(string adminName, string adminPwd, string userEmail, StateId userState, string rowId, string maxRows, object userState1) {
            if ((this.GetUserListOperationCompleted == null)) {
                this.GetUserListOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetUserListOperationCompleted);
            }
            this.InvokeAsync("GetUserList", new object[] {
                        adminName,
                        adminPwd,
                        userEmail,
                        userState,
                        rowId,
                        maxRows}, this.GetUserListOperationCompleted, userState1);
        }
        
        private void OnGetUserListOperationCompleted(object arg) {
            if ((this.GetUserListCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetUserListCompleted(this, new GetUserListCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("", RequestNamespace="http://neien.org/schema/usermgr.xsd", ResponseNamespace="http://neien.org/schema/usermgr.xsd")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public string ChangePwd(string userEmail, string password, string newPwd) {
            object[] results = this.Invoke("ChangePwd", new object[] {
                        userEmail,
                        password,
                        newPwd});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ChangePwdAsync(string userEmail, string password, string newPwd) {
            this.ChangePwdAsync(userEmail, password, newPwd, null);
        }
        
        /// <remarks/>
        public void ChangePwdAsync(string userEmail, string password, string newPwd, object userState) {
            if ((this.ChangePwdOperationCompleted == null)) {
                this.ChangePwdOperationCompleted = new System.Threading.SendOrPostCallback(this.OnChangePwdOperationCompleted);
            }
            this.InvokeAsync("ChangePwd", new object[] {
                        userEmail,
                        password,
                        newPwd}, this.ChangePwdOperationCompleted, userState);
        }
        
        private void OnChangePwdOperationCompleted(object arg) {
            if ((this.ChangePwdCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ChangePwdCompleted(this, new ChangePwdCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.SoapTypeAttribute(Namespace="http://neien.org/schema/usermgr.xsd")]
    public enum UserType {
        
        /// <remarks/>
        user,
        
        /// <remarks/>
        @operator,
        
        /// <remarks/>
        admin,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.SoapTypeAttribute(Namespace="http://neien.org/schema/usermgr.xsd")]
    public enum StateId {
        
        /// <remarks/>
        [System.Xml.Serialization.SoapEnumAttribute("")]
        Item,
        
        /// <remarks/>
        AL,
        
        /// <remarks/>
        AK,
        
        /// <remarks/>
        AK_TC,
        
        /// <remarks/>
        AZ,
        
        /// <remarks/>
        AZ_NN,
        
        /// <remarks/>
        AZ_SRPMIC,
        
        /// <remarks/>
        AR,
        
        /// <remarks/>
        BPEL,
        
        /// <remarks/>
        CA,
        
        /// <remarks/>
        CA_DHS,
        
        /// <remarks/>
        CA_WB,
        
        /// <remarks/>
        CA_Water,
        
        /// <remarks/>
        CDX,
        
        /// <remarks/>
        CDX_RMP,
        
        /// <remarks/>
        REF,
        
        /// <remarks/>
        CO,
        
        /// <remarks/>
        CT,
        
        /// <remarks/>
        DE,
        
        /// <remarks/>
        DE_DT,
        
        /// <remarks/>
        DC,
        
        /// <remarks/>
        EPA_R9,
        
        /// <remarks/>
        FL,
        
        /// <remarks/>
        GA,
        
        /// <remarks/>
        GLNPO,
        
        /// <remarks/>
        HI,
        
        /// <remarks/>
        ID,
        
        /// <remarks/>
        IL,
        
        /// <remarks/>
        IN,
        
        /// <remarks/>
        IA,
        
        /// <remarks/>
        KS,
        
        /// <remarks/>
        KS_DA,
        
        /// <remarks/>
        KY,
        
        /// <remarks/>
        KY_DOGI,
        
        /// <remarks/>
        LA,
        
        /// <remarks/>
        LA_DEQ,
        
        /// <remarks/>
        ME,
        
        /// <remarks/>
        MD,
        
        /// <remarks/>
        MA,
        
        /// <remarks/>
        MI,
        
        /// <remarks/>
        MN,
        
        /// <remarks/>
        MN_NRRI,
        
        /// <remarks/>
        MS,
        
        /// <remarks/>
        MO,
        
        /// <remarks/>
        MT,
        
        /// <remarks/>
        NatureServe,
        
        /// <remarks/>
        NE,
        
        /// <remarks/>
        NE_OMAHA,
        
        /// <remarks/>
        NE_HHSS,
        
        /// <remarks/>
        NEI,
        
        /// <remarks/>
        NH,
        
        /// <remarks/>
        NV,
        
        /// <remarks/>
        NJ,
        
        /// <remarks/>
        NM,
        
        /// <remarks/>
        NY,
        
        /// <remarks/>
        NY_HEALTH,
        
        /// <remarks/>
        NY_MHK,
        
        /// <remarks/>
        NC,
        
        /// <remarks/>
        ND,
        
        /// <remarks/>
        OH,
        
        /// <remarks/>
        OK,
        
        /// <remarks/>
        OK_CN,
        
        /// <remarks/>
        OK_ODA,
        
        /// <remarks/>
        OR,
        
        /// <remarks/>
        OR_CTUIR,
        
        /// <remarks/>
        OregonRPC,
        
        /// <remarks/>
        PA,
        
        /// <remarks/>
        PR,
        
        /// <remarks/>
        RI,
        
        /// <remarks/>
        SC,
        
        /// <remarks/>
        SD,
        
        /// <remarks/>
        TN,
        
        /// <remarks/>
        TX,
        
        /// <remarks/>
        TrustService,
        
        /// <remarks/>
        UT,
        
        /// <remarks/>
        VT,
        
        /// <remarks/>
        VA,
        
        /// <remarks/>
        WA,
        
        /// <remarks/>
        WA_DNR,
        
        /// <remarks/>
        WA_SIN,
        
        /// <remarks/>
        WV,
        
        /// <remarks/>
        WV_HRS,
        
        /// <remarks/>
        WI,
        
        /// <remarks/>
        WY,
        
        /// <remarks/>
        CA_YT,
        
        /// <remarks/>
        WY_WRIR,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.SoapTypeAttribute(Namespace="http://neien.org/schema/usermgr.xsd")]
    public partial class UserProperty {
        
        private string userIdField;
        
        private string commonNameField;
        
        private string organizationField;
        
        private string organizationUnitField;
        
        private string addressField;
        
        private string cityField;
        
        private StateId stateField;
        
        private string zipCodeField;
        
        private string phoneField;
        
        private string supervisorField;
        
        private string supervisorPhoneField;
        
        private string userDataField;
        
        private string securityLevelField;
        
        private string certificateStatusField;
        
        private string lastChangeField;
        
        /// <remarks/>
        public string UserId {
            get {
                return this.userIdField;
            }
            set {
                this.userIdField = value;
            }
        }
        
        /// <remarks/>
        public string CommonName {
            get {
                return this.commonNameField;
            }
            set {
                this.commonNameField = value;
            }
        }
        
        /// <remarks/>
        public string Organization {
            get {
                return this.organizationField;
            }
            set {
                this.organizationField = value;
            }
        }
        
        /// <remarks/>
        public string OrganizationUnit {
            get {
                return this.organizationUnitField;
            }
            set {
                this.organizationUnitField = value;
            }
        }
        
        /// <remarks/>
        public string Address {
            get {
                return this.addressField;
            }
            set {
                this.addressField = value;
            }
        }
        
        /// <remarks/>
        public string City {
            get {
                return this.cityField;
            }
            set {
                this.cityField = value;
            }
        }
        
        /// <remarks/>
        public StateId State {
            get {
                return this.stateField;
            }
            set {
                this.stateField = value;
            }
        }
        
        /// <remarks/>
        public string ZipCode {
            get {
                return this.zipCodeField;
            }
            set {
                this.zipCodeField = value;
            }
        }
        
        /// <remarks/>
        public string Phone {
            get {
                return this.phoneField;
            }
            set {
                this.phoneField = value;
            }
        }
        
        /// <remarks/>
        public string Supervisor {
            get {
                return this.supervisorField;
            }
            set {
                this.supervisorField = value;
            }
        }
        
        /// <remarks/>
        public string SupervisorPhone {
            get {
                return this.supervisorPhoneField;
            }
            set {
                this.supervisorPhoneField = value;
            }
        }
        
        /// <remarks/>
        public string UserData {
            get {
                return this.userDataField;
            }
            set {
                this.userDataField = value;
            }
        }
        
        /// <remarks/>
        public string SecurityLevel {
            get {
                return this.securityLevelField;
            }
            set {
                this.securityLevelField = value;
            }
        }
        
        /// <remarks/>
        public string CertificateStatus {
            get {
                return this.certificateStatusField;
            }
            set {
                this.certificateStatusField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string LastChange {
            get {
                return this.lastChangeField;
            }
            set {
                this.lastChangeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.SoapTypeAttribute(Namespace="http://neien.org/schema/usermgr.xsd")]
    public partial class UserInfo {
        
        private string userIdField;
        
        private string userGroupField;
        
        private string ownerField;
        
        private string nodeField;
        
        private string affiliateField;
        
        /// <remarks/>
        public string UserId {
            get {
                return this.userIdField;
            }
            set {
                this.userIdField = value;
            }
        }
        
        /// <remarks/>
        public string UserGroup {
            get {
                return this.userGroupField;
            }
            set {
                this.userGroupField = value;
            }
        }
        
        /// <remarks/>
        public string Owner {
            get {
                return this.ownerField;
            }
            set {
                this.ownerField = value;
            }
        }
        
        /// <remarks/>
        public string Node {
            get {
                return this.nodeField;
            }
            set {
                this.nodeField = value;
            }
        }
        
        /// <remarks/>
        public string Affiliate {
            get {
                return this.affiliateField;
            }
            set {
                this.affiliateField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")]
    public delegate void AddUserCompletedEventHandler(object sender, AddUserCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class AddUserCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal AddUserCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")]
    public delegate void DeleteUserCompletedEventHandler(object sender, DeleteUserCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class DeleteUserCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal DeleteUserCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")]
    public delegate void UpdateUserCompletedEventHandler(object sender, UpdateUserCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class UpdateUserCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal UpdateUserCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")]
    public delegate void SetUserPropertyCompletedEventHandler(object sender, SetUserPropertyCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SetUserPropertyCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SetUserPropertyCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")]
    public delegate void GetUserPropertyCompletedEventHandler(object sender, GetUserPropertyCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetUserPropertyCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetUserPropertyCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public UserProperty[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((UserProperty[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")]
    public delegate void GetUserListCompletedEventHandler(object sender, GetUserListCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetUserListCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetUserListCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public UserInfo[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((UserInfo[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")]
    public delegate void ChangePwdCompletedEventHandler(object sender, ChangePwdCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ChangePwdCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ChangePwdCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}