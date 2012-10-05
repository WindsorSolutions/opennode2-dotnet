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
 * Copyright 2001-2004 The Apache Software Foundation.
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *      http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
package org.apache.axis.transport.http;

import java.io.ByteArrayOutputStream;
import java.io.FilterInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.net.URL;
import java.util.ArrayList;
import java.util.Hashtable;
import java.util.Iterator;
import java.util.Map;
import java.util.StringTokenizer;
import java.util.zip.GZIPInputStream;
import java.util.zip.GZIPOutputStream;

import javax.xml.soap.MimeHeader;
import javax.xml.soap.MimeHeaders;
import javax.xml.soap.SOAPException;

import org.apache.axis.AxisFault;
import org.apache.axis.Constants;
import org.apache.axis.Message;
import org.apache.axis.MessageContext;
import org.apache.axis.components.net.CommonsHTTPClientProperties;
import org.apache.axis.components.net.CommonsHTTPClientPropertiesFactory;
import org.apache.axis.components.net.TransportClientProperties;
import org.apache.axis.components.net.TransportClientPropertiesFactory;
import org.apache.axis.handlers.BasicHandler;
import org.apache.axis.soap.SOAP12Constants;
import org.apache.axis.soap.SOAPConstants;
import org.apache.axis.utils.JavaUtils;
import org.apache.axis.utils.Messages;
import org.apache.axis.utils.NetworkUtils;
import org.apache.commons.httpclient.Cookie;
import org.apache.commons.httpclient.Credentials;
import org.apache.commons.httpclient.Header;
import org.apache.commons.httpclient.HostConfiguration;
import org.apache.commons.httpclient.HttpClient;
import org.apache.commons.httpclient.HttpConnectionManager;
import org.apache.commons.httpclient.HttpMethodBase;
import org.apache.commons.httpclient.HttpState;
import org.apache.commons.httpclient.HttpVersion;
import org.apache.commons.httpclient.MultiThreadedHttpConnectionManager;
import org.apache.commons.httpclient.NTCredentials;
import org.apache.commons.httpclient.UsernamePasswordCredentials;
import org.apache.commons.httpclient.auth.AuthScope;
import org.apache.commons.httpclient.contrib.ssl.WindsorSSLProtocolSocketFactory;
import org.apache.commons.httpclient.cookie.CookiePolicy;
import org.apache.commons.httpclient.methods.GetMethod;
import org.apache.commons.httpclient.methods.PostMethod;
import org.apache.commons.httpclient.methods.RequestEntity;
import org.apache.commons.httpclient.params.HttpMethodParams;
import org.apache.commons.httpclient.protocol.Protocol;
import org.apache.commons.httpclient.protocol.ProtocolSocketFactory;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

/**
 * This class uses Jakarta Commons's HttpClient to call a SOAP server.
 * 
 * <p>
 * Originally from the Axis 1.3 distribution, modified by Windsor Solutions to
 * enhance logging and use a more lenient TrustManager.
 * </p>
 * 
 * @author Davanum Srinivas (dims@yahoo.com) History: By Chandra Talluri
 *         Modifications done for maintaining sessions. Cookies needed to be set
 *         on HttpState not on MessageContext, since HttpMethodBase overwrites
 *         the cookies from HttpState. Also we need to setCookiePolicy on
 *         HttpState to CookiePolicy.COMPATIBILITY else it is defaulting to
 *         RFC2109Spec and adding Version information to it and tomcat server
 *         not recognizing it
 */
public class WindsorHTTPSender extends BasicHandler {

    private static final long serialVersionUID = 1L;

    /** Field log */
    private static final Logger log = LoggerFactory
            .getLogger(WindsorHTTPSender.class
            .getName());

    protected HttpConnectionManager connectionManager;
    protected CommonsHTTPClientProperties clientProperties;
    boolean httpChunkStream = true; // Use HTTP chunking or not.

    public WindsorHTTPSender() {
        log.debug("WindsorHTTPSender: constructor");
        initialize();
    }

