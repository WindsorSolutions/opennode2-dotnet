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

namespace Windsor.Commons.Logging
{
    /// <summary>
    /// Factory for some additional logging functionality from ILogEx.
    /// </summary>
    public static class LogManagerEx
    {
        public static ILogEx GetLogger(MethodBase declaringMethod)
        {
            return new DefaultLoggerEx(declaringMethod.DeclaringType.FullName);
        }
        public static ILogEx GetLogger(Type declaringType)
        {
            return new DefaultLoggerEx(declaringType.FullName);
        }
        public static ILogEx GetLogger(string loggerName)
        {
            return new DefaultLoggerEx(loggerName);
        }
    }

    /// <summary>
    /// Interface for additional logging functionality beyond the ILog interface.
    /// </summary>
    public interface ILogEx : ILog
    {
        string DebugArguments(string message, params object[] args);
        string DebugEnter(MethodBase methodBase, params object[] values);
        void AppendMethodEnterString(ref StringBuilder sb, MethodBase methodBase, params object[] values);
        void AppendMethodErrorString(ref StringBuilder sb, MethodBase methodBase, Exception exception);
        void AppendMethodReturnValueString(ref StringBuilder sb, MethodBase methodBase, object returnValue);
        void Debug(string format, params Object[] args);
        void Debug(string format, Exception exception, params Object[] args);
        void Error(string format, params Object[] args);
        void Error(string format, Exception exception, params Object[] args);
        void Fatal(string format, params Object[] args);
        void Fatal(string format, Exception exception, params Object[] args);
        void Info(string format, params Object[] args);
        void Info(string format, Exception exception, params Object[] args);
        void Trace(string format, params Object[] args);
        void Trace(string format, Exception exception, params Object[] args);
        void Warn(string format, params Object[] args);
        void Warn(string format, Exception exception, params Object[] args);
    }

    /// <summary>
    /// Implementation for additional logging functionality beyond the ILog interface.
    /// </summary>
    internal class DefaultLoggerEx : ILogEx
    {

        private ILog _logger;

        public DefaultLoggerEx(Type type)
        {
            _logger = LogManager.GetLogger(type);
        }
        public DefaultLoggerEx(string name)
        {
            _logger = LogManager.GetLogger(name);
        }
        public bool IsDebugEnabled
        {
            get { return _logger.IsDebugEnabled; }
        }
        public bool IsErrorEnabled
        {
            get { return _logger.IsErrorEnabled; }
        }
        public bool IsFatalEnabled
        {
            get { return _logger.IsFatalEnabled; }
        }
        public bool IsInfoEnabled
        {
            get { return _logger.IsInfoEnabled; }
        }
        public bool IsTraceEnabled
        {
            get { return _logger.IsTraceEnabled; }
        }
        public bool IsWarnEnabled
        {
            get { return _logger.IsWarnEnabled; }
        }
        public string DebugArguments(string message, params object[] args)
        {
            if (IsDebugEnabled)
            {
                string result = ConstructMessageWithArguments(message, args);
                _logger.Debug(result);
                return result;
            }
            return string.Empty;
        }
        public string DebugEnter(MethodBase methodBase, params object[] values)
        {
            if (IsDebugEnabled)
            {
                StringBuilder sb = null;
                AppendMethodEnterString(ref sb, methodBase, values);
                string message = sb.ToString();
                try
                {
                    _logger.Debug(message);
                }
                catch (Exception)
                {
                }
                return message;
            }
            return string.Empty;
        }

