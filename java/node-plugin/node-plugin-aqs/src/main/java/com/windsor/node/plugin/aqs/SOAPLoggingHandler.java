package com.windsor.node.plugin.aqs;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import javax.xml.namespace.QName;
import javax.xml.soap.SOAPMessage;
import javax.xml.ws.handler.MessageContext;
import javax.xml.ws.handler.soap.SOAPHandler;
import javax.xml.ws.handler.soap.SOAPMessageContext;
import java.io.ByteArrayOutputStream;
import java.util.Set;

/**
 * A SOAP handler that logs all of it's traffic.
 */
public class SOAPLoggingHandler implements SOAPHandler<SOAPMessageContext> {

    /**
     * Logger instance.
     */
    protected Logger logger = LoggerFactory.getLogger(SOAPLoggingHandler.class);

    @Override
    public Set<QName> getHeaders() {
        return null;
    }

    @Override
    public boolean handleMessage(SOAPMessageContext context) {
        logSOAPMessageContext(context);
        return true;
    }

    @Override
    public boolean handleFault(SOAPMessageContext context) {
        logSOAPMessageContext(context);
        return true;
    }

    @Override
    public void close(MessageContext context) {

    }

    /**
     * Logs a SOAP message to the configured logger.
     *
     * @param context SOAP message to log
     */
    private void logSOAPMessageContext(SOAPMessageContext context) {

        Boolean outboundProperty = (Boolean) context.get (MessageContext.MESSAGE_OUTBOUND_PROPERTY);

        String out = "";

        if (outboundProperty.booleanValue()) {
            out += "Outbound message: ";
        } else {
            out += "Inbound message: ";
        }

        SOAPMessage message = context.getMessage();

        try {
            ByteArrayOutputStream outputStream = new ByteArrayOutputStream();
            message.writeTo(outputStream);
            out += outputStream.toString();
            logger.info(out);
        } catch (Exception e) {
            logger.error("Couldn't log SOAP message: " + e.getMessage());
        }
    }
}
