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

﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Collections;
using System.Text;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.IO;
using System.Runtime.Remoting;
using Spring.Context;
using Spring.Context.Support;
using Spring.Objects.Factory;
using Spring.Data.Common;
using Common.Logging;
using Windsor.Commons.Logging;
using Windsor.Commons.Spring;
using Windsor.Commons.Core;
using System.Data;
using Commons.Collections;
using NVelocity;
using NVelocity.App;
using NVelocity.Context;
using System.Xml;

namespace Windsor.Commons.Velocity
{
    /// <summary>
    /// VelocityHelper provides some rudemantary Velocity merging functionality
    /// </summary>
    public class VelocityHelper : Windsor.Commons.Velocity.IVelocityHelper
    {
        private static readonly ILogEx _logger = LogManagerEx.GetLogger(typeof(VelocityHelper));

        private readonly VelocityEngine _engine;


        /// <summary>
        /// Default constructor of the VelocityHelper
        /// </summary>
        public VelocityHelper() : this(new VelocityEngine(), new ExtendedProperties()) { }


        /// <summary>
        /// Default constructor of the VelocityHelper
        /// </summary>
        public VelocityHelper(ExtendedProperties properties) : this(new VelocityEngine(), properties) { }


        /// <summary>
        /// Construct VelocityHelper and initialize it with provided property file
        /// </summary>
        /// <param name="propertyFilePath">Path to the Velocity property file</param>
        public VelocityHelper(string propertyFilePath) : this(new VelocityEngine(), propertyFilePath) { }

        /// <summary>
        /// Constructs VelocityHelper with the provided engine and initilizes with the provided properties
        /// </summary>
        /// <param name="engine">Instance of the Velocity Engine</param>
        /// <param name="propertyFilePath">Path to the Velocity property file</param>
        public VelocityHelper(VelocityEngine engine, string propertyFilePath)
        {
            _engine = engine;
            if (File.Exists(propertyFilePath))
            {
                _engine.Init(propertyFilePath);
            }
        }


        /// <summary>
        /// Constructs VelocityHelper with the provided engine and properties
        /// </summary>
        /// <param name="engine">Instance of the Velocity Engine</param>
        /// <param name="props">Instance of the Velocity Properties</param>
        public VelocityHelper(VelocityEngine engine, ExtendedProperties props)
        {
            _engine = engine;

            if (props == null || props.Count == 0)
            {
                props = new ExtendedProperties();
                props.SetProperty("input.encoding", "UTF-8");
                props.SetProperty("output.encoding", "UTF-8");

                _engine.Init(props);
            }
            else
            {
                _engine.Init(props);
            }
        }


        public object Merge(string templatePath, IDaoTemplateHelper helper, string outputPath, NameValueCollection additionalArgs)
        {

            _logger.DebugEnter(MethodBase.GetCurrentMethod(), templatePath, helper, outputPath);

            if (helper == null)
            {
                throw new ApplicationException("null helper");
            }

            VelocityContext context = new VelocityContext();

            context.Put(helper.Name, helper);

            if (additionalArgs != null)
            {
                foreach (string key in additionalArgs.AllKeys)
                {
                    context.Put(key, additionalArgs[key]);
                }
            }

            Merge(templatePath, context, outputPath);

            _logger.Debug("Result: {0}", helper.GetResult());
            return helper.GetResult();
        }


        /// <summary>
        /// Merges provided Velocity template with a Dao Helper into a specified file
        /// </summary>
        /// <param name="templatePath">Path to the output file</param>
        /// <param name="helper">Instance of the Dao Helper</param>
        /// <param name="outputPath">If the output file already exists it will be overritten</param>
        /// <returns>Instance of the input object in case its state was modified by the template</returns>
        public object Merge(string templatePath, IDaoTemplateHelper helper, string outputPath)
        {

            _logger.DebugEnter(MethodBase.GetCurrentMethod(), templatePath, helper, outputPath);

            if (helper == null)
            {
                throw new ApplicationException("null helper");
            }

            VelocityContext context = new VelocityContext();

            context.Put(helper.Name, helper);

            Merge(templatePath, context, outputPath);

            _logger.Debug("Result: {0}", helper.GetResult());
            return helper.GetResult();
        }


        public object Merge(string templatePath, object item, TextWriter writer)
        {

            _logger.DebugEnter(MethodBase.GetCurrentMethod(), templatePath, item, writer);

            if (item == null)
            {
                throw new ApplicationException("null object");
            }

            String objectName = item.GetType().Name;
            _logger.Debug("Object: " + objectName);

