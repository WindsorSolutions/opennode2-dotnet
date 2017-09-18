using System;
using System.IO;
using System.Xml;
using System.Data;
using System.Collections;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using Common.Logging;

namespace Windsor.Node2008.WNOSPlugin.TRI4
{

    public class TriDocument
    {
        [System.Xml.Serialization.XmlElementAttribute("Payload", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public TriPayload[] Payload;
    }

    public class TriPayload
    {
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public XmlElement Any;
    }

	public class DBKeys 
	{

		public DBKeys(){}


		public virtual bool IsClean()
		{
			return true;
		}

		[System.Xml.Serialization.XmlIgnore()]
		public string PK;

		[System.Xml.Serialization.XmlIgnore()]
		public string FK;

	}

	[System.Xml.Serialization.XmlRootAttribute("TRI", IsNullable=false)]
	public class TRIDataType : DBKeys
	{

        private static readonly ILog LOG = LogManager.GetLogger(typeof(TRIDataType));
    
		private SubmissionDataType[] submissionField;
		private string transactionID;

    
    
		[System.Xml.Serialization.XmlElementAttribute("Submission")]
		public SubmissionDataType[] Submission 
		{
			get 
			{
				return this.submissionField;
			}
			set 
			{
				this.submissionField = value;
			}
		}

		[System.Xml.Serialization.XmlIgnore]
		public string TransactionID 
		{
			get 
			{
				return this.transactionID;
			}
			set 
			{
				this.transactionID = value;
			}
		}



		private static void UnknownAttribute(object sender, XmlAttributeEventArgs e)
		{
            LOG.Info("Unknown Attribute");
            if (e != null && e.Attr != null)
            {
                LOG.Info("\t" + e.Attr.Name + " " + e.Attr.InnerXml);
            }
		}

		private static void UnknownElement(object sender, XmlElementEventArgs e)
		{
            LOG.Info("Unknown Element");
            if (e != null)
            {
                if (e.Element != null)
                {
                    LOG.Info("\t" + e.Element.Name);
                }
                LOG.Info("\t" + e.ObjectBeingDeserialized);
            }
		}

		private static void UnknownNode(object sender, XmlNodeEventArgs e)
		{
			LOG.Info("Unknown Node");
            if (e != null)
            {
                LOG.Info("\t" + e.Name);
                LOG.Info("\t" + e.NodeType);
                LOG.Info("\t" + e.LineNumber + ":" + e.LinePosition);
                LOG.Info("\t" + e.Text);
            }
		}

		private static void UnreferencedObject(object sender, UnreferencedObjectEventArgs e)
		{
			LOG.Info("Unreferenced Object");
            if (e != null)
            {
                LOG.Info("\t" + e.UnreferencedId + "\t");
                LOG.Info(e.UnreferencedObject);
            }
		}


        private static T Deserialize<T>(string file)
        {
            using (XmlReader reader = XmlReader.Create(file))
            {
                XmlSerializer xmlSer = new XmlSerializer(typeof(T));

                xmlSer.UnknownAttribute += new XmlAttributeEventHandler(UnknownAttribute);
                xmlSer.UnknownElement += new XmlElementEventHandler(UnknownElement);
                xmlSer.UnknownNode += new XmlNodeEventHandler(UnknownNode);
                xmlSer.UnreferencedObject += new UnreferencedObjectEventHandler(UnreferencedObject);

                return (T)xmlSer.Deserialize(reader);
            }
            
        }

		public static TRIDataType Deserialize(string file)
		{
            try
            {
                LOG.Info("Parsing TRIDataType from: " + file);
                return Deserialize<TRIDataType>(file);
            }
            catch (Exception ex)
            {

                try
                {

                    LOG.Error("Error while deserializing TRIDataType: " + ex.Message);

                    LOG.Info("Parsing Document from: " + file);
                    TriDocument hd = Deserialize<TriDocument>(file);
                    LOG.Info("Result: " + hd);

                    if (hd != null && hd.Payload != null && hd.Payload.Length > 0)
                    {

                        LOG.Info("Document has payloads");

                        foreach (TriPayload pld in hd.Payload)
                        {

                            LOG.Info("Testing for TRI content...");

                            if (pld.Any != null && pld.Any.OuterXml.StartsWith("<TRI>"))
                            {
                                LOG.Info("TRI Content Found");

                                LOG.Info("Writting payload content to file: " + file);
                                File.WriteAllText(file, pld.Any.OuterXml);

                                LOG.Info("2nd Chance - Parsing TRIDataType from: " + file);
                                return Deserialize<TRIDataType>(file);
                            }
                            else
                            {
                                LOG.Info("Content not TRI");
                            }
                        }

                    }

                }
                catch (Exception ex2)
                {
                    LOG.Error(ex.Message, ex);
                    LOG.Error(ex2.Message, ex2);
                }

                throw ex;
            }
		}
	}





	[System.Xml.Serialization.XmlRootAttribute("MailingAddress", IsNullable=false)]
	public class MailingAddressDataType : DBKeys
	{
    
		private string mailingAddressTextField;
    
		private string supplementalAddressTextField;
    
		private string mailingAddressCityNameField;
    
		private StateIdentityDataType stateIdentityField = new StateIdentityDataType();
    
		private AddressPostalCodeDataType addressPostalCodeField = new AddressPostalCodeDataType();
    
		private CountryIdentityDataType countryIdentityField = new CountryIdentityDataType();
		
		private string provinceNameTextField;
    
    
		public string ProvinceNameText 
		{
			get 
			{
				return this.provinceNameTextField;
			}
			set 
			{
				this.provinceNameTextField = value;
			}
		}
    

		public string MailingAddressText 
		{
			get 
			{
				return this.mailingAddressTextField;
			}
			set 
			{
				this.mailingAddressTextField = value;
			}
		}
    
    
		public string SupplementalAddressText 
		{
			get 
			{
				return this.supplementalAddressTextField;
			}
			set 
			{
				this.supplementalAddressTextField = value;
			}
		}
    
    
		public string MailingAddressCityName 
		{
			get 
			{
				return this.mailingAddressCityNameField;
			}
			set 
			{
				this.mailingAddressCityNameField = value;
			}
		}
    
    
		public StateIdentityDataType StateIdentity 
		{
			get 
			{
				return this.stateIdentityField;
			}
			set 
			{
				this.stateIdentityField = value;
			}
		}
    
    
		public AddressPostalCodeDataType AddressPostalCode 
		{
			get 
			{
				return this.addressPostalCodeField;
			}
			set 
			{
				this.addressPostalCodeField = value;
			}
		}
    
    
		public CountryIdentityDataType CountryIdentity 
		{
			get 
			{
				return this.countryIdentityField;
			}
			set 
			{
				this.countryIdentityField = value;
			}
		}
	}






	
	[System.Xml.Serialization.XmlRootAttribute("StateIdentity", IsNullable=false)]
	public class StateIdentityDataType : DBKeys
	{
    
		private string stateCodeField;
    
		private StateCodeListIdentifierDataType stateCodeListIdentifierField = new StateCodeListIdentifierDataType();
    
		private string stateNameField;
    
    
		public string StateCode 
		{
			get 
			{
				return this.stateCodeField;
			}
			set 
			{
				this.stateCodeField = value;
			}
		}
    
    
		public StateCodeListIdentifierDataType StateCodeListIdentifier 
		{
			get 
			{
				return this.stateCodeListIdentifierField;
			}
			set 
			{
				this.stateCodeListIdentifierField = value;
			}
		}
    
    
		public string StateName 
		{
			get 
			{
				return this.stateNameField;
			}
			set 
			{
				this.stateNameField = value;
			}
		}
	}






	
	[System.Xml.Serialization.XmlRootAttribute("StateCodeListIdentifier", IsNullable=false)]
	public class StateCodeListIdentifierDataType : DBKeys
	{
    
		private string codeListVersionIdentifierField;
    
		private string codeListVersionAgencyIdentifierField;
    
		private string valueField;
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string CodeListVersionIdentifier 
		{
			get 
			{
				return this.codeListVersionIdentifierField;
			}
			set 
			{
				this.codeListVersionIdentifierField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string CodeListVersionAgencyIdentifier 
		{
			get 
			{
				return this.codeListVersionAgencyIdentifierField;
			}
			set 
			{
				this.codeListVersionAgencyIdentifierField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value 
		{
			get 
			{
				return this.valueField;
			}
			set 
			{
				this.valueField = value;
			}
		}
	}






	
	[System.Xml.Serialization.XmlRootAttribute("IndividualIdentifier", IsNullable=false)]
	public class IndividualIdentifierDataType : DBKeys
	{
    
		private string individualIdentifierContextField;
    
		private string valueField;
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string IndividualIdentifierContext 
		{
			get 
			{
				return this.individualIdentifierContextField;
			}
			set 
			{
				this.individualIdentifierContextField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value 
		{
			get 
			{
				return this.valueField;
			}
			set 
			{
				this.valueField = value;
			}
		}
	}






	
	[System.Xml.Serialization.XmlRootAttribute("ReportIdentifier", IsNullable=false)]
	public class ReportIdentifierDataType : DBKeys
	{
    
		private string reportIdentifierContextField;
    
		private string valueField;
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string ReportIdentifierContext 
		{
			get 
			{
				return this.reportIdentifierContextField;
			}
			set 
			{
				this.reportIdentifierContextField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value 
		{
			get 
			{
				return this.valueField;
			}
			set 
			{
				this.valueField = value;
			}
		}
	}






	
	[System.Xml.Serialization.XmlRootAttribute("ReportTypeCodeListIdentifier", IsNullable=false)]
	public class ReportTypeCodeListIdentifierDataType : DBKeys
	{
    
		private string codeListVersionIdentifierField;
    
		private string codeListVersionAgencyIdentifierField;
    
		private string valueField;
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string CodeListVersionIdentifier 
		{
			get 
			{
				return this.codeListVersionIdentifierField;
			}
			set 
			{
				this.codeListVersionIdentifierField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string CodeListVersionAgencyIdentifier 
		{
			get 
			{
				return this.codeListVersionAgencyIdentifierField;
			}
			set 
			{
				this.codeListVersionAgencyIdentifierField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value 
		{
			get 
			{
				return this.valueField;
			}
			set 
			{
				this.valueField = value;
			}
		}
	}






	
	[System.Xml.Serialization.XmlRootAttribute("TribalCodeListIdentifier", IsNullable=false)]
	public class TribalCodeListIdentifierDataType : DBKeys
	{
    
		private string codeListVersionIdentifierField;
    
		private string codeListVersionAgencyIdentifierField;
    
		private string valueField;
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string CodeListVersionIdentifier 
		{
			get 
			{
				return this.codeListVersionIdentifierField;
			}
			set 
			{
				this.codeListVersionIdentifierField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string CodeListVersionAgencyIdentifier 
		{
			get 
			{
				return this.codeListVersionAgencyIdentifierField;
			}
			set 
			{
				this.codeListVersionAgencyIdentifierField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value 
		{
			get 
			{
				return this.valueField;
			}
			set 
			{
				this.valueField = value;
			}
		}
	}






	
	[System.Xml.Serialization.XmlRootAttribute("TribalIdentity", IsNullable=false)]
	public class TribalIdentityCodeDataType : DBKeys
	{
    
		private string tribalCodeField;
    
		private TribalCodeListIdentifierDataType tribalCodeListIdentifierField = new TribalCodeListIdentifierDataType();
    
		private string tribalNameField;
    
    
		public string TribalCode 
		{
			get 
			{
				return this.tribalCodeField;
			}
			set 
			{
				this.tribalCodeField = value;
			}
		}
    
    
		public TribalCodeListIdentifierDataType TribalCodeListIdentifier 
		{
			get 
			{
				return this.tribalCodeListIdentifierField;
			}
			set 
			{
				this.tribalCodeListIdentifierField = value;
			}
		}
    
    
		public string TribalName 
		{
			get 
			{
				return this.tribalNameField;
			}
			set 
			{
				this.tribalNameField = value;
			}
		}
	}






	
	[System.Xml.Serialization.XmlRootAttribute("CountyCodeListIdentifier", IsNullable=false)]
	public class CountyCodeListIdentifierDataType : DBKeys
	{
    
		private string codeListVersionIdentifierField;
    
		private string codeListVersionAgencyIdentifierField;
    
		private string valueField;
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string CodeListVersionIdentifier 
		{
			get 
			{
				return this.codeListVersionIdentifierField;
			}
			set 
			{
				this.codeListVersionIdentifierField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string CodeListVersionAgencyIdentifier 
		{
			get 
			{
				return this.codeListVersionAgencyIdentifierField;
			}
			set 
			{
				this.codeListVersionAgencyIdentifierField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value 
		{
			get 
			{
				return this.valueField;
			}
			set 
			{
				this.valueField = value;
			}
		}
	}






	
	[System.Xml.Serialization.XmlRootAttribute("CountyIdentity", IsNullable=false)]
	public class CountyIdentityDataType : DBKeys
	{
    
		private string countyCodeField;
    
		private CountyCodeListIdentifierDataType countyCodeListIdentifierField = new CountyCodeListIdentifierDataType();
    
		private string countyNameField;
    
    
		public string CountyCode 
		{
			get 
			{
				return this.countyCodeField;
			}
			set 
			{
				this.countyCodeField = value;
			}
		}
    
    
		public CountyCodeListIdentifierDataType CountyCodeListIdentifier 
		{
			get 
			{
				return this.countyCodeListIdentifierField;
			}
			set 
			{
				this.countyCodeListIdentifierField = value;
			}
		}
    
    
		public string CountyName 
		{
			get 
			{
				return this.countyNameField;
			}
			set 
			{
				this.countyNameField = value;
			}
		}
	}






	
	[System.Xml.Serialization.XmlRootAttribute("LocationAddress", IsNullable=false)]
	public class LocationAddressDataType : DBKeys
	{
    
		private string locationAddressTextField;
    
		private string supplementalLocationTextField;
    
		private string localityNameField;
    
		private StateIdentityDataType stateIdentityField = new StateIdentityDataType();
    
		private AddressPostalCodeDataType addressPostalCodeField = new AddressPostalCodeDataType();
    
		private CountryIdentityDataType countryIdentityField = new CountryIdentityDataType();
    
		private CountyIdentityDataType countyIdentityField = new CountyIdentityDataType();
    
		private TribalIdentityCodeDataType tribalIdentityField = new TribalIdentityCodeDataType();
    
		private string tribalLandNameField;
    
		private string tribalLandIndicatorField;
    
		private bool tribalLandIndicatorFieldSpecified;
    
		private string locationDescriptionTextField;
    
    
		public string LocationAddressText 
		{
			get 
			{
				return this.locationAddressTextField;
			}
			set 
			{
				this.locationAddressTextField = value;
			}
		}
    
    
		public string SupplementalLocationText 
		{
			get 
			{
				return this.supplementalLocationTextField;
			}
			set 
			{
				this.supplementalLocationTextField = value;
			}
		}
    
    
		public string LocalityName 
		{
			get 
			{
				return this.localityNameField;
			}
			set 
			{
				this.localityNameField = value;
			}
		}
    
    
		public StateIdentityDataType StateIdentity 
		{
			get 
			{
				return this.stateIdentityField;
			}
			set 
			{
				this.stateIdentityField = value;
			}
		}
    
    
		public AddressPostalCodeDataType AddressPostalCode 
		{
			get 
			{
				return this.addressPostalCodeField;
			}
			set 
			{
				this.addressPostalCodeField = value;
			}
		}
    
    
		public CountryIdentityDataType CountryIdentity 
		{
			get 
			{
				return this.countryIdentityField;
			}
			set 
			{
				this.countryIdentityField = value;
			}
		}
    
    
		public CountyIdentityDataType CountyIdentity 
		{
			get 
			{
				return this.countyIdentityField;
			}
			set 
			{
				this.countyIdentityField = value;
			}
		}
    
    
		public TribalIdentityCodeDataType TribalIdentity 
		{
			get 
			{
				return this.tribalIdentityField;
			}
			set 
			{
				this.tribalIdentityField = value;
			}
		}
    
    
		public string TribalLandName 
		{
			get 
			{
				return this.tribalLandNameField;
			}
			set 
			{
				this.tribalLandNameField = value;
			}
		}
    
    
		public string TribalLandIndicator 
		{
			get 
			{
				return this.tribalLandIndicatorField;
			}
			set 
			{
				this.tribalLandIndicatorField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool TribalLandIndicatorSpecified 
		{
			get 
			{
				return this.tribalLandIndicatorFieldSpecified;
			}
			set 
			{
				this.tribalLandIndicatorFieldSpecified = value;
			}
		}
    
    
		public string LocationDescriptionText 
		{
			get 
			{
				return this.locationDescriptionTextField;
			}
			set 
			{
				this.locationDescriptionTextField = value;
			}
		}
	}






	
	[System.Xml.Serialization.XmlRootAttribute("AddressPostalCode", IsNullable=false)]
	public class AddressPostalCodeDataType : DBKeys
	{
    
		private string addressPostalCodeContextField;
    
		private string valueField;
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string AddressPostalCodeContext 
		{
			get 
			{
				return this.addressPostalCodeContextField;
			}
			set 
			{
				this.addressPostalCodeContextField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value 
		{
			get 
			{
				return this.valueField;
			}
			set 
			{
				this.valueField = value;
			}
		}
	}






	
	[System.Xml.Serialization.XmlRootAttribute("CountryIdentity", IsNullable=false)]
	public class CountryIdentityDataType : DBKeys
	{
    
		private string countryCodeField;
    
		private CountryCodeListIdentifierDataType countryCodeListIdentifierField = new CountryCodeListIdentifierDataType();
    
		private string countryNameField;
    
    
		public string CountryCode 
		{
			get 
			{
				return this.countryCodeField;
			}
			set 
			{
				this.countryCodeField = value;
			}
		}
    
    
		public CountryCodeListIdentifierDataType CountryCodeListIdentifier 
		{
			get 
			{
				return this.countryCodeListIdentifierField;
			}
			set 
			{
				this.countryCodeListIdentifierField = value;
			}
		}
    
    
		public string CountryName 
		{
			get 
			{
				return this.countryNameField;
			}
			set 
			{
				this.countryNameField = value;
			}
		}
	}






	
	[System.Xml.Serialization.XmlRootAttribute("CountryCodeListIdentifier", IsNullable=false)]
	public class CountryCodeListIdentifierDataType : DBKeys
	{
    
		private string codeListVersionIdentifierField;
    
		private string codeListVersionAgencyIdentifierField;
    
		private string valueField;
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string CodeListVersionIdentifier 
		{
			get 
			{
				return this.codeListVersionIdentifierField;
			}
			set 
			{
				this.codeListVersionIdentifierField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string CodeListVersionAgencyIdentifier 
		{
			get 
			{
				return this.codeListVersionAgencyIdentifierField;
			}
			set 
			{
				this.codeListVersionAgencyIdentifierField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value 
		{
			get 
			{
				return this.valueField;
			}
			set 
			{
				this.valueField = value;
			}
		}
	}




	
	[System.Xml.Serialization.XmlRootAttribute("GeometricTypeCodeListIdentifier", IsNullable=false)]
	public class GeometricTypeCodeListIdentifierDataType : DBKeys
	{
    
		private string codeListVersionIdentifierField;
    
		private string codeListVersionAgencyIdentifierField;
    
		private string valueField;
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string CodeListVersionIdentifier 
		{
			get 
			{
				return this.codeListVersionIdentifierField;
			}
			set 
			{
				this.codeListVersionIdentifierField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string CodeListVersionAgencyIdentifier 
		{
			get 
			{
				return this.codeListVersionAgencyIdentifierField;
			}
			set 
			{
				this.codeListVersionAgencyIdentifierField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value 
		{
			get 
			{
				return this.valueField;
			}
			set 
			{
				this.valueField = value;
			}
		}
	}






	
	[System.Xml.Serialization.XmlRootAttribute("GeometricType", IsNullable=false)]
	public class GeometricTypeDataType : DBKeys
	{
    
		private string geometricTypeCodeField;
    
		private GeometricTypeCodeListIdentifierDataType geometricTypeCodeListIdentifierField = new GeometricTypeCodeListIdentifierDataType();
    
		private string geometricTypeNameField;
    
    
		public string GeometricTypeCode 
		{
			get 
			{
				return this.geometricTypeCodeField;
			}
			set 
			{
				this.geometricTypeCodeField = value;
			}
		}
    
    
		public GeometricTypeCodeListIdentifierDataType GeometricTypeCodeListIdentifier 
		{
			get 
			{
				return this.geometricTypeCodeListIdentifierField;
			}
			set 
			{
				this.geometricTypeCodeListIdentifierField = value;
			}
		}
    
    
		public string GeometricTypeName 
		{
			get 
			{
				return this.geometricTypeNameField;
			}
			set 
			{
				this.geometricTypeNameField = value;
			}
		}
	}






	
	[System.Xml.Serialization.XmlRootAttribute("CoordinateDataSourceCodeListIdentifier", IsNullable=false)]
	public class CoordinateDataSourceCodeListIdentifierDataType : DBKeys
	{
    
		private string codeListVersionIdentifierField;
    
		private string codeListVersionAgencyIdentifierField;
    
		private string valueField;
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string CodeListVersionIdentifier 
		{
			get 
			{
				return this.codeListVersionIdentifierField;
			}
			set 
			{
				this.codeListVersionIdentifierField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string CodeListVersionAgencyIdentifier 
		{
			get 
			{
				return this.codeListVersionAgencyIdentifierField;
			}
			set 
			{
				this.codeListVersionAgencyIdentifierField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value 
		{
			get 
			{
				return this.valueField;
			}
			set 
			{
				this.valueField = value;
			}
		}
	}






	
	[System.Xml.Serialization.XmlRootAttribute("CoordinateDataSource", IsNullable=false)]
	public class CoordinateDataSourceDataType : DBKeys
	{
    
		private string coordinateDataSourceCodeField;
    
		private CoordinateDataSourceCodeListIdentifierDataType coordinateDataSourceCodeListIdentifierField;
    
		private string coordinateDataSourceNameField;
    
    
		public string CoordinateDataSourceCode 
		{
			get 
			{
				return this.coordinateDataSourceCodeField;
			}
			set 
			{
				this.coordinateDataSourceCodeField = value;
			}
		}
    
    
		public CoordinateDataSourceCodeListIdentifierDataType CoordinateDataSourceCodeListIdentifier 
		{
			get 
			{
				return this.coordinateDataSourceCodeListIdentifierField;
			}
			set 
			{
				this.coordinateDataSourceCodeListIdentifierField = value;
			}
		}
    
    
		public string CoordinateDataSourceName 
		{
			get 
			{
				return this.coordinateDataSourceNameField;
			}
			set 
			{
				this.coordinateDataSourceNameField = value;
			}
		}
	}






	
	[System.Xml.Serialization.XmlRootAttribute("GeographicReferenceDatumCodeListIdentifier", IsNullable=false)]
	public class GeographicReferenceDatumCodeListIdentifierDataType : DBKeys
	{
    
		private string codeListVersionIdentifierField;
    
		private string codeListVersionAgencyIdentifierField;
    
		private string valueField;
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string CodeListVersionIdentifier 
		{
			get 
			{
				return this.codeListVersionIdentifierField;
			}
			set 
			{
				this.codeListVersionIdentifierField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string CodeListVersionAgencyIdentifier 
		{
			get 
			{
				return this.codeListVersionAgencyIdentifierField;
			}
			set 
			{
				this.codeListVersionAgencyIdentifierField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value 
		{
			get 
			{
				return this.valueField;
			}
			set 
			{
				this.valueField = value;
			}
		}
	}






	
	[System.Xml.Serialization.XmlRootAttribute("GeographicReferenceDatum", IsNullable=false)]
	public class GeographicReferenceDatumDataType : DBKeys
	{
    
		private string geographicReferenceDatumCodeField;
    
		private GeographicReferenceDatumCodeListIdentifierDataType geographicReferenceDatumCodeListIdentifierField = 
			new GeographicReferenceDatumCodeListIdentifierDataType();
    
		private string geographicReferenceDatumNameField;
    
    
		public string GeographicReferenceDatumCode 
		{
			get 
			{
				return this.geographicReferenceDatumCodeField;
			}
			set 
			{
				this.geographicReferenceDatumCodeField = value;
			}
		}
    
    
		public GeographicReferenceDatumCodeListIdentifierDataType GeographicReferenceDatumCodeListIdentifier 
		{
			get 
			{
				return this.geographicReferenceDatumCodeListIdentifierField;
			}
			set 
			{
				this.geographicReferenceDatumCodeListIdentifierField = value;
			}
		}
    
    
		public string GeographicReferenceDatumName 
		{
			get 
			{
				return this.geographicReferenceDatumNameField;
			}
			set 
			{
				this.geographicReferenceDatumNameField = value;
			}
		}
	}






	
	[System.Xml.Serialization.XmlRootAttribute("ReferencePointCodeListIdentifier", IsNullable=false)]
	public class ReferencePointCodeListIdentifierDataType : DBKeys
	{
    
		private string codeListVersionIdentifierField;
    
		private string codeListVersionAgencyIdentifierField;
    
		private string valueField;
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string CodeListVersionIdentifier 
		{
			get 
			{
				return this.codeListVersionIdentifierField;
			}
			set 
			{
				this.codeListVersionIdentifierField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string CodeListVersionAgencyIdentifier 
		{
			get 
			{
				return this.codeListVersionAgencyIdentifierField;
			}
			set 
			{
				this.codeListVersionAgencyIdentifierField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value 
		{
			get 
			{
				return this.valueField;
			}
			set 
			{
				this.valueField = value;
			}
		}
	}






	
	[System.Xml.Serialization.XmlRootAttribute("GeographicReferencePoint", IsNullable=false)]
	public class GeographicReferencePointDataType : DBKeys
	{
    
		private string geographicReferencePointCodeField;
    
		private ReferencePointCodeListIdentifierDataType referencePointCodeListIdentifierField = new ReferencePointCodeListIdentifierDataType();
    
		private string geographicReferencePointNameField;
    
    
		public string GeographicReferencePointCode 
		{
			get 
			{
				return this.geographicReferencePointCodeField;
			}
			set 
			{
				this.geographicReferencePointCodeField = value;
			}
		}
    
    
		public ReferencePointCodeListIdentifierDataType ReferencePointCodeListIdentifier 
		{
			get 
			{
				return this.referencePointCodeListIdentifierField;
			}
			set 
			{
				this.referencePointCodeListIdentifierField = value;
			}
		}
    
    
		public string GeographicReferencePointName 
		{
			get 
			{
				return this.geographicReferencePointNameField;
			}
			set 
			{
				this.geographicReferencePointNameField = value;
			}
		}
	}






	
	[System.Xml.Serialization.XmlRootAttribute("MethodIdentifierCodeListIdentifier", IsNullable=false)]
	public class MethodIdentifierCodeListIdentifierDataType : DBKeys
	{
    
		private string codeListVersionIdentifierField;
    
		private string codeListVersionAgencyIdentifierField;
    
		private string valueField;
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string CodeListVersionIdentifier 
		{
			get 
			{
				return this.codeListVersionIdentifierField;
			}
			set 
			{
				this.codeListVersionIdentifierField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string CodeListVersionAgencyIdentifier 
		{
			get 
			{
				return this.codeListVersionAgencyIdentifierField;
			}
			set 
			{
				this.codeListVersionAgencyIdentifierField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value 
		{
			get 
			{
				return this.valueField;
			}
			set 
			{
				this.valueField = value;
			}
		}
	}






	
	[System.Xml.Serialization.XmlRootAttribute("ReferenceMethod", IsNullable=false)]
	public class ReferenceMethodDataType : DBKeys
	{
    
		private string methodIdentifierCodeField;
    
		private MethodIdentifierCodeListIdentifierDataType methodIdentifierCodeListIdentifierField = new MethodIdentifierCodeListIdentifierDataType();
    
		private string methodNameField;
    
		private string methodDescriptionTextField;
    
		private string methodDeviationsTextField;
    
    
		public string MethodIdentifierCode 
		{
			get 
			{
				return this.methodIdentifierCodeField;
			}
			set 
			{
				this.methodIdentifierCodeField = value;
			}
		}
    
    
		public MethodIdentifierCodeListIdentifierDataType MethodIdentifierCodeListIdentifier 
		{
			get 
			{
				return this.methodIdentifierCodeListIdentifierField;
			}
			set 
			{
				this.methodIdentifierCodeListIdentifierField = value;
			}
		}
    
    
		public string MethodName 
		{
			get 
			{
				return this.methodNameField;
			}
			set 
			{
				this.methodNameField = value;
			}
		}
    
    
		public string MethodDescriptionText 
		{
			get 
			{
				return this.methodDescriptionTextField;
			}
			set 
			{
				this.methodDescriptionTextField = value;
			}
		}
    
    
		public string MethodDeviationsText 
		{
			get 
			{
				return this.methodDeviationsTextField;
			}
			set 
			{
				this.methodDeviationsTextField = value;
			}
		}
	}






	
	[System.Xml.Serialization.XmlRootAttribute("ResultQualifierCodeListIdentifier", IsNullable=false)]
	public class ResultQualifierCodeListIdentifierDataType : DBKeys
	{
    
		private string codeListVersionIdentifierField;
    
		private string codeListVersionAgencyIdentifierField;
    
		private string valueField;
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string CodeListVersionIdentifier 
		{
			get 
			{
				return this.codeListVersionIdentifierField;
			}
			set 
			{
				this.codeListVersionIdentifierField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string CodeListVersionAgencyIdentifier 
		{
			get 
			{
				return this.codeListVersionAgencyIdentifierField;
			}
			set 
			{
				this.codeListVersionAgencyIdentifierField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value 
		{
			get 
			{
				return this.valueField;
			}
			set 
			{
				this.valueField = value;
			}
		}
	}






	
	[System.Xml.Serialization.XmlRootAttribute("ResultQualifier", IsNullable=false)]
	public class ResultQualifierDataType : DBKeys
	{
    
		private string resultQualifierCodeField;
    
		private ResultQualifierCodeListIdentifierDataType resultQualifierCodeListIdentifierField = new ResultQualifierCodeListIdentifierDataType();
    
		private string resultQualifierNameField;
    
    
		public string ResultQualifierCode 
		{
			get 
			{
				return this.resultQualifierCodeField;
			}
			set 
			{
				this.resultQualifierCodeField = value;
			}
		}
    
    
		public ResultQualifierCodeListIdentifierDataType ResultQualifierCodeListIdentifier 
		{
			get 
			{
				return this.resultQualifierCodeListIdentifierField;
			}
			set 
			{
				this.resultQualifierCodeListIdentifierField = value;
			}
		}
    
    
		public string ResultQualifierName 
		{
			get 
			{
				return this.resultQualifierNameField;
			}
			set 
			{
				this.resultQualifierNameField = value;
			}
		}
	}






	
	[System.Xml.Serialization.XmlRootAttribute("MeasureUnitCodeListIdentifier", IsNullable=false)]
	public class MeasureUnitCodeListIdentifierDataType : DBKeys
	{
    
		private string codeListVersionIdentifierField;
    
		private string codeListVersionAgencyIdentifierField;
    
		private string valueField;
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string CodeListVersionIdentifier 
		{
			get 
			{
				return this.codeListVersionIdentifierField;
			}
			set 
			{
				this.codeListVersionIdentifierField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string CodeListVersionAgencyIdentifier 
		{
			get 
			{
				return this.codeListVersionAgencyIdentifierField;
			}
			set 
			{
				this.codeListVersionAgencyIdentifierField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value 
		{
			get 
			{
				return this.valueField;
			}
			set 
			{
				this.valueField = value;
			}
		}
	}


	
	[System.Xml.Serialization.XmlRootAttribute("MeasureUnit", IsNullable=false)]
	public class MeasureUnitDataType : DBKeys
	{
    
		private string measureUnitCodeField;
    
		private MeasureUnitCodeListIdentifierDataType measureUnitCodeListIdentifierField = new MeasureUnitCodeListIdentifierDataType();
    
		private string measureUnitNameField;
    
    
		public string MeasureUnitCode 
		{
			get 
			{
				return this.measureUnitCodeField;
			}
			set 
			{
				this.measureUnitCodeField = value;
			}
		}
    
    
		public MeasureUnitCodeListIdentifierDataType MeasureUnitCodeListIdentifier 
		{
			get 
			{
				return this.measureUnitCodeListIdentifierField;
			}
			set 
			{
				this.measureUnitCodeListIdentifierField = value;
			}
		}
    
    
		public string MeasureUnitName 
		{
			get 
			{
				return this.measureUnitNameField;
			}
			set 
			{
				this.measureUnitNameField = value;
			}
		}
	}


	
	[System.Xml.Serialization.XmlRootAttribute("Measure", IsNullable=false)]
	public class MeasureDataType : DBKeys
	{
    
		private string measureValueField;
    
		private MeasureUnitDataType measureUnitField = new MeasureUnitDataType();
    
		private string measurePrecisionTextField;
    
		private ResultQualifierDataType resultQualifierField = new ResultQualifierDataType();
    
    
		public string MeasureValue 
		{
			get 
			{
				return this.measureValueField;
			}
			set 
			{
				this.measureValueField = value;
			}
		}
    
    
		public MeasureUnitDataType MeasureUnit 
		{
			get 
			{
				return this.measureUnitField;
			}
			set 
			{
				this.measureUnitField = value;
			}
		}
    
    
		public string MeasurePrecisionText 
		{
			get 
			{
				return this.measurePrecisionTextField;
			}
			set 
			{
				this.measurePrecisionTextField = value;
			}
		}
    
    
		public ResultQualifierDataType ResultQualifier 
		{
			get 
			{
				return this.resultQualifierField;
			}
			set 
			{
				this.resultQualifierField = value;
			}
		}
	}


	[System.Xml.Serialization.XmlRootAttribute("GeographicLocationDescription", IsNullable=false)]
	public class GeographicLocationDescriptionDataType : DBKeys
	{

		private string latitudeDegreeMeasureField;
    
		private string latitudeMinuteMeasureField;
    
		private string latitudeSecondMeasureField;
    
		private string longitudeDegreeMeasureField;
    
		private string longitudeMinuteMeasureField;
    
		private string longitudeSecondMeasureField;
    
		private string latitudeMeasureField;
    
		private string longitudeMeasureField;
    
		private string sourceMapScaleNumberField;
    
		private MeasureDataType horizontalAccuracyMeasureField = new MeasureDataType();
    
		private ReferenceMethodDataType horizontalCollectionMethodField = new ReferenceMethodDataType();
    
		private GeographicReferencePointDataType geographicReferencePointField = new GeographicReferencePointDataType();
    
		private GeographicReferenceDatumDataType horizontalReferenceDatumField = new GeographicReferenceDatumDataType();
    
		private System.DateTime dataCollectionDateField;
    
		private bool dataCollectionDateFieldSpecified;
    
		private string locationCommentsTextField;
    
		private MeasureDataType verticalMeasureField = new MeasureDataType();
    
		private ReferenceMethodDataType verticalCollectionMethodField = new ReferenceMethodDataType();
    
		private GeographicReferenceDatumDataType verticalReferenceDatumField = new GeographicReferenceDatumDataType();
    
		private ReferenceMethodDataType verificationMethodField = new ReferenceMethodDataType();
    
		private CoordinateDataSourceDataType coordinateDataSourceField = new CoordinateDataSourceDataType();
    
		private GeometricTypeDataType geometricTypeField = new GeometricTypeDataType();
    
    
		[System.Xml.Serialization.XmlElementAttribute(DataType="integer")]
		public string LatitudeDegreeMeasure 
		{
			get 
			{
				return this.latitudeDegreeMeasureField;
			}
			set 
			{
				this.latitudeDegreeMeasureField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlElementAttribute(DataType="integer")]
		public string LatitudeMinuteMeasure 
		{
			get 
			{
				return this.latitudeMinuteMeasureField;
			}
			set 
			{
				this.latitudeMinuteMeasureField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlElementAttribute(DataType="integer")]
		public string LatitudeSecondMeasure 
		{
			get 
			{
				return this.latitudeSecondMeasureField;
			}
			set 
			{
				this.latitudeSecondMeasureField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlElementAttribute(DataType="integer")]
		public string LongitudeDegreeMeasure 
		{
			get 
			{
				return this.longitudeDegreeMeasureField;
			}
			set 
			{
				this.longitudeDegreeMeasureField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlElementAttribute(DataType="integer")]
		public string LongitudeMinuteMeasure 
		{
			get 
			{
				return this.longitudeMinuteMeasureField;
			}
			set 
			{
				this.longitudeMinuteMeasureField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlElementAttribute(DataType="integer")]
		public string LongitudeSecondMeasure 
		{
			get 
			{
				return this.longitudeSecondMeasureField;
			}
			set 
			{
				this.longitudeSecondMeasureField = value;
			}
		}

		public string LatitudeMeasure 
		{
			get 
			{
				return this.latitudeMeasureField;
			}
			set 
			{
				this.latitudeMeasureField = value;
			}
		}
    
    
		public string LongitudeMeasure 
		{
			get 
			{
				return this.longitudeMeasureField;
			}
			set 
			{
				this.longitudeMeasureField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlElementAttribute(DataType="nonNegativeInteger")]
		public string SourceMapScaleNumber 
		{
			get 
			{
				return this.sourceMapScaleNumberField;
			}
			set 
			{
				this.sourceMapScaleNumberField = value;
			}
		}
    
    
		public MeasureDataType HorizontalAccuracyMeasure 
		{
			get 
			{
				return this.horizontalAccuracyMeasureField;
			}
			set 
			{
				this.horizontalAccuracyMeasureField = value;
			}
		}
    
    
		public ReferenceMethodDataType HorizontalCollectionMethod 
		{
			get 
			{
				return this.horizontalCollectionMethodField;
			}
			set 
			{
				this.horizontalCollectionMethodField = value;
			}
		}
    
    
		public GeographicReferencePointDataType GeographicReferencePoint 
		{
			get 
			{
				return this.geographicReferencePointField;
			}
			set 
			{
				this.geographicReferencePointField = value;
			}
		}
    
    
		public GeographicReferenceDatumDataType HorizontalReferenceDatum 
		{
			get 
			{
				return this.horizontalReferenceDatumField;
			}
			set 
			{
				this.horizontalReferenceDatumField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlElementAttribute(DataType="date")]
		public System.DateTime DataCollectionDate 
		{
			get 
			{
				return this.dataCollectionDateField;
			}
			set 
			{
				this.dataCollectionDateField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool DataCollectionDateSpecified 
		{
			get 
			{
				return this.dataCollectionDateFieldSpecified;
			}
			set 
			{
				this.dataCollectionDateFieldSpecified = value;
			}
		}
    
    
		public string LocationCommentsText 
		{
			get 
			{
				return this.locationCommentsTextField;
			}
			set 
			{
				this.locationCommentsTextField = value;
			}
		}
    
    
		public MeasureDataType VerticalMeasure 
		{
			get 
			{
				return this.verticalMeasureField;
			}
			set 
			{
				this.verticalMeasureField = value;
			}
		}
    
    
		public ReferenceMethodDataType VerticalCollectionMethod 
		{
			get 
			{
				return this.verticalCollectionMethodField;
			}
			set 
			{
				this.verticalCollectionMethodField = value;
			}
		}
    
    
		public GeographicReferenceDatumDataType VerticalReferenceDatum 
		{
			get 
			{
				return this.verticalReferenceDatumField;
			}
			set 
			{
				this.verticalReferenceDatumField = value;
			}
		}
    
    
		public ReferenceMethodDataType VerificationMethod 
		{
			get 
			{
				return this.verificationMethodField;
			}
			set 
			{
				this.verificationMethodField = value;
			}
		}
    
    
		public CoordinateDataSourceDataType CoordinateDataSource 
		{
			get 
			{
				return this.coordinateDataSourceField;
			}
			set 
			{
				this.coordinateDataSourceField = value;
			}
		}
    
    
		public GeometricTypeDataType GeometricType 
		{
			get 
			{
				return this.geometricTypeField;
			}
			set 
			{
				this.geometricTypeField = value;
			}
		}
	}



	
	[System.Xml.Serialization.XmlRootAttribute("Facility", IsNullable=false)]
	public class FacilityDataType : DBKeys
	{
    
		private FacilitySiteIdentifierDataType[] facilityIdentifierField;

        private FacilityAccessDetailsDataType facilityAccessDetailsField = new FacilityAccessDetailsDataType();
        
        private string facilitySiteNameField;
    
		private LocationAddressDataType locationAddressField = new LocationAddressDataType();
    
		private string mailingFacilitySiteNameField;
    
		private MailingAddressDataType mailingAddressField = new MailingAddressDataType();
    
		private FacilitySICDataType[] facilitySICField;

		private FacilityNAICSDataType[] facilityNAICSField;
    
		private GeographicLocationDescriptionDataType geographicLocationDescriptionField = new GeographicLocationDescriptionDataType();
    
		private bool parentCompanyNameNAIndicatorField;
    
		private bool parentCompanyNameNAIndicatorFieldSpecified;
    
		private string parentCompanyNameTextField;
    
		private string parentDunBradstreetCodeField;
    
		private string[] facilityDunBradstreetCodeField;
    
		private string[] rCRAIdentificationNumberField;
    
		private string[] nPDESIdentificationNumberField;
    
		private string[] uICIdentificationNumberField;
    
    
		[System.Xml.Serialization.XmlElementAttribute("FacilityIdentifier")]
		public FacilitySiteIdentifierDataType[] FacilityIdentifier 
		{
			get 
			{
				return this.facilityIdentifierField;
			}
			set 
			{
				this.facilityIdentifierField = value;
			}
		}


        public FacilityAccessDetailsDataType FacilityAccessDetails
        {
            get
            {
                return this.facilityAccessDetailsField;
            }
            set
            {
                this.facilityAccessDetailsField = value;
            }
        }
        
        public string FacilitySiteName 
		{
			get 
			{
				return this.facilitySiteNameField;
			}
			set 
			{
				this.facilitySiteNameField = value;
			}
		}
    
    
		
		public LocationAddressDataType LocationAddress 
		{
			get 
			{
				return this.locationAddressField;
			}
			set 
			{
				this.locationAddressField = value;
			}
		}
    
    
		public string MailingFacilitySiteName 
		{
			get 
			{
				return this.mailingFacilitySiteNameField;
			}
			set 
			{
				this.mailingFacilitySiteNameField = value;
			}
		}
    
    
		public MailingAddressDataType MailingAddress 
		{
			get 
			{
				return this.mailingAddressField;
			}
			set 
			{
				this.mailingAddressField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlElementAttribute("FacilitySIC")]
		public FacilitySICDataType[] FacilitySIC 
		{
			get 
			{
				return this.facilitySICField;
			}
			set 
			{
				this.facilitySICField = value;
			}
		}

		[System.Xml.Serialization.XmlElementAttribute("FacilityNAICS")]
		public FacilityNAICSDataType[] FacilityNAICS 
		{
			get 
			{
				return this.facilityNAICSField;
			}
			set 
			{
				this.facilityNAICSField = value;
			}
		}
    
    
		public GeographicLocationDescriptionDataType GeographicLocationDescription 
		{
			get 
			{
				return this.geographicLocationDescriptionField;
			}
			set 
			{
				this.geographicLocationDescriptionField = value;
			}
		}
    
    
		public bool ParentCompanyNameNAIndicator 
		{
			get 
			{
				return this.parentCompanyNameNAIndicatorField;
			}
			set 
			{
				this.parentCompanyNameNAIndicatorField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool ParentCompanyNameNAIndicatorSpecified 
		{
			get 
			{
				return this.parentCompanyNameNAIndicatorFieldSpecified;
			}
			set 
			{
				this.parentCompanyNameNAIndicatorFieldSpecified = value;
			}
		}
    
    
		public string ParentCompanyNameText 
		{
			get 
			{
				return this.parentCompanyNameTextField;
			}
			set 
			{
				this.parentCompanyNameTextField = value;
			}
		}
    
    
		public string ParentDunBradstreetCode 
		{
			get 
			{
				return this.parentDunBradstreetCodeField;
			}
			set 
			{
				this.parentDunBradstreetCodeField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlElementAttribute("FacilityDunBradstreetCode")]
		public string[] FacilityDunBradstreetCode 
		{
			get 
			{
				return this.facilityDunBradstreetCodeField;
			}
			set 
			{
				this.facilityDunBradstreetCodeField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlElementAttribute("RCRAIdentificationNumber")]
		public string[] RCRAIdentificationNumber 
		{
			get 
			{
				return this.rCRAIdentificationNumberField;
			}
			set 
			{
				this.rCRAIdentificationNumberField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlElementAttribute("NPDESIdentificationNumber")]
		public string[] NPDESIdentificationNumber 
		{
			get 
			{
				return this.nPDESIdentificationNumberField;
			}
			set 
			{
				this.nPDESIdentificationNumberField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlElementAttribute("UICIdentificationNumber")]
		public string[] UICIdentificationNumber 
		{
			get 
			{
				return this.uICIdentificationNumberField;
			}
			set 
			{
				this.uICIdentificationNumberField = value;
			}
		}
	}




    [System.Xml.Serialization.XmlRootAttribute("FacilityAccessDetails", IsNullable = false)]
    public class FacilityAccessDetailsDataType : DBKeys
    {

        private object itemField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FacilityAccessCode", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("PriorYearTechnicalContactDetails", typeof(PriorYearTechnicalContactDetailsDataType))]
        public object Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }
    }


	
	[System.Xml.Serialization.XmlRootAttribute("FacilityIdentifier", IsNullable=false)]
	public class FacilitySiteIdentifierDataType : DBKeys
	{
    
		private string facilitySiteIdentifierContextField;
    
		private string valueField;
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string FacilitySiteIdentifierContext 
		{
			get 
			{
				return this.facilitySiteIdentifierContextField;
			}
			set 
			{
				this.facilitySiteIdentifierContextField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value 
		{
			get 
			{
				return this.valueField;
			}
			set 
			{
				this.valueField = value;
			}
		}
	}



    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlRootAttribute("PriorYearTechnicalContactDetails", IsNullable = false)]
    public partial class PriorYearTechnicalContactDetailsDataType : DBKeys
    {

        private string priorYearTechnicalContactNameTextField;

        private string priorYearTechnicalContactTelephoneNumberTextField;

        /// <remarks/>
        public string PriorYearTechnicalContactNameText
        {
            get
            {
                return this.priorYearTechnicalContactNameTextField;
            }
            set
            {
                this.priorYearTechnicalContactNameTextField = value;
            }
        }

        /// <remarks/>
        public string PriorYearTechnicalContactTelephoneNumberText
        {
            get
            {
                return this.priorYearTechnicalContactTelephoneNumberTextField;
            }
            set
            {
                this.priorYearTechnicalContactTelephoneNumberTextField = value;
            }
        }
    }


	
	[System.Xml.Serialization.XmlRootAttribute("FacilitySIC", IsNullable=false)]
	public class FacilitySICDataType : DBKeys
	{
    
		private string sICCodeField;
    
		private string sICPrimaryIndicatorField;
    
    
		
		public string SICCode 
		{
			get 
			{
				return this.sICCodeField;
			}
			set 
			{
				this.sICCodeField = value;
			}
		}
    
    
		
		public string SICPrimaryIndicator 
		{
			get 
			{
				return this.sICPrimaryIndicatorField;
			}
			set 
			{
				this.sICPrimaryIndicatorField = value;
			}
		}
	}



	
	[System.Xml.Serialization.XmlRootAttribute("FacilityNAICS", IsNullable=false)]
	public class FacilityNAICSDataType : DBKeys
	{
    
		private string nAICSCodeField;
    
		private string nAICSPrimaryIndicatorField;
    
    
		
		public string NAICSCode 
		{
			get 
			{
				return this.nAICSCodeField;
			}
			set 
			{
				this.nAICSCodeField = value;
			}
		}
    
    
		
		public string NAICSPrimaryIndicator 
		{
			get 
			{
				return this.nAICSPrimaryIndicatorField;
			}
			set 
			{
				this.nAICSPrimaryIndicatorField = value;
			}
		}
	}


	
	[System.Xml.Serialization.XmlRootAttribute("ReportType", IsNullable=false)]
	public class ReportTypeDataType : DBKeys
	{
    
		private string reportTypeCodeField;
    
		private bool reportTypeCodeFieldSpecified;
    
		private ReportTypeCodeListIdentifierDataType reportTypeCodeListIdentifierField;
    
		private string reportTypeNameField;
    
    
		public string ReportTypeCode 
		{
			get 
			{
				return this.reportTypeCodeField;
			}
			set 
			{
				this.reportTypeCodeField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool ReportTypeCodeSpecified 
		{
			get 
			{
				return this.reportTypeCodeFieldSpecified;
			}
			set 
			{
				this.reportTypeCodeFieldSpecified = value;
			}
		}
    
    
		
		public ReportTypeCodeListIdentifierDataType ReportTypeCodeListIdentifier 
		{
			get 
			{
				return this.reportTypeCodeListIdentifierField;
			}
			set 
			{
				this.reportTypeCodeListIdentifierField = value;
			}
		}
    
    
		
		public string ReportTypeName 
		{
			get 
			{
				return this.reportTypeNameField;
			}
			set 
			{
				this.reportTypeNameField = value;
			}
		}
	}




	
	[System.Xml.Serialization.XmlRootAttribute("SourceReductionActivity", IsNullable=false)]
	public class SourceReductionActivityDataType : DBKeys
	{
    
		private int sourceReductionSequenceNumberField;
    
		private bool sourceReductionSequenceNumberFieldSpecified;
    
		private string sourceReductionActivityCodeField;
    
		private string[] sourceReductionMethodCodeField;
    
    
		public int SourceReductionSequenceNumber 
		{
			get 
			{
				return this.sourceReductionSequenceNumberField;
			}
			set 
			{
				this.sourceReductionSequenceNumberField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool SourceReductionSequenceNumberSpecified 
		{
			get 
			{
				return this.sourceReductionSequenceNumberFieldSpecified;
			}
			set 
			{
				this.sourceReductionSequenceNumberFieldSpecified = value;
			}
		}
    
    
		public string SourceReductionActivityCode 
		{
			get 
			{
				return this.sourceReductionActivityCodeField;
			}
			set 
			{
				this.sourceReductionActivityCodeField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlElementAttribute("SourceReductionMethodCode")]
		public string[] SourceReductionMethodCode 
		{
			get 
			{
				return this.sourceReductionMethodCodeField;
			}
			set 
			{
				this.sourceReductionMethodCodeField = value;
			}
		}
	}




	
	[System.Xml.Serialization.XmlRootAttribute("SourceReductionQuantity", IsNullable=false)]
	public class SourceReductionQuantityDataType : DBKeys
	{
    
		private TotalYearlyQuantityDataType[] onsiteUICDisposalQuantityField;
    
		private TotalYearlyQuantityDataType[] onsiteOtherDisposalQuantityField;
    
		private TotalYearlyQuantityDataType[] offsiteUICDisposalQuantityField;
    
		private TotalYearlyQuantityDataType[] offsiteOtherDisposalQuantityField;
    
		private TotalYearlyQuantityDataType[] onsiteEnergyRecoveryQuantityField;
    
		private TotalYearlyQuantityDataType[] offsiteEnergyRecoveryQuantityField;
    
		private TotalYearlyQuantityDataType[] onsiteRecycledQuantityField;
    
		private TotalYearlyQuantityDataType[] offsiteRecycledQuantityField;
    
		private TotalYearlyQuantityDataType[] onsiteTreatedQuantityField;
    
		private TotalYearlyQuantityDataType[] offsiteTreatedQuantityField;

        private object[] itemField;
    
		private object item1Field;
    
    
		[System.Xml.Serialization.XmlElementAttribute("OnsiteUICDisposalQuantity")]
		public TotalYearlyQuantityDataType[] OnsiteUICDisposalQuantity 
		{
			get 
			{
				return this.onsiteUICDisposalQuantityField;
			}
			set 
			{
				this.onsiteUICDisposalQuantityField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlElementAttribute("OnsiteOtherDisposalQuantity")]
		public TotalYearlyQuantityDataType[] OnsiteOtherDisposalQuantity 
		{
			get 
			{
				return this.onsiteOtherDisposalQuantityField;
			}
			set 
			{
				this.onsiteOtherDisposalQuantityField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlElementAttribute("OffsiteUICDisposalQuantity")]
		public TotalYearlyQuantityDataType[] OffsiteUICDisposalQuantity 
		{
			get 
			{
				return this.offsiteUICDisposalQuantityField;
			}
			set 
			{
				this.offsiteUICDisposalQuantityField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlElementAttribute("OffsiteOtherDisposalQuantity")]
		public TotalYearlyQuantityDataType[] OffsiteOtherDisposalQuantity 
		{
			get 
			{
				return this.offsiteOtherDisposalQuantityField;
			}
			set 
			{
				this.offsiteOtherDisposalQuantityField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlElementAttribute("OnsiteEnergyRecoveryQuantity")]
		public TotalYearlyQuantityDataType[] OnsiteEnergyRecoveryQuantity 
		{
			get 
			{
				return this.onsiteEnergyRecoveryQuantityField;
			}
			set 
			{
				this.onsiteEnergyRecoveryQuantityField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlElementAttribute("OffsiteEnergyRecoveryQuantity")]
		public TotalYearlyQuantityDataType[] OffsiteEnergyRecoveryQuantity 
		{
			get 
			{
				return this.offsiteEnergyRecoveryQuantityField;
			}
			set 
			{
				this.offsiteEnergyRecoveryQuantityField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlElementAttribute("OnsiteRecycledQuantity")]
		public TotalYearlyQuantityDataType[] OnsiteRecycledQuantity 
		{
			get 
			{
				return this.onsiteRecycledQuantityField;
			}
			set 
			{
				this.onsiteRecycledQuantityField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlElementAttribute("OffsiteRecycledQuantity")]
		public TotalYearlyQuantityDataType[] OffsiteRecycledQuantity 
		{
			get 
			{
				return this.offsiteRecycledQuantityField;
			}
			set 
			{
				this.offsiteRecycledQuantityField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlElementAttribute("OnsiteTreatedQuantity")]
		public TotalYearlyQuantityDataType[] OnsiteTreatedQuantity 
		{
			get 
			{
				return this.onsiteTreatedQuantityField;
			}
			set 
			{
				this.onsiteTreatedQuantityField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlElementAttribute("OffsiteTreatedQuantity")]
		public TotalYearlyQuantityDataType[] OffsiteTreatedQuantity 
		{
			get 
			{
				return this.offsiteTreatedQuantityField;
			}
			set 
			{
				this.offsiteTreatedQuantityField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlElementAttribute("OneTimeReleaseNAIndicator", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("OneTimeReleaseQuantity", typeof(decimal))]
        [System.Xml.Serialization.XmlElementAttribute("CalculatorRoundingHintNumber", typeof(string), DataType = "integer")]
        [System.Xml.Serialization.XmlElementAttribute("ToxicEquivalencyIdentification", typeof(ToxicEquivalencyIdentificationDataType))]
        public object[] Items
		{
			get 
			{
				return this.itemField;
			}
			set 
			{
				this.itemField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlElementAttribute("ProductionRatioMeasure", typeof(decimal))]
		[System.Xml.Serialization.XmlElementAttribute("ProductionRatioNAIndicator", typeof(bool))]
		public object Item1 
		{
			get 
			{
				return this.item1Field;
			}
			set 
			{
				this.item1Field = value;
			}
		}
	}


	
	[System.Xml.Serialization.XmlRootAttribute("OnsiteUICDisposalQuantity", IsNullable=false)]
	public class TotalYearlyQuantityDataType : DBKeys
	{
    
		private string yearOffsetMeasureField;

        private object[] itemsField;

        private ToxicEquivalencyIdentificationDataType toxicEquivalencyIdentification;

    
		[System.Xml.Serialization.XmlElementAttribute(DataType="integer")]
		public string YearOffsetMeasure 
		{
			get 
			{
				return this.yearOffsetMeasureField;
			}
			set 
			{
				this.yearOffsetMeasureField = value;
			}
		}


        [System.Xml.Serialization.XmlElementAttribute("CalculatorRoundingHintNumber", typeof(string), DataType = "integer")]
        [System.Xml.Serialization.XmlElementAttribute("TotalQuantity", typeof(decimal))]
        [System.Xml.Serialization.XmlElementAttribute("TotalQuantityNAIndicator", typeof(bool))]
        public object[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }

        public ToxicEquivalencyIdentificationDataType ToxicEquivalencyIdentification
        {
            get { return toxicEquivalencyIdentification; }
            set { toxicEquivalencyIdentification = value; }
        }
	}


	
	[System.Xml.Serialization.XmlRootAttribute("OnsiteRecyclingProcess", IsNullable=false)]
	public class OnsiteRecyclingProcessDataType : DBKeys
	{
    
		private object[] itemsField;
    
    
		[System.Xml.Serialization.XmlElementAttribute("OnsiteRecyclingMethodCode", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("OnsiteRecyclingNAIndicator", typeof(bool))]
		public object[] Items 
		{
			get 
			{
				return this.itemsField;
			}
			set 
			{
				this.itemsField = value;
			}
		}
	}

	
	[System.Xml.Serialization.XmlRootAttribute("OnsiteRecoveryProcess", IsNullable=false)]
	public class OnsiteRecoveryProcessDataType : DBKeys
	{
    
		private object[] itemsField;
    
    
		[System.Xml.Serialization.XmlElementAttribute("EnergyRecoveryMethodCode", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("EnergyRecoveryNAIndicator", typeof(bool))]
		public object[] Items 
		{
			get 
			{
				return this.itemsField;
			}
			set 
			{
				this.itemsField = value;
			}
		}
	}

	
	[System.Xml.Serialization.XmlRootAttribute("WasteTreatmentMethod", IsNullable=false)]
	public class WasteTreatmentMethodDataType : DBKeys
	{
    
		private int wasteTreatmentSequenceNumberField;
    
		private bool wasteTreatmentSequenceNumberFieldSpecified;
    
		private string wasteTreatmentMethodCodeField;
    
    
		public int WasteTreatmentSequenceNumber 
		{
			get 
			{
				return this.wasteTreatmentSequenceNumberField;
			}
			set 
			{
				this.wasteTreatmentSequenceNumberField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool WasteTreatmentSequenceNumberSpecified 
		{
			get 
			{
				return this.wasteTreatmentSequenceNumberFieldSpecified;
			}
			set 
			{
				this.wasteTreatmentSequenceNumberFieldSpecified = value;
			}
		}
    
    
		public string WasteTreatmentMethodCode 
		{
			get 
			{
				return this.wasteTreatmentMethodCodeField;
			}
			set 
			{
				this.wasteTreatmentMethodCodeField = value;
			}
		}
	}


	[System.Xml.Serialization.XmlRootAttribute("WasteTreatmentDetails", IsNullable=false)]
	public class WasteTreatmentDetailsDataType : DBKeys
	{
    
		private string wasteStreamSequenceNumberField;
    
		private string wasteStreamTypeCodeField;
    
		private WasteTreatmentMethodDataType[] wasteTreatmentMethodField;
    
		private string influentConcentrationRangeCodeField;
    
		private bool influentConcentrationRangeCodeFieldSpecified;
    
		private object itemField;
    
		private bool operatingDataIndicatorField;
    
		private bool operatingDataIndicatorFieldSpecified;
    
    
		[System.Xml.Serialization.XmlElementAttribute(DataType="integer")]
		public string WasteStreamSequenceNumber 
		{
			get 
			{
				return this.wasteStreamSequenceNumberField;
			}
			set 
			{
				this.wasteStreamSequenceNumberField = value;
			}
		}
    
    
		public string WasteStreamTypeCode 
		{
			get 
			{
				return this.wasteStreamTypeCodeField;
			}
			set 
			{
				this.wasteStreamTypeCodeField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlElementAttribute("WasteTreatmentMethod")]
		public WasteTreatmentMethodDataType[] WasteTreatmentMethod 
		{
			get 
			{
				return this.wasteTreatmentMethodField;
			}
			set 
			{
				this.wasteTreatmentMethodField = value;
			}
		}
    
    
		public string InfluentConcentrationRangeCode 
		{
			get 
			{
				return this.influentConcentrationRangeCodeField;
			}
			set 
			{
				this.influentConcentrationRangeCodeField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool InfluentConcentrationRangeCodeSpecified 
		{
			get 
			{
				return this.influentConcentrationRangeCodeFieldSpecified;
			}
			set 
			{
				this.influentConcentrationRangeCodeFieldSpecified = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlElementAttribute("TreatmentEfficiencyEstimatePercent", typeof(decimal))]
		[System.Xml.Serialization.XmlElementAttribute("TreatmentEfficiencyNAIndicator", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("TreatmentEfficiencyRangeCode", typeof(string))]
		public object Item 
		{
			get 
			{
				return this.itemField;
			}
			set 
			{
				this.itemField = value;
			}
		}
    
    
		public bool OperatingDataIndicator 
		{
			get 
			{
				return this.operatingDataIndicatorField;
			}
			set 
			{
				this.operatingDataIndicatorField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool OperatingDataIndicatorSpecified 
		{
			get 
			{
				return this.operatingDataIndicatorFieldSpecified;
			}
			set 
			{
				this.operatingDataIndicatorFieldSpecified = value;
			}
		}
	}


	[System.Xml.Serialization.XmlRootAttribute("TransferQuantity", IsNullable=false)]
	public class TransferQuantityDataType : DBKeys
	{
    
		private int transferSequenceNumberField;
    
		private bool transferSequenceNumberFieldSpecified;
    
		private WasteQuantityDataType transferWasteQuantityField = new WasteQuantityDataType();
    
		private string wasteManagementTypeCodeField;
    
		private bool wasteManagementTypeCodeFieldSpecified;
    
    
		public int TransferSequenceNumber 
		{
			get 
			{
				return this.transferSequenceNumberField;
			}
			set 
			{
				this.transferSequenceNumberField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool TransferSequenceNumberSpecified 
		{
			get 
			{
				return this.transferSequenceNumberFieldSpecified;
			}
			set 
			{
				this.transferSequenceNumberFieldSpecified = value;
			}
		}
    
    
		public WasteQuantityDataType TransferWasteQuantity 
		{
			get 
			{
				return this.transferWasteQuantityField;
			}
			set 
			{
				this.transferWasteQuantityField = value;
			}
		}
    
    
		public string WasteManagementTypeCode 
		{
			get 
			{
				return this.wasteManagementTypeCodeField;
			}
			set 
			{
				this.wasteManagementTypeCodeField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool WasteManagementTypeCodeSpecified 
		{
			get 
			{
				return this.wasteManagementTypeCodeFieldSpecified;
			}
			set 
			{
				this.wasteManagementTypeCodeFieldSpecified = value;
			}
		}
	}

    [System.Xml.Serialization.XmlRootAttribute("ToxicEquivalencyIdentification", IsNullable = false)]
    public class ToxicEquivalencyIdentificationDataType
    {
        private string toxicEquivalency1Value;
        private string toxicEquivalency2Value;
        private string toxicEquivalency3Value;
        private string toxicEquivalency4Value;
        private string toxicEquivalency5Value;
        private string toxicEquivalency6Value;
        private string toxicEquivalency7Value;
        private string toxicEquivalency8Value;
        private string toxicEquivalency9Value;
        private string toxicEquivalency10Value;
        private string toxicEquivalency11Value;
        private string toxicEquivalency12Value;
        private string toxicEquivalency13Value;
        private string toxicEquivalency14Value;
        private string toxicEquivalency15Value;
        private string toxicEquivalency16Value;
        private string toxicEquivalency17Value;
        private bool toxicEquivalencyNAIndicator;
        private bool toxicEquivalencyNAIndicatorSpecified;

        public string ToxicEquivalency1Value
        {
          get { return toxicEquivalency1Value; }
          set { toxicEquivalency1Value = value; }
        }

        public string ToxicEquivalency2Value
        {
            get { return toxicEquivalency2Value; }
            set { toxicEquivalency2Value = value; }
        }

        public string ToxicEquivalency3Value
        {
            get { return toxicEquivalency3Value; }
            set { toxicEquivalency3Value = value; }
        }

        public string ToxicEquivalency4Value
        {
            get { return toxicEquivalency4Value; }
            set { toxicEquivalency4Value = value; }
        }

        public string ToxicEquivalency5Value
        {
            get { return toxicEquivalency5Value; }
            set { toxicEquivalency5Value = value; }
        }

        public string ToxicEquivalency6Value
        {
            get { return toxicEquivalency6Value; }
            set { toxicEquivalency6Value = value; }
        }

        public string ToxicEquivalency7Value
        {
            get { return toxicEquivalency7Value; }
            set { toxicEquivalency7Value = value; }
        }

        public string ToxicEquivalency8Value
        {
            get { return toxicEquivalency8Value; }
            set { toxicEquivalency8Value = value; }
        }

        public string ToxicEquivalency9Value
        {
            get { return toxicEquivalency9Value; }
            set { toxicEquivalency9Value = value; }
        }

        public string ToxicEquivalency10Value
        {
            get { return toxicEquivalency10Value; }
            set { toxicEquivalency10Value = value; }
        }

        public string ToxicEquivalency11Value
        {
            get { return toxicEquivalency11Value; }
            set { toxicEquivalency11Value = value; }
        }

        public string ToxicEquivalency12Value
        {
            get { return toxicEquivalency12Value; }
            set { toxicEquivalency12Value = value; }
        }

        public string ToxicEquivalency13Value
        {
            get { return toxicEquivalency13Value; }
            set { toxicEquivalency13Value = value; }
        }

        public string ToxicEquivalency14Value
        {
            get { return toxicEquivalency14Value; }
            set { toxicEquivalency14Value = value; }
        }

        public string ToxicEquivalency15Value
        {
            get { return toxicEquivalency15Value; }
            set { toxicEquivalency15Value = value; }
        }

        public string ToxicEquivalency16Value
        {
            get { return toxicEquivalency16Value; }
            set { toxicEquivalency16Value = value; }
        }
        public string ToxicEquivalency17Value
        {
            get { return toxicEquivalency17Value; }
            set { toxicEquivalency17Value = value; }
        }

        public bool ToxicEquivalencyNAIndicator
        {
            get { return toxicEquivalencyNAIndicator; }
            set { toxicEquivalencyNAIndicator = value; }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ToxicEquivalencyNAIndicatorSpecified
        {
            get
            {
                return this.toxicEquivalencyNAIndicatorSpecified;
            }
            set
            {
                this.toxicEquivalencyNAIndicatorSpecified = value;
                //transferLocationSequenceNumberFieldSpecified
            }
        }
    }

    [System.Xml.Serialization.XmlRootAttribute("POTWWasteQuantity", IsNullable = false)]
    public partial class POTWWasteQuantityDataType : DBKeys
    {

        private object[] itemsField;

        private ItemsChoiceType2[] itemsElementNameField;

        private object itemField;

        private ToxicEquivalencyIdentificationDataType toxicEquivalencyIdentificationField;

        private decimal quantityDisposedLandfillPercentValueField;

        private bool quantityDisposedLandfillPercentValueFieldSpecified;

        private decimal quantityDisposedOtherPercentValueField;

        private bool quantityDisposedOtherPercentValueFieldSpecified;

        private decimal quantityTreatedPercentValueField;

        private bool quantityTreatedPercentValueFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("WasteQuantityCatastrophicMeasure", typeof(decimal))]
        [System.Xml.Serialization.XmlElementAttribute("WasteQuantityMeasure", typeof(decimal))]
        [System.Xml.Serialization.XmlElementAttribute("WasteQuantityNAIndicator", typeof(bool))]
        [System.Xml.Serialization.XmlElementAttribute("WasteQuantityRangeCode", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("WasteQuantityRangeNumericBasisValue", typeof(decimal))]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
        public object[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemsChoiceType2[] ItemsElementName
        {
            get
            {
                return this.itemsElementNameField;
            }
            set
            {
                this.itemsElementNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("QuantityBasisEstimationCode", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("QuantityBasisEstimationNAIndicator", typeof(bool))]
        public object Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }

        /// <remarks/>
        public ToxicEquivalencyIdentificationDataType ToxicEquivalencyIdentification
        {
            get
            {
                return this.toxicEquivalencyIdentificationField;
            }
            set
            {
                this.toxicEquivalencyIdentificationField = value;
            }
        }

        /// <remarks/>
        public decimal QuantityDisposedLandfillPercentValue
        {
            get
            {
                return this.quantityDisposedLandfillPercentValueField;
            }
            set
            {
                this.quantityDisposedLandfillPercentValueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool QuantityDisposedLandfillPercentValueSpecified
        {
            get
            {
                return this.quantityDisposedLandfillPercentValueFieldSpecified;
            }
            set
            {
                this.quantityDisposedLandfillPercentValueFieldSpecified = value;
            }
        }

        /// <remarks/>
        public decimal QuantityDisposedOtherPercentValue
        {
            get
            {
                return this.quantityDisposedOtherPercentValueField;
            }
            set
            {
                this.quantityDisposedOtherPercentValueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool QuantityDisposedOtherPercentValueSpecified
        {
            get
            {
                return this.quantityDisposedOtherPercentValueFieldSpecified;
            }
            set
            {
                this.quantityDisposedOtherPercentValueFieldSpecified = value;
            }
        }

        /// <remarks/>
        public decimal QuantityTreatedPercentValue
        {
            get
            {
                return this.quantityTreatedPercentValueField;
            }
            set
            {
                this.quantityTreatedPercentValueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool QuantityTreatedPercentValueSpecified
        {
            get
            {
                return this.quantityTreatedPercentValueFieldSpecified;
            }
            set
            {
                this.quantityTreatedPercentValueFieldSpecified = value;
            }
        }
    }


    [System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
    public enum ItemsChoiceType2
    {

        /// <remarks/>
        WasteQuantityCatastrophicMeasure,

        /// <remarks/>
        WasteQuantityMeasure,

        /// <remarks/>
        WasteQuantityNAIndicator,

        /// <remarks/>
        WasteQuantityRangeCode,

        /// <remarks/>
        WasteQuantityRangeNumericBasisValue,
    }
    
    
    [System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
    public enum ItemsChoiceType
    {

        /// <remarks/>
        WasteQuantityCatastrophicMeasure,

        /// <remarks/>
        WasteQuantityMeasure,

        /// <remarks/>
        WasteQuantityNAIndicator,

        /// <remarks/>
        WasteQuantityRangeCode,

        /// <remarks/>
        WasteQuantityRangeNumericBasisValue,
    }

    [System.Xml.Serialization.XmlRootAttribute("TransferWasteQuantity", IsNullable = false)]
	public class WasteQuantityDataType : DBKeys
	{

        private object[] itemsField;

        private ItemsChoiceType[] itemsElementNameField;

        private object itemField;

        private ToxicEquivalencyIdentificationDataType toxicEquivalencyIdentificationField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("WasteQuantityCatastrophicMeasure", typeof(decimal))]
        [System.Xml.Serialization.XmlElementAttribute("WasteQuantityMeasure", typeof(decimal))]
        [System.Xml.Serialization.XmlElementAttribute("WasteQuantityNAIndicator", typeof(bool))]
        [System.Xml.Serialization.XmlElementAttribute("WasteQuantityRangeCode", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("WasteQuantityRangeNumericBasisValue", typeof(decimal))]
        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
        public object[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public ItemsChoiceType[] ItemsElementName
        {
            get
            {
                return this.itemsElementNameField;
            }
            set
            {
                this.itemsElementNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("QuantityBasisEstimationCode", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("QuantityBasisEstimationNAIndicator", typeof(bool))]
        public object Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }

        /// <remarks/>
        public ToxicEquivalencyIdentificationDataType ToxicEquivalencyIdentification
        {
            get
            {
                return this.toxicEquivalencyIdentificationField;
            }
            set
            {
                this.toxicEquivalencyIdentificationField = value;
            }
        }
    }


	[System.Xml.Serialization.XmlRootAttribute("TransferLocation", IsNullable=false)]
	public class TransferLocationDataType : DBKeys
	{
    
		private int transferLocationSequenceNumberField;
    
		private bool transferLocationSequenceNumberFieldSpecified;
    
		private bool pOTWIndicatorField;
    
		private bool pOTWIndicatorFieldSpecified;
    
		private string facilitySiteNameField;
    
		private LocationAddressDataType locationAddressField;
    
		private bool controlledLocationIndicatorField;
    
		private bool controlledLocationIndicatorFieldSpecified;
    
		private string rCRAIdentificationNumberField;
    
		private TransferQuantityDataType[] transferQuantityField;
    
    
		public int TransferLocationSequenceNumber 
		{
			get 
			{
				return this.transferLocationSequenceNumberField;
			}
			set 
			{
				this.transferLocationSequenceNumberField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool TransferLocationSequenceNumberSpecified 
		{
			get 
			{
				return this.transferLocationSequenceNumberFieldSpecified;
			}
			set 
			{
				this.transferLocationSequenceNumberFieldSpecified = value;
			}
		}
    
    
		public bool POTWIndicator 
		{
			get 
			{
				return this.pOTWIndicatorField;
			}
			set 
			{
				this.pOTWIndicatorField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool POTWIndicatorSpecified 
		{
			get 
			{
				return this.pOTWIndicatorFieldSpecified;
			}
			set 
			{
				this.pOTWIndicatorFieldSpecified = value;
			}
		}
    
    
		
		public string FacilitySiteName 
		{
			get 
			{
				return this.facilitySiteNameField;
			}
			set 
			{
				this.facilitySiteNameField = value;
			}
		}
    
    
		
		public LocationAddressDataType LocationAddress 
		{
			get 
			{
				return this.locationAddressField;
			}
			set 
			{
				this.locationAddressField = value;
			}
		}
    
    
		public bool ControlledLocationIndicator 
		{
			get 
			{
				return this.controlledLocationIndicatorField;
			}
			set 
			{
				this.controlledLocationIndicatorField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool ControlledLocationIndicatorSpecified 
		{
			get 
			{
				return this.controlledLocationIndicatorFieldSpecified;
			}
			set 
			{
				this.controlledLocationIndicatorFieldSpecified = value;
			}
		}
    
    
		public string RCRAIdentificationNumber 
		{
			get 
			{
				return this.rCRAIdentificationNumberField;
			}
			set 
			{
				this.rCRAIdentificationNumberField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlElementAttribute("TransferQuantity")]
		public TransferQuantityDataType[] TransferQuantity 
		{
			get 
			{
				return this.transferQuantityField;
			}
			set 
			{
				this.transferQuantityField = value;
			}
		}
	}






	
	[System.Xml.Serialization.XmlRootAttribute("WaterStream", IsNullable=false)]
	public class WaterStreamDataType : DBKeys
	{
    
		private string waterSequenceNumberField;
    
		private string streamNameField;
    
		private object itemField;
    
    
		[System.Xml.Serialization.XmlElementAttribute(DataType="integer")]
		public string WaterSequenceNumber 
		{
			get 
			{
				return this.waterSequenceNumberField;
			}
			set 
			{
				this.waterSequenceNumberField = value;
			}
		}
    
    
		public string StreamName 
		{
			get 
			{
				return this.streamNameField;
			}
			set 
			{
				this.streamNameField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlElementAttribute("ReleaseStormWaterNAIndicator", typeof(bool))]
		[System.Xml.Serialization.XmlElementAttribute("ReleaseStormWaterPercent", typeof(decimal))]
		public object Item 
		{
			get 
			{
				return this.itemField;
			}
			set 
			{
				this.itemField = value;
			}
		}
	}






	
	[System.Xml.Serialization.XmlRootAttribute("OnsiteReleaseQuantity", IsNullable=false)]
	public class OnsiteReleaseQuantityDataType : DBKeys
	{
    
		private string environmentalMediumCodeField;
    
		private WasteQuantityDataType onsiteWasteQuantityField = new WasteQuantityDataType();
    
		private WaterStreamDataType waterStreamField;
    
    
		public string EnvironmentalMediumCode 
		{
			get 
			{
				return this.environmentalMediumCodeField;
			}
			set 
			{
				this.environmentalMediumCodeField = value;
			}
		}
    
    
		public WasteQuantityDataType OnsiteWasteQuantity 
		{
			get 
			{
				return this.onsiteWasteQuantityField;
			}
			set 
			{
				this.onsiteWasteQuantityField = value;
			}
		}
    
    
		public WaterStreamDataType WaterStream 
		{
			get 
			{
				return this.waterStreamField;
			}
			set 
			{
				this.waterStreamField = value;
			}
		}
	}



	
	[System.Xml.Serialization.XmlRootAttribute("ChemicalActivitiesAndUses", IsNullable=false)]
	public class ChemicalActivitiesAndUsesDataType : DBKeys
	{
    
		private bool chemicalAncillaryUsageIndicatorField;
    
		private bool chemicalAncillaryUsageIndicatorFieldSpecified;
    
		private bool chemicalArticleComponentIndicatorField;
    
		private bool chemicalArticleComponentIndicatorFieldSpecified;
    
		private bool chemicalByproductIndicatorField;
    
		private bool chemicalByproductIndicatorFieldSpecified;
    
		private bool chemicalFormulationComponentIndicatorField;
    
		private bool chemicalFormulationComponentIndicatorFieldSpecified;
    
		private bool chemicalImportedIndicatorField;
    
		private bool chemicalImportedIndicatorFieldSpecified;
    
		private bool chemicalManufactureAidIndicatorField;
    
		private bool chemicalManufactureAidIndicatorFieldSpecified;
    
		private bool chemicalManufactureImpurityIndicatorField;
    
		private bool chemicalManufactureImpurityIndicatorFieldSpecified;
    
		private bool chemicalProcessImpurityIndicatorField;
    
		private bool chemicalProcessImpurityIndicatorFieldSpecified;
    
		private bool chemicalProcessingAidIndicatorField;
    
		private bool chemicalProcessingAidIndicatorFieldSpecified;
    
		private bool chemicalProducedIndicatorField;
    
		private bool chemicalProducedIndicatorFieldSpecified;
    
		private bool chemicalReactantIndicatorField;
    
		private bool chemicalReactantIndicatorFieldSpecified;
    
		private bool chemicalRepackagingIndicatorField;
    
		private bool chemicalRepackagingIndicatorFieldSpecified;
    
		private bool chemicalSalesDistributionIndicatorField;
    
		private bool chemicalSalesDistributionIndicatorFieldSpecified;
    
		private bool chemicalUsedProcessedIndicatorField;
    
		private bool chemicalUsedProcessedIndicatorFieldSpecified;
    
    
		public bool ChemicalAncillaryUsageIndicator 
		{
			get 
			{
				return this.chemicalAncillaryUsageIndicatorField;
			}
			set 
			{
				this.chemicalAncillaryUsageIndicatorField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool ChemicalAncillaryUsageIndicatorSpecified 
		{
			get 
			{
				return this.chemicalAncillaryUsageIndicatorFieldSpecified;
			}
			set 
			{
				this.chemicalAncillaryUsageIndicatorFieldSpecified = value;
			}
		}
    
    
		public bool ChemicalArticleComponentIndicator 
		{
			get 
			{
				return this.chemicalArticleComponentIndicatorField;
			}
			set 
			{
				this.chemicalArticleComponentIndicatorField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool ChemicalArticleComponentIndicatorSpecified 
		{
			get 
			{
				return this.chemicalArticleComponentIndicatorFieldSpecified;
			}
			set 
			{
				this.chemicalArticleComponentIndicatorFieldSpecified = value;
			}
		}
    
    
		public bool ChemicalByproductIndicator 
		{
			get 
			{
				return this.chemicalByproductIndicatorField;
			}
			set 
			{
				this.chemicalByproductIndicatorField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool ChemicalByproductIndicatorSpecified 
		{
			get 
			{
				return this.chemicalByproductIndicatorFieldSpecified;
			}
			set 
			{
				this.chemicalByproductIndicatorFieldSpecified = value;
			}
		}
    
    
		public bool ChemicalFormulationComponentIndicator 
		{
			get 
			{
				return this.chemicalFormulationComponentIndicatorField;
			}
			set 
			{
				this.chemicalFormulationComponentIndicatorField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool ChemicalFormulationComponentIndicatorSpecified 
		{
			get 
			{
				return this.chemicalFormulationComponentIndicatorFieldSpecified;
			}
			set 
			{
				this.chemicalFormulationComponentIndicatorFieldSpecified = value;
			}
		}
    
    
		public bool ChemicalImportedIndicator 
		{
			get 
			{
				return this.chemicalImportedIndicatorField;
			}
			set 
			{
				this.chemicalImportedIndicatorField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool ChemicalImportedIndicatorSpecified 
		{
			get 
			{
				return this.chemicalImportedIndicatorFieldSpecified;
			}
			set 
			{
				this.chemicalImportedIndicatorFieldSpecified = value;
			}
		}
    
    
		public bool ChemicalManufactureAidIndicator 
		{
			get 
			{
				return this.chemicalManufactureAidIndicatorField;
			}
			set 
			{
				this.chemicalManufactureAidIndicatorField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool ChemicalManufactureAidIndicatorSpecified 
		{
			get 
			{
				return this.chemicalManufactureAidIndicatorFieldSpecified;
			}
			set 
			{
				this.chemicalManufactureAidIndicatorFieldSpecified = value;
			}
		}
    
    
		public bool ChemicalManufactureImpurityIndicator 
		{
			get 
			{
				return this.chemicalManufactureImpurityIndicatorField;
			}
			set 
			{
				this.chemicalManufactureImpurityIndicatorField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool ChemicalManufactureImpurityIndicatorSpecified 
		{
			get 
			{
				return this.chemicalManufactureImpurityIndicatorFieldSpecified;
			}
			set 
			{
				this.chemicalManufactureImpurityIndicatorFieldSpecified = value;
			}
		}
    
    
		public bool ChemicalProcessImpurityIndicator 
		{
			get 
			{
				return this.chemicalProcessImpurityIndicatorField;
			}
			set 
			{
				this.chemicalProcessImpurityIndicatorField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool ChemicalProcessImpurityIndicatorSpecified 
		{
			get 
			{
				return this.chemicalProcessImpurityIndicatorFieldSpecified;
			}
			set 
			{
				this.chemicalProcessImpurityIndicatorFieldSpecified = value;
			}
		}
    
    
		public bool ChemicalProcessingAidIndicator 
		{
			get 
			{
				return this.chemicalProcessingAidIndicatorField;
			}
			set 
			{
				this.chemicalProcessingAidIndicatorField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool ChemicalProcessingAidIndicatorSpecified 
		{
			get 
			{
				return this.chemicalProcessingAidIndicatorFieldSpecified;
			}
			set 
			{
				this.chemicalProcessingAidIndicatorFieldSpecified = value;
			}
		}
    
    
		public bool ChemicalProducedIndicator 
		{
			get 
			{
				return this.chemicalProducedIndicatorField;
			}
			set 
			{
				this.chemicalProducedIndicatorField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool ChemicalProducedIndicatorSpecified 
		{
			get 
			{
				return this.chemicalProducedIndicatorFieldSpecified;
			}
			set 
			{
				this.chemicalProducedIndicatorFieldSpecified = value;
			}
		}
    
    
		public bool ChemicalReactantIndicator 
		{
			get 
			{
				return this.chemicalReactantIndicatorField;
			}
			set 
			{
				this.chemicalReactantIndicatorField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool ChemicalReactantIndicatorSpecified 
		{
			get 
			{
				return this.chemicalReactantIndicatorFieldSpecified;
			}
			set 
			{
				this.chemicalReactantIndicatorFieldSpecified = value;
			}
		}
    
    
		public bool ChemicalRepackagingIndicator 
		{
			get 
			{
				return this.chemicalRepackagingIndicatorField;
			}
			set 
			{
				this.chemicalRepackagingIndicatorField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool ChemicalRepackagingIndicatorSpecified 
		{
			get 
			{
				return this.chemicalRepackagingIndicatorFieldSpecified;
			}
			set 
			{
				this.chemicalRepackagingIndicatorFieldSpecified = value;
			}
		}
    
    
		public bool ChemicalSalesDistributionIndicator 
		{
			get 
			{
				return this.chemicalSalesDistributionIndicatorField;
			}
			set 
			{
				this.chemicalSalesDistributionIndicatorField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool ChemicalSalesDistributionIndicatorSpecified 
		{
			get 
			{
				return this.chemicalSalesDistributionIndicatorFieldSpecified;
			}
			set 
			{
				this.chemicalSalesDistributionIndicatorFieldSpecified = value;
			}
		}
    
    
		public bool ChemicalUsedProcessedIndicator 
		{
			get 
			{
				return this.chemicalUsedProcessedIndicatorField;
			}
			set 
			{
				this.chemicalUsedProcessedIndicatorField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool ChemicalUsedProcessedIndicatorSpecified 
		{
			get 
			{
				return this.chemicalUsedProcessedIndicatorFieldSpecified;
			}
			set 
			{
				this.chemicalUsedProcessedIndicatorFieldSpecified = value;
			}
		}
	}






	
	[System.Xml.Serialization.XmlRootAttribute("ChemicalIdentification", IsNullable=false)]
	public class ChemicalIdentificationDataType : DBKeys
	{
    
		private string cASNumberField;
    
		private string chemicalNameTextField;
    
		private string chemicalMixtureNameTextField;
    
		private string ePAChemicalIdentifierField;
    
		private string ePAChemicalRegistryNameField;
    
		private string ePAChemicalRegistryNameContextField;
    
		private decimal dioxinDistribution1PercentField;
    
		private bool dioxinDistribution1PercentFieldSpecified;
    
		private decimal dioxinDistribution2PercentField;
    
		private bool dioxinDistribution2PercentFieldSpecified;
    
		private decimal dioxinDistribution3PercentField;
    
		private bool dioxinDistribution3PercentFieldSpecified;
    
		private decimal dioxinDistribution4PercentField;
    
		private bool dioxinDistribution4PercentFieldSpecified;
    
		private decimal dioxinDistribution5PercentField;
    
		private bool dioxinDistribution5PercentFieldSpecified;
    
		private decimal dioxinDistribution6PercentField;
    
		private bool dioxinDistribution6PercentFieldSpecified;
    
		private decimal dioxinDistribution7PercentField;
    
		private bool dioxinDistribution7PercentFieldSpecified;
    
		private decimal dioxinDistribution8PercentField;
    
		private bool dioxinDistribution8PercentFieldSpecified;
    
		private decimal dioxinDistribution9PercentField;
    
		private bool dioxinDistribution9PercentFieldSpecified;
    
		private decimal dioxinDistribution10PercentField;
    
		private bool dioxinDistribution10PercentFieldSpecified;
    
		private decimal dioxinDistribution11PercentField;
    
		private bool dioxinDistribution11PercentFieldSpecified;
    
		private decimal dioxinDistribution12PercentField;
    
		private bool dioxinDistribution12PercentFieldSpecified;
    
		private decimal dioxinDistribution13PercentField;
    
		private bool dioxinDistribution13PercentFieldSpecified;
    
		private decimal dioxinDistribution14PercentField;
    
		private bool dioxinDistribution14PercentFieldSpecified;
    
		private decimal dioxinDistribution15PercentField;
    
		private bool dioxinDistribution15PercentFieldSpecified;
    
		private decimal dioxinDistribution16PercentField;
    
		private bool dioxinDistribution16PercentFieldSpecified;
    
		private decimal dioxinDistribution17PercentField;
    
		private bool dioxinDistribution17PercentFieldSpecified;
    
		private bool dioxinDistributionNAIndicatorField;
    
		private bool dioxinDistributionNAIndicatorFieldSpecified;
    
    
		
		public string CASNumber 
		{
			get 
			{
				return this.cASNumberField;
			}
			set 
			{
				this.cASNumberField = value;
			}
		}
    
    
		public string ChemicalNameText 
		{
			get 
			{
				return this.chemicalNameTextField;
			}
			set 
			{
				this.chemicalNameTextField = value;
			}
		}
    
    
		public string ChemicalMixtureNameText 
		{
			get 
			{
				return this.chemicalMixtureNameTextField;
			}
			set 
			{
				this.chemicalMixtureNameTextField = value;
			}
		}
    
    
		
		public string EPAChemicalIdentifier 
		{
			get 
			{
				return this.ePAChemicalIdentifierField;
			}
			set 
			{
				this.ePAChemicalIdentifierField = value;
			}
		}
    
    
		
		public string EPAChemicalRegistryName 
		{
			get 
			{
				return this.ePAChemicalRegistryNameField;
			}
			set 
			{
				this.ePAChemicalRegistryNameField = value;
			}
		}
    
    
		
		public string EPAChemicalRegistryNameContext 
		{
			get 
			{
				return this.ePAChemicalRegistryNameContextField;
			}
			set 
			{
				this.ePAChemicalRegistryNameContextField = value;
			}
		}
    
    
		public decimal DioxinDistribution1Percent 
		{
			get 
			{
				return this.dioxinDistribution1PercentField;
			}
			set 
			{
				this.dioxinDistribution1PercentField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool DioxinDistribution1PercentSpecified 
		{
			get 
			{
				return this.dioxinDistribution1PercentFieldSpecified;
			}
			set 
			{
				this.dioxinDistribution1PercentFieldSpecified = value;
			}
		}
    
    
		public decimal DioxinDistribution2Percent 
		{
			get 
			{
				return this.dioxinDistribution2PercentField;
			}
			set 
			{
				this.dioxinDistribution2PercentField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool DioxinDistribution2PercentSpecified 
		{
			get 
			{
				return this.dioxinDistribution2PercentFieldSpecified;
			}
			set 
			{
				this.dioxinDistribution2PercentFieldSpecified = value;
			}
		}
    
    
		public decimal DioxinDistribution3Percent 
		{
			get 
			{
				return this.dioxinDistribution3PercentField;
			}
			set 
			{
				this.dioxinDistribution3PercentField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool DioxinDistribution3PercentSpecified 
		{
			get 
			{
				return this.dioxinDistribution3PercentFieldSpecified;
			}
			set 
			{
				this.dioxinDistribution3PercentFieldSpecified = value;
			}
		}
    
    
		public decimal DioxinDistribution4Percent 
		{
			get 
			{
				return this.dioxinDistribution4PercentField;
			}
			set 
			{
				this.dioxinDistribution4PercentField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool DioxinDistribution4PercentSpecified 
		{
			get 
			{
				return this.dioxinDistribution4PercentFieldSpecified;
			}
			set 
			{
				this.dioxinDistribution4PercentFieldSpecified = value;
			}
		}
    
    
		public decimal DioxinDistribution5Percent 
		{
			get 
			{
				return this.dioxinDistribution5PercentField;
			}
			set 
			{
				this.dioxinDistribution5PercentField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool DioxinDistribution5PercentSpecified 
		{
			get 
			{
				return this.dioxinDistribution5PercentFieldSpecified;
			}
			set 
			{
				this.dioxinDistribution5PercentFieldSpecified = value;
			}
		}
    
    
		public decimal DioxinDistribution6Percent 
		{
			get 
			{
				return this.dioxinDistribution6PercentField;
			}
			set 
			{
				this.dioxinDistribution6PercentField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool DioxinDistribution6PercentSpecified 
		{
			get 
			{
				return this.dioxinDistribution6PercentFieldSpecified;
			}
			set 
			{
				this.dioxinDistribution6PercentFieldSpecified = value;
			}
		}
    
    
		public decimal DioxinDistribution7Percent 
		{
			get 
			{
				return this.dioxinDistribution7PercentField;
			}
			set 
			{
				this.dioxinDistribution7PercentField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool DioxinDistribution7PercentSpecified 
		{
			get 
			{
				return this.dioxinDistribution7PercentFieldSpecified;
			}
			set 
			{
				this.dioxinDistribution7PercentFieldSpecified = value;
			}
		}
    
    
		public decimal DioxinDistribution8Percent 
		{
			get 
			{
				return this.dioxinDistribution8PercentField;
			}
			set 
			{
				this.dioxinDistribution8PercentField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool DioxinDistribution8PercentSpecified 
		{
			get 
			{
				return this.dioxinDistribution8PercentFieldSpecified;
			}
			set 
			{
				this.dioxinDistribution8PercentFieldSpecified = value;
			}
		}
    
    
		public decimal DioxinDistribution9Percent 
		{
			get 
			{
				return this.dioxinDistribution9PercentField;
			}
			set 
			{
				this.dioxinDistribution9PercentField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool DioxinDistribution9PercentSpecified 
		{
			get 
			{
				return this.dioxinDistribution9PercentFieldSpecified;
			}
			set 
			{
				this.dioxinDistribution9PercentFieldSpecified = value;
			}
		}
    
    
		public decimal DioxinDistribution10Percent 
		{
			get 
			{
				return this.dioxinDistribution10PercentField;
			}
			set 
			{
				this.dioxinDistribution10PercentField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool DioxinDistribution10PercentSpecified 
		{
			get 
			{
				return this.dioxinDistribution10PercentFieldSpecified;
			}
			set 
			{
				this.dioxinDistribution10PercentFieldSpecified = value;
			}
		}
    
    
		public decimal DioxinDistribution11Percent 
		{
			get 
			{
				return this.dioxinDistribution11PercentField;
			}
			set 
			{
				this.dioxinDistribution11PercentField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool DioxinDistribution11PercentSpecified 
		{
			get 
			{
				return this.dioxinDistribution11PercentFieldSpecified;
			}
			set 
			{
				this.dioxinDistribution11PercentFieldSpecified = value;
			}
		}
    
    
		public decimal DioxinDistribution12Percent 
		{
			get 
			{
				return this.dioxinDistribution12PercentField;
			}
			set 
			{
				this.dioxinDistribution12PercentField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool DioxinDistribution12PercentSpecified 
		{
			get 
			{
				return this.dioxinDistribution12PercentFieldSpecified;
			}
			set 
			{
				this.dioxinDistribution12PercentFieldSpecified = value;
			}
		}
    
    
		public decimal DioxinDistribution13Percent 
		{
			get 
			{
				return this.dioxinDistribution13PercentField;
			}
			set 
			{
				this.dioxinDistribution13PercentField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool DioxinDistribution13PercentSpecified 
		{
			get 
			{
				return this.dioxinDistribution13PercentFieldSpecified;
			}
			set 
			{
				this.dioxinDistribution13PercentFieldSpecified = value;
			}
		}
    
    
		public decimal DioxinDistribution14Percent 
		{
			get 
			{
				return this.dioxinDistribution14PercentField;
			}
			set 
			{
				this.dioxinDistribution14PercentField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool DioxinDistribution14PercentSpecified 
		{
			get 
			{
				return this.dioxinDistribution14PercentFieldSpecified;
			}
			set 
			{
				this.dioxinDistribution14PercentFieldSpecified = value;
			}
		}
    
    
		public decimal DioxinDistribution15Percent 
		{
			get 
			{
				return this.dioxinDistribution15PercentField;
			}
			set 
			{
				this.dioxinDistribution15PercentField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool DioxinDistribution15PercentSpecified 
		{
			get 
			{
				return this.dioxinDistribution15PercentFieldSpecified;
			}
			set 
			{
				this.dioxinDistribution15PercentFieldSpecified = value;
			}
		}
    
    
		public decimal DioxinDistribution16Percent 
		{
			get 
			{
				return this.dioxinDistribution16PercentField;
			}
			set 
			{
				this.dioxinDistribution16PercentField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool DioxinDistribution16PercentSpecified 
		{
			get 
			{
				return this.dioxinDistribution16PercentFieldSpecified;
			}
			set 
			{
				this.dioxinDistribution16PercentFieldSpecified = value;
			}
		}
    
    
		public decimal DioxinDistribution17Percent 
		{
			get 
			{
				return this.dioxinDistribution17PercentField;
			}
			set 
			{
				this.dioxinDistribution17PercentField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool DioxinDistribution17PercentSpecified 
		{
			get 
			{
				return this.dioxinDistribution17PercentFieldSpecified;
			}
			set 
			{
				this.dioxinDistribution17PercentFieldSpecified = value;
			}
		}
    
    
		public bool DioxinDistributionNAIndicator 
		{
			get 
			{
				return this.dioxinDistributionNAIndicatorField;
			}
			set 
			{
				this.dioxinDistributionNAIndicatorField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool DioxinDistributionNAIndicatorSpecified 
		{
			get 
			{
				return this.dioxinDistributionNAIndicatorFieldSpecified;
			}
			set 
			{
				this.dioxinDistributionNAIndicatorFieldSpecified = value;
			}
		}
	}






	
	[System.Xml.Serialization.XmlRootAttribute("ReportValidation", IsNullable=false)]
	public class ReportValidationDataType : DBKeys
	{
    
		private string validationEntityNameTextField;
    
		private string validationMessageCodeField;
    
		private string validationMessageTextField;
    
		private string ePAErrorSeverityCodeField;
    
		private bool ePAErrorSeverityCodeFieldSpecified;
    
    
		public string ValidationEntityNameText 
		{
			get 
			{
				return this.validationEntityNameTextField;
			}
			set 
			{
				this.validationEntityNameTextField = value;
			}
		}
    
    
		public string ValidationMessageCode 
		{
			get 
			{
				return this.validationMessageCodeField;
			}
			set 
			{
				this.validationMessageCodeField = value;
			}
		}
    
    
		public string ValidationMessageText 
		{
			get 
			{
				return this.validationMessageTextField;
			}
			set 
			{
				this.validationMessageTextField = value;
			}
		}
    
    
		public string EPAErrorSeverityCode 
		{
			get 
			{
				return this.ePAErrorSeverityCodeField;
			}
			set 
			{
				this.ePAErrorSeverityCodeField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool EPAErrorSeverityCodeSpecified 
		{
			get 
			{
				return this.ePAErrorSeverityCodeFieldSpecified;
			}
			set 
			{
				this.ePAErrorSeverityCodeFieldSpecified = value;
			}
		}
	}




	
	[System.Xml.Serialization.XmlRootAttribute("ReportMetaData", IsNullable=false)]
	public class ReportMetaDataType : DBKeys
	{
    
		private System.DateTime reportPostmarkDateField;
    
		private bool reportPostmarkDateFieldSpecified;
    
		private System.DateTime reportReceivedDateField;
    
		private bool reportReceivedDateFieldSpecified;
    
		private System.DateTime reportOriginalPostmarkDateField;
    
		private bool reportOriginalPostmarkDateFieldSpecified;
    
		private System.DateTime reportOriginalReceivedDateField;
    
		private bool reportOriginalReceivedDateFieldSpecified;
    
		private string reportSubmissionMethodCodeField;
    
		private bool reportSubmissionMethodCodeFieldSpecified;
    
		private bool ePAPassedValidationIndicatorField;
    
		private bool ePAPassedValidationIndicatorFieldSpecified;
    
		private string ePAProcessingStatusCodeField;
    
		private bool ePAProcessingStatusCodeFieldSpecified;
    
		private bool unalteredReportIndicatorField;
    
		private bool unalteredReportIndicatorFieldSpecified;
    
		private ReportValidationDataType[] reportValidationField;
    
    
		[System.Xml.Serialization.XmlElementAttribute(DataType="date")]
		public System.DateTime ReportPostmarkDate 
		{
			get 
			{
				return this.reportPostmarkDateField;
			}
			set 
			{
				this.reportPostmarkDateField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool ReportPostmarkDateSpecified 
		{
			get 
			{
				return this.reportPostmarkDateFieldSpecified;
			}
			set 
			{
				this.reportPostmarkDateFieldSpecified = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlElementAttribute(DataType="date")]
		public System.DateTime ReportReceivedDate 
		{
			get 
			{
				return this.reportReceivedDateField;
			}
			set 
			{
				this.reportReceivedDateField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool ReportReceivedDateSpecified 
		{
			get 
			{
				return this.reportReceivedDateFieldSpecified;
			}
			set 
			{
				this.reportReceivedDateFieldSpecified = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlElementAttribute(DataType="date")]
		public System.DateTime ReportOriginalPostmarkDate 
		{
			get 
			{
				return this.reportOriginalPostmarkDateField;
			}
			set 
			{
				this.reportOriginalPostmarkDateField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool ReportOriginalPostmarkDateSpecified 
		{
			get 
			{
				return this.reportOriginalPostmarkDateFieldSpecified;
			}
			set 
			{
				this.reportOriginalPostmarkDateFieldSpecified = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlElementAttribute(DataType="date")]
		public System.DateTime ReportOriginalReceivedDate 
		{
			get 
			{
				return this.reportOriginalReceivedDateField;
			}
			set 
			{
				this.reportOriginalReceivedDateField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool ReportOriginalReceivedDateSpecified 
		{
			get 
			{
				return this.reportOriginalReceivedDateFieldSpecified;
			}
			set 
			{
				this.reportOriginalReceivedDateFieldSpecified = value;
			}
		}
    
    
		public string ReportSubmissionMethodCode 
		{
			get 
			{
				return this.reportSubmissionMethodCodeField;
			}
			set 
			{
				this.reportSubmissionMethodCodeField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool ReportSubmissionMethodCodeSpecified 
		{
			get 
			{
				return this.reportSubmissionMethodCodeFieldSpecified;
			}
			set 
			{
				this.reportSubmissionMethodCodeFieldSpecified = value;
			}
		}
    
    
		public bool EPAPassedValidationIndicator 
		{
			get 
			{
				return this.ePAPassedValidationIndicatorField;
			}
			set 
			{
				this.ePAPassedValidationIndicatorField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool EPAPassedValidationIndicatorSpecified 
		{
			get 
			{
				return this.ePAPassedValidationIndicatorFieldSpecified;
			}
			set 
			{
				this.ePAPassedValidationIndicatorFieldSpecified = value;
			}
		}
    
    
		public string EPAProcessingStatusCode 
		{
			get 
			{
				return this.ePAProcessingStatusCodeField;
			}
			set 
			{
				this.ePAProcessingStatusCodeField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool EPAProcessingStatusCodeSpecified 
		{
			get 
			{
				return this.ePAProcessingStatusCodeFieldSpecified;
			}
			set 
			{
				this.ePAProcessingStatusCodeFieldSpecified = value;
			}
		}
    
    
		public bool UnalteredReportIndicator 
		{
			get 
			{
				return this.unalteredReportIndicatorField;
			}
			set 
			{
				this.unalteredReportIndicatorField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool UnalteredReportIndicatorSpecified 
		{
			get 
			{
				return this.unalteredReportIndicatorFieldSpecified;
			}
			set 
			{
				this.unalteredReportIndicatorFieldSpecified = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlElementAttribute("ReportValidation")]
		public ReportValidationDataType[] ReportValidation 
		{
			get 
			{
				return this.reportValidationField;
			}
			set 
			{
				this.reportValidationField = value;
			}
		}
	}




	
	[System.Xml.Serialization.XmlRootAttribute("Report", IsNullable=false)]
	public class ReportDataType : DBKeys
	{
    
		private ReportMetaDataType reportMetaDataField = new ReportMetaDataType();
    
		private ReportIdentifierDataType[] reportIdentifierField;
    
		private string[] replacedReportIdentifierField;
    
		private ReportTypeDataType reportTypeField = new ReportTypeDataType();
    
		private string submissionReportingYearField;
    
		private System.DateTime reportDueDateField;
    
		private bool reportDueDateFieldSpecified;
    
		private string revisionIndicatorField;
    
		private bool revisionIndicatorFieldSpecified;
    
		private bool chemicalTradeSecretIndicatorField;
    
		private bool chemicalTradeSecretIndicatorFieldSpecified;
    
		private bool submissionSanitizedIndicatorField;
    
		private bool submissionSanitizedIndicatorFieldSpecified;
    
		private string certifierNameField;
    
		private string certifierTitleTextField;
    
		private System.DateTime certificationSignedDateField;
    
		private bool certificationSignedDateFieldSpecified;
    
		private bool submissionEntireFacilityIndicatorField;
    
		private bool submissionEntireFacilityIndicatorFieldSpecified;
    
		private bool submissionPartialFacilityIndicatorField;
    
		private bool submissionPartialFacilityIndicatorFieldSpecified;
    
		private string submissionFederalFacilityIndicatorField;
    
		private bool submissionFederalFacilityIndicatorFieldSpecified;
    
		private bool submissionGOCOFacilityIndicatorField;
    
		private bool submissionGOCOFacilityIndicatorFieldSpecified;
    
		private IndividualIdentityDataType technicalContactNameTextField = new IndividualIdentityDataType();
    
		private string technicalContactPhoneTextField;
    
		private string technicalContactEmailAddressTextField;
    
		private IndividualIdentityDataType publicContactNameTextField = new IndividualIdentityDataType();
    
		private string publicContactPhoneTextField;

        private string publicContactEmailAddressTextField;

        private string[] chemicalReportRevisionCodeField;

        private string[] chemicalReportWithdrawalCodeField;
    
		private ChemicalIdentificationDataType[] chemicalIdentificationField;
    
		private ChemicalActivitiesAndUsesDataType chemicalActivitiesAndUsesField = new ChemicalActivitiesAndUsesDataType();
    
		private string maximumChemicalAmountCodeField;
    
		private bool maximumChemicalAmountCodeFieldSpecified;
    
		private OnsiteReleaseQuantityDataType[] onsiteReleaseQuantityField;

        private POTWWasteQuantityDataType pOTWWasteQuantityField = new POTWWasteQuantityDataType();
    
		private TransferLocationDataType[] transferLocationField;
    
		private object[] itemsField;
    
		private OnsiteRecoveryProcessDataType onsiteRecoveryProcessField = new OnsiteRecoveryProcessDataType();
    
		private OnsiteRecyclingProcessDataType onsiteRecyclingProcessField = new OnsiteRecyclingProcessDataType();
    
		private SourceReductionQuantityDataType sourceReductionQuantityField = new SourceReductionQuantityDataType();
    
		private object[] items1Field;
    
		private bool submissionAdditionalDataIndicatorField;
    
		private bool submissionAdditionalDataIndicatorFieldSpecified;
    
		private string optionalInformationTextField;
    
    
		public ReportMetaDataType ReportMetaData 
		{
			get 
			{
				return this.reportMetaDataField;
			}
			set 
			{
				this.reportMetaDataField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlElementAttribute("ReportIdentifier")]
		public ReportIdentifierDataType[] ReportIdentifier 
		{
			get 
			{
				return this.reportIdentifierField;
			}
			set 
			{
				this.reportIdentifierField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlElementAttribute("ReplacedReportIdentifier")]
		public string[] ReplacedReportIdentifier 
		{
			get 
			{
				return this.replacedReportIdentifierField;
			}
			set 
			{
				this.replacedReportIdentifierField = value;
			}
		}
    
    
		public ReportTypeDataType ReportType 
		{
			get 
			{
				return this.reportTypeField;
			}
			set 
			{
				this.reportTypeField = value;
			}
		}
    
    
		public string SubmissionReportingYear 
		{
			get 
			{
				return this.submissionReportingYearField;
			}
			set 
			{
				this.submissionReportingYearField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlElementAttribute(Namespace="urn:us:net:exchangenetwork:sc:1:0", DataType="date")]
		public System.DateTime ReportDueDate 
		{
			get 
			{
				return this.reportDueDateField;
			}
			set 
			{
				this.reportDueDateField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool ReportDueDateSpecified 
		{
			get 
			{
				return this.reportDueDateFieldSpecified;
			}
			set 
			{
				this.reportDueDateFieldSpecified = value;
			}
		}
    
    
		
		public string RevisionIndicator 
		{
			get 
			{
				return this.revisionIndicatorField;
			}
			set 
			{
				this.revisionIndicatorField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool RevisionIndicatorSpecified 
		{
			get 
			{
				return this.revisionIndicatorFieldSpecified;
			}
			set 
			{
				this.revisionIndicatorFieldSpecified = value;
			}
		}
    
    
		public bool ChemicalTradeSecretIndicator 
		{
			get 
			{
				return this.chemicalTradeSecretIndicatorField;
			}
			set 
			{
				this.chemicalTradeSecretIndicatorField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool ChemicalTradeSecretIndicatorSpecified 
		{
			get 
			{
				return this.chemicalTradeSecretIndicatorFieldSpecified;
			}
			set 
			{
				this.chemicalTradeSecretIndicatorFieldSpecified = value;
			}
		}
    
    
		public bool SubmissionSanitizedIndicator 
		{
			get 
			{
				return this.submissionSanitizedIndicatorField;
			}
			set 
			{
				this.submissionSanitizedIndicatorField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool SubmissionSanitizedIndicatorSpecified 
		{
			get 
			{
				return this.submissionSanitizedIndicatorFieldSpecified;
			}
			set 
			{
				this.submissionSanitizedIndicatorFieldSpecified = value;
			}
		}
    
    
		public string CertifierName 
		{
			get 
			{
				return this.certifierNameField;
			}
			set 
			{
				this.certifierNameField = value;
			}
		}
    
    
		public string CertifierTitleText 
		{
			get 
			{
				return this.certifierTitleTextField;
			}
			set 
			{
				this.certifierTitleTextField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlElementAttribute(DataType="date")]
		public System.DateTime CertificationSignedDate 
		{
			get 
			{
				return this.certificationSignedDateField;
			}
			set 
			{
				this.certificationSignedDateField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool CertificationSignedDateSpecified 
		{
			get 
			{
				return this.certificationSignedDateFieldSpecified;
			}
			set 
			{
				this.certificationSignedDateFieldSpecified = value;
			}
		}
    
    
		public bool SubmissionEntireFacilityIndicator 
		{
			get 
			{
				return this.submissionEntireFacilityIndicatorField;
			}
			set 
			{
				this.submissionEntireFacilityIndicatorField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool SubmissionEntireFacilityIndicatorSpecified 
		{
			get 
			{
				return this.submissionEntireFacilityIndicatorFieldSpecified;
			}
			set 
			{
				this.submissionEntireFacilityIndicatorFieldSpecified = value;
			}
		}
    
    
		public bool SubmissionPartialFacilityIndicator 
		{
			get 
			{
				return this.submissionPartialFacilityIndicatorField;
			}
			set 
			{
				this.submissionPartialFacilityIndicatorField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool SubmissionPartialFacilityIndicatorSpecified 
		{
			get 
			{
				return this.submissionPartialFacilityIndicatorFieldSpecified;
			}
			set 
			{
				this.submissionPartialFacilityIndicatorFieldSpecified = value;
			}
		}
    
    
		public string SubmissionFederalFacilityIndicator 
		{
			get 
			{
				return this.submissionFederalFacilityIndicatorField;
			}
			set 
			{
				this.submissionFederalFacilityIndicatorField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool SubmissionFederalFacilityIndicatorSpecified 
		{
			get 
			{
				return this.submissionFederalFacilityIndicatorFieldSpecified;
			}
			set 
			{
				this.submissionFederalFacilityIndicatorFieldSpecified = value;
			}
		}
    
    
		public bool SubmissionGOCOFacilityIndicator 
		{
			get 
			{
				return this.submissionGOCOFacilityIndicatorField;
			}
			set 
			{
				this.submissionGOCOFacilityIndicatorField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool SubmissionGOCOFacilityIndicatorSpecified 
		{
			get 
			{
				return this.submissionGOCOFacilityIndicatorFieldSpecified;
			}
			set 
			{
				this.submissionGOCOFacilityIndicatorFieldSpecified = value;
			}
		}
    
    
		public IndividualIdentityDataType TechnicalContactNameText 
		{
			get 
			{
				return this.technicalContactNameTextField;
			}
			set 
			{
				this.technicalContactNameTextField = value;
			}
		}
    
    
		public string TechnicalContactPhoneText 
		{
			get 
			{
				return this.technicalContactPhoneTextField;
			}
			set 
			{
				this.technicalContactPhoneTextField = value;
			}
		}
    
    
		public string TechnicalContactEmailAddressText 
		{
			get 
			{
				return this.technicalContactEmailAddressTextField;
			}
			set 
			{
				this.technicalContactEmailAddressTextField = value;
			}
		}
    
    
		public IndividualIdentityDataType PublicContactNameText 
		{
			get 
			{
				return this.publicContactNameTextField;
			}
			set 
			{
				this.publicContactNameTextField = value;
			}
		}
    
    
		public string PublicContactPhoneText 
		{
			get 
			{
				return this.publicContactPhoneTextField;
			}
			set 
			{
				this.publicContactPhoneTextField = value;
			}
		}

        public string PublicContactEmailAddressText
        {
            get
            {
                return this.publicContactEmailAddressTextField;
            }
            set
            {
                this.publicContactEmailAddressTextField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("ChemicalReportRevisionCode")]
        public string[] ChemicalReportRevisionCode
        {
            get
            {
                return this.chemicalReportRevisionCodeField;
            }
            set
            {
                this.chemicalReportRevisionCodeField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute("ChemicalReportWithdrawalCode")]
        public string[] ChemicalReportWithdrawalCode
        {
            get
            {
                return this.chemicalReportWithdrawalCodeField;
            }
            set
            {
                this.chemicalReportWithdrawalCodeField = value;
            }
        }
    
    
		[System.Xml.Serialization.XmlElementAttribute("ChemicalIdentification")]
		public ChemicalIdentificationDataType[] ChemicalIdentification 
		{
			get 
			{
				return this.chemicalIdentificationField;
			}
			set 
			{
				this.chemicalIdentificationField = value;
			}
		}
    
    
		public ChemicalActivitiesAndUsesDataType ChemicalActivitiesAndUses 
		{
			get 
			{
				return this.chemicalActivitiesAndUsesField;
			}
			set 
			{
				this.chemicalActivitiesAndUsesField = value;
			}
		}
    
    
		public string MaximumChemicalAmountCode 
		{
			get 
			{
				return this.maximumChemicalAmountCodeField;
			}
			set 
			{
				this.maximumChemicalAmountCodeField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool MaximumChemicalAmountCodeSpecified 
		{
			get 
			{
				return this.maximumChemicalAmountCodeFieldSpecified;
			}
			set 
			{
				this.maximumChemicalAmountCodeFieldSpecified = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlElementAttribute("OnsiteReleaseQuantity")]
		public OnsiteReleaseQuantityDataType[] OnsiteReleaseQuantity 
		{
			get 
			{
				return this.onsiteReleaseQuantityField;
			}
			set 
			{
				this.onsiteReleaseQuantityField = value;
			}
		}


        public POTWWasteQuantityDataType POTWWasteQuantity 
		{
			get 
			{
				return this.pOTWWasteQuantityField;
			}
			set 
			{
				this.pOTWWasteQuantityField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlElementAttribute("TransferLocation")]
		public TransferLocationDataType[] TransferLocation 
		{
			get 
			{
				return this.transferLocationField;
			}
			set 
			{
				this.transferLocationField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlElementAttribute("WasteTreatmentDetails", typeof(WasteTreatmentDetailsDataType))]
		[System.Xml.Serialization.XmlElementAttribute("WasteTreatmentNAIndicator", typeof(bool))]
		public object[] Items 
		{
			get 
			{
				return this.itemsField;
			}
			set 
			{
				this.itemsField = value;
			}
		}
    
    
		public OnsiteRecoveryProcessDataType OnsiteRecoveryProcess 
		{
			get 
			{
				return this.onsiteRecoveryProcessField;
			}
			set 
			{
				this.onsiteRecoveryProcessField = value;
			}
		}
    
    
		public OnsiteRecyclingProcessDataType OnsiteRecyclingProcess 
		{
			get 
			{
				return this.onsiteRecyclingProcessField;
			}
			set 
			{
				this.onsiteRecyclingProcessField = value;
			}
		}
    
    
		public SourceReductionQuantityDataType SourceReductionQuantity 
		{
			get 
			{
				return this.sourceReductionQuantityField;
			}
			set 
			{
				this.sourceReductionQuantityField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlElementAttribute("SourceReductionActivity", typeof(SourceReductionActivityDataType))]
		[System.Xml.Serialization.XmlElementAttribute("SourceReductionNAIndicator", typeof(bool))]
		public object[] Items1 
		{
			get 
			{
				return this.items1Field;
			}
			set 
			{
				this.items1Field = value;
			}
		}
    
    
		public bool SubmissionAdditionalDataIndicator 
		{
			get 
			{
				return this.submissionAdditionalDataIndicatorField;
			}
			set 
			{
				this.submissionAdditionalDataIndicatorField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool SubmissionAdditionalDataIndicatorSpecified 
		{
			get 
			{
				return this.submissionAdditionalDataIndicatorFieldSpecified;
			}
			set 
			{
				this.submissionAdditionalDataIndicatorFieldSpecified = value;
			}
		}
    
    
		public string OptionalInformationText 
		{
			get 
			{
				return this.optionalInformationTextField;
			}
			set 
			{
				this.optionalInformationTextField = value;
			}
		}
	}


	
	[System.Xml.Serialization.XmlRootAttribute("SourceReductionActivity", IsNullable=false)]
	public class SourceReductionActivity  : DBKeys
	{
		public string SourceReductionActivityCode;

		public string SourceReductionSequenceNumber;

		public string[] SourceReductionMethodCode;
	}


	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlRootAttribute("TechnicalContactNameText", IsNullable=false)]
	public class IndividualIdentityDataType : DBKeys
	{
    
		private IndividualIdentifierDataType individualIdentifierField = new IndividualIdentifierDataType();
    
		private string individualTitleTextField;
    
		private string namePrefixTextField;
    

		public string individualFullName;

    
		private string nameSuffixTextField;

    
    
		public IndividualIdentifierDataType IndividualIdentifier 
		{
			get 
			{
				return this.individualIdentifierField;
			}
			set 
			{
				this.individualIdentifierField = value;
			}
		}
    
    
		public string IndividualTitleText 
		{
			get 
			{
				return this.individualTitleTextField;
			}
			set 
			{
				this.individualTitleTextField = value;
			}
		}
    
    
		public string NamePrefixText 
		{
			get 
			{
				return this.namePrefixTextField;
			}
			set 
			{
				this.namePrefixTextField = value;
			}
		}


		public string IndividualFullName 
		{
			get 
			{
				return this.individualFullName;
			}
			set 
			{
				this.individualFullName = value;
			}
		}
    
        
    
		public string NameSuffixText 
		{
			get 
			{
				return this.nameSuffixTextField;
			}
			set 
			{
				this.nameSuffixTextField = value;
			}
		}
	}



	



	
	[System.Xml.Serialization.XmlRootAttribute("Submission", IsNullable=false)]
	public class SubmissionDataType : DBKeys
	{
    
		private TRISubmissionIdentifier tRISubmissionIdentifierField;
    
		private FacilityDataType facilityField;
    
		private ReportDataType[] reportField;
    
    
		public TRISubmissionIdentifier TRISubmissionIdentifier 
		{
			get 
			{
				return this.tRISubmissionIdentifierField;
			}
			set 
			{
				this.tRISubmissionIdentifierField = value;
			}
		}
    
    
		public FacilityDataType Facility 
		{
			get 
			{
				return this.facilityField;
			}
			set 
			{
				this.facilityField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlElementAttribute("Report")]
		public ReportDataType[] Report 
		{
			get 
			{
				return this.reportField;
			}
			set 
			{
				this.reportField = value;
			}
		}
	}



	public class TRISubmissionIdentifier : DBKeys
	{
    
		private string submissionIdentifierContextField;
    
		private string valueField;
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string SubmissionIdentifierContext 
		{
			get 
			{
				return this.submissionIdentifierContextField;
			}
			set 
			{
				this.submissionIdentifierContextField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value 
		{
			get 
			{
				return this.valueField;
			}
			set 
			{
				this.valueField = value;
			}
		}
	}






	
	[System.Xml.Serialization.XmlRootAttribute("AccreditationAuthorityIdentifier", IsNullable=false)]
	public class AccreditationAuthorityIdentifierDataType : DBKeys
	{
    
		private string accreditationAuthorityIdentifierContextField;
    
		private string valueField;
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string AccreditationAuthorityIdentifierContext 
		{
			get 
			{
				return this.accreditationAuthorityIdentifierContextField;
			}
			set 
			{
				this.accreditationAuthorityIdentifierContextField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value 
		{
			get 
			{
				return this.valueField;
			}
			set 
			{
				this.valueField = value;
			}
		}
	}





	
	[System.Xml.Serialization.XmlRootAttribute("AgencyCodeListIdentifier", IsNullable=false)]
	public class AgencyCodeListIdentifierDataType : DBKeys
	{
    
		private string codeListVersionIdentifierField;
    
		private string codeListVersionAgencyIdentifierField;
    
		private string valueField;
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string CodeListVersionIdentifier 
		{
			get 
			{
				return this.codeListVersionIdentifierField;
			}
			set 
			{
				this.codeListVersionIdentifierField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string CodeListVersionAgencyIdentifier 
		{
			get 
			{
				return this.codeListVersionAgencyIdentifierField;
			}
			set 
			{
				this.codeListVersionAgencyIdentifierField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value 
		{
			get 
			{
				return this.valueField;
			}
			set 
			{
				this.valueField = value;
			}
		}
	}






	
	[System.Xml.Serialization.XmlRootAttribute("AgencyTypeCodeListIdentifier", IsNullable=false)]
	public class AgencyTypeCodeListIdentifierDataType : DBKeys
	{
    
		private string codeListVersionIdentifierField;
    
		private string codeListVersionAgencyIdentifierField;
    
		private string valueField;
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string CodeListVersionIdentifier 
		{
			get 
			{
				return this.codeListVersionIdentifierField;
			}
			set 
			{
				this.codeListVersionIdentifierField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string CodeListVersionAgencyIdentifier 
		{
			get 
			{
				return this.codeListVersionAgencyIdentifierField;
			}
			set 
			{
				this.codeListVersionAgencyIdentifierField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value 
		{
			get 
			{
				return this.valueField;
			}
			set 
			{
				this.valueField = value;
			}
		}
	}






	
	[System.Xml.Serialization.XmlRootAttribute("BiologicalGroupName", IsNullable=false)]
	public class BiologicalGroupNameDataType : DBKeys
	{
    
		private string biologicalGroupNameContextField;
    
		private string valueField;
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string BiologicalGroupNameContext 
		{
			get 
			{
				return this.biologicalGroupNameContextField;
			}
			set 
			{
				this.biologicalGroupNameContextField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value 
		{
			get 
			{
				return this.valueField;
			}
			set 
			{
				this.valueField = value;
			}
		}
	}






	
	[System.Xml.Serialization.XmlRootAttribute("BiologicalSynonymName", IsNullable=false)]
	public class BiologicalSynonymNameDataType : DBKeys
	{
    
		private string biologicalSynonymNameContextField;
    
		private string valueField;
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string BiologicalSynonymNameContext 
		{
			get 
			{
				return this.biologicalSynonymNameContextField;
			}
			set 
			{
				this.biologicalSynonymNameContextField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value 
		{
			get 
			{
				return this.valueField;
			}
			set 
			{
				this.valueField = value;
			}
		}
	}






	
	[System.Xml.Serialization.XmlRootAttribute("BiologicalSystematicName", IsNullable=false)]
	public class BiologicalSystematicNameDataType : DBKeys
	{
    
		private string biologicalSystematicNameContextField;
    
		private string valueField;
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string BiologicalSystematicNameContext 
		{
			get 
			{
				return this.biologicalSystematicNameContextField;
			}
			set 
			{
				this.biologicalSystematicNameContextField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value 
		{
			get 
			{
				return this.valueField;
			}
			set 
			{
				this.valueField = value;
			}
		}
	}






	
	[System.Xml.Serialization.XmlRootAttribute("BiologicalVernacularName", IsNullable=false)]
	public class BiologicalVernacularNameDataType : DBKeys
	{
    
		private string biologicalVernacularNameContextField;
    
		private string valueField;
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string BiologicalVernacularNameContext 
		{
			get 
			{
				return this.biologicalVernacularNameContextField;
			}
			set 
			{
				this.biologicalVernacularNameContextField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value 
		{
			get 
			{
				return this.valueField;
			}
			set 
			{
				this.valueField = value;
			}
		}
	}






	
	[System.Xml.Serialization.XmlRootAttribute("ComplianceMilestoneIdentifier", IsNullable=false)]
	public class ComplianceMilestoneIdentifierDataType : DBKeys
	{
    
		private string complianceMilestoneIdentifierContextField;
    
		private string valueField;
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string ComplianceMilestoneIdentifierContext 
		{
			get 
			{
				return this.complianceMilestoneIdentifierContextField;
			}
			set 
			{
				this.complianceMilestoneIdentifierContextField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value 
		{
			get 
			{
				return this.valueField;
			}
			set 
			{
				this.valueField = value;
			}
		}
	}



	
	[System.Xml.Serialization.XmlRootAttribute("ComplianceMilestoneTypeCodeListIdentifier", IsNullable=false)]
	public class ComplianceMilestoneTypeCodeListIdentifierDataType : DBKeys
	{
    
		private string codeListVersionIdentifierField;
    
		private string codeListVersionAgencyIdentifierField;
    
		private string valueField;
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string CodeListVersionIdentifier 
		{
			get 
			{
				return this.codeListVersionIdentifierField;
			}
			set 
			{
				this.codeListVersionIdentifierField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string CodeListVersionAgencyIdentifier 
		{
			get 
			{
				return this.codeListVersionAgencyIdentifierField;
			}
			set 
			{
				this.codeListVersionAgencyIdentifierField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value 
		{
			get 
			{
				return this.valueField;
			}
			set 
			{
				this.valueField = value;
			}
		}
	}




	
	[System.Xml.Serialization.XmlRootAttribute("ComplianceScheduleIdentifier", IsNullable=false)]
	public class ComplianceScheduleIdentifierDataType : DBKeys
	{
    
		private string complianceScheduleIdentifierContextField;
    
		private string valueField;
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string ComplianceScheduleIdentifierContext 
		{
			get 
			{
				return this.complianceScheduleIdentifierContextField;
			}
			set 
			{
				this.complianceScheduleIdentifierContextField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value 
		{
			get 
			{
				return this.valueField;
			}
			set 
			{
				this.valueField = value;
			}
		}
	}







	
	[System.Xml.Serialization.XmlRootAttribute("ConditionIdentifier", IsNullable=false)]
	public class ConditionIdentifierDataType : DBKeys
	{
    
		private string conditionIdentifierContextField;
    
		private string valueField;
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string ConditionIdentifierContext 
		{
			get 
			{
				return this.conditionIdentifierContextField;
			}
			set 
			{
				this.conditionIdentifierContextField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value 
		{
			get 
			{
				return this.valueField;
			}
			set 
			{
				this.valueField = value;
			}
		}
	}









	
	[System.Xml.Serialization.XmlRootAttribute("EnforcementActionIdentifier", IsNullable=false)]
	public class EnforcementActionIdentifierDataType : DBKeys
	{
    
		private string enforcementActionIdentifierContextField;
    
		private string valueField;
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string EnforcementActionIdentifierContext 
		{
			get 
			{
				return this.enforcementActionIdentifierContextField;
			}
			set 
			{
				this.enforcementActionIdentifierContextField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value 
		{
			get 
			{
				return this.valueField;
			}
			set 
			{
				this.valueField = value;
			}
		}
	}






	
	[System.Xml.Serialization.XmlRootAttribute("FacilityManagementTypeCodeListIdentifier", IsNullable=false)]
	public class FacilityManagementTypeCodeListIdentifierDataType : DBKeys
	{
    
		private string codeListVersionIdentifierField;
    
		private string codeListVersionAgencyIdentifierField;
    
		private string valueField;
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string CodeListVersionIdentifier 
		{
			get 
			{
				return this.codeListVersionIdentifierField;
			}
			set 
			{
				this.codeListVersionIdentifierField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string CodeListVersionAgencyIdentifier 
		{
			get 
			{
				return this.codeListVersionAgencyIdentifierField;
			}
			set 
			{
				this.codeListVersionAgencyIdentifierField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value 
		{
			get 
			{
				return this.valueField;
			}
			set 
			{
				this.valueField = value;
			}
		}
	}






	
	[System.Xml.Serialization.XmlRootAttribute("FacilitySiteTypeCodeListIdentifier", IsNullable=false)]
	public class FacilitySiteTypeCodeListIdentifierDataType : DBKeys
	{
    
		private string codeListVersionIdentifierField;
    
		private string codeListVersionAgencyIdentifierField;
    
		private string valueField;
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string CodeListVersionIdentifier 
		{
			get 
			{
				return this.codeListVersionIdentifierField;
			}
			set 
			{
				this.codeListVersionIdentifierField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string CodeListVersionAgencyIdentifier 
		{
			get 
			{
				return this.codeListVersionAgencyIdentifierField;
			}
			set 
			{
				this.codeListVersionAgencyIdentifierField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value 
		{
			get 
			{
				return this.valueField;
			}
			set 
			{
				this.valueField = value;
			}
		}
	}






	
	[System.Xml.Serialization.XmlRootAttribute("FormIdentifier", IsNullable=false)]
	public class FormIdentifierDataType : DBKeys
	{
    
		private string formIdentifierContextField;
    
		private string valueField;
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string FormIdentifierContext 
		{
			get 
			{
				return this.formIdentifierContextField;
			}
			set 
			{
				this.formIdentifierContextField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value 
		{
			get 
			{
				return this.valueField;
			}
			set 
			{
				this.valueField = value;
			}
		}
	}






	
	[System.Xml.Serialization.XmlRootAttribute("InjunctiveReliefIdentifier", IsNullable=false)]
	public class InjunctiveReliefIdentifierDataType : DBKeys
	{
    
		private string injunctiveReliefIdentifierContextField;
    
		private string valueField;
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string InjunctiveReliefIdentifierContext 
		{
			get 
			{
				return this.injunctiveReliefIdentifierContextField;
			}
			set 
			{
				this.injunctiveReliefIdentifierContextField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value 
		{
			get 
			{
				return this.valueField;
			}
			set 
			{
				this.valueField = value;
			}
		}
	}






	
	[System.Xml.Serialization.XmlRootAttribute("LaboratoryIdentifier", IsNullable=false)]
	public class LaboratoryIdentifierDataType : DBKeys
	{
    
		private string laboratoryIdentifierContextField;
    
		private string valueField;
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string LaboratoryIdentifierContext 
		{
			get 
			{
				return this.laboratoryIdentifierContextField;
			}
			set 
			{
				this.laboratoryIdentifierContextField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value 
		{
			get 
			{
				return this.valueField;
			}
			set 
			{
				this.valueField = value;
			}
		}
	}






	
	[System.Xml.Serialization.XmlRootAttribute("MonitoringLocationIdentifier", IsNullable=false)]
	public class MonitoringLocationIdentifierDataType : DBKeys
	{
    
		private string monitoringLocationIdentifierContextField;
    
		private string valueField;
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string MonitoringLocationIdentifierContext 
		{
			get 
			{
				return this.monitoringLocationIdentifierContextField;
			}
			set 
			{
				this.monitoringLocationIdentifierContextField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value 
		{
			get 
			{
				return this.valueField;
			}
			set 
			{
				this.valueField = value;
			}
		}
	}








	
	[System.Xml.Serialization.XmlRootAttribute("OrganizationIdentifier", IsNullable=false)]
	public class OrganizationIdentifierDataType : DBKeys
	{
    
		private string organizationIdentifierContextField;
    
		private string valueField;
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string OrganizationIdentifierContext 
		{
			get 
			{
				return this.organizationIdentifierContextField;
			}
			set 
			{
				this.organizationIdentifierContextField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value 
		{
			get 
			{
				return this.valueField;
			}
			set 
			{
				this.valueField = value;
			}
		}
	}






	
	[System.Xml.Serialization.XmlRootAttribute("OtherPermitIdentifier", IsNullable=false)]
	public class OtherPermitIdentifierDataType : DBKeys
	{
    
		private string otherPermitIdentifierContextField;
    
		private string valueField;
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string OtherPermitIdentifierContext 
		{
			get 
			{
				return this.otherPermitIdentifierContextField;
			}
			set 
			{
				this.otherPermitIdentifierContextField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value 
		{
			get 
			{
				return this.valueField;
			}
			set 
			{
				this.valueField = value;
			}
		}
	}






	
	[System.Xml.Serialization.XmlRootAttribute("PenaltyIdentifier", IsNullable=false)]
	public class PenaltyIdentifierDataType : DBKeys
	{
    
		private string penaltyIdentifierContextField;
    
		private string valueField;
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string PenaltyIdentifierContext 
		{
			get 
			{
				return this.penaltyIdentifierContextField;
			}
			set 
			{
				this.penaltyIdentifierContextField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value 
		{
			get 
			{
				return this.valueField;
			}
			set 
			{
				this.valueField = value;
			}
		}
	}






	
	[System.Xml.Serialization.XmlRootAttribute("PermitIdentifier", IsNullable=false)]
	public class PermitIdentifierDataType : DBKeys
	{
    
		private string permitIdentifierContextField;
    
		private string valueField;
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string PermitIdentifierContext 
		{
			get 
			{
				return this.permitIdentifierContextField;
			}
			set 
			{
				this.permitIdentifierContextField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value 
		{
			get 
			{
				return this.valueField;
			}
			set 
			{
				this.valueField = value;
			}
		}
	}






	
	[System.Xml.Serialization.XmlRootAttribute("PermittedFeatureIdentifier", IsNullable=false)]
	public class PermittedFeatureIdentifierDataType : DBKeys
	{
    
		private string permittedFeatureIdentifierContextField;
    
		private string valueField;
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string PermittedFeatureIdentifierContext 
		{
			get 
			{
				return this.permittedFeatureIdentifierContextField;
			}
			set 
			{
				this.permittedFeatureIdentifierContextField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value 
		{
			get 
			{
				return this.valueField;
			}
			set 
			{
				this.valueField = value;
			}
		}
	}






	
	[System.Xml.Serialization.XmlRootAttribute("PermitTypeCodeListIdentifier", IsNullable=false)]
	public class PermitTypeCodeListIdentifierDataType : DBKeys
	{
    
		private string codeListVersionIdentifierField;
    
		private string codeListVersionAgencyIdentifierField;
    
		private string valueField;
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string CodeListVersionIdentifier 
		{
			get 
			{
				return this.codeListVersionIdentifierField;
			}
			set 
			{
				this.codeListVersionIdentifierField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string CodeListVersionAgencyIdentifier 
		{
			get 
			{
				return this.codeListVersionAgencyIdentifierField;
			}
			set 
			{
				this.codeListVersionAgencyIdentifierField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value 
		{
			get 
			{
				return this.valueField;
			}
			set 
			{
				this.valueField = value;
			}
		}
	}






	
	[System.Xml.Serialization.XmlRootAttribute("SubstanceIdentifier", IsNullable=false)]
	public class SubstanceIdentifierDataType : DBKeys
	{
    
		private string substanceIdentifierContextField;
    
		private string valueField;
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string SubstanceIdentifierContext 
		{
			get 
			{
				return this.substanceIdentifierContextField;
			}
			set 
			{
				this.substanceIdentifierContextField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value 
		{
			get 
			{
				return this.valueField;
			}
			set 
			{
				this.valueField = value;
			}
		}
	}






	
	[System.Xml.Serialization.XmlRootAttribute("SubstanceName", IsNullable=false)]
	public class SubstanceNameDataType : DBKeys
	{
    
		private string substanceNameContextField;
    
		private string valueField;
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string SubstanceNameContext 
		{
			get 
			{
				return this.substanceNameContextField;
			}
			set 
			{
				this.substanceNameContextField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value 
		{
			get 
			{
				return this.valueField;
			}
			set 
			{
				this.valueField = value;
			}
		}
	}






	
	[System.Xml.Serialization.XmlRootAttribute("ViolationIdentifer", IsNullable=false)]
	public class ViolationIdentiferDataType : DBKeys
	{
    
		private string violationIdentiferContextField;
    
		private string valueField;
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string ViolationIdentiferContext 
		{
			get 
			{
				return this.violationIdentiferContextField;
			}
			set 
			{
				this.violationIdentiferContextField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value 
		{
			get 
			{
				return this.valueField;
			}
			set 
			{
				this.valueField = value;
			}
		}
	}






	
	[System.Xml.Serialization.XmlRootAttribute("ViolationTypeCodeListIdentifier", IsNullable=false)]
	public class ViolationTypeCodeListIdentifierDataType : DBKeys
	{
    
		private string codeListVersionIdentifierField;
    
		private string codeListVersionAgencyIdentifierField;
    
		private string valueField;
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string CodeListVersionIdentifier 
		{
			get 
			{
				return this.codeListVersionIdentifierField;
			}
			set 
			{
				this.codeListVersionIdentifierField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string CodeListVersionAgencyIdentifier 
		{
			get 
			{
				return this.codeListVersionAgencyIdentifierField;
			}
			set 
			{
				this.codeListVersionAgencyIdentifierField = value;
			}
		}
    
    
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value 
		{
			get 
			{
				return this.valueField;
			}
			set 
			{
				this.valueField = value;
			}
		}
	}






}
