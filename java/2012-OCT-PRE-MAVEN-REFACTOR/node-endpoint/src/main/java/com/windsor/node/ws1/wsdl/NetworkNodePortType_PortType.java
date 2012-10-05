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

/**
 * NetworkNodePortType_PortType.java
 *
 * This file was auto-generated from WSDL
 * by the Apache Axis 1.3 Oct 05, 2005 (05:23:37 EDT) WSDL2Java emitter.
 */

package com.windsor.node.ws1.wsdl;

public interface NetworkNodePortType_PortType extends java.rmi.Remote {

	/**
	 * User authentication method, must be called initially
	 */
	public java.lang.String authenticate(java.lang.String userId,
			java.lang.String credential, java.lang.String authenticationMethod)
			throws java.rmi.RemoteException;

	/**
	 * Submit one or more documents to the node.
	 */
	public java.lang.String submit(java.lang.String securityToken,
			java.lang.String transactionId, java.lang.String dataflow,
			NodeDocument[] documents)
			throws java.rmi.RemoteException;

	/**
	 * Check the status of a transaction
	 */
	public java.lang.String getStatus(java.lang.String securityToken,
			java.lang.String transactionId) throws java.rmi.RemoteException;

	/**
	 * Notify document availability, network events, submission statuses
	 */
	public java.lang.String notify(java.lang.String securityToken,
			java.lang.String nodeAddress, java.lang.String dataflow,
			NodeDocument[] documents)
			throws java.rmi.RemoteException;

	/**
	 * Download one or more documents from the node
	 */
	public void download(java.lang.String securityToken,
			java.lang.String transactionId, java.lang.String dataflow,
			ArrayofDocHolder documents)
			throws java.rmi.RemoteException;

	/**
	 * Execute an SQL query
	 */
	public java.lang.String query(java.lang.String securityToken,
			java.lang.String request, java.math.BigInteger rowId,
			java.math.BigInteger maxRows, java.lang.String[] parameters)
			throws java.rmi.RemoteException;

	/**
	 * Solicit an SQL query
	 */
	public java.lang.String solicit(java.lang.String securityToken,
			java.lang.String returnURL, java.lang.String request,
			java.lang.String[] parameters) throws java.rmi.RemoteException;

	/**
	 * Execute an SQL statement (DML)
	 */
	public java.lang.String execute(java.lang.String securityToken,
			java.lang.String request, java.lang.String[] parameters)
			throws java.rmi.RemoteException;

	/**
	 * Check the status of the service
	 */
	public java.lang.String nodePing(java.lang.String hello)
			throws java.rmi.RemoteException;

	/**
	 * Query services offered by the node
	 */
	public java.lang.String[] getServices(java.lang.String securityToken,
			java.lang.String serviceType) throws java.rmi.RemoteException;
}