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
using System.Reflection;

using Common.Logging;
using Spring.Transaction.Support;

using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOS.Data;
using Windsor.Node2008.WNOSUtility;
using Windsor.Node2008.WNOSConnector.Logic;
using Windsor.Node2008.WNOSProviders;
using Windsor.Commons.Core;
using Windsor.Commons.Logging;

namespace Windsor.Node2008.WNOS.Logic
{
    /// <summary>
    /// Base business logic manager that includes auditing and validation-by-user-role capabilities.
    /// </summary>
    public class LogicAuditBaseManager : LogicBaseManager
    {
        protected IActivityManager _activityManager;
        protected ISettingsProvider _settingsProvider;

        #region Init

        /// <summary>
        /// IoC initializer.
        /// </summary>
        new public void Init()
        {
            base.Init();
            FieldNotInitializedException.ThrowIfNull(this, ref _activityManager);
            FieldNotInitializedException.ThrowIfNull(this, ref _settingsProvider);
        }

        #endregion

        /// <summary>
        /// Validate that the input admin visitor has at least minimumRole permissions.  Throw an 
        /// UnauthorizedAccessException() if visitor is not validated.
        /// </summary>
        public static void ValidateByRole(AdminVisit visit, SystemRoleType minimumRole)
        {
            ValidateByRole(visit, minimumRole, false);
        }
 
        /// <summary>
        /// Validate that the input admin visitor has at least minimumRole permissions AND is not
        /// a demo visitor.  Throw an UnauthorizedAccessException() if visitor is not validated.
        /// </summary>
        public static void ValidateByRoleAndNotDemoAccount(AdminVisit visit, SystemRoleType minimumRole)
        {
            ValidateByRole(visit, minimumRole, true);
        }

        /// <summary>
        /// Internal validation method.  Throw an UnauthorizedAccessException() if visitor is not validated.
        /// </summary>
        private static void ValidateByRole(AdminVisit visit, SystemRoleType minimumRole, bool doValidateNotDemoAccount)
        {

            if (visit == null)
            {
                throw new ArgumentException("Input visit is null.");
            }

            if ((visit.Account == null) || string.IsNullOrEmpty(visit.Account.Id) ||
                ((visit.Account.Role != SystemRoleType.Admin) && ((Int32)visit.Account.Role) < ((Int32)minimumRole)))
            {
                throw new UnauthorizedAccessException("The current user does not have sufficient permissions to perform this operation.");
            }

            if (doValidateNotDemoAccount && (visit.Account.IsDemoUser != null) && visit.Account.IsDemoUser.Value)
            {
                throw new UnauthorizedAccessException("The current demo user does not have sufficient permissions to perform this operation.");
            }
        }

        #region Properties
        /// <summary>
        /// Activity manager is used for activity audit logging.
        /// </summary>
        public IActivityManager ActivityManager
        {
            get { return _activityManager; }
            set { _activityManager = value; }
        }

        /// <summary>
        /// Settings provider allows access to application settings.
        /// </summary>
        public ISettingsProvider SettingsProvider
        {
            get { return _settingsProvider; }
            set { _settingsProvider = value; }
        }
        #endregion
    }
}