    protected void initialize() {
        /* added by Windsor */
        log.debug("Setting up WindsorSSLProtocolSocketFactory");
        ProtocolSocketFactory factory = new WindsorSSLProtocolSocketFactory();
        Protocol https = new Protocol("https", factory, 443);
        Protocol.registerProtocol("https", https);
        log.debug("WindsorSSLProtocolSocketFactory created and registered");
        /* end added by Windsor */

        MultiThreadedHttpConnectionManager cm = new MultiThreadedHttpConnectionManager();
        this.clientProperties = CommonsHTTPClientPropertiesFactory.create();
        cm.getParams().setDefaultMaxConnectionsPerHost(
                clientProperties.getMaximumConnectionsPerHost());
        cm.getParams().setMaxTotalConnections(
                clientProperties.getMaximumTotalConnections());
        // If defined, set the default timeouts
        // Can be overridden by the MessageContext
        if (this.clientProperties.getDefaultConnectionTimeout() > 0) {
            cm.getParams().setConnectionTimeout(
                    this.clientProperties.getDefaultConnectionTimeout());
        }
        if (this.clientProperties.getDefaultSoTimeout() > 0) {
            cm.getParams().setSoTimeout(
                    this.clientProperties.getDefaultSoTimeout());
        }
        this.connectionManager = cm;
    }

