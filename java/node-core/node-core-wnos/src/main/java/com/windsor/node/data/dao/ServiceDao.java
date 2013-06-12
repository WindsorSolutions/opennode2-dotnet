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

package com.windsor.node.data.dao;

import java.util.List;
import java.util.Map;
import com.windsor.node.common.domain.DataService;

/**
 * Defines operations for saving and retrieving
 * {@link com.windsor.node.common.domain.DataService DataServices} from the Node
 * metadata database.
 */
public interface ServiceDao extends DeletableDao {

    /**
     * Save a configured DataService, assigning a unique id.
     * 
     * @param instance
     * @return the DataService, with the saved id
     */
    DataService save(DataService instance);

    /**
     * Retrieve the DataService associated with the given id.
     * 
     * @param id
     * @return the DataService associated with the given id
     */
    DataService get(String id);

    /**
     * Retrieve the DataService associated with the given name.
     * 
     * @param name
     * @return the DataService associated with the given name
     */
    DataService getByServiceName(String name);

    /**
     * Retrieve the DataService associated with the given name and DataFLow id.
     * 
     * @param flowId
     * @param name
     * @return the DataService associated with the given name and DataFLow id
     */
    DataService getByServiceName(String flowId, String name);

    /**
     * 
     * Retrieve a list of DataServices associated with the given DataFlow id.
     * 
     * @param id
     * @return a list of DataServices associated with the given DataFlow id
     */
    List<DataService> getByFlowId(String id);

    /**
     * Retrieve a Map of all DataServices flagged as active.
     * 
     * @return a Map of all DataServices flagged as active
     */
    Map<String, String> getActive();

    /**
     * Retrieve a Map of all DataServices flagged as active with the given
     * DataFlow id.
     * 
     * @param id
     * @return a Map of all DataServices flagged as active with the given
     *         DataFlow id
     */
    Map<String, String> getActiveByFlowId(String id);

    /**
     * Retrieve a List of all active DataServices, populated with parent Flow
     * Name.
     * 
     * <p>
     * Specific to Exchange Network Discovery Services, v20.
     * </p>
     * 
     * @return a List of all active DataServices, populated with parent Flow
     *         Name
     */
    List<DataService> getServicesForEnds2();

    /**
     * Retrieve a List of all active DataServices with a given implementing
     * class name; intended for use by Ends2.
     * 
     * @param implementorName
     * @return
     */
    List<DataService> getActiveByImplementor(String implementorName);
}
