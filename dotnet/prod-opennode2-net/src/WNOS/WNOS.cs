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
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Data;
using System.Text;
using System.Runtime.Remoting;
using System.Reflection;
using System.Diagnostics;
using System.Threading;

using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;

using Spring.Context;
using Spring.Context.Support;
using Spring.Data;
using Spring.Data.Common;

using Common.Logging;
using Windsor.Node2008.WNOS.Server;
using Windsor.Node2008.WNOSUtility;
using Windsor.Node2008.WNOSConnector.Server;
using Windsor.Node2008.WNOSDomain;
using Windsor.Commons.Core;
using Windsor.Commons.Logging;
using Windsor.Commons.Spring;

namespace Windsor.Node2008.WNOS
{
    public static class WNOSController
    {
        private static ILogEx LOG;
        private static INodeProcessor _centralProcessor;
        private static string _serviceName = "WNOS";

        public static string ServiceName
        {
            get { return _serviceName; }
        }

        public static void Start(string serviceName)
        {
            try
            {
                _serviceName = serviceName;
#if DEBUG
                //IDbProvider dbProvider = DbProviderFactory.GetDbProvider("OracleClient-2.0");
                //dbProvider.ConnectionString = "Data Source=ORA1;User Id=NODE_2008;Password=memorial;";
                //SpringBaseDao springBaseDao = new SpringBaseDao(dbProvider);

                //springBaseDao.RowExists("NAccount", "*", "Id", "0000-0000-0000-0000-0000");
#endif // DEBUG

                LOG = LogManagerEx.GetLogger(typeof(WNOSController));
                CreateApplicationEventLog();

                LogInfo("Calling ContextRegistry.GetContext()");
                IApplicationContext ctx = ContextRegistry.GetContext();

                LogInfo("Calling ConfigureRemoting()");
                ConfigureRemoting(ctx);

                LogInfo("Locating centralProcessor");
                _centralProcessor = (INodeProcessor)ctx["centralProcessor"];
                if (_centralProcessor == null)
                {
                    throw new System.Configuration.SettingsPropertyNotFoundException("centralProcessor");
                }
                LogInfo("Starting centralProcessor");
                _centralProcessor.Start();
                
                LogInfo("Exit WNOSController.Start()");
            }
            catch (Exception e)
            {
                LogError(e, "Exception thrown in WNOSController.Start()");
                throw;
            }
        }

        public static void Stop()
        {
            try
            {
                LogInfo("Stopping centralProcessor");
                if (_centralProcessor != null)
                {
                    _centralProcessor.Stop();
                }
                LogInfo("Exit WNOSController.Stop()");
            }
            catch (Exception e)
            {
                LogError(e, "Exception thrown in WNOSController.Start()");
                throw;
            }
        }
        private static void LogInfo(string messageFormat, params object[] args)
        {
            string message = CollectionUtils.IsNullOrEmpty(args) ? messageFormat : string.Format(messageFormat, args);
            try
            {
                EventLog.WriteEntry(ServiceName, message, EventLogEntryType.Information);
            }
            catch
            {
            }
            if (LOG != null)
            {
                try
                {
                    LOG.Info(message);
                }
                catch
                {
                }
            }
        }
        private static void LogError(Exception exception, string messageFormat, params object[] args)
        {
            string message = CollectionUtils.IsNullOrEmpty(args) ? messageFormat : string.Format(messageFormat, args);
            message += "EXCEPTION: " + ExceptionUtils.ToLongString(exception);
            try
            {
                EventLog.WriteEntry(ServiceName, message, EventLogEntryType.Error);
            }
            catch
            {
            }
            if (LOG != null)
            {
                try
                {
                    LOG.Error(message);
                }
                catch
                {
                }
            }
        }
        private static void CreateApplicationEventLog()
        {
            if (!EventLog.SourceExists(ServiceName))
            {
                //An event log source should not be created and immediately used.
                //There is a latency time to enable the source, it should be created
                //prior to executing the application that uses the source.
                //Execute this sample a second time to use the new source.
                EventLog.CreateEventSource(ServiceName, null);
                Thread.Sleep(5000);    // Let the source be created before logging
            }
        }


        private static void CheckDatabaseConnection(IApplicationContext ctx)
        {
            SpringBaseDao baseDao = (SpringBaseDao) ctx.GetObject("baseDao");
        }
        private static void ConfigureRemoting(IApplicationContext ctx)
        {
            RemotingConfiguration.CustomErrorsMode = CustomErrorsModes.Off;
            ExposablePropertyPaceholderConfigurer deployProps =
                (ExposablePropertyPaceholderConfigurer)ctx["deploymentProperties"];
            int tcpPort = int.Parse(deployProps["wnos.service.port"].ToString());
            TcpChannel channel = new TcpChannel(tcpPort);
            ChannelServices.RegisterChannel(channel, false);
        }
    }
}
