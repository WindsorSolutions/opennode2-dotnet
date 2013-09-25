package com.windsor.node.web;

import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.Serializable;
import java.io.Writer;
import java.nio.charset.StandardCharsets;
import java.util.Enumeration;
import java.util.List;
import java.util.zip.ZipEntry;
import java.util.zip.ZipInputStream;
import java.util.zip.ZipOutputStream;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import org.apache.commons.lang3.StringUtils;
import org.apache.commons.lang3.math.NumberUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.stereotype.Controller;
import org.springframework.util.FileCopyUtils;
import org.springframework.web.bind.annotation.ExceptionHandler;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import com.windsor.node.common.domain.CommonContentType;
import com.windsor.node.common.domain.DataFlow;
import com.windsor.node.common.domain.DataRequest;
import com.windsor.node.common.domain.DataService;
import com.windsor.node.common.domain.Document;
import com.windsor.node.common.domain.EndpointAuthenticationRequest;
import com.windsor.node.common.domain.EndpointTokenValidationRequest;
import com.windsor.node.common.domain.EndpointVersionType;
import com.windsor.node.common.domain.EndpointVisit;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.common.domain.TransactionStatus;
import com.windsor.node.common.service.admin.FlowService;
import com.windsor.node.common.service.cmf.SecurityService;
import com.windsor.node.common.service.cmf.TransactionService;
import com.windsor.node.common.util.ByIndexOrNameMap;
import com.windsor.node.data.dao.PluginServiceParameterDescriptor;
import com.windsor.node.service.helper.id.UUIDGenerator;
import com.windsor.node.web.exception.RestException;

@Controller
public class RestActivationController implements Serializable
{
    private static final long serialVersionUID = 5444456389572239306L;
    private static final String HTTP_HEADER_FORWARD_FOR = "X-Forward-For";
    protected Logger logger = LoggerFactory.getLogger(RestActivationController.class);

    private @Autowired TransactionService transactionService;
    private @Autowired com.windsor.node.common.service.admin.TransactionService nodeTransactionService;
    private @Autowired FlowService flowService;
    private @Autowired SecurityService securityService;
    private @Value("${rest.node.ping.ready.response}") String nodePingReadyResponse;
    private @Autowired String requestIPHeaderProperty;

    @RequestMapping(value="/Authenticate", method=RequestMethod.GET, produces={"text/plain;charset=UTF-8", "application/xml;charset=UTF-8"})
    public String authenticate(HttpServletRequest request, Writer out) throws IOException
    {
        logger.info("Responding to \"Authenticate\" request.");

        String csm = "not authed";
        //userId credential  domain(optional) authenticationMethod
        String userId = request.getParameter("userId");
        String credential = request.getParameter("credential");
        /*String domain = request.getParameter("domain");
        if(StringUtils.isBlank(domain))
        {
            domain = "default";
        }*/

        String authenticationMethod = request.getParameter("authenticationMethod");

        EndpointVisit visit = securityService.endpointAuthenticate(new EndpointAuthenticationRequest(EndpointVersionType.ENREST, userId, credential,
                        authenticationMethod, getClientHost(request)));

        csm = visit.getToken();

        out.write("csm is:  " + csm);

        out.close();
        return null;
    }

    @RequestMapping(value="/NodePing", method=RequestMethod.GET, produces={"text/plain;charset=UTF-8", "application/xml;charset=UTF-8"})
    public String nodePing(Writer out) throws IOException
    {
        logger.info("Responding to \"NodePing\" with \"" + getNodePingReadyResponse() + "\".");
        out.write(getNodePingReadyResponse());
        out.close();
        return null;
    }

    @RequestMapping(value="/Execute", method=RequestMethod.GET, produces={"text/plain;charset=UTF-8", "application/xml;charset=UTF-8"})
    public String execute(Writer out) throws IOException
    {
        logger.info("Responding to \"Execute\" with \"Not Implemented\".");
        out.write("Not Implemented");
        out.close();
        return null;
    }

