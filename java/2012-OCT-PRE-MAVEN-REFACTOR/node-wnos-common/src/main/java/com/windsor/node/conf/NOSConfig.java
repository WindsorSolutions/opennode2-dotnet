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

package com.windsor.node.conf;

import java.io.File;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;

import org.apache.commons.lang3.StringUtils;
import org.springframework.beans.factory.InitializingBean;

import com.windsor.node.common.domain.NodeDeploymentType;

public class NOSConfig implements InitializingBean {

    private String webServiceEndpoint1;
    private String webServiceEndpoint2;
    private String adminUrl;
    private String nodeAdminEmail;
    private List<String> adminWhiteList;
    private String localhostIp = "127.0.0.1";
    private File pluginDir;
    private File tempDir;
    private String globalArgumentIndicator = "@";
    /**
     * FIXME Remove this, already disabled
     * @deprecated
     */
    private boolean skipNaas = false;

    /** ENDS property. */
    private String nodeName;

    /** ENDS property. */
    private String orgIdentifier;

    /** ENDS property. */
    private String boundingCoordinateEast;

    /** ENDS property. */
    private String boundingCoordinateNorth;

    /** ENDS property. */
    private String boundingCoordinateSouth;

    /** ENDS property. */
    private String boundingCoordinateWest;

    /** ENDS property. */
    private String deploymentType;

    private NodeDeploymentType nodeDeploymentType;

    /** ENDS property. */
    private String publicV2endpointUrl;

    /**
     * Make sure the required properties are set; we don't worry about ENDS
     * properties.
     */
    public void afterPropertiesSet() {

        if (StringUtils.isBlank(webServiceEndpoint1)) {
            throw new RuntimeException("webServiceEndpoint1 not set");
        }

        if (StringUtils.isBlank(webServiceEndpoint2)) {
            throw new RuntimeException("webServiceEndpoint2 not set");
        }

        if (StringUtils.isBlank(adminUrl)) {
            throw new RuntimeException("adminUrl not set");
        }

        if (StringUtils.isBlank(nodeAdminEmail)) {
            throw new RuntimeException("nodeAdminEmail not set");
        }

        if (StringUtils.isBlank(localhostIp)) {
            throw new RuntimeException("localhostIp not set");
        }

        if (adminWhiteList == null || adminWhiteList.size() == 0) {
            throw new RuntimeException("adminWhiteList not set");
        } else {
            adminWhiteList = massageWhitelist(adminWhiteList);
        }

        validateDir(pluginDir);

        validateDir(tempDir);

    }

    private void validateDir(File dir) {

        if (dir == null) {
            throw new RuntimeException("Dir not set");
        }

        if (!dir.exists()) {
            throw new RuntimeException("Dir set but it does not exist: " + dir);
        }

        if (!dir.canWrite()) {
            throw new RuntimeException("Dir exist but not writeable: " + dir);
        }

    }

    public String getWebServiceEndpoint1() {
        return webServiceEndpoint1;
    }

    public void setWebServiceEndpoint1(String webServiceEndpoint1) {
        this.webServiceEndpoint1 = webServiceEndpoint1;
    }

    public String getWebServiceEndpoint2() {
        return webServiceEndpoint2;
    }

    public void setWebServiceEndpoint2(String webServiceEndpoint2) {
        this.webServiceEndpoint2 = webServiceEndpoint2;
    }

    public String getAdminUrl() {
        return adminUrl;
    }

    public void setAdminUrl(String adminUrl) {
        this.adminUrl = adminUrl;
    }

    public String getNodeAdminEmail() {
        return nodeAdminEmail;
    }

    public void setNodeAdminEmail(String nodeAdminEmail) {
        this.nodeAdminEmail = nodeAdminEmail;
    }

    public List<String> getAdminWhiteList() {
        return adminWhiteList;
    }

    public void setAdminWhiteList(List<String> adminWhiteList) {
        this.adminWhiteList = adminWhiteList;
    }

    public String getLocalhostIp() {
        return localhostIp;
    }

    public void setLocalhostIp(String localhostIp) {
        this.localhostIp = localhostIp;
    }

    public File getPluginDir() {
        return pluginDir;
    }

    public void setPluginDir(File pluginDir) {
        this.pluginDir = pluginDir;
    }

    public File getTempDir() {
        return tempDir;
    }

    public void setTempDir(File tempDir) {
        this.tempDir = tempDir;
    }

    public String getGlobalArgumentIndicator() {
        return globalArgumentIndicator;
    }

    public void setGlobalArgumentIndicator(String globalArgumentIndicator) {
        this.globalArgumentIndicator = globalArgumentIndicator;
    }

    /**
     * FIXME Remove this, already disabled
     * @deprecated
     */
    public boolean isSkipNaas() {
        return skipNaas;
    }

    /**
     * FIXME Remove this, already disabled
     * @deprecated
     */
    public void setSkipNaas(boolean skipNaas) {
        this.skipNaas = skipNaas;
    }

    public String getNodeName() {
        return nodeName;
    }

    public void setNodeName(String nodeName) {
        this.nodeName = nodeName;
    }

    public String getBoundingCoordinateEast() {
        return boundingCoordinateEast;
    }

    public void setBoundingCoordinateEast(String boundingCoordinateEast) {
        this.boundingCoordinateEast = boundingCoordinateEast;
    }

    public String getBoundingCoordinateNorth() {
        return boundingCoordinateNorth;
    }

    public void setBoundingCoordinateNorth(String boundingCoordinateNorth) {
        this.boundingCoordinateNorth = boundingCoordinateNorth;
    }

    public String getBoundingCoordinateSouth() {
        return boundingCoordinateSouth;
    }

    public void setBoundingCoordinateSouth(String boundingCoordinateSouth) {
        this.boundingCoordinateSouth = boundingCoordinateSouth;
    }

    public String getBoundingCoordinateWest() {
        return boundingCoordinateWest;
    }

    public void setBoundingCoordinateWest(String boundingCoordinateWest) {
        this.boundingCoordinateWest = boundingCoordinateWest;
    }

    public NodeDeploymentType getNodeDeploymentType() {
        return nodeDeploymentType;
    }

    public void setNodeDeploymentType(NodeDeploymentType type) {
        this.nodeDeploymentType = type;
        setDeploymentType(type.toString());
    }

    public void setDeploymentType(String deployment) {

        try {

            this.nodeDeploymentType = Enum.valueOf(NodeDeploymentType.class,
                    deployment);
            this.deploymentType = getNodeDeploymentType().toString();

        } catch (IllegalArgumentException e) {

            this.nodeDeploymentType = null;
        }
    }

    public String getDeploymentType() {
        return this.deploymentType;
    }

    protected List<String> massageWhitelist(List<String> whitelist) {

        List<String> newlist = new ArrayList<String>();

        int i = 0;
        Iterator<String> iter = whitelist.iterator();

        while (iter.hasNext()) {

            String s = iter.next();

            if (StringUtils.contains(s, ',')) {
                String[] arr = StringUtils.split(s, ',');
                for (int n = 0; n < arr.length; n++) {
                    newlist.add(arr[n].trim());
                }
            } else {
                newlist.add(s.trim());
            }
            i++;
        }

        return newlist;
    }

    public String getOrgIdentifier() {
        return orgIdentifier;
    }

    public void setOrgIdentifier(String orgIdentifier) {
        this.orgIdentifier = orgIdentifier;
    }

    public String getPublicV2endpointUrl() {
        return publicV2endpointUrl;
    }

    public void setPublicV2endpointUrl(String publicV2endpointUrl) {
        this.publicV2endpointUrl = publicV2endpointUrl;
    }

}