    /**
     * invoke creates a socket connection, sends the request SOAP message and
     * then reads the response SOAP message back from the SOAP server
     * 
     * @param msgContext
     *            the messsage context
     * 
     * @throws AxisFault
     */
    public void invoke(MessageContext msgContext) throws AxisFault {
        HttpMethodBase method = null;
        if (log.isDebugEnabled()) {
            log.debug(Messages.getMessage("enter00",
                    "WindsorHTTPSender::invoke"));
        }
        try {
            URL targetURL = new URL(msgContext
                    .getStrProp(MessageContext.TRANS_URL));

            // no need to retain these, as the cookies/credentials are
            // stored in the message context across multiple requests.
            // the underlying connection manager, however, is retained
            // so sockets get recycled when possible.
            HttpClient httpClient = new HttpClient(this.connectionManager);
            // the timeout value for allocation of connections from the pool
            httpClient.getParams().setConnectionManagerTimeout(
                    this.clientProperties.getConnectionPoolTimeout());

            HostConfiguration hostConfiguration = getHostConfiguration(
                    httpClient, msgContext, targetURL);

            boolean posting = true;

            // If we're SOAP 1.2, allow the web method to be set from the
            // MessageContext.
            if (msgContext.getSOAPConstants() == SOAPConstants.SOAP12_CONSTANTS) {
                String webMethod = msgContext
                        .getStrProp(SOAP12Constants.PROP_WEBMETHOD);
                if (webMethod != null) {
                    posting = webMethod.equals(HTTPConstants.HEADER_POST);
                }
            }

            if (posting) {
                log.debug("using HTTP POST");
                Message reqMessage = msgContext.getRequestMessage();
                method = new PostMethod(targetURL.toString());

                // set false as default, addContextInfo can overwrite
                method.getParams().setBooleanParameter(
                        HttpMethodParams.USE_EXPECT_CONTINUE, false);

                addContextInfo(method, httpClient, msgContext, targetURL);

                MessageRequestEntity requestEntity = null;
                if (msgContext.isPropertyTrue(HTTPConstants.MC_GZIP_REQUEST)) {
                    requestEntity = new GzipMessageRequestEntity(method,
                            reqMessage, httpChunkStream);
                } else {
                    requestEntity = new MessageRequestEntity(method,
                            reqMessage, httpChunkStream);
                }
                ((PostMethod) method).setRequestEntity(requestEntity);
            } else {
                log.debug("using HTTP GET");
                method = new GetMethod(targetURL.toString());
                addContextInfo(method, httpClient, msgContext, targetURL);
            }

            String httpVersion = msgContext
                    .getStrProp(MessageContext.HTTP_TRANSPORT_VERSION);
            log.debug("HTTP version from MessageContext: " + httpVersion);

            if (httpVersion != null) {
                if (httpVersion.equals(HTTPConstants.HEADER_PROTOCOL_V10)) {
                    method.getParams().setVersion(HttpVersion.HTTP_1_0);
                }
                // assume 1.1
            }

            // don't forget the cookies!
            // Cookies need to be set on HttpState, since HttpMethodBase
            // overwrites the cookies from HttpState
            if (msgContext.getMaintainSession()) {
                HttpState state = httpClient.getState();
                method.getParams().setCookiePolicy(
                        CookiePolicy.BROWSER_COMPATIBILITY);
                String host = hostConfiguration.getHost();
                String path = targetURL.getPath();
                boolean secure = hostConfiguration.getProtocol().isSecure();
                fillHeaders(msgContext, state, HTTPConstants.HEADER_COOKIE,
                        host, path, secure);
                fillHeaders(msgContext, state, HTTPConstants.HEADER_COOKIE2,
                        host, path, secure);
                httpClient.setState(state);
            }

            /* added by Windsor */
            log
                    .debug("Calling httpClient.executeMethod(), with hostConfiguration: "
                            + hostConfiguration);
            int returnCode = httpClient.executeMethod(hostConfiguration,
                    method, null);

            String contentType = getHeader(method,
                    HTTPConstants.HEADER_CONTENT_TYPE);
            String contentLocation = getHeader(method,
                    HTTPConstants.HEADER_CONTENT_LOCATION);
            // String contentLength = getHeader(method,
            // HTTPConstants.HEADER_CONTENT_LENGTH);

            if ((returnCode > 199) && (returnCode < 300)) {

                // SOAP return is OK - so fall through
            } else if (msgContext.getSOAPConstants() == SOAPConstants.SOAP12_CONSTANTS) {
                // For now, if we're SOAP 1.2, fall through, since the range of
                // valid result codes is much greater
            } else if ((contentType != null)
                    && !contentType.equals("text/html")
                    && ((returnCode > 499) && (returnCode < 600))) {

                // SOAP Fault should be in here - so fall through
            } else {
                String statusMessage = method.getStatusText();
                AxisFault fault = new AxisFault("HTTP", "(" + returnCode + ")"
                        + statusMessage, null, null);

                try {
                    fault.setFaultDetailString(Messages.getMessage("return01",
                            "" + returnCode, method.getResponseBodyAsString()));
                    fault.addFaultDetail(
                            Constants.QNAME_FAULTDETAIL_HTTPERRORCODE, Integer
                                    .toString(returnCode));
                    throw fault;
                } finally {
                    method.releaseConnection(); // release connection back to
                    // pool.
                }
            }

            // wrap the response body stream so that close() also releases
            // the connection back to the pool.
            InputStream releaseConnectionOnCloseStream = createConnectionReleasingInputStream(method);

            Header contentEncoding = method
                    .getResponseHeader(HTTPConstants.HEADER_CONTENT_ENCODING);
            if (contentEncoding != null) {
                if (contentEncoding.getValue().equalsIgnoreCase(
                        HTTPConstants.COMPRESSION_GZIP)) {
                    releaseConnectionOnCloseStream = new GZIPInputStream(
                            releaseConnectionOnCloseStream);
                } else {
                    AxisFault fault = new AxisFault("HTTP",
                            "unsupported content-encoding of '"
                                    + contentEncoding.getValue() + "' found",
                            null, null);
                    throw fault;
                }

            }
            Message outMsg = new Message(releaseConnectionOnCloseStream, false,
                    contentType, contentLocation);
            // Transfer HTTP headers of HTTP message to MIME headers of SOAP
            // message
            Header[] responseHeaders = method.getResponseHeaders();
            MimeHeaders responseMimeHeaders = outMsg.getMimeHeaders();
            for (int i = 0; i < responseHeaders.length; i++) {
                Header responseHeader = responseHeaders[i];
                responseMimeHeaders.addHeader(responseHeader.getName(),
                        responseHeader.getValue());
            }
            outMsg.setMessageType(Message.RESPONSE);
            msgContext.setResponseMessage(outMsg);
            if (log.isDebugEnabled()) {
                log.debug(Messages.getMessage("xmlRecd00"));
                log.debug("-----------------------------------------------");
                log.debug(outMsg.getSOAPPartAsString());
            }

            // if we are maintaining session state,
            // handle cookies (if any)
            if (msgContext.getMaintainSession()) {
                Header[] headers = method.getResponseHeaders();

                for (int i = 0; i < headers.length; i++) {
                    if (headers[i].getName().equalsIgnoreCase(
                            HTTPConstants.HEADER_SET_COOKIE)) {
                        handleCookie(HTTPConstants.HEADER_COOKIE, headers[i]
                                .getValue(), msgContext);
                    } else if (headers[i].getName().equalsIgnoreCase(
                            HTTPConstants.HEADER_SET_COOKIE2)) {
                        handleCookie(HTTPConstants.HEADER_COOKIE2, headers[i]
                                .getValue(), msgContext);
                    }
                }
            }

            // always release the connection back to the pool if
            // it was one way invocation
            if (msgContext.isPropertyTrue("axis.one.way")) {
                method.releaseConnection();
            }

        } catch (Exception e) {
            log.debug(e.getMessage(), e);
            throw AxisFault.makeFault(e);
        }

        if (log.isDebugEnabled()) {
            log.debug(Messages
                    .getMessage("exit00", "WindsorHTTPSender::invoke"));
        }
    }

