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

using System.Data;
using System.Data.Common;
using System.Reflection;

using Spring.Data.Generic;
using Spring.Data.Common;


using Common.Logging;

using Windsor.Node2008.WNOSDomain;
using Windsor.Node2008.WNOSConnector.Provider;
using Windsor.Node2008.WNOSUtility;
using Windsor.Commons.Core;
using Windsor.Commons.NodeDomain;

namespace Windsor.Node2008.WNOS.Data
{
    /// <summary>
    /// Should be implementing interface but for now just use the raw object
    /// </summary>
    public class PartnerDao : BaseDao, IPartnerDao
    {
        public const string TABLE_NAME = "NPartner";

        #region Init

        new public void Init()
        {
            base.Init();
		}

        #endregion
        #region Mappers
        internal const string MAP_PARTNER_IDENTITY_COLUMNS = "Id;Name;Url;ModifiedBy;ModifiedOn;Version";
        internal static PartnerIdentity MapPartnerIdentity(IDataReader reader)
        {
            PartnerIdentity partnerIdentity = new PartnerIdentity();
            int index = 0;
            partnerIdentity.Id = reader.GetString(index++);
            partnerIdentity.Name = reader.GetString(index++);
            partnerIdentity.Url = reader.GetString(index++);
            partnerIdentity.ModifiedById = reader.GetString(index++);
            partnerIdentity.ModifiedOn = reader.GetDateTime(index++);
            partnerIdentity.Version = EnumUtils.ParseEnum<EndpointVersionType>(reader.GetString(index++));
            return partnerIdentity;
        }
        #endregion // Mappers
		
        #region Methods
        /// <summary>
        /// Save()
        /// </summary>
        public void Save(PartnerIdentity item)
        {
            if (item == null)
            {
                throw new ArgumentException("Null item");
            }
            DateTime now = DateTime.Now;
            string id = null;
            if (string.IsNullOrEmpty(item.Id))
            {
                id = IdProvider.Get();
                DoInsert(TABLE_NAME, "Id;Name;Url;ModifiedBy;ModifiedOn;Version",
                         id, item.Name, item.Url, item.ModifiedById,
                         now, item.Version.ToString());
            }
            else
            {
                DoSimpleUpdateOne(TABLE_NAME, "Id", item.Id.ToString(),
                                  "Name;Url;ModifiedBy;ModifiedOn;Version",
                                  item.Name, item.Url, item.ModifiedById,
                                  now, item.Version.ToString());
            }
            if (id != null)
            {
                item.Id = id;
            }
            item.ModifiedOn = now;
        }
        
        /// <summary>
        /// GetById()
		/// </summary>
        public PartnerIdentity GetById(string id)
        {
			try {
                PartnerIdentity partnerIdentity =
                    DoSimpleQueryForObjectDelegate<PartnerIdentity>(
                        TABLE_NAME, "Id", id, MAP_PARTNER_IDENTITY_COLUMNS, 
						delegate(IDataReader reader, int rowNum) 
						{
                            return MapPartnerIdentity(reader);
						});

                return partnerIdentity;
			}
			catch(Spring.Dao.IncorrectResultSizeDataAccessException) {
				return null; // Not found
			}
        }

        /// <summary>
        /// GetByCode()
        /// </summary>
        public PartnerIdentity GetByName(string name)
        {
            try
            {
                PartnerIdentity partnerIdentity =
                    DoSimpleQueryForObjectDelegate<PartnerIdentity>(
                        TABLE_NAME, "Name", name, MAP_PARTNER_IDENTITY_COLUMNS,
                        delegate(IDataReader reader, int rowNum)
                        {
                            return MapPartnerIdentity(reader);
                        });

                return partnerIdentity;
            }
            catch (Spring.Dao.IncorrectResultSizeDataAccessException)
            {
                return null; // Not found
            }
        }

        /// <summary>
        /// Get()
        /// </summary>
        public IList<PartnerIdentity> Get()
        {
            List<PartnerIdentity> partnerIdentities = new List<PartnerIdentity>();
            DoSimpleQueryWithRowCallbackDelegate(
                TABLE_NAME, null, null, null,
                MAP_PARTNER_IDENTITY_COLUMNS,
                delegate(IDataReader reader)
                {
                    partnerIdentities.Add(MapPartnerIdentity(reader));
                });

            return partnerIdentities;
        }

        public void Delete(PartnerIdentity item)
        {
            DoSimpleDelete(TABLE_NAME, "Id", new object[] { item.Id });
        }
        /// <summary>
        /// Return all service names as a dictionary of key/value pairs.
        /// </summary>
        public IDictionary<string, string> GetAllPartnerNames()
        {
            Dictionary<string, string> partnerNames = new Dictionary<string, string>();
            DoSimpleQueryWithRowCallbackDelegate(
                TABLE_NAME, null, null, null,
                "Id,Name,Version",
                delegate(IDataReader reader)
                {
                    string name = reader.GetString(1);
                    EndpointVersionType version = EnumUtils.ParseEnum<EndpointVersionType>(reader.GetString(2));
                    string displayName = string.Format("{0} ({1})", name, EnumUtils.ToDescription(version));
                    partnerNames.Add(reader.GetString(0), displayName);
                });
            return partnerNames;
        }
        #endregion

        #region Properties

        #endregion
    }
}
