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

using System.Data;
using Windsor.Commons.XsdOrm;

namespace Windsor.Node2008.WNOSPlugin.HERE.TANKS10 {


    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/tanks/1")]
    [System.Xml.Serialization.XmlRootAttribute("TankTypeText", Namespace = "http://www.exchangenetwork.net/schema/tanks/1", IsNullable = false)]
    public enum TankTypeTextDataType
    {

        /// <remarks/>
        AST,

        /// <remarks/>
        UST,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/tanks/1")]
    [System.Xml.Serialization.XmlRootAttribute("TankPiping", Namespace = "http://www.exchangenetwork.net/schema/tanks/1", IsNullable = false)]
    public partial class TankPipingDataType
    {
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The type of piping system utilized by the storage tank. For exampe, pressurized, " +
            "suction, or safe suction.")]
        public string PipingSystemTypeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 1)]
        [System.Xml.Serialization.XmlArrayItemAttribute("PipingConstructionText", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("List of materials or construction methods used in the tank piping.")]
        public string[] PipingConstruction;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The material or construction method used in the tank piping..")]
        public bool PipingHasSecondaryContainmentIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PipingHasSecondaryContainmentIndicatorSpecified;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/tanks/1")]
    [System.Xml.Serialization.XmlRootAttribute("FacilitySiteIdentifier", Namespace = "http://www.exchangenetwork.net/schema/tanks/1", IsNullable = false)]
    public partial class FacilitySiteIdentifierDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FacilitySiteIdentifierContext;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        // TSM:
        [Column("FAC_SITE_IDEN")]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/tanks/1")]
    [System.Xml.Serialization.XmlRootAttribute("FacilitySiteTypeCodeListIdentifier", Namespace = "http://www.exchangenetwork.net/schema/tanks/1", IsNullable = false)]
    public partial class FacilitySiteTypeCodeListIdentifierDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CodeListVersionAgencyIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        // TSM:
        [Column("CODE_LIST_VALUE")]
        public string Value;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/tanks/1")]
    [System.Xml.Serialization.XmlRootAttribute("FederalFacilityIndicator", Namespace = "http://www.exchangenetwork.net/schema/tanks/1", IsNullable = false)]
    public enum FederalFacilityIndicatorDataType
    {

        /// <remarks/>
        Y,

        /// <remarks/>
        N,

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("")]
        Item,
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/tanks/1")]
    [System.Xml.Serialization.XmlRootAttribute("ChemicalSubstanceIdentity", Namespace = "http://www.exchangenetwork.net/schema/tanks/1", IsNullable = false)]
    public partial class ChemicalSubstanceIdentityDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The unique record number assigned to all chemical substances and chemical groupin" +
            "gs for internal tracking within EPA systems.")]
        public string EPAChemicalInternalNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The unique number assigned by Chemical Abstracts Service (CAS) to a chemical subs" +
            "tance.")]
        public string CASRegistryNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The name assigned to a chemical substance that describes it in terms of its molec" +
            "ular composition.")]
        public string ChemicalSubstanceSystematicName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("The name that the Environmental Protection Agency has selected as its preferred n" +
            "ame for a chemical substance.")]
        public string EPAChemicalRegistryName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("The unique number assigned to all chemical substances and chemical groupings for " +
            "which a CAS Registry Number does not exist and cannot be assigned.")]
        public string EPAChemicalIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The name that identifies the circumstances for which a chemical substance name is" +
            " used.")]
        public string ChemicalNameContextName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        [System.ComponentModel.DescriptionAttribute("The source of the Environmental Protection Agency chemical registry name.")]
        public string EPAChemicalRegistryNameSourceText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 7)]
        [System.ComponentModel.DescriptionAttribute("The type of source for the Environmental Protection Agency chemical registry name" +
            ".")]
        public string EPAChemicalRegistryNameContextName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("The text that provides clarification to the identity of a chemical substance.")]
        public string ChemicalSubstanceDefinitionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("The text that provides additional information about a chemical substance.")]
        public string ChemicalSubstanceCommentText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 10)]
        [System.ComponentModel.DescriptionAttribute("A name that is used as the alternative for representing a chemical substance.")]
        public string ChemicalSubstanceSynonymName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 11)]
        [System.ComponentModel.DescriptionAttribute("The code that represents the number of atoms of each element in a molecule of a c" +
            "hemical substance.")]
        public string MolecularFormulaCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 12)]
        [System.ComponentModel.DescriptionAttribute("The sum of the atomic weights of constituent atoms in a molecule of a chemical su" +
            "bstance.")]
        public string ChemicalSubstanceFormulaWeightQuantity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 13)]
        [System.ComponentModel.DescriptionAttribute("A descriptive name for types of chemical substances.")]
        public string ChemicalSubstanceTypeName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 14)]
        [System.ComponentModel.DescriptionAttribute("The code that represents the connectivity of atoms in a molecule of a chemical su" +
            "bstance as a linear formula, such as SMILES.")]
        public string ChemicalSubstanceLinearStructureCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 15)]
        [System.ComponentModel.DescriptionAttribute("A graphical representation of a molecule of a chemical substance as a two or thre" +
            "e dimensional diagram.")]
        public string ChemicalStructureGraphicalDiagram;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 16)]
        [System.ComponentModel.DescriptionAttribute("The name of a schema that classifies chemical substances according to structural " +
            "similarities.")]
        public string ChemicalSubstanceClassificationName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 17)]
        [System.ComponentModel.DescriptionAttribute("The name that documents the correctness of a synonym for a specific chemical subs" +
            "tance.")]
        public string ChemicalSynonymStatusName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 18)]
        [System.ComponentModel.DescriptionAttribute("The name of the source of an alternate name for a chemical substance.")]
        public string ChemicalSynonymSourceName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/tanks/1")]
    [System.Xml.Serialization.XmlRootAttribute("TankContents", Namespace = "http://www.exchangenetwork.net/schema/tanks/1", IsNullable = false)]
    public partial class TankContentsDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Indicates if the contents of the tank compartment is a mixture of chemicals, or n" +
            "ot.")]
        public bool TankContentIsMixtureIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TankContentIsMixtureIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Indicates if the contents of the tank compartment is considered confidential info" +
            "rmation, or not.")]
        public bool TankContentIsConfidentialIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TankContentIsConfidentialIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ChemicalSubstanceIdentity", Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The Chemical Identification Block provides for the use of common identifiers for " +
            "all chemical substances regulated or monitored by environmental programs.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public ChemicalSubstanceIdentityDataType[] ChemicalSubstanceIdentity;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/tanks/1")]
    [System.Xml.Serialization.XmlRootAttribute("TankCompartment", Namespace = "http://www.exchangenetwork.net/schema/tanks/1", IsNullable = false)]
    public partial class TankCompartmentDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "positiveInteger", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Maximum capacity of the storage tank, in gallons.")]
        public string TankCompartmentCapacityNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("If applicable, date that the compartment within the storage tank was installed.")]
        public System.DateTime TankCompartmentInstallationDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TankCompartmentInstallationDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The unique identification number used by a government entity to identify a storag" +
            "e tank compartment.")]
        public string TankCompartmentIdentifierText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Identifies the secondary containment method, if any, of the storage tank compartm" +
            "ent.")]
        public bool TankCompartmentHasSecondaryContainmentIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TankCompartmentHasSecondaryContainmentIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Storage tank piping schema containing tank piping specific data elements.")]
        public TankPipingDataType TankPiping;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("Storage tank schema containing tank chemical/substance contents.")]
        public TankContentsDataType TankContents;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/tanks/1")]
    [System.Xml.Serialization.XmlRootAttribute("Tank", Namespace = "http://www.exchangenetwork.net/schema/tanks/1", IsNullable = false)]
    public partial class TankDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Code identifying a storage tank as an aboveground (AST) or underground (UST) tank" +
            ".")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public TankTypeTextDataType TankTypeText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Identifies if the storage tank is currently being used, is temporarily/permanentl" +
            "y out of service, and has been filled or removed.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public string TankUseStatusText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The unique identification number used by a government entity to identify a storag" +
            "e tank.")]
        public string TankIdentifierText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 3)]
        [System.ComponentModel.DescriptionAttribute("Date that the storage tank was installed at the facility site.")]
        public System.DateTime TankInstallationDate;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TankInstallationDateSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
        [System.ComponentModel.DescriptionAttribute("Indicates if the location or details of the tank is considered confidential infor" +
            "mation, or not.")]
        public bool TankIsConfidentialIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TankIsConfidentialIndicatorSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
        [System.ComponentModel.DescriptionAttribute("The material used in the construction of the storage tank. For example, steel, co" +
            "ncrete, fiberglass, unknown, or other.")]
        public string TankConstructionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 6)]
        [System.Xml.Serialization.XmlArrayItemAttribute("TankExternalProtectionText", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("List of external protection methods for a storage tank.")]
        public string[] TankExternalProtection;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order = 7)]
        [System.Xml.Serialization.XmlArrayItemAttribute("TankInternalProtectionText", IsNullable = false)]
        [System.ComponentModel.DescriptionAttribute("List of internal protection methods for a storage tank.")]
        public string[] TankInternalProtection;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 8)]
        [System.ComponentModel.DescriptionAttribute("Any additional descriptive text that could be used to identify or describe the st" +
            "orage tank.")]
        public string TankDescriptionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 9)]
        [System.ComponentModel.DescriptionAttribute("A brief description of the storage tank location at the facility.")]
        public string TankLocationDescriptionText;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("TankCompartment", Order = 10)]
        [System.ComponentModel.DescriptionAttribute("Storage Tank compartment schema containing tank compartment specific data element" +
            "s.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public TankCompartmentDataType[] TankCompartment;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/tanks/1")]
    [System.Xml.Serialization.XmlRootAttribute("FacilitySiteType", Namespace = "http://www.exchangenetwork.net/schema/tanks/1", IsNullable = false)]
    public partial class FacilitySiteDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The code that represents the type of site a facility occupies.")]
        public string FacilitySiteTypeCode;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("A designator specifying the code set used to provide a facility site type code. C" +
            "an be used to identify the URL of a source that defines the set of currently app" +
            "roved permitted values.")]
        public FacilitySiteTypeCodeListIdentifierDataType FacilitySiteTypeCodeListIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("The descriptive name for the type of site the facility occupies.")]
        public string FacilitySiteTypeName;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/tanks/1")]
    [System.Xml.Serialization.XmlRootAttribute("FacilitySiteIdentity", Namespace = "http://www.exchangenetwork.net/schema/tanks/1", IsNullable = false)]
    public partial class FacilitySiteIdentityDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("The unique identification number used by a governmental entity to identify a faci" +
            "lity site.")]
        public FacilitySiteIdentifierDataType FacilitySiteIdentifier;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        [System.ComponentModel.DescriptionAttribute("The public or commercial name of a facility site (i.e., the full name that common" +
            "ly appears on invoices, signs, or other business documents, or as assigned by th" +
            "e state when the name is ambiguous).")]
        public string FacilitySiteName;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
        [System.ComponentModel.DescriptionAttribute("A designator and associated metadata used to represents the type of site a facili" +
            "ty occupies.")]
        public FacilitySiteDataType FacilitySiteType;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
        [System.ComponentModel.DescriptionAttribute("An indicator identifying facilities owned or operated by a federal government uni" +
            "t.")]
        public FederalFacilityIndicatorDataType FederalFacilityIndicator;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool FederalFacilityIndicatorSpecified;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/tanks/1")]
    [System.Xml.Serialization.XmlRootAttribute("TanksFacilitySite", Namespace = "http://www.exchangenetwork.net/schema/tanks/1", IsNullable = false)]
    public partial class TanksFacilitySiteDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Basic information used by an organization to identify a facility or site.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public FacilitySiteIdentityDataType FacilitySiteIdentity;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Tank", Order = 1)]
        [System.ComponentModel.DescriptionAttribute("Storage Tank schema containing tank specific data elements.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public TankDataType[] Tank;
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.exchangenetwork.net/schema/tanks/1")]
    [System.Xml.Serialization.XmlRootAttribute("TanksSubmission", Namespace = "http://www.exchangenetwork.net/schema/tanks/1", IsNullable = false)]
    public partial class TanksSubmissionDataType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("TanksFacilitySite", Order = 0)]
        [System.ComponentModel.DescriptionAttribute("Main component schema containing facility and tank information.")]
        [Windsor.Commons.XsdOrm.DbNotNullAttribute()]
        public TanksFacilitySiteDataType[] TanksFacilitySite;
    }
}