    @RequestMapping(value="/Query", method=RequestMethod.GET, produces={"application/zip", "application/xml;charset=UTF-8"})
    public String queryToSpec(HttpServletRequest request, HttpServletResponse response) throws IOException
    {
        logger.info("Responding to \"Query\" using the ECOS spec.");
        String exchangeName = request.getParameter("Dataflow");
        String serviceName = request.getParameter("Request");
        logger.info("Exchange name \"" + exchangeName + "\" called.");
        logger.info("Service name \"" + serviceName + "\" called.");

        String userId = request.getParameter("Username");
        String credential = request.getParameter("Password");
        EndpointVisit visit = null;
        if(StringUtils.isNotBlank(userId) && StringUtils.isNotBlank(credential))
        {
            /*String domain = request.getParameter("domain");
            if(StringUtils.isBlank(domain))
            {
                domain = "default";
            }*/
            //Authenticate
            visit = securityService.endpointAuthenticate(new EndpointAuthenticationRequest(EndpointVersionType.ENREST, userId,
                            credential, "password", getClientHost(request)));
        }
        else if(StringUtils.isBlank(request.getParameter("token")))
        {
            throw new RestException("Neither NAAS authentication credentials nor an existing authenticated NAAS token were provided.");
        }
        else
        {
            visit = getEndpointVisit(request);
        }

        //Lookup flow information
        DataFlow dataFlow = getDataFlowByExchangeName(exchangeName, visit);
        DataService dataService = getDataServiceByServiceNameAndDataFlow(serviceName, dataFlow);

        if(dataFlow == null || dataService == null)
        {
            //FIXME error condition
        }

        DataRequest dataRequest = createDataRequestFromSpecUrl(request, dataFlow, dataService);
        if(request.getParameter("rowId") != null && NumberUtils.isNumber(request.getParameter("rowId")))
        {
            dataRequest.getPaging().setStart(Integer.valueOf(request.getParameter("rowId")));
        }
        if(request.getParameter("maxRows") != null && NumberUtils.isNumber(request.getParameter("maxRows")))
        {
            dataRequest.getPaging().setCount(Integer.valueOf(request.getParameter("maxRows")));
        }

        ProcessContentResult processContentResult = getTransactionService().query(visit, dataRequest);
        if(processContentResult == null || processContentResult.getDocuments() == null || processContentResult.getDocuments().size() < 1)
        {
            //FIXME Error condition
        }

        writeDocumentToOutput(request, response, processContentResult.getDocuments());
        return null;
    }

    @RequestMapping(value="/Query/{exchangeName}/{serviceName}", method=RequestMethod.GET, produces={"application/zip", "application/xml;charset=UTF-8"})
    public String query(@PathVariable String exchangeName, @PathVariable String serviceName, HttpServletRequest request, HttpServletResponse response) throws IOException
    {
        logger.info("Responding to \"Query\".");
        logger.info("Exchange name \"" + exchangeName + "\" called.");
        logger.info("Service name \"" + serviceName + "\" called.");

        EndpointVisit visit = getEndpointVisit(request);

        //Lookup flow information
        DataFlow dataFlow = getDataFlowByExchangeName(exchangeName, visit);
        DataService dataService = getDataServiceByServiceNameAndDataFlow(serviceName, dataFlow);

        if(dataFlow == null || dataService == null)
        {
            //FIXME error condition
        }

        DataRequest dataRequest = createDataRequest(request, dataFlow, dataService);

        ProcessContentResult processContentResult = getTransactionService().query(visit, dataRequest);
        if(processContentResult == null || processContentResult.getDocuments() == null || processContentResult.getDocuments().size() < 1)
        {
            //FIXME Error condition
        }

        writeDocumentToOutput(request, response, processContentResult.getDocuments());

        return null;
    }

