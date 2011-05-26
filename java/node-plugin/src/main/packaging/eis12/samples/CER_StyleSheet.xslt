<?xml version="1.0"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:cer="http://www.exchangenetwork.net/schema/cer/1">
	<xsl:template match="/">
		<html>
			<head>
				<style>
					body {
					font-family: Verdana, Arial, Helvetica, sans-serif;
					font-size: 9px;
					}
					h1 {
					font-size: 16px;
					}
					h2 {
					font-size: 14px;
					}
					h3 {
					font-size: 12px;
					}
					th {
					font-size: 9px;
					}
					td {
					font-size: 9px;
					}
					div.scroll {
						height: 50px;
						width: 200px;
						overflow: auto;
						// border: 1px solid #666;
						// background-color: #ccc;
						// padding: 8px;
					div.indent1{padding-left: 18px;} 
					div.indent2{padding-left: 36px;} 
					div.indent3{padding-left: 54px;} 
					div.indent4{padding-left: 72px;} 
					div.indent5{padding-left: 90px;} 
					div.indent6{padding-left: 108px;} 
					div.indent7{padding-left: 124px;} 
					}
					table.standard {    
						background-color:#FFFFFF;    
						border: solid #000 3px;    
						width: 400px;
					}
					table.standard td {   
						padding: 5px;    
						border: solid #000 1px;
					}	
				</style>
			</head>
			<body>
				<xsl:apply-templates/>
			</body>
		</html>
	</xsl:template>
	<xsl:template match="/cer:CERS">
		<div class="indent1">
			<h2>CERS</h2>
			<table class="standard">
				<tr>
					<td>User Identifier</td>
					<td>
						<xsl:value-of select="cer:UserIdentifier"/>
					</td>
				</tr>
				<tr>
					<td>Program System Code</td>
					<td>
						<xsl:value-of select="cer:ProgramSystemCode"/>
					</td>
				</tr>
				<tr>
					<td>Emissions Year</td>
					<td>
						<xsl:value-of select="cer:EmissionsYear"/>
					</td>
				</tr>
				<tr>
					<td>Model</td>
					<td>
						<xsl:value-of select="cer:Model"/>
					</td>
				</tr>
				<tr>
					<td>Model Version</td>
					<td>
						<xsl:value-of select="cer:ModelVersion"/>
					</td>
				</tr>
				<tr>
					<td>Emissions Creation Date</td>
					<td>
						<xsl:value-of select="cer:EmissionsCreationDate"/>
					</td>
				</tr>
				<tr>
					<td>Submittal Comment</td>
					<td>
						<xsl:value-of select="cer:SubmittalComment"/>
					</td>
				</tr>
			</table>
		</div>
		<xsl:apply-templates select="cer:FacilitySite"/>
		<xsl:apply-templates select="cer:Location"/>
		<xsl:apply-templates select="cer:Event"/>
		<xsl:apply-templates select="cer:QualityFinding"/>
	</xsl:template>
	<xsl:template match="cer:CERS/cer:FacilitySite">
		<div class="indent2">
			<h2>Facility Site</h2>
			<table class="standard">
				<tr>
					<td>Facility Category Code</td>
					<td>
						<xsl:value-of select="cer:FacilityCategoryCode"/>
					</td>
				</tr>
				<tr>
					<td>Facility Site Name</td>
					<td>
						<xsl:value-of select="cer:FacilitySiteName"/>
					</td>
				</tr>
				<tr>
					<td>Facility Site Description</td>
					<td>
						<xsl:value-of select="cer:FacilitySiteDescription"/>
					</td>
				</tr>
				<tr>
					<td>Facility Site Status Code</td>
					<td>
						<xsl:value-of select="cer:FacilitySiteStatusCode"/>
					</td>
				</tr>
				<tr>
					<td>Facility Site Status Code Year</td>
					<td>
						<xsl:value-of select="cer:FacilitySiteStatusCodeYear"/>
					</td>
				</tr>
				<tr>
					<td>Sector Type Code</td>
					<td>
						<xsl:value-of select="cer:SectorTypeCode"/>
					</td>
				</tr>
				<tr>
					<td>Agency Name</td>
					<td>
						<xsl:value-of select="cer:AgencyName"/>
					</td>
				</tr>
				<tr>
					<td>FacilitySiteComment</td>
					<td>
						<xsl:value-of select="cer:FacilitySiteComment"/>
					</td>
				</tr>
			</table>
		</div>
		<xsl:apply-templates select="cer:FacilityNAICS"/>
		<xsl:apply-templates select="cer:FacilityIdentification"/>
		<xsl:apply-templates select="cer:AlternativeFacilityName"/>
		<xsl:apply-templates select="cer:FacilitySiteAddress"/>
		<xsl:apply-templates select="cer:FacilitySiteGeographicCoordinates"/>
		<xsl:apply-templates select="cer:FacilitySiteQualityIdentification"/>
		<xsl:apply-templates select="cer:FacilitySiteAttachedFile"/>
		<xsl:apply-templates select="cer:FacilitySiteAffiliation"/>
		<xsl:apply-templates select="cer:EmissionsUnit"/>
		<xsl:apply-templates select="cer:ReleasePoint"/>
	</xsl:template>
	<xsl:template match="cer:FacilitySite/cer:FacilityNAICS">
		<div class="indent3">
			<h2>Facility NAICS</h2>
			<table class="standard">
				<tr>
					<td>NAICS Code</td>
					<td>
						<xsl:value-of select="cer:NAICSCode"/>
					</td>
				</tr>
				<tr>
					<td>NAICS Primary Indicator</td>
					<td>
						<xsl:value-of select="cer:NAICSPrimaryIndicator"/>
					</td>
				</tr>
			</table>
		</div>
	</xsl:template>	
	<xsl:template match="cer:FacilitySite/cer:FacilityIdentification">
		<div class="indent3">
			<h2>Facility Identification</h2>
			<table class="standard">
				<tr>
					<td>Facility Identifier</td>
					<td>
						<xsl:value-of select="cer:FacilitySiteIdentifier"/>
					</td>
				</tr>
				<tr>
					<td>Program System Code</td>
					<td>
						<xsl:value-of select="cer:ProgramSystemCode"/>
					</td>
				</tr>
				<tr>
					<td>State And County FIPS Code</td>
					<td>
						<xsl:value-of select="cer:StateAndCountyFIPSCode"/>
					</td>
				</tr>
				<tr>
					<td>Tribal Code</td>
					<td>
						<xsl:value-of select="cer:TribalCode"/>
					</td>
				</tr>
				<tr>
					<td>State And Country FIPS Code</td>
					<td>
						<xsl:value-of select="cer:StateAndCountryFIPSCode"/>
					</td>
				</tr>
				<tr>
					<td>Effective Date</td>
					<td>
						<xsl:value-of select="cer:EffectiveDate"/>
					</td>
				</tr>
				<tr>
					<td>End Date</td>
					<td>
						<xsl:value-of select="cer:EndDate"/>
					</td>
				</tr>
			</table>
		</div>
	</xsl:template>
	<xsl:template match="cer:FacilitySite/cer:AlternativeFacilityName">
		<div class="indent3">
			<h2>Alternative Facility Name</h2>
			<table class="standard">
				<tr>
					<td>Alternative Name</td>
					<td>
						<xsl:value-of select="cer:AlternativeName"/>
					</td>
				</tr>
				<tr>
					<td>Program System Code</td>
					<td>
						<xsl:value-of select="cer:ProgramSystemCode"/>
					</td>
				</tr>
				<tr>
					<td>Alternative Name Type Text</td>
					<td>
						<xsl:value-of select="cer:AlternativeNameTypeText"/>
					</td>
				</tr>
				<tr>
					<td>Effective Date</td>
					<td>
						<xsl:value-of select="cer:EffectiveDate"/>
					</td>
				</tr>
			</table>
		</div>
	</xsl:template>
	<xsl:template match="cer:FacilitySite/cer:FacilitySiteAddress">
		<div class="indent3">
			<h2>Facility Site Address</h2>
			<table class="standard">
				<tr>
					<td>Mailing Address Text</td>
					<td>
						<xsl:value-of select="cer:MailingAddressText"/>
					</td>
				</tr>
				<tr>
					<td>Supplemental Address Text</td>
					<td>
						<xsl:value-of select="cer:SupplementalAddressText"/>
					</td>
				</tr>
				<tr>
					<td>Mailing Address City Name</td>
					<td>
						<xsl:value-of select="cer:MailingAddressCityName"/>
					</td>
				</tr>
				<tr>
					<td>Mailing Address County Text</td>
					<td>
						<xsl:value-of select="cer:MailingAddressCountyText"/>
					</td>
				</tr>
				<tr>
					<td>Mailing Address State Code</td>
					<td>
						<xsl:value-of select="cer:MailingAddressStateCode"/>
					</td>
				</tr>
				<tr>
					<td>Mailing Address Postal Code</td>
					<td>
						<xsl:value-of select="cer:MailingAddressPostalCode"/>
					</td>
				</tr>
				<tr>
					<td>Mailing Address Country Code</td>
					<td>
						<xsl:value-of select="cer:MailingAddressCountryCode"/>
					</td>
				</tr>
				<tr>
					<td>Location Address Text</td>
					<td>
						<xsl:value-of select="cer:LocationAddressText"/>
					</td>
				</tr>
				<tr>
					<td>Supplemental Location Text</td>
					<td>
						<xsl:value-of select="cer:SupplementalLocationText"/>
					</td>
				</tr>
				<tr>
					<td>Locality Name</td>
					<td>
						<xsl:value-of select="cer:LocalityName"/>
					</td>
				</tr>
				<tr>
					<td>Location Address State Code</td>
					<td>
						<xsl:value-of select="cer:LocationAddressStateCode"/>
					</td>
				</tr>
				<tr>
					<td>Location Address Postal Code</td>
					<td>
						<xsl:value-of select="cer:LocationAddressPostalCode"/>
					</td>
				</tr>
				<tr>
					<td>Location Address Country Code</td>
					<td>
						<xsl:value-of select="cer:LocationAddressCountryCode"/>
					</td>
				</tr>
				<tr>
					<td>Address Comment</td>
					<td>
						<xsl:value-of select="cer:AddressComment"/>
					</td>
				</tr>
			</table>
		</div>
	</xsl:template>
	<xsl:template match="cer:FacilitySite/cer:FacilitySiteGeographicCoordinates">
		<div class="indent3">
			<h2>Geographic Coordinates</h2>
			<table class="standard">
				<tr>
					<td>Latitude Measure</td>
					<td>
						<xsl:value-of select="cer:LatitudeMeasure"/>
					</td>
				</tr>
				<tr>
					<td>Longitude Measure</td>
					<td>
						<xsl:value-of select="cer:LongitudeMeasure"/>
					</td>
				</tr>
				<tr>
					<td>Source Map Scale Number</td>
					<td>
						<xsl:value-of select="cer:SourceMapScaleNumber"/>
					</td>
				</tr>
				<tr>
					<td>Horizontal Accuracy Measure</td>
					<td>
						<xsl:value-of select="cer:HorizontalAccuracyMeasure"/>
					</td>
				</tr>
				<tr>
					<td>Horizontal Accuracy Unit of Measure</td>
					<td>
						<xsl:value-of select="cer:HorizontalAccuracyUnitofMeasure"/>
					</td>
				</tr>
				<tr>
					<td>Horizontal Collection Method Code</td>
					<td>
						<xsl:value-of select="cer:HorizontalCollectionMethodCode"/>
					</td>
				</tr>
				<tr>
					<td>Horizontal Reference Datum Code</td>
					<td>
						<xsl:value-of select="cer:HorizontalReferenceDatumCode"/>
					</td>
				</tr>
				<tr>
					<td>Geographic Reference Point Code</td>
					<td>
						<xsl:value-of select="cer:GeographicReferencePointCode"/>
					</td>
				</tr>
				<tr>
					<td>Data Collection Date</td>
					<td>
						<xsl:value-of select="cer:DataCollectionDate"/>
					</td>
				</tr>
				<tr>
					<td>Geographic Comment</td>
					<td>
						<xsl:value-of select="cer:GeographicComment"/>
					</td>
				</tr>
				<tr>
					<td>Vertical Measure</td>
					<td>
						<xsl:value-of select="cer:VerticalMeasure"/>
					</td>
				</tr>
				<tr>
					<td>Vertical Unit of Measure Code</td>
					<td>
						<xsl:value-of select="cer:VerticalUnitofMeasureCode"/>
					</td>
				</tr>
				<tr>
					<td>Vertical Collection Method Code</td>
					<td>
						<xsl:value-of select="cer:VerticalCollectionMethodCode"/>
					</td>
				</tr>
				<tr>
					<td>Vertical Reference Datum Code</td>
					<td>
						<xsl:value-of select="cer:VerticalReferenceDatumCode"/>
					</td>
				</tr>
				<tr>
					<td>Verification Method Code</td>
					<td>
						<xsl:value-of select="cer:VerificationMethodCode"/>
					</td>
				</tr>
				<tr>
					<td>Coordinate Data Source Code</td>
					<td>
						<xsl:value-of select="cer:CoordinateDataSourceCode"/>
					</td>
				</tr>
				<tr>
					<td>Geometric Type Code</td>
					<td>
						<xsl:value-of select="cer:GeometricTypeCode"/>
					</td>
				</tr>
				<tr>
					<td>Area Within Perimeter</td>
					<td>
						<xsl:value-of select="cer:AreaWithinPerimeter"/>
					</td>
				</tr>
				<tr>
					<td>Area Within Perimeter Unit of Measure Code</td>
					<td>
						<xsl:value-of select="cer:AreaWithinPerimeterUnitofMeasureCode"/>
					</td>
				</tr>
				<tr>
					<td>Percent of Area Producing Emissions</td>
					<td>
						<xsl:value-of select="cer:PercentofAreaProducingEmissions"/>
					</td>
				</tr>
			</table>
		</div>
	</xsl:template>
	<xsl:template match="cer:FacilitySite/cer:FacilitySiteQualityIdentification">
		<div class="indent3">
			<h2>Quality Identification</h2>
			<table class="standard">
				<tr>
					<td>Quality Identifier</td>
					<td>
						<xsl:value-of select="cer:QualityIdentifier"/>
					</td>
				</tr>
				<tr>
					<td>Program System Code</td>
					<td>
						<xsl:value-of select="cer:ProgramSystemCode"/>
					</td>
				</tr>
			</table>
		</div>
	</xsl:template>
	<xsl:template match="cer:FacilitySite/cer:FacilitySiteAttachedFile">
		<div class="indent3">
			<h2>Attached File</h2>
			<table class="standard">
				<tr>
					<td>Attachment File Name</td>
					<td>
						<xsl:value-of select="cer:AttachmentFileName"/>
					</td>
				</tr>
				<tr>
					<td>Attachment File Description</td>
					<td>
						<xsl:value-of select="cer:AttachmentFileDescription"/>
					</td>
				</tr>
				<tr>
					<td>Attachment File Size</td>
					<td>
						<xsl:value-of select="cer:AttachmentfileSize"/>
					</td>
				</tr>
				<tr>
					<td>Attachment File Content Type Code</td>
					<td>
						<xsl:value-of select="cer:AttachmentFileContentTypeCode"/>
					</td>
				</tr>
			</table>
		</div>
	</xsl:template>
	<xsl:template match="cer:FacilitySite/cer:FacilitySiteAffiliation">
		<div class="indent3">
			<h2>Affiliation</h2>
			<table class="standard">
				<tr>
					<td>Affiliation Type Code</td>
					<td>
						<xsl:value-of select="cer:AffiliationTypeCode"/>
					</td>
				</tr>
				<tr>
					<td>Affiliation Start Date</td>
					<td>
						<xsl:value-of select="cer:AffiliationStartDate"/>
					</td>
				</tr>
				<tr>
					<td>Affiliation End Date</td>
					<td>
						<xsl:value-of select="cer:AffiliationEndDate"/>
					</td>
				</tr>
			</table>
		</div>
		<xsl:apply-templates select="cer:AffiliationOrganization"/>
		<xsl:apply-templates select="cer:AffiliationIndividual"/>
	</xsl:template>
	<xsl:template match="cer:FacilitySite/cer:FacilitySiteAffiliation/cer:AffiliationIndividual">
		<div class="indent4">
			<h2>Individual</h2>
			<table class="standard">
				<tr>
					<td>Individual Title Text</td>
					<td>
						<xsl:value-of select="cer:IndividualTitleText"/>
					</td>
				</tr>
				<tr>
					<td>Name Prefix Text</td>
					<td>
						<xsl:value-of select="cer:NamePrefixText"/>
					</td>
				</tr>
				<tr>
					<td>First Name</td>
					<td>
						<xsl:value-of select="cer:FirstName"/>
					</td>
				</tr>
				<tr>
					<td>Middle Name</td>
					<td>
						<xsl:value-of select="cer:MiddleName"/>
					</td>
				</tr>
				<tr>
					<td>Last Name</td>
					<td>
						<xsl:value-of select="cer:LastName"/>
					</td>
				</tr>
				<tr>
					<td>Name Suffix Text</td>
					<td>
						<xsl:value-of select="cer:NameSuffixText"/>
					</td>
				</tr>
			</table>
		</div>
		<xsl:apply-templates select="cer:IndividualIdentification"/>
		<xsl:apply-templates select="cer:IndividualAddress"/>
		<xsl:apply-templates select="cer:Communication"/>
	</xsl:template>
	<xsl:template match="cer:FacilitySite/cer:FacilitySiteAffiliation/cer:AffiliationIndividual/cer:IndividualIdentification">
		<div class="indent5">
			<h2>Individual Identification</h2>
			<table class="standard">
				<tr>
					<td>Individual Identifier</td>
					<td>
						<xsl:value-of select="cer:Identifier"/>
					</td>
				</tr>
				<tr>
					<td>Program System Code</td>
					<td>
						<xsl:value-of select="cer:ProgramSystemCode"/>
					</td>
				</tr>
				<tr>
					<td>Effective Date</td>
					<td>
						<xsl:value-of select="cer:EffectiveDate"/>
					</td>
				</tr>
				<tr>
					<td>End Date</td>
					<td>
						<xsl:value-of select="cer:EndDate"/>
					</td>
				</tr>
			</table>
		</div>
	</xsl:template>
	<xsl:template match="cer:FacilitySite/cer:FacilitySiteAffiliation/cer:AffiliationIndividual/cer:IndividualAddress">
		<div class="indent5">
			<h2>Address</h2>
			<table class="standard">
				<tr>
					<td>Mailing Address Text</td>
					<td>
						<xsl:value-of select="cer:MailingAddressText"/>
					</td>
				</tr>
				<tr>
					<td>Supplemental Address Text</td>
					<td>
						<xsl:value-of select="cer:SupplementalAddressText"/>
					</td>
				</tr>
				<tr>
					<td>Mailing Address City Name</td>
					<td>
						<xsl:value-of select="cer:MailingAddressCityName"/>
					</td>
				</tr>
				<tr>
					<td>Mailing Address County Text</td>
					<td>
						<xsl:value-of select="cer:MailingAddressCountyText"/>
					</td>
				</tr>
				<tr>
					<td>Mailing Address State Code</td>
					<td>
						<xsl:value-of select="cer:MailingAddressStateCode"/>
					</td>
				</tr>
				<tr>
					<td>Mailing Address Postal Code</td>
					<td>
						<xsl:value-of select="cer:MailingAddressPostalCode"/>
					</td>
				</tr>
				<tr>
					<td>Mailing Address Country Code</td>
					<td>
						<xsl:value-of select="cer:MailingAddressCountryCode"/>
					</td>
				</tr>
				<tr>
					<td>Location Address Text</td>
					<td>
						<xsl:value-of select="cer:LocationAddressText"/>
					</td>
				</tr>
				<tr>
					<td>Supplemental Location Text</td>
					<td>
						<xsl:value-of select="cer:SupplementalLocationText"/>
					</td>
				</tr>
				<tr>
					<td>Locality Name</td>
					<td>
						<xsl:value-of select="cer:LocalityName"/>
					</td>
				</tr>
				<tr>
					<td>Location Address State Code</td>
					<td>
						<xsl:value-of select="cer:LocationAddressStateCode"/>
					</td>
				</tr>
				<tr>
					<td>Location Address Postal Code</td>
					<td>
						<xsl:value-of select="cer:LocationAddressPostalCode"/>
					</td>
				</tr>
				<tr>
					<td>Location Address Country Code</td>
					<td>
						<xsl:value-of select="cer:LocationAddressCountryCode"/>
					</td>
				</tr>
				<tr>
					<td>Address Comment</td>
					<td>
						<xsl:value-of select="cer:AddressComment"/>
					</td>
				</tr>
			</table>
		</div>
	</xsl:template>
	<xsl:template match="cer:FacilitySite/cer:FacilitySiteAffiliation/cer:AffiliationIndividual/cer:Communication">
		<div class="indent5">
			<h2>Communication</h2>
			<table class="standard">
				<tr>
					<td>Telephone Number Text</td>
					<td>
						<xsl:value-of select="cer:TelephoneNumberText"/>
					</td>
				</tr>
				<tr>
					<td>Telephone Number Type Name</td>
					<td>
						<xsl:value-of select="cer:TelephoneNumberTypeName"/>
					</td>
				</tr>
				<tr>
					<td>Telephone Extension Number Text</td>
					<td>
						<xsl:value-of select="cer:TelephoneExtensionNumberText"/>
					</td>
				</tr>
				<tr>
					<td>Electronic Address Text</td>
					<td>
						<xsl:value-of select="cer:ElectronicAddressText"/>
					</td>
				</tr>
				<tr>
					<td>Electronic Address Type Name</td>
					<td>
						<xsl:value-of select="cer:ElectronicAddressTypeName"/>
					</td>
				</tr>
			</table>
		</div>
	</xsl:template>
	<xsl:template match="cer:FacilitySite/cer:FacilitySiteAffiliation/cer:AffiliationOrganization">
		<div class="indent4">
			<h2>Organization</h2>
			<table class="standard">
				<tr>
					<td>Organization Name</td>
					<td>
						<xsl:value-of select="cer:OrganizationFormalName"/>
					</td>
				</tr>
				<tr>
					<td>Percent Ownership</td>
					<td>
						<xsl:value-of select="cer:PercentOwnership"/>
					</td>
				</tr>
				<tr>
					<td>Consolidation Methodology</td>
					<td>
						<xsl:value-of select="cer:ConsolidationMethodology"/>
					</td>
				</tr>
			</table>
		</div>
		<xsl:apply-templates select="cer:OrganizationIdentification"/>
		<xsl:apply-templates select="cer:OrganizationAddress"/>
		<xsl:apply-templates select="cer:OrganizationCommunication"/>
		<xsl:apply-templates select="cer:OrganizationIndividual"/>
		<xsl:apply-templates select="cer:OrganizationAttachedFile"/>
	</xsl:template>
	<xsl:template match="cer:FacilitySite/cer:Affiliation/cer:Organization/cer:OrganizationIdentification">
		<div class="indent5">
			<h2>Organization Identification</h2>
			<table class="standard">
				<tr>
					<td>Organization Identifier</td>
					<td>
						<xsl:value-of select="cer:Identifier"/>
					</td>
				</tr>
				<tr>
					<td>Program System Code</td>
					<td>
						<xsl:value-of select="cer:ProgramSystemCode"/>
					</td>
				</tr>
				<tr>
					<td>Effective Date</td>
					<td>
						<xsl:value-of select="cer:EffectiveDate"/>
					</td>
				</tr>
				<tr>
					<td>End Date</td>
					<td>
						<xsl:value-of select="cer:EndDate"/>
					</td>
				</tr>
			</table>
		</div>
	</xsl:template>
	<xsl:template match="cer:FacilitySite/cer:Affiliation/cer:Organization/cer:OrganizationAddress">
		<div class="indent5">
			<h2>Address</h2>
			<table class="standard">
				<tr>
					<td>Mailing Address Text</td>
					<td>
						<xsl:value-of select="cer:MailingAddressText"/>
					</td>
				</tr>
				<tr>
					<td>Supplemental Address Text</td>
					<td>
						<xsl:value-of select="cer:SupplementalAddressText"/>
					</td>
				</tr>
				<tr>
					<td>Mailing Address City Name</td>
					<td>
						<xsl:value-of select="cer:MailingAddressCityName"/>
					</td>
				</tr>
				<tr>
					<td>Mailing Address County Text</td>
					<td>
						<xsl:value-of select="cer:MailingAddressCountyText"/>
					</td>
				</tr>
				<tr>
					<td>Mailing Address State Code</td>
					<td>
						<xsl:value-of select="cer:MailingAddressStateCode"/>
					</td>
				</tr>
				<tr>
					<td>Mailing Address Postal Code</td>
					<td>
						<xsl:value-of select="cer:MailingAddressPostalCode"/>
					</td>
				</tr>
				<tr>
					<td>Mailing Address Country Code</td>
					<td>
						<xsl:value-of select="cer:MailingAddressCountryCode"/>
					</td>
				</tr>
				<tr>
					<td>Location Address Text</td>
					<td>
						<xsl:value-of select="cer:LocationAddressText"/>
					</td>
				</tr>
				<tr>
					<td>Supplemental Location Text</td>
					<td>
						<xsl:value-of select="cer:SupplementalLocationText"/>
					</td>
				</tr>
				<tr>
					<td>Locality Name</td>
					<td>
						<xsl:value-of select="cer:LocalityName"/>
					</td>
				</tr>
				<tr>
					<td>Location Address State Code</td>
					<td>
						<xsl:value-of select="cer:LocationAddressStateCode"/>
					</td>
				</tr>
				<tr>
					<td>Location Address Postal Code</td>
					<td>
						<xsl:value-of select="cer:LocationAddressPostalCode"/>
					</td>
				</tr>
				<tr>
					<td>Location Address Country Code</td>
					<td>
						<xsl:value-of select="cer:LocationAddressCountryCode"/>
					</td>
				</tr>
				<tr>
					<td>Address Comment</td>
					<td>
						<xsl:value-of select="cer:AddressComment"/>
					</td>
				</tr>
			</table>
		</div>
	</xsl:template>
	<xsl:template match="cer:FacilitySite/cer:Affiliation/cer:Organization/cer:OrganizationCommunication">
		<div class="indent5">
			<h2>Communication</h2>
			<table class="standard">
				<tr>
					<td>Telephone Number Text</td>
					<td>
						<xsl:value-of select="cer:TelephoneNumberText"/>
					</td>
				</tr>
				<tr>
					<td>Telephone Number Type Name</td>
					<td>
						<xsl:value-of select="cer:TelephoneNumberTypeName"/>
					</td>
				</tr>
				<tr>
					<td>Telephone Extension Number Text</td>
					<td>
						<xsl:value-of select="cer:TelephoneExtensionNumberText"/>
					</td>
				</tr>
				<tr>
					<td>Electronic Address Text</td>
					<td>
						<xsl:value-of select="cer:ElectronicAddressText"/>
					</td>
				</tr>
				<tr>
					<td>Electronic Address Type Name</td>
					<td>
						<xsl:value-of select="cer:ElectronicAddressTypeName"/>
					</td>
				</tr>
			</table>
		</div>
	</xsl:template>
	<xsl:template match="cer:FacilitySite/cer:Affiliation/cer:Organization/cer:OrganizationAttachedFile">
		<div class="indent5">
			<h2>Attached File</h2>
			<table class="standard">
				<tr>
					<td>Attachment File Name</td>
					<td>
						<xsl:value-of select="cer:AttachmentFileName"/>
					</td>
				</tr>
				<tr>
					<td>Attachment File Description</td>
					<td>
						<xsl:value-of select="cer:AttachmentFileDescription"/>
					</td>
				</tr>
				<tr>
					<td>Attachment File Size</td>
					<td>
						<xsl:value-of select="cer:AttachmentfileSize"/>
					</td>
				</tr>
				<tr>
					<td>Attachment File Content Type Code</td>
					<td>
						<xsl:value-of select="cer:AttachmentFileContentTypeCode"/>
					</td>
				</tr>
			</table>
		</div>
	</xsl:template>
	<xsl:template match="cer:FacilitySite/cer:EmissionsUnit">
		<div class="indent3">
			<h2>Emissions Unit</h2>
			<table class="standard">
				<tr>
					<td>Scope</td>
					<td>
						<xsl:value-of select="cer:Scope"/>
					</td>
				</tr>
				<tr>
					<td>Unit Description</td>
					<td>
						<xsl:value-of select="cer:UnitDescription"/>
					</td>
				</tr>
				<tr>
					<td>Unit Type Code</td>
					<td>
						<xsl:value-of select="cer:UnitTypeCode"/>
					</td>
				</tr>
				<tr>
					<td>Unit Source Location</td>
					<td>
						<xsl:value-of select="cer:UnitSourceLocation"/>
					</td>
				</tr>
				<tr>
					<td>Insignificant Source Indicator</td>
					<td>
						<xsl:value-of select="cer:InsignificantSourceIndicator"/>
					</td>
				</tr>
				<tr>
					<td>Unit Design Capacity</td>
					<td>
						<xsl:value-of select="cer:UnitDesignCapacity"/>
					</td>
				</tr>
				<tr>
					<td>Unit Design Capacity Unit of Measure Code</td>
					<td>
						<xsl:value-of select="cer:UnitDesignCapacityUnitofMeasureCode"/>
					</td>
				</tr>
				<tr>
					<td>Unit Status Code</td>
					<td>
						<xsl:value-of select="cer:UnitStatusCode"/>
					</td>
				</tr>
				<tr>
					<td>Unit Status Code Year</td>
					<td>
						<xsl:value-of select="cer:UnitStatusCodeYear"/>
					</td>
				</tr>
				<tr>
					<td>Unit Operation Date</td>
					<td>
						<xsl:value-of select="cer:UnitOperationDate"/>
					</td>
				</tr>
				<tr>
					<td>Unit Commercial Operation Date</td>
					<td>
						<xsl:value-of select="cer:UnitCommercialOperationDate"/>
					</td>
				</tr>
				<tr>
					<td>Unit Comment</td>
					<td>
						<xsl:value-of select="cer:UnitComment "/>
					</td>
				</tr>
			</table>
		</div>
		<xsl:apply-templates select="cer:UnitIdentification"/>
		<xsl:apply-templates select="cer:UnitQualityIdentification"/>
		<xsl:apply-templates select="cer:UnitRegulation"/>
		<xsl:apply-templates select="cer:UnitControlApproach"/>
		<xsl:apply-templates select="cer:UnitEmissionsProcess"/>
	</xsl:template>
	<xsl:template match="cer:FacilitySite/cer:EmissionsUnit/cer:UnitIdentification">
		<div class="indent4">
			<h2>Unit Identification</h2>
			<table class="standard">
				<tr>
					<td>Unit Identifier</td>
					<td>
						<xsl:value-of select="cer:Identifier"/>
					</td>
				</tr>
				<tr>
					<td>Program System Code</td>
					<td>
						<xsl:value-of select="cer:ProgramSystemCode"/>
					</td>
				</tr>
				<tr>
					<td>Effective Date</td>
					<td>
						<xsl:value-of select="cer:EffectiveDate"/>
					</td>
				</tr>
				<tr>
					<td>End Date</td>
					<td>
						<xsl:value-of select="cer:EndDate"/>
					</td>
				</tr>
			</table>
		</div>
	</xsl:template>
	<xsl:template match="cer:FacilitySite/cer:EmissionsUnit/cer:UnitQualityIdentification">
		<div class="indent4">
			<h2>Quality Identification</h2>
			<table class="standard">
				<tr>
					<td>Quality Identifier</td>
					<td>
						<xsl:value-of select="cer:QualityIdentifier"/>
					</td>
				</tr>
				<tr>
					<td>Program System Code</td>
					<td>
						<xsl:value-of select="cer:ProgramSystemCode"/>
					</td>
				</tr>
			</table>
		</div>
	</xsl:template>
	<xsl:template match="cer:FacilitySite/cer:EmissionsUnit/cer:UnitRegulation">
		<div class="indent4">
			<h2>Regulation</h2>
			<table class="standard">
				<tr>
					<td>Regulatory Code</td>
					<td>
						<xsl:value-of select="cer:RegulatoryCode"/>
					</td>
				</tr>
				<tr>
					<td>Agency Code Text</td>
					<td>
						<xsl:value-of select="cer:AgencyCodeText"/>
					</td>
				</tr>
				<tr>
					<td>Regulatory Start Year</td>
					<td>
						<xsl:value-of select="cer:RegulatoryStartYear"/>
					</td>
				</tr>
				<tr>
					<td>Regulatory End Year</td>
					<td>
						<xsl:value-of select="cer:RegulatoryEndYear"/>
					</td>
				</tr>
				<tr>
					<td>Regulation Comment</td>
					<td>
						<xsl:value-of select="cer:RegulationComment"/>
					</td>
				</tr>
			</table>
		</div>
	</xsl:template>
	<xsl:template match="cer:FacilitySite/cer:EmissionsUnit/cer:UnitControlApproach">
		<div class="indent4">
			<h2>Control Approach</h2>
			<table class="standard">
				<tr>
					<td>Control Approach Description</td>
					<td>
						<xsl:value-of select="cer:ControlApproachDescription"/>
					</td>
				</tr>
				<tr>
					<td>Percent Control Approach Capture Efficiency</td>
					<td>
						<xsl:value-of select="cer:PercentControlApproachCaptureEfficiency"/>
					</td>
				</tr>
				<tr>
					<td>Percent Control Approach Effectiveness</td>
					<td>
						<xsl:value-of select="cer:PercentControlApproachEffectiveness"/>
					</td>
				</tr>
				<tr>
					<td>Percent Control Approach Penetration</td>
					<td>
						<xsl:value-of select="cer:PercentControlApproachPenetration"/>
					</td>
				</tr>
				<tr>
					<td>First Inventory Year</td>
					<td>
						<xsl:value-of select="cer:FirstInventoryYear"/>
					</td>
				</tr>
				<tr>
					<td>Last Inventory Year</td>
					<td>
						<xsl:value-of select="cer:LastInventoryYear"/>
					</td>
				</tr>
				<tr>
					<td>Control Approach Comment</td>
					<td>
						<xsl:value-of select="cer:ControlApproachComment"/>
					</td>
				</tr>
			</table>
		</div>
		<xsl:apply-templates select="cer:ControlMeasure"/>
		<xsl:apply-templates select="cer:ControlPollutant"/>
	</xsl:template>
	<xsl:template match="cer:FacilitySite/cer:EmissionsUnit/cer:UnitControlApproach/cer:ControlMeasure">
		<div class="indent5">
			<h2>ControlMeasure</h2>
			<table class="standard">
				<tr>
					<td>Control Measure Code</td>
					<td>
						<xsl:value-of select="cer:ControlMeasureCode"/>
					</td>
				</tr>
				<tr>
					<td>Control Measure Sequence</td>
					<td>
						<xsl:value-of select="cer:ControlMeasureSequence"/>
					</td>
				</tr>
			</table>
		</div>
	</xsl:template>
	<xsl:template match="cer:FacilitySite/cer:EmissionsUnit/cer:UnitControlApproach/cer:ControlPollutant">
		<div class="indent5">
			<h2>Control Pollutant</h2>
			<table class="standard">
				<tr>
					<td>Pollutant Code</td>
					<td>
						<xsl:value-of select="cer:PollutantCode"/>
					</td>
				</tr>
				<tr>
					<td>Percent Control Measures Reduction Efficiency</td>
					<td>
						<xsl:value-of select="cer:PercentControlMeasuresReductionEfficiency"/>
					</td>
				</tr>
			</table>
		</div>
	</xsl:template>
	<xsl:template match="cer:FacilitySite/cer:EmissionsUnit/cer:UnitEmissionsProcess">
		<div class="indent4">
			<h2>Emissions Process</h2>
			<table class="standard">
				<tr>
					<td>Source Classification Code</td>
					<td>
						<xsl:value-of select="cer:SourceClassificationCode"/>
					</td>
				</tr>
				<tr>
					<td>Emissions Type Code</td>
					<td>
						<xsl:value-of select="cer:EmissionsTypeCode"/>
					</td>
				</tr>
				<tr>
					<td>Aircraft Engine Type Code</td>
					<td>
						<xsl:value-of select="cer:AircraftEngineTypeCode"/>
					</td>
				</tr>
				<tr>
					<td>Process Type Code</td>
					<td>
						<xsl:value-of select="cer:ProcessTypeCode"/>
					</td>
				</tr>
				<tr>
					<td>Process Description</td>
					<td>
						<xsl:value-of select="cer:ProcessDescription"/>
					</td>
				</tr>
				<tr>
					<td>Last Emissions Year</td>
					<td>
						<xsl:value-of select="cer:LastEmissionsYear"/>
					</td>
				</tr>
				<tr>
					<td>Process Comment</td>
					<td>
						<xsl:value-of select="cer:ProcessComment"/>
					</td>
				</tr>
			</table>
		</div>
		<xsl:apply-templates select="cer:ProcessIdentification"/>
		<xsl:apply-templates select="cer:ProcessRegulation"/>
		<xsl:apply-templates select="cer:ProcessControlApproach"/>
		<xsl:apply-templates select="cer:ReportingPeriod"/>
		<xsl:apply-templates select="cer:ReleasePointApportionment"/>
	</xsl:template>
	<xsl:template match="cer:FacilitySite/cer:EmissionsUnit/cer:UnitEmissionsProcess/cer:ProcessIdentification">
		<div class="indent5">
			<h2>Emissions Process Identification</h2>
			<table class="standard">
				<tr>
					<td>Emissions Process Identifier</td>
					<td>
						<xsl:value-of select="cer:Identifier"/>
					</td>
				</tr>
				<tr>
					<td>Program System Code</td>
					<td>
						<xsl:value-of select="cer:ProgramSystemCode"/>
					</td>
				</tr>
				<tr>
					<td>Effective Date</td>
					<td>
						<xsl:value-of select="cer:EffectiveDate"/>
					</td>
				</tr>
				<tr>
					<td>End Date</td>
					<td>
						<xsl:value-of select="cer:EndDate"/>
					</td>
				</tr>
			</table>
		</div>
	</xsl:template>
	<xsl:template match="cer:FacilitySite/cer:EmissionsUnit/cer:UnitEmissionsProcess/cer:ProcessRegulation">
		<div class="indent5">
			<h2>Regulation</h2>
			<table class="standard">
				<tr>
					<td>Regulatory Code</td>
					<td>
						<xsl:value-of select="cer:RegulatoryCode"/>
					</td>
				</tr>
				<tr>
					<td>Agency Code Text</td>
					<td>
						<xsl:value-of select="cer:AgencyCodeText"/>
					</td>
				</tr>
				<tr>
					<td>Regulatory Start Year</td>
					<td>
						<xsl:value-of select="cer:RegulatoryStartYear"/>
					</td>
				</tr>
				<tr>
					<td>Regulatory End Year</td>
					<td>
						<xsl:value-of select="cer:RegulatoryEndYear"/>
					</td>
				</tr>
				<tr>
					<td>Regulation Comment</td>
					<td>
						<xsl:value-of select="cer:RegulationComment"/>
					</td>
				</tr>
			</table>
		</div>
	</xsl:template>
	<xsl:template match="cer:FacilitySite/cer:EmissionsUnit/cer:UnitEmissionsProcess/cer:ProcessControlApproach">
		<div class="indent5">
			<h2>Control Approach</h2>
			<table class="standard">
				<tr>
					<td>Control Approach Description</td>
					<td>
						<xsl:value-of select="cer:ControlApproachDescription"/>
					</td>
				</tr>
				<tr>
					<td>Percent Control Approach Capture Efficiency</td>
					<td>
						<xsl:value-of select="cer:PercentControlApproachCaptureEfficiency"/>
					</td>
				</tr>
				<tr>
					<td>Percent Control Approach Effectiveness</td>
					<td>
						<xsl:value-of select="cer:PercentControlApproachEffectiveness"/>
					</td>
				</tr>
				<tr>
					<td>Percent Control Approach Penetration</td>
					<td>
						<xsl:value-of select="cer:PercentControlApproachPenetration"/>
					</td>
				</tr>
				<tr>
					<td>First Inventory Year</td>
					<td>
						<xsl:value-of select="cer:FirstInventoryYear"/>
					</td>
				</tr>
				<tr>
					<td>Last Inventory Year</td>
					<td>
						<xsl:value-of select="cer:LastInventoryYear"/>
					</td>
				</tr>
				<tr>
					<td>Control Approach Comment</td>
					<td>
						<xsl:value-of select="cer:ControlApproachComment"/>
					</td>
				</tr>
			</table>
		</div>
		<xsl:apply-templates select="cer:ControlMeasure"/>
		<xsl:apply-templates select="cer:ControlPollutant"/>
	</xsl:template>
	<xsl:template match="cer:FacilitySite/cer:EmissionsUnit/cer:UnitEmissionsProcess/cer:ProcessControlApproach/cer:ControlMeasure">
		<div class="indent6">
			<h2>ControlMeasure</h2>
			<table class="standard">
				<tr>
					<td>Control Measure Code</td>
					<td>
						<xsl:value-of select="cer:ControlMeasureCode"/>
					</td>
				</tr>
				<tr>
					<td>Control Measure Sequence</td>
					<td>
						<xsl:value-of select="cer:ControlMeasureSequence"/>
					</td>
				</tr>
			</table>
		</div>
	</xsl:template>
	<xsl:template match="cer:FacilitySite/cer:EmissionsUnit/cer:UnitEmissionsProcess/cer:ProcessControlApproach/cer:ControlPollutant">
		<div class="indent6">
			<h2>Control Pollutant</h2>
			<table class="standard">
				<tr>
					<td>Pollutant Code</td>
					<td>
						<xsl:value-of select="cer:PollutantCode"/>
					</td>
				</tr>
				<tr>
					<td>Percent Control Measures Reduction Efficiency</td>
					<td>
						<xsl:value-of select="cer:PercentControlMeasuresReductionEfficiency"/>
					</td>
				</tr>
			</table>
		</div>
	</xsl:template>
	<xsl:template match="cer:FacilitySite/cer:EmissionsUnit/cer:UnitEmissionsProcess/cer:ReleasePointApportionment">
		<div class="indent5">
			<h2>Release Point Apportionment</h2>
			<table class="standard">
				<tr>
					<td>Average Percent Emissions</td>
					<td>
						<xsl:value-of select="cer:AveragePercentEmissions"/>
					</td>
				</tr>
				<tr>
					<td>Release Point Apportionment Comment</td>
					<td>
						<xsl:value-of select="cer:ReleasePointApportionmentComment"/>
					</td>
				</tr>
			</table>
		</div>
		<xsl:apply-templates select="cer:ReleasePointApportionmentIdentification"/>
	</xsl:template>
	<xsl:template match="cer:FacilitySite/cer:EmissionsUnit/cer:UnitEmissionsProcess/cer:ReleasePointApportionment/cer:ReleasePointApportionmentIdentification">
		<div class="indent6">
			<h2>Release Point Identification</h2>
			<table class="standard">
				<tr>
					<td>Release Point Identifier</td>
					<td>
						<xsl:value-of select="cer:Identifier"/>
					</td>
				</tr>
				<tr>
					<td>Program System Code</td>
					<td>
						<xsl:value-of select="cer:ProgramSystemCode"/>
					</td>
				</tr>
				<tr>
					<td>Effective Date</td>
					<td>
						<xsl:value-of select="cer:EffectiveDate"/>
					</td>
				</tr>
				<tr>
					<td>End Date</td>
					<td>
						<xsl:value-of select="cer:EndDate"/>
					</td>
				</tr>
			</table>
		</div>
	</xsl:template>
	<xsl:template match="cer:FacilitySite/cer:EmissionsUnit/cer:UnitEmissionsProcess/cer:ReportingPeriod">
		<div class="indent5">
			<h2>Reporting Period</h2>
			<table class="standard">
				<tr>
					<td>Reporting Period Type Code</td>
					<td>
						<xsl:value-of select="cer:ReportingPeriodTypeCode"/>
					</td>
				</tr>
				<tr>
					<td>Emission Operating Type Code</td>
					<td>
						<xsl:value-of select="cer:EmissionOperatingTypeCode"/>
					</td>
				</tr>
				<tr>
					<td>Effective Date</td>
					<td>
						<xsl:value-of select="cer:StartDate"/>
					</td>
				</tr>
				<tr>
					<td>End Date</td>
					<td>
						<xsl:value-of select="cer:EndDate"/>
					</td>
				</tr>
				<tr>
					<td>Calculation Parameter Type Code</td>
					<td>
						<xsl:value-of select="cer:CalculationParameterTypeCode"/>
					</td>
				</tr>
				<tr>
					<td>Calculation Parameter Value</td>
					<td>
						<xsl:value-of select="cer:CalculationParameterValue"/>
					</td>
				</tr>
				<tr>
					<td>Calculation Parameter Unit of Measure</td>
					<td>
						<xsl:value-of select="cer:CalculationParameterUnitofMeasure"/>
					</td>
				</tr>
				<tr>
					<td>Calculation Material Code</td>
					<td>
						<xsl:value-of select="cer:CalculationMaterialCode"/>
					</td>
				</tr>
				<tr>
					<td>Calculation Data Year</td>
					<td>
						<xsl:value-of select="cer:CalculationDataYear"/>
					</td>
				</tr>
				<tr>
					<td>Calculation Data Source</td>
					<td>
						<xsl:value-of select="cer:CalculationDataSource"/>
					</td>
				</tr>
				<tr>
					<td>Reporting Period Comment</td>
					<td>
						<xsl:value-of select="cer:ReportingPeriodComment"/>
					</td>
				</tr>
			</table>
		</div>
		<xsl:apply-templates select="cer:QualityIdentification"/>
		<xsl:apply-templates select="cer:OperatingDetails"/>
		<xsl:apply-templates select="cer:SupplementalCalculationParameter"/>
		<xsl:apply-templates select="cer:ReportingPeriodEmissions"/>
	</xsl:template>
	<xsl:template match="cer:FacilitySite/cer:EmissionsUnit/cer:UnitEmissionsProcess/cer:ReportingPeriod/cer:QualityIdentification">
		<div class="indent6">
			<h2>Quality Identification</h2>
			<table class="standard">
				<tr>
					<td>Quality Identifier</td>
					<td>
						<xsl:value-of select="cer:QualityIdentifier"/>
					</td>
				</tr>
				<tr>
					<td>Program System Code</td>
					<td>
						<xsl:value-of select="cer:ProgramSystemCode"/>
					</td>
				</tr>
			</table>
		</div>
	</xsl:template>
	<xsl:template match="cer:FacilitySite/cer:EmissionsUnit/cer:UnitEmissionsProcess/cer:ReportingPeriod/cer:OperatingDetails">
		<div class="indent6">
			<h2>Operating Details</h2>
			<table class="standard">
				<tr>
					<td>Actual Hours Per Period</td>
					<td>
						<xsl:value-of select="cer:ActualHoursPerPeriod"/>
					</td>
				</tr>
				<tr>
					<td>Average Days Per Week</td>
					<td>
						<xsl:value-of select="cer:AverageDaysPerWeek"/>
					</td>
				</tr>
				<tr>
					<td>Average Hours Per Day</td>
					<td>
						<xsl:value-of select="cer:AverageHoursPerDay"/>
					</td>
				</tr>
				<tr>
					<td>Average Weeks Per Period</td>
					<td>
						<xsl:value-of select="cer:AverageWeeksPerPeriod"/>
					</td>
				</tr>
				<tr>
					<td>Percent Winter Activity</td>
					<td>
						<xsl:value-of select="cer:PercentWinterActivity"/>
					</td>
				</tr>
				<tr>
					<td>Percent Spring Activity</td>
					<td>
						<xsl:value-of select="cer:PercentSpringActivity"/>
					</td>
				</tr>
				<tr>
					<td>Percent Summer Activity</td>
					<td>
						<xsl:value-of select="cer:PercentSummerActivity"/>
					</td>
				</tr>
				<tr>
					<td>Percent Fall Activity</td>
					<td>
						<xsl:value-of select="cer:PercentFallActivity"/>
					</td>
				</tr>
			</table>
		</div>
	</xsl:template>
	<xsl:template match="cer:FacilitySite/cer:EmissionsUnit/cer:UnitEmissionsProcess/cer:ReportingPeriod/cer:SupplementalCalculationParameter">
		<div class="indent6">
			<h2>Supplemental Calculation Parameter</h2>
			<table class="standard">
				<tr>
					<td>Supplemental Parameter Type</td>
					<td>
						<xsl:value-of select="cer:SupplementalCalculationParameterType"/>
					</td>
				</tr>
				<tr>
					<td>Supplemental Parameter Value</td>
					<td>
						<xsl:value-of select="cer:SupplementalCalculationParameterValue"/>
					</td>
				</tr>
				<tr>
					<td>Supplemental Calculation Parameter Numerator Unit of Measure Code</td>
					<td>
						<xsl:value-of select="cer:SupplementalCalculationParameterNumeratorUnitofMeasureCode"/>
					</td>
				</tr>
				<tr>
					<td>Supplemental Calculation Parameter Denominator Unit of Measure Code</td>
					<td>
						<xsl:value-of select="cer:SupplementalCalculationParameterDenominatorUnitofMeasureCode"/>
					</td>
				</tr>
				<tr>
					<td>Supplemental Parameter Data Year</td>
					<td>
						<xsl:value-of select="cer:SupplementalCalculationParameterDataYear"/>
					</td>
				</tr>
				<tr>
					<td>Supplemental Parameter Data Source</td>
					<td>
						<xsl:value-of select="cer:SupplementalCalculationParameterDataSource"/>
					</td>
				</tr>
				<tr>
					<td>Supplemental Parameter Comment</td>
					<td>
						<xsl:value-of select="cer:SupplementalCalculationParameterComment"/>
					</td>
				</tr>
			</table>
		</div>
	</xsl:template>
	<xsl:template match="cer:FacilitySite/cer:EmissionsUnit/cer:UnitEmissionsProcess/cer:ReportingPeriod/cer:ReportingPeriodEmissions">
		<div class="indent6">
			<h2>Emissions</h2>
			<table class="standard">
				<tr>
					<td>Pollutant Code</td>
					<td>
						<xsl:value-of select="cer:PollutantCode"/>
					</td>
				</tr>
				<tr>
					<td>Total Emissions</td>
					<td>
						<xsl:value-of select="cer:TotalEmissions"/>
					</td>
				</tr>
				<tr>
					<td>Emissions Unit of Measure Code</td>
					<td>
						<xsl:value-of select="cer:EmissionsUnitofMeasureCode"/>
					</td>
				</tr>
				<tr>
					<td>Emission Factor</td>
					<td>
						<xsl:value-of select="cer:EmissionFactor"/>
					</td>
				</tr>
				<tr>
					<td>Emission Factor Numerator Unit of Measure Code</td>
					<td>
						<xsl:value-of select="cer:EmissionFactorNumeratorUnitofMeasureCode"/>
					</td>
				</tr>
				<tr>
					<td>Emission Factor Denominator Unit of Measure Code</td>
					<td>
						<xsl:value-of select="cer:EmissionFactorDenominatorUnitofMeasureCode"/>
					</td>
				</tr>
				<tr>
					<td>Emission Factor Formula Code</td>
					<td>
						<xsl:value-of select="cer:EmissionFactorFormulaCode"/>
					</td>
				</tr>
				<tr>
					<td>Emission Factor Text</td>
					<td>
						<xsl:value-of select="cer:EmissionFactorText"/>
					</td>
				</tr>
				<tr>
					<td>Emissions Calculation Method Code</td>
					<td>
						<xsl:value-of select="cer:EmissionsCalculationMethodCode"/>
					</td>
				</tr>
				<tr>
					<td>Emission Factor Reference Text</td>
					<td>
						<xsl:value-of select="cer:EmissionFactorReferenceText"/>
					</td>
				</tr>
				<tr>
					<td>Algorithm Formula Text</td>
					<td>
						<xsl:value-of select="cer:AlgorithmFormulaText"/>
					</td>
				</tr>
				<tr>
					<td>Algorithm Comment</td>
					<td>
						<xsl:value-of select="cer:AlgorithmComment"/>
					</td>
				</tr>
				<tr>
					<td>Calculation Method Accuracy Assessment Code</td>
					<td>
						<xsl:value-of select="cer:CalculationMethodAccuracyAssessmentCode"/>
					</td>
				</tr>
				<tr>
					<td>Emissions DeMinimis Status</td>
					<td>
						<xsl:value-of select="cer:EmissionsDeMinimisStatus"/>
					</td>
				</tr>
				<tr>
					<td>Emissions Comment</td>
					<td>
						<xsl:value-of select="cer:EmissionsComment"/>
					</td>
				</tr>
			</table>
		</div>
		<xsl:apply-templates select="cer:CO2Equivalent"/>
	</xsl:template>
	<xsl:template match="cer:FacilitySite/cer:EmissionsUnit/cer:UnitEmissionsProcess/cer:ReportingPeriod/cer:ReportingPeriodEmissions/cer:CO2Equivalent">
		<div class="indent7">
			<h2>CO2 Equivalent</h2>
			<table class="standard">
				<tr>
					<td>CO2e</td>
					<td>
						<xsl:value-of select="cer:CO2e"/>
					</td>
				</tr>
				<tr>
					<td>CO2e Unit of Measure Code</td>
					<td>
						<xsl:value-of select="cer:CO2eUnitofMeasureCode"/>
					</td>
				</tr>
				<tr>
					<td>CO2 Conversion Factor</td>
					<td>
						<xsl:value-of select="cer:CO2ConversionFactor"/>
					</td>
				</tr>
				<tr>
					<td>CO2 Conversion Factor Source</td>
					<td>
						<xsl:value-of select="cer:CO2ConversionFactorSource"/>
					</td>
				</tr>
			</table>
		</div>
	</xsl:template>
	<xsl:template match="cer:FacilitySite/cer:ReleasePoint">
		<div class="indent3">
			<h2>Release Point</h2>
			<table class="standard">
				<tr>
					<td>Release Point Type Code</td>
					<td>
						<xsl:value-of select="cer:ReleasePointTypeCode"/>
					</td>
				</tr>
				<tr>
					<td>Release Point Description</td>
					<td>
						<xsl:value-of select="cer:ReleasePointDescription"/>
					</td>
				</tr>
				<tr>
					<td>Release Point Stack Height Measure</td>
					<td>
						<xsl:value-of select="cer:ReleasePointStackHeightMeasure"/>
					</td>
				</tr>
				<tr>
					<td>Release Point Stack Height Unit of Measure Code</td>
					<td>
						<xsl:value-of select="cer:ReleasePointStackHeightUnitofMeasureCode"/>
					</td>
				</tr>
				<tr>
					<td>Release Point Stack Diameter Measure</td>
					<td>
						<xsl:value-of select="cer:ReleasePointStackDiameterMeasure"/>
					</td>
				</tr>
				<tr>
					<td>Release Point Stack Diameter Unit of Measure Code</td>
					<td>
						<xsl:value-of select="cer:ReleasePointStackDiameterUnitofMeasureCode"/>
					</td>
				</tr>
				<tr>
					<td>Release Point Exit Gas Velocity Measure</td>
					<td>
						<xsl:value-of select="cer:ReleasePointExitGasVelocityMeasure"/>
					</td>
				</tr>
				<tr>
					<td>Release Point Exit Gas Velocity Unit of Measure Code</td>
					<td>
						<xsl:value-of select="cer:ReleasePointExitGasVelocityUnitofMeasureCode"/>
					</td>
				</tr>
				<tr>
					<td>Release Point Exit Gas Flow Rate Measure</td>
					<td>
						<xsl:value-of select="cer:ReleasePointExitGasFlowRateMeasure"/>
					</td>
				</tr>
				<tr>
					<td>Release Point Exit Gas Flow Rate Unit of Measure Code</td>
					<td>
						<xsl:value-of select="cer:ReleasePointExitGasFlowRateUnitofMeasureCode"/>
					</td>
				</tr>
				<tr>
					<td>Release Point Exit Gas Temperature Measure</td>
					<td>
						<xsl:value-of select="cer:ReleasePointExitGasTemperatureMeasure"/>
					</td>
				</tr>
				<tr>
					<td>Release Point FenceLine Distance Measure</td>
					<td>
						<xsl:value-of select="cer:ReleasePointFenceLineDistanceMeasure"/>
					</td>
				</tr>
				<tr>
					<td>Release Point Fence Line Distance Unit of Measure Code</td>
					<td>
						<xsl:value-of select="cer:ReleasePointFenceLineDistanceUnitofMeasureCode"/>
					</td>
				</tr>
				<tr>
					<td>Release Point Fugitive Height Measure</td>
					<td>
						<xsl:value-of select="cer:ReleasePointFugitiveHeightMeasure"/>
					</td>
				</tr>
				<tr>
					<td>Release Point Fugitive Height Unit of Measure Code</td>
					<td>
						<xsl:value-of select="cer:ReleasePointFugitiveHeightUnitofMeasureCode"/>
					</td>
				</tr>
				<tr>
					<td>Release Point Fugitive Width Measure</td>
					<td>
						<xsl:value-of select="cer:ReleasePointFugitiveWidthMeasure"/>
					</td>
				</tr>
				<tr>
					<td>Release Point Fugitive Width Unit of Measure Code</td>
					<td>
						<xsl:value-of select="cer:ReleasePointFugitiveWidthUnitofMeasureCode"/>
					</td>
				</tr>
				<tr>
					<td>Release Point Fugitive Length Measure</td>
					<td>
						<xsl:value-of select="cer:ReleasePointFugitiveLengthMeasure"/>
					</td>
				</tr>
				<tr>
					<td>Release Point Fugitive Length Unit of Measure Code</td>
					<td>
						<xsl:value-of select="cer:ReleasePointFugitiveLengthUnitofMeasureCode"/>
					</td>
				</tr>
				<tr>
					<td>Release Point Fugitive Angle Measure</td>
					<td>
						<xsl:value-of select="cer:ReleasePointFugitiveAngleMeasure"/>
					</td>
				</tr>
				<tr>
					<td>Release Point Comment</td>
					<td>
						<xsl:value-of select="cer:ReleasePointComment"/>
					</td>
				</tr>
				<tr>
					<td>Release Point Status Code</td>
					<td>
						<xsl:value-of select="cer:ReleasePointStatusCode"/>
					</td>
				</tr>
				<tr>
					<td>Release Point Status Code Year</td>
					<td>
						<xsl:value-of select="cer:ReleasePointStatusCodeYear"/>
					</td>
				</tr>
			</table>
		</div>
		<xsl:apply-templates select="cer:ReleasePointIdentification"/>
		<xsl:apply-templates select="cer:ReleasePointTest"/>
		<xsl:apply-templates select="cer:GeographicCoordinates"/>
	</xsl:template>
	<xsl:template match="cer:FacilitySite/cer:ReleasePoint/cer:ReleasePointIdentification">
		<div class="indent4">
			<h2>Release Point Identification</h2>
			<table class="standard">
				<tr>
					<td>Release Point Identifier</td>
					<td>
						<xsl:value-of select="cer:Identifier"/>
					</td>
				</tr>
				<tr>
					<td>Program System Code</td>
					<td>
						<xsl:value-of select="cer:ProgramSystemCode"/>
					</td>
				</tr>
				<tr>
					<td>Effective Date</td>
					<td>
						<xsl:value-of select="cer:EffectiveDate"/>
					</td>
				</tr>
				<tr>
					<td>End Date</td>
					<td>
						<xsl:value-of select="cer:EndDate"/>
					</td>
				</tr>
			</table>
		</div>
	</xsl:template>
	<xsl:template match="cer:FacilitySite/cer:ReleasePoint/cer:ReleasePointTest">
		<div class="indent4">
			<h2>Release Point Test</h2>
			<table class="standard">
				<tr>
					<td>Release Point Plume Height Measure</td>
					<td>
						<xsl:value-of select="cer:ReleasePointPlumeHeightMeasure"/>
					</td>
				</tr>
				<tr>
					<td>Release Point Plume Height Unit of Measure Code</td>
					<td>
						<xsl:value-of select="cer:ReleasePointPlumeHeightUnitofMeasureCode"/>
					</td>
				</tr>
				<tr>
					<td>Percent Oxygen Content</td>
					<td>
						<xsl:value-of select="cer:PercentOxygenContent"/>
					</td>
				</tr>
				<tr>
					<td>Percent Moisture Content</td>
					<td>
						<xsl:value-of select="cer:PercentMoistureContent"/>
					</td>
				</tr>
				<tr>
					<td>Release Point Test Date</td>
					<td>
						<xsl:value-of select="cer:ReleasePointTestDate"/>
					</td>
				</tr>
			</table>
		</div>
	</xsl:template>
	<xsl:template match="cer:FacilitySite/cer:ReleasePoint/cer:GeographicCoordinates">
		<div class="indent4">
			<h2>Geographic Coordinates</h2>
			<table class="standard">
				<tr>
					<td>Latitude Measure</td>
					<td>
						<xsl:value-of select="cer:LatitudeMeasure"/>
					</td>
				</tr>
				<tr>
					<td>Longitude Measure</td>
					<td>
						<xsl:value-of select="cer:LongitudeMeasure"/>
					</td>
				</tr>
				<tr>
					<td>Source Map Scale Number</td>
					<td>
						<xsl:value-of select="cer:SourceMapScaleNumber"/>
					</td>
				</tr>
				<tr>
					<td>Horizontal Accuracy Measure</td>
					<td>
						<xsl:value-of select="cer:HorizontalAccuracyMeasure"/>
					</td>
				</tr>
				<tr>
					<td>Horizontal Accuracy Unit of Measure</td>
					<td>
						<xsl:value-of select="cer:HorizontalAccuracyUnitofMeasure"/>
					</td>
				</tr>
				<tr>
					<td>Horizontal Collection Method Code</td>
					<td>
						<xsl:value-of select="cer:HorizontalCollectionMethodCode"/>
					</td>
				</tr>
				<tr>
					<td>Horizontal Reference Datum Code</td>
					<td>
						<xsl:value-of select="cer:HorizontalReferenceDatumCode"/>
					</td>
				</tr>
				<tr>
					<td>Geographic Reference Point Code</td>
					<td>
						<xsl:value-of select="cer:GeographicReferencePointCode"/>
					</td>
				</tr>
				<tr>
					<td>Data Collection Date</td>
					<td>
						<xsl:value-of select="cer:DataCollectionDate"/>
					</td>
				</tr>
				<tr>
					<td>Geographic Comment</td>
					<td>
						<xsl:value-of select="cer:GeographicComment"/>
					</td>
				</tr>
				<tr>
					<td>Vertical Measure</td>
					<td>
						<xsl:value-of select="cer:VerticalMeasure"/>
					</td>
				</tr>
				<tr>
					<td>Vertical Unit of Measure Code</td>
					<td>
						<xsl:value-of select="cer:VerticalUnitofMeasureCode"/>
					</td>
				</tr>
				<tr>
					<td>Vertical Collection Method Code</td>
					<td>
						<xsl:value-of select="cer:VerticalCollectionMethodCode"/>
					</td>
				</tr>
				<tr>
					<td>Vertical Reference Datum Code</td>
					<td>
						<xsl:value-of select="cer:VerticalReferenceDatumCode"/>
					</td>
				</tr>
				<tr>
					<td>Verification Method Code</td>
					<td>
						<xsl:value-of select="cer:VerificationMethodCode"/>
					</td>
				</tr>
				<tr>
					<td>Coordinate Data Source Code</td>
					<td>
						<xsl:value-of select="cer:CoordinateDataSourceCode"/>
					</td>
				</tr>
				<tr>
					<td>Geometric Type Code</td>
					<td>
						<xsl:value-of select="cer:GeometricTypeCode"/>
					</td>
				</tr>
				<tr>
					<td>Area Within Perimeter</td>
					<td>
						<xsl:value-of select="cer:AreaWithinPerimeter"/>
					</td>
				</tr>
				<tr>
					<td>Area Within Perimeter Unit of Measure Code</td>
					<td>
						<xsl:value-of select="cer:AreaWithinPerimeterUnitofMeasureCode"/>
					</td>
				</tr>
				<tr>
					<td>Percent of Area Producing Emissions</td>
					<td>
						<xsl:value-of select="cer:PercentofAreaProducingEmissions"/>
					</td>
				</tr>
			</table>
		</div>
	</xsl:template>
	<xsl:template match="cer:CERS/cer:Location">
		<div class="indent2">
			<h2>Location</h2>
			<table class="standard">
				<tr>
					<td>State And County FIPS Code</td>
					<td>
						<xsl:value-of select="cer:StateAndCountyFIPSCode"/>
					</td>
				</tr>
				<tr>
					<td>Tribal Code</td>
					<td>
						<xsl:value-of select="cer:TribalCode"/>
					</td>
				</tr>
				<tr>
					<td>State And Country FIPS Code</td>
					<td>
						<xsl:value-of select="cer:StateAndCountryFIPSCode"/>
					</td>
				</tr>
				<tr>
					<td>Census Block Identifier</td>
					<td>
						<xsl:value-of select="cer:CensusBlockIdentifier"/>
					</td>
				</tr>
				<tr>
					<td>Census Tract Identifier</td>
					<td>
						<xsl:value-of select="cer:CensusTractIdentifier"/>
					</td>
				</tr>
				<tr>
					<td>Shape Identifier</td>
					<td>
						<xsl:value-of select="cer:ShapeIdentifier"/>
					</td>
				</tr>
				<tr>
					<td>Location Comment</td>
					<td>
						<xsl:value-of select="cer:LocationComment"/>
					</td>
				</tr>
			</table>
		</div>
		<xsl:apply-templates select="cer:ExcludedLocationParameter"/>
		<xsl:apply-templates select="cer:LocationEmissionsProcess"/>
	</xsl:template>
	<xsl:template match="cer:Location/cer:ExcludedLocationParameter">
		<div class="indent3">
			<h2>Location</h2>
			<table class="standard">
				<tr>
					<td>Location Type Code</td>
					<td>
						<xsl:value-of select="cer:LocationTypeCode"/>
					</td>
				</tr>
				<tr>
					<td>Location Parameter</td>
					<td>
						<xsl:value-of select="cer:LocationParameter"/>
					</td>
				</tr>
				<tr>
					<td>Location Comment</td>
					<td>
						<xsl:value-of select="cer:LocationComment"/>
					</td>
				</tr>
			</table>
		</div>
	</xsl:template>
	<xsl:template match="cer:Location/cer:LocationEmissionsProcess">
		<div class="indent4">
			<h2>Emissions Process</h2>
			<table class="standard">
				<tr>
					<td>Source Classification Code</td>
					<td>
						<xsl:value-of select="cer:SourceClassificationCode"/>
					</td>
				</tr>
				<tr>
					<td>Emissions Type Code</td>
					<td>
						<xsl:value-of select="cer:EmissionsTypeCode"/>
					</td>
				</tr>
				<tr>
					<td>Aircraft Engine Type Code</td>
					<td>
						<xsl:value-of select="cer:AircraftEngineTypeCode"/>
					</td>
				</tr>
				<tr>
					<td>Process Type Code</td>
					<td>
						<xsl:value-of select="cer:ProcessTypeCode"/>
					</td>
				</tr>
				<tr>
					<td>Process Description</td>
					<td>
						<xsl:value-of select="cer:ProcessDescription"/>
					</td>
				</tr>
				<tr>
					<td>Last Emissions Year</td>
					<td>
						<xsl:value-of select="cer:LastEmissionsYear"/>
					</td>
				</tr>
				<tr>
					<td>Process Comment</td>
					<td>
						<xsl:value-of select="cer:ProcessComment"/>
					</td>
				</tr>
			</table>
		</div>
		<xsl:apply-templates select="cer:ProcessIdentification"/>
		<xsl:apply-templates select="cer:ProcessRegulation"/>
		<xsl:apply-templates select="cer:ProcessControlApproach"/>
		<xsl:apply-templates select="cer:ReleasePointApportionment"/>
		<xsl:apply-templates select="cer:ReportingPeriod"/>
	</xsl:template>
	<xsl:template match="cer:Location/cer:LocationEmissionsProcess/cer:ProcessIdentification">
		<div class="indent5">
			<h2>Emissions Process Identification</h2>
			<table class="standard">
				<tr>
					<td>Emissions Process Identifier</td>
					<td>
						<xsl:value-of select="cer:Identifier"/>
					</td>
				</tr>
				<tr>
					<td>Program System Code</td>
					<td>
						<xsl:value-of select="cer:ProgramSystemCode"/>
					</td>
				</tr>
				<tr>
					<td>Effective Date</td>
					<td>
						<xsl:value-of select="cer:EffectiveDate"/>
					</td>
				</tr>
				<tr>
					<td>End Date</td>
					<td>
						<xsl:value-of select="cer:EndDate"/>
					</td>
				</tr>
			</table>
		</div>
	</xsl:template>
	<xsl:template match="cer:Location/cer:LocationEmissionsProcess/cer:ProcessRegulation">
		<div class="indent5">
			<h2>Regulation</h2>
			<table class="standard">
				<tr>
					<td>Regulatory Code</td>
					<td>
						<xsl:value-of select="cer:RegulatoryCode"/>
					</td>
				</tr>
				<tr>
					<td>Agency Code Text</td>
					<td>
						<xsl:value-of select="cer:AgencyCodeText"/>
					</td>
				</tr>
				<tr>
					<td>Regulatory Start Year</td>
					<td>
						<xsl:value-of select="cer:RegulatoryStartYear"/>
					</td>
				</tr>
				<tr>
					<td>Regulatory End Year</td>
					<td>
						<xsl:value-of select="cer:RegulatoryEndYear"/>
					</td>
				</tr>
				<tr>
					<td>Regulation Comment</td>
					<td>
						<xsl:value-of select="cer:RegulationComment"/>
					</td>
				</tr>
			</table>
		</div>
	</xsl:template>
	<xsl:template match="cer:Location/cer:LocationEmissionsProcess/cer:ProcessControlApproach">
		<div class="indent5">
			<h2>Control Approach</h2>
			<table class="standard">
				<tr>
					<td>Control Approach Description</td>
					<td>
						<xsl:value-of select="cer:ControlApproachDescription"/>
					</td>
				</tr>
				<tr>
					<td>Percent Control Approach Capture Efficiency</td>
					<td>
						<xsl:value-of select="cer:PercentControlApproachCaptureEfficiency"/>
					</td>
				</tr>
				<tr>
					<td>Percent Control Approach Effectiveness</td>
					<td>
						<xsl:value-of select="cer:PercentControlApproachEffectiveness"/>
					</td>
				</tr>
				<tr>
					<td>Percent Control Approach Penetration</td>
					<td>
						<xsl:value-of select="cer:PercentControlApproachPenetration"/>
					</td>
				</tr>
				<tr>
					<td>First Inventory Year</td>
					<td>
						<xsl:value-of select="cer:FirstInventoryYear"/>
					</td>
				</tr>
				<tr>
					<td>Last Inventory Year</td>
					<td>
						<xsl:value-of select="cer:LastInventoryYear"/>
					</td>
				</tr>
				<tr>
					<td>Control Approach Comment</td>
					<td>
						<xsl:value-of select="cer:ControlApproachComment"/>
					</td>
				</tr>
			</table>
		</div>
		<xsl:apply-templates select="cer:ControlMeasure"/>
		<xsl:apply-templates select="cer:ControlPollutant"/>
	</xsl:template>
	<xsl:template match="cer:Location/cer:LocationEmissionsProcess/cer:ProcessControlApproach/cer:ControlMeasure">
		<div class="indent6">
			<h2>ControlMeasure</h2>
			<table class="standard">
				<tr>
					<td>Control Measure Code</td>
					<td>
						<xsl:value-of select="cer:ControlMeasureCode"/>
					</td>
				</tr>
				<tr>
					<td>Control Measure Sequence</td>
					<td>
						<xsl:value-of select="cer:ControlMeasureSequence"/>
					</td>
				</tr>
			</table>
		</div>
	</xsl:template>
	<xsl:template match="cer:Location/cer:LocationEmissionsProcess/cer:ProcessControlApproach/cer:ControlPollutant">
		<div class="indent6">
			<h2>Control Pollutant</h2>
			<table class="standard">
				<tr>
					<td>Pollutant Code</td>
					<td>
						<xsl:value-of select="cer:PollutantCode"/>
					</td>
				</tr>
				<tr>
					<td>Percent Control Measures Reduction Efficiency</td>
					<td>
						<xsl:value-of select="cer:PercentControlMeasuresReductionEfficiency"/>
					</td>
				</tr>
			</table>
		</div>
	</xsl:template>
	<xsl:template match="cer:Location/cer:LocationEmissionsProcess/cer:ReleasePointApportionment">
		<div class="indent5">
			<h2>Release Point Apportionment</h2>
			<table class="standard">
				<tr>
					<td>Average Percent Emissions</td>
					<td>
						<xsl:value-of select="cer:AveragePercentEmissions"/>
					</td>
				</tr>
				<tr>
					<td>Release Point Apportionment Comment</td>
					<td>
						<xsl:value-of select="cer:ReleasePointApportionmentComment"/>
					</td>
				</tr>
			</table>
		</div>
		<xsl:apply-templates select="cer:ReleasePointApportionmentIdentification"/>
	</xsl:template>
	<xsl:template match="cer:Location/cer:LocationEmissionsProcess/cer:ReleasePointApportionment/cer:ReleasePointApportionmentIdentification">
		<div class="indent6">
			<h2>Release Point Identification</h2>
			<table class="standard">
				<tr>
					<td>Release Point Identifier</td>
					<td>
						<xsl:value-of select="cer:Identifier"/>
					</td>
				</tr>
				<tr>
					<td>Program System Code</td>
					<td>
						<xsl:value-of select="cer:ProgramSystemCode"/>
					</td>
				</tr>
				<tr>
					<td>Effective Date</td>
					<td>
						<xsl:value-of select="cer:EffectiveDate"/>
					</td>
				</tr>
				<tr>
					<td>End Date</td>
					<td>
						<xsl:value-of select="cer:EndDate"/>
					</td>
				</tr>
			</table>
		</div>
	</xsl:template>
	<xsl:template match="cer:Location/cer:LocationEmissionsProcess/cer:ReportingPeriod">
		<div class="indent5">
			<h2>Reporting Period</h2>
			<table class="standard">
				<tr>
					<td>Reporting Period Type Code</td>
					<td>
						<xsl:value-of select="cer:ReportingPeriodTypeCode"/>
					</td>
				</tr>
				<tr>
					<td>Emission Operating Type Code</td>
					<td>
						<xsl:value-of select="cer:EmissionOperatingTypeCode"/>
					</td>
				</tr>
				<tr>
					<td>Effective Date</td>
					<td>
						<xsl:value-of select="cer:StartDate"/>
					</td>
				</tr>
				<tr>
					<td>End Date</td>
					<td>
						<xsl:value-of select="cer:EndDate"/>
					</td>
				</tr>
				<tr>
					<td>Calculation Parameter Type Code</td>
					<td>
						<xsl:value-of select="cer:CalculationParameterTypeCode"/>
					</td>
				</tr>
				<tr>
					<td>Calculation Parameter Value</td>
					<td>
						<xsl:value-of select="cer:CalculationParameterValue"/>
					</td>
				</tr>
				<tr>
					<td>Calculation Parameter Unit of Measure</td>
					<td>
						<xsl:value-of select="cer:CalculationParameterUnitofMeasure"/>
					</td>
				</tr>
				<tr>
					<td>Calculation Material Code</td>
					<td>
						<xsl:value-of select="cer:CalculationMaterialCode"/>
					</td>
				</tr>
				<tr>
					<td>Calculation Data Year</td>
					<td>
						<xsl:value-of select="cer:CalculationDataYear"/>
					</td>
				</tr>
				<tr>
					<td>Calculation Data Source</td>
					<td>
						<xsl:value-of select="cer:CalculationDataSource"/>
					</td>
				</tr>
				<tr>
					<td>Reporting Period Comment</td>
					<td>
						<xsl:value-of select="cer:ReportingPeriodComment"/>
					</td>
				</tr>
			</table>
		</div>
		<xsl:apply-templates select="cer:QualityIdentification"/>
		<xsl:apply-templates select="cer:OperatingDetails"/>
		<xsl:apply-templates select="cer:SupplementalCalculationParameter"/>
		<xsl:apply-templates select="cer:ReportingPeriodEmissions"/>
	</xsl:template>
	<xsl:template match="cer:Location/cer:LocationEmissionsProcess/cer:ReportingPeriod/cer:QualityIdentification">
		<div class="indent6">
			<h2>Quality Identification</h2>
			<table class="standard">
				<tr>
					<td>Quality Identifier</td>
					<td>
						<xsl:value-of select="cer:QualityIdentifier"/>
					</td>
				</tr>
				<tr>
					<td>Program System Code</td>
					<td>
						<xsl:value-of select="cer:ProgramSystemCode"/>
					</td>
				</tr>
			</table>
		</div>
	</xsl:template>
	<xsl:template match="cer:Location/cer:LocationEmissionsProcess/cer:ReportingPeriod/cer:OperatingDetails">
		<div class="indent6">
			<h2>Operating Details</h2>
			<table class="standard">
				<tr>
					<td>Actual Hours Per Period</td>
					<td>
						<xsl:value-of select="cer:ActualHoursPerPeriod"/>
					</td>
				</tr>
				<tr>
					<td>Average Days Per Week</td>
					<td>
						<xsl:value-of select="cer:AverageDaysPerWeek"/>
					</td>
				</tr>
				<tr>
					<td>Average Hours Per Day</td>
					<td>
						<xsl:value-of select="cer:AverageHoursPerDay"/>
					</td>
				</tr>
				<tr>
					<td>Average Weeks Per Period</td>
					<td>
						<xsl:value-of select="cer:AverageWeeksPerPeriod"/>
					</td>
				</tr>
				<tr>
					<td>Percent Winter Activity</td>
					<td>
						<xsl:value-of select="cer:PercentWinterActivity"/>
					</td>
				</tr>
				<tr>
					<td>Percent Spring Activity</td>
					<td>
						<xsl:value-of select="cer:PercentSpringActivity"/>
					</td>
				</tr>
				<tr>
					<td>Percent Summer Activity</td>
					<td>
						<xsl:value-of select="cer:PercentSummerActivity"/>
					</td>
				</tr>
				<tr>
					<td>Percent Fall Activity</td>
					<td>
						<xsl:value-of select="cer:PercentFallActivity"/>
					</td>
				</tr>
			</table>
		</div>
	</xsl:template>
	<xsl:template match="cer:Location/cer:LocationEmissionsProcess/cer:ReportingPeriod/cer:SupplementalCalculationParameter">
		<div class="indent6">
			<h2>Supplemental Calculation Parameter</h2>
			<table class="standard">
				<tr>
					<td>Supplemental Parameter Type</td>
					<td>
						<xsl:value-of select="cer:SupplementalCalculationParameterType"/>
					</td>
				</tr>
				<tr>
					<td>Supplemental Parameter Value</td>
					<td>
						<xsl:value-of select="cer:SupplementalCalculationParameterValue"/>
					</td>
				</tr>
				<tr>
					<td>Supplemental Calculation Parameter Numerator Unit of Measure Code</td>
					<td>
						<xsl:value-of select="cer:SupplementalCalculationParameterNumeratorUnitofMeasureCode"/>
					</td>
				</tr>
				<tr>
					<td>Supplemental Calculation Parameter Denominator Unit of Measure Code</td>
					<td>
						<xsl:value-of select="cer:SupplementalCalculationParameterDenominatorUnitofMeasureCode"/>
					</td>
				</tr>
				<tr>
					<td>Supplemental Parameter Data Year</td>
					<td>
						<xsl:value-of select="cer:SupplementalCalculationParameterDataYear"/>
					</td>
				</tr>
				<tr>
					<td>Supplemental Parameter Data Source</td>
					<td>
						<xsl:value-of select="cer:SupplementalCalculationParameterDataSource"/>
					</td>
				</tr>
				<tr>
					<td>Supplemental Parameter Comment</td>
					<td>
						<xsl:value-of select="cer:SupplementalCalculationParameterComment"/>
					</td>
				</tr>
			</table>
		</div>
	</xsl:template>
	<xsl:template match="cer:Location/cer:LocationEmissionsProcess/cer:ReportingPeriod/cer:ReportingPeriodEmissions">
		<div class="indent6">
			<h2>Emissions</h2>
			<table class="standard">
				<tr>
					<td>Pollutant Code</td>
					<td>
						<xsl:value-of select="cer:PollutantCode"/>
					</td>
				</tr>
				<tr>
					<td>Total Emissions</td>
					<td>
						<xsl:value-of select="cer:TotalEmissions"/>
					</td>
				</tr>
				<tr>
					<td>Emissions Unit of Measure Code</td>
					<td>
						<xsl:value-of select="cer:EmissionsUnitofMeasureCode"/>
					</td>
				</tr>
				<tr>
					<td>Emission Factor</td>
					<td>
						<xsl:value-of select="cer:EmissionFactor"/>
					</td>
				</tr>
				<tr>
					<td>Emission Factor Numerator Unit of Measure Code</td>
					<td>
						<xsl:value-of select="cer:EmissionFactorNumeratorUnitofMeasureCode"/>
					</td>
				</tr>
				<tr>
					<td>Emission Factor Denominator Unit of Measure Code</td>
					<td>
						<xsl:value-of select="cer:EmissionFactorDenominatorUnitofMeasureCode"/>
					</td>
				</tr>
				<tr>
					<td>Emission Factor Formula Code</td>
					<td>
						<xsl:value-of select="cer:EmissionFactorFormulaCode"/>
					</td>
				</tr>
				<tr>
					<td>Emission Factor Text</td>
					<td>
						<xsl:value-of select="cer:EmissionFactorText"/>
					</td>
				</tr>
				<tr>
					<td>Emissions Calculation Method Code</td>
					<td>
						<xsl:value-of select="cer:EmissionsCalculationMethodCode"/>
					</td>
				</tr>
				<tr>
					<td>Emission Factor Reference Text</td>
					<td>
						<xsl:value-of select="cer:EmissionFactorReferenceText"/>
					</td>
				</tr>
				<tr>
					<td>Algorithm Formula Text</td>
					<td>
						<xsl:value-of select="cer:AlgorithmFormulaText"/>
					</td>
				</tr>
				<tr>
					<td>Algorithm Comment</td>
					<td>
						<xsl:value-of select="cer:AlgorithmComment"/>
					</td>
				</tr>
				<tr>
					<td>Calculation Method Accuracy Assessment Code</td>
					<td>
						<xsl:value-of select="cer:CalculationMethodAccuracyAssessmentCode"/>
					</td>
				</tr>
				<tr>
					<td>Emissions DeMinimis Status</td>
					<td>
						<xsl:value-of select="cer:EmissionsDeMinimisStatus"/>
					</td>
				</tr>
				<tr>
					<td>Emissions Comment</td>
					<td>
						<xsl:value-of select="cer:EmissionsComment"/>
					</td>
				</tr>
			</table>
		</div>
		<xsl:apply-templates select="cer:CO2Equivalent"/>
	</xsl:template>
	<xsl:template match="cer:Location/cer:LocationEmissionsProcess/cer:ReportingPeriod/cer:ReportingPeriodEmissions/cer:CO2Equivalent">
		<div class="indent7">
			<h2>CO2 Equivalent</h2>
			<table class="standard">
				<tr>
					<td>CO2e</td>
					<td>
						<xsl:value-of select="cer:CO2e"/>
					</td>
				</tr>
				<tr>
					<td>CO2e Unit of Measure Code</td>
					<td>
						<xsl:value-of select="cer:CO2eUnitofMeasureCode"/>
					</td>
				</tr>
				<tr>
					<td>CO2 Conversion Factor</td>
					<td>
						<xsl:value-of select="cer:CO2ConversionFactor"/>
					</td>
				</tr>
				<tr>
					<td>CO2 Conversion Factor Source</td>
					<td>
						<xsl:value-of select="cer:CO2ConversionFactorSource"/>
					</td>
				</tr>
			</table>
		</div>
	</xsl:template>
	<xsl:template match="cer:CERS/cer:Event">
		<div class="indent2">
			<h2>CO2 Equivalent</h2>
			<table class="standard">
				<tr>
					<td>Event Identifier</td>
					<td>
						<xsl:value-of select="cer:EventIdentifier"/>
					</td>
				</tr>
				<tr>
					<td>Program System Code</td>
					<td>
						<xsl:value-of select="cer:ProgramSystemCode"/>
					</td>
				</tr>
				<tr>
					<td>Event Name</td>
					<td>
						<xsl:value-of select="cer:EventName"/>
					</td>
				</tr>
				<tr>
					<td>Land Manager</td>
					<td>
						<xsl:value-of select="cer:LandManager"/>
					</td>
				</tr>
				<tr>
					<td>Location Description</td>
					<td>
						<xsl:value-of select="cer:LocationDescription"/>
					</td>
				</tr>
				<tr>
					<td>Event Classification Code</td>
					<td>
						<xsl:value-of select="cer:EventClassificationCode"/>
					</td>
				</tr>
				<tr>
					<td>Event Size Source Code</td>
					<td>
						<xsl:value-of select="cer:EventSizeSourceCode"/>
					</td>
				</tr>
				<tr>
					<td>Containment Date</td>
					<td>
						<xsl:value-of select="cer:ContainmentDate"/>
					</td>
				</tr>
				<tr>
					<td>Recurrence Indicator Code</td>
					<td>
						<xsl:value-of select="cer:RecurrenceIndicatorCode"/>
					</td>
				</tr>
				<tr>
					<td>Recurrence Year</td>
					<td>
						<xsl:value-of select="cer:RecurrenceYear"/>
					</td>
				</tr>
				<tr>
					<td>Ground Based Data Source Code </td>
					<td>
						<xsl:value-of select="cer:GroundBasedDataSourceCode"/>
					</td>
				</tr>
				<tr>
					<td>Remote Sensing Data Source Code</td>
					<td>
						<xsl:value-of select="cer:RemoteSensingDataSourceCode"/>
					</td>
				</tr>
				<tr>
					<td>Fuel Consumption And Emissions Model Code</td>
					<td>
						<xsl:value-of select="cer:FuelConsumptionAndEmissionsModelCode"/>
					</td>
				</tr>
				<tr>
					<td>Fuel Type Model Code</td>
					<td>
						<xsl:value-of select="cer:FuelTypeModelCode"/>
					</td>
				</tr>
				<tr>
					<td>Fuel Selection Code</td>
					<td>
						<xsl:value-of select="cer:FuelSelectionCode"/>
					</td>
				</tr>
				<tr>
					<td>Ignition Method Code</td>
					<td>
						<xsl:value-of select="cer:IgnitionMethodCode"/>
					</td>
				</tr>
				<tr>
					<td>Ignition Location Code</td>
					<td>
						<xsl:value-of select="cer:IgnitionLocationCode"/>
					</td>
				</tr>
				<tr>
					<td>Ignition Orientation Code</td>
					<td>
						<xsl:value-of select="cer:IgnitionOrientationCode"/>
					</td>
				</tr>
				<tr>
					<td>Event Comment</td>
					<td>
						<xsl:value-of select="cer:EventComment"/>
					</td>
				</tr>
			</table>
		</div>
		<xsl:apply-templates select="cer:AttachedFile"/>
		<xsl:apply-templates select="cer:MergedEvents"/>
		<xsl:apply-templates select="cer:EventReportingPeriod"/>
	</xsl:template>
	<xsl:template match="cer:Event/cer:AttachedFile">
		<div class="indent3">
			<h2>Attached File</h2>
			<table class="standard">
				<tr>
					<td>Attachment File Name</td>
					<td>
						<xsl:value-of select="cer:AttachmentFileName"/>
					</td>
				</tr>
				<tr>
					<td>Attachment File Description</td>
					<td>
						<xsl:value-of select="cer:AttachmentFileDescription"/>
					</td>
				</tr>
				<tr>
					<td>Attachment File Size</td>
					<td>
						<xsl:value-of select="cer:AttachmentfileSize"/>
					</td>
				</tr>
				<tr>
					<td>Attachment File Content Type Code</td>
					<td>
						<xsl:value-of select="cer:AttachmentFileContentTypeCode"/>
					</td>
				</tr>
			</table>
		</div>
	</xsl:template>
	<xsl:template match="cer:Event/cer:MergedEvents">
		<div class="indent3">
			<h2>Merged Events</h2>
			<table class="standard">
				<tr>
					<td>Event Identifier</td>
					<td>
						<xsl:value-of select="cer:EventIdentifier"/>
					</td>
				</tr>
				<tr>
					<td>Program System Code</td>
					<td>
						<xsl:value-of select="cer:ProgramSystemCode"/>
					</td>
				</tr>
				<tr>
					<td>Date Merged</td>
					<td>
						<xsl:value-of select="cer:DateMerged"/>
					</td>
				</tr>
				<tr>
					<td>Merged Events Comment</td>
					<td>
						<xsl:value-of select="cer:MergedEventsComment"/>
					</td>
				</tr>
			</table>
		</div>
	</xsl:template>
	<xsl:template match="cer:Event/cer:EventReportingPeriod">
		<div class="indent3">
			<h2>Event Reporting Period</h2>
			<table class="standard">
				<tr>
					<td>Event Begin Date</td>
					<td>
						<xsl:value-of select="cer:EventBeginDate"/>
					</td>
				</tr>
				<tr>
					<td>Event End Date</td>
					<td>
						<xsl:value-of select="cer:EventEndDate"/>
					</td>
				</tr>
				<tr>
					<td>Event Stage Code</td>
					<td>
						<xsl:value-of select="cer:EventStageCode"/>
					</td>
				</tr>
				<tr>
					<td>Begin Hour</td>
					<td>
						<xsl:value-of select="cer:BeginHour"/>
					</td>
				</tr>
				<tr>
					<td>Event Reporting Period Comment</td>
					<td>
						<xsl:value-of select="cer:EventReportingPeriodComment"/>
					</td>
				</tr>
			</table>
		</div>
		<xsl:apply-templates select="cer:EventLocation"/>
	</xsl:template>
	<xsl:template match="cer:Event/cer:EventReportingPeriod/cer:EventLocation">
		<div class="indent4">
			<h2>Event Location</h2>
			<table class="standard">
				<tr>
					<td>County Code</td>
					<td>
						<xsl:value-of select="cer:CountyCode"/>
					</td>
				</tr>
				<tr>
					<td>State Code</td>
					<td>
						<xsl:value-of select="cer:StateCode"/>
					</td>
				</tr>
				<tr>
					<td>Tribal Code</td>
					<td>
						<xsl:value-of select="cer:TribalCode"/>
					</td>
				</tr>
				<tr>
					<td>State And Country FIPS Code</td>
					<td>
						<xsl:value-of select="cer:StateAndCountryFIPSCode"/>
					</td>
				</tr>
			</table>
		</div>
		<xsl:apply-templates select="cer:GeographicCoordinates"/>
		<xsl:apply-templates select="cer:GeospatialParameters"/>
		<xsl:apply-templates select="cer:EventEmissionsProcess"/>
	</xsl:template>
	<xsl:template match="cer:Event/cer:EventReportingPeriod/cer:EventLocation/cer:GeographicCoordinates">
		<div class="indent5">
			<h2>Geographic Coordinates</h2>
			<table class="standard">
				<tr>
					<td>Latitude Measure</td>
					<td>
						<xsl:value-of select="cer:LatitudeMeasure"/>
					</td>
				</tr>
				<tr>
					<td>Longitude Measure</td>
					<td>
						<xsl:value-of select="cer:LongitudeMeasure"/>
					</td>
				</tr>
				<tr>
					<td>Source Map Scale Number</td>
					<td>
						<xsl:value-of select="cer:SourceMapScaleNumber"/>
					</td>
				</tr>
				<tr>
					<td>Horizontal Accuracy Measure</td>
					<td>
						<xsl:value-of select="cer:HorizontalAccuracyMeasure"/>
					</td>
				</tr>
				<tr>
					<td>Horizontal Accuracy Unit of Measure</td>
					<td>
						<xsl:value-of select="cer:HorizontalAccuracyUnitofMeasure"/>
					</td>
				</tr>
				<tr>
					<td>Horizontal Collection Method Code</td>
					<td>
						<xsl:value-of select="cer:HorizontalCollectionMethodCode"/>
					</td>
				</tr>
				<tr>
					<td>Horizontal Reference Datum Code</td>
					<td>
						<xsl:value-of select="cer:HorizontalReferenceDatumCode"/>
					</td>
				</tr>
				<tr>
					<td>Geographic Reference Point Code</td>
					<td>
						<xsl:value-of select="cer:GeographicReferencePointCode"/>
					</td>
				</tr>
				<tr>
					<td>Data Collection Date</td>
					<td>
						<xsl:value-of select="cer:DataCollectionDate"/>
					</td>
				</tr>
				<tr>
					<td>Geographic Comment</td>
					<td>
						<xsl:value-of select="cer:GeographicComment"/>
					</td>
				</tr>
				<tr>
					<td>Vertical Measure</td>
					<td>
						<xsl:value-of select="cer:VerticalMeasure"/>
					</td>
				</tr>
				<tr>
					<td>Vertical Unit of Measure Code</td>
					<td>
						<xsl:value-of select="cer:VerticalUnitofMeasureCode"/>
					</td>
				</tr>
				<tr>
					<td>Vertical Collection Method Code</td>
					<td>
						<xsl:value-of select="cer:VerticalCollectionMethodCode"/>
					</td>
				</tr>
				<tr>
					<td>Vertical Reference Datum Code</td>
					<td>
						<xsl:value-of select="cer:VerticalReferenceDatumCode"/>
					</td>
				</tr>
				<tr>
					<td>Verification Method Code</td>
					<td>
						<xsl:value-of select="cer:VerificationMethodCode"/>
					</td>
				</tr>
				<tr>
					<td>Coordinate Data Source Code</td>
					<td>
						<xsl:value-of select="cer:CoordinateDataSourceCode"/>
					</td>
				</tr>
				<tr>
					<td>Geometric Type Code</td>
					<td>
						<xsl:value-of select="cer:GeometricTypeCode"/>
					</td>
				</tr>
				<tr>
					<td>Area Within Perimeter</td>
					<td>
						<xsl:value-of select="cer:AreaWithinPerimeter"/>
					</td>
				</tr>
				<tr>
					<td>Area Within Perimeter Unit of Measure Code</td>
					<td>
						<xsl:value-of select="cer:AreaWithinPerimeterUnitofMeasureCode"/>
					</td>
				</tr>
				<tr>
					<td>Percent of Area Producing Emissions</td>
					<td>
						<xsl:value-of select="cer:PercentofAreaProducingEmissions"/>
					</td>
				</tr>
			</table>
		</div>
	</xsl:template>
	<xsl:template match="cer:Event/cer:EventReportingPeriod/cer:EventLocation/cer:GeospatialParameters">
		<div class="indent5">
			<h2>Geospatial Parameters</h2>
			<table class="standard">
				<tr>
					<td>Shape File Identifier</td>
					<td>
						<xsl:value-of select="cer:ShapeFileIdentifier"/>
					</td>
				</tr>
				<tr>
					<td>Area Within Shape</td>
					<td>
						<xsl:value-of select="cer:AreaWithinShape"/>
					</td>
				</tr>
				<tr>
					<td>Area Within Shape Unit of Measure Code</td>
					<td>
						<xsl:value-of select="cer:AreaWithinShapeUnitofMeasureCode"/>
					</td>
				</tr>
				<tr>
					<td>Percent of Area Producing Emissions</td>
					<td>
						<xsl:value-of select="cer:PercentofAreaProducingEmissions"/>
					</td>
				</tr>
				<tr>
					<td>Geospatial Parameters Comment</td>
					<td>
						<xsl:value-of select="cer:GeospatialParametersComment"/>
					</td>
				</tr>
			</table>
		</div>
	</xsl:template>
	<xsl:template match="cer:Event/cer:EventReportingPeriod/cer:EventLocation/cer:EventEmissionsProcess">
		<div class="indent5">
			<h2>Event Emissions Process</h2>
			<table class="standard">
				<tr>
					<td>Source Classification Code</td>
					<td>
						<xsl:value-of select="cer:SourceClassificationCode"/>
					</td>
				</tr>
				<tr>
					<td>Fuel Configuration Code</td>
					<td>
						<xsl:value-of select="cer:FuelConfigurationCode"/>
					</td>
				</tr>
				<tr>
					<td>Fuel Loading</td>
					<td>
						<xsl:value-of select="cer:FuelLoading"/>
					</td>
				</tr>
				<tr>
					<td>Fuel Loading Unit of Measure Code</td>
					<td>
						<xsl:value-of select="cer:FuelLoadingUnitofMeasureCode"/>
					</td>
				</tr>
				<tr>
					<td>Amount of Fuel Consumed</td>
					<td>
						<xsl:value-of select="cer:AmountofFuelConsumed"/>
					</td>
				</tr>
				<tr>
					<td>Amount of Fuel Consumed Unit of Measure Code</td>
					<td>
						<xsl:value-of select="cer:AmountofFuelConsumedUnitofMeasureCode"/>
					</td>
				</tr>
				<tr>
					<td>Percent Ten Hour Fuel Moisture</td>
					<td>
						<xsl:value-of select="cer:PercentTenHourFuelMoisture"/>
					</td>
				</tr>
				<tr>
					<td>Percent One Thousand Hour Fuel Moisture</td>
					<td>
						<xsl:value-of select="cer:PercentOneThousandHourFuelMoisture"/>
					</td>
				</tr>
				<tr>
					<td>Percent Live Fuel Moisture</td>
					<td>
						<xsl:value-of select="cer:PercentLiveFuelMoisture"/>
					</td>
				</tr>
				<tr>
					<td>Percent Duff Fuel Moisture</td>
					<td>
						<xsl:value-of select="cer:PercentDuffFuelMoisture"/>
					</td>
				</tr>
				<tr>
					<td>Heat Release</td>
					<td>
						<xsl:value-of select="cer:HeatRelease"/>
					</td>
				</tr>
				<tr>
					<td>Heat Release Unit of MeasureCode</td>
					<td>
						<xsl:value-of select="cer:HeatReleaseUnitofMeasureCode"/>
					</td>
				</tr>
				<tr>
					<td>Emission Reduction Technique Code</td>
					<td>
						<xsl:value-of select="cer:EmissionReductionTechniqueCode"/>
					</td>
				</tr>
				<tr>
					<td>Event Emissions Process Comment</td>
					<td>
						<xsl:value-of select="cer:EventEmissionsProcessComment"/>
					</td>
				</tr>
			</table>
		</div>
		<xsl:apply-templates select="cer:Emissions"/>
	</xsl:template>
	<xsl:template match="cer:Event/cer:EventReportingPeriod/cer:EventLocation/cer:EventEmissionsProcess/cer:Emissions">
		<div class="indent6">
			<h2>Emissions</h2>
			<table class="standard">
				<tr>
					<td>Pollutant Code</td>
					<td>
						<xsl:value-of select="cer:PollutantCode"/>
					</td>
				</tr>
				<tr>
					<td>Total Emissions</td>
					<td>
						<xsl:value-of select="cer:TotalEmissions"/>
					</td>
				</tr>
				<tr>
					<td>Emissions Unit of Measure Code</td>
					<td>
						<xsl:value-of select="cer:EmissionsUnitofMeasureCode"/>
					</td>
				</tr>
				<tr>
					<td>Emission Factor</td>
					<td>
						<xsl:value-of select="cer:EmissionFactor"/>
					</td>
				</tr>
				<tr>
					<td>Emission Factor Numerator Unit of Measure Code</td>
					<td>
						<xsl:value-of select="cer:EmissionFactorNumeratorUnitofMeasureCode"/>
					</td>
				</tr>
				<tr>
					<td>Emission Factor Denominator Unit of Measure Code</td>
					<td>
						<xsl:value-of select="cer:EmissionFactorDenominatorUnitofMeasureCode"/>
					</td>
				</tr>
				<tr>
					<td>Emission Factor Formula Code</td>
					<td>
						<xsl:value-of select="cer:EmissionFactorFormulaCode"/>
					</td>
				</tr>
				<tr>
					<td>Emission Factor Text</td>
					<td>
						<xsl:value-of select="cer:EmissionFactorText"/>
					</td>
				</tr>
				<tr>
					<td>Emissions Calculation Method Code</td>
					<td>
						<xsl:value-of select="cer:EmissionsCalculationMethodCode"/>
					</td>
				</tr>
				<tr>
					<td>Emission Factor Reference Text</td>
					<td>
						<xsl:value-of select="cer:EmissionFactorReferenceText"/>
					</td>
				</tr>
				<tr>
					<td>Algorithm Formula Text</td>
					<td>
						<xsl:value-of select="cer:AlgorithmFormulaText"/>
					</td>
				</tr>
				<tr>
					<td>Algorithm Comment</td>
					<td>
						<xsl:value-of select="cer:AlgorithmComment"/>
					</td>
				</tr>
				<tr>
					<td>Calculation Method Accuracy Assessment Code</td>
					<td>
						<xsl:value-of select="cer:CalculationMethodAccuracyAssessmentCode"/>
					</td>
				</tr>
				<tr>
					<td>Emissions DeMinimis Status</td>
					<td>
						<xsl:value-of select="cer:EmissionsDeMinimisStatus"/>
					</td>
				</tr>
				<tr>
					<td>Emissions Comment</td>
					<td>
						<xsl:value-of select="cer:EmissionsComment"/>
					</td>
				</tr>
			</table>
		</div>
		<xsl:apply-templates select="cer:CO2Equivalent"/>
	</xsl:template>
	<xsl:template match="cer:Event/cer:EventReportingPeriod/cer:EventLocation/cer:EventEmissionsProcess/cer:Emissions/cer:CO2Equivalent">
		<div class="indent7">
			<h2>CO2 Equivalent</h2>
			<table class="standard">
				<tr>
					<td>CO2e</td>
					<td>
						<xsl:value-of select="cer:CO2e"/>
					</td>
				</tr>
				<tr>
					<td>CO2e Unit of Measure Code</td>
					<td>
						<xsl:value-of select="cer:CO2eUnitofMeasureCode"/>
					</td>
				</tr>
				<tr>
					<td>CO2 Conversion Factor</td>
					<td>
						<xsl:value-of select="cer:CO2ConversionFactor"/>
					</td>
				</tr>
				<tr>
					<td>CO2 Conversion Factor Source</td>
					<td>
						<xsl:value-of select="cer:CO2ConversionFactorSource"/>
					</td>
				</tr>
			</table>
		</div>
	</xsl:template>
	<xsl:template match="cer:CERS/cer:QualityFinding">
		<div class="indent2">
			<h2>Quality Finding</h2>
			<table class="standard">
				<tr>
					<td>Quality Identifier</td>
					<td>
						<xsl:value-of select="cer:QualityIdentifier"/>
					</td>
				</tr>
				<tr>
					<td>Program System Code</td>
					<td>
						<xsl:value-of select="cer:ProgramSystemCode"/>
					</td>
				</tr>
				<tr>
					<td>Quality Verification Type</td>
					<td>
						<xsl:value-of select="cer:QualityVerificationType"/>
					</td>
				</tr>
				<tr>
					<td>Quality Type Code</td>
					<td>
						<xsl:value-of select="cer:QualityTypeCode"/>
					</td>
				</tr>
				<tr>
					<td>Quality Exceptions</td>
					<td>
						<xsl:value-of select="cer:QualityExceptions"/>
					</td>
				</tr>
				<tr>
					<td>Quality Status Code</td>
					<td>
						<xsl:value-of select="cer:QualityStatusCode"/>
					</td>
				</tr>
				<tr>
					<td>Quality Level of Assurance Code</td>
					<td>
						<xsl:value-of select="cer:QualityLevelofAssuranceCode"/>
					</td>
				</tr>
				<tr>
					<td>Quality Standards Source</td>
					<td>
						<xsl:value-of select="cer:QualityStandardsSource"/>
					</td>
				</tr>
				<tr>
					<td>Quality Determination Date</td>
					<td>
						<xsl:value-of select="cer:QualityDeterminationDate"/>
					</td>
				</tr>
			</table>
			<xsl:apply-templates select="cer:QualityFindingOrganization"/>
			<xsl:apply-templates select="cer:QualityFindingAttachedFile"/>
		</div>
	</xsl:template>
	<xsl:template match="cer:QualityFinding/cer:QualityFindingAttachedFile">
		<div class="indent3">
			<h2>Attached File</h2>
			<table class="standard">
				<tr>
					<td>Attachment File Name</td>
					<td>
						<xsl:value-of select="cer:AttachmentFileName"/>
					</td>
				</tr>
				<tr>
					<td>Attachment File Description</td>
					<td>
						<xsl:value-of select="cer:AttachmentFileDescription"/>
					</td>
				</tr>
				<tr>
					<td>Attachment File Size</td>
					<td>
						<xsl:value-of select="cer:AttachmentfileSize"/>
					</td>
				</tr>
				<tr>
					<td>Attachment File Content Type Code</td>
					<td>
						<xsl:value-of select="cer:AttachmentFileContentTypeCode"/>
					</td>
				</tr>
			</table>
		</div>
	</xsl:template>
	<xsl:template match="cer:QualityFinding/cer:QualityFindingOrganization">
		<div class="indent4">
			<h2>Organization</h2>
			<table class="standard">
				<tr>
					<td>Organization Name</td>
					<td>
						<xsl:value-of select="cer:OrganizationName"/>
					</td>
				</tr>
				<tr>
					<td>Percent Ownership</td>
					<td>
						<xsl:value-of select="cer:PercentOwnership"/>
					</td>
				</tr>
				<tr>
					<td>Consolidation Methodology</td>
					<td>
						<xsl:value-of select="cer:ConsolidationMethodology"/>
					</td>
				</tr>
			</table>
		</div>
		<xsl:apply-templates select="cer:OrganizationIdentification"/>
		<xsl:apply-templates select="cer:OrganizationAddress"/>
		<xsl:apply-templates select="cer:OrganizationCommunication"/>
		<xsl:apply-templates select="cer:OrganizationIndividual"/>
		<xsl:apply-templates select="cer:OrganizationAttachedFile"/>
	</xsl:template>
	<xsl:template match="cer:QualityFinding/cer:QualityFindingOrganization/cer:OrganizationIdentification">
		<div class="indent5">
			<h2>Organization Identification</h2>
			<table class="standard">
				<tr>
					<td>Organization Identifier</td>
					<td>
						<xsl:value-of select="cer:OrganizationIdentifier"/>
					</td>
				</tr>
				<tr>
					<td>Program System Code</td>
					<td>
						<xsl:value-of select="cer:ProgramSystemCode"/>
					</td>
				</tr>
				<tr>
					<td>Effective Date</td>
					<td>
						<xsl:value-of select="cer:EffectiveDate"/>
					</td>
				</tr>
				<tr>
					<td>End Date</td>
					<td>
						<xsl:value-of select="cer:EndDate"/>
					</td>
				</tr>
			</table>
		</div>
	</xsl:template>
	<xsl:template match="cer:QualityFinding/cer:QualityFindingOrganization/cer:OrganizationAddress">
		<div class="indent5">
			<h2>Address</h2>
			<table class="standard">
				<tr>
					<td>Mailing Address Text</td>
					<td>
						<xsl:value-of select="cer:MailingAddressText"/>
					</td>
				</tr>
				<tr>
					<td>Supplemental Address Text</td>
					<td>
						<xsl:value-of select="cer:SupplementalAddressText"/>
					</td>
				</tr>
				<tr>
					<td>Mailing Address City Name</td>
					<td>
						<xsl:value-of select="cer:MailingAddressCityName"/>
					</td>
				</tr>
				<tr>
					<td>Mailing Address County Text</td>
					<td>
						<xsl:value-of select="cer:MailingAddressCountyText"/>
					</td>
				</tr>
				<tr>
					<td>Mailing Address State Code</td>
					<td>
						<xsl:value-of select="cer:MailingAddressStateCode"/>
					</td>
				</tr>
				<tr>
					<td>Mailing Address Postal Code</td>
					<td>
						<xsl:value-of select="cer:MailingAddressPostalCode"/>
					</td>
				</tr>
				<tr>
					<td>Mailing Address Country Code</td>
					<td>
						<xsl:value-of select="cer:MailingAddressCountryCode"/>
					</td>
				</tr>
				<tr>
					<td>Location Address Text</td>
					<td>
						<xsl:value-of select="cer:LocationAddressText"/>
					</td>
				</tr>
				<tr>
					<td>Supplemental Location Text</td>
					<td>
						<xsl:value-of select="cer:SupplementalLocationText"/>
					</td>
				</tr>
				<tr>
					<td>Locality Name</td>
					<td>
						<xsl:value-of select="cer:LocalityName"/>
					</td>
				</tr>
				<tr>
					<td>Location Address State Code</td>
					<td>
						<xsl:value-of select="cer:LocationAddressStateCode"/>
					</td>
				</tr>
				<tr>
					<td>Location Address Postal Code</td>
					<td>
						<xsl:value-of select="cer:LocationAddressPostalCode"/>
					</td>
				</tr>
				<tr>
					<td>Location Address Country Code</td>
					<td>
						<xsl:value-of select="cer:LocationAddressCountryCode"/>
					</td>
				</tr>
				<tr>
					<td>Address Comment</td>
					<td>
						<xsl:value-of select="cer:AddressComment"/>
					</td>
				</tr>
			</table>
		</div>
	</xsl:template>
	<xsl:template match="cer:QualityFinding/cer:QualityFindingOrganization/cer:OrganizationCommunication">
		<div class="indent5">
			<h2>Communication</h2>
			<table class="standard">
				<tr>
					<td>Telephone Number Text</td>
					<td>
						<xsl:value-of select="cer:TelephoneNumberText"/>
					</td>
				</tr>
				<tr>
					<td>Telephone Number Type Name</td>
					<td>
						<xsl:value-of select="cer:TelephoneNumberTypeName"/>
					</td>
				</tr>
				<tr>
					<td>Telephone Extension Number Text</td>
					<td>
						<xsl:value-of select="cer:TelephoneExtensionNumberText"/>
					</td>
				</tr>
				<tr>
					<td>Electronic Address Text</td>
					<td>
						<xsl:value-of select="cer:ElectronicAddressText"/>
					</td>
				</tr>
				<tr>
					<td>Electronic Address Type Name</td>
					<td>
						<xsl:value-of select="cer:ElectronicAddressTypeName"/>
					</td>
				</tr>
			</table>
		</div>
	</xsl:template>
	<xsl:template match="cer:QualityFinding/cer:QualityFindingOrganization/cer:OrganizationAttachedFile">
		<div class="indent5">
			<h2>Attached File</h2>
			<table class="standard">
				<tr>
					<td>Attachment File Name</td>
					<td>
						<xsl:value-of select="cer:AttachmentFileName"/>
					</td>
				</tr>
				<tr>
					<td>Attachment File Description</td>
					<td>
						<xsl:value-of select="cer:AttachmentFileDescription"/>
					</td>
				</tr>
				<tr>
					<td>Attachment File Size</td>
					<td>
						<xsl:value-of select="cer:AttachmentfileSize"/>
					</td>
				</tr>
				<tr>
					<td>Attachment File Content Type Code</td>
					<td>
						<xsl:value-of select="cer:AttachmentFileContentTypeCode"/>
					</td>
				</tr>
			</table>
		</div>
	</xsl:template>
		<xsl:template match="cer:QualityFinding/cer:QualityFindingOrganization/cer:OrganizationIndividual">
		<div class="indent4">
			<h2>Individual</h2>
			<table class="standard">
				<tr>
					<td>Individual Title Text</td>
					<td>
						<xsl:value-of select="cer:IndividualTitleText"/>
					</td>
				</tr>
				<tr>
					<td>Name Prefix Text</td>
					<td>
						<xsl:value-of select="cer:NamePrefixText"/>
					</td>
				</tr>
				<tr>
					<td>First Name</td>
					<td>
						<xsl:value-of select="cer:FirstName"/>
					</td>
				</tr>
				<tr>
					<td>Middle Name</td>
					<td>
						<xsl:value-of select="cer:MiddleName"/>
					</td>
				</tr>
				<tr>
					<td>Last Name</td>
					<td>
						<xsl:value-of select="cer:LastName"/>
					</td>
				</tr>
				<tr>
					<td>Name Suffix Text</td>
					<td>
						<xsl:value-of select="cer:NameSuffixText"/>
					</td>
				</tr>
			</table>
		</div>
		<xsl:apply-templates select="cer:IndividualIdentification"/>
		<xsl:apply-templates select="cer:IndividualAddress"/>
		<xsl:apply-templates select="cer:Communication"/>
	</xsl:template>
	<xsl:template match="cer:QualityFinding/cer:QualityFindingOrganization/cer:OrganizationIndividual/cer:IndividualIdentification">
		<div class="indent5">
			<h2>Individual Identification</h2>
			<table class="standard">
				<tr>
					<td>Individual Identifier</td>
					<td>
						<xsl:value-of select="cer:Identifier"/>
					</td>
				</tr>
				<tr>
					<td>Program System Code</td>
					<td>
						<xsl:value-of select="cer:ProgramSystemCode"/>
					</td>
				</tr>
				<tr>
					<td>Effective Date</td>
					<td>
						<xsl:value-of select="cer:EffectiveDate"/>
					</td>
				</tr>
				<tr>
					<td>End Date</td>
					<td>
						<xsl:value-of select="cer:EndDate"/>
					</td>
				</tr>
			</table>
		</div>
	</xsl:template>
	<xsl:template match="cer:QualityFinding/cer:QualityFindingOrganization/cer:OrganizationIndividual/cer:IndividualAddress">
		<div class="indent5">
			<h2>Address</h2>
			<table class="standard">
				<tr>
					<td>Mailing Address Text</td>
					<td>
						<xsl:value-of select="cer:MailingAddressText"/>
					</td>
				</tr>
				<tr>
					<td>Supplemental Address Text</td>
					<td>
						<xsl:value-of select="cer:SupplementalAddressText"/>
					</td>
				</tr>
				<tr>
					<td>Mailing Address City Name</td>
					<td>
						<xsl:value-of select="cer:MailingAddressCityName"/>
					</td>
				</tr>
				<tr>
					<td>Mailing Address County Text</td>
					<td>
						<xsl:value-of select="cer:MailingAddressCountyText"/>
					</td>
				</tr>
				<tr>
					<td>Mailing Address State Code</td>
					<td>
						<xsl:value-of select="cer:MailingAddressStateCode"/>
					</td>
				</tr>
				<tr>
					<td>Mailing Address Postal Code</td>
					<td>
						<xsl:value-of select="cer:MailingAddressPostalCode"/>
					</td>
				</tr>
				<tr>
					<td>Mailing Address Country Code</td>
					<td>
						<xsl:value-of select="cer:MailingAddressCountryCode"/>
					</td>
				</tr>
				<tr>
					<td>Location Address Text</td>
					<td>
						<xsl:value-of select="cer:LocationAddressText"/>
					</td>
				</tr>
				<tr>
					<td>Supplemental Location Text</td>
					<td>
						<xsl:value-of select="cer:SupplementalLocationText"/>
					</td>
				</tr>
				<tr>
					<td>Locality Name</td>
					<td>
						<xsl:value-of select="cer:LocalityName"/>
					</td>
				</tr>
				<tr>
					<td>Location Address State Code</td>
					<td>
						<xsl:value-of select="cer:LocationAddressStateCode"/>
					</td>
				</tr>
				<tr>
					<td>Location Address Postal Code</td>
					<td>
						<xsl:value-of select="cer:LocationAddressPostalCode"/>
					</td>
				</tr>
				<tr>
					<td>Location Address Country Code</td>
					<td>
						<xsl:value-of select="cer:LocationAddressCountryCode"/>
					</td>
				</tr>
				<tr>
					<td>Address Comment</td>
					<td>
						<xsl:value-of select="cer:AddressComment"/>
					</td>
				</tr>
			</table>
		</div>
	</xsl:template>
	<xsl:template match="cer:QualityFinding/cer:QualityFindingOrganization/cer:OrganizationIndividual/cer:Communication">
		<div class="indent5">
			<h2>Communication</h2>
			<table class="standard">
				<tr>
					<td>Telephone Number Text</td>
					<td>
						<xsl:value-of select="cer:TelephoneNumberText"/>
					</td>
				</tr>
				<tr>
					<td>Telephone Number Type Name</td>
					<td>
						<xsl:value-of select="cer:TelephoneNumberTypeName"/>
					</td>
				</tr>
				<tr>
					<td>Telephone Extension Number Text</td>
					<td>
						<xsl:value-of select="cer:TelephoneExtensionNumberText"/>
					</td>
				</tr>
				<tr>
					<td>Electronic Address Text</td>
					<td>
						<xsl:value-of select="cer:ElectronicAddressText"/>
					</td>
				</tr>
				<tr>
					<td>Electronic Address Type Name</td>
					<td>
						<xsl:value-of select="cer:ElectronicAddressTypeName"/>
					</td>
				</tr>
			</table>
		</div>
	</xsl:template>
</xsl:stylesheet>
