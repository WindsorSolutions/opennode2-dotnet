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

using System.Xml.Serialization;
using System.Data;
using Windsor.Commons.XsdOrm;
using Windsor.Commons.Core;

namespace Windsor.Node2008.WNOSPlugin.HERE.TANKS10
{
    [AbbreviationsAttribute("FACILITY", "FAC",
                            "COMPARTMENT", "COMPART",
                            "INSTALLATION", "INSTALL",
                            "NUMBER", "NUM",
                            "SECONDARY", "SEC",
                            "CONTAINMENT", "CONT",
                            "INDICATOR", "IND",
                            "CHEMICAL", "CHEM",
                            "SUBSTANCE", "SUBS",
                            "IDENTITY", "IDEN",
                            "CONFIDENTIAL", "CONF",
                            "EPACHEMICAL", "EPA_CHEM",
                            "CASREGISTRY", "CAS_REG",
                            "SOURCE", "SRC",
                            "REGISTRY", "REG",
                            "WEIGHT", "WGHT",
                            "QUANTITY", "QNTY",
                            "STRUCTURE", "STRU",
                            "CONSTRUCTION", "CONST",
                            "LOCATION", "LOC",
                            "DESCRIPTION", "DESC",
                            "IDENTIFIER", "IDEN")]
    [DefaultStringDbValues(DbType.AnsiString, 255)]
    [DefaultElementNamePostfixLengthsAttribute("Text", "255",
                                               "Name", "128",
                                               "Code", "50",
                                               "Value", "50",
                                               "CodeContext", "50",
                                               "Identifier", "50",
                                               "Number", "50")]
    [DefaultTableNamePrefixAttribute("TANKS")]
    [AppliedAttribute(typeof(TankPipingDataType), "PipingConstruction", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(TankDataType), "TankExternalProtection", typeof(DbIgnoreAttribute))]
    [AppliedAttribute(typeof(TankDataType), "TankInternalProtection", typeof(DbIgnoreAttribute))]

