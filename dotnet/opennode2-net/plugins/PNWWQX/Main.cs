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
using System.Collections;
using pnwwqx.wa;
using System.Web.Services.Protocols;
using System.Xml;

namespace pnwwqx.wa
{
	/// <summary>
	/// Main
	/// </summary>
	public class Main
	{
        public static PNWWQXMeasurements getMeasurements(
			int rowId, 
			int maxRows, 
			string providingOrganizationName, 
			string projectOrganizationName, 
			string projectName, 
			string projectStartDate, 
			string projectEndDate, 
			string responsibleOrganizationName,  
			string maximumLocationLatitude, 
			string maximumLocationLongitude, 
			string minimumLocationLatitude, 
			string minimumLocationLongitude, 
			string locationDescriptorContext, 
			string[] locationDescriptorName, 
			string[] stationType, 
			string stationName, 
			string samplingOrganizationName,
			string fieldEventStartDate, 
			string fieldEventEndDate, 
			string[] sampledMedia, 
			string[] analyteName, 
			string[] sampledTaxon
			)
        {

            PNWWQXMeasurements measurments = new PNWWQXMeasurements();

            //Validate Lat long
            //Do not wrap in try,catch -- validation logic build in
            Utility.LatLong ll = new Utility.LatLong(
                minimumLocationLatitude, 
                minimumLocationLongitude,
                maximumLocationLatitude,
                maximumLocationLongitude);

			Utility.MinMaxDate dateProject = new Utility.MinMaxDate(
				projectStartDate,
				projectEndDate);
			
			Utility.MinMaxDate dateFieldEvent = new Utility.MinMaxDate(
                fieldEventStartDate,
                fieldEventEndDate);


            //Array Used to buld the return array
            ArrayList returnMeasurments = new ArrayList();

            //Get Data
            DataSet ds = Data.getData
				(
                rowId,
                maxRows,
                providingOrganizationName,
                projectOrganizationName,
				projectName,
				dateProject,
				responsibleOrganizationName,
				ll,
				locationDescriptorContext,
				string.Join(Config.SQL_ARR_DELIMINATOR.ToString(), locationDescriptorName),
				string.Join(Config.SQL_ARR_DELIMINATOR.ToString(), stationType),
				stationName,
                samplingOrganizationName,
                dateFieldEvent,
				string.Join(Config.SQL_ARR_DELIMINATOR.ToString(), sampledMedia),
				string.Join(Config.SQL_ARR_DELIMINATOR.ToString(), analyteName),                    
                string.Join(Config.SQL_ARR_DELIMINATOR.ToString(), sampledTaxon),
				Common.PNWWQDXIdentity.Measurements
                );

#if DEBUG

			foreach(DataTable dt in ds.Tables)
			{
				System.Diagnostics.Debug.WriteLine("Table " + dt.TableName + ": " + dt.Rows.Count);
			}

#endif

                //Load Measurments
                Measurements.loadMeasurementsValues(ref returnMeasurments, ref ds);

            //Return cased array
            measurments.PNWWQXMeasurementsList = (PNWWQXMeasurementsList[])returnMeasurments.ToArray(typeof(PNWWQXMeasurementsList));

           
            return measurments;
        }



