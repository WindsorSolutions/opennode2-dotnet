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
using System.Data;

namespace Windsor.Node2008.WNOSPlugin.PNWWQX
{
	/// <summary>
	/// Main
	/// </summary>
	public class PNWWQXProcessor
	{
        public static PNWWQXMeasurements GetMeasurements(
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
            DataSet ds = PNWWQXData.GetData
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
                Measurements.LoadMeasurementsValues(ref returnMeasurments, ref ds);

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
        public static PNWWQXProjects GetProjects
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
				DataSet ds = PNWWQXData.GetData
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
        public static PNWWQXStations GetStations
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
			DataSet ds = PNWWQXData.GetData
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


	}
}
