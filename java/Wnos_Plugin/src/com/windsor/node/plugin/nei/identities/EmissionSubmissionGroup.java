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

/*
 * Created on Dec 16, 2004
 *
 */
package com.windsor.node.plugin.nei.identities;

/**
 * 
 */
public class EmissionSubmissionGroup extends BaseClass {

    public String EmissionRecordTypeCode;
    public String CountyStateFIPSCode;
    public String StateFacilityIdentifier;
    public String EmissionUnitIdentifier;
    public String ProcessIdentifier;
    public String PollutantCode;
    public String blank = "";
    public String ReleasePointIdentifier;
    public String EmissionPeriodStartDate;
    public String EmissionPeriodEndDate;
    public String EmissionPeriodStartTime;
    public String EmissionPeriodEndTime;
    public String blank2 = "";
    public String EmissionValue;
    public String EmissionUnitNumeratorValue;
    public String EmissionTypeCode;
    public String ReliabilityIndicator;
    public String EmissionFactorValue;
    public String FactorUnitNumeratorValue;
    public String FactorUnitDenominatorValue;
    public String MaterialCode;
    public String MaterialInputOutputCode;
    public String blank3 = "";
    public String EmissionCalculationMethodCode;
    public String EmissionFactorReliabilityIndicator;
    public String RuleEffectivenessMeasure;
    public String RuleEffectivenessMethodCode;
    public String blank4 = "";
    public String HAPEmissionsPerformanceLevelCode;
    public String ControlStatusCode;
    public String EmissionDataLevelIdentifier;
    public String TransactionSubmittalCode;
    public String TribalCode;
}