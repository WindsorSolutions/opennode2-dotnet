package com.windsor.node.plugin.rcra52;

import com.windsor.node.plugin.rcra52.solicit.request.SolicitRequest;
import com.windsor.node.plugin.rcra52.solicit.request.SolicitRequestFactory;
import com.windsor.node.plugin.rcra52.status.GetStatusRequest;
import com.windsor.node.service.helper.naas.auth.AuthMethod;
import com.windsor.node.service.helper.naas.auth.NetworkSecurityBindingStub;
import net.exchangenetwork.schema.node._2.*;
import net.exchangenetwork.wsdl.node._2.NodeFaultMessage;
import org.apache.axis.AxisFault;

import java.net.MalformedURLException;
import java.net.URL;
import java.rmi.RemoteException;
import java.util.Calendar;
import java.util.GregorianCalendar;

public class TestClient {

    private final static String TEST_NAAS = "https://naas.epacdxnode.net/xml/auth.wsdl";
    private final static String PROD_NAAS = "https://cdxnodenaas.epa.gov/xml/auth.wsdl";
    private final static String NAAS_ACCOUNT = "chris_miles@windsorsolutions.com";
    private final static String TEST_NASS_PASS = "Wp893D73";
    private final static String PROD_NAAS_PASS = "Wp7A0D30";

    public static void main(String[] args) {

        String securityToken = null;
        String transactionId = null;
        String testEndpoint = "https://testngn.epacdxnode.net/ngn-enws20/services/NetworkNode2ServiceConditionalMTOM";

        try {
            NetworkSecurityBindingStub securityBindingStub =
                    new NetworkSecurityBindingStub(new URL(TEST_NAAS), null);
            securityToken = securityBindingStub.authenticate(NAAS_ACCOUNT, TEST_NASS_PASS,
                    AuthMethod.fromValue("password"));
            System.out.println("Security Token: " + securityToken);
        } catch(MalformedURLException exception) {
            System.out.println("Bad URL: " + exception.getMessage());
        } catch(AxisFault exception) {
            System.out.println("Axis Fault: " + exception.getMessage());
        } catch(RemoteException exception) {
            System.out.println("RMI exception: " + exception.getMessage());
        }

        SolicitRequestFactory requestFactory =
                new SolicitRequestFactory(testEndpoint, securityToken);
        SolicitRequest request = requestFactory.getCAByState("MA",
                new GregorianCalendar(2016, Calendar.MARCH, 1).getTime());

        try {
            StatusResponseType responseType = request.execute();
            transactionId = responseType.getTransactionId();
            System.out.println("Response: " + responseType.getTransactionId());
            System.out.println("Response: " + responseType.getStatus());
            System.out.println("Response: " + responseType.getStatusDetail());

            GetStatusRequest getStatusRequest = new GetStatusRequest(testEndpoint, securityToken, transactionId);
            responseType = getStatusRequest.execute();
            System.out.println("Response: " + responseType.getTransactionId());
            System.out.println("Response: " + responseType.getStatus());
            System.out.println("Response: " + responseType.getStatusDetail());

            // loop until our request completed or fails
            String status = null;
            while(status == null || (!status.equals("COMPLETED") && !status.equals("FAILED"))) {

                System.out.println("Sleeping for 10 secounds...");
                Thread.sleep(10000);

                getStatusRequest = new GetStatusRequest(testEndpoint, securityToken, transactionId);
                responseType = getStatusRequest.execute();
                status = responseType.getStatus().toString();
                System.out.println("Response: " + responseType.getTransactionId());
                System.out.println("Response: " + responseType.getStatus());
                System.out.println("Response: " + responseType.getStatusDetail());
            }
        } catch(NodeFaultMessage exception) {
            System.out.println("CDX Node Fault Message: " + exception.getFaultInfo().getDescription());
        } catch(InterruptedException exception) {
            // do nothing
        }
    }
}
