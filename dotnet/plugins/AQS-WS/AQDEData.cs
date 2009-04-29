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

namespace Windsor.Node2008.WNOSPlugin.AQSWS
{


    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name = "AQDEDataSoap", Namespace = "urn:schemas-drdas-com:reporter.aqde.webservice")]
    public partial class DrDasProxy : System.Web.Services.Protocols.SoapHttpClientProtocol
    {

        private System.Threading.SendOrPostCallback queryAQSRawDataOperationCompleted;

        private System.Threading.SendOrPostCallback queryAQSMonitorDataOperationCompleted;

        private System.Threading.SendOrPostCallback solicitAQSRawDataOperationCompleted;

        /// <remarks/>
        public DrDasProxy()
        {
            this.Url = "http://ecydblcyaqsql02/Reporter/AQDEData.asmx";
        }

        public DrDasProxy(string url)
        {
            this.Url = url;
        }

        /// <remarks/>
        public event queryAQSRawDataCompletedEventHandler queryAQSRawDataCompleted;

        /// <remarks/>
        public event queryAQSMonitorDataCompletedEventHandler queryAQSMonitorDataCompleted;

        /// <remarks/>
        public event solicitAQSRawDataCompletedEventHandler solicitAQSRawDataCompleted;

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:schemas-drdas-com:reporter.aqde.webservice/queryAQSRawData", RequestNamespace = "urn:schemas-drdas-com:reporter.aqde.webservice", ResponseNamespace = "urn:schemas-drdas-com:reporter.aqde.webservice", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string queryAQSRawData(
                    string FileGenerationPurposeCode,
                    string BeginDate,
                    string BeginTime,
                    string EndDate,
                    string EndTime,
                    string TimeType,
                    string SampleDuration,
                    string SubstanceName,
                    string MonitorType,
                    string DataValidityCode,
                    string DataApprovalIndicator,
                    string StateName,
                    string CountyName,
                    string CityName,
                    string TribeName,
                    string FacilitySiteIdentifier,
                    string MinLatitudeMeasure,
                    string MaxLatitudeMeasure,
                    string MinLongitudeMeasure,
                    string MaxLongitudeMeasure,
                    string LastUpdatedDate,
                    string IncludeMonitorDetails,
                    string IncludeEventData,
                    string SchemaVersion)
        {
            object[] results = this.Invoke("queryAQSRawData", new object[] {
                    FileGenerationPurposeCode,
                    BeginDate,
                    BeginTime,
                    EndDate,
                    EndTime,
                    TimeType,
                    SampleDuration,
                    SubstanceName,
                    MonitorType,
                    DataValidityCode,
                    DataApprovalIndicator,
                    StateName,
                    CountyName,
                    CityName,
                    TribeName,
                    FacilitySiteIdentifier,
                    MinLatitudeMeasure,
                    MaxLatitudeMeasure,
                    MinLongitudeMeasure,
                    MaxLongitudeMeasure,
                    LastUpdatedDate,
                    IncludeMonitorDetails,
                    IncludeEventData,
                    SchemaVersion});
            return ((string)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginqueryAQSRawData(
                    string FileGenerationPurposeCode,
                    string BeginDate,
                    string BeginTime,
                    string EndDate,
                    string EndTime,
                    string TimeType,
                    string SampleDuration,
                    string SubstanceName,
                    string MonitorType,
                    string DataValidityCode,
                    string DataApprovalIndicator,
                    string StateName,
                    string CountyName,
                    string CityName,
                    string TribeName,
                    string FacilitySiteIdentifier,
                    string MinLatitudeMeasure,
                    string MaxLatitudeMeasure,
                    string MinLongitudeMeasure,
                    string MaxLongitudeMeasure,
                    string LastUpdatedDate,
                    string IncludeMonitorDetails,
                    string IncludeEventData,
                    string SchemaVersion,
                    System.AsyncCallback callback,
                    object asyncState)
        {
            return this.BeginInvoke("queryAQSRawData", new object[] {
                    FileGenerationPurposeCode,
                    BeginDate,
                    BeginTime,
                    EndDate,
                    EndTime,
                    TimeType,
                    SampleDuration,
                    SubstanceName,
                    MonitorType,
                    DataValidityCode,
                    DataApprovalIndicator,
                    StateName,
                    CountyName,
                    CityName,
                    TribeName,
                    FacilitySiteIdentifier,
                    MinLatitudeMeasure,
                    MaxLatitudeMeasure,
                    MinLongitudeMeasure,
                    MaxLongitudeMeasure,
                    LastUpdatedDate,
                    IncludeMonitorDetails,
                    IncludeEventData,
                    SchemaVersion}, callback, asyncState);
        }

        /// <remarks/>
        public string EndqueryAQSRawData(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }

        /// <remarks/>
        public void queryAQSRawDataAsync(
                    string FileGenerationPurposeCode,
                    string BeginDate,
                    string BeginTime,
                    string EndDate,
                    string EndTime,
                    string TimeType,
                    string SampleDuration,
                    string SubstanceName,
                    string MonitorType,
                    string DataValidityCode,
                    string DataApprovalIndicator,
                    string StateName,
                    string CountyName,
                    string CityName,
                    string TribeName,
                    string FacilitySiteIdentifier,
                    string MinLatitudeMeasure,
                    string MaxLatitudeMeasure,
                    string MinLongitudeMeasure,
                    string MaxLongitudeMeasure,
                    string LastUpdatedDate,
                    string IncludeMonitorDetails,
                    string IncludeEventData,
                    string SchemaVersion)
        {
            this.queryAQSRawDataAsync(FileGenerationPurposeCode, BeginDate, BeginTime, EndDate, EndTime, TimeType, SampleDuration, SubstanceName, MonitorType, DataValidityCode, DataApprovalIndicator, StateName, CountyName, CityName, TribeName, FacilitySiteIdentifier, MinLatitudeMeasure, MaxLatitudeMeasure, MinLongitudeMeasure, MaxLongitudeMeasure, LastUpdatedDate, IncludeMonitorDetails, IncludeEventData, SchemaVersion, null);
        }

        /// <remarks/>
        public void queryAQSRawDataAsync(
                    string FileGenerationPurposeCode,
                    string BeginDate,
                    string BeginTime,
                    string EndDate,
                    string EndTime,
                    string TimeType,
                    string SampleDuration,
                    string SubstanceName,
                    string MonitorType,
                    string DataValidityCode,
                    string DataApprovalIndicator,
                    string StateName,
                    string CountyName,
                    string CityName,
                    string TribeName,
                    string FacilitySiteIdentifier,
                    string MinLatitudeMeasure,
                    string MaxLatitudeMeasure,
                    string MinLongitudeMeasure,
                    string MaxLongitudeMeasure,
                    string LastUpdatedDate,
                    string IncludeMonitorDetails,
                    string IncludeEventData,
                    string SchemaVersion,
                    object userState)
        {
            if ((this.queryAQSRawDataOperationCompleted == null))
            {
                this.queryAQSRawDataOperationCompleted = new System.Threading.SendOrPostCallback(this.OnqueryAQSRawDataOperationCompleted);
            }
            this.InvokeAsync("queryAQSRawData", new object[] {
                    FileGenerationPurposeCode,
                    BeginDate,
                    BeginTime,
                    EndDate,
                    EndTime,
                    TimeType,
                    SampleDuration,
                    SubstanceName,
                    MonitorType,
                    DataValidityCode,
                    DataApprovalIndicator,
                    StateName,
                    CountyName,
                    CityName,
                    TribeName,
                    FacilitySiteIdentifier,
                    MinLatitudeMeasure,
                    MaxLatitudeMeasure,
                    MinLongitudeMeasure,
                    MaxLongitudeMeasure,
                    LastUpdatedDate,
                    IncludeMonitorDetails,
                    IncludeEventData,
                    SchemaVersion}, this.queryAQSRawDataOperationCompleted, userState);
        }

        private void OnqueryAQSRawDataOperationCompleted(object arg)
        {
            if ((this.queryAQSRawDataCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.queryAQSRawDataCompleted(this, new queryAQSRawDataCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:schemas-drdas-com:reporter.aqde.webservice/queryAQSMonitorData", RequestNamespace = "urn:schemas-drdas-com:reporter.aqde.webservice", ResponseNamespace = "urn:schemas-drdas-com:reporter.aqde.webservice", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string queryAQSMonitorData(string FileGenerationPurposeCode, string SubstanceName, string MonitorType, string StateName, string CountyName, string CityName, string TribeName, string FacilitySiteIdentifier, string MinLatitudeMeasure, string MaxLatitudeMeasure, string MinLongitudeMeasure, string MaxLongitudeMeasure, string LastUpdatedDate, string SchemaVersion)
        {
            object[] results = this.Invoke("queryAQSMonitorData", new object[] {
                    FileGenerationPurposeCode,
                    SubstanceName,
                    MonitorType,
                    StateName,
                    CountyName,
                    CityName,
                    TribeName,
                    FacilitySiteIdentifier,
                    MinLatitudeMeasure,
                    MaxLatitudeMeasure,
                    MinLongitudeMeasure,
                    MaxLongitudeMeasure,
                    LastUpdatedDate,
                    SchemaVersion});
            return ((string)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginqueryAQSMonitorData(
                    string FileGenerationPurposeCode,
                    string SubstanceName,
                    string MonitorType,
                    string StateName,
                    string CountyName,
                    string CityName,
                    string TribeName,
                    string FacilitySiteIdentifier,
                    string MinLatitudeMeasure,
                    string MaxLatitudeMeasure,
                    string MinLongitudeMeasure,
                    string MaxLongitudeMeasure,
                    string LastUpdatedDate,
                    string SchemaVersion,
                    System.AsyncCallback callback,
                    object asyncState)
        {
            return this.BeginInvoke("queryAQSMonitorData", new object[] {
                    FileGenerationPurposeCode,
                    SubstanceName,
                    MonitorType,
                    StateName,
                    CountyName,
                    CityName,
                    TribeName,
                    FacilitySiteIdentifier,
                    MinLatitudeMeasure,
                    MaxLatitudeMeasure,
                    MinLongitudeMeasure,
                    MaxLongitudeMeasure,
                    LastUpdatedDate,
                    SchemaVersion}, callback, asyncState);
        }

        /// <remarks/>
        public string EndqueryAQSMonitorData(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }

        /// <remarks/>
        public void queryAQSMonitorDataAsync(string FileGenerationPurposeCode, string SubstanceName, string MonitorType, string StateName, string CountyName, string CityName, string TribeName, string FacilitySiteIdentifier, string MinLatitudeMeasure, string MaxLatitudeMeasure, string MinLongitudeMeasure, string MaxLongitudeMeasure, string LastUpdatedDate, string SchemaVersion)
        {
            this.queryAQSMonitorDataAsync(FileGenerationPurposeCode, SubstanceName, MonitorType, StateName, CountyName, CityName, TribeName, FacilitySiteIdentifier, MinLatitudeMeasure, MaxLatitudeMeasure, MinLongitudeMeasure, MaxLongitudeMeasure, LastUpdatedDate, SchemaVersion, null);
        }

        /// <remarks/>
        public void queryAQSMonitorDataAsync(string FileGenerationPurposeCode, string SubstanceName, string MonitorType, string StateName, string CountyName, string CityName, string TribeName, string FacilitySiteIdentifier, string MinLatitudeMeasure, string MaxLatitudeMeasure, string MinLongitudeMeasure, string MaxLongitudeMeasure, string LastUpdatedDate, string SchemaVersion, object userState)
        {
            if ((this.queryAQSMonitorDataOperationCompleted == null))
            {
                this.queryAQSMonitorDataOperationCompleted = new System.Threading.SendOrPostCallback(this.OnqueryAQSMonitorDataOperationCompleted);
            }
            this.InvokeAsync("queryAQSMonitorData", new object[] {
                    FileGenerationPurposeCode,
                    SubstanceName,
                    MonitorType,
                    StateName,
                    CountyName,
                    CityName,
                    TribeName,
                    FacilitySiteIdentifier,
                    MinLatitudeMeasure,
                    MaxLatitudeMeasure,
                    MinLongitudeMeasure,
                    MaxLongitudeMeasure,
                    LastUpdatedDate,
                    SchemaVersion}, this.queryAQSMonitorDataOperationCompleted, userState);
        }

        private void OnqueryAQSMonitorDataOperationCompleted(object arg)
        {
            if ((this.queryAQSMonitorDataCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.queryAQSMonitorDataCompleted(this, new queryAQSMonitorDataCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:schemas-drdas-com:reporter.aqde.webservice/solicitAQSRawData", RequestNamespace = "urn:schemas-drdas-com:reporter.aqde.webservice", ResponseNamespace = "urn:schemas-drdas-com:reporter.aqde.webservice", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string solicitAQSRawData(
                    string FileGenerationPurposeCode,
                    string BeginDate,
                    string BeginTime,
                    string EndDate,
                    string EndTime,
                    string TimeType,
                    string SampleDuration,
                    string SubstanceName,
                    string MonitorType,
                    string DataValidityCode,
                    string DataApprovalIndicator,
                    string StateName,
                    string CountyName,
                    string CityName,
                    string TribeName,
                    string FacilitySiteIdentifier,
                    string MinLatitudeMeasure,
                    string MaxLatitudeMeasure,
                    string MinLongitudeMeasure,
                    string MaxLongitudeMeasure,
                    string LastUpdatedDate,
                    string IncludeMonitorDetails,
                    string IncludeEventData,
                    string SchemaVersion,
                    string RequestId,
                    string CompressionEnabled)
        {
            object[] results = this.Invoke("solicitAQSRawData", new object[] {
                    FileGenerationPurposeCode,
                    BeginDate,
                    BeginTime,
                    EndDate,
                    EndTime,
                    TimeType,
                    SampleDuration,
                    SubstanceName,
                    MonitorType,
                    DataValidityCode,
                    DataApprovalIndicator,
                    StateName,
                    CountyName,
                    CityName,
                    TribeName,
                    FacilitySiteIdentifier,
                    MinLatitudeMeasure,
                    MaxLatitudeMeasure,
                    MinLongitudeMeasure,
                    MaxLongitudeMeasure,
                    LastUpdatedDate,
                    IncludeMonitorDetails,
                    IncludeEventData,
                    SchemaVersion,
                    RequestId,
                    CompressionEnabled});
            return ((string)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginsolicitAQSRawData(
                    string FileGenerationPurposeCode,
                    string BeginDate,
                    string BeginTime,
                    string EndDate,
                    string EndTime,
                    string TimeType,
                    string SampleDuration,
                    string SubstanceName,
                    string MonitorType,
                    string DataValidityCode,
                    string DataApprovalIndicator,
                    string StateName,
                    string CountyName,
                    string CityName,
                    string TribeName,
                    string FacilitySiteIdentifier,
                    string MinLatitudeMeasure,
                    string MaxLatitudeMeasure,
                    string MinLongitudeMeasure,
                    string MaxLongitudeMeasure,
                    string LastUpdatedDate,
                    string IncludeMonitorDetails,
                    string IncludeEventData,
                    string SchemaVersion,
                    string RequestId,
                    string CompressionEnabled,
                    System.AsyncCallback callback,
                    object asyncState)
        {
            return this.BeginInvoke("solicitAQSRawData", new object[] {
                    FileGenerationPurposeCode,
                    BeginDate,
                    BeginTime,
                    EndDate,
                    EndTime,
                    TimeType,
                    SampleDuration,
                    SubstanceName,
                    MonitorType,
                    DataValidityCode,
                    DataApprovalIndicator,
                    StateName,
                    CountyName,
                    CityName,
                    TribeName,
                    FacilitySiteIdentifier,
                    MinLatitudeMeasure,
                    MaxLatitudeMeasure,
                    MinLongitudeMeasure,
                    MaxLongitudeMeasure,
                    LastUpdatedDate,
                    IncludeMonitorDetails,
                    IncludeEventData,
                    SchemaVersion,
                    RequestId,
                    CompressionEnabled}, callback, asyncState);
        }

        /// <remarks/>
        public string EndsolicitAQSRawData(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }

        /// <remarks/>
        public void solicitAQSRawDataAsync(
                    string FileGenerationPurposeCode,
                    string BeginDate,
                    string BeginTime,
                    string EndDate,
                    string EndTime,
                    string TimeType,
                    string SampleDuration,
                    string SubstanceName,
                    string MonitorType,
                    string DataValidityCode,
                    string DataApprovalIndicator,
                    string StateName,
                    string CountyName,
                    string CityName,
                    string TribeName,
                    string FacilitySiteIdentifier,
                    string MinLatitudeMeasure,
                    string MaxLatitudeMeasure,
                    string MinLongitudeMeasure,
                    string MaxLongitudeMeasure,
                    string LastUpdatedDate,
                    string IncludeMonitorDetails,
                    string IncludeEventData,
                    string SchemaVersion,
                    string RequestId,
                    string CompressionEnabled)
        {
            this.solicitAQSRawDataAsync(FileGenerationPurposeCode, BeginDate, BeginTime, EndDate, EndTime, TimeType, SampleDuration, SubstanceName, MonitorType, DataValidityCode, DataApprovalIndicator, StateName, CountyName, CityName, TribeName, FacilitySiteIdentifier, MinLatitudeMeasure, MaxLatitudeMeasure, MinLongitudeMeasure, MaxLongitudeMeasure, LastUpdatedDate, IncludeMonitorDetails, IncludeEventData, SchemaVersion, RequestId, CompressionEnabled, null);
        }

        /// <remarks/>
        public void solicitAQSRawDataAsync(
                    string FileGenerationPurposeCode,
                    string BeginDate,
                    string BeginTime,
                    string EndDate,
                    string EndTime,
                    string TimeType,
                    string SampleDuration,
                    string SubstanceName,
                    string MonitorType,
                    string DataValidityCode,
                    string DataApprovalIndicator,
                    string StateName,
                    string CountyName,
                    string CityName,
                    string TribeName,
                    string FacilitySiteIdentifier,
                    string MinLatitudeMeasure,
                    string MaxLatitudeMeasure,
                    string MinLongitudeMeasure,
                    string MaxLongitudeMeasure,
                    string LastUpdatedDate,
                    string IncludeMonitorDetails,
                    string IncludeEventData,
                    string SchemaVersion,
                    string RequestId,
                    string CompressionEnabled,
                    object userState)
        {
            if ((this.solicitAQSRawDataOperationCompleted == null))
            {
                this.solicitAQSRawDataOperationCompleted = new System.Threading.SendOrPostCallback(this.OnsolicitAQSRawDataOperationCompleted);
            }
            this.InvokeAsync("solicitAQSRawData", new object[] {
                    FileGenerationPurposeCode,
                    BeginDate,
                    BeginTime,
                    EndDate,
                    EndTime,
                    TimeType,
                    SampleDuration,
                    SubstanceName,
                    MonitorType,
                    DataValidityCode,
                    DataApprovalIndicator,
                    StateName,
                    CountyName,
                    CityName,
                    TribeName,
                    FacilitySiteIdentifier,
                    MinLatitudeMeasure,
                    MaxLatitudeMeasure,
                    MinLongitudeMeasure,
                    MaxLongitudeMeasure,
                    LastUpdatedDate,
                    IncludeMonitorDetails,
                    IncludeEventData,
                    SchemaVersion,
                    RequestId,
                    CompressionEnabled}, this.solicitAQSRawDataOperationCompleted, userState);
        }

        private void OnsolicitAQSRawDataOperationCompleted(object arg)
        {
            if ((this.solicitAQSRawDataCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.solicitAQSRawDataCompleted(this, new solicitAQSRawDataCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        public new void CancelAsync(object userState)
        {
            base.CancelAsync(userState);
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    public delegate void queryAQSRawDataCompletedEventHandler(object sender, queryAQSRawDataCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class queryAQSRawDataCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal queryAQSRawDataCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public string Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    public delegate void queryAQSMonitorDataCompletedEventHandler(object sender, queryAQSMonitorDataCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class queryAQSMonitorDataCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal queryAQSMonitorDataCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public string Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    public delegate void solicitAQSRawDataCompletedEventHandler(object sender, solicitAQSRawDataCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class solicitAQSRawDataCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal solicitAQSRawDataCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public string Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }

}