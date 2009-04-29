#region License
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
#endregion

using System;
using Windsor.Node.Plugin.Interface30;
using System.Collections;


public class NodeService : Windsor.Node.Plugin.Interface30.INodeService
{
	private string _serviceName;
	private string _schemaUrl;
	private ArrayList _serviceParams = new ArrayList();
	private bool _supportsQuery;
	private bool _supportsSolicit;

	public NodeService(string serviceName, string schemaUrl, bool supportsQuery, bool supportsSolicit)
	{
		this._serviceName = serviceName;
		this._schemaUrl = schemaUrl;
		this._supportsQuery = supportsQuery;
		this._supportsSolicit = supportsSolicit;
	}

	public void AddParameter(bool isRequired, string paramName, string paramType, string regExpPat)
	{
		_serviceParams.Add(new ServiceParameter(isRequired, paramName, paramType, regExpPat));
	}

	public string DataServiceName 
	{
		get 
		{
			return this._serviceName;
		}
	}

	public string SchemaUrl 
	{
		get 
		{
			return this._schemaUrl;
		}
	}

	public INodeServiceParameter[] ServiceParameters 
	{
		get 
		{
			return ((ServiceParameter[])(_serviceParams.ToArray(typeof(ServiceParameter))));
		}
	}

	public bool SupportsQuery 
	{
		get 
		{
			return this._supportsQuery;
		}
	}

	public bool SupportsSolicit 
	{
		get 
		{
			return this._supportsSolicit;
		}
	}
}
public class ServiceParameter : Windsor.Node.Plugin.Interface30.INodeServiceParameter
{
	private bool _isRequired;
	private string _paramName;
	private Type _paramType;
	private string _regExpPat;

	public ServiceParameter(bool isRequired, string paramName, string paramType, string regExpPat)
	{
		this._isRequired = isRequired;
		this._paramName = paramName;
		this._paramType = Type.GetType(paramType, true, true);
		this._regExpPat = regExpPat;
	}

	public bool IsRequired 
	{
		get 
		{
			return _isRequired;
		}
	}

	public string ParameterName 
	{
		get 
		{
			return _paramName;
		}
	}

	public System.Type ParameterType 
	{
		get 
		{
			return _paramType;
		}
	}

	public string RegExPattern 
	{
		get 
		{
			return _regExpPat;
		}
	}
}