    @RequestMapping(value="/Download", method=RequestMethod.GET, produces={"application/zip", "application/xml;charset=UTF-8"})
    public String download(HttpServletRequest request, HttpServletResponse response) throws IOException
    {
        logger.info("Responding to \"Download\".");
        //Get the EndpointVisit
        EndpointVisit visit = getEndpointVisit(request);

        String transactionId = request.getParameter("transactionId");
        //NodeTransaction nodeTransaction = getNodeTransactionService().get(transactionId, visit);
        NodeTransaction nodeTransaction = getNodeTransactionService().getNodeTransactionByIdWithAllData(transactionId, visit);
        List<Document> documents = nodeTransaction.getDocuments();

        writeDocumentToOutput(request, response, documents);

        return null;
    }

    @RequestMapping(value="/Solicit/{exchangeName}/{serviceName}", method=RequestMethod.GET, produces={"text/plain;charset=UTF-8", "application/xml;charset=UTF-8"})
    public String solicit(@PathVariable String exchangeName, @PathVariable String serviceName, HttpServletRequest request, Writer out) throws IOException
    {
        logger.info("Responding to \"Solicit\".");
        logger.info("Exchange name \"" + exchangeName + "\" called.");
        logger.info("Service name \"" + serviceName + "\" called.");
        //Get the EndpointVisit
        EndpointVisit visit = getEndpointVisit(request);

        //Lookup flow information
        DataFlow dataFlow = getDataFlowByExchangeName(exchangeName, visit);
        DataService dataService = getDataServiceByServiceNameAndDataFlow(serviceName, dataFlow);

        if(dataFlow == null || dataService == null)
        {
            //FIXME error condition
        }

        DataRequest dataRequest = createDataRequest(request, dataFlow, dataService);

        TransactionStatus transactionStatus = getTransactionService().solicit(visit, dataRequest);

        //Response
        out.write("Exchange name:  " + exchangeName + "\n");
        out.write("Service name:  " + serviceName + "\n");
        if(transactionStatus != null)
        {
            out.write("Transaction Id:  " + transactionStatus.getTransactionId() + "\n");
            out.write("Status Code:  " + transactionStatus.getStatus() + "\n");
        }
        out.close();
        return null;
    }

    @RequestMapping(value="/GetStatus", method=RequestMethod.GET, produces={"text/plain;charset=UTF-8", "application/xml;charset=UTF-8"})
    public String getStatus(HttpServletRequest request, Writer out) throws IOException
    {
        logger.info("Responding to \"GetStatus\".");
        //Get the EndpointVisit
        EndpointVisit visit = getEndpointVisit(request);

        String transactionId = request.getParameter("transactionId");
        TransactionStatus transactionStatus = getTransactionService().getStatus(visit, transactionId);
        if(transactionStatus != null)
        {
            out.write("Transaction Id:  " + transactionStatus.getTransactionId() + "\n");
            out.write("Status Code:  " + transactionStatus.getStatus() + "\n");
        }
        out.close();
        return null;
    }

    //FIXME Implement Notify, it's important and the main hangups are that 1) I don't use it much and have less of an implicit understanding of why its here and 2) It actually has a fairly complex structure that is hard to translate into a REST GET
    @RequestMapping(value="/Notify/{exchangeName}", method=RequestMethod.GET, produces={"text/plain;charset=UTF-8", "application/xml;charset=UTF-8"})
    public String notify(@PathVariable String exchangeName, HttpServletRequest request, Writer out) throws IOException
    {
        logger.info("Responding to \"Notify\"with \"Not Implemented\".");
        out.write("Not Implemented");
        out.close();
        /*logger.info("Exchange name \"" + exchangeName + "\" called.");
        EndpointVisit visit = getEndpointVisit(request);

        String nodeAddress = request.getParameter("nodeAddress");
        String messagesParam = request.getParameter("messages");
        String[] messages = messagesParam.split("|");

        ComplexNotification complexNotification = new ComplexNotification();
        complexNotification.setFlowName(exchangeName);
        complexNotification.setUri(nodeAddress);
        complexNotification.setNotifications(new ArrayList<Notification>());
        for(int i = 0; i < messages.length; i++)
        {
            Notification notification = new Notification();
        }*/
        //NotificationTypeCode <enumeration value="Warning"/><enumeration value="Error"/><enumeration value="Status"/><enumeration value="All"/><enumeration value="None"/>
        return null;
    }

