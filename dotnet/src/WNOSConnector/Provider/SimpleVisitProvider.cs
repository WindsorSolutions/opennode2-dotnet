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
using System.Data;
using System.Configuration;
using System.Web;
using System.Net;
using Common.Logging;
using Windsor.Node2008.WNOSUtility;
using System.Reflection;

using Windsor.Node2008.WNOSDomain;
using Windsor.Commons.Logging;

namespace Windsor.Node2008.WNOSConnector.Provider
{

    public interface IVisitProvider
    {
        NamedEndpointVisit GetVisit(string token);
        AuthEndpointVisit GetVisit(string username, string password, string domain, string method);
        AuthEndpointVisit GetVisit(string username, string password);
        string GetRequestorIP();

    }

    public class SimpleVisitProvider : IVisitProvider
    {
        private static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());

        public const string DEFAULT_HEADER_IP_ARGUMENT = "REMOTE_ADDR";
        public const string DEFAULT_AUTH_METHOD = "password";
        public const string DEFAULT_IP = "172.0.0.1";

        #region Members
        private string _headerIPArgument;
        private string _defaultAuthMethod;
        private string _defaultIp;
        private EndpointVersionType _version;
        #endregion

        #region Init

        public void Init()
        {

            if (string.IsNullOrEmpty(_defaultIp))
            {
                LOG.Info("DefaultIp not set. Using: " + DEFAULT_IP);
                _defaultIp = DEFAULT_IP;
            }

            if (string.IsNullOrEmpty(_headerIPArgument))
            {
                LOG.Info("HeaderIPArgument not set. Using: " + DEFAULT_HEADER_IP_ARGUMENT);
                _headerIPArgument = DEFAULT_HEADER_IP_ARGUMENT;
            }

            if (string.IsNullOrEmpty(_defaultAuthMethod))
            {
                LOG.Info("DefaultAuthMethod not set. Using: " + DEFAULT_AUTH_METHOD);
                _defaultAuthMethod = DEFAULT_AUTH_METHOD;
            }

            if (_version == EndpointVersionType.Undefined)
            {
                throw new ArgumentException("Version property not set");
            }
        }

        #endregion

        #region Methods


        /// <summary>
        /// Get Auth rewquest Visit
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="domain"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public AuthEndpointVisit GetVisit(string username, string password, string domain, string method)
        {
            LOG.Debug(string.Format(
                "Visit from (username: {0} password: *********** domain: {1} method: {2}", 
                username, domain, method));

            AuthEndpointVisit visit = GetVisit<AuthEndpointVisit>();
            visit.AuthMethod = method;
            visit.Credentials = new AuthenticationCredentials(username, password, domain);

            LOG.Debug("Visit: " + visit);
            return visit;
        }

        /// <summary>
        /// Get Auth rewquest Visit
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public AuthEndpointVisit GetVisit(string username, string password)
        {
            return GetVisit(username, password, null, _defaultAuthMethod);
        }

        /// <summary>
        /// Get Named User Visit
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public NamedEndpointVisit GetVisit(string token)
        {
            LOG.Debug("Visit from token: " + token);
            NamedEndpointVisit visit = GetVisit<NamedEndpointVisit>();
            visit.Token = token;
            LOG.Debug("Visit: " + visit);
            return visit;
        }
        #endregion

        #region Privates

        /// <summary>
        /// GetVisit
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private T GetVisit<T>() where T : EndpointVisit, new() 
        {
            LOG.Debug("Getting Basic Visit...");
            T visit = new T();
            visit.CreatedOn = DateTime.Now;
            visit.IP = GetRequestorIP();
            visit.Version = _version;
            return visit;
        }


        /// <summary>
        /// Get IP
        /// </summary>
        /// <returns></returns>
        public string GetRequestorIP()
        {
            string ip = _defaultIp;

            if (System.Web.HttpContext.Current != null)
            {
                LOG.Debug("Current HttpContext Exists");
                ip = System.Web.HttpContext.Current.Request[_headerIPArgument];
                LOG.Debug("IP: " + ip);
            }

            return ip;
        }

        #endregion

        #region Properties



        public string DefaultIp
        {
            set { _defaultIp = value; }
        }

        public string HeaderIPArgument
        {
            set { _headerIPArgument = value; }
        }

        public string DefaultAuthMethod
        {
            set { _defaultAuthMethod = value; }
        }

        public EndpointVersionType Version
        {
            set { _version = value; }
        }

        #endregion
    }
}
