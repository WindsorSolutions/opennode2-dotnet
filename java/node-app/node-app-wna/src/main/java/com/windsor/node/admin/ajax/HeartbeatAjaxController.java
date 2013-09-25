package com.windsor.node.admin.ajax;

import java.net.MalformedURLException;
import java.net.URL;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import net.sf.json.JSONObject;
import org.apache.commons.lang3.StringUtils;
import org.springframework.beans.factory.InitializingBean;
import com.windsor.node.common.domain.EndpointVersionType;
import com.windsor.node.common.domain.PartnerIdentity;
import com.windsor.node.common.service.admin.PartnerService;
import com.windsor.node.common.util.NodeClientService;
import com.windsor.node.service.helper.RemoteFileResourceHelper;
import com.windsor.node.service.helper.client.NodeClientFactory;

public class HeartbeatAjaxController extends JsonAjaxController implements InitializingBean
{
    private String externalAdminUrl;
    private PartnerService partnerService;
    private NodeClientFactory nodeClientFactory;
    private RemoteFileResourceHelper remoteFileResourceHelper;

    @Override
    public void afterPropertiesSet() throws Exception
    {
        if(StringUtils.isBlank(externalAdminUrl))
        {
            throw new IllegalStateException("String externalAdminUrl member of HeartbeatAjaxController cannot be empty.");
        }
        if(partnerService == null)
        {
            throw new IllegalStateException("PartnerService partnerService member of HeartbeatAjaxController cannot be null.");
        }
        if(nodeClientFactory == null)
        {
            throw new IllegalStateException("NodeClientFactory nodeClientFactory member of HeartbeatAjaxController cannot be null.");
        }
    }

    @Override
    protected Object getOutput(HttpServletRequest request, HttpServletResponse response)
    {
        int indexOfFinalSlash = getExternalAdminUrl().lastIndexOf("/");
        String baseUrl = getExternalAdminUrl().substring(0, indexOfFinalSlash);
        String wneUrl = baseUrl + "/" + "wne/services/v11";
        String wne2Url = baseUrl + "/" + "wne2/services/v21";
        String wnrestUrl = baseUrl + "/" + "wnrest/services/NodePing";
        JSONObject jsonResponse = new JSONObject();
        jsonResponse.put("wneendpoint", wneUrl);
        jsonResponse.put("wne2endpoint", wne2Url);
        jsonResponse.put("wnrestendpoint", baseUrl + "/" + "wnrest/services/{Query}");

        PartnerIdentity testWnePartner;
        PartnerIdentity testWne2Partner;
        try
        {
            testWnePartner = new PartnerIdentity("NODE-TRANSIENT-ONLY", "testWnePartner", new URL(wneUrl), EndpointVersionType.EN11);
            testWne2Partner = new PartnerIdentity("NODE-TRANSIENT-ONLY", "testWn2ePartner", new URL(wne2Url), EndpointVersionType.EN21);
        }
        catch(MalformedURLException e1)
        {
            throw new IllegalStateException("The URLs for at least one of the WNE/WNE2 endpoints were invalid.");
        }

        NodeClientService wneNodeClientService = nodeClientFactory.makeAndConfigure(testWnePartner);
        NodeClientService wne2NodeClientService = nodeClientFactory.makeAndConfigure(testWne2Partner);

        String result = "No Result";
        try
        {
            result = wneNodeClientService.nodePing("Ping");
        }
        catch(Exception e)
        {
            //whatever the exception we want a nice message indicating that the node could not be contacted
            result = "error";
            logger.info("NodePing to local WNE failed with:  " + e.getMessage());
        }
        if(StringUtils.isBlank(result) || result.equalsIgnoreCase("No Result") || result.equalsIgnoreCase("error"))
        {
            jsonResponse.put("wneresult", "failure");
        }
        else
        {
            jsonResponse.put("wneresult", "success");
        }

        result = "No Result";
        try
        {
            result = wne2NodeClientService.nodePing("Ping");
        }
        catch(Exception e)
        {
            //whatever the exception we want a nice message indicating that the node could not be contacted
            result = "error";
            logger.info("NodePing to local WNE2 failed with:  " + e.getMessage());
        }
        if(StringUtils.isBlank(result) || result.equalsIgnoreCase("No Result") || result.equalsIgnoreCase("error"))
        {
            jsonResponse.put("wne2result", "failure");
        }
        else
        {
            jsonResponse.put("wne2result", "success");
        }

        String restResponse = "No Result";
        try
        {
            byte[] restResponseBytes = getRemoteFileResourceHelper().getBytesFromURL(wnrestUrl);
            restResponse = new String(restResponseBytes);
        }
        catch(Exception e)
        {
            //whatever the exception we want a nice message indicating that the node could not be contacted
            restResponse = "error";
            logger.info("NodePing to local WNREST failed with:  " + e.getMessage());
        }
        if(StringUtils.isBlank(restResponse) || restResponse.equalsIgnoreCase("No Result") || restResponse.equalsIgnoreCase("error"))
        {
            jsonResponse.put("wnrestresult", "failure");
        }
        else
        {
            jsonResponse.put("wnrestresult", "success");
        }

        return jsonResponse;
    }

    public String getExternalAdminUrl()
    {
        return externalAdminUrl;
    }

    public void setExternalAdminUrl(String externalAdminUrl)
    {
        this.externalAdminUrl = externalAdminUrl;
    }

    public PartnerService getPartnerService()
    {
        return partnerService;
    }

    public void setPartnerService(PartnerService partnerService)
    {
        this.partnerService = partnerService;
    }

    public NodeClientFactory getNodeClientFactory()
    {
        return nodeClientFactory;
    }

    public void setNodeClientFactory(NodeClientFactory nodeClientFactory)
    {
        this.nodeClientFactory = nodeClientFactory;
    }

    public RemoteFileResourceHelper getRemoteFileResourceHelper()
    {
        return remoteFileResourceHelper;
    }

    public void setRemoteFileResourceHelper(RemoteFileResourceHelper remoteFileResourceHelper)
    {
        this.remoteFileResourceHelper = remoteFileResourceHelper;
    }
}