    public partial class TanksSubmissionDataType : IBeforeSaveToDatabase, IAfterLoadFromDatabase
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey]
        public string SubmissionId;
 
        public void BeforeSaveToDatabase()
        {
            CollectionUtils.ForEach(TanksFacilitySite, delegate(TanksFacilitySiteDataType obj)
            {
                obj.BeforeSaveToDatabase();
            });
        }
        public void AfterLoadFromDatabase()
        {
            CollectionUtils.ForEach(TanksFacilitySite, delegate(TanksFacilitySiteDataType obj)
            {
                obj.AfterLoadFromDatabase();
            });
        }
    }

    public partial class TanksFacilitySiteDataType : IBeforeSaveToDatabase, IAfterLoadFromDatabase
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey]
        public string FacilitySiteId;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey]
        public string SubmissionId;

        public void BeforeSaveToDatabase()
        {
            CollectionUtils.ForEach(Tank, delegate(TankDataType obj)
            {
                obj.BeforeSaveToDatabase();
            });
        }
        public void AfterLoadFromDatabase()
        {
            CollectionUtils.ForEach(Tank, delegate(TankDataType obj)
            {
                obj.AfterLoadFromDatabase();
            });
        }
    }

    public partial class TankDataType : IBeforeSaveToDatabase, IAfterLoadFromDatabase
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey]
        public string TankId;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey]
        public string FacilitySiteId;

        [System.Xml.Serialization.XmlIgnore]
        public ExternalProtectionDataType[] ExternalProtections;

        [System.Xml.Serialization.XmlIgnore]
        public InternalProtectionDataType[] InternalProtections;

        public void BeforeSaveToDatabase()
        {
            if (!CollectionUtils.IsNullOrEmpty(TankExternalProtection))
            {
                ExternalProtections = new ExternalProtectionDataType[TankExternalProtection.Length];
                for (int i = 0; i < TankExternalProtection.Length; ++i)
                {
                    ExternalProtections[i] = new ExternalProtectionDataType();
                    ExternalProtections[i].Text = TankExternalProtection[i];
                }
            }
            if (!CollectionUtils.IsNullOrEmpty(TankInternalProtection))
            {
                InternalProtections = new InternalProtectionDataType[TankInternalProtection.Length];
                for (int i = 0; i < TankInternalProtection.Length; ++i)
                {
                    InternalProtections[i] = new InternalProtectionDataType();
                    InternalProtections[i].Text = TankInternalProtection[i];
                }
            }
            CollectionUtils.ForEach(TankCompartment, delegate(TankCompartmentDataType obj)
            {
                obj.BeforeSaveToDatabase();
            });
        }
        public void AfterLoadFromDatabase()
        {
            if (!CollectionUtils.IsNullOrEmpty(ExternalProtections))
            {
                TankExternalProtection = new string[ExternalProtections.Length];
                for (int i = 0; i < ExternalProtections.Length; ++i)
                {
                    TankExternalProtection[i] = ExternalProtections[i].Text;
                }
            }
            if (!CollectionUtils.IsNullOrEmpty(InternalProtections))
            {
                TankInternalProtection = new string[InternalProtections.Length];
                for (int i = 0; i < InternalProtections.Length; ++i)
                {
                    TankInternalProtection[i] = InternalProtections[i].Text;
                }
            }
            CollectionUtils.ForEach(TankCompartment, delegate(TankCompartmentDataType obj)
            {
                obj.AfterLoadFromDatabase();
            });
        }
    }

    public partial class TankCompartmentDataType : IBeforeSaveToDatabase, IAfterLoadFromDatabase
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey]
        public string TankCompartmentId;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey]
        public string TankId;
        
        public void BeforeSaveToDatabase()
        {
            if (TankPiping != null)
            {
                TankPiping.BeforeSaveToDatabase();
            }
        }
        public void AfterLoadFromDatabase()
        {
            if (TankPiping != null)
            {
                TankPiping.AfterLoadFromDatabase();
            }
        }
    }

    public partial class ChemicalSubstanceIdentityDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey]
        public string ChemicalSubstanceIdentityId;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey]
        public string TankCompartmentId;
    }
    public partial class TankPipingDataType : IBeforeSaveToDatabase, IAfterLoadFromDatabase
    {
        [System.Xml.Serialization.XmlIgnore]
        public PipingConstructionDataType[] PipingConstructions;
        
        public void BeforeSaveToDatabase()
        {
            if (!CollectionUtils.IsNullOrEmpty(PipingConstruction))
            {
                PipingConstructions = new PipingConstructionDataType[PipingConstruction.Length];
                for (int i = 0; i < PipingConstruction.Length; ++i)
                {
                    PipingConstructions[i] = new PipingConstructionDataType();
                    PipingConstructions[i].Text = PipingConstruction[i];
                }
            }
        }
        public void AfterLoadFromDatabase()
        {
            if (!CollectionUtils.IsNullOrEmpty(PipingConstructions))
            {
                PipingConstruction = new string[PipingConstructions.Length];
                for (int i = 0; i < PipingConstructions.Length; ++i)
                {
                    PipingConstruction[i] = PipingConstructions[i].Text;
                }
            }
        }
    }

    public class PipingConstructionDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey]
        public string PipingConstructionId;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey]
        public string TankCompartmentId;

        [System.Xml.Serialization.XmlIgnore]
        public string Text;
    }

    public class ExternalProtectionDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey]
        public string ExternalProtectionId;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey]
        public string TankId;

        [System.Xml.Serialization.XmlIgnore]
        public string Text;
    }

    public class InternalProtectionDataType
    {
        [System.Xml.Serialization.XmlIgnore]
        [GuidPrimaryKey]
        public string InternalProtectionId;

        [System.Xml.Serialization.XmlIgnore]
        [GuidForeignKey]
        public string TankId;

        [System.Xml.Serialization.XmlIgnore]
        public string Text;
    }
}