            VelocityContext context = new VelocityContext();

            _logger.Debug("Name: {0} Value: {1}", objectName, item);
            context.Put(objectName, item);

            Merge(templatePath, context, writer);

            _logger.Debug("Result: {0}", item);
            return item;
        }


        /// <summary>
        /// Merges provided Velocity template with an object into a specified file
        /// </summary>
        /// <param name="templatePath">Fully qualified Velocity template file path</param>
        /// <param name="item">Instance of an object with public propeties that can be accessed by the template. It will be available to the template by its type name</param>
        /// <param name="outputPath">Path to the output file</param>
        /// <remarks>If the output file already exists it will be overritten</remarks>
        /// <returns>Instance of the input object in case its state was modified by the template</returns>
        public object Merge(string templatePath, object item, string outputPath)
        {

            _logger.DebugEnter(MethodBase.GetCurrentMethod(), templatePath, item, outputPath);

            if (item == null)
            {
                throw new ApplicationException("null object");
            }

            String objectName = item.GetType().Name;
            _logger.Debug("Object: " + objectName);

            VelocityContext context = new VelocityContext();

            _logger.Debug("Name: {0} Value: {1}", objectName, item);
            context.Put(objectName, item);

            Merge(templatePath, context, outputPath);

            _logger.Debug("Result: {0}", item);
            return item;
        }

        /// <summary>
        /// Merges provided Velocity template with a dictionary of kev/value arguments into a specified file
        /// </summary>
        /// <param name="templatePath">Fully qualified Velocity template file path</param>
        /// <param name="args">Key/Value arguments</param>
        /// <param name="outputPath">Path to the output file</param>
        /// <remarks>If the output file already exists it will be overritten</remarks>
        /// <returns>Ref to the input args in case its state was modified inside of the template</returns>
        public IDictionary<string, object> Merge(string templatePath, IDictionary<string, object> args, string outputPath)
        {

            _logger.DebugEnter(MethodBase.GetCurrentMethod(), templatePath, args, outputPath);

            if (!File.Exists(templatePath))
            {
                throw new IOException("template does not exists: " + templatePath);
            }

            VelocityContext context = new VelocityContext();

            if (args != null && args.Count > 0)
            {
                foreach (KeyValuePair<string, object> arg in args)
                {
                    _logger.Debug("Key: {0} Value: {1}", arg.Key, arg.Value);
                    context.Put(arg.Key, arg.Value);
                }
            }

            Merge(templatePath, context, outputPath);

            _logger.Debug("Result: {0}", args);
            return args;
        }


        /// <summary>
        /// Merges provided Velocity template with a dictionary of kev/value arguments into a specified file
        /// </summary>
        /// <param name="templatePath">Fully qualified Velocity template file path</param>
        /// <param name="arg">Populated DataSet</param>
        /// <param name="outputPath">Path to the output file</param>
        /// <remarks>If the output file already exists it will be overritten</remarks>
        public void Merge(string templatePath, DataSet arg, string outputPath)
        {

            _logger.DebugEnter(MethodBase.GetCurrentMethod(), templatePath, arg, outputPath);

            if (!File.Exists(templatePath))
            {
                throw new IOException("template does not exists: " + templatePath);
            }

            VelocityContext context = new VelocityContext();

            _logger.Debug("Name: {0} Value: {1}", arg.DataSetName, arg);
            context.Put(arg.DataSetName, arg);

            Merge(templatePath, context, outputPath);

        }



        private void Merge(string templatePath, VelocityContext context, string outputPath)
        {

            _logger.DebugEnter(MethodBase.GetCurrentMethod(), templatePath, context, outputPath);

            if (!File.Exists(templatePath))
            {
                throw new IOException("template does not exists: " + templatePath);
            }

            _logger.Debug("Getting template from: {0}", templatePath);
            Template template = _engine.GetTemplate(templatePath);
            _logger.Debug("Template: {0}", template);

            using (StreamWriter writer = new StreamWriter(outputPath, false, Encoding.UTF8))
            {
                template.Merge(context, writer);
            }

        }

        private void Merge(string templatePath, VelocityContext context, TextWriter writer)
        {

            _logger.DebugEnter(MethodBase.GetCurrentMethod(), templatePath, context, writer);

            if (writer == null)
            {
                throw new IOException("template does not exists: " + templatePath);
            }

            _logger.Debug("Getting template from: {0}", templatePath);
            Template template = _engine.GetTemplate(templatePath);
            _logger.Debug("Template: {0}", template);

            template.Merge(context, writer);

        }

    }
}