        /// <summary>
        /// getProjects
        /// </summary>
        /// <param name="rowId"></param>
        /// <param name="maxRows"></param>
        /// <param name="providingOrganizationName"></param>
        /// <param name="projectOrganizationName"></param>
        /// <param name="samplingOrganizationName"></param>
        /// <param name="projectStartDate"></param>
        /// <param name="projectEndDate"></param>
        /// <param name="maximumLocationLatitude"></param>
        /// <param name="maximumLocationLongitude"></param>
        /// <param name="minimumLocationLatitude"></param>
        /// <param name="minimumLocationLongitude"></param>
        /// <param name="locationDescriptorContext"></param>
        /// <param name="locationDescriptorName"></param>
        /// <param name="analyteName"></param>
        /// <returns>PNWWQXProjects</returns>
        public static PNWWQXProjects getProjects
			(
			int rowId, 
			int maxRows, 
			string providingOrganizationName, 
			string projectOrganizationName, 
			string projectName, 
			string projectStartDate, 
			string projectEndDate, 
			string responsibleOrganizationName,  
			string maximumLocationLatitude, 
			string maximumLocationLongitude, 
			string minimumLocationLatitude, 
			string minimumLocationLongitude, 
			string locationDescriptorContext, 
			string[] locationDescriptorName, 
			string[] stationType, 
			string stationName, 
			string samplingOrganizationName,
			string fieldEventStartDate, 
			string fieldEventEndDate, 
			string[] sampledMedia, 
			string[] analyteName, 
			string[] sampledTaxon
			)
        {

			//begin test raising user exceptions
			//SoapException SoapExcept = CreateSoapException();
			//throw SoapExcept;
			//throw new Exception("E_InvalidSQL");
			//end test

            PNWWQXProjects projects = new PNWWQXProjects();

			//Validate Lat long
			//Do not wrap in try,catch -- validation logic build in
			Utility.LatLong ll = new Utility.LatLong(
				minimumLocationLatitude, 
				minimumLocationLongitude,
				maximumLocationLatitude,
				maximumLocationLongitude);

			Utility.MinMaxDate dateProject = new Utility.MinMaxDate(
				projectStartDate,
				projectEndDate);
			
			Utility.MinMaxDate dateFieldEvent = new Utility.MinMaxDate(
				fieldEventStartDate,
				fieldEventEndDate);

				//Array Used to buld the return array
				ArrayList returnProject = new ArrayList();

				//Get Data
				DataSet ds = Data.getData
					(
					rowId,
					maxRows,
					providingOrganizationName,
					projectOrganizationName,
					projectName,
					dateProject,
					responsibleOrganizationName,
					ll,
					locationDescriptorContext,
					string.Join(Config.SQL_ARR_DELIMINATOR.ToString(), locationDescriptorName),
					string.Join(Config.SQL_ARR_DELIMINATOR.ToString(), stationType),
					stationName,
					samplingOrganizationName,
					dateFieldEvent,
					string.Join(Config.SQL_ARR_DELIMINATOR.ToString(), sampledMedia),
					string.Join(Config.SQL_ARR_DELIMINATOR.ToString(), analyteName),                    
					string.Join(Config.SQL_ARR_DELIMINATOR.ToString(), sampledTaxon),
					Common.PNWWQDXIdentity.Project
					);

#if DEBUG

			System.Diagnostics.Debug.WriteLine("Provider Row Count: " + ds.Tables[0].Rows.Count);
			System.Diagnostics.Debug.WriteLine("Project Row Count: " + ds.Tables[1].Rows.Count);
			System.Diagnostics.Debug.WriteLine("Organization Row Count: " + ds.Tables[2].Rows.Count);
			System.Diagnostics.Debug.WriteLine("Analyte Row Count: " + ds.Tables[3].Rows.Count);
			System.Diagnostics.Debug.WriteLine("Binaries Row Count: " + ds.Tables[4].Rows.Count);

#endif

				//Load Projects
				Project.loadProjectValues(ref returnProject, ref ds);

				//Return cased array
				projects.PNWWQXProjectsList = (PNWWQXProjectsList[])returnProject.ToArray(typeof(PNWWQXProjectsList));

			
			return projects;
        }


