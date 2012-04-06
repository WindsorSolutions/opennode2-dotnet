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

﻿
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using System.Runtime.Serialization;

namespace Windsor.Node2008.WNOSPlugin.HERE.CAFO11
{

    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/CAFO/1_0")]
    [System.Xml.Serialization.XmlRootAttribute("AnimalType", Namespace = "http://www.exchangenetwork.net/schema/CAFO/1_0", IsNullable = false)]
    public partial class AnimalTypeDataType
    {

        private string animalTypeCodeField;

        private string animalTypeNameField;

        private string totalNumbersEachLivestockField;

        private bool totalNumbersEachLivestockFieldSpecified;

        private string openConfinementCountField;

        private bool openConfinementCountFieldSpecified;

        private string housedUnderRoofConfinementCountField;

        private bool housedUnderRoofConfinementCountFieldSpecified;

        /// <remarks/>
        public string AnimalTypeCode
        {
            get
            {
                return this.animalTypeCodeField;
            }
            set
            {
                this.animalTypeCodeField = value;
            }
        }

        /// <remarks/>
        public string AnimalTypeName
        {
            get
            {
                return this.animalTypeNameField;
            }
            set
            {
                this.animalTypeNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("TotalNumbersEachLivestock")]
        public string TotalNumbersEachLivestock
        {
            get
            {
                return this.totalNumbersEachLivestockField;
            }
            set
            {
                this.totalNumbersEachLivestockField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TotalNumbersEachLivestockSpecified
        {
            get
            {
                return this.totalNumbersEachLivestockFieldSpecified;
            }
            set
            {
                this.totalNumbersEachLivestockFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string OpenConfinementCount
        {
            get
            {
                return this.openConfinementCountField;
            }
            set
            {
                this.openConfinementCountField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool OpenConfinementCountSpecified
        {
            get
            {
                return this.openConfinementCountFieldSpecified;
            }
            set
            {
                this.openConfinementCountFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string HousedUnderRoofConfinementCount
        {
            get
            {
                return this.housedUnderRoofConfinementCountField;
            }
            set
            {
                this.housedUnderRoofConfinementCountField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool HousedUnderRoofConfinementCountSpecified
        {
            get
            {
                return this.housedUnderRoofConfinementCountFieldSpecified;
            }
            set
            {
                this.housedUnderRoofConfinementCountFieldSpecified = value;
            }
        }
    }

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("PermitTypeCodeListIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class PermitTypeCodeListIdentifierDataType
    {

        private string codeListVersionIdentifierField;

        private string codeListVersionAgencyIdentifierField;

        private string valueField;

        /// <remarks/>
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

        /// <remarks/>
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

        /// <remarks/>
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

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("PermitType", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class PermitTypeDataType
    {

        private string permitTypeCodeField;

        private PermitTypeCodeListIdentifierDataType permitTypeCodeListIdentifierField;

        private string permitTypeNameField;

        /// <remarks/>
        public string PermitTypeCode
        {
            get
            {
                return this.permitTypeCodeField;
            }
            set
            {
                this.permitTypeCodeField = value;
            }
        }

        /// <remarks/>
        public PermitTypeCodeListIdentifierDataType PermitTypeCodeListIdentifier
        {
            get
            {
                return this.permitTypeCodeListIdentifierField;
            }
            set
            {
                this.permitTypeCodeListIdentifierField = value;
            }
        }

        /// <remarks/>
        public string PermitTypeName
        {
            get
            {
                return this.permitTypeNameField;
            }
            set
            {
                this.permitTypeNameField = value;
            }
        }
    }

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("OtherPermitIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class OtherPermitIdentifierDataType
    {

        private string otherPermitIdentifierContextField;

        private string valueField;

        /// <remarks/>
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

        /// <remarks/>
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

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("PermitIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class PermitIdentifierDataType
    {

        private string permitIdentifierContextField;

        private string valueField;

        /// <remarks/>
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

        /// <remarks/>
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

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("PermitIdentity", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class PermitIdentityDataType
    {

        private PermitIdentifierDataType permitIdentifierField;

        private string permitNameField;

        private OtherPermitIdentifierDataType otherPermitIdentifierField;

        private string programNameField;

        private PermitTypeDataType permitTypeField;

        /// <remarks/>
        public PermitIdentifierDataType PermitIdentifier
        {
            get
            {
                return this.permitIdentifierField;
            }
            set
            {
                this.permitIdentifierField = value;
            }
        }

        /// <remarks/>
        public string PermitName
        {
            get
            {
                return this.permitNameField;
            }
            set
            {
                this.permitNameField = value;
            }
        }

        /// <remarks/>
        public OtherPermitIdentifierDataType OtherPermitIdentifier
        {
            get
            {
                return this.otherPermitIdentifierField;
            }
            set
            {
                this.otherPermitIdentifierField = value;
            }
        }

        /// <remarks/>
        public string ProgramName
        {
            get
            {
                return this.programNameField;
            }
            set
            {
                this.programNameField = value;
            }
        }

        /// <remarks/>
        public PermitTypeDataType PermitType
        {
            get
            {
                return this.permitTypeField;
            }
            set
            {
                this.permitTypeField = value;
            }
        }
    }

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("MethodIdentifierCodeListIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class MethodIdentifierCodeListIdentifierDataType
    {

        private string codeListVersionIdentifierField;

        private string codeListVersionAgencyIdentifierField;

        private string valueField;

        /// <remarks/>
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

        /// <remarks/>
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

        /// <remarks/>
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

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("ResultQualifierCodeListIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class ResultQualifierCodeListIdentifierDataType
    {

        private string codeListVersionIdentifierField;

        private string codeListVersionAgencyIdentifierField;

        private string valueField;

        /// <remarks/>
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

        /// <remarks/>
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

        /// <remarks/>
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

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("ResultQualifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class ResultQualifierDataType
    {

        private string resultQualifierCodeField;

        private ResultQualifierCodeListIdentifierDataType resultQualifierCodeListIdentifierField;

        private string resultQualifierNameField;

        /// <remarks/>
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

        /// <remarks/>
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

        /// <remarks/>
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

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("MeasureUnitCodeListIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class MeasureUnitCodeListIdentifierDataType
    {

        private string codeListVersionIdentifierField;

        private string codeListVersionAgencyIdentifierField;

        private string valueField;

        /// <remarks/>
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

        /// <remarks/>
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

        /// <remarks/>
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

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("MeasureUnit", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class MeasureUnitDataType
    {

        private string measureUnitCodeField;

        private MeasureUnitCodeListIdentifierDataType measureUnitCodeListIdentifierField;

        private string measureUnitNameField;

        /// <remarks/>
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

        /// <remarks/>
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

        /// <remarks/>
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

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/CAFO/1_0")]
    [System.Xml.Serialization.XmlRootAttribute("GeographicLocationDescription", Namespace = "http://www.exchangenetwork.net/schema/CAFO/1_0", IsNullable = false)]
    public partial class GeographicLocationDataType
    {

        private string latitudeMeasureDecimalField;

        private string longitudeMeasureDecimalField;

        private MeasureDataType horizontalAccuracyMeasureField;

        private ReferenceMethodDataType horizontalMethodField;

        private string hydrologicUnitCodeField;

        private string locationCommentsTextField;

        /// <remarks/>
        public string LatitudeMeasureDecimal
        {
            get
            {
                return this.latitudeMeasureDecimalField;
            }
            set
            {
                this.latitudeMeasureDecimalField = value;
            }
        }

        /// <remarks/>
        public string LongitudeMeasureDecimal
        {
            get
            {
                return this.longitudeMeasureDecimalField;
            }
            set
            {
                this.longitudeMeasureDecimalField = value;
            }
        }

        /// <remarks/>
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

        /// <remarks/>
        public ReferenceMethodDataType HorizontalMethod
        {
            get
            {
                return this.horizontalMethodField;
            }
            set
            {
                this.horizontalMethodField = value;
            }
        }

        /// <remarks/>
        public string HydrologicUnitCode
        {
            get
            {
                return this.hydrologicUnitCodeField;
            }
            set
            {
                this.hydrologicUnitCodeField = value;
            }
        }

        /// <remarks/>
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
    }

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("HorizontalAccuracyMeasure", Namespace = "http://www.exchangenetwork.net/schema/CAFO/1_0", IsNullable = false)]
    public partial class MeasureDataType
    {

        private string measureValueField;

        private MeasureUnitDataType measureUnitField;

        private string measurePrecisionTextField;

        private ResultQualifierDataType resultQualifierField;

        /// <remarks/>
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

        /// <remarks/>
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

        /// <remarks/>
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

        /// <remarks/>
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

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("HorizontalMethod", Namespace = "http://www.exchangenetwork.net/schema/CAFO/1_0", IsNullable = false)]
    public partial class ReferenceMethodDataType
    {

        private string methodIdentifierCodeField;

        private MethodIdentifierCodeListIdentifierDataType methodIdentifierCodeListIdentifierField;

        private string methodNameField;

        private string methodDescriptionTextField;

        private string methodDeviationsTextField;

        /// <remarks/>
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

        /// <remarks/>
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

        /// <remarks/>
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

        /// <remarks/>
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

        /// <remarks/>
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

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/CAFO/1_0")]
    [System.Xml.Serialization.XmlRootAttribute("RegulatoryDetails", Namespace = "http://www.exchangenetwork.net/schema/CAFO/1_0", IsNullable = false)]
    public partial class RegulatoryDetailsDataType
    {

        private string dischargesFromProductionAreaIndicatorField;

        private bool dischargesFromProductionAreaIndicatorFieldSpecified;

        private string authorizedDischargeIndicatorField;

        private bool authorizedDischargeIndicatorFieldSpecified;

        private string unauthorizedDischargeIndicatorField;

        private bool unauthorizedDischargeIndicatorFieldSpecified;

        private string permittingAuthorityReportReceivedDateField;

        private bool permittingAuthorityReportReceivedDateFieldSpecified;

        private string isAnimalFacilityTypeCAFOIndicatorField;

        private bool isAnimalFacilityTypeCAFOIndicatorFieldSpecified;

        private MeasureDataType liquidManureWastewaterGeneratedAmountField;

        private MeasureDataType liquidManureWastewaterTransferAmountField;

        private MeasureDataType solidManureLitterGeneratedAmountField;

        private MeasureDataType solidManureLitterTransferAmountField;

        private string nMPDevelopedCertifiedPlannerApprovedIndicatorField;

        private bool nMPDevelopedCertifiedPlannerApprovedIndicatorFieldSpecified;

        private int totalNumberAcresNMPIdentifiedField;

        private bool totalNumberAcresNMPIdentifiedFieldSpecified;

        private int totalNumberAcresUsedLandApplicationField;

        private bool totalNumberAcresUsedLandApplicationFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PermitIdentity", Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
        public List<PermitIdentityDataType> PermitIdentity;

        /// <remarks/>
        public string DischargesFromProductionAreaIndicator
        {
            get
            {
                return this.dischargesFromProductionAreaIndicatorField;
            }
            set
            {
                this.dischargesFromProductionAreaIndicatorField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DischargesFromProductionAreaIndicatorSpecified
        {
            get
            {
                return this.dischargesFromProductionAreaIndicatorFieldSpecified;
            }
            set
            {
                this.dischargesFromProductionAreaIndicatorFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string AuthorizedDischargeIndicator
        {
            get
            {
                return this.authorizedDischargeIndicatorField;
            }
            set
            {
                this.authorizedDischargeIndicatorField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AuthorizedDischargeIndicatorSpecified
        {
            get
            {
                return this.authorizedDischargeIndicatorFieldSpecified;
            }
            set
            {
                this.authorizedDischargeIndicatorFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string UnauthorizedDischargeIndicator
        {
            get
            {
                return this.unauthorizedDischargeIndicatorField;
            }
            set
            {
                this.unauthorizedDischargeIndicatorField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool UnauthorizedDischargeIndicatorSpecified
        {
            get
            {
                return this.unauthorizedDischargeIndicatorFieldSpecified;
            }
            set
            {
                this.unauthorizedDischargeIndicatorFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute()]
        public string PermittingAuthorityReportReceivedDate
        {
            get
            {
                return this.permittingAuthorityReportReceivedDateField;
            }
            set
            {
                this.permittingAuthorityReportReceivedDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PermittingAuthorityReportReceivedDateSpecified
        {
            get
            {
                return this.permittingAuthorityReportReceivedDateFieldSpecified;
            }
            set
            {
                this.permittingAuthorityReportReceivedDateFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string IsAnimalFacilityTypeCAFOIndicator
        {
            get
            {
                return this.isAnimalFacilityTypeCAFOIndicatorField;
            }
            set
            {
                this.isAnimalFacilityTypeCAFOIndicatorField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IsAnimalFacilityTypeCAFOIndicatorSpecified
        {
            get
            {
                return this.isAnimalFacilityTypeCAFOIndicatorFieldSpecified;
            }
            set
            {
                this.isAnimalFacilityTypeCAFOIndicatorFieldSpecified = value;
            }
        }

        /// <remarks/>
        public MeasureDataType LiquidManureWastewaterGeneratedAmount
        {
            get
            {
                return this.liquidManureWastewaterGeneratedAmountField;
            }
            set
            {
                this.liquidManureWastewaterGeneratedAmountField = value;
            }
        }

        /// <remarks/>
        public MeasureDataType LiquidManureWastewaterTransferAmount
        {
            get
            {
                return this.liquidManureWastewaterTransferAmountField;
            }
            set
            {
                this.liquidManureWastewaterTransferAmountField = value;
            }
        }

        /// <remarks/>
        public MeasureDataType SolidManureLitterGeneratedAmount
        {
            get
            {
                return this.solidManureLitterGeneratedAmountField;
            }
            set
            {
                this.solidManureLitterGeneratedAmountField = value;
            }
        }

        /// <remarks/>
        public MeasureDataType SolidManureLitterTransferAmount
        {
            get
            {
                return this.solidManureLitterTransferAmountField;
            }
            set
            {
                this.solidManureLitterTransferAmountField = value;
            }
        }

        /// <remarks/>
        public string NMPDevelopedCertifiedPlannerApprovedIndicator
        {
            get
            {
                return this.nMPDevelopedCertifiedPlannerApprovedIndicatorField;
            }
            set
            {
                this.nMPDevelopedCertifiedPlannerApprovedIndicatorField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NMPDevelopedCertifiedPlannerApprovedIndicatorSpecified
        {
            get
            {
                return this.nMPDevelopedCertifiedPlannerApprovedIndicatorFieldSpecified;
            }
            set
            {
                this.nMPDevelopedCertifiedPlannerApprovedIndicatorFieldSpecified = value;
            }
        }

        /// <remarks/>
        public int TotalNumberAcresNMPIdentified
        {
            get
            {
                return this.totalNumberAcresNMPIdentifiedField;
            }
            set
            {
                this.totalNumberAcresNMPIdentifiedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TotalNumberAcresNMPIdentifiedSpecified
        {
            get
            {
                return this.totalNumberAcresNMPIdentifiedFieldSpecified;
            }
            set
            {
                this.totalNumberAcresNMPIdentifiedFieldSpecified = value;
            }
        }

        /// <remarks/>
        public int TotalNumberAcresUsedLandApplication
        {
            get
            {
                return this.totalNumberAcresUsedLandApplicationField;
            }
            set
            {
                this.totalNumberAcresUsedLandApplicationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TotalNumberAcresUsedLandApplicationSpecified
        {
            get
            {
                return this.totalNumberAcresUsedLandApplicationFieldSpecified;
            }
            set
            {
                this.totalNumberAcresUsedLandApplicationFieldSpecified = value;
            }
        }
    }

    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/CAFO/1_0")]
    [System.Xml.Serialization.XmlRootAttribute("LocationAddress", Namespace = "http://www.exchangenetwork.net/schema/CAFO/1_0", IsNullable = false)]
    public partial class LocationAddressDataType
    {

        private string locationAddressTextField;

        private string supplementalAddressTextField;

        private string localityNameField;

        private string countyNameField;

        private string stateNameField;

        private string stateUSPSCodeField;

        private AddressPostalCodeDataType addressPostalCodeField;

        /// <remarks/>
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

        /// <remarks/>
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

        /// <remarks/>
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

        /// <remarks/>
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

        /// <remarks/>
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

        /// <remarks/>
        public string StateUSPSCode
        {
            get
            {
                return this.stateUSPSCodeField;
            }
            set
            {
                this.stateUSPSCodeField = value;
            }
        }

        /// <remarks/>
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
    }

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("AddressPostalCode", Namespace = "http://www.exchangenetwork.net/schema/CAFO/1_0", IsNullable = false)]
    public partial class AddressPostalCodeDataType
    {

        private string addressPostalCodeContextField;

        private string valueField;

        /// <remarks/>
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

        /// <remarks/>
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

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/CAFO/1_0")]
    [System.Xml.Serialization.XmlRootAttribute("Facility", Namespace = "http://www.exchangenetwork.net/schema/CAFO/1_0", IsNullable = false)]
    public partial class CAFOFacilityDataType
    {

        private FacilitySiteIdentifierDataType facilityRegistryIdentifierField;

        private FacilitySiteIdentifierDataType stateFacilityIdentifierField;

        private string facilitySiteNameField;

        private string facilityAlternativeNameField;

        private string facilityInformationURLField;

        private LocationAddressDataType locationAddressField;

        private GeographicLocationDataType geographicLocationDescriptionField;

        private RegulatoryDetailsDataType regulatoryDetailsField;

        private List<AnimalTypeDataType> animalTypeField;

        /// <remarks/>
        public FacilitySiteIdentifierDataType FacilityRegistryIdentifier
        {
            get
            {
                return this.facilityRegistryIdentifierField;
            }
            set
            {
                this.facilityRegistryIdentifierField = value;
            }
        }

        /// <remarks/>
        public FacilitySiteIdentifierDataType StateFacilityIdentifier
        {
            get
            {
                return this.stateFacilityIdentifierField;
            }
            set
            {
                this.stateFacilityIdentifierField = value;
            }
        }

        /// <remarks/>
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

        /// <remarks/>
        public string FacilityAlternativeName
        {
            get
            {
                return this.facilityAlternativeNameField;
            }
            set
            {
                this.facilityAlternativeNameField = value;
            }
        }

        /// <remarks/>
        public string FacilityInformationURL
        {
            get
            {
                return this.facilityInformationURLField;
            }
            set
            {
                this.facilityInformationURLField = value;
            }
        }

        /// <remarks/>
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

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("GeographicLocationDescription")]
        public GeographicLocationDataType GeographicLocation
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

        /// <remarks/>
        public RegulatoryDetailsDataType RegulatoryDetails
        {
            get
            {
                return this.regulatoryDetailsField;
            }
            set
            {
                this.regulatoryDetailsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AnimalType")]
        public List<AnimalTypeDataType> AnimalTypeList
        {
            get
            {
                return this.animalTypeField;
            }
            set
            {
                this.animalTypeField = value;
            }
        }
    }

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("FacilityRegistryIdentifier", Namespace = "http://www.exchangenetwork.net/schema/CAFO/1_0", IsNullable = false)]
    public partial class FacilitySiteIdentifierDataType
    {

        private string facilitySiteIdentifierContextField;

        private string valueField;

        /// <remarks/>
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

        /// <remarks/>
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

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/CAFO/1_0")]
    [System.Xml.Serialization.XmlRootAttribute("FacilityList", Namespace = "http://www.exchangenetwork.net/schema/CAFO/1_0", IsNullable = false)]
    public partial class CAFOFacilityList
    {


        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Facility")]
        public List<CAFOFacilityDataType> CAFOFacilities;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string schemaVersion = "1.0";
    }

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("AccreditationAuthorityIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class AccreditationAuthorityIdentifierDataType
    {

        private string accreditationAuthorityIdentifierContextField;

        private string valueField;

        /// <remarks/>
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

        /// <remarks/>
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
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("AgencyCodeListIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class AgencyCodeListIdentifierDataType
    {

        private string codeListVersionIdentifierField;

        private string codeListVersionAgencyIdentifierField;

        private string valueField;

        /// <remarks/>
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

        /// <remarks/>
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

        /// <remarks/>
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

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("AgencyTypeCodeListIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class AgencyTypeCodeListIdentifierDataType
    {

        private string codeListVersionIdentifierField;

        private string codeListVersionAgencyIdentifierField;

        private string valueField;

        /// <remarks/>
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

        /// <remarks/>
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

        /// <remarks/>
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

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("BiologicalGroupName", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class BiologicalGroupNameDataType
    {

        private string biologicalGroupNameContextField;

        private string valueField;

        /// <remarks/>
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

        /// <remarks/>
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

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("BiologicalSynonymName", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class BiologicalSynonymNameDataType
    {

        private string biologicalSynonymNameContextField;

        private string valueField;

        /// <remarks/>
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

        /// <remarks/>
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

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("BiologicalSystematicName", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class BiologicalSystematicNameDataType
    {

        private string biologicalSystematicNameContextField;

        private string valueField;

        /// <remarks/>
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

        /// <remarks/>
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

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("BiologicalVernacularName", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class BiologicalVernacularNameDataType
    {

        private string biologicalVernacularNameContextField;

        private string valueField;

        /// <remarks/>
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

        /// <remarks/>
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

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("ComplianceMilestoneIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class ComplianceMilestoneIdentifierDataType
    {

        private string complianceMilestoneIdentifierContextField;

        private string valueField;

        /// <remarks/>
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

        /// <remarks/>
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
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("ComplianceMilestoneTypeCodeListIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class ComplianceMilestoneTypeCodeListIdentifierDataType
    {

        private string codeListVersionIdentifierField;

        private string codeListVersionAgencyIdentifierField;

        private string valueField;

        /// <remarks/>
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

        /// <remarks/>
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

        /// <remarks/>
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
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("ComplianceScheduleIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class ComplianceScheduleIdentifierDataType
    {

        private string complianceScheduleIdentifierContextField;

        private string valueField;

        /// <remarks/>
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

        /// <remarks/>
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
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("ConditionIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class ConditionIdentifierDataType
    {

        private string conditionIdentifierContextField;

        private string valueField;

        /// <remarks/>
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

        /// <remarks/>
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

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("CoordinateDataSourceCodeListIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class CoordinateDataSourceCodeListIdentifierDataType
    {

        private string codeListVersionIdentifierField;

        private string codeListVersionAgencyIdentifierField;

        private string valueField;

        /// <remarks/>
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

        /// <remarks/>
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

        /// <remarks/>
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

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("CountryCodeListIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class CountryCodeListIdentifierDataType
    {

        private string codeListVersionIdentifierField;

        private string codeListVersionAgencyIdentifierField;

        private string valueField;

        /// <remarks/>
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

        /// <remarks/>
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

        /// <remarks/>
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

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("CountyCodeListIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class CountyCodeListIdentifierDataType
    {

        private string codeListVersionIdentifierField;

        private string codeListVersionAgencyIdentifierField;

        private string valueField;

        /// <remarks/>
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

        /// <remarks/>
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

        /// <remarks/>
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
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("EnforcementActionIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class EnforcementActionIdentifierDataType
    {

        private string enforcementActionIdentifierContextField;

        private string valueField;

        /// <remarks/>
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

        /// <remarks/>
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

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("FacilityManagementTypeCodeListIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class FacilityManagementTypeCodeListIdentifierDataType
    {

        private string codeListVersionIdentifierField;

        private string codeListVersionAgencyIdentifierField;

        private string valueField;

        /// <remarks/>
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

        /// <remarks/>
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

        /// <remarks/>
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

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("FacilitySiteTypeCodeListIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class FacilitySiteTypeCodeListIdentifierDataType
    {

        private string codeListVersionIdentifierField;

        private string codeListVersionAgencyIdentifierField;

        private string valueField;

        /// <remarks/>
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

        /// <remarks/>
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

        /// <remarks/>
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
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("FormIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class FormIdentifierDataType
    {

        private string formIdentifierContextField;

        private string valueField;

        /// <remarks/>
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

        /// <remarks/>
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

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("GeographicReferenceDatumCodeListIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class GeographicReferenceDatumCodeListIdentifierDataType
    {

        private string codeListVersionIdentifierField;

        private string codeListVersionAgencyIdentifierField;

        private string valueField;

        /// <remarks/>
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

        /// <remarks/>
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

        /// <remarks/>
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

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("GeometricTypeCodeListIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class GeometricTypeCodeListIdentifierDataType
    {

        private string codeListVersionIdentifierField;

        private string codeListVersionAgencyIdentifierField;

        private string valueField;

        /// <remarks/>
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

        /// <remarks/>
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

        /// <remarks/>
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

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("IndividualIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class IndividualIdentifierDataType
    {

        private string individualIdentifierContextField;

        private string valueField;

        /// <remarks/>
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

        /// <remarks/>
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

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("InjunctiveReliefIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class InjunctiveReliefIdentifierDataType
    {

        private string injunctiveReliefIdentifierContextField;

        private string valueField;

        /// <remarks/>
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

        /// <remarks/>
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

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("LaboratoryIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class LaboratoryIdentifierDataType
    {

        private string laboratoryIdentifierContextField;

        private string valueField;

        /// <remarks/>
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

        /// <remarks/>
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

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("MonitoringLocationIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class MonitoringLocationIdentifierDataType
    {

        private string monitoringLocationIdentifierContextField;

        private string valueField;

        /// <remarks/>
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

        /// <remarks/>
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
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("OrganizationIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class OrganizationIdentifierDataType
    {

        private string organizationIdentifierContextField;

        private string valueField;

        /// <remarks/>
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

        /// <remarks/>
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

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("PenaltyIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class PenaltyIdentifierDataType
    {

        private string penaltyIdentifierContextField;

        private string valueField;

        /// <remarks/>
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

        /// <remarks/>
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

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("PermittedFeatureIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class PermittedFeatureIdentifierDataType
    {

        private string permittedFeatureIdentifierContextField;

        private string valueField;

        /// <remarks/>
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

        /// <remarks/>
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

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("ReferencePointCodeListIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class ReferencePointCodeListIdentifierDataType
    {

        private string codeListVersionIdentifierField;

        private string codeListVersionAgencyIdentifierField;

        private string valueField;

        /// <remarks/>
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

        /// <remarks/>
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

        /// <remarks/>
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

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("ReportIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class ReportIdentifierDataType
    {

        private string reportIdentifierContextField;

        private string valueField;

        /// <remarks/>
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

        /// <remarks/>
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

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("ReportTypeCodeListIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class ReportTypeCodeListIdentifierDataType
    {

        private string codeListVersionIdentifierField;

        private string codeListVersionAgencyIdentifierField;

        private string valueField;

        /// <remarks/>
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

        /// <remarks/>
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

        /// <remarks/>
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
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("StateCodeListIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class StateCodeListIdentifierDataType
    {

        private string codeListVersionIdentifierField;

        private string codeListVersionAgencyIdentifierField;

        private string valueField;

        /// <remarks/>
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

        /// <remarks/>
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

        /// <remarks/>
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

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("SubstanceIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class SubstanceIdentifierDataType
    {

        private string substanceIdentifierContextField;

        private string valueField;

        /// <remarks/>
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

        /// <remarks/>
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

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("SubstanceName", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class SubstanceNameDataType
    {

        private string substanceNameContextField;

        private string valueField;

        /// <remarks/>
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

        /// <remarks/>
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

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("TribalCodeListIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class TribalCodeListIdentifierDataType
    {

        private string codeListVersionIdentifierField;

        private string codeListVersionAgencyIdentifierField;

        private string valueField;

        /// <remarks/>
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

        /// <remarks/>
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

        /// <remarks/>
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
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("ViolationIdentifer", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class ViolationIdentiferDataType
    {

        private string violationIdentiferContextField;

        private string valueField;

        /// <remarks/>
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

        /// <remarks/>
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

    /// <remarks/>

    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:us:net:exchangenetwork:sc:1:0")]
    [System.Xml.Serialization.XmlRootAttribute("ViolationTypeCodeListIdentifier", Namespace = "urn:us:net:exchangenetwork:sc:1:0", IsNullable = false)]
    public partial class ViolationTypeCodeListIdentifierDataType
    {

        private string codeListVersionIdentifierField;

        private string codeListVersionAgencyIdentifierField;

        private string valueField;

        /// <remarks/>
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

        /// <remarks/>
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

        /// <remarks/>
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