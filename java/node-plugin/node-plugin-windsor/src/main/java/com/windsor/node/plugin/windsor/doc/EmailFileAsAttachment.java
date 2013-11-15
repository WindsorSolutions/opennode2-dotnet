package com.windsor.node.plugin.windsor.doc;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.Serializable;
import java.net.MalformedURLException;
import java.net.URI;
import java.net.URISyntaxException;
import java.util.ArrayList;
import java.util.List;
import org.apache.commons.io.IOUtils;
import com.windsor.node.common.domain.CommonTransactionStatusCode;
import com.windsor.node.common.domain.DataServiceRequestParameter;
import com.windsor.node.common.domain.Document;
import com.windsor.node.common.domain.NodeTransaction;
import com.windsor.node.common.domain.PluginServiceImplementorDescriptor;
import com.windsor.node.common.domain.ProcessContentResult;
import com.windsor.node.common.domain.ServiceType;
import com.windsor.node.common.exception.WinNodeException;
import com.windsor.node.data.dao.PluginServiceParameterDescriptor;
import com.windsor.node.plugin.common.BaseWnosJaxbPlugin;

public class EmailFileAsAttachment extends BaseWnosJaxbPlugin implements Serializable
{
    private static final long serialVersionUID = -3352579592079235607L;

    public static final PluginServiceParameterDescriptor FILE_URI = new PluginServiceParameterDescriptor("File URI",
                    PluginServiceParameterDescriptor.TYPE_STRING, Boolean.TRUE,
                    "URL of file.");
    public static final PluginServiceParameterDescriptor EMAIL_ADDRESSES = new PluginServiceParameterDescriptor("Email Addresses",
                    PluginServiceParameterDescriptor.TYPE_STRING, Boolean.TRUE,
                    "Semicolon delemited list of email addresses.");

    private static final PluginServiceImplementorDescriptor PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR = new PluginServiceImplementorDescriptor();

    static
    {
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setName("EmailFileAsAttachment");
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setDescription("Windsor utility method to email a file to an address, access should be restricted.");
        PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR.setClassName(EmailFileAsAttachment.class.getCanonicalName());
    }

    @Override
    public PluginServiceImplementorDescriptor getPluginServiceImplementorDescription()
    {
        return PLUGIN_SERVICE_IMPLEMENTOR_DESCRIPTOR;
    }

    public EmailFileAsAttachment()
    {
        setPublishForEN11(true);
        setPublishForEN20(true);
        getSupportedPluginTypes().add(ServiceType.TASK);
    }


    @Override
    public ProcessContentResult process(NodeTransaction transaction)
    {
        try
        {
            ProcessContentResult result = new ProcessContentResult();
            result.setSuccess(false);
            result.setStatus(CommonTransactionStatusCode.Failed);

            URI uri = new URI((String)transaction.getRequest().getParameters().get(FILE_URI.getName()));
            String[] emails = ((String)transaction.getRequest().getParameters().get(EMAIL_ADDRESSES.getName())).split(";");
            File file = new File(uri);
            byte[] bytes = IOUtils.toByteArray(new FileInputStream(file));
            for(int i = 0; i < emails.length; i++)
            {
                List<Document> attachments = new ArrayList<>();
                Document doc = new Document();
                doc.setDocumentName(file.getName());
                doc.setContent(bytes);
                attachments.add(doc);
                getNotificationHelper().sendTransactionStatusUpdate(transaction, emails[i], transaction.getFlow().getName(), attachments);
            }

            result.setSuccess(true);
            result.setStatus(CommonTransactionStatusCode.Completed);
            return result;
        }
        catch(MalformedURLException e)
        {
            throw new WinNodeException(e);
        }
        catch(FileNotFoundException e)
        {
            throw new WinNodeException(e);
        }
        catch(IOException e)
        {
            throw new WinNodeException(e);
        }
        catch(URISyntaxException e)
        {
            throw new WinNodeException(e);
        }
    }

    @Override
    public List<PluginServiceParameterDescriptor> getParameters()
    {
        List<PluginServiceParameterDescriptor> params = new ArrayList<PluginServiceParameterDescriptor>();
        params.add(FILE_URI);
        params.add(EMAIL_ADDRESSES);
        return params;
    }

    @Override
    public List<DataServiceRequestParameter> getServiceRequestParamSpecs(String serviceName)
    {
        // TODO Auto-generated method stub
        return null;
    }

}
