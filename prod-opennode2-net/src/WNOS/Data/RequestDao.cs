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

using System.Data;
using System.Data.Common;
using System.Reflection;

using Spring.Data.Generic;
using Spring.Data.Common;
using Spring.Dao;
using Spring.Data.Support;

using Common.Logging;

using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSConnector.Provider;
using Windsor.Node2008.WNOSUtility;
using Windsor.Commons.Core;
using Windsor.Commons.NodeDomain;

namespace Windsor.Node2008.WNOS.Data
{
    /// <summary>
    /// Should be implementing interface but for now just use the raw object
    /// </summary>
    public class RequestDao : BaseDao, IRequestDao
    {
        public const string TABLE_NAME = "NRequest";
        public const string ARGS_TABLE_NAME = "NRequestArg";
        private IServiceDao _serviceDao;
        private ITransactionDao _transactionDao;

        #region Mappers
        private const string MAP_DATA_REQUEST_COLUMNS = "Id;TransactionId;ServiceId;RowIndex;MaxRowCount;RequestType;ModifiedBy;ModifiedOn;ParamsByName";
		private DataRequest MapDataRequest(IDataReader reader, out string serviceId, out bool paramsByName)
		{
			DataRequest request = new DataRequest();
			request.Id = reader.GetString(0);
			request.TransactionId = reader.GetString(1);
			serviceId = reader.GetString(2);
            object objNum = reader.GetValue(3);
            request.RowIndex = (objNum != null) ? int.Parse(objNum.ToString()) : 0;
            objNum = reader.GetValue(4);
            request.MaxRowCount = (objNum != null) ? int.Parse(objNum.ToString()) : 0;
			request.Type = EnumUtils.ParseEnum<RequestType>(reader.GetString(5));
			request.ModifiedById = reader.GetString(6);
			request.ModifiedOn = reader.GetDateTime(7);
			paramsByName = DbUtils.ToBool(reader.GetString(8));
			return request;
		}
		private void PostMapDataRequest(DataRequest request, string serviceId, bool paramsByName)
		{
			GetRequestArguments(request, paramsByName);
			request.Service = ServiceDao.GetDataService(serviceId);
		}
		private void PostMapDataRequests(IList<DataRequest> dataRequests, IList<string> serviceIds, 
										 IList<bool> paramsByNames)
		{
			if ( dataRequests != null ) {
				for (int i = 0; i < dataRequests.Count; ++i) {
					PostMapDataRequest(dataRequests[i], serviceIds[i], paramsByNames[i]);
				}
			}
		}
		#endregion // Mappers
		
        #region Methods
		/// <summary>
		/// Return the request id from the input transaction id.
		/// </summary>
        public string GetRequestIdFromTransaction(string transactionId) {
			return DoSimpleQueryForObjectDelegate<string>(
					TABLE_NAME, "TransactionId", transactionId, "Id", 
					delegate(IDataReader reader, int rowNum) 
					{
						return reader.GetString(0);
					});
        }
		/// <summary>
		/// Get the data request object for the request with the specified id, or null
		/// if the data request is not found.
		/// </summary>
        public DataRequest GetDataRequest(string requestId)
        {
			string serviceId = null;
			bool paramsByName = false;
			DataRequest dataRequest = 
				DoSimpleQueryForObjectDelegate<DataRequest>(
					TABLE_NAME, "Id", requestId, MAP_DATA_REQUEST_COLUMNS, 
					delegate(IDataReader reader, int rowNum) 
					{
						return MapDataRequest(reader, out serviceId, out paramsByName);
					});
				
			PostMapDataRequest(dataRequest, serviceId, paramsByName);	
			return dataRequest;
        }
		/// <summary>
		/// Return the arguments for the data request with the specified request id, or null
		/// if the data request is not found.
		/// </summary>
        private void GetRequestArguments(DataRequest request, bool paramsByName)
        {
			ByIndexOrNameDictionary<string> parameters = new ByIndexOrNameDictionary<string>(paramsByName);
			if ( paramsByName ) {
				DoSimpleQueryWithRowCallbackDelegate(
					ARGS_TABLE_NAME, "RequestId", request.Id, "ArgName",
					"ArgName;ArgValue",
					delegate(IDataReader reader) {
						parameters.Add(reader.GetString(0), reader.GetString(1));
					});
			} else {
				DoSimpleQueryWithRowCallbackDelegate(
                    ARGS_TABLE_NAME, "RequestId", request.Id, "ArgName",
					"ArgValue",
					delegate(IDataReader reader) {
						parameters.Add(reader.GetString(0));
					});
			}
			request.Parameters = parameters;
        }
		/// <summary>
		/// Create a new data request according to the input parameters and return the
		/// data request id.
		/// </summary>
        public string CreateDataRequest(string transactionId, string serviceId, int rowIndex, int maxRowCount, 
										RequestType type, string userCreatorId, ByIndexOrNameDictionary<string> parameters)
        {
			string requestId = IdProvider.Get();
			TransactionTemplate.Execute(delegate {
				DoInsert(TABLE_NAME,
						 "Id;TransactionId;ServiceId;RowIndex;MaxRowCount;RequestType;ModifiedBy;ModifiedOn;ParamsByName",
						 requestId, transactionId, serviceId, rowIndex, 
						 maxRowCount, type.ToString(), userCreatorId, DateTime.Now, 
						 DbUtils.ToDbBool((parameters == null) ? true : parameters.IsByName));
				if ( !CollectionUtils.IsNullOrEmpty(parameters) ) {
					object[] insertValues = new object[4];
					DoBulkInsert(ARGS_TABLE_NAME, "Id;RequestId;ArgName;ArgValue",
								 delegate(int currentInsertIndex) {
									if ( currentInsertIndex < parameters.Count ) {
										insertValues[0] = IdProvider.Get();
										insertValues[1] = requestId;
                                        if (parameters.IsByName)
                                        {
                                            insertValues[2] = parameters.KeyAtIndex(currentInsertIndex);
                                        }
                                        else
                                        {
                                            insertValues[2] = currentInsertIndex.ToString("D3");
                                        }
										insertValues[3] = parameters[currentInsertIndex];
										return insertValues;
									}
									return null;
								});
				}
				return null;
			});
			return requestId;
        }
        #endregion

        #region Init

        new public void Init()
        {
            base.Init();

			FieldNotInitializedException.ThrowIfNull(this, ref _serviceDao);
			FieldNotInitializedException.ThrowIfNull(this, ref _transactionDao);
		}

        #endregion

        #region Properties

        public IServiceDao ServiceDao
        {
			get {
				return _serviceDao;
			}
			set {
				_serviceDao = value;
			}
		}
        public ITransactionDao TransactionDao
        {
			get {
				return _transactionDao;
			}
			set {
				_transactionDao = value;
			}
		}
        #endregion
    }
}
