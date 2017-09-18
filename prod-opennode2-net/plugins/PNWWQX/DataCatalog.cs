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

﻿using System;
using System.Collections;
using System.Data;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;


//namespace PNWWQX_DataCatalog
namespace Windsor.Node2008.WNOSPlugin.PNWWQX
{

	/// <remarks/>
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:us:net:exchangenetwork")]
	[System.Xml.Serialization.XmlRootAttribute(Namespace="urn:us:net:exchangenetwork", IsNullable=false)]
	public class PNWWQXDataCatalog 
	{


		public static PNWWQXDataCatalog GetDataCatalog()
		{
			#region Get Data
			DataSet dsDataCatalog = SqlHelper.ExecuteDataset(
				Config.connectionString,
				CommandType.StoredProcedure,
				"PNWWQX_GetDataCatalog");
			#endregion

			#region Establish Relationships
			/* Tables[0] is Providing Organization  */
			/* Tables[1] is Projects */
			/* Tables[2] is Stations  */
			/* Tables[3] is Location Descriptor*/
			/* Tables[4] is Field Events*/
			/* Tables[5] is Data Access */
			
			//Providing Organization
			dsDataCatalog.Relations.Add("Org_Projects",dsDataCatalog.Tables[0].Columns["ProvidingOrganizationPK"],dsDataCatalog.Tables[1].Columns["ProvidingOrganizationFK"],false);
			dsDataCatalog.Relations.Add("Org_Station",dsDataCatalog.Tables[0].Columns["ProvidingOrganizationPK"],dsDataCatalog.Tables[2].Columns["ProvidingOrganizationFK"],false);
			dsDataCatalog.Relations.Add("Org_FieldEvent",dsDataCatalog.Tables[0].Columns["ProvidingOrganizationPK"],dsDataCatalog.Tables[4].Columns["ProvidingOrganizationFK"],false);

			//Station
			dsDataCatalog.Relations.Add("Station_LocationDescriptor",dsDataCatalog.Tables[2].Columns["StationIdentifier"],dsDataCatalog.Tables[3].Columns["StationSummaryIdentifier"],false);
			#endregion

			#region Populate Object

			ArrayList alPNWWQXDataCatalogList = new ArrayList();
			foreach(DataRow drProvidingOrg in dsDataCatalog.Tables[0].Rows)
			{
				#region ProvidingOrganizationDetails
				PNWWQXDataCatalogList PNWWQXDataCatalogList = new PNWWQXDataCatalogList();
				ProvidingOrganizationDetailsType ProvidingOrganizationDetails = new ProvidingOrganizationDetailsType();
				ProvidingOrganizationDetails.ProvidingOrganizationIdentifier = Utility.toStr(drProvidingOrg["ProvidingOrganizationIdentifier"]);
				ProvidingOrganizationDetails.ProvidingOrganizationName = Utility.toStr(drProvidingOrg["ProvidingOrganizationName"]);
				ProvidingOrganizationDetails.ProvidingOrganizationType = Utility.toStr(drProvidingOrg["ProvidingOrganizationType"]);

				ProvidingOrganizationDetails.ProvidingOrganizationContactName = Utility.toStr(drProvidingOrg["ProvidingOrganizationContactName"]);
				if (drProvidingOrg["MailingAddress"] != DBNull.Value ||
					drProvidingOrg["MailingAddressCityName"] != DBNull.Value ||
					drProvidingOrg["MailingAddressStateName"] != DBNull.Value ||
					drProvidingOrg["MailingAddressZIPCode"] != DBNull.Value)
				{
					ProvidingOrganizationDetails.ProvidingOrganizationMailingAddress = new MailingAddressType();
					if(drProvidingOrg["MailingAddress"] != DBNull.Value) ProvidingOrganizationDetails.ProvidingOrganizationMailingAddress.MailingAddress = Utility.toStr(drProvidingOrg["MailingAddress"]);
					if(drProvidingOrg["MailingAddressCityName"] != DBNull.Value) ProvidingOrganizationDetails.ProvidingOrganizationMailingAddress.MailingAddressCityName = Utility.toStr(drProvidingOrg["MailingAddressCityName"]);
					if(drProvidingOrg["MailingAddressStateName"] != DBNull.Value) ProvidingOrganizationDetails.ProvidingOrganizationMailingAddress.MailingAddressStateName = Utility.toStr(drProvidingOrg["MailingAddressStateName"]);
					if(drProvidingOrg["MailingAddressZIPCode"] != DBNull.Value) ProvidingOrganizationDetails.ProvidingOrganizationMailingAddress.MailingAddressZIPCode = Utility.toStr(drProvidingOrg["MailingAddressZIPCode"]);
				}
				ProvidingOrganizationDetails.ProvidingOrganizationPhoneEmail = new PhoneEmailType();
				ProvidingOrganizationDetails.ProvidingOrganizationPhoneEmail.TelephoneNumber = Utility.toStr(drProvidingOrg["TelephoneNumber"]);
				if(drProvidingOrg["ElectronicMailAddressText"] != DBNull.Value) ProvidingOrganizationDetails.ProvidingOrganizationPhoneEmail.ElectronicMailAddressText = Utility.toStr(drProvidingOrg["ElectronicMailAddressText"]);
				if(drProvidingOrg["ProvidingOrganizationURL"] != DBNull.Value) ProvidingOrganizationDetails.ProvidingOrganizationURL = Utility.toStr(drProvidingOrg["ProvidingOrganizationURL"]);

				PNWWQXDataCatalogList.ProvidingOrganizationDetails = ProvidingOrganizationDetails;
				#endregion

				#region DataAccess
				DataAccessType DataAccess = new DataAccessType();
				DataAccess.DataSourceName = Utility.toStr(dsDataCatalog.Tables[5].Rows[0]["DataSourceName"]);

				DataAccess.DataSourceAccessMethod = Utility.toStr(dsDataCatalog.Tables[5].Rows[0]["DataSourceAccessMethod"]);
				
				if(dsDataCatalog.Tables[5].Rows[0]["DataSourceLocation"] != DBNull.Value) DataAccess.DataSourceLocation = Utility.toStr(dsDataCatalog.Tables[5].Rows[0]["DataSourceLocation"]);
				if(dsDataCatalog.Tables[5].Rows[0]["AvailabilityDescription"] != DBNull.Value) DataAccess.AvailabilityDescription = Utility.toStr(dsDataCatalog.Tables[5].Rows[0]["AvailabilityDescription"]);
				DataAccess.RefreshDate = Utility.toDT(dsDataCatalog.Tables[5].Rows[0]["RefreshDate"]);

				PNWWQXDataCatalogList.DataAccess = DataAccess;
				#endregion

				#region ProjectSummary
				ArrayList alProjectSummary = new ArrayList();

				foreach(DataRow drProject in drProvidingOrg.GetChildRows(dsDataCatalog.Relations["Org_Projects"]))
				{
					ProjectSummaryType ProjectSummary = new ProjectSummaryType();
					ProjectSummary.ProjectIdentifier = Utility.toStr(drProject["ProjectIdentifier"]);
					ProjectSummary.ProjectName = Utility.toStr(drProject["ProjectName"]);
					ProjectSummary.ProjectStartDate = Utility.toDT(drProject["ProjectStartDate"]);
					if(drProject["ProjectEndDate"] != DBNull.Value) ProjectSummary.ProjectEndDate = Utility.toDT(drProject["ProjectEndDate"]);
					ProjectSummary.ProjectContactOrganizationName = Utility.toStr(drProject["ProjectContactOrganizationName"]);

					alProjectSummary.Add(ProjectSummary);
				}
				PNWWQXDataCatalogList.ProjectSummary = (ProjectSummaryType[])alProjectSummary.ToArray(typeof(ProjectSummaryType));
				#endregion

				#region StationSummary
				ArrayList alStationSummary = new ArrayList();
				
				DataRow[] stationRootRows = drProvidingOrg.GetChildRows(dsDataCatalog.Relations["Org_Station"]);

				foreach(DataRow drStation in stationRootRows)
				{
					StationSummaryType StationSummary = new StationSummaryType();
					StationSummary.StationIdentifier = Utility.toStr(drStation["StationIdentifier"]);
					StationSummary.StationName = Utility.toStr(drStation["StationName"]);

					StationSummary.StationType = Utility.toStr(drStation["StationType"]);

					ArrayList alStationLocationDescriptor = new ArrayList();





					#region Location Description

					DataRow[] stationRows = drStation.GetChildRows(dsDataCatalog.Relations["Station_LocationDescriptor"]);

					System.Console.WriteLine(stationRows.Length);
					
					foreach(DataRow drStationLocDescr in stationRows)
					{
						StationLocationDescriptorType StationLocationDescriptor = new StationLocationDescriptorType();
						StationLocationDescriptor.LocationDescriptorName = Utility.toStr(drStationLocDescr["LocationDescriptorName"]);

						StationLocationDescriptor.LocationDescriptorContext = Utility.toStr(drStationLocDescr["LocationDescriptorContext"]);

						alStationLocationDescriptor.Add(StationLocationDescriptor);
					}
					
					#endregion

					StationSummary.LocationDescriptor = (StationLocationDescriptorType[])alStationLocationDescriptor.ToArray(typeof(StationLocationDescriptorType));




					StationSummary.LatitudeMeasure = Utility.toDecimal(drStation["LatitudeMeasure"]);
					StationSummary.LongitudeMeasure = Utility.toDecimal(drStation["LongitudeMeasure"]);
					if(drStation["StationContactOrganizationName"] != DBNull.Value) StationSummary.StationContactOrganizationName = Utility.toStr(drStation["StationContactOrganizationName"]);
				
					alStationSummary.Add(StationSummary);
				}
				PNWWQXDataCatalogList.StationSummary = (StationSummaryType[])alStationSummary.ToArray(typeof(StationSummaryType));
				#endregion

				#region FieldEventSummary
				ArrayList alFieldEventSummary = new ArrayList();

				foreach(DataRow drFieldEvent in drProvidingOrg.GetChildRows(dsDataCatalog.Relations["Org_FieldEvent"]))
				{
					FieldEventSummaryType FieldEventSummary = new FieldEventSummaryType();
					FieldEventSummary.MinFieldEventStartDate = Utility.toDT(drFieldEvent["MinFieldEventStartDate"]);
					FieldEventSummary.MaxFieldEventEndDate = Utility.toDT(drFieldEvent["MaxFieldEventEndDate"]);
					FieldEventSummary.MediaText = Utility.toStr(drFieldEvent["MediaText"]);
					

					if(drFieldEvent["BiologicalSystematicName"] != DBNull.Value) FieldEventSummary.BiologicalSystematicName = Utility.toStr(drFieldEvent["BiologicalSystematicName"]);
					FieldEventSummary.AnalyteName = Utility.toStr(drFieldEvent["AnalyteName"]);
					FieldEventSummary.NumberResults = Utility.toInt(drFieldEvent["NumberResults"]).ToString();
					FieldEventSummary.FieldEventProjectIdentifier = Utility.toStr(drFieldEvent["FieldEventProjectIdentifier"]);
					FieldEventSummary.FieldEventStationIdentifier = Utility.toStr(drFieldEvent["FieldEventStationIdentifier"]);
					if(drFieldEvent["FieldEventContactOrganizationName"] != DBNull.Value) FieldEventSummary.FieldEventContactOrganizationName = Utility.toStr(drFieldEvent["FieldEventContactOrganizationName"]);
					alFieldEventSummary.Add(FieldEventSummary);
				}
				PNWWQXDataCatalogList.FieldEventSummary = (FieldEventSummaryType[])alFieldEventSummary.ToArray(typeof(FieldEventSummaryType));
				#endregion

				#region PNWWQXDataCatalogList
				alPNWWQXDataCatalogList.Add(PNWWQXDataCatalogList);
				#endregion
			}

			PNWWQXDataCatalog PNWWQXDataCatalog = new PNWWQXDataCatalog();
			PNWWQXDataCatalog.PNWWQXDataCatalogList = (PNWWQXDataCatalogList[])alPNWWQXDataCatalogList.ToArray(typeof(PNWWQXDataCatalogList));
			#endregion

			return PNWWQXDataCatalog;
		}



