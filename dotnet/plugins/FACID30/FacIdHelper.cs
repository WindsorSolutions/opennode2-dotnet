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
using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSProviders;
using Spring.Data.Common;
using Spring.Transaction.Support;
using Spring.Data.Core;
using System.ComponentModel;
using Windsor.Commons.Core;
using Windsor.Commons.Logging;
using Windsor.Commons.Spring;
using Windsor.Commons.XsdOrm;
using System.Text.RegularExpressions;

namespace Windsor.Node2008.WNOSPlugin.FACID30
{
    public static class FacIdHelper
    {
        public static string GetFacilityId(FacilityDataType facility)
        {
            if ((facility != null) && (facility.FacilitySiteIdentity != null) &&
                 (facility.FacilitySiteIdentity.FacilitySiteIdentifier != null) &&
                 !string.IsNullOrEmpty(facility.FacilitySiteIdentity.FacilitySiteIdentifier.Value))
            {
                return facility.FacilitySiteIdentity.FacilitySiteIdentifier.Value;
            }
            return null;
        }

        public static FacilityDetailsDataType CombineFacilityDetailsQueryResults(List<FacilityDetailsDataType> list)
        {
            if (CollectionUtils.IsNullOrEmpty(list))
            {
                return new FacilityDetailsDataType();
            }
            Dictionary<string, FacilityDataType> facilities = new Dictionary<string, FacilityDataType>();
            Dictionary<string, AffiliateDataType> affiliates = new Dictionary<string, AffiliateDataType>();
            foreach (FacilityDetailsDataType facilityDetails in list)
            {
                Dictionary<string, AffiliateDataType> validAffiliates = new Dictionary<string, AffiliateDataType>();
                if (!CollectionUtils.IsNullOrEmpty(facilityDetails.FacilityList))
                {
                    for (int i = 0; i < facilityDetails.FacilityList.Length; ++i)
                    {
                        FacilityDataType facility = facilityDetails.FacilityList[i];
                        string facilityId = GetFacilityId(facility);
                        if ((facilityId == null) || facilities.ContainsKey(facilityId)) continue;

                        facilities.Add(facilityId, facility);
                        if (!CollectionUtils.IsNullOrEmpty(facilityDetails.AffiliateList))
                        {
                            if (!CollectionUtils.IsNullOrEmpty(facility.AffiliationList))
                            {
                                foreach (FacilityFacilityAffiliationDataType facilityAffilitate in facility.AffiliationList)
                                {
                                    if (!validAffiliates.ContainsKey(facilityAffilitate.AffiliateIdentifier))
                                    {
                                        validAffiliates.Add(facilityAffilitate.AffiliateIdentifier, null);
                                    }
                                }
                            }
                            if (!CollectionUtils.IsNullOrEmpty(facility.EnvironmentalInterestList))
                            {
                                foreach (EnvironmentalInterestDataType environmentalInterest in facility.EnvironmentalInterestList)
                                {
                                    if (!CollectionUtils.IsNullOrEmpty(environmentalInterest.AffiliationList))
                                    {
                                        foreach (EnvironmentalInterestFacilityAffiliationDataType
                                            environmentalInterestAffiliation in environmentalInterest.AffiliationList)
                                        {
                                            if (!validAffiliates.ContainsKey(environmentalInterestAffiliation.AffiliateIdentifier))
                                            {
                                                validAffiliates.Add(environmentalInterestAffiliation.AffiliateIdentifier, null);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (!CollectionUtils.IsNullOrEmpty(facilityDetails.AffiliateList))
                {
                    foreach (AffiliateDataType affilitate in facilityDetails.AffiliateList)
                    {
                        if (validAffiliates.ContainsKey(affilitate.AffiliateIdentifier) &&
                            !affiliates.ContainsKey(affilitate.AffiliateIdentifier))
                        {
                            affiliates.Add(affilitate.AffiliateIdentifier, affilitate);
                        }
                    }
                }
            }
            FacilityDetailsDataType rtnFacilityDetails = new FacilityDetailsDataType();
            if (facilities.Count > 0)
            {
                rtnFacilityDetails.FacilityList = new List<FacilityDataType>(facilities.Values).ToArray();
                if (affiliates.Count > 0)
                {
                    rtnFacilityDetails.AffiliateList = new List<AffiliateDataType>(affiliates.Values).ToArray();
                }
            }
            return rtnFacilityDetails;
        }
    }
}