        /// <summary>
        /// getStations
        /// </summary>
        /// <param name="rowId"></param>
        /// <param name="maxRows"></param>
        /// <param name="responsibleOrganizationName"></param>
        /// <param name="providingOrganizationName"></param>
        /// <param name="projectName"></param>
        /// <param name="fieldEventStartDate"></param>
        /// <param name="fieldEventEndDate"></param>
        /// <param name="maximumLocationLatitude"></param>
        /// <param name="maximumLocationLongitude"></param>
        /// <param name="minimumLocationLatitude"></param>
        /// <param name="minimumLocationLongitude"></param>
        /// <param name="locationDescriptorContext"></param>
        /// <param name="locationDescriptorName"></param>
        /// <param name="stationType"></param>
        /// <param name="analyteName"></param>
        /// <returns>PNWWQXStations</returns>
        public static PNWWQXStations getStations
			(
			int rowId, 
			int maxRows, 
			string providingOrganizationName, 
			string projectOrganizationName, 
			string projectName, 
			string projectStartDate, 
			string projectEndDate, 
			string responsibleOrganizationName,  
			string maximumLocationLatitude, 
			string maximumLocationLongitude, 
			string minimumLocationLatitude, 
			string minimumLocationLongitude, 
			string locationDescriptorContext, 
			string[] locationDescriptorName, 
			string[] stationType, 
			string stationName, 
			string samplingOrganizationName,
			string fieldEventStartDate, 
			string fieldEventEndDate, 
			string[] sampledMedia, 
			string[] analyteName, 
			string[] sampledTaxon
            )
        {
            PNWWQXStations station = new PNWWQXStations();

			//Validate Lat long
			//Do not wrap in try,catch -- validation logic build in
			Utility.LatLong ll = new Utility.LatLong(
				minimumLocationLatitude, 
				minimumLocationLongitude,
				maximumLocationLatitude,
				maximumLocationLongitude);

			Utility.MinMaxDate dateProject = new Utility.MinMaxDate(
				projectStartDate,
				projectEndDate);
			
			Utility.MinMaxDate dateFieldEvent = new Utility.MinMaxDate(
				fieldEventStartDate,
				fieldEventEndDate);

			ArrayList returnStations = new ArrayList();

			//Get Data
			DataSet ds = Data.getData
				(
				rowId,
				maxRows,
				providingOrganizationName,
				projectOrganizationName,
				projectName,
				dateProject,
				responsibleOrganizationName,
				ll,
				locationDescriptorContext,
				string.Join(Config.SQL_ARR_DELIMINATOR.ToString(), locationDescriptorName),
				string.Join(Config.SQL_ARR_DELIMINATOR.ToString(), stationType),
				stationName,
				samplingOrganizationName,
				dateFieldEvent,
				string.Join(Config.SQL_ARR_DELIMINATOR.ToString(), sampledMedia),
				string.Join(Config.SQL_ARR_DELIMINATOR.ToString(), analyteName),                    
				string.Join(Config.SQL_ARR_DELIMINATOR.ToString(), sampledTaxon),
				Common.PNWWQDXIdentity.Station
				);

			if ((ds == null) || (ds.Tables == null) || (ds.Tables[0] == null) || (ds.Tables[0].Rows.Count < 1))
			{
				throw new ApplicationException("Query did not return any results. Please adjust your query.");
			}

#if DEBUG

			System.Diagnostics.Debug.WriteLine("Provider Row Count: " + ds.Tables[0].Rows.Count);
			System.Diagnostics.Debug.WriteLine("Project Row Count: " + ds.Tables[1].Rows.Count);
			System.Diagnostics.Debug.WriteLine("Organization Row Count: " + ds.Tables[2].Rows.Count);
			System.Diagnostics.Debug.WriteLine("Analyte Row Count: " + ds.Tables[3].Rows.Count);
			System.Diagnostics.Debug.WriteLine("Binaries Row Count: " + ds.Tables[4].Rows.Count);

#endif

			//Load Stations
			Stations.loadStationsValues(ref returnStations, ref ds);

			//Return cased array
			station.PNWWQXStationsList = (PNWWQXStationsList[])returnStations.ToArray(typeof(PNWWQXStationsList));


            return station;
        }


