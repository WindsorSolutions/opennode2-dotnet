package com.windsor.node.plugin.icisnpdes40.submission.exception;

import com.windsor.node.common.domain.PartnerIdentity;

/**
 * Thrown when a {@link PartnerIdentity} cannot be found in the Node
 * metadata store.
 */
public class PartnerIdentityNotFoundException extends Exception {
   
   private static final long serialVersionUID = 1L;

   public PartnerIdentityNotFoundException(String msg) {
       super(msg);
   }
}