    @ExceptionHandler(Exception.class)
    public void handleUncaughtException(Exception exception, HttpServletRequest request, HttpServletResponse response)
    {
        StringBuffer errorResponseBody = createExceptionResponse(exception);
        Writer out = null;
        try
        {
            configureResponseHeader(response);
            out = response.getWriter();
            out.write(new String(errorResponseBody.toString().getBytes(StandardCharsets.UTF_8), StandardCharsets.UTF_8));
        }
        catch(IOException e)
        {
            logger.error("Failed to respond to an uncaught Exception.", e);
        }
        finally
        {
            try
            {
                out.close();
            }
            catch(IOException e)
            {
                logger.error("Could not close OutputStream reponse to unhandled Exception");
            }
        }
    }

    //TODO determine the value of a more specific method
    @ExceptionHandler(RestException.class)
    public void handleRestException(RestException exception, HttpServletRequest request, HttpServletResponse response)
    {
        StringBuffer errorResponseBody = createExceptionResponse(exception);
        Writer out = null;
        try
        {
            configureResponseHeader(response);
            out = response.getWriter();
            out.write(errorResponseBody.toString());
        }
        catch(IOException e)
        {
            logger.error("Failed to respond to a RestException.", e);
        }
        finally
        {
            try
            {
                out.close();
            }
            catch(IOException e)
            {
                logger.error("Could not close OutputStream reponse to unhandled Exception");
            }
        }
    }

    private StringBuffer createExceptionResponse(Exception exception)
    {
        StringBuffer errorResponseBody = new StringBuffer();
        errorResponseBody.append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
        errorResponseBody.append("\n").append("<Error>");
        errorResponseBody.append("\n    ").append("<Message>");
        errorResponseBody.append("\n        ").append("Exception: ").append(exception.getClass().getName()).append(",").append("Message: ").append(exception.getMessage());
        errorResponseBody.append("\n    ").append("</Message>");
        errorResponseBody.append("\n").append("</Error>");
        return errorResponseBody;
    }

    private void configureResponseHeader(HttpServletResponse response)
    {
        response.setHeader("Cache-Control", "no-cache");
        response.setHeader("Expires", "-1");
        response.setContentType("application/xml;charset=UTF-8");
        response.setCharacterEncoding("UTF-8");
        response.setStatus(HttpServletResponse.SC_BAD_REQUEST);
    }

    private DataRequest createDataRequestFromSpecUrl(HttpServletRequest request, DataFlow dataFlow, DataService dataService)
    {
        ByIndexOrNameMap paramMap = new ByIndexOrNameMap();

        String paramsParameter = request.getParameter("Params");
        String[] params = new String[]{};
        if(StringUtils.isNotBlank(paramsParameter))
        {
            params = paramsParameter.split(";");
            for(int i = 0; i < params.length; i++)
            {
                String[] keyValuePair = params[i].split("\\|");
                if(keyValuePair != null && keyValuePair.length >= 2)
                {
                    if(StringUtils.isNotBlank((String)paramMap.get(keyValuePair[0])))
                    {
                        StringBuffer sb = new StringBuffer((String)paramMap.get(keyValuePair[0]));
                        sb.append("|").append(keyValuePair[1]);
                        paramMap.put(keyValuePair[0], sb.toString());
                    }
                    else
                    {
                        paramMap.put(keyValuePair[0], keyValuePair[1]);
                        for(int j = 2; j < keyValuePair.length; j++)
                        {
                            StringBuffer sb = new StringBuffer((String)paramMap.get(keyValuePair[0]));
                            sb.append("|").append(keyValuePair[j]);
                            paramMap.put(keyValuePair[0], sb.toString());
                        }
                    }
                }
            }
        }
        DataRequest dataRequest = new DataRequest();
        dataRequest.setService(dataService);
        dataRequest.setParameters(paramMap);
        return dataRequest;
    }