    /**
     * little helper function for cookies. fills up the message context with a
     * string or an array of strings (if there are more than one Set-Cookie)
     * 
     * @param cookieName
     * @param setCookieName
     * @param cookie
     * @param msgContext
     */
    public void handleCookie(String cookieName, String cookie,
            MessageContext msgContext) {

        cookie = cleanupCookie(cookie);
        int keyIndex = cookie.indexOf("=");
        String key = (keyIndex != -1) ? cookie.substring(0, keyIndex) : cookie;

        ArrayList cookies = new ArrayList();
        Object oldCookies = msgContext.getProperty(cookieName);
        boolean alreadyExist = false;
        if (oldCookies != null) {
            if (oldCookies instanceof String[]) {
                String[] oldCookiesArray = (String[]) oldCookies;
                for (int i = 0; i < oldCookiesArray.length; i++) {
                    String anOldCookie = oldCookiesArray[i];
                    if (key != null && anOldCookie.indexOf(key) == 0) { // same
                        // cookie
                        // key
                        anOldCookie = cookie; // update to new one
                        alreadyExist = true;
                    }
                    cookies.add(anOldCookie);
                }
            } else {
                String oldCookie = (String) oldCookies;
                if (key != null && oldCookie.indexOf(key) == 0) { // same cookie
                    // key
                    oldCookie = cookie; // update to new one
                    alreadyExist = true;
                }
                cookies.add(oldCookie);
            }
        }

        if (!alreadyExist) {
            cookies.add(cookie);
        }

        if (cookies.size() == 1) {
            msgContext.setProperty(cookieName, cookies.get(0));
        } else if (cookies.size() > 1) {
            msgContext.setProperty(cookieName, cookies
                    .toArray(new String[cookies.size()]));
        }
    }

    /**
     * Add cookies from message context
     * 
     * @param msgContext
     * @param state
     * @param header
     * @param host
     * @param path
     * @param secure
     */
    private void fillHeaders(MessageContext msgContext, HttpState state,
            String header, String host, String path, boolean secure) {
        Object ck1 = msgContext.getProperty(header);
        if (ck1 != null) {
            if (ck1 instanceof String[]) {
                String[] cookies = (String[]) ck1;
                for (int i = 0; i < cookies.length; i++) {
                    addCookie(state, cookies[i], host, path, secure);
                }
            } else {
                addCookie(state, (String) ck1, host, path, secure);
            }
        }
    }

    /**
     * add cookie to state
     * 
     * @param state
     * @param cookie
     */
    private void addCookie(HttpState state, String cookie, String host,
            String path, boolean secure) {
        int index = cookie.indexOf('=');
        state.addCookie(new Cookie(host, cookie.substring(0, index), cookie
                .substring(index + 1), path, null, secure));
    }

    /**
     * cleanup the cookie value.
     * 
     * @param cookie
     *            initial cookie value
     * 
     * @return a cleaned up cookie value.
     */
    private String cleanupCookie(String cookie) {
        cookie = cookie.trim();
        // chop after first ; a la Apache SOAP (see HTTPUtils.java there)
        int index = cookie.indexOf(';');
        if (index != -1) {
            cookie = cookie.substring(0, index);
        }
        return cookie;
    }

