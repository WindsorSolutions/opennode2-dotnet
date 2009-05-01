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
using System.Xml;
using System.IO;
using System.Data;
using System.Data.Common;
using System.Data.ProviderBase;
using Windsor.Node2008.WNOSPlugin;
using System.Diagnostics;
using System.Reflection;
using Windsor.Node2008.WNOSUtility;
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSProviders;
using Windsor.Commons.Logging;

namespace Windsor.Node2008.WNOSPlugin.FRS23
{
    public class FRSServiceCriteria
    {

        private static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());

        public enum FRSServiceType
        {
            GetFacilityByName, 
            GetFacilityByChangeDate, 
            GetDeletedFacilityByChangeDate,
            GetFacilityByChangePeriod, 
            GetDeletedFacilityByChangePeriod
        }

        private readonly string _uspsCode;
        private readonly string _facilityName;
        private readonly DateTime _changeDate;
        private readonly FRSServiceType _type;





        public FRSServiceCriteria(DataRequest request)
        {

            LOG.DebugEnter(MethodBase.GetCurrentMethod(), request);

            _type = (FRSServiceType)Enum.Parse(typeof(FRSServiceType), request.Service.Name);

            LOG.DebugEnter(MethodBase.GetCurrentMethod(), "Service Type: " + _type);

            _uspsCode = request.Parameters[0];

            //Get the arguments based on the type
            switch (_type)
            {
                case FRSServiceType.GetFacilityByName:
                    _facilityName = string.Format("%{0}%", request.Parameters[1]);
                    break;

                case FRSServiceType.GetFacilityByChangeDate:
                case FRSServiceType.GetDeletedFacilityByChangeDate:
                    if (!DateTime.TryParse(request.Parameters[1], out _changeDate))
                    {
                        throw new ApplicationException("Invalid change date argument");
                    }
                    break;

                case FRSServiceType.GetFacilityByChangePeriod:
                case FRSServiceType.GetDeletedFacilityByChangePeriod:

                    int numOfDays = -999;

                    if (!int.TryParse(request.Parameters[1], out numOfDays))
                    {
                        throw new ApplicationException("Invalid change period argument");
                    }

                    _changeDate = DateTime.Now.AddDays(-numOfDays);
                    break;

                default:
                    throw new ApplicationException("Invalid service type.");
            }
            
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(MethodBase.GetCurrentMethod());
            sb.Append(Environment.NewLine);
            sb.AppendFormat(" Service Type: {0}", _type);
            sb.Append(Environment.NewLine);
            sb.AppendFormat(" Facility Name: {0}", _facilityName);
            sb.Append(Environment.NewLine);
            sb.AppendFormat(" Change Date: {0}", _changeDate);
            sb.Append(Environment.NewLine);
            sb.AppendFormat(" USPS Code: {0}", _uspsCode);
            sb.Append(Environment.NewLine);

            return sb.ToString();
        }


        #region Properties


        public string USPSCode
        {
            get { return _uspsCode; }
        }

        public DateTime ChangeDate
        {
            get { return _changeDate; }
        }

        public string FacilityName
        {
            get { return _facilityName; }
        }

        internal FRSServiceType Type
        {
            get { return _type; }
        }

        public string ChangeDateXml
        {
            get { return _changeDate.ToString("yyyy-MM-dd"); }
        } 

        #endregion


    }
}
