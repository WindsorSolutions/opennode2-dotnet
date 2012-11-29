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
using Spring.Data.Common;
using Spring.Transaction.Support;
using Spring.Data.Core;
using System.ComponentModel;
using Windsor.Commons.Core;
using Windsor.Commons.Spring;

namespace Windsor.Node2008.WNOSPlugin.P2R
{
    [Serializable]
    internal static class P2RPluginMappers
    {
        public static ProgramDetailsDataType MapProgramDetails(NamedNullMappingDataReader readerEx)
        {
            ProgramDetailsDataType programDetails = new ProgramDetailsDataType();
            programDetails.ProgramIdentifier = readerEx.GetString("PROGRAM_IDENTIFIER");
            programDetails.ProgramName = readerEx.GetString("PROGRAM_NAME");
            programDetails.ProgramDescription = readerEx.GetNullString("PROGRAM_DESCRIPTION");
            programDetails.ProgramAddress = readerEx.GetNullString("PROGRAM_ADDRESS");
            programDetails.ProgramCity = readerEx.GetNullString("PROGRAM_CITY");
            programDetails.ProgramState = readerEx.GetNullString("PROGRAM_STATE");
            programDetails.ProgramZipCode = readerEx.GetNullString("PROGRAM_ZIP_CODE");
            programDetails.ProgramPhoneNumber = readerEx.GetNullString("PROGRAM_PHONE_NUMBER");
            programDetails.ProgramContactPerson = readerEx.GetNullString("PROGRAM_CONTACT_PERSON");
            return programDetails;
        }
        public static ProjectDetailsDataType MapProjectDetails(NamedNullMappingDataReader readerEx)
        {
            ProjectDetailsDataType projectDetails = new ProjectDetailsDataType();
            projectDetails.ProjectIdentifier = readerEx.GetString("PROJECT_IDENTIFIER");
            projectDetails.ProjectName = readerEx.GetString("PROJECT_NAME");
            projectDetails.ProjectDescription = readerEx.GetNullString("PROJECT_DESCRIPTION");
            projectDetails.ScopeAreaTextSpecified = !readerEx.IsDBNull("SCOPE_AREA_TEXT");
            if ( projectDetails.ScopeAreaTextSpecified ) {
                projectDetails.ScopeAreaText = EnumUtils.ParseEnum<ScopeAreaTextDataType>(readerEx.GetString("SCOPE_AREA_TEXT"));
            }
            projectDetails.ProjectStartDate = readerEx.GetDateTime("PROJECT_START_DATE");
            projectDetails.ProjectEndDateSpecified = !readerEx.IsDBNull("PROJECT_END_DATE");
            if (projectDetails.ProjectEndDateSpecified)
            {
                projectDetails.ProjectEndDate = readerEx.GetDateTime("PROJECT_END_DATE");
            }
            projectDetails.ProjectInputPerson = readerEx.GetNullString("PROJECT_INPUT_PERSON");
            projectDetails.ProjectDateEnteredSpecified = !readerEx.IsDBNull("PROJECT_DATE_ENTERED");
            if (projectDetails.ProjectDateEnteredSpecified)
            {
                projectDetails.ProjectDateEntered = readerEx.GetDateTime("PROJECT_DATE_ENTERED");
            }
            return projectDetails;
        }
        public static ActivityMeasureDataType MapActivityMeasure(NamedNullMappingDataReader readerEx)
        {
            ActivityMeasureDataType activityMeasure = new ActivityMeasureDataType();
            activityMeasure.ActivityMeasureIdentifier = readerEx.GetString("ACTIVITY_MEASURE_IDENTIFIER");
            activityMeasure.ActivityMeasureName = readerEx.GetString("ACTIVITY_MEASURE_NAME");
            activityMeasure.ActivityMeasureDefinition = readerEx.GetNullString("ACTIVITY_MEASURE_DEFINITION");
            return activityMeasure;
        }
        public static ProjectDetailsSectorDataType MapSectorText(NamedNullMappingDataReader readerEx)
        {
            ProjectDetailsSectorDataType data = new ProjectDetailsSectorDataType();
            data.SectorText = EnumUtils.ParseEnum<SectorTextDataType>(readerEx.GetString("SECTOR_TEXT"));
            return data;
        }
        public static InvestmentDataType MapInvestment(NamedNullMappingDataReader readerEx)
        {
            InvestmentDataType investment = new InvestmentDataType();
            investment.InvestmentIdentifier = readerEx.GetString("INVESTMENT_IDENTIFIER");
            investment.InvestmentName = readerEx.GetString("INVESTMENT_NAME");
            investment.InvestmentDefinition = readerEx.GetNullString("INVESTMENT_DEFINITION");
            investment.UnitOfMeasure = EnumUtils.ParseEnum<UnitOfMeasureDataType>(readerEx.GetString("UNIT_OF_MEASURE"));
            investment.InvestmentValue = ToDecimal(readerEx.GetString("INVESTMENT_VALUE"));
            return investment;
        }
        public static BehavioralChangeDataType MapBehavioralChange(NamedNullMappingDataReader readerEx)
        {
            BehavioralChangeDataType behavioralChange = new BehavioralChangeDataType();
            behavioralChange.BehavioralChangeIdentifier = readerEx.GetString("BEHAVIORAL_CHANGE_IDENTIFIER");
            behavioralChange.BehavioralChangeName = readerEx.GetString("BEHAVIORAL_CHANGE_NAME");
            behavioralChange.BehavioralChangeDefinition = readerEx.GetNullString("BEHAVIORAL_CHANGE_DEFINITION");
            return behavioralChange;
        }
        public static OutcomeMeasureDataType MapOutcomeMeasure(NamedNullMappingDataReader readerEx)
        {
            OutcomeMeasureDataType outcomeMeasure = new OutcomeMeasureDataType();
            outcomeMeasure.OutcomeMeasureIdentifier = readerEx.GetString("OUTCOME_MEASURE_IDENTIFIER");
            outcomeMeasure.OutcomeMeasureName = readerEx.GetString("OUTCOME_MEASURE_NAME");
            outcomeMeasure.OutcomeMeasureDefinition = readerEx.GetNullString("OUTCOME_MEASURE_DEFINITION");
            outcomeMeasure.OutcomeMeasureSavingSpecified = !readerEx.IsDBNull("OUTCOME_MEASURE_SAVING");
            if (outcomeMeasure.OutcomeMeasureSavingSpecified)
            {
                outcomeMeasure.OutcomeMeasureSaving = ToDecimal(readerEx.GetString("OUTCOME_MEASURE_SAVING"));
            }
            outcomeMeasure.OutcomeMeasureInitialCostSpecified = !readerEx.IsDBNull("OUTCOME_MEASURE_INITIAL_COST");
            if (outcomeMeasure.OutcomeMeasureInitialCostSpecified)
            {
                outcomeMeasure.OutcomeMeasureInitialCost = ToDecimal(readerEx.GetString("OUTCOME_MEASURE_INITIAL_COST"));
            }
            outcomeMeasure.OutcomeMeasureRecurringYear = readerEx.GetNullString("OUTCOME_MEASURE_RECURRING_YEAR");
            return outcomeMeasure;
        }
        public static ActivityMeasureQuantitativeResultDataType MapActivityMeasureQuantitativeResultDataType(NamedNullMappingDataReader readerEx)
        {
            ActivityMeasureQuantitativeResultDataType quantitativeResult = new ActivityMeasureQuantitativeResultDataType();
            quantitativeResult.P2RMeasureValue = readerEx.GetString("P2R_MEASURE_VALUE");
            quantitativeResult.UnitOfMeasure = EnumUtils.ParseEnum<UnitOfMeasureDataType>(readerEx.GetString("UNIT_OF_MEASURE"));
            return quantitativeResult;
        }
        public static BehavioralChangeQuantitativeResultDataType MapBehavioralChangeQuantitativeResultDataType(NamedNullMappingDataReader readerEx)
        {
            BehavioralChangeQuantitativeResultDataType quantitativeResult = new BehavioralChangeQuantitativeResultDataType();
            quantitativeResult.P2RMeasureValue = readerEx.GetString("P2R_MEASURE_VALUE");
            quantitativeResult.UnitOfMeasure = EnumUtils.ParseEnum<UnitOfMeasureDataType>(readerEx.GetString("UNIT_OF_MEASURE"));
            return quantitativeResult;
        }
        public static OutcomeMeasureResultDataType MapOutcomeMeasureResult(NamedNullMappingDataReader readerEx)
        {
            OutcomeMeasureResultDataType outcomeMeasureResult = new OutcomeMeasureResultDataType();
            outcomeMeasureResult.MediaTypeText = readerEx.GetString("MEDIA_TYPE_TEXT");
            outcomeMeasureResult.OutcomeMeasureResultValue = ToDecimal(readerEx.GetString("OUTCOME_MEASURE_RESULT_VALUE"));
            outcomeMeasureResult.UnitOfMeasure = EnumUtils.ParseEnum<UnitOfMeasureDataType>(readerEx.GetString("UNIT_OF_MEASURE"));
            outcomeMeasureResult.MetricText = EnumUtils.ParseEnum<MetricTextDataType>(readerEx.GetString("METRIC_TEXT"));
            return outcomeMeasureResult;
        }
        public static AddressPostalCodeDataType GetNullAddressPostalCode(NamedNullMappingDataReader readerEx, string valueName)
        {
            if (!readerEx.IsDBNull(valueName))
            {
                AddressPostalCodeDataType data = new AddressPostalCodeDataType();
                data.Value = readerEx.GetString(valueName);
                return data;
            }
            else
            {
                return null;
            }
        }
        public static T[] ToArray<T>(List<T> list)
        {
            return (list != null) ? list.ToArray() : null;
        }
        public static bool ToBool(string value)
        {
            return string.IsNullOrEmpty(value) ? false : ((value == "Y") || (value == "y"));
        }
        public static decimal ToDecimal(string value)
        {
            return string.IsNullOrEmpty(value) ? 0 : decimal.Parse(value);
        }
        public static string ToDbString(DateTime value)
        {
            return value.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