		public PNWWQXDataCatalog()
		{
			XmlDocument d = new XmlDocument();
			XmlAttribute xsi = d.CreateAttribute("xsi", "noNamespaceSchemaLocation", XmlSchema.InstanceNamespace);
			xsi.Value = "http://www.exchangenetwork.net/Registry/PNWWQX_DataCatalog_v.1.3.xsd";
			this.XAttributes = new XmlAttribute[] {xsi};
		}

		[XmlAnyAttribute]
		public XmlAttribute[] XAttributes;
    
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("PNWWQXDataCatalogList")]
		public PNWWQXDataCatalogList[] PNWWQXDataCatalogList;
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:us:net:exchangenetwork")]
	[System.Xml.Serialization.XmlRootAttribute(Namespace="urn:us:net:exchangenetwork", IsNullable=false)]
	public class PNWWQXDataCatalogList 
	{
    
		/// <remarks/>
		public ProvidingOrganizationDetailsType ProvidingOrganizationDetails;
    
		/// <remarks/>
		public DataAccessType DataAccess;
    
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("ProjectSummary")]
		public ProjectSummaryType[] ProjectSummary;
    
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("StationSummary")]
		public StationSummaryType[] StationSummary;
    
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("FieldEventSummary")]
		public FieldEventSummaryType[] FieldEventSummary;
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:us:net:exchangenetwork")]
	[System.Xml.Serialization.XmlRootAttribute("FieldEventSummary", Namespace="urn:us:net:exchangenetwork", IsNullable=false)]
	public class FieldEventSummaryType 
	{
    
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(DataType="date")]
		public System.DateTime MinFieldEventStartDate;
    
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(DataType="date")]
		public System.DateTime MaxFieldEventEndDate;
    
		/// <remarks/>
		public string MediaText;
    
		/// <remarks/>
		public string BiologicalSystematicName;
    
		/// <remarks/>
		public string AnalyteName;
    
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(DataType="nonNegativeInteger")]
		public string NumberResults;
    
		/// <remarks/>
		public string FieldEventProjectIdentifier;
    
		/// <remarks/>
		public string FieldEventStationIdentifier;
    
		/// <remarks/>
		public string FieldEventContactOrganizationName;
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:us:net:exchangenetwork")]
	[System.Xml.Serialization.XmlRootAttribute("LocationDescriptor", Namespace="urn:us:net:exchangenetwork", IsNullable=false)]
	public class StationLocationDescriptorType 
	{
    
		/// <remarks/>
		public string LocationDescriptorName;
    
		/// <remarks/>
		public string LocationDescriptorContext;
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:us:net:exchangenetwork")]
	[System.Xml.Serialization.XmlRootAttribute("StationSummary", Namespace="urn:us:net:exchangenetwork", IsNullable=false)]
	public class StationSummaryType 
	{
    
		/// <remarks/>
		public string StationIdentifier;
    
		/// <remarks/>
		public string StationName;
    
		/// <remarks/>
		public string StationType;
    
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("LocationDescriptor")]
		public StationLocationDescriptorType[] LocationDescriptor;
    
		/// <remarks/>
		public System.Decimal LatitudeMeasure;
    
		/// <remarks/>
		public System.Decimal LongitudeMeasure;
    
		/// <remarks/>
		public string StationContactOrganizationName;
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:us:net:exchangenetwork")]
	[System.Xml.Serialization.XmlRootAttribute("ProjectSummary", Namespace="urn:us:net:exchangenetwork", IsNullable=false)]
	public class ProjectSummaryType 
	{
    
		/// <remarks/>
		public string ProjectIdentifier;
    
		/// <remarks/>
		public string ProjectName;
    
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(DataType="date")]
		public System.DateTime ProjectStartDate;
    
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(DataType="date")]
		public System.DateTime ProjectEndDate;
    
		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool ProjectEndDateSpecified;
    
		/// <remarks/>
		public string ProjectContactOrganizationName;
	}

	/// <remarks/>
	[System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:us:net:exchangenetwork")]
	[System.Xml.Serialization.XmlRootAttribute("DataAccess", Namespace="urn:us:net:exchangenetwork", IsNullable=false)]
	public class DataAccessType 
	{
    
		/// <remarks/>
		public string DataSourceName;
    
		/// <remarks/>
		public string DataSourceAccessMethod;
    
		/// <remarks/>
		public string DataSourceLocation;
    
		/// <remarks/>
		public string AvailabilityDescription;
    
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(DataType="date")]
		public System.DateTime RefreshDate;
	}

}