        /// <summary>
        /// getDataCatalog
        /// </summary>
        /// <returns>PNWWQXDataCatalog</returns>
//        public static PNWWQXDataCatalog getDataCatalog()
//        {
//            #region Get Data
//            DataSet dsDataCatalog = SqlHelper.ExecuteDataset(
//                Config.connectionString,
//                CommandType.StoredProcedure,
//                "PNWWQX_Get_DataCatalog");
//            #endregion
//
//            #region Establish Relationships
//            /* Tables[0] is Providing Organization  */
//            /* Tables[1] is Projects */
//            /* Tables[2] is Stations  */
//            /* Tables[3] is Location Descriptor*/
//            /* Tables[4] is Field Events*/
//            /* Tables[5] is Data Access */
//			
//            dsDataCatalog.Relations.Add("Org_Projects",
//                dsDataCatalog.Tables[0].Columns["ProvidingOrganizationPK"],
//                dsDataCatalog.Tables[1].Columns["ProvidingOrganizationFK"], false);
//
//            dsDataCatalog.Relations.Add("Org_Station",
//                dsDataCatalog.Tables[0].Columns["ProvidingOrganizationPK"],
//                dsDataCatalog.Tables[2].Columns["ProvidingOrganizationFK"], false);
//
//            dsDataCatalog.Relations.Add("Org_FieldEvent",
//                dsDataCatalog.Tables[0].Columns["ProvidingOrganizationPK"],
//                dsDataCatalog.Tables[4].Columns["ProvidingOrganizationFK"], false);
//
//            dsDataCatalog.Relations.Add("Station_LocationDescriptor",
//                dsDataCatalog.Tables[2].Columns["StationIdentifier"],
//                dsDataCatalog.Tables[3].Columns["StationSummaryIdentifier"], false);
//            #endregion
//
//            #region Populate Object
//
//            PNWWQXDataCatalog PNWWQXDataCatalog = new PNWWQXDataCatalog();
//            PNWWQXDataCatalog.PNWWQXDataCatalogList = new PNWWQXDataCatalogList[dsDataCatalog.Tables[0].Rows.Count];
//
//
//            for(int r = 0; r < dsDataCatalog.Tables[0].Rows.Count; r++)
//            {
//
//                DataRow drProvidingOrg = dsDataCatalog.Tables[0].Rows[r];
//
//                #region ProvidingOrganizationDetails
//                PNWWQXDataCatalogList PNWWQXDataCatalogList = new PNWWQXDataCatalogList();
//                ProvidingOrganizationDetailsType ProvidingOrganizationDetails = new ProvidingOrganizationDetailsType();
//                ProvidingOrganizationDetails.ProvidingOrganizationIdentifier = Utility.toStr(drProvidingOrg["ProvidingOrganizationIdentifier"]);
//                ProvidingOrganizationDetails.ProvidingOrganizationName = Utility.toStr(drProvidingOrg["ProvidingOrganizationName"]);
//
//                ProvidingOrganizationDetails.ProvidingOrganizationType = Utility.toStr(drProvidingOrg["ProvidingOrganizationType"]);
//
//                ProvidingOrganizationDetails.ProvidingOrganizationContactName = Utility.toStr(drProvidingOrg["ProvidingOrganizationContactName"]);
//                if (drProvidingOrg["MailingAddress"] != DBNull.Value ||
//                    drProvidingOrg["MailingAddressCityName"] != DBNull.Value ||
//                    drProvidingOrg["MailingAddressStateName"] != DBNull.Value ||
//                    drProvidingOrg["MailingAddressZIPCode"] != DBNull.Value)
//                {
//                    ProvidingOrganizationDetails.ProvidingOrganizationMailingAddress = new MailingAddressType();
//                    if(drProvidingOrg["MailingAddress"] != DBNull.Value) ProvidingOrganizationDetails.ProvidingOrganizationMailingAddress.MailingAddress = Utility.toStr(drProvidingOrg["MailingAddress"]);
//                    if(drProvidingOrg["MailingAddressCityName"] != DBNull.Value) ProvidingOrganizationDetails.ProvidingOrganizationMailingAddress.MailingAddressCityName = Utility.toStr(drProvidingOrg["MailingAddressCityName"]);
//                    if(drProvidingOrg["MailingAddressStateName"] != DBNull.Value) ProvidingOrganizationDetails.ProvidingOrganizationMailingAddress.MailingAddressStateName = Utility.toStr(drProvidingOrg["MailingAddressStateName"]);
//                    if(drProvidingOrg["MailingAddressZIPCode"] != DBNull.Value) ProvidingOrganizationDetails.ProvidingOrganizationMailingAddress.MailingAddressZIPCode = Utility.toStr(drProvidingOrg["MailingAddressZIPCode"]);
//                }
//                ProvidingOrganizationDetails.ProvidingOrganizationPhoneEmail = new PhoneEmailType();
//                ProvidingOrganizationDetails.ProvidingOrganizationPhoneEmail.TelephoneNumber = Utility.toStr(drProvidingOrg["TelephoneNumber"]);
//                if(drProvidingOrg["ElectronicMailAddressText"] != DBNull.Value) ProvidingOrganizationDetails.ProvidingOrganizationPhoneEmail.ElectronicMailAddressText = Utility.toStr(drProvidingOrg["ElectronicMailAddressText"]);
//                if(drProvidingOrg["ProvidingOrganizationURL"] != DBNull.Value) ProvidingOrganizationDetails.ProvidingOrganizationURL = Utility.toStr(drProvidingOrg["ProvidingOrganizationURL"]);
//
//                PNWWQXDataCatalogList.ProvidingOrganizationDetails = ProvidingOrganizationDetails;
//                #endregion
//
//                #region DataAccess
//                DataAccessType DataAccess = new DataAccessType();
//                DataAccess.DataSourceName = Utility.toStr(dsDataCatalog.Tables[5].Rows[0]["DataSourceName"]);
//
//                DataAccess.DataSourceAccessMethod = Utility.toStr(dsDataCatalog.Tables[5].Rows[0]["DataSourceAccessMethod"]);
//				
//				
//                if(dsDataCatalog.Tables[5].Rows[0]["DataSourceLocation"] != DBNull.Value) DataAccess.DataSourceLocation = Utility.toStr(dsDataCatalog.Tables[5].Rows[0]["DataSourceLocation"]);
//                if(dsDataCatalog.Tables[5].Rows[0]["AvailabilityDescription"] != DBNull.Value) DataAccess.AvailabilityDescription = Utility.toStr(dsDataCatalog.Tables[5].Rows[0]["AvailabilityDescription"]);
//                DataAccess.RefreshDate = Utility.toDT(dsDataCatalog.Tables[5].Rows[0]["RefreshDate"]);
//
//                PNWWQXDataCatalogList.DataAccess = DataAccess;
//                #endregion
//
//                #region ProjectSummary
//                DataRow[] projectList = drProvidingOrg.GetChildRows(dsDataCatalog.Relations["Org_Projects"]);
//                PNWWQXDataCatalogList.ProjectSummary = new ProjectSummaryType[projectList.Length];
//
//                for(int p = 0; p < projectList.Length; p++)
//                {
//
//                    DataRow drProject = projectList[p];
//
//                    ProjectSummaryType ProjectSummary = new ProjectSummaryType();
//                    ProjectSummary.ProjectIdentifier = Utility.toStr(drProject["ProjectIdentifier"]);
//                    ProjectSummary.ProjectName = Utility.toStr(drProject["ProjectName"]);
//                    ProjectSummary.ProjectStartDate = Utility.toDT(drProject["ProjectStartDate"]);
//                    if(drProject["ProjectEndDate"] != DBNull.Value) ProjectSummary.ProjectEndDate = Utility.toDT(drProject["ProjectEndDate"]);
//                    ProjectSummary.ProjectContactOrganizationName = Utility.toStr(drProject["ProjectContactOrganizationName"]);
//
//                    PNWWQXDataCatalogList.ProjectSummary[p] = ProjectSummary;
//                }
//
//                #endregion
//
//                #region StationSummary
//
//                DataRow[] stationSummryList = drProvidingOrg.GetChildRows(dsDataCatalog.Relations["Org_Station"]);
//                PNWWQXDataCatalogList.StationSummary = new StationSummaryType[stationSummryList.Length];
//
//                for(int s = 0; s < stationSummryList.Length; s++)
//                {
//
//                    DataRow drStation = stationSummryList[s];
//                    StationSummaryType StationSummary = new StationSummaryType();
//                    StationSummary.StationIdentifier = Utility.toStr(drStation["StationIdentifier"]);
//                    StationSummary.StationName = Utility.toStr(drStation["StationName"]);
//
//                    StationSummary.StationType = Utility.toStr(drStation["StationType"]);
//
//                    #region Location Description
//					
//                    DataRow[] locDescrList = drStation.GetChildRows(dsDataCatalog.Relations["Station_LocationDescriptor"]);
//                    StationSummary.LocationDescriptor = new StationLocationDescriptorType[locDescrList.Length];
//
//                    for(int d = 0; d < locDescrList.Length; d++)
//                    {
//                        DataRow drStationLocDescr = locDescrList[d];
//                        StationLocationDescriptorType StationLocationDescriptor = new StationLocationDescriptorType();
//                        StationLocationDescriptor.LocationDescriptorName = Utility.toStr(drStationLocDescr["LocationDescriptorName"]);
//                        StationLocationDescriptor.LocationDescriptorContext = Utility.toStr(drStationLocDescr["LocationDescriptorContext"]);
//                        StationSummary.LocationDescriptor[d] = StationLocationDescriptor;
//                    }
//
//                    #endregion
//
//                    StationSummary.LatitudeMeasure = Utility.toDecimal(drStation["LatitudeMeasure"]);
//                    StationSummary.LongitudeMeasure = Utility.toDecimal(drStation["LongitudeMeasure"]);
//                    if(drStation["StationContactOrganizationName"] != DBNull.Value) StationSummary.StationContactOrganizationName = Utility.toStr(drStation["StationContactOrganizationName"]);
//				
//                    PNWWQXDataCatalogList.StationSummary[s] = StationSummary;
//                }
//
//                #endregion
//
//                #region FieldEventSummary
//                ArrayList alFieldEventSummary = new ArrayList();
//
//                foreach(DataRow drFieldEvent in drProvidingOrg.GetChildRows(dsDataCatalog.Relations["Org_FieldEvent"]))
//                {
//                    FieldEventSummaryType FieldEventSummary = new FieldEventSummaryType();
//                    FieldEventSummary.MinFieldEventStartDate = Utility.toDT(drFieldEvent["MinFieldEventStartDate"]);
//                    FieldEventSummary.MaxFieldEventEndDate = Utility.toDT(drFieldEvent["MaxFieldEventEndDate"]);
//
//
//                    FieldEventSummary.MediaText = Utility.toStr(drFieldEvent["MediaText"]);
//
//                    if(drFieldEvent["BiologicalSystematicName"] != DBNull.Value) FieldEventSummary.BiologicalSystematicName = Utility.toStr(drFieldEvent["BiologicalSystematicName"]);
//                    FieldEventSummary.AnalyteName = Utility.toStr(drFieldEvent["AnalyteName"]);
//                    FieldEventSummary.NumberResults = Utility.toInt(drFieldEvent["NumberResults"]).ToString();
//                    FieldEventSummary.FieldEventProjectIdentifier = Utility.toStr(drFieldEvent["FieldEventProjectIdentifier"]);
//                    FieldEventSummary.FieldEventStationIdentifier = Utility.toStr(drFieldEvent["FieldEventStationIdentifier"]);
//                    if(drFieldEvent["FieldEventContactOrganizationName"] != DBNull.Value) FieldEventSummary.FieldEventContactOrganizationName = Utility.toStr(drFieldEvent["FieldEventContactOrganizationName"]);
//                    alFieldEventSummary.Add(FieldEventSummary);
//                }
//                PNWWQXDataCatalogList.FieldEventSummary = (FieldEventSummaryType[])alFieldEventSummary.ToArray(typeof(FieldEventSummaryType));
//                #endregion
//
//
//                PNWWQXDataCatalog.PNWWQXDataCatalogList[r] = PNWWQXDataCatalogList;
//
//
//            }
//
//            #endregion
//
//            return PNWWQXDataCatalog;
//       }
	}
}
