using System;
using System.Data;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data.Properties;
using Microsoft.Practices.EnterpriseLibrary.Data.Instrumentation;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Data.Oracle;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Diagnostics;
using Common.Logging;
using System.IO;
using Windsor.Commons.Core;
using Windsor.Commons.Logging;
using Windsor.Commons.Spring;
using System.Transactions;

namespace Windsor.Node2008.WNOSPlugin.TRI5
{

    public enum TRIDataProviderType
    {
        Undefined, SQL, ORA
    }

    internal enum TRIDBTableType
    {
        TRI_CHEM,
        TRI_FAC,
        TRI_FAC_DUN,
        TRI_FAC_NAICS,
        TRI_FAC_SIC,
        TRI_NPDES_ID,
        TRI_OFFSITE_DISP_QTY,
        TRI_OFFSITE_ENERGY_REC_QTY,
        TRI_OFFSITE_RECYCLED_Q,
        TRI_OFFSITE_TREATED_Q,
        TRI_OFFSITE_UIC_DISP_QTY,
        TRI_ONSITE_DISP_QTY,
        TRI_ONSITE_ENERGY_RCV_QTY,
        TRI_ONSITE_RCV_PROC,
        TRI_ONSITE_RECYCG_PROC,
        TRI_ONSITE_RECYCLED_Q,
        TRI_ONSITE_RELEASE_Q,
        TRI_ONSITE_TREATED_Q,
        TRI_ONSITE_UIC_DISP_QTY,
        TRI_RCRA_ID,
        TRI_REPLACED_REPORT_ID,
        TRI_REPORT,
        TRI_REPORT_VALIDATION,
        TRI_SRC_RED_ACT,
        TRI_SRC_RED_METH_CD,
        TRI_SUB,
        TRI_TRANSFER_LOC,
        TRI_TRANSFER_Q,
        TRI_UIC_ID,
        TRI_WASTE_TREAT_DTL,
        TRI_WASTE_TREAT_METH,
        TRI_POTW_WASTE_QUANTITY,
    }


    public class TRIData
    {

        private static readonly string LINE = "********************************************************";
        private static readonly ILog LOG = LogManager.GetLogger(typeof(TRIData));


        private DbConnection _connection;
        private Database _db;
        private Dictionary<TRIDBTableType, DbCommand> _dbCommands;
        private string[] _uniqueSubExceptionPaterns = new string[] { "unique constraint", "UNIQUE KEY constraint" };

        #region IInitializingObject Members

        public void Init(SpringBaseDao baseDao)
        {
            string connectionString = baseDao.DbProvider.ConnectionString;
            _db = baseDao.IsSqlServerDatabase ? 
                (Database) new SqlDatabase(connectionString) : (Database) new OracleDatabase(connectionString);

            if (_db == null)
            {
                throw new ArgumentException("Database not configured");
            }

            _connection = _db.CreateConnection();

            _connection.Open();

            _dbCommands = new Dictionary<TRIDBTableType, DbCommand>();

            //Get Commands
            foreach (string table in Enum.GetNames(typeof(TRIDBTableType)))
            {
                TRIDBTableType tableType = (TRIDBTableType)Enum.Parse(typeof(TRIDBTableType), table);
                DbCommand cmd = GetCommand(tableType);
                _dbCommands.Add(tableType, cmd);
            }
        }

        #endregion



        /// <summary>
        /// Dispose
        /// </summary>
        protected void Dispose()
        {
            if (_connection != null)
            {
                _connection.Close();
            }
        }

        /// <summary>
        /// Execute
        /// </summary>
        /// <param name="table"></param>
        /// <param name="parms"></param>
        private void Execute(TRIDBTableType table, params object[] parms)
        {
            try
            {
                ExecCommand(_dbCommands[table], parms);
            }
            catch (Exception ex)
            {
                LOG.Error("TABLE: " + table);
                LOG.Error("MSG: " + ex.Message, ex);
                throw;
            }

        }

        /// <summary>
        /// ToDBParam
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private object ToDBParam(object obj)
        {

            if ((obj == null) || (obj.ToString().Trim() == string.Empty))
            {
                return DBNull.Value;
            }

            try
            {

                TypeCode tCode = (TypeCode)Enum.Parse(typeof(TypeCode), obj.GetType().Name, true);

                switch (tCode)
                {
                    case TypeCode.DateTime:
                        if (Convert.ToDateTime(obj) < DateTime.Now.AddYears(-50))
                            return DBNull.Value;
                        break;
                    case TypeCode.Boolean:
                        return (obj.ToString().ToLower() == "true") ? "Y" : "N";
                    default:
                        break;
                }


                return obj;


            }
            catch (Exception ex)
            {
                LOG.Error(ex.Message, ex);
            }

            return obj;

        }



        /// <summary>
        /// GetCommand
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        private DbCommand GetCommand(TRIDBTableType table)
        {

            LOG.Info("Parsing SqlCommand for: " + table);
            string select = string.Format("select * from {0}", table);

            DbDataAdapter da = _db.DbProviderFactory.CreateDataAdapter();
            da.SelectCommand = _db.GetSqlStringCommand(select);
            da.SelectCommand.Connection = _connection;

            DbCommandBuilder cb = _db.DbProviderFactory.CreateCommandBuilder();
            cb.DataAdapter = da;
            cb.ConflictOption = ConflictOption.OverwriteChanges;

            DbCommand cmd = cb.GetInsertCommand();
            cmd.Connection = _connection;

            return cmd;
        }


        private object ParseItemFromArray(string[] list, int itemIndex)
        {
            if (list == null || itemIndex >= list.Length)
            {
                return null;
            }
            else
            {
                return list[itemIndex];
            }
        }


