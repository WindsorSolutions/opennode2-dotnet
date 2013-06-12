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

package com.windsor.node.plugin;

import java.io.File;
import java.util.List;
import com.windsor.node.common.domain.DataFlow;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.NodeVisit;
import com.windsor.node.common.domain.PluginMetaData;
import com.windsor.node.common.domain.PluginServiceImplementorDescriptor;
import com.windsor.node.common.domain.ProcessContentResult;

public interface PluginHelper {

    /**
     * Saves plugin content to the flow plugin dir.
     * 
     * @param flowName
     * @param content
     */
    void savePluginContent(DataFlow flow, NodeVisit visit, byte[] content);

    /**
     * Returns the directory containing the plugin .jar file associated with the
     * given DataFlow.
     * 
     * @param flow
     * @return
     */
    File getPluginContentDir(DataFlow flow);

    /**
     * Processes Submits and Notifies
     */
    ProcessContentResult processTransaction(NodeTransaction transaction);

    /**
     * Gets instance of the plugin for info only; does not configure the plugin.
     * 
     * @param service
     * @return
     */
    BaseWnosPlugin getWnosPlugin(DataFlow flow, String implementingClassName);

    /**
     * Gets List of names of concrete implementations of BaseWnosPlugin
     * associated with the given DataFlow.
     * 
     * @param flow
     * @return
     */
    List<String> getWnosPluginImplementors(DataFlow flow);

    WnosClassLoader getClassLoader();

    PluginMetaData getPluginMetaData(DataFlow flow);

    List<PluginServiceImplementorDescriptor> getPluginServiceImplementorDescriptors(DataFlow flow);
}