using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.IO;
using Spring.Data.Core;
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSProviders;
using Windsor.Node2008.WNOSPlugin;
using Windsor.Commons;
using Windsor.Commons.Spring;
using Windsor.Commons.NodeDomain;

namespace Windsor.Node2008.WNOSPlugin.ATTAINS_10
{
    public class GetAssessments : BaseWNOSPlugin, ISolicitProcessor
    {
        protected ISerializationHelper _serializationHelper;
        protected ICompressionHelper _compressionHelper;
        protected IRequestManager _requestManager;
        protected IDocumentManager _documentManager;
        protected ISettingsProvider _settingsProvider;
        protected SpringBaseDao _baseDao;
        protected DataRequest _dataRequest;

        protected const string SOURCE_PROVIDER_KEY = "Data Source";

        //service parameters
        protected const string CONFIG_COMPRESS_RESULTS = "Compress Results (true or false)";
        protected bool _compressResults;

        //request parameters
        protected const string PARAM_CYCLE_FILTER = "Cycle";
        protected int _cycle;
        protected const string PARAM_HUC_FILTER = "HUC";
        protected string _huc;
        protected const string PARAM_COUNTY_FILTER = "County";
        protected string _county;
        protected const string PARAM_WATERBODY_FILTER = "Waterbody";
        protected string _waterbody;
        protected const string PARAM_WATERTYPE_FILTER = "WaterType";
        protected string _waterType;
        protected const string PARAM_IRCATEGORY_FILTER = "IRCategory";
        protected string _IRCategory;

        public GetAssessments()
        {
            DataProviders.Add(SOURCE_PROVIDER_KEY, null);

            ConfigurationArguments.Add(CONFIG_COMPRESS_RESULTS, null);
        }

        public void ProcessSolicit(string requestId)
        {
            AppendAuditLogEvent("Initializing {0} plugin ...", this.GetType().Name);

            GetServiceImplementation(out _serializationHelper);
            GetServiceImplementation(out _compressionHelper);
            GetServiceImplementation(out _requestManager);
            GetServiceImplementation(out _documentManager);
            GetServiceImplementation(out _settingsProvider);

            _baseDao = ValidateDBProvider(SOURCE_PROVIDER_KEY, typeof(NamedNullMappingDataReader));

            TryGetConfigParameter(CONFIG_COMPRESS_RESULTS, ref _compressResults);

            AppendAuditLogEvent("Loading request with id \"{0}\"", requestId);
            _dataRequest = _requestManager.GetDataRequest(requestId);
            AppendAuditLogEvent("Request loaded: {0}", _dataRequest);

            //get params
            GetParameters();

            //call the build here
            string results = GetAssessmentData(_cycle, _huc, _county, _waterbody, _waterType, _IRCategory);

            string tempXmlPath = _settingsProvider.NewTempFilePath(".xml");
            using (StreamWriter outfile = new StreamWriter(tempXmlPath))
            {
                outfile.Write(results);
            }

            AppendAuditLogEvent("Attaching submission document to transaction \"{0}\"", _dataRequest.TransactionId);

            if (_compressResults)
            {
                //.zip the results before returning
                string tempZipPath = _settingsProvider.NewTempFilePath(".zip");
                _compressionHelper.CompressFile(tempXmlPath, tempZipPath);
                _documentManager.AddDocument(_dataRequest.TransactionId,
                    CommonTransactionStatusCode.Completed, null, tempZipPath);
            }
            else
            {
                _documentManager.AddDocument(_dataRequest.TransactionId,
                CommonTransactionStatusCode.Completed, null, tempXmlPath);
            }

        }

        /// <summary>
        /// Executes WQA.usp_node_GetAssessments stored procedure with parameters provided by the user.
        /// </summary>
        private string GetAssessmentData(int cycle, string huc, string county, string waterbody, string waterType, string IRCategory)
        {
            DataTable table = new DataTable();
            table.TableName = "Assessments";

            if (cycle <= 0)
            {
                AppendAuditLogEvent("Error:  Invalid Cycle parameter.");
                return null;
            }

            return (_baseDao.FillTable(table, "EXEC WQA.usp_node_GetAssessments '" + cycle + "', '" + huc + "', '" + county + "', '" 
                + waterbody + "', '" + waterType + "', '" + IRCategory + "';") > 0) ? table.Rows[0][0].ToString() : null;
        }

        /// <summary>
        /// Gets query paremeters.  Uses try/catch block to set default parameter if no value was provided.
        /// </summary>
        private void GetParameters()
        {
            try
            {
                GetParameter(_dataRequest, PARAM_CYCLE_FILTER, 0, out _cycle);
            }
            catch
            {
                _cycle = 0;
            }
            AppendAuditLogEvent("Cycle = \"{0}\"", _cycle);

            try
            {
                GetParameter(_dataRequest, PARAM_HUC_FILTER, 1, out _huc);
            }
            catch
            {
                _huc = "All";
            }
            AppendAuditLogEvent("HUC = \"{0}\"", _huc);

            try
            {
                GetParameter(_dataRequest, PARAM_COUNTY_FILTER, 2, out _county);
            }
            catch
            {
                _county = "All";
            }
            AppendAuditLogEvent("County = \"{0}\"", _county);

            try
            {
                GetParameter(_dataRequest, PARAM_WATERBODY_FILTER, 3, out _waterbody);
            }
            catch
            {
                _waterbody = "All";
            }
            AppendAuditLogEvent("Waterbody = \"{0}\"", _waterbody);

            try
            {
                GetParameter(_dataRequest, PARAM_WATERTYPE_FILTER, 4, out _waterType);
            }
            catch
            {
                _waterType = "All";
            }
            AppendAuditLogEvent("WaterType = \"{0}\"", _waterType);

            try
            {
                GetParameter(_dataRequest, PARAM_IRCATEGORY_FILTER, 5, out _IRCategory);
            }
            catch
            {
                _IRCategory = "All";
            }
            AppendAuditLogEvent("IRCategory = \"{0}\"", _IRCategory);
        }
    }
}