        /// <summary>
        /// ExecCommand
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="tableName"></param>
        /// <param name="insertParameters"></param>
        private void ExecCommand(DbCommand cmd, object[] insertParameters)
        {

            LOG.Info(cmd.CommandText);

            if ((cmd.Parameters.Count != 0) && (insertParameters != null) && (cmd.Parameters.Count != insertParameters.Length))
            {
                ApplicationException ex = new ApplicationException(string.Format(
                    "Number of params do not match: Expected the {0} command to have {1} and found {2}.",
                    cmd.CommandText, insertParameters.Length, cmd.Parameters.Count));

                LOG.Error(ex.Message, ex);
                throw ex;
            }

            for (int i = 0; i < cmd.Parameters.Count; i++)
            {
                cmd.Parameters[i].Value = ToDBParam(insertParameters[i]);
                LOG.Info(string.Format("{0}: {1}", i, cmd.Parameters[i].Value));
            }

            LOG.Info("ExecutingNonQuery");
            cmd.ExecuteNonQuery();

        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private object GetAnonymousTypeValue(object obj, Type type)
        {
            if ((obj == null) || (type == null))
            {
                return null;
            }

            Type t = obj.GetType();
            if (t.Name.ToLower() == type.Name.ToLower())
            {
                return obj;
            }

            return null;
        }

        private object GetAnonymousTypeValueFromList<T>(object[] objList, T[] enumList, string enumName, Type type)
        {

            if ((objList == null) || (objList.Length == 0) || (enumList == null) || (enumList.Length == 0) || (type == null))
            {
                return null;
            }
            int max = Math.Min(objList.Length, enumList.Length);
            for (int i = 0; i < max; ++i)
            {
                if (enumList[i].ToString() == enumName)
                {
                    return GetAnonymousTypeValue(objList[i], type);
                }
            }

            return null;
        }
        private object GetAnonymousTypeValueFromList(object[] objList, Type type)
        {
            if ((objList == null) || (objList.Length == 0) || (type == null))
            {
                return null;
            }
            foreach (object obj in objList)
            {
                Type t = obj.GetType();
                if (t.Name.ToLower() == type.Name.ToLower())
                {
                    return obj;
                }
            }

            return null;
        }
        private object GetSpecifiedValue<T>(bool isSpecified, T value)
        {
            return isSpecified ? (object)value : null;
        }
        /// <summary>
        /// ToxicEquivalencyIndicatorySpecified
        /// </summary>
        /// <param name="inVal"></param>
        /// <returns></returns>
        private object ToxicEquivalencyIndicatorySpecified(ToxicEquivalencyIdentificationDataType inVal)
        {
            if ((inVal != null) && inVal.ToxicEquivalencyNAIndicatorSpecified)
            {
                return inVal.ToxicEquivalencyNAIndicator;
            }
            else
            {
                return null;
            }
        }

        private string NewID()
        {
            return StringUtils.CreateSequentialGuid();
        }


        public void Load(TRIDataType triObjectInstance, SpringBaseDao baseDao, bool deleteExistingDataBeforeInsert)
        {

            if (triObjectInstance == null)
            {
                ArgumentException argEx = new ArgumentException("NULL TRI object");
                LOG.Error(argEx.Message, argEx);
                throw argEx;
            }

            if (triObjectInstance.Submission == null)
            {
                ArgumentException argSubEx = new ArgumentException("NULL Submission object");
                LOG.Error(argSubEx.Message, argSubEx);
                throw argSubEx;
            }

            try
            {
                Dictionary<string, string> subList = new Dictionary<string, string>();

                using (TransactionScope scope = new TransactionScope())
                {
                    Init(baseDao);

                    foreach (SubmissionDataType submit in triObjectInstance.Submission)
                    {

                        if (submit.Facility == null || submit.Report == null || submit.TRISubmissionIdentifier == null || 
                            string.IsNullOrEmpty(submit.TRISubmissionIdentifier.Value))
                        {
                            ArgumentException argSubElementEx = new ArgumentException(
                                "Submission cannot be saved without the Facility and Report components.");
                            LOG.Error(argSubElementEx.Message, argSubElementEx);
                            throw argSubElementEx;
                        }

                        LOG.Info("Submission Id (Dirty): " + submit.TRISubmissionIdentifier.Value);

                        string subIdentifier = Path.GetFileNameWithoutExtension(submit.TRISubmissionIdentifier.Value).ToUpper().Trim();

                        LOG.Info("Submission Id (Clean): " + subIdentifier);

                        if (subList.ContainsKey(subIdentifier))
                        {
                            submit.PK = subList[subIdentifier];
                        }
                        else
                        {

                            //Submissions
                            submit.PK = Guid.NewGuid().ToString();

                            LOG.Info(LINE);
                            LOG.Info("Sub Id: " + subIdentifier);
                            LOG.Info("Fac Pk: " + submit.PK);
                            LOG.Info("Fac Name: " + submit.Facility.FacilitySiteName);
                            LOG.Info(LINE);

                            try
                            {
                                if (deleteExistingDataBeforeInsert)
                                {
                                    baseDao.DoSimpleDelete("TRI_SUB", "TRI_SUB_ID", subIdentifier);
                                }

                                Execute(TRIDBTableType.TRI_SUB, submit.PK,
                                                                subIdentifier,
                                                                DateTime.Now,
                                                                triObjectInstance.TransactionID);

                            }
                            catch (Exception ex)
                            {
                                LOG.Error(ex.Message, ex);
                                bool isUniqueContraintException = false;
                                foreach (string checkString in _uniqueSubExceptionPaterns)
                                {
                                    if (ex.Message.IndexOf(checkString, 0, StringComparison.OrdinalIgnoreCase) >= 0)
                                    {
                                        isUniqueContraintException = true;
                                        break;
                                    }
                                }

                                if (isUniqueContraintException)
                                {
                                    //TSM: Don't throw exception here, just exit the method, the data is already in the database
                                    //throw new ApplicationException("Duplicate Submission Id (TRI_SUB_ID)!", ex);
                                    LOG.Warn(string.Format("Duplicate Submission Id (TRI_SUB_ID) found in database, exiting Load() routine: {0}!", subIdentifier), ex);
                                    continue;
                                }
                                else
                                {
                                    throw;
                                }
                            }

                            subList.Add(subIdentifier, submit.PK);

                            #region Facility

                            #region Facility Detail
                            //Facility
                            //Load only when the submission is new
                            //Someone thought it would be a good idea to repeat the facilities for each submission
                            submit.Facility.PK = NewID();
                            submit.Facility.FK = submit.PK;
                            string facilityAccessCode = submit.Facility.FacilityAccessDetails.Item as string;
                            PriorYearTechnicalContactDetailsDataType priorYearTechnicalContactDetailsDataType = submit.Facility.FacilityAccessDetails.Item as PriorYearTechnicalContactDetailsDataType;
                            Execute(TRIDBTableType.TRI_FAC,
                                submit.Facility.PK,
                                submit.Facility.FK,
                                submit.Facility.FacilityIdentifier[0].Value,
                                submit.Facility.FacilitySiteName,
                                submit.Facility.LocationAddress.LocationAddressText,
                                submit.Facility.LocationAddress.SupplementalLocationText,
                                submit.Facility.LocationAddress.LocalityName,
                                submit.Facility.LocationAddress.StateIdentity.StateCodeListIdentifier.Value,
                                submit.Facility.LocationAddress.StateIdentity.StateCode,
                                submit.Facility.LocationAddress.StateIdentity.StateName,
                                submit.Facility.LocationAddress.AddressPostalCode.Value,
                                submit.Facility.LocationAddress.CountryIdentity.CountryCodeListIdentifier.Value,
                                submit.Facility.LocationAddress.CountryIdentity.CountryCode,
                                submit.Facility.LocationAddress.CountryIdentity.CountryName,
                                submit.Facility.LocationAddress.CountyIdentity.CountyCodeListIdentifier.Value,
                                submit.Facility.LocationAddress.CountyIdentity.CountyCode,
                                submit.Facility.LocationAddress.CountyIdentity.CountyName,
                                submit.Facility.LocationAddress.TribalIdentity.TribalCodeListIdentifier.Value,
                                submit.Facility.LocationAddress.TribalIdentity.TribalCode,
                                submit.Facility.LocationAddress.TribalIdentity.TribalName,
                                submit.Facility.LocationAddress.TribalLandName,
                                submit.Facility.LocationAddress.TribalLandIndicator,
                                submit.Facility.LocationAddress.LocationDescriptionText,
                                submit.Facility.MailingFacilitySiteName,
                                submit.Facility.MailingAddress.MailingAddressText,
                                submit.Facility.MailingAddress.SupplementalAddressText,
                                submit.Facility.MailingAddress.MailingAddressCityName,
                                submit.Facility.MailingAddress.AddressPostalCode.Value,
                                submit.Facility.MailingAddress.ProvinceNameText,
                                submit.Facility.MailingAddress.StateIdentity.StateCodeListIdentifier.Value,
                                submit.Facility.MailingAddress.StateIdentity.StateCode,
                                submit.Facility.MailingAddress.StateIdentity.StateName,
                                submit.Facility.MailingAddress.CountryIdentity.CountryCodeListIdentifier.Value,
                                submit.Facility.MailingAddress.CountryIdentity.CountryCode,
                                submit.Facility.MailingAddress.CountryIdentity.CountryName,
                                submit.Facility.GeographicLocationDescription.LatitudeMeasure,
                                submit.Facility.GeographicLocationDescription.LongitudeMeasure,
                                submit.Facility.GeographicLocationDescription.SourceMapScaleNumber,
                                submit.Facility.GeographicLocationDescription.HorizontalAccuracyMeasure.MeasureValue,
                                submit.Facility.GeographicLocationDescription.HorizontalAccuracyMeasure.MeasureUnit.MeasureUnitCode,
                                submit.Facility.GeographicLocationDescription.HorizontalAccuracyMeasure.MeasureUnit.MeasureUnitName,
                                submit.Facility.GeographicLocationDescription.HorizontalAccuracyMeasure.MeasurePrecisionText, //42
                                submit.Facility.GeographicLocationDescription.HorizontalAccuracyMeasure.ResultQualifier.ResultQualifierCode,
                                submit.Facility.GeographicLocationDescription.HorizontalAccuracyMeasure.ResultQualifier.ResultQualifierName,
                                submit.Facility.GeographicLocationDescription.HorizontalCollectionMethod.MethodIdentifierCode,
                                submit.Facility.GeographicLocationDescription.HorizontalCollectionMethod.MethodName,
                                submit.Facility.GeographicLocationDescription.HorizontalCollectionMethod.MethodDescriptionText,
                                submit.Facility.GeographicLocationDescription.HorizontalCollectionMethod.MethodDeviationsText,
                                submit.Facility.GeographicLocationDescription.GeographicReferencePoint.GeographicReferencePointCode,
                                submit.Facility.GeographicLocationDescription.GeographicReferencePoint.GeographicReferencePointName,
                                submit.Facility.GeographicLocationDescription.HorizontalReferenceDatum.GeographicReferenceDatumCode,
                                submit.Facility.GeographicLocationDescription.HorizontalReferenceDatum.GeographicReferenceDatumName,
                                submit.Facility.GeographicLocationDescription.DataCollectionDate,
                                submit.Facility.GeographicLocationDescription.LocationCommentsText,
                                submit.Facility.GeographicLocationDescription.VerticalMeasure.MeasureValue,
                                submit.Facility.GeographicLocationDescription.VerticalMeasure.MeasureUnit.MeasureUnitCode,
                                submit.Facility.GeographicLocationDescription.VerticalMeasure.MeasureUnit.MeasureUnitName,
                                submit.Facility.GeographicLocationDescription.VerticalMeasure.MeasurePrecisionText, //42
                                submit.Facility.GeographicLocationDescription.VerticalMeasure.ResultQualifier.ResultQualifierCode,
                                submit.Facility.GeographicLocationDescription.VerticalMeasure.ResultQualifier.ResultQualifierName,
                                submit.Facility.GeographicLocationDescription.VerticalCollectionMethod.MethodIdentifierCode,
                                submit.Facility.GeographicLocationDescription.VerticalCollectionMethod.MethodName,
                                submit.Facility.GeographicLocationDescription.VerticalCollectionMethod.MethodDescriptionText,
                                submit.Facility.GeographicLocationDescription.VerticalCollectionMethod.MethodDeviationsText,
                                submit.Facility.GeographicLocationDescription.GeographicReferencePoint.GeographicReferencePointCode,
                                submit.Facility.GeographicLocationDescription.GeographicReferencePoint.GeographicReferencePointName,
                                submit.Facility.GeographicLocationDescription.VerificationMethod.MethodIdentifierCodeListIdentifier.Value,
                                submit.Facility.GeographicLocationDescription.VerificationMethod.MethodName,
                                submit.Facility.GeographicLocationDescription.VerificationMethod.MethodDescriptionText,
                                submit.Facility.GeographicLocationDescription.VerificationMethod.MethodDeviationsText,
                                submit.Facility.GeographicLocationDescription.CoordinateDataSource.CoordinateDataSourceCode,
                                submit.Facility.GeographicLocationDescription.CoordinateDataSource.CoordinateDataSourceName,
                                submit.Facility.GeographicLocationDescription.GeometricType.GeometricTypeCode,
                                submit.Facility.GeographicLocationDescription.GeometricType.GeometricTypeName,
                                submit.Facility.GeographicLocationDescription.LatitudeDegreeMeasure,
                                submit.Facility.GeographicLocationDescription.LatitudeMinuteMeasure,
                                submit.Facility.GeographicLocationDescription.LatitudeSecondMeasure,
                                submit.Facility.GeographicLocationDescription.LongitudeDegreeMeasure,
                                submit.Facility.GeographicLocationDescription.LongitudeMinuteMeasure,
                                submit.Facility.GeographicLocationDescription.LongitudeSecondMeasure,
                                submit.Facility.ParentCompanyNameText,
                                submit.Facility.ParentDunBradstreetCode,
                                facilityAccessCode,
                                (priorYearTechnicalContactDetailsDataType != null) ? priorYearTechnicalContactDetailsDataType.PriorYearTechnicalContactNameText : null,
                                (priorYearTechnicalContactDetailsDataType != null) ? priorYearTechnicalContactDetailsDataType.PriorYearTechnicalContactTelephoneNumberText : null);


                            #endregion


                            #region SIC
                            if (submit.Facility.FacilitySIC != null)
                            {
                                foreach (FacilitySICDataType sic in submit.Facility.FacilitySIC)
                                {
                                    if (!string.IsNullOrEmpty(sic.SICCode))
                                    {
                                        sic.PK = NewID();
                                        sic.FK = submit.Facility.PK;
                                        Execute(TRIDBTableType.TRI_FAC_SIC, sic.PK,
                                                sic.FK,
                                                sic.SICCode,
                                                sic.SICPrimaryIndicator);
                                    }

                                }
                            }
                            #endregion


                            #region NAICS
                            if (submit.Facility.FacilityNAICS != null)
                            {
                                foreach (FacilityNAICSDataType naics in submit.Facility.FacilityNAICS)
                                {
                                    if (!string.IsNullOrEmpty(naics.NAICSCode))
                                    {
                                        naics.PK = NewID();
                                        naics.FK = submit.Facility.PK;
                                        Execute(TRIDBTableType.TRI_FAC_NAICS, naics.PK,
                                                                                naics.FK,
                                                                                naics.NAICSCode,
                                                                                naics.NAICSPrimaryIndicator);
                                    }

                                }
                            }
                            #endregion


                            #region DUN
                            if (submit.Facility.FacilityDunBradstreetCode != null)
                            {
                                foreach (string dun in submit.Facility.FacilityDunBradstreetCode)
                                {
                                    if (!string.IsNullOrEmpty(dun))
                                    {
                                        Execute(TRIDBTableType.TRI_FAC_DUN, NewID(),
                                                                        submit.Facility.PK,
                                                                        dun);
                                    }

                                }
                            }
                            #endregion


                            #region RCRA
                            if (submit.Facility.RCRAIdentificationNumber != null)
                            {
                                foreach (string rcra in submit.Facility.RCRAIdentificationNumber)
                                {
                                    if (!string.IsNullOrEmpty(rcra))
                                    {
                                        Execute(TRIDBTableType.TRI_RCRA_ID, NewID(), submit.Facility.PK,
                                                                                                rcra);
                                    }

                                }
                            }
                            #endregion


                            #region NPDS
                            if (submit.Facility.NPDESIdentificationNumber != null)
                            {
                                foreach (string npds in submit.Facility.NPDESIdentificationNumber)
                                {
                                    if (!string.IsNullOrEmpty(npds))
                                    {
                                        Execute(TRIDBTableType.TRI_NPDES_ID, NewID(), submit.Facility.PK, npds);
                                    }

                                }
                            }
                            #endregion


                            #region UIC
                            if (submit.Facility.UICIdentificationNumber != null)
                            {
                                foreach (string uic in submit.Facility.UICIdentificationNumber)
                                {
                                    if (!string.IsNullOrEmpty(uic))
                                    {
                                        Execute(TRIDBTableType.TRI_UIC_ID, NewID(), submit.Facility.PK, uic);
                                    }

                                }
                            }
                            #endregion


                            #endregion

                        }

                        #region Report


                        //Reports
                        foreach (ReportDataType rep in submit.Report)
                        {

                            #region Report Detail

                            ToxicEquivalencyIdentificationDataType teidtOneTime =
                                GetAnonymousTypeValueFromList(rep.SourceReductionQuantity.Items, typeof(ToxicEquivalencyIdentificationDataType)) as ToxicEquivalencyIdentificationDataType;
                            if (teidtOneTime == null)
                            {
                                teidtOneTime = new ToxicEquivalencyIdentificationDataType();
                            }
                            //Add Report PK and Submit PK as Report FK
                            rep.PK = NewID();
                            rep.FK = submit.PK;
                            Execute(TRIDBTableType.TRI_REPORT,
                            rep.PK,
                            rep.FK,
                            rep.ReportIdentifier[0].Value,
                            rep.ReportMetaData.ReportPostmarkDate,
                            rep.ReportMetaData.ReportReceivedDate,
                            rep.ReportMetaData.ReportOriginalPostmarkDate,
                            rep.ReportMetaData.ReportOriginalReceivedDate,
                            rep.ReportMetaData.ReportSubmissionMethodCode,
                            rep.ReportMetaData.EPAPassedValidationIndicator,
                            rep.ReportMetaData.EPAProcessingStatusCode,
                            rep.ReportMetaData.UnalteredReportIndicator,
                            rep.ReportType.ReportTypeCode,
                            rep.SubmissionReportingYear,
                            rep.ReportDueDate,
                            rep.RevisionIndicator,
                            rep.ChemicalTradeSecretIndicator,
                            rep.SubmissionSanitizedIndicator,
                            rep.CertifierName,
                            rep.CertifierTitleText,
                            rep.CertificationSignedDate,
                            rep.SubmissionEntireFacilityIndicator,
                            rep.SubmissionPartialFacilityIndicator,
                            rep.SubmissionFederalFacilityIndicator,
                            rep.SubmissionGOCOFacilityIndicator,
                            rep.TechnicalContactNameText.IndividualFullName,
                            rep.TechnicalContactPhoneText,
                            rep.TechnicalContactEmailAddressText,
                            rep.PublicContactNameText.IndividualIdentifier.Value,
                            rep.PublicContactNameText.IndividualTitleText,
                            rep.PublicContactNameText.IndividualFullName,
                            rep.PublicContactPhoneText,
                            rep.ChemicalActivitiesAndUses.ChemicalAncillaryUsageIndicator,
                            rep.ChemicalActivitiesAndUses.ChemicalArticleComponentIndicator,
                            rep.ChemicalActivitiesAndUses.ChemicalByproductIndicator,
                            rep.ChemicalActivitiesAndUses.ChemicalFormulationComponentIndicator,
                            rep.ChemicalActivitiesAndUses.ChemicalImportedIndicator,
                            rep.ChemicalActivitiesAndUses.ChemicalManufactureAidIndicator,
                            rep.ChemicalActivitiesAndUses.ChemicalManufactureImpurityIndicator,
                            rep.ChemicalActivitiesAndUses.ChemicalProcessImpurityIndicator,
                            rep.ChemicalActivitiesAndUses.ChemicalProcessingAidIndicator,
                            rep.ChemicalActivitiesAndUses.ChemicalProducedIndicator,
                            rep.ChemicalActivitiesAndUses.ChemicalReactantIndicator,
                            rep.ChemicalActivitiesAndUses.ChemicalRepackagingIndicator,
                            rep.ChemicalActivitiesAndUses.ChemicalSalesDistributionIndicator,
                            rep.ChemicalActivitiesAndUses.ChemicalUsedProcessedIndicator,
                            rep.MaximumChemicalAmountCode,


                            //TSM: v5, five fields below have moved to the new TRI_POTW_WASTE_QUANTITY table
                                //GetAnonymousTypeValueFromList(rep.POTWWasteQuantity.Items, rep.POTWWasteQuantity.ItemsElementName, "WasteQuantityMeasure", typeof(decimal)),
                                //GetAnonymousTypeValueFromList(rep.POTWWasteQuantity.Items, rep.POTWWasteQuantity.ItemsElementName, "WasteQuantityNAIndicator", typeof(bool)),
                                //GetAnonymousTypeValueFromList(rep.POTWWasteQuantity.Items, rep.POTWWasteQuantity.ItemsElementName, "WasteQuantityRangeCode", typeof(string)),
                                //GetAnonymousTypeValue(rep.POTWWasteQuantity.Item, typeof(string)),
                                //GetAnonymousTypeValue(rep.POTWWasteQuantity.Item, typeof(bool)),
                            //null, // WASTE_Q_ME
                            //null, // WASTE_Q_ME_NA_IND
                            //null, // WASTE_Q_RANGE_CODE
                            //null, // Q_BASIS_EST_CODE
                            //null, // Q_BASIS_EST_NA_IND


                            GetAnonymousTypeValueFromList(rep.SourceReductionQuantity.Items, typeof(decimal)),
                            GetAnonymousTypeValueFromList(rep.SourceReductionQuantity.Items, typeof(bool)),
                            GetAnonymousTypeValue(rep.SourceReductionQuantity.Item1, typeof(decimal)),
                            GetAnonymousTypeValue(rep.SourceReductionQuantity.Item1, typeof(bool)),
                            rep.SubmissionAdditionalDataIndicator,
                            CheckToTruncateText(rep.OptionalInformationText),
                            rep.PublicContactEmailAddressText,
                            ParseItemFromArray(rep.ChemicalReportRevisionCode, 0),
                            ParseItemFromArray(rep.ChemicalReportRevisionCode, 1),
                            ParseItemFromArray(rep.ChemicalReportWithdrawalCode, 0),
                            ParseItemFromArray(rep.ChemicalReportWithdrawalCode, 1),


                            //TSM: v5, twenty-three fields below have moved to the new TRI_POTW_WASTE_QUANTITY table
                                //GetAnonymousTypeValue(teidt2.ToxicEquivalency1Value, typeof(string)),
                                //GetAnonymousTypeValue(teidt2.ToxicEquivalency2Value, typeof(string)),
                                //GetAnonymousTypeValue(teidt2.ToxicEquivalency3Value, typeof(string)),
                                //GetAnonymousTypeValue(teidt2.ToxicEquivalency4Value, typeof(string)),
                                //GetAnonymousTypeValue(teidt2.ToxicEquivalency5Value, typeof(string)),
                                //GetAnonymousTypeValue(teidt2.ToxicEquivalency6Value, typeof(string)),
                                //GetAnonymousTypeValue(teidt2.ToxicEquivalency7Value, typeof(string)),
                                //GetAnonymousTypeValue(teidt2.ToxicEquivalency8Value, typeof(string)),
                                //GetAnonymousTypeValue(teidt2.ToxicEquivalency9Value, typeof(string)),
                                //GetAnonymousTypeValue(teidt2.ToxicEquivalency10Value, typeof(string)),
                                //GetAnonymousTypeValue(teidt2.ToxicEquivalency11Value, typeof(string)),
                                //GetAnonymousTypeValue(teidt2.ToxicEquivalency12Value, typeof(string)),
                                //GetAnonymousTypeValue(teidt2.ToxicEquivalency13Value, typeof(string)),
                                //GetAnonymousTypeValue(teidt2.ToxicEquivalency14Value, typeof(string)),
                                //GetAnonymousTypeValue(teidt2.ToxicEquivalency15Value, typeof(string)),
                                //GetAnonymousTypeValue(teidt2.ToxicEquivalency16Value, typeof(string)),
                                //GetAnonymousTypeValue(teidt2.ToxicEquivalency17Value, typeof(string)),
                                //ToxicEquivalencyIndicatorySpecified(teidt2),
                                //GetAnonymousTypeValueFromList(rep.POTWWasteQuantity.Items, rep.POTWWasteQuantity.ItemsElementName, "WasteQuantityCatastrophicMeasure", typeof(decimal)),
                                //GetAnonymousTypeValueFromList(rep.POTWWasteQuantity.Items, rep.POTWWasteQuantity.ItemsElementName, "WasteQuantityRangeNumericBasisValue", typeof(decimal)),
                                //GetSpecifiedValue(rep.POTWWasteQuantity.QuantityDisposedLandfillPercentValueSpecified, rep.POTWWasteQuantity.QuantityDisposedLandfillPercentValue),
                                //GetSpecifiedValue(rep.POTWWasteQuantity.QuantityDisposedOtherPercentValueSpecified, rep.POTWWasteQuantity.QuantityDisposedOtherPercentValue),
                                //GetSpecifiedValue(rep.POTWWasteQuantity.QuantityTreatedPercentValueSpecified, rep.POTWWasteQuantity.QuantityTreatedPercentValue),
                            //null, // TOX_EQ_VAL1_POTW
                            //null, // TOX_EQ_VAL2_POTW
                            //null, // TOX_EQ_VAL3_POTW
                            //null, // TOX_EQ_VAL4_POTW
                            //null, // TOX_EQ_VAL5_POTW
                            //null, // TOX_EQ_VAL6_POTW
                            //null, // TOX_EQ_VAL7_POTW
                            //null, // TOX_EQ_VAL8_POTW
                            //null, // TOX_EQ_VAL9_POTW
                            //null, // TOX_EQ_VAL10_POTW
                            //null, // TOX_EQ_VAL11_POTW
                            //null, // TOX_EQ_VAL12_POTW
                            //null, // TOX_EQ_VAL13_POTW
                            //null, // TOX_EQ_VAL14_POTW
                            //null, // TOX_EQ_VAL15_POTW
                            //null, // TOX_EQ_VAL16_POTW
                            //null, // TOX_EQ_VAL17_POTW
                            //null, // TOX_EQ_NA_IND_POTW
                            //null, // WASTE_Q_CATASTROPHIC_MEASURE
                            //null, // WASTE_Q_RANGE_NUM_BASIS_VALUE
                            //null, // Q_DISP_LANDFILL_PERCENT_VALUE
                            //null, // Q_DISP_OTHER_PERCENT_VALUE
                            //null, // Q_TREATED_PERCENT_VALUE


                            GetAnonymousTypeValue(teidtOneTime.ToxicEquivalency1Value, typeof(string)),
                            GetAnonymousTypeValue(teidtOneTime.ToxicEquivalency2Value, typeof(string)),
                            GetAnonymousTypeValue(teidtOneTime.ToxicEquivalency3Value, typeof(string)),
                            GetAnonymousTypeValue(teidtOneTime.ToxicEquivalency4Value, typeof(string)),
                            GetAnonymousTypeValue(teidtOneTime.ToxicEquivalency5Value, typeof(string)),
                            GetAnonymousTypeValue(teidtOneTime.ToxicEquivalency6Value, typeof(string)),
                            GetAnonymousTypeValue(teidtOneTime.ToxicEquivalency7Value, typeof(string)),
                            GetAnonymousTypeValue(teidtOneTime.ToxicEquivalency8Value, typeof(string)),
                            GetAnonymousTypeValue(teidtOneTime.ToxicEquivalency9Value, typeof(string)),
                            GetAnonymousTypeValue(teidtOneTime.ToxicEquivalency10Value, typeof(string)),
                            GetAnonymousTypeValue(teidtOneTime.ToxicEquivalency11Value, typeof(string)),
                            GetAnonymousTypeValue(teidtOneTime.ToxicEquivalency12Value, typeof(string)),
                            GetAnonymousTypeValue(teidtOneTime.ToxicEquivalency13Value, typeof(string)),
                            GetAnonymousTypeValue(teidtOneTime.ToxicEquivalency14Value, typeof(string)),
                            GetAnonymousTypeValue(teidtOneTime.ToxicEquivalency15Value, typeof(string)),
                            GetAnonymousTypeValue(teidtOneTime.ToxicEquivalency16Value, typeof(string)),
                            GetAnonymousTypeValue(teidtOneTime.ToxicEquivalency17Value, typeof(string)),
                            ToxicEquivalencyIndicatorySpecified(teidtOneTime),
                            GetAnonymousTypeValueFromList(rep.SourceReductionQuantity.Items, typeof(string)),
                            CheckToTruncateText(rep.MiscellaneousInformationText)
                            );

                            #endregion



                            #region TRI_POTW_WASTE_QUANTITY
                            if ((rep.POTWWasteQuantity != null) && (rep.POTWWasteQuantity.Length > 0))
                            {
                                foreach (POTWWasteQuantityDataType potw in rep.POTWWasteQuantity)
                                {
                                    ToxicEquivalencyIdentificationDataType teidt2 = new ToxicEquivalencyIdentificationDataType();
                                    if (potw.ToxicEquivalencyIdentification != null)
                                    {
                                        teidt2 = potw.ToxicEquivalencyIdentification;
                                    }
                                    Execute(TRIDBTableType.TRI_POTW_WASTE_QUANTITY, NewID(),
                                            rep.PK,
                                            GetSpecifiedValue(potw.POTWSequenceNumberSpecified, potw.POTWSequenceNumber),
                                            GetAnonymousTypeValueFromList(potw.Items, potw.ItemsElementName, "WasteQuantityMeasure", typeof(decimal)),
                                            GetAnonymousTypeValueFromList(potw.Items, potw.ItemsElementName, "WasteQuantityCatastrophicMeasure", typeof(decimal)),
                                            GetAnonymousTypeValueFromList(potw.Items, potw.ItemsElementName, "WasteQuantityRangeCode", typeof(string)),
                                            GetAnonymousTypeValueFromList(potw.Items, potw.ItemsElementName, "WasteQuantityRangeNumericBasisValue", typeof(decimal)),
                                            GetAnonymousTypeValueFromList(potw.Items, potw.ItemsElementName, "WasteQuantityNAIndicator", typeof(bool)),
                                            GetAnonymousTypeValue(potw.Item, typeof(string)),
                                            GetAnonymousTypeValue(potw.Item, typeof(bool)),
                                            GetAnonymousTypeValue(teidt2.ToxicEquivalency1Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt2.ToxicEquivalency2Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt2.ToxicEquivalency3Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt2.ToxicEquivalency4Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt2.ToxicEquivalency5Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt2.ToxicEquivalency6Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt2.ToxicEquivalency7Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt2.ToxicEquivalency8Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt2.ToxicEquivalency9Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt2.ToxicEquivalency10Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt2.ToxicEquivalency11Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt2.ToxicEquivalency12Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt2.ToxicEquivalency13Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt2.ToxicEquivalency14Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt2.ToxicEquivalency15Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt2.ToxicEquivalency16Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt2.ToxicEquivalency17Value, typeof(string)),
                                            ToxicEquivalencyIndicatorySpecified(teidt2),
                                            GetSpecifiedValue(potw.QuantityDisposedLandfillPercentValueSpecified, potw.QuantityDisposedLandfillPercentValue),
                                            GetSpecifiedValue(potw.QuantityDisposedOtherPercentValueSpecified, potw.QuantityDisposedOtherPercentValue),
                                            GetSpecifiedValue(potw.QuantityTreatedPercentValueSpecified, potw.QuantityTreatedPercentValue)
                                            );
                                }
                            }
                            #endregion


                            #region TRI_REPORT_VALIDATION
                            if (rep.ReportMetaData.ReportValidation != null)
                            {
                                foreach (ReportValidationDataType rvdt in rep.ReportMetaData.ReportValidation)
                                {
                                    Execute(TRIDBTableType.TRI_REPORT_VALIDATION, NewID(),
                                                                                     rep.PK,
                                                                                     rvdt.ValidationEntityNameText,
                                                                                     rvdt.ValidationMessageCode,
                                                                                     rvdt.ValidationMessageText,
                                                                                     rvdt.EPAErrorSeverityCode);

                                }
                            }
                            #endregion


                            #region TRI_ONSITE_TREATED_QUANTITY
                            if (rep.SourceReductionQuantity.OnsiteTreatedQuantity != null)
                            {
                                foreach (TotalYearlyQuantityDataType otq in rep.SourceReductionQuantity.OnsiteTreatedQuantity)
                                {
                                    if ((otq.Items != null) || (otq.YearOffsetMeasure != null))
                                    {

                                        // new - 11/3/2008 - Added dioxin fields
                                        ToxicEquivalencyIdentificationDataType teidt = new ToxicEquivalencyIdentificationDataType();
                                        if (otq.ToxicEquivalencyIdentification != null)
                                        {
                                            teidt = otq.ToxicEquivalencyIdentification;
                                        }
                                        //                                INSERT INTO [TRI_ONSITE_TREATED_Q] ([PK_GUID], [FK_GUID], [YEAR_OFFSET_ME], [TOTAL_Q], [TOTAL_Q_NA_IND], [TOX_EQ_VAL1], [TOX_EQ_VAL2], [TOX_EQ_VAL3], [TOX_EQ_VAL4], [TOX_EQ_VAL5], [TOX_EQ_VAL6], [TOX_EQ_VAL7], [TOX_EQ_VAL8], [TOX_EQ_VAL9], [TOX_EQ_VAL10], [TOX_EQ_VAL11], [TOX_EQ_VAL12], [TOX_EQ_VAL13], [TOX_EQ_VAL14], [TOX_EQ_VAL15], [TOX_EQ_VAL16], [TOX_EQ_VAL17], [TOX_EQ_NA_IND], [CALC_ROUNDING_HINT_NUMBER])
                                        Execute(TRIDBTableType.TRI_ONSITE_TREATED_Q,
                                                NewID(),
                                                rep.PK,
                                                otq.YearOffsetMeasure,
                                                GetAnonymousTypeValueFromList(otq.Items, typeof(decimal)),
                                                GetAnonymousTypeValueFromList(otq.Items, typeof(bool)),
                                                GetAnonymousTypeValue(teidt.ToxicEquivalency1Value, typeof(string)),
                                                GetAnonymousTypeValue(teidt.ToxicEquivalency2Value, typeof(string)),
                                                GetAnonymousTypeValue(teidt.ToxicEquivalency3Value, typeof(string)),
                                                GetAnonymousTypeValue(teidt.ToxicEquivalency4Value, typeof(string)),
                                                GetAnonymousTypeValue(teidt.ToxicEquivalency5Value, typeof(string)),
                                                GetAnonymousTypeValue(teidt.ToxicEquivalency6Value, typeof(string)),
                                                GetAnonymousTypeValue(teidt.ToxicEquivalency7Value, typeof(string)),
                                                GetAnonymousTypeValue(teidt.ToxicEquivalency8Value, typeof(string)),
                                                GetAnonymousTypeValue(teidt.ToxicEquivalency9Value, typeof(string)),
                                                GetAnonymousTypeValue(teidt.ToxicEquivalency10Value, typeof(string)),
                                                GetAnonymousTypeValue(teidt.ToxicEquivalency11Value, typeof(string)),
                                                GetAnonymousTypeValue(teidt.ToxicEquivalency12Value, typeof(string)),
                                                GetAnonymousTypeValue(teidt.ToxicEquivalency13Value, typeof(string)),
                                                GetAnonymousTypeValue(teidt.ToxicEquivalency14Value, typeof(string)),
                                                GetAnonymousTypeValue(teidt.ToxicEquivalency15Value, typeof(string)),
                                                GetAnonymousTypeValue(teidt.ToxicEquivalency16Value, typeof(string)),
                                                GetAnonymousTypeValue(teidt.ToxicEquivalency17Value, typeof(string)),
                                                ToxicEquivalencyIndicatorySpecified(teidt),
                                                GetAnonymousTypeValueFromList(otq.Items, typeof(string)));
                                    }

                                }
                            }
                            #endregion

                            #region TRI_ONSITE_RELEASE_QUANTITY
                            if (rep.OnsiteReleaseQuantity != null)
                            {
                                foreach (OnsiteReleaseQuantityDataType orc in rep.OnsiteReleaseQuantity)
                                {

                                    // new - 11/3/2008 - Added dioxin fields
                                    ToxicEquivalencyIdentificationDataType teidt = new ToxicEquivalencyIdentificationDataType();

                                    if (orc.OnsiteWasteQuantity != null)
                                    {
                                        if (orc.OnsiteWasteQuantity.ToxicEquivalencyIdentification != null)
                                        {
                                            teidt = orc.OnsiteWasteQuantity.ToxicEquivalencyIdentification;
                                        }
                                    }


                                    Execute(TRIDBTableType.TRI_ONSITE_RELEASE_Q,
                                            NewID(),
                                            rep.PK,
                                            orc.EnvironmentalMediumCode,
                                            GetAnonymousTypeValueFromList(orc.OnsiteWasteQuantity.Items, orc.OnsiteWasteQuantity.ItemsElementName, "WasteQuantityMeasure", typeof(decimal)),
                                            GetAnonymousTypeValueFromList(orc.OnsiteWasteQuantity.Items, orc.OnsiteWasteQuantity.ItemsElementName, "WasteQuantityNAIndicator", typeof(bool)),
                                            GetAnonymousTypeValueFromList(orc.OnsiteWasteQuantity.Items, orc.OnsiteWasteQuantity.ItemsElementName, "WasteQuantityRangeCode", typeof(string)),
                                            GetAnonymousTypeValue(orc.OnsiteWasteQuantity.Item, typeof(string)),
                                            GetAnonymousTypeValue(orc.OnsiteWasteQuantity.Item, typeof(bool)),
                                            (orc.WaterStream == null) ? null : orc.WaterStream.WaterSequenceNumber,
                                            (orc.WaterStream == null) ? null : orc.WaterStream.StreamName,
                                            (orc.WaterStream == null) ? null : GetAnonymousTypeValue(orc.WaterStream.Item, typeof(decimal)),
                                            (orc.WaterStream == null) ? null : GetAnonymousTypeValue(orc.WaterStream.Item, typeof(bool)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency1Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency2Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency3Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency4Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency5Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency6Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency7Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency8Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency9Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency10Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency11Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency12Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency13Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency14Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency15Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency16Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency17Value, typeof(string)),
                                            ToxicEquivalencyIndicatorySpecified(teidt),
                                            GetAnonymousTypeValueFromList(orc.OnsiteWasteQuantity.Items, orc.OnsiteWasteQuantity.ItemsElementName, "WasteQuantityCatastrophicMeasure", typeof(decimal)),
                                            GetAnonymousTypeValueFromList(orc.OnsiteWasteQuantity.Items, orc.OnsiteWasteQuantity.ItemsElementName, "WasteQuantityRangeNumericBasisValue", typeof(decimal))
                                            );

                                }
                            }
                            #endregion

                            #region TRI_OFFSITE_ENERGY_REC_QTY
                            if (rep.SourceReductionQuantity.OffsiteEnergyRecoveryQuantity != null)
                            {
                                foreach (TotalYearlyQuantityDataType oer in rep.SourceReductionQuantity.OffsiteEnergyRecoveryQuantity)
                                {
                                    // new - 11/3/2008 - Added dioxin fields
                                    ToxicEquivalencyIdentificationDataType teidt = new ToxicEquivalencyIdentificationDataType();
                                    if (oer.ToxicEquivalencyIdentification != null)
                                    {
                                        teidt = oer.ToxicEquivalencyIdentification;
                                    }

                                    if ((oer.Items != null) || (oer.YearOffsetMeasure != null))
                                    {
                                        Execute(TRIDBTableType.TRI_OFFSITE_ENERGY_REC_QTY, NewID(),
                                            rep.PK,
                                            oer.YearOffsetMeasure,
                                            GetAnonymousTypeValueFromList(oer.Items, typeof(decimal)),
                                            GetAnonymousTypeValueFromList(oer.Items, typeof(bool)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency1Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency2Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency3Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency4Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency5Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency6Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency7Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency8Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency9Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency10Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency11Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency12Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency13Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency14Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency15Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency16Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency17Value, typeof(string)),
                                            ToxicEquivalencyIndicatorySpecified(teidt),
                                            GetAnonymousTypeValueFromList(oer.Items, typeof(string))
                                            );
                                    }

                                }
                            }
                            #endregion

                            #region TRI_REPLACED_REPORT_IDENTIFIER
                            if (rep.ReplacedReportIdentifier != null)
                            {
                                foreach (string rri in rep.ReplacedReportIdentifier)
                                {
                                    if (!string.IsNullOrEmpty(rri))
                                    {
                                        Execute(TRIDBTableType.TRI_REPLACED_REPORT_ID, NewID(),
                                                                                                      rep.PK,
                                                                                                      rri);
                                    }

                                }
                            }
                            #endregion

                            #region TRI_OFFSITE_RECYCLED_QUANTITY
                            if (rep.SourceReductionQuantity.OffsiteRecycledQuantity != null)
                            {
                                foreach (TotalYearlyQuantityDataType orq in rep.SourceReductionQuantity.OffsiteRecycledQuantity)
                                {
                                    // new - 11/3/2008 - Added dioxin fields
                                    ToxicEquivalencyIdentificationDataType teidt = new ToxicEquivalencyIdentificationDataType();
                                    if (orq.ToxicEquivalencyIdentification != null)
                                    {
                                        teidt = orq.ToxicEquivalencyIdentification;
                                    }

                                    if ((orq.Items != null) || (orq.YearOffsetMeasure != null))
                                    {
                                        Execute(TRIDBTableType.TRI_OFFSITE_RECYCLED_Q,
                                            NewID(),
                                            rep.PK,
                                            orq.YearOffsetMeasure,
                                            GetAnonymousTypeValueFromList(orq.Items, typeof(decimal)),
                                            GetAnonymousTypeValueFromList(orq.Items, typeof(bool)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency1Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency2Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency3Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency4Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency5Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency6Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency7Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency8Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency9Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency10Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency11Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency12Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency13Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency14Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency15Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency16Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency17Value, typeof(string)),
                                            ToxicEquivalencyIndicatorySpecified(teidt),
                                            GetAnonymousTypeValueFromList(orq.Items, typeof(string))
                                            );
                                    }

                                }
                            }
                            #endregion

                            #region TRI_ONSITE_ENERGY_RECOVERY_QTY
                            if (rep.SourceReductionQuantity.OnsiteEnergyRecoveryQuantity != null)
                            {
                                foreach (TotalYearlyQuantityDataType oer in rep.SourceReductionQuantity.OnsiteEnergyRecoveryQuantity)
                                {
                                    if ((oer.Items != null) || (oer.YearOffsetMeasure != null))
                                    {
                                        // new - 11/3/2008 - Added dioxin fields
                                        ToxicEquivalencyIdentificationDataType teidt = new ToxicEquivalencyIdentificationDataType();
                                        if (oer.ToxicEquivalencyIdentification != null)
                                        {
                                            teidt = oer.ToxicEquivalencyIdentification;
                                        }

                                        Execute(TRIDBTableType.TRI_ONSITE_ENERGY_RCV_QTY,
                                            NewID(),
                                            rep.PK,
                                            oer.YearOffsetMeasure,
                                            GetAnonymousTypeValueFromList(oer.Items, typeof(decimal)),
                                            GetAnonymousTypeValueFromList(oer.Items, typeof(bool)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency1Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency2Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency3Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency4Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency5Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency6Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency7Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency8Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency9Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency10Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency11Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency12Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency13Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency14Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency15Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency16Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency17Value, typeof(string)),
                                            ToxicEquivalencyIndicatorySpecified(teidt),
                                            GetAnonymousTypeValueFromList(oer.Items, typeof(string))
                                            );
                                    }

                                }
                            }
                            #endregion

                            #region TRI_CHEMICAL
                            if (rep.ChemicalIdentification != null)
                            {
                                foreach (ChemicalIdentificationDataType ci in rep.ChemicalIdentification)
                                {
                                    Execute(TRIDBTableType.TRI_CHEM,
                                        NewID(),
                                        rep.PK,
                                        ci.CASNumber,
                                        ci.ChemicalNameText,
                                        ci.ChemicalMixtureNameText,
                                        ci.EPAChemicalIdentifier,
                                        ci.EPAChemicalRegistryName,
                                        ci.EPAChemicalRegistryNameContext,
                                        ci.DioxinDistribution1Percent,
                                        ci.DioxinDistribution2Percent,
                                        ci.DioxinDistribution3Percent,
                                        ci.DioxinDistribution4Percent,
                                        ci.DioxinDistribution5Percent,
                                        ci.DioxinDistribution6Percent,
                                        ci.DioxinDistribution7Percent,
                                        ci.DioxinDistribution8Percent,
                                        ci.DioxinDistribution9Percent,
                                        ci.DioxinDistribution10Percent,
                                        ci.DioxinDistribution11Percent,
                                        ci.DioxinDistribution12Percent,
                                        ci.DioxinDistribution13Percent,
                                        ci.DioxinDistribution14Percent,
                                        ci.DioxinDistribution15Percent,
                                        ci.DioxinDistribution16Percent,
                                        ci.DioxinDistribution17Percent);


                                }
                            }
                            #endregion

                            #region TRI_OFFSITE_TREATED_QUANTITY
                            if (rep.SourceReductionQuantity.OffsiteTreatedQuantity != null)
                            {
                                foreach (TotalYearlyQuantityDataType otq in rep.SourceReductionQuantity.OffsiteTreatedQuantity)
                                {
                                    if ((otq.Items != null) || (otq.YearOffsetMeasure != null))
                                    {
                                        // new - 11/3/2008 - Added dioxin fields
                                        ToxicEquivalencyIdentificationDataType teidt = new ToxicEquivalencyIdentificationDataType();
                                        if (otq.ToxicEquivalencyIdentification != null)
                                        {
                                            teidt = otq.ToxicEquivalencyIdentification;
                                        }

                                        Execute(TRIDBTableType.TRI_OFFSITE_TREATED_Q,
                                            NewID(),
                                            rep.PK,
                                            otq.YearOffsetMeasure,
                                            GetAnonymousTypeValueFromList(otq.Items, typeof(decimal)),
                                            GetAnonymousTypeValueFromList(otq.Items, typeof(bool)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency1Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency2Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency3Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency4Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency5Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency6Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency7Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency8Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency9Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency10Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency11Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency12Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency13Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency14Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency15Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency16Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency17Value, typeof(string)),
                                            ToxicEquivalencyIndicatorySpecified(teidt),
                                            GetAnonymousTypeValueFromList(otq.Items, typeof(string))
                                            );
                                    }

                                }
                            }
                            #endregion

                            #region TRI_ONSITE_UIC_DISPOSAL_QTY
                            if (rep.SourceReductionQuantity.OnsiteUICDisposalQuantity != null)
                            {
                                foreach (TotalYearlyQuantityDataType uicd in rep.SourceReductionQuantity.OnsiteUICDisposalQuantity)
                                {
                                    if ((uicd.Items != null) || (uicd.YearOffsetMeasure != null))
                                    {
                                        // new - 11/3/2008 - Added dioxin fields
                                        ToxicEquivalencyIdentificationDataType teidt = new ToxicEquivalencyIdentificationDataType();
                                        if (uicd.ToxicEquivalencyIdentification != null)
                                        {
                                            teidt = uicd.ToxicEquivalencyIdentification;
                                        }

                                        Execute(TRIDBTableType.TRI_ONSITE_UIC_DISP_QTY,
                                            NewID(),
                                            rep.PK,
                                            uicd.YearOffsetMeasure,
                                            GetAnonymousTypeValueFromList(uicd.Items, typeof(decimal)),
                                            GetAnonymousTypeValueFromList(uicd.Items, typeof(bool)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency1Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency2Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency3Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency4Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency5Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency6Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency7Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency8Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency9Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency10Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency11Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency12Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency13Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency14Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency15Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency16Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency17Value, typeof(string)),
                                            ToxicEquivalencyIndicatorySpecified(teidt),
                                            GetAnonymousTypeValueFromList(uicd.Items, typeof(string))
                                            );
                                    }

                                }
                            }
                            #endregion

                            #region TRI_ONSITE_OTHER_DISPOSAL_QTY
                            if (rep.SourceReductionQuantity.OnsiteOtherDisposalQuantity != null)
                            {
                                foreach (TotalYearlyQuantityDataType oodq in rep.SourceReductionQuantity.OnsiteOtherDisposalQuantity)
                                {
                                    if ((oodq.Items != null) || (oodq.YearOffsetMeasure != null))
                                    {
                                        // new - 11/3/2008 - Added dioxin fields
                                        ToxicEquivalencyIdentificationDataType teidt = new ToxicEquivalencyIdentificationDataType();
                                        if (oodq.ToxicEquivalencyIdentification != null)
                                        {
                                            teidt = oodq.ToxicEquivalencyIdentification;
                                        }

                                        Execute(TRIDBTableType.TRI_ONSITE_DISP_QTY,
                                            NewID(),
                                            rep.PK,
                                            oodq.YearOffsetMeasure,
                                            GetAnonymousTypeValueFromList(oodq.Items, typeof(decimal)),
                                            GetAnonymousTypeValueFromList(oodq.Items, typeof(bool)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency1Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency2Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency3Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency4Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency5Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency6Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency7Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency8Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency9Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency10Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency11Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency12Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency13Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency14Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency15Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency16Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency17Value, typeof(string)),
                                            ToxicEquivalencyIndicatorySpecified(teidt),
                                            GetAnonymousTypeValueFromList(oodq.Items, typeof(string))
                                            );
                                    }

                                }
                            }
                            #endregion

                            #region TRI_OFFSITE_OTHER_DISPOSAL_QTY
                            if (rep.SourceReductionQuantity.OffsiteOtherDisposalQuantity != null)
                            {
                                foreach (TotalYearlyQuantityDataType oodq2 in rep.SourceReductionQuantity.OffsiteOtherDisposalQuantity)
                                {
                                    if ((oodq2.Items != null) || (oodq2.YearOffsetMeasure != null))
                                    {
                                        // new - 11/3/2008 - Added dioxin fields
                                        ToxicEquivalencyIdentificationDataType teidt = new ToxicEquivalencyIdentificationDataType();
                                        if (oodq2.ToxicEquivalencyIdentification != null)
                                        {
                                            teidt = oodq2.ToxicEquivalencyIdentification;
                                        }

                                        Execute(TRIDBTableType.TRI_OFFSITE_DISP_QTY,
                                            NewID(),
                                            rep.PK,
                                            oodq2.YearOffsetMeasure,
                                            GetAnonymousTypeValueFromList(oodq2.Items, typeof(decimal)),
                                            GetAnonymousTypeValueFromList(oodq2.Items, typeof(bool)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency1Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency2Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency3Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency4Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency5Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency6Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency7Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency8Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency9Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency10Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency11Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency12Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency13Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency14Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency15Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency16Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency17Value, typeof(string)),
                                            ToxicEquivalencyIndicatorySpecified(teidt),
                                            GetAnonymousTypeValueFromList(oodq2.Items, typeof(string))
                                            );
                                    }

                                }
                            }
                            #endregion

                            #region TRI_ONSITE_RECOVERY_PROCESS
                            if (rep.OnsiteRecoveryProcess.Items != null)
                            {
                                foreach (object ermc in rep.OnsiteRecoveryProcess.Items)
                                {
                                    if ((ermc != null) && (ermc.ToString() != string.Empty))
                                    {
                                        Execute(TRIDBTableType.TRI_ONSITE_RCV_PROC,
                                            NewID(),
                                            rep.PK,
                                            GetAnonymousTypeValue(ermc, typeof(string)),
                                            GetAnonymousTypeValue(ermc, typeof(bool)));
                                    }

                                }
                            }
                            #endregion

                            #region TRI_ONSITE_RECYCLING_PROCESS
                            if (rep.OnsiteRecyclingProcess.Items != null)
                            {



                                foreach (object ormc in rep.OnsiteRecyclingProcess.Items)
                                {
                                    if ((ormc != null) && (ormc.ToString() != string.Empty))
                                    {
                                        Execute(TRIDBTableType.TRI_ONSITE_RECYCG_PROC,
                                            NewID(),
                                            rep.PK,
                                            GetAnonymousTypeValue(ormc, typeof(string)),
                                            GetAnonymousTypeValue(ormc, typeof(bool)));
                                    }

                                }
                            }
                            #endregion

                            #region TRI_OFFSITE_UIC_DISPOSAL_QTY
                            if (rep.SourceReductionQuantity.OffsiteUICDisposalQuantity != null)
                            {
                                foreach (TotalYearlyQuantityDataType uicd2 in rep.SourceReductionQuantity.OffsiteUICDisposalQuantity)
                                {
                                    if ((uicd2.Items != null) || (uicd2.YearOffsetMeasure != null))
                                    {
                                        // new - 11/3/2008 - Added dioxin fields
                                        ToxicEquivalencyIdentificationDataType teidt = new ToxicEquivalencyIdentificationDataType();
                                        if (uicd2.ToxicEquivalencyIdentification != null)
                                        {
                                            teidt = uicd2.ToxicEquivalencyIdentification;
                                        }

                                        Execute(TRIDBTableType.TRI_OFFSITE_UIC_DISP_QTY,
                                                                    NewID(),
                                                                    rep.PK,
                                                                    uicd2.YearOffsetMeasure,
                                                                    GetAnonymousTypeValueFromList(uicd2.Items, typeof(decimal)),
                                                                    GetAnonymousTypeValueFromList(uicd2.Items, typeof(bool)),
                                                                    GetAnonymousTypeValue(teidt.ToxicEquivalency1Value, typeof(string)),
                                                                    GetAnonymousTypeValue(teidt.ToxicEquivalency2Value, typeof(string)),
                                                                    GetAnonymousTypeValue(teidt.ToxicEquivalency3Value, typeof(string)),
                                                                    GetAnonymousTypeValue(teidt.ToxicEquivalency4Value, typeof(string)),
                                                                    GetAnonymousTypeValue(teidt.ToxicEquivalency5Value, typeof(string)),
                                                                    GetAnonymousTypeValue(teidt.ToxicEquivalency6Value, typeof(string)),
                                                                    GetAnonymousTypeValue(teidt.ToxicEquivalency7Value, typeof(string)),
                                                                    GetAnonymousTypeValue(teidt.ToxicEquivalency8Value, typeof(string)),
                                                                    GetAnonymousTypeValue(teidt.ToxicEquivalency9Value, typeof(string)),
                                                                    GetAnonymousTypeValue(teidt.ToxicEquivalency10Value, typeof(string)),
                                                                    GetAnonymousTypeValue(teidt.ToxicEquivalency11Value, typeof(string)),
                                                                    GetAnonymousTypeValue(teidt.ToxicEquivalency12Value, typeof(string)),
                                                                    GetAnonymousTypeValue(teidt.ToxicEquivalency13Value, typeof(string)),
                                                                    GetAnonymousTypeValue(teidt.ToxicEquivalency14Value, typeof(string)),
                                                                    GetAnonymousTypeValue(teidt.ToxicEquivalency15Value, typeof(string)),
                                                                    GetAnonymousTypeValue(teidt.ToxicEquivalency16Value, typeof(string)),
                                                                    GetAnonymousTypeValue(teidt.ToxicEquivalency17Value, typeof(string)),
                                                                    ToxicEquivalencyIndicatorySpecified(teidt),
                                                                    GetAnonymousTypeValueFromList(uicd2.Items, typeof(string))
                                                                    );
                                    }

                                }
                            }
                            #endregion

                            #region TRI_ONSITE_RECYCLED_QUANTITY
                            if (rep.SourceReductionQuantity.OnsiteRecycledQuantity != null)
                            {
                                foreach (TotalYearlyQuantityDataType orc in rep.SourceReductionQuantity.OnsiteRecycledQuantity)
                                {
                                    if ((orc.Items != null) || (orc.YearOffsetMeasure != null))
                                    {
                                        // new - 11/3/2008 - Added dioxin fields
                                        ToxicEquivalencyIdentificationDataType teidt = new ToxicEquivalencyIdentificationDataType();
                                        if (orc.ToxicEquivalencyIdentification != null)
                                        {
                                            teidt = orc.ToxicEquivalencyIdentification;
                                        }

                                        Execute(TRIDBTableType.TRI_ONSITE_RECYCLED_Q,
                                            NewID(),
                                            rep.PK,
                                            orc.YearOffsetMeasure,
                                            GetAnonymousTypeValueFromList(orc.Items, typeof(decimal)),
                                            GetAnonymousTypeValueFromList(orc.Items, typeof(bool)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency1Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency2Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency3Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency4Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency5Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency6Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency7Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency8Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency9Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency10Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency11Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency12Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency13Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency14Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency15Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency16Value, typeof(string)),
                                            GetAnonymousTypeValue(teidt.ToxicEquivalency17Value, typeof(string)),
                                            ToxicEquivalencyIndicatorySpecified(teidt),
                                            GetAnonymousTypeValueFromList(orc.Items, typeof(string))
                                            );
                                    }

                                }
                            }
                            #endregion

                            //Multiples
                            #region TRI_SOURCE_REDUCTION_ACTIVITY

                            if (rep.Items1 != null)
                            {


                                foreach (object sra in rep.Items1)
                                {

                                    if (sra != null)
                                    {



                                        if (sra is SourceReductionActivityDataType)
                                        {

                                            SourceReductionActivityDataType sradt = (SourceReductionActivityDataType)sra;

                                            sradt.PK = NewID();
                                            sradt.FK = rep.PK;

                                            Execute(TRIDBTableType.TRI_SRC_RED_ACT,
                                                sradt.PK,
                                                sradt.FK,
                                                sradt.SourceReductionSequenceNumber,
                                                sradt.SourceReductionActivityCode,
                                                null);

                                            if (sradt.SourceReductionMethodCode != null)
                                            {
                                                foreach (string code in sradt.SourceReductionMethodCode)
                                                {
                                                    Execute(TRIDBTableType.TRI_SRC_RED_METH_CD,
                                                        NewID(), sradt.PK, code, GetAnonymousTypeValue(code, typeof(bool)));
                                                }
                                            }

                                        }
                                        else
                                        {
                                            Execute(TRIDBTableType.TRI_SRC_RED_ACT,
                                                NewID(),
                                                rep.PK,
                                                null,
                                                null,
                                                sra);
                                        }
                                    }

                                }
                            }
                            #endregion

                            #region TRI_WASTE_TREATMENT_DETAILS
                            if (rep.Items != null)
                            {
                                foreach (object wtdo in rep.Items)
                                {
                                    if (wtdo is WasteTreatmentDetailsDataType)
                                    {

                                        WasteTreatmentDetailsDataType wtd = (WasteTreatmentDetailsDataType)wtdo;


                                        wtd.PK = NewID();
                                        wtd.FK = rep.PK;

                                        Execute(TRIDBTableType.TRI_WASTE_TREAT_DTL,
                                                    wtd.PK,
                                                    wtd.FK,
                                                    wtd.WasteStreamSequenceNumber,
                                                    wtd.WasteStreamTypeCode,
                                                    wtd.InfluentConcentrationRangeCode,
                                                    GetAnonymousTypeValue(wtd.Item, typeof(decimal)),
                                                    GetAnonymousTypeValue(wtd.Item, typeof(string)),
                                                    GetAnonymousTypeValue(wtd.Item, typeof(bool)),
                                                    wtd.OperatingDataIndicator,
                                                    null);

                                        if (wtd.WasteTreatmentMethod != null)
                                        {
                                            foreach (WasteTreatmentMethodDataType method in wtd.WasteTreatmentMethod)
                                            {
                                                if (method.WasteTreatmentMethodCode != null)
                                                {
                                                    Execute(TRIDBTableType.TRI_WASTE_TREAT_METH,
                                                                                                    NewID(),
                                                                                                    wtd.PK,
                                                                                                    method.WasteTreatmentSequenceNumber,
                                                                                                    method.WasteTreatmentMethodCode);
                                                }
                                            }
                                        }

                                    }
                                    else
                                    {

                                        Execute(TRIDBTableType.TRI_WASTE_TREAT_DTL,
                                                                                       NewID(),
                                                                                       rep.PK,
                                                                                       null,
                                                                                       null,
                                                                                       null,
                                                                                       null,
                                                                                       null,
                                                                                       null,
                                                                                       null,
                                                                                       GetAnonymousTypeValue(wtdo, typeof(bool)));

                                    }
                                }
                            }
                            #endregion

                            #region TRI_TRANSFER_LOCATION
                            if (rep.TransferLocation != null)
                            {
                                foreach (TransferLocationDataType tl in rep.TransferLocation)
                                {
                                    tl.PK = NewID();
                                    tl.FK = rep.PK;

                                    Execute(TRIDBTableType.TRI_TRANSFER_LOC,
                                        tl.PK,
                                        tl.FK,
                                        tl.TransferLocationSequenceNumber, // TODO: Doesn't check specified?
                                        tl.POTWIndicator,
                                        tl.FacilitySiteName,
                                        (tl.LocationAddress == null) ? string.Empty : tl.LocationAddress.LocationAddressText,
                                        (tl.LocationAddress == null) ? string.Empty : tl.LocationAddress.SupplementalLocationText,
                                        (tl.LocationAddress == null) ? string.Empty : tl.LocationAddress.LocalityName,
                                        (tl.LocationAddress == null) ? string.Empty : tl.LocationAddress.StateIdentity.StateName,
                                        (tl.LocationAddress == null) ? string.Empty : tl.LocationAddress.AddressPostalCode.Value,
                                        (tl.LocationAddress == null) ? string.Empty : tl.LocationAddress.CountyIdentity.CountyName,
                                        tl.ControlledLocationIndicator,
                                        tl.RCRAIdentificationNumber);

                                    if (tl.TransferQuantity != null)
                                    {
                                        foreach (TransferQuantityDataType tq in tl.TransferQuantity)
                                        {
                                            if (tq.TransferWasteQuantity != null)
                                            {
                                                WasteQuantityDataType wqdt = tq.TransferWasteQuantity;

                                                // new - 11/3/2008 - Added dioxin fields
                                                ToxicEquivalencyIdentificationDataType teidt = new ToxicEquivalencyIdentificationDataType();
                                                if (wqdt.ToxicEquivalencyIdentification != null)
                                                {
                                                    teidt = wqdt.ToxicEquivalencyIdentification;
                                                }

                                                Execute(TRIDBTableType.TRI_TRANSFER_Q,
                                                    NewID(),
                                                    tl.PK,
                                                    tq.TransferSequenceNumber,
                                                    GetAnonymousTypeValueFromList(wqdt.Items, wqdt.ItemsElementName, "WasteQuantityMeasure", typeof(decimal)),
                                                    GetAnonymousTypeValueFromList(wqdt.Items, wqdt.ItemsElementName, "WasteQuantityRangeCode", typeof(string)),
                                                    GetAnonymousTypeValueFromList(wqdt.Items, wqdt.ItemsElementName, "WasteQuantityNAIndicator", typeof(bool)),
                                                    GetAnonymousTypeValue(wqdt.Item, typeof(string)),
                                                    GetAnonymousTypeValue(wqdt.Item, typeof(bool)),
                                                    tq.WasteManagementTypeCode,
                                                    GetAnonymousTypeValue(teidt.ToxicEquivalency1Value, typeof(string)),
                                                    GetAnonymousTypeValue(teidt.ToxicEquivalency2Value, typeof(string)),
                                                    GetAnonymousTypeValue(teidt.ToxicEquivalency3Value, typeof(string)),
                                                    GetAnonymousTypeValue(teidt.ToxicEquivalency4Value, typeof(string)),
                                                    GetAnonymousTypeValue(teidt.ToxicEquivalency5Value, typeof(string)),
                                                    GetAnonymousTypeValue(teidt.ToxicEquivalency6Value, typeof(string)),
                                                    GetAnonymousTypeValue(teidt.ToxicEquivalency7Value, typeof(string)),
                                                    GetAnonymousTypeValue(teidt.ToxicEquivalency8Value, typeof(string)),
                                                    GetAnonymousTypeValue(teidt.ToxicEquivalency9Value, typeof(string)),
                                                    GetAnonymousTypeValue(teidt.ToxicEquivalency10Value, typeof(string)),
                                                    GetAnonymousTypeValue(teidt.ToxicEquivalency11Value, typeof(string)),
                                                    GetAnonymousTypeValue(teidt.ToxicEquivalency12Value, typeof(string)),
                                                    GetAnonymousTypeValue(teidt.ToxicEquivalency13Value, typeof(string)),
                                                    GetAnonymousTypeValue(teidt.ToxicEquivalency14Value, typeof(string)),
                                                    GetAnonymousTypeValue(teidt.ToxicEquivalency15Value, typeof(string)),
                                                    GetAnonymousTypeValue(teidt.ToxicEquivalency16Value, typeof(string)),
                                                    GetAnonymousTypeValue(teidt.ToxicEquivalency17Value, typeof(string)),
                                                    ToxicEquivalencyIndicatorySpecified(teidt),
                                                    GetAnonymousTypeValueFromList(wqdt.Items, wqdt.ItemsElementName, "WasteQuantityCatastrophicMeasure", typeof(decimal)),
                                                    GetAnonymousTypeValueFromList(wqdt.Items, wqdt.ItemsElementName, "WasteQuantityRangeNumericBasisValue", typeof(decimal))
                                                    );
                                            }
                                        }
                                    }

                                }
                            }
                            #endregion


                        }

                        #endregion

                    }

                    scope.Complete();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Dispose();
            }
        }
        protected string CheckToTruncateText(string text)
        {
            const string prependText = " **Field truncated due to size. See original submission.**";
            const int maxTextSize = 4000;

            if ((text != null) && (text.Length > maxTextSize))
            {
                text = text.Substring(0, maxTextSize - prependText.Length) + prependText;
            }
            return text;
        }
    }
}