    private DataRequest createDataRequest(HttpServletRequest request, DataFlow dataFlow, DataService dataService)
    {
        @SuppressWarnings("unchecked")
        List<PluginServiceParameterDescriptor> params = (List<PluginServiceParameterDescriptor>)getFlowService().getPluginParameterDescriptors(dataFlow, dataService);
        //use param names to pull out keys
        ByIndexOrNameMap paramMap = new ByIndexOrNameMap();
        for(int i = 0; params != null && i < params.size(); i++)
        {
            String currentParamName = params.get(i).getName();
            String currentParamValue = request.getParameter(currentParamName);
            if(StringUtils.isNotBlank(currentParamName) && StringUtils.isNotBlank(currentParamValue))
            {
                paramMap.put(currentParamName, currentParamValue);
            }
        }

        //DataRequest configuration
        DataRequest dataRequest = new DataRequest();
        dataRequest.setService(dataService);
        dataRequest.setParameters(paramMap);
        return dataRequest;
    }

    private DataFlow getDataFlowByExchangeName(String exchangeName, EndpointVisit visit)
    {
        DataFlow dataFlow = getFlowService().getDataFlowByName(exchangeName, visit);
        return dataFlow;
    }

    private DataService getDataServiceByServiceNameAndDataFlow(String serviceName, DataFlow dataFlow)
    {
        DataService dataService = null;
        for(int i = 0; dataFlow != null && dataFlow.getServices() != null && i < dataFlow.getServices().size(); i++)
        {
            DataService currentDataService = dataFlow.getServices().get(i);
            if(StringUtils.isNotBlank(currentDataService.getName()) && currentDataService.getName().equals(serviceName))
            {
                dataService = currentDataService;
            }
        }
        return dataService;
    }

    private void writeDocumentToOutput(HttpServletRequest request, HttpServletResponse response, List<Document> documents) throws IOException,
                    FileNotFoundException
    {
        String zipResults = request.getParameter("ZipResults");
        Boolean sendResultsZipped = Boolean.TRUE;// Default should be true if not specified
        if("false".equalsIgnoreCase(zipResults))
        {
            sendResultsZipped = Boolean.FALSE;
        }
        String tempFileName = UUIDGenerator.makeId();// TODO remove this in favor of transactionId
        if(sendResultsZipped)
        {
            // write Document bytes into a temp zip file
            File zipFile = File.createTempFile("restdownload", ".zip");
            if(zipFile.exists())
            {
                zipFile.delete();
            }
            ZipOutputStream zipOut = new ZipOutputStream(new FileOutputStream(zipFile));
            for(int i = 0; documents != null && i < documents.size(); i++)
            {
                Document doc = documents.get(i);
                if(doc != null && doc.getContent() != null && doc.getContent().length > 0)
                {
                    writeFileToZip(zipOut, doc.getContent(), doc.getDocumentName());
                }
            }
            zipOut.flush();
            zipOut.close();

            response.setHeader("Cache-Control", "must-revalidate");
            response.setContentType("application/zip");

            response.setHeader("Content-Disposition", "attachment; filename=\"" + tempFileName + ".zip\"");
            FileCopyUtils.copy(new FileInputStream(zipFile), response.getOutputStream());
        }
        else
        {
            //We have to simply take the first Document in this case
            if(documents != null && documents.size() > 0)
            {
                Document doc = documents.get(0);
                byte[] output = null;
                if(CommonContentType.ZIP.equals(doc.getType()))//Must unzip first
                {
                    ZipInputStream zipIn = new ZipInputStream(new ByteArrayInputStream(doc.getContent()));
                    //Only write the first entry, again, limited to a single file due to response type
                    ZipEntry zipEntry = zipIn.getNextEntry();
                    if(zipEntry != null)
                    {
                        ByteArrayOutputStream out = new ByteArrayOutputStream();
                        int interval = 100;
                        int start = 0;
                        byte[] curr = new byte[interval];
                        int read = zipIn.read(curr, start, interval);
                        while(read != -1)
                        {
                            out.write(curr, start, read);
                            read = zipIn.read(curr, start, interval);
                        }
                        output = out.toByteArray();
                    }
                }
                else
                {
                    output = doc.getContent();
                }
                response.setHeader("Cache-Control", "must-revalidate");
                response.setContentType("application/xml");
                response.setHeader("Content-Disposition", "attachment; filename=\"" + tempFileName + ".xml\"");
                FileCopyUtils.copy(output, response.getOutputStream());
            }
        }
    }