    protected HostConfiguration getHostConfiguration(HttpClient client,
            MessageContext context, URL targetURL) {
        TransportClientProperties tcp = TransportClientPropertiesFactory
                .create(targetURL.getProtocol()); // http or https
        int port = targetURL.getPort();
        boolean hostInNonProxyList = isHostInNonProxyList(targetURL.getHost(),
                tcp.getNonProxyHosts());

        HostConfiguration config = new HostConfiguration();

        if (port == -1) {
            if (targetURL.getProtocol().equalsIgnoreCase("https")) {
                port = 443; // default port for https being 443
            } else { // it must be http
                port = 80; // default port for http being 80
            }
        }

        if (hostInNonProxyList) {
            config.setHost(targetURL.getHost(), port, targetURL.getProtocol());
        } else {
            if (tcp.getProxyHost().length() == 0
                    || tcp.getProxyPort().length() == 0) {
                config.setHost(targetURL.getHost(), port, targetURL
                        .getProtocol());
            } else {
                if (tcp.getProxyUser().length() != 0) {
                    Credentials proxyCred = new UsernamePasswordCredentials(tcp
                            .getProxyUser(), tcp.getProxyPassword());
                    // if the username is in the form "user\domain"
                    // then use NTCredentials instead.
                    int domainIndex = tcp.getProxyUser().indexOf("\\");
                    if (domainIndex > 0) {
                        String domain = tcp.getProxyUser().substring(0,
                                domainIndex);
                        if (tcp.getProxyUser().length() > domainIndex + 1) {
                            String user = tcp.getProxyUser().substring(
                                    domainIndex + 1);
                            proxyCred = new NTCredentials(user, tcp
                                    .getProxyPassword(), tcp.getProxyHost(),
                                    domain);
                        }
                    }
                    client.getState().setProxyCredentials(AuthScope.ANY,
                            proxyCred);
                }
                int proxyPort = new Integer(tcp.getProxyPort()).intValue();
                config.setProxy(tcp.getProxyHost(), proxyPort);
            }
        }
        return config;
    }

