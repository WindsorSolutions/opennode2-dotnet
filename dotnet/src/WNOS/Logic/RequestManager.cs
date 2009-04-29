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

using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOS.Data;
using Windsor.Node2008.WNOS.Logic;
using Windsor.Node2008.WNOSUtility;
using Windsor.Node2008.WNOSConnector.Provider;
using Windsor.Node2008.WNOSConnector.Logic;
using Windsor.Node2008.WNOSPlugin;
using Windsor.Commons.Core;

namespace Windsor.Node2008.WNOS.Logic
{
    public class RequestManager : LogicAuditBaseManager, IRequestManagerEx
    {
        private IRequestDao _requestDao;

        #region Init

        new public void Init()
        {
			base.Init();
			
			FieldNotInitializedException.ThrowIfNull(this, ref _requestDao);
        }

        #endregion
        
		public DataRequest GetDataRequest(string requestId)
        {
			return _requestDao.GetDataRequest(requestId);
        }
		public string CreateDataRequest(string transactionId, string serviceId, int rowIndex, int maxRowCount, 
										RequestType type, string userCreatorId, ByIndexOrNameDictionary<string> parameters)
        {
			return _requestDao.CreateDataRequest(transactionId, serviceId, rowIndex, maxRowCount, 
												 type, userCreatorId, parameters);
        }
        
        #region Properties
        public IRequestDao RequestDao
        {
			get {
				return _requestDao;
			}
			set {
				_requestDao = value;
			}
		}
        #endregion

    }
}