    private void writeFileToZip(ZipOutputStream zipOut, byte[] bytes, String fileName) throws IOException
    {
        ZipEntry entry = new ZipEntry(fileName);
        zipOut.putNextEntry(entry);
        zipOut.write(bytes, 0, bytes.length);
        zipOut.closeEntry();
    }

    private EndpointVisit getEndpointVisit(HttpServletRequest request)
    {
        String securityToken = request.getParameter("token");
        EndpointTokenValidationRequest endpointTokenValidationRequest = new EndpointTokenValidationRequest(EndpointVersionType.ENREST, securityToken,
                        getClientHost(request));
        EndpointVisit visit = getSecurityService().endpointValidate(endpointTokenValidationRequest);
        return visit;
    }

    private String getClientHost(HttpServletRequest request)
    {
        String clientHost = null;
        if(StringUtils.isBlank(requestIPHeaderProperty))
        {
            clientHost = request.getRemoteAddr();
            Enumeration<?> hdEnum = request.getHeaderNames();
            while(hdEnum.hasMoreElements())
            {
                String hdKey = (String)hdEnum.nextElement();
                if(StringUtils.isNotBlank(hdKey) && hdKey.equalsIgnoreCase(HTTP_HEADER_FORWARD_FOR))
                {
                    clientHost = request.getHeader(hdKey);
                }
            }
        }
        else
        {
            clientHost = request.getHeader(requestIPHeaderProperty);
            logger.debug(requestIPHeaderProperty + ": " + clientHost);
        }
        logger.debug("[host]: " + clientHost);
        return clientHost;
    }

    public String getNodePingReadyResponse()
    {
        return nodePingReadyResponse;
    }

    public void setNodePingReadyResponse(String nodePingReadyResponse)
    {
        this.nodePingReadyResponse = nodePingReadyResponse;
    }

    public TransactionService getTransactionService()
    {
        return transactionService;
    }

    public void setTransactionService(TransactionService transactionService)
    {
        this.transactionService = transactionService;
    }

    public FlowService getFlowService()
    {
        return flowService;
    }

    public void setFlowService(FlowService flowService)
    {
        this.flowService = flowService;
    }

    public SecurityService getSecurityService()
    {
        return securityService;
    }

    public void setSecurityService(SecurityService securityService)
    {
        this.securityService = securityService;
    }

    public String getRequestIPHeaderProperty()
    {
        return requestIPHeaderProperty;
    }

    public void setRequestIPHeaderProperty(String requestIPHeaderProperty)
    {
        this.requestIPHeaderProperty = requestIPHeaderProperty;
    }

    public com.windsor.node.common.service.admin.TransactionService getNodeTransactionService()
    {
        return nodeTransactionService;
    }

    public void setNodeTransactionService(com.windsor.node.common.service.admin.TransactionService nodeTransactionService)
    {
        this.nodeTransactionService = nodeTransactionService;
    }
}