    /**
     * Extracts info from message context.
     * 
     * @param method
     *            Post method
     * @param httpClient
     *            The client used for posting
     * @param msgContext
     *            the message context
     * @param tmpURL
     *            the url to post to.
     * 
     * @throws Exception
     */
    private void addContextInfo(HttpMethodBase method, HttpClient httpClient,
            MessageContext msgContext, URL tmpURL) throws Exception {

        // optionally set a timeout for the request
        if (msgContext.getTimeout() != 0) {
            /*
             * ISSUE: these are not the same, but MessageContext has only one
             * definition of timeout
             */
            // SO_TIMEOUT -- timeout for blocking reads
            httpClient.getHttpConnectionManager().getParams().setSoTimeout(
                    msgContext.getTimeout());
            // timeout for initial connection
            httpClient.getHttpConnectionManager().getParams()
                    .setConnectionTimeout(msgContext.getTimeout());
        }

        // Get SOAPAction, default to ""
        String action = msgContext.useSOAPAction() ? msgContext
                .getSOAPActionURI() : "";

        if (action == null) {
            action = "";
        }

        Message msg = msgContext.getRequestMessage();
        if (msg != null) {
            method.setRequestHeader(new Header(
                    HTTPConstants.HEADER_CONTENT_TYPE, msg
                            .getContentType(msgContext.getSOAPConstants())));
        }
        method.setRequestHeader(new Header(HTTPConstants.HEADER_SOAP_ACTION,
                "\"" + action + "\""));
        method.setRequestHeader(new Header(HTTPConstants.HEADER_USER_AGENT,
                Messages.getMessage("axisUserAgent")));
        String userID = msgContext.getUsername();
        String passwd = msgContext.getPassword();

        // if UserID is not part of the context, but is in the URL, use
        // the one in the URL.
        if ((userID == null) && (tmpURL.getUserInfo() != null)) {
            String info = tmpURL.getUserInfo();
            int sep = info.indexOf(':');

            if ((sep >= 0) && (sep + 1 < info.length())) {
                userID = info.substring(0, sep);
                passwd = info.substring(sep + 1);
            } else {
                userID = info;
            }
        }
        if (userID != null) {
            Credentials proxyCred = new UsernamePasswordCredentials(userID,
                    passwd);
            // if the username is in the form "user\domain"
            // then use NTCredentials instead.
            int domainIndex = userID.indexOf("\\");
            if (domainIndex > 0) {
                String domain = userID.substring(0, domainIndex);
                if (userID.length() > domainIndex + 1) {
                    String user = userID.substring(domainIndex + 1);
                    proxyCred = new NTCredentials(user, passwd, NetworkUtils
                            .getLocalHostname(), domain);
                }
            }
            httpClient.getState().setCredentials(AuthScope.ANY, proxyCred);
        }

        // add compression headers if needed
        if (msgContext.isPropertyTrue(HTTPConstants.MC_ACCEPT_GZIP)) {
            method.addRequestHeader(HTTPConstants.HEADER_ACCEPT_ENCODING,
                    HTTPConstants.COMPRESSION_GZIP);
        }
        if (msgContext.isPropertyTrue(HTTPConstants.MC_GZIP_REQUEST)) {
            method.addRequestHeader(HTTPConstants.HEADER_CONTENT_ENCODING,
                    HTTPConstants.COMPRESSION_GZIP);
        }

        // Transfer MIME headers of SOAPMessage to HTTP headers.
        MimeHeaders mimeHeaders = msg.getMimeHeaders();
        if (mimeHeaders != null) {
            for (Iterator i = mimeHeaders.getAllHeaders(); i.hasNext();) {
                MimeHeader mimeHeader = (MimeHeader) i.next();
                // HEADER_CONTENT_TYPE and HEADER_SOAP_ACTION are already set.
                // Let's not duplicate them.
                String headerName = mimeHeader.getName();
                if (headerName.equals(HTTPConstants.HEADER_CONTENT_TYPE)
                        || headerName.equals(HTTPConstants.HEADER_SOAP_ACTION)) {
                    continue;
                }
                method.addRequestHeader(mimeHeader.getName(), mimeHeader
                        .getValue());
            }
        }

        // process user defined headers for information.
        Hashtable userHeaderTable = (Hashtable) msgContext
                .getProperty(HTTPConstants.REQUEST_HEADERS);

        if (userHeaderTable != null) {
            for (Iterator e = userHeaderTable.entrySet().iterator(); e
                    .hasNext();) {
                Map.Entry me = (Map.Entry) e.next();
                Object keyObj = me.getKey();

                if (null == keyObj) {
                    continue;
                }
                String key = keyObj.toString().trim();
                String value = me.getValue().toString().trim();

                if (key.equalsIgnoreCase(HTTPConstants.HEADER_EXPECT)
                        && value
                                .equalsIgnoreCase(HTTPConstants.HEADER_EXPECT_100_Continue)) {
                    method.getParams().setBooleanParameter(
                            HttpMethodParams.USE_EXPECT_CONTINUE, true);
                } else if (key
                        .equalsIgnoreCase(HTTPConstants.HEADER_TRANSFER_ENCODING_CHUNKED)) {
                    String val = me.getValue().toString();
                    if (null != val) {
                        httpChunkStream = JavaUtils.isTrue(val);
                    }
                } else {
                    method.addRequestHeader(key, value);
                }
            }
        }
    }

    /**
     * Check if the specified host is in the list of non proxy hosts.
     * 
     * @param host
     *            host name
     * @param nonProxyHosts
     *            string containing the list of non proxy hosts
     * 
     * @return true/false
     */
    protected boolean isHostInNonProxyList(String host, String nonProxyHosts) {

        if ((nonProxyHosts == null) || (host == null)) {
            return false;
        }

        /*
         * The http.nonProxyHosts system property is a list enclosed in double
         * quotes with items separated by a vertical bar.
         */
        StringTokenizer tokenizer = new StringTokenizer(nonProxyHosts, "|\"");

        while (tokenizer.hasMoreTokens()) {
            String pattern = tokenizer.nextToken();

            if (log.isDebugEnabled()) {
                log.debug(Messages.getMessage("match00", new String[] {
                        "HTTPSender", host, pattern }));
            }
            if (match(pattern, host, false)) {
                return true;
            }
        }
        return false;
    }

