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

namespace Windsor.Node2008.WNOSPlugin.PNWWQX
{
	/// <summary>
	/// Summary description for Common.
	/// </summary>
	public class Common
	{

        public Common(){}

        /// <summary>
        /// PNWWQDXIdentity
        /// </summary>
        public enum PNWWQDXIdentity 
        {
            Measurements, Project, Station, FieldEvent, ProvidingOrganization
        }


        /// <summary>
        /// LoadRelationships
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="identType"></param>
        protected static void LoadRelationships(ref DataSet ds, PNWWQDXIdentity identType)
        {

            switch (identType) 
            {

                case PNWWQDXIdentity.Measurements:

                    //Providing Organization
                    ds.Relations.Add("Org_Projects",ds.Tables[0].Columns["ProvidingOrganizationPK"],ds.Tables[1].Columns["ProvidingOrganizationFK"],false);
                    ds.Relations.Add("Org_Station",ds.Tables[0].Columns["ProvidingOrganizationPK"],ds.Tables[2].Columns["ProvidingOrganizationFK"],false);
                    ds.Relations.Add("Org_FieldEvent",ds.Tables[0].Columns["ProvidingOrganizationPK"],ds.Tables[5].Columns["ProvidingOrganizationFK"],false);
                    ds.Relations.Add("Org_Contact",ds.Tables[0].Columns["ProvidingOrganizationPK"],ds.Tables[6].Columns["ProvidingOrganizationFK"],false);

                    //Project
                    ds.Relations.Add("Project_Binary",ds.Tables[1].Columns["ProjectPK"],ds.Tables[7].Columns["ProjectFK"],false);
                    ds.Relations.Add("Project_Contact",ds.Tables[1].Columns["ProjectPK"],ds.Tables[6].Columns["ProjectFK"],false);
    		
                    //Station
                    ds.Relations.Add("Station_Binary",ds.Tables[2].Columns["StationPK"],ds.Tables[7].Columns["StationFK"],false);
                    ds.Relations.Add("Station_Contact",ds.Tables[2].Columns["StationPK"],ds.Tables[6].Columns["StationFK"],false);
                    ds.Relations.Add("Station_Well",ds.Tables[2].Columns["StationPK"],ds.Tables[3].Columns["StationFK"],false);
                    ds.Relations.Add("Station_LocationDescriptor",ds.Tables[2].Columns["StationPK"],ds.Tables[4].Columns["StationFK"],false);

                    //FieldEvent
                    ds.Relations.Add("FieldEvent_Binary",ds.Tables[5].Columns["FieldEventPK"],ds.Tables[7].Columns["FieldEventFK"],false);
                    ds.Relations.Add("FieldEvent_Contact",ds.Tables[5].Columns["FieldEventPK"],ds.Tables[6].Columns["FieldEventFK"],false);
                    ds.Relations.Add("FieldEvent_Result",ds.Tables[5].Columns["FieldEventPK"],ds.Tables[8].Columns["FieldEventFK"],false);
                    ds.Relations.Add("FieldEvent_SamplePrepMethod",ds.Tables[5].Columns["FieldEventPK"],ds.Tables[10].Columns["FieldEventFK"],false);
                    ds.Relations.Add("FieldEvent_SamplePresMethod",ds.Tables[5].Columns["FieldEventPK"],ds.Tables[11].Columns["FieldEventFK"],false);
                    //ds.Relations.Add("FieldEvent_SampleColMethod",ds.Tables[5].Columns["FieldEventPK"],ds.Tables[12].Columns["FieldEventFK"],false);

                    //Result
                    ds.Relations.Add("Result_DetectionLevel",ds.Tables[8].Columns["ResultPK"],ds.Tables[9].Columns["ResultFK"],false);
                    return;

				case PNWWQDXIdentity.Project:

					//Providing Organization
					ds.Relations.Add("Org_Projects",ds.Tables[0].Columns["ProvidingOrganizationPK"],ds.Tables[1].Columns["ProvidingOrganizationFK"],false);
					ds.Relations.Add("Org_Contact",ds.Tables[0].Columns["ProvidingOrganizationPK"],ds.Tables[2].Columns["ProvidingOrganizationFK"],false);

					//Project
					ds.Relations.Add("Project_Contact",ds.Tables[1].Columns["ProjectPK"],ds.Tables[2].Columns["ProjectFK"],false);
		    		ds.Relations.Add("Project_Analyte",ds.Tables[1].Columns["ProjectPK"],ds.Tables[3].Columns["ProjectFK"],false);
					ds.Relations.Add("Project_Binary",ds.Tables[1].Columns["ProjectPK"],ds.Tables[4].Columns["ProjectFK"],false);
					return;

				case PNWWQDXIdentity.Station:
					//Providing Organization
					ds.Relations.Add("Org_Projects",ds.Tables[0].Columns["ProvidingOrganizationPK"],ds.Tables[1].Columns["ProvidingOrganizationFK"],false);
					ds.Relations.Add("Org_Station",ds.Tables[0].Columns["ProvidingOrganizationPK"],ds.Tables[2].Columns["ProvidingOrganizationFK"],false);
					ds.Relations.Add("Org_Contact",ds.Tables[0].Columns["ProvidingOrganizationPK"],ds.Tables[5].Columns["ProvidingOrganizationFK"],false);

					//Project
					ds.Relations.Add("Project_Contact",ds.Tables[1].Columns["ProjectPK"],ds.Tables[5].Columns["ProjectFK"],false);
    		
					//Station
					ds.Relations.Add("Station_Binary",ds.Tables[2].Columns["StationPK"],ds.Tables[6].Columns["StationFK"],false);
					ds.Relations.Add("Station_Contact",ds.Tables[2].Columns["StationPK"],ds.Tables[5].Columns["StationFK"],false);
					ds.Relations.Add("Station_Well",ds.Tables[2].Columns["StationPK"],ds.Tables[3].Columns["StationFK"],false);
					ds.Relations.Add("Station_LocationDescriptor",ds.Tables[2].Columns["StationPK"],ds.Tables[4].Columns["StationFK"],false);
					ds.Relations.Add("Station_ProjectStation",ds.Tables[2].Columns["StationPK"],ds.Tables[7].Columns["StationFK"],false);
					return;
                default:
                    return;

            }

        }

	}
}
