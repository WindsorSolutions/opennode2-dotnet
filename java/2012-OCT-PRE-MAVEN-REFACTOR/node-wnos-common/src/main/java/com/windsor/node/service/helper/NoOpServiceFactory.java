package com.windsor.node.service.helper;

/**
 * A no-op implementation, on behalf of the ENDS plugin, which needs to act more
 * like the Node itself than a plugin proper.
 */
public class NoOpServiceFactory implements ServiceFactory {

    /**
     * Returns <code>new Object();</code>.
     * 
     * @see com.windsor.node.service.helper.ServiceFactory#makeService(java.lang.Class)
     */
    public Object makeService(Class serviceType) {
        return new Object();
    }

}