    /**
     * Matches a string against a pattern. The pattern contains two special
     * characters: '*' which means zero or more characters,
     * 
     * @param pattern
     *            the (non-null) pattern to match against
     * @param str
     *            the (non-null) string that must be matched against the pattern
     * @param isCaseSensitive
     * 
     * @return <code>true</code> when the string matches against the pattern,
     *         <code>false</code> otherwise.
     */
    protected static boolean match(String pattern, String str,
            boolean isCaseSensitive) {

        char[] patArr = pattern.toCharArray();
        char[] strArr = str.toCharArray();
        int patIdxStart = 0;
        int patIdxEnd = patArr.length - 1;
        int strIdxStart = 0;
        int strIdxEnd = strArr.length - 1;
        char ch;
        boolean containsStar = false;

        for (int i = 0; i < patArr.length; i++) {
            if (patArr[i] == '*') {
                containsStar = true;
                break;
            }
        }
        if (!containsStar) {

            // No '*'s, so we make a shortcut
            if (patIdxEnd != strIdxEnd) {
                return false; // Pattern and string do not have the same size
            }
            for (int i = 0; i <= patIdxEnd; i++) {
                ch = patArr[i];
                if (isCaseSensitive && (ch != strArr[i])) {
                    return false; // Character mismatch
                }
                if (!isCaseSensitive
                        && (Character.toUpperCase(ch) != Character
                                .toUpperCase(strArr[i]))) {
                    return false; // Character mismatch
                }
            }
            return true; // String matches against pattern
        }
        if (patIdxEnd == 0) {
            return true; // Pattern contains only '*', which matches anything
        }

        // Process characters before first star
        while ((ch = patArr[patIdxStart]) != '*' && (strIdxStart <= strIdxEnd)) {
            if (isCaseSensitive && (ch != strArr[strIdxStart])) {
                return false; // Character mismatch
            }
            if (!isCaseSensitive
                    && (Character.toUpperCase(ch) != Character
                            .toUpperCase(strArr[strIdxStart]))) {
                return false; // Character mismatch
            }
            patIdxStart++;
            strIdxStart++;
        }
        if (strIdxStart > strIdxEnd) {

            // All characters in the string are used. Check if only '*'s are
            // left in the pattern. If so, we succeeded. Otherwise failure.
            for (int i = patIdxStart; i <= patIdxEnd; i++) {
                if (patArr[i] != '*') {
                    return false;
                }
            }
            return true;
        }

        // Process characters after last star
        while ((ch = patArr[patIdxEnd]) != '*' && (strIdxStart <= strIdxEnd)) {
            if (isCaseSensitive && (ch != strArr[strIdxEnd])) {
                return false; // Character mismatch
            }
            if (!isCaseSensitive
                    && (Character.toUpperCase(ch) != Character
                            .toUpperCase(strArr[strIdxEnd]))) {
                return false; // Character mismatch
            }
            patIdxEnd--;
            strIdxEnd--;
        }
        if (strIdxStart > strIdxEnd) {

            // All characters in the string are used. Check if only '*'s are
            // left in the pattern. If so, we succeeded. Otherwise failure.
            for (int i = patIdxStart; i <= patIdxEnd; i++) {
                if (patArr[i] != '*') {
                    return false;
                }
            }
            return true;
        }

        // process pattern between stars. padIdxStart and patIdxEnd point
        // always to a '*'.
        while ((patIdxStart != patIdxEnd) && (strIdxStart <= strIdxEnd)) {
            int patIdxTmp = -1;

            for (int i = patIdxStart + 1; i <= patIdxEnd; i++) {
                if (patArr[i] == '*') {
                    patIdxTmp = i;
                    break;
                }
            }
            if (patIdxTmp == patIdxStart + 1) {

                // Two stars next to each other, skip the first one.
                patIdxStart++;
                continue;
            }

            // Find the pattern between padIdxStart & padIdxTmp in str between
            // strIdxStart & strIdxEnd
            int patLength = (patIdxTmp - patIdxStart - 1);
            int strLength = (strIdxEnd - strIdxStart + 1);
            int foundIdx = -1;

            strLoop: for (int i = 0; i <= strLength - patLength; i++) {
                for (int j = 0; j < patLength; j++) {
                    ch = patArr[patIdxStart + j + 1];
                    if (isCaseSensitive && (ch != strArr[strIdxStart + i + j])) {
                        continue strLoop;
                    }
                    if (!isCaseSensitive
                            && (Character.toUpperCase(ch) != Character
                                    .toUpperCase(strArr[strIdxStart + i + j]))) {
                        continue strLoop;
                    }
                }
                foundIdx = strIdxStart + i;
                break;
            }
            if (foundIdx == -1) {
                return false;
            }
            patIdxStart = patIdxTmp;
            strIdxStart = foundIdx + patLength;
        }

        // All characters in the string are used. Check if only '*'s are left
        // in the pattern. If so, we succeeded. Otherwise failure.
        for (int i = patIdxStart; i <= patIdxEnd; i++) {
            if (patArr[i] != '*') {
                return false;
            }
        }
        return true;
    }

