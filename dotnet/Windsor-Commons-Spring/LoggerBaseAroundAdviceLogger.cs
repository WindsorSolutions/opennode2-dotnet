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
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;
using System.Collections.Specialized;
using Common.Logging;
using System.Reflection;
using System.Xml;
using AopAlliance.Intercept;
using Spring.Aop.Framework;
using Windsor.Commons.Core;
using Common.Logging.Log4Net;
using Windsor.Commons.Logging;

namespace Windsor.Commons.Spring
{
    /// <summary>
    /// Class for AOP logging around advice for classes that implement Windsor.Commons.Logging.ILoggerBase.  This class is
    /// injected into the process using normal AOP injection methods.
    /// </summary>
    public class LoggerBaseAroundAdviceLogger : IMethodInterceptor
    {
        public LoggerBaseAroundAdviceLogger()
        {
        }
        public object Invoke(IMethodInvocation invocation)
        {
            ILoggerBase logger = invocation.Target as ILoggerBase;
            if (logger != null)
            {
                StringBuilder sb = null;
                if (logger.LOG.IsDebugEnabled)
                {
                    logger.LOG.AppendMethodEnterString(ref sb, invocation.Method, invocation.Arguments);
                    logger.LOG.Debug("$$ METHOD_ENTER: " + sb.ToString());
                }
                try
                {
                    // INVOKE:
                    object returnValue = invocation.Proceed();

                    if (logger.LOG.IsDebugEnabled && (invocation.Method.ReturnParameter != null) &&
                        (invocation.Method.ReturnParameter.ParameterType != typeof(void)) )
                    {
                        if (sb != null) sb.Length = 0;
                        logger.LOG.AppendMethodReturnValueString(ref sb, invocation.Method, returnValue);
                        logger.LOG.Debug("$$ METHOD_EXIT: " + sb.ToString());
                    }
                    return returnValue;
                }
                catch (Exception e)
                {
                    if (logger.LOG.IsErrorEnabled)
                    {
                        if (sb != null) sb.Length = 0;
                        logger.LOG.AppendMethodErrorString(ref sb, invocation.Method, e);
                        logger.LOG.Error("$$ METHOD_ERROR: " + sb.ToString());
                    }
                    throw;
                }
            }
            else
            {
                return invocation.Proceed();
            }
        }
    }
}

