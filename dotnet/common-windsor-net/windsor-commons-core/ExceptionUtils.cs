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
using System.Collections;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Runtime.Serialization;
using Windsor.Commons.Core;

namespace Windsor.Commons.Core
{
    /// <summary>
    /// Basic helper functions for dealing with exceptions.
    /// </summary>
    public static class ExceptionUtils
    {

        /// <summary>
        /// Returns a long string describing an exception, including information about
        /// any inner exceptions.
        /// </summary>
        public static string ToLongString(Exception inException)
        {
            return ToExceptionString(inException, true);
        }
        /// <summary>
        /// Returns a short string describing an exception, including information about
        /// any inner exceptions.
        /// </summary>
        public static string ToShortString(Exception inException)
        {
            return ToExceptionString(inException, false);
        }
        /// <summary>
        /// Returns the innermost exception's message.
        /// </summary>
        public static string GetDeepExceptionMessage(Exception inException)
        {
            Exception nextException = inException;
            while (nextException != null)
            {
                if (nextException.InnerException != null)
                {
                    nextException = nextException.InnerException;
                }
                else
                {
                    break;
                }
            }
            if (nextException == null)
            {
                return null;
            }
            return string.Format("Exception: {0}, Message: {1}", nextException.GetType().Name,
                                 nextException.Message);
        }
        public static string GetDeepExceptionMessageOnly(Exception inException)
        {
            Exception nextException = inException;
            while (nextException != null)
            {
                if (nextException.InnerException != null)
                {
                    nextException = nextException.InnerException;
                }
                else
                {
                    break;
                }
            }
            if (nextException == null)
            {
                return null;
            }
            return nextException.Message;
        }
        public static void ThrowIfFalse(bool condition, string conditionName)
        {
            if (!condition)
            {
                throw new InvalidOperationException(conditionName);
            }
        }
        public static void ThrowIfTrue(bool condition, string conditionName)
        {
            if (condition)
            {
                throw new InvalidOperationException(conditionName);
            }
        }
        public static T ThrowIfNull<T>(T parameter, string paramName) where T : class
        {
            if (parameter == null)
            {
                throw new NullReferenceException(paramName + " cannot be null");
            }
            return parameter;
        }
        public static T ThrowIfNull<T>(T parameter) where T : class
        {
            if (parameter == null)
            {
                throw new NullReferenceException("The parameter cannot be null");
            }
            return parameter;
        }
        public static string ThrowIfEmptyString(string parameter)
        {
            if (string.IsNullOrEmpty(parameter))
            {
                throw new NullReferenceException("The parameter cannot be an empty string");
            }
            return parameter;
        }
        public static string ThrowIfEmptyString(string parameter, string paramName)
        {
            if (string.IsNullOrEmpty(parameter))
            {
                throw new NullReferenceException(paramName + " cannot be an empty string");
            }
            return parameter;
        }
        public static string ThrowIfNotEmptyString(string parameter, string paramName)
        {
            if (!string.IsNullOrEmpty(parameter))
            {
                throw new NullReferenceException(paramName + " must be an empty string");
            }
            return parameter;
        }
        public static string ThrowIfDirectoryNotFound(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                throw new DirectoryNotFoundException(string.Format("The directory \"{0}\" does not exist",
                                                                   folderPath));
            }
            return folderPath;
        }
        public static void ThrowIfFileNotFound(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new DirectoryNotFoundException(string.Format("The file \"{0}\" does not exist",
                                                                   filePath));
            }
        }
        public static void ThrowIfZeroOrNegative(int parameter, string paramName)
        {
            if (parameter < 1)
            {
                throw new DirectoryNotFoundException(string.Format("The parameter \"{0}\" must be greater than 0",
                                                                   paramName));
            }
        }
        public static T Get<T>(string format, params object[] args) where T : Exception
        {
            DebugUtils.CheckDebuggerBreak();
            T exception = (T)global::System.Activator.CreateInstance(typeof(T), string.Format(format, args));
            return exception;
        }
        public static void Throw<T>(string format, params object[] args) where T : Exception
        {
            DebugUtils.CheckDebuggerBreak();
            T exception = (T)global::System.Activator.CreateInstance(typeof(T), string.Format(format, args));
            throw exception;
        }
        public static void Throw<T>(Exception innerException, string format, params object[] args) where T : Exception
        {
            DebugUtils.CheckDebuggerBreak();
            T exception = (T)global::System.Activator.CreateInstance(typeof(T), string.Format(format, args), innerException);
            throw exception;
        }
        private static string ToExceptionString(Exception inException, bool includeAll)
        {
            StringBuilder sb = new StringBuilder();
            if (inException != null)
            {
                AppendExceptionString(inException, string.Empty, sb, includeAll);
                if (inException.InnerException != null)
                {
                    Exception curException = inException.InnerException;
                    string prefix = "\t";
                    do
                    {
                        sb.AppendLine(" ");
                        sb.AppendLine(" ");
                        sb.AppendLine(prefix + "INNER EXCEPTION: ");
                        sb.AppendLine(" ");
                        AppendExceptionString(curException, prefix, sb, includeAll);
                        curException = curException.InnerException;
                        prefix += "\t";
                    } while (curException != null);
                }
            }
            return sb.ToString();
        }
        private static void AppendExceptionString(Exception inException, string inPrefix,
                                                  StringBuilder ioSB, bool includeAll)
        {

            if (includeAll)
            {
                ioSB.Append(inPrefix);
                ioSB.AppendFormat("Type: {0}", inException.GetType().ToString());
                ioSB.AppendLine(" ");
                ioSB.Append(inPrefix);
                ioSB.AppendFormat("Message: {0}", inException.Message);
                ioSB.AppendLine(" ");
                ioSB.Append(inPrefix);
                ioSB.AppendFormat("StackTrace: {0}", (inException.StackTrace != null) ?
                                  inException.StackTrace.ToString() : "");
            }
            else
            {
                ioSB.Append(inPrefix);
                ioSB.AppendFormat("Message: {0}", inException.Message);
            }
        }
    }

    /// <summary>
    /// This exception should be thrown when a field for a class has not been
    /// initialized correctly.
    /// </summary>
    [Serializable]
    public class FieldNotInitializedException : ArgumentException
    {
        public FieldNotInitializedException()
        {
        }
        public FieldNotInitializedException(string message) :
            base(message)
        {
        }
        public FieldNotInitializedException(string message, string paramName) :
            base(message, paramName)
        {
        }
        public FieldNotInitializedException(string message, Exception innerException) :
            base(message, innerException)
        {
        }
        public FieldNotInitializedException(string message, string paramName,
                                               Exception innerException) :
            base(message, paramName, innerException)
        {
        }

        protected FieldNotInitializedException(SerializationInfo info,
                                                  StreamingContext context) :
            base(info, context)
        {
        }
        public static void ThrowIfNull(object owner, object field,
                                       string fieldName, bool doDebuggerBreak)
        {
            if (field == null)
            {
                DebugUtils.CheckDebuggerBreak(doDebuggerBreak);
                throw new FieldNotInitializedException("The field \"" +
                                                       owner.GetType().FullName +
                                                       "." + fieldName +
                                                       "\" is null.", fieldName);
            }
        }
        public static void ThrowIfNull(object owner, object field,
                                       string fieldName)
        {
            ThrowIfNull(owner, field, fieldName, true);
        }
        public static void ThrowIfNull<T>(object owner, ref T field) where T : class
        {
            if (field == null)
            {
                ThrowIfNull(owner, field, GetPropertyName(owner, ref field));
            }
        }
        public static void ThrowIfRelativeFileMissing(string fileRelativePath)
        {

            ThrowIfRelativeFileMissing(fileRelativePath, true);
        }
        public static void ThrowIfDirectoryDoesNotExist(string dirPath)
        {

            if (!Directory.Exists(dirPath))
            {
                DebugUtils.CheckDebuggerBreak();
                throw new DirectoryNotFoundException(string.Format("Directory not found: \"{0}\"", dirPath));
            }
        }
        public static void ThrowIfRelativeFileMissing(string fileRelativePath,
                                                      bool doDebuggerBreak)
        {
            string path = FileUtils.PathFromExecutingAssemblyRelativePath(fileRelativePath);
            if (!File.Exists(path))
            {
                DebugUtils.CheckDebuggerBreak(doDebuggerBreak);
                throw new FileNotFoundException("File is missing", path);
            }
        }
        public static void ThrowIfEmptyString(object owner, string field,
                                              string fieldName, bool doDebuggerBreak)
        {
            if (string.IsNullOrEmpty(field))
            {
                DebugUtils.CheckDebuggerBreak(doDebuggerBreak);
                throw new FieldNotInitializedException("The string field \"" +
                                                       owner.GetType().FullName +
                                                       "." + fieldName +
                                                       "\" is null or empty.", fieldName);
            }
        }
        public static void ThrowIfEmptyString(object owner, string field,
                                              string fieldName)
        {
            ThrowIfNull(owner, field, fieldName, true);
        }
        public static void ThrowIfEmptyString(object owner, ref string field)
        {
            if (string.IsNullOrEmpty(field))
            {
                ThrowIfEmptyString(owner, field, GetPropertyName(owner, ref field));
            }
        }
        public static void ThrowIfZero(object owner, ref int field)
        {
            if (field == 0)
            {
                ThrowIfNull(owner, field, GetPropertyName(owner, ref field));
            }
        }
        private static string GetPropertyName<T>(object owner, ref T field)
        {
            string name = string.Empty;
            IList<FieldInfo> fields =
                ReflectionUtils.GetAllPublicAndPrivateInstanceFields(owner.GetType());
            foreach (FieldInfo curField in fields)
            {
                if (object.ReferenceEquals(curField.GetValue(owner), field))
                {
                    name = curField.Name;
                }
            }
            return name;
        }
    }
    [Serializable]
    public class FatalAppException : ApplicationException
    {
        public FatalAppException()
        {
        }
        public FatalAppException(string message) :
            base(message)
        {
        }
        public FatalAppException(string message, Exception innerException) :
            base(message, innerException)
        {
        }
        protected FatalAppException(SerializationInfo info,
                                                  StreamingContext context) :
            base(info, context)
        {
        }
    }
    [Serializable]
    public class ArgException : ArgumentException
    {
        public ArgException(string format, params object[] args) :
            base(string.Format(format, args))
        {
            DebugUtils.CheckDebuggerBreak();
        }
        public ArgException(Exception innerException, string format, params object[] args) :
            base(string.Format(format, args), innerException)
        {
            DebugUtils.CheckDebuggerBreak();
        }
        protected ArgException(SerializationInfo info, StreamingContext context) :
            base(info, context)
        {
        }
    }
}