    private static String getHeader(HttpMethodBase method, String headerName) {
        Header header = method.getResponseHeader(headerName);
        return (header == null) ? null : header.getValue().trim();
    }

    private InputStream createConnectionReleasingInputStream(
            final HttpMethodBase method) throws IOException {
        return new FilterInputStream(method.getResponseBodyAsStream()) {
            public void close() throws IOException {
                try {
                    super.close();
                } finally {
                    method.releaseConnection();
                }
            }
        };
    }

    private static class MessageRequestEntity implements RequestEntity {

        private HttpMethodBase method;
        private Message message;
        boolean httpChunkStream = true; // Use HTTP chunking or not.

        public MessageRequestEntity(HttpMethodBase method, Message message) {
            log.debug("MessageRequestEntity(method, message)");
            this.message = message;
            this.method = method;
        }

        public MessageRequestEntity(HttpMethodBase method, Message message,
                boolean httpChunkStream) {
            log.debug("MessageRequestEntity(method, message, httpChunkStream)");
            this.message = message;
            this.method = method;
            this.httpChunkStream = httpChunkStream;
        }

        public boolean isRepeatable() {
            return true;
        }

        public void writeRequest(OutputStream out) throws IOException {
            try {
                this.message.writeTo(out);
            } catch (SOAPException e) {
                throw new IOException(e.getMessage());
            }
        }

        protected boolean isContentLengthNeeded() {
            log
                    .debug("(this.method.getParams().getVersion() == HttpVersion.HTTP_1_0): "
                            + (this.method.getParams().getVersion() == HttpVersion.HTTP_1_0));
            log.debug("httpChunkStream = " + httpChunkStream);
            boolean b = this.method.getParams().getVersion() == HttpVersion.HTTP_1_0
                    || !httpChunkStream;
            log.debug("isContentLengthNeeded() = " + b);
            return b;
        }

        public long getContentLength() {
            long length = 0;
            if (isContentLengthNeeded()) {
                try {
                    length = message.getContentLength();
                } catch (Exception e) {
                }
            } else {
                length = -1; /* -1 for chunked */
            }
            log.debug("getContentLength() = " + length);
            return length;
        }

        public String getContentType() {
            return null; // a separate header is added
        }

    }

    private static class GzipMessageRequestEntity extends MessageRequestEntity {

        public GzipMessageRequestEntity(HttpMethodBase method, Message message) {
            super(method, message);
            log.debug("from GzipMessageRequestEntity(method, message)");
        }

        public GzipMessageRequestEntity(HttpMethodBase method, Message message,
                boolean httpChunkStream) {
            super(method, message, httpChunkStream);
            log
                    .debug("from GzipMessageRequestEntity(method, message, httpChunkStream)");
        }

        public void writeRequest(OutputStream out) throws IOException {
            if (cachedStream != null) {
                cachedStream.writeTo(out);
            } else {
                GZIPOutputStream gzStream = new GZIPOutputStream(out);
                super.writeRequest(gzStream);
                gzStream.finish();
            }
        }

        public long getContentLength() {
            long length = 0;
            if (isContentLengthNeeded()) {
                ByteArrayOutputStream baos = new ByteArrayOutputStream();
                try {
                    writeRequest(baos);
                    cachedStream = baos;
                    length = baos.size();
                } catch (IOException e) {
                    // fall through to doing chunked.
                }
            } else {
                length = -1; // do chunked
            }
            log.debug("getContentLength() = " + length);
            return length;

        }

        private ByteArrayOutputStream cachedStream;
    }
}