package com.windsor.node.plugin.icisnpdes40.submission;

import java.lang.reflect.Method;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import javax.persistence.EntityManager;

import com.windsor.node.plugin.icisnpdes40.dao.PayloadOperationDao;
import com.windsor.node.plugin.icisnpdes40.dao.jdbc.PayloadOperationDaoJdbc;
import com.windsor.node.plugin.icisnpdes40.domain.PayloadOperation;
import com.windsor.node.plugin.icisnpdes40.generated.BasicPermitData;
import com.windsor.node.plugin.icisnpdes40.generated.LimitSetData;
import com.windsor.node.plugin.icisnpdes40.generated.ObjectFactory;
import com.windsor.node.plugin.icisnpdes40.generated.OperationType;
import com.windsor.node.plugin.icisnpdes40.generated.PayloadData;
import com.windsor.node.plugin.icisnpdes40.generated.PermittedFeatureData;
import com.windsor.node.plugin.icisnpdes40.generated.TransactionHeader;
import com.windsor.node.plugin.icisnpdes40.generated.TransactionType;

public class PerformICISSubmission extends AbstractIcisNpdesSubmission {

    /**
     * Returns a {@link List} of {@link PayloadData} objects. The list of
     * elements is determined by looking at the ICS_PAYLOAD table. Each record
     * in the table has the type of submission operation to complete. The name
     * of the operation is used to dynamically invoke a setter on
     * {@link PayloadData} instance before adding it to list.
     * 
     */
    @Override
    public List<PayloadData> createAllPayloads(EntityManager em) {

        log("Creating new list for <Payload>", "");

        List<PayloadData> allPayloads = new ArrayList<PayloadData>();

        /**
         * Instantiate a new DAO to lookup ICS_PAYLOAD records.
         */
        PayloadOperationDao payloadOperationDao = new PayloadOperationDaoJdbc(getDataSource());
        
        List<PayloadOperation> dbConfiguredOperationsToSubmit = payloadOperationDao.findPayloadsToSubmit();
                
        log("Found {} operations to submit to ICIS.", dbConfiguredOperationsToSubmit.size());
        
        /**
         * Iterate over the list ICS_PAYLOAD records.
         */
        for (PayloadOperation op : dbConfiguredOperationsToSubmit) {

            log("...Starting the {} operation", op.getOperationType());
            
            PayloadData payloadData = new ObjectFactory().createPayloadData();

            /**
             * Look up the @Entity class that holds the payload operation data.
             * The class definition will drive the rest of the flow in this
             * loop.
             */
            Class<?> klass = payloadOperationTypeJpaEntityMap().get(op.getOperationType());
            
            if (klass != null ) {
                
                String klassName = klass.getSimpleName();
                
                log("Found the {} class for operation {}", klassName, op.getOperationType());

                /**
                 * Use the class name to create a JPQL select statement and then
                 * get the results.
                 */
                final List<?> list = em.createQuery("select ls from "+klassName+" ls").getResultList();
                
                log("Found {} records in the database.", list.size());
                
                if (list.size() > 0 ) {

                    /**
                     * Set the type operation to send to ICIS. Only set if there are records for this operation.
                     */
                    payloadData.setOperation(op.getOperationType());
                    
                    /////
                    // Set a transaction header - temporary code
                    ////
                    TransactionHeader txHeader = new TransactionHeader();
                    txHeader.setTransactionTimestamp(new Date());
                    txHeader.setTransactionType(TransactionType.C);
                    
                    try {
                        Method m = klass.getMethod("setTransactionHeader", TransactionHeader.class);
                        
                        for(Object o : list) {
                            m.invoke(o, txHeader);
                        }
                        
                    } catch (Exception e1) {
                        e1.printStackTrace();
                    }
                    
                    String methodName = "set" + klassName;
                    
                    log("Searching for method {}", methodName);
                    
                    for(Method method : PayloadData.class.getMethods()) {
                        
                        log("Candidate method {}?", method.getName());
                                                
                        if (method.getName().equals(methodName)) {
                            
                            log("Found method and invoking it");
                            
                            try {
                                method.invoke(payloadData, list);
                            } catch (Exception e) {
                                error("Unable to invoke the method {}", method.getName());
                            }
                        }
                    }          
                    allPayloads.add(payloadData);
                }
            } else {
                log("!!! Did not find an @Entity class for {} operation.", op.getOperationType());
            }
        }
        return allPayloads;
    }

    /**
     * Returns a map of Classes keyed on {@link OperationType}. Used to look up
     * the class to hold the the payload data originating from the database and
     * then eventually serialized to XML via JAXB. The operation type is known
     * by a lookup to the ICIS_PAYLOAD table.
     * 
     * @return Map
     */
    private Map<OperationType, Class<?>> payloadOperationTypeJpaEntityMap() {
        Map<OperationType, Class<?>> map = new HashMap<OperationType, Class<?>>();
        map.put(OperationType.LIMIT_SET_SUBMISSION, LimitSetData.class);
        map.put(OperationType.PERMITTED_FEATURE_SUBMISSION, PermittedFeatureData.class);
        map.put(OperationType.BASIC_PERMIT_SUBMISSION, BasicPermitData.class);
        
        return map;
    }
    
    /**
     * A convenience debug method, implementation can be changed in one place.
     * 
     * @param format A formatted string, eg. log("Successfully found {}.", arg)
     * @param args The arguments for the string message
     */
    private void log(String format, Object... args) {
        if (logger.isDebugEnabled()) {
            logger.debug(format, args);
        }
    }
        
    /**
     * A convenience error method, implementation can be changed in one place.
     * 
     * @param format A formatted string, eg. log("Successfully found {}.", arg)
     * @param args The arguments for the string message
     */
    private void error(String format, Object... args) {
        logger.error(format, args);    
    }
}