        public void AppendMethodEnterString(ref StringBuilder sb, MethodBase methodBase, params object[] values)
        {
            if (sb == null) sb = new StringBuilder();
            try
            {
                int maxOututLength = sb.Length + 8192;
                if (sb.Length > 0)
                {
                    sb.AppendLine();
                }
                sb.Append(methodBase.Name + "(");
                ParameterInfo[] parameters = methodBase.GetParameters();
                if (!CollectionUtils.IsNullOrEmpty(parameters))
                {
                    int numValues = (values == null) ? 0 : values.Length;
                    int count = Math.Min(numValues, parameters.Length);
                    for (int i = 0; i < count; ++i)
                    {
                        if (i > 0)
                        {
                            sb.Append(", ");
                        }
                        ParameterInfo parameter = parameters[i];
                        object value = (values != null) && (values.Length > i) ? values[i] : null;
                        if (parameter.IsOut)
                        {
                            sb.AppendFormat("{0}=[out]", (parameter == null) ? string.Empty : parameter.Name);
                            // Can't show out parameters
                        }
                        else
                        {
                            sb.AppendFormat("{0}=", (parameter == null) ? string.Empty : parameter.Name);
                            AppendObjectString(sb, value, maxOututLength);
                            if (sb.Length >= maxOututLength)
                            {
                                break;
                            }
                        }
                    }
                }
                sb.Append(")");
            }
            catch (Exception e)
            {
                try
                {
                    sb.Append("EXCEPTION: " + e.Message);
                }
                catch (Exception)
                {
                }
            }
        }
        public void AppendMethodReturnValueString(ref StringBuilder sb, MethodBase methodBase, object returnValue)
        {
            if (sb == null) sb = new StringBuilder();
            try
            {
                int maxOututLength = sb.Length + 8192;
                if (sb.Length > 0)
                {
                    sb.AppendLine();
                }
                if (returnValue != null)
                {
                    sb.AppendFormat(" RETURN ({0}): ", returnValue.GetType().FullName);
                }
                else
                {
                    sb.Append(" RETURN: ");
                }
                AppendObjectString(sb, returnValue, maxOututLength);
            }
            catch (Exception e)
            {
                try
                {
                    sb.Append("EXCEPTION: " + e.Message);
                }
                catch (Exception)
                {
                }
            }
        }
        public void AppendMethodErrorString(ref StringBuilder sb, MethodBase methodBase, Exception exception)
        {
            if (sb == null) sb = new StringBuilder();
            try
            {
                int maxOututLength = sb.Length + 8192;
                if (sb.Length > 0)
                {
                    sb.AppendLine();
                }
                sb.Append(methodBase.Name + " ERROR: ");
                sb.Append(ExceptionUtils.ToLongString(exception));
                if (sb.Length > maxOututLength)
                {
                    sb.Remove(maxOututLength, sb.Length - maxOututLength);
                    sb.Append(" ....");
                }
            }
            catch (Exception e)
            {
                try
                {
                    sb.Append("EXCEPTION: " + e.Message);
                }
                catch (Exception)
                {
                }
            }
        }
        private void AppendObjectString(StringBuilder sb, object value, int maxOututLength)
        {
            try
            {
                if (value is ICollection)
                {
                    ReflectionUtils.AppendCollectionString((ICollection)value, maxOututLength, sb);
                }
                else if (value is Delegate)
                {
                    sb.AppendFormat("Delegate={0}", ((Delegate)value).Method.Name);
                }
                else
                {
                    sb.AppendFormat("{0}", (value == null) ? "null" : value);
                }
                if (sb.Length > maxOututLength)
                {
                    sb.Remove(maxOututLength, sb.Length - maxOututLength);
                    sb.Append(" ....");
                }
            }
            catch (Exception)
            {
            }
        }
        public void Debug(object message)
        {
            _logger.Debug(message);
        }
        public void Debug(object message, Exception exception)
        {
            _logger.Debug(message, exception);
        }
        public void Error(object message)
        {
            _logger.Error(message);
        }
        public void Error(object message, Exception exception)
        {
            _logger.Error(message, exception);
        }
        public void Fatal(object message)
        {
            _logger.Fatal(message);
        }
        public void Fatal(object message, Exception exception)
        {
            _logger.Fatal(message, exception);
        }
        public void Info(object message)
        {
            _logger.Info(message);
        }
        public void Info(object message, Exception exception)
        {
            _logger.Info(message, exception);
        }
        public void Trace(object message)
        {
            _logger.Trace(message);
        }
        public void Trace(object message, Exception exception)
        {
            _logger.Trace(message, exception);
        }
        public void Warn(object message)
        {
            _logger.Warn(message);
        }
        public void Warn(object message, Exception exception)
        {
            _logger.Warn(message, exception);
        }
        public void Debug(string format, params Object[] args)
        {
            _logger.Debug(Format(format, args));
        }
        public void Debug(string format, Exception exception, params Object[] args)
        {
            _logger.Debug(Format(format, args), exception);
        }
        public void Error(string format, params Object[] args)
        {
            _logger.Error(Format(format, args));
        }
        public void Error(string format, Exception exception, params Object[] args)
        {
            _logger.Error(Format(format, args), exception);
        }
        public void Fatal(string format, params Object[] args)
        {
            _logger.Fatal(Format(format, args));
        }
        public void Fatal(string format, Exception exception, params Object[] args)
        {
            _logger.Fatal(Format(format, args), exception);
        }
        public void Info(string format, params Object[] args)
        {
            _logger.Info(Format(format, args));
        }
        public void Info(string format, Exception exception, params Object[] args)
        {
            _logger.Info(Format(format, args), exception);
        }
        public void Trace(string format, params Object[] args)
        {
            _logger.Trace(Format(format, args));
        }
        public void Trace(string format, Exception exception, params Object[] args)
        {
            _logger.Trace(Format(format, args), exception);
        }
        public void Warn(string format, params Object[] args)
        {
            _logger.Warn(Format(format, args));
        }
        public void Warn(string format, Exception exception, params Object[] args)
        {
            _logger.Warn(Format(format, args), exception);
        }

        /// <summary>
        /// Logger
        /// </summary>
        public ILog Logger
        {
            get { return _logger; }
            set { _logger = value; }
        }

        /// <summary>
        /// Format
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private string Format(string format, params Object[] args)
        {
            if (CollectionUtils.IsNullOrEmpty(args))
            {
                return format;
            }
            else
            {
                try
                {
                    return string.Format(format, args);
                }
                catch (Exception)
                {
                    return string.Empty;
                }
            }
        }

        /// <summary>
        /// ConstructMessageWithArguments
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private string ConstructMessageWithArguments(string message, params Object[] args)
        {
            try
            {
                if ((args != null) && (args.Length > 0))
                {
                    StringBuilder sb = new StringBuilder(message);
                    sb.Append(":");
                    for (int i = 0; i < args.Length - 1; i += 2)
                    {
                        object value = args[i + 1];
                        ICollection collection = value as ICollection;
                        if (collection != null)
                        {
                            value = collection.Count.ToString() + " items";
                        }
                        sb.AppendFormat(" {0}={1}", args[i], value);
                    }
                    return sb.ToString();
                }
                else
                {
                    return message;
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
    public interface ILoggerBase
    {
        ILogEx LOG { get; }
    }
    public class LoggerBase : ILoggerBase
    {
        public readonly ILogEx _logger;
        public LoggerBase()
        {
            _logger = LogManagerEx.GetLogger(this.GetType());
        }
        public ILogEx LOG
        {
            get { return _logger; }
        }
    }
    public abstract class DisposableLoggerBase : DisposableBase, ILoggerBase
    {
        public readonly ILogEx _logger;
        protected DisposableLoggerBase()
        {
            _logger = LogManagerEx.GetLogger(this.GetType());
        }
        public ILogEx LOG
        {
            get { return _logger; }
        }
    }
}

