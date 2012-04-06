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
using System.ComponentModel;

namespace Windsor.Node2008.WNOSDomain
{

    /// <summary>
    /// The type of a data request
    /// </summary>
    public enum RequestType
    {
        None, Solicit, Query, Execute, Task
    }
    /// <summary>
    /// User roles on a system level
    /// </summary>
    public enum SystemRoleType
    {
        None,
        [Description("Endpoint User")]
        Authed,
        [Description("Program User")]
        Program,
        [Description("Administrator")]
        Admin
    }

    /// <summary>
    /// User roles on a flow level
    /// </summary>
    public enum FlowRoleType
    {
        [Description("None")]
        None,
        [Description("Endpoint User")]
        Endpoint,
        [Description("View")]
        View,
        [Description("Modify")]
        Modify
    }

    /// <summary>
    /// Notification types the system reports on and the user can subscribe to (NOTE: flags enum)
    /// </summary>
    [Flags]
    public enum NotificationType
    {
        None = 0x00, 
        OnSolicit = 0x01, 
        OnQuery = 0x02, 
        OnSubmit = 0x04, 
        OnDownload = 0x08, 
        OnNotify = 0x10, 
        OnSchedule = 0x20, 
        OnExecute = 0x40, 
        All = (OnSolicit | OnQuery | OnSubmit | OnDownload | OnNotify | OnSchedule | OnExecute)
    }

    /// <summary>
    /// Type of data service (NOTE: flags enum)
    /// </summary>
	[Flags]
    public enum ServiceType
    {
        None = 0x00,
        [Description("Query")]
        Query = 0x02,
        [Description("Solicit")]
        Solicit = 0x04,
        [Description("Submit")]
        Submit = 0x08,
        [Description("Notify")]
        Notify = 0x10,
        [Description("Execute")]
        Execute = 0x20,
        [Description("Internal Only")]
        InternalOnly = 0x40,
        [Description("Task")]
        Task = 0x80,
        [Description("Query or Solicit")]
        QueryOrSolicit = (Query | Solicit),
        [Description("Query or Solicit or Execute")]
        QueryOrSolicitOrExecute = (Query | Solicit | Execute),
        [Description("Query or Solicit or Execute or Task")]
        QueryOrSolicitOrExecuteOrTask = (Query | Solicit | Execute | Task)
    }

    /// <summary>
    /// Type of audit logging activity (NOTE: flags enum)
    /// </summary>
    public enum ActivityType
    {
        None = 0x00,
        [Description("Info")]
        Info = 1,
        [Description("Audit")]
        Audit = 8,
        [Description("Error")]
        Error = 16,
    }

    /// <summary>
    /// The authentication level for a data service request
    /// </summary>
    public enum ServiceRequestAuthorizationType
    {
        None,
        [Description("Basic")]
        Basic,
        [Description("Primitive")]
        Primitive,
        [Description("Flow")]
        Flow,
        [Description("Service")]
        Service
    }

    /// <summary>
    /// The type of node method call
    /// </summary>
    public enum NodeMethod
    {
        None = 0,
        [Description("Admin Login")]
        AdminLogin,
        [Description("Endpoint Authenticate")]
        Authenticate,
        [Description("Endpoint Submit")]
        Submit,
        [Description("Endpoint Download")]
        Download,
        [Description("Endpoint Query")]
        Query,
        [Description("Endpoint Solicit")]
        Solicit,
        [Description("Endpoint Notify")]
        Notify,
        [Description("Endpoint Execute")]
        Execute,
        [Description("Endpoint GetStatus")]
        GetStatus,
        [Description("Endpoint GetServices")]
        GetServices,
        [Description("Schedule")]
        Schedule,
        [Description("Task")]
        Task, 
        Any
    }

    /// <summary>
    /// The type of transaction notification
    /// </summary>
    public enum TransactionNotificationType
    {
        All,
        Warning,
        Error,
        Status,
        None
    }

    public enum SchedulePostProcessingAction
    {
        None,
        ContinueNormally,
    }
}
