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
using System.ComponentModel;
using System.Data;
using System.Text;
using Common.Logging;
using Windsor.Commons.Core;
using Windsor.Commons.Logging;
using System.IO;
using System.Net;
using Windsor.Commons.SchematronClient.Ws;
using Microsoft.Web.Services;
using Microsoft.Web.Services.Configuration;
using Microsoft.Web.Services.Dime;

namespace Windsor.Commons.SchematronClient
{

    public class ValidatorHelper : Windsor.Commons.SchematronClient.IValidatorHelper
    {

        public event EventHandler<ValidationEventArgs> OnValidationEvent;
        public event EventHandler<ValidationResultArgs> OnValidationSubmittedEvent;

        

        private static readonly ILogEx LOG = LogManagerEx.GetLogger(typeof(ValidatorHelper));


        private string _prodUrl = "https://cdxtools.epa.gov/xml/validatorEx.wsdl";
        private string _testUrl = "https://cdxtools.epa.gov/xml/validatorEx.wsdl";
        private DocumentType _documentType;
        private ValidatorEx _ws;
        private IWebProxy _proxy;


        public ValidatorHelper(DocumentType documentType)
        {
            _documentType = documentType;
        }



        private void Raise(string message, int percentDone)
        {
            if (OnValidationEvent != null)
            {
                OnValidationEvent(this, new ValidationEventArgs(message, percentDone));
            }
        }

        private void Init(bool isProduction)
        {
            LOG.Debug("ValidatorHelper");
            LOG.Debug("Prod: " + isProduction);
            LOG.Debug("Proxy: " + _proxy);

            Raise(String.Format("Configuring {0} Schematron client...", (isProduction) ? "production" : "test"), 5);

            ServicePointManager.MaxServicePointIdleTime = -1;
            ServicePointManager.ServerCertificateValidationCallback = ValidatorCertificatePolicy.RemoteCertificateValidationProc;

            _ws = new ValidatorEx(isProduction ? _prodUrl : _testUrl);
            _ws.AllowAutoRedirect = true;
            _ws.Timeout = 3000000;
            _ws.UseDefaultCredentials = true; 
            _ws.RequestSoapContext.Timestamp.Ttl = 0L;
            _ws.Timeout = -1;

            SoapContext context = _ws.RequestSoapContext;
            context.Timestamp.Ttl = 0;

            _ws.ValidateExCompleted += new ValidateExCompletedEventHandler(ValidateExCompleted);


            if (_proxy != null)
            {
                Raise("Configuring Http Proxy...", 10);
                LOG.Debug("Proxy: " + _proxy);
                _ws.Proxy = _proxy;
            }





            Raise("Schematron client configured", 20);

        }

        private void SetMustUnderstand()
        {
            SoapContext context = _ws.RequestSoapContext;
            context.Path.EncodedMustUnderstand = "false";
            //need to clean out attachments BEFORE EVERY CALL
            context.Attachments.Clear();
            //need to clean out CONTEXT BEFORE EVERY CALL
            context.Clear();
        }


        public void Validate(bool isProduction, ValidationRequestArgs args)
        {

            LOG.Debug("Validate: " + args);

            if (args == null)
            {
                throw new ArgumentNullException("Null SchematronValidationArgs");
            }


            if (!File.Exists(args.DocumentPath))
            {
                throw new IOException("Null DocumentPath");
            }

            if (Path.GetExtension(args.DocumentPath).ToUpper() != ".ZIP")
            {
                throw new ArgumentException("DocumentPath not Zip");
            }

            if (args.Credential == null || String.IsNullOrEmpty(args.Credential.UserName)
                || String.IsNullOrEmpty(args.Credential.Password))
            {
                throw new ArgumentNullException("Invalid Credential");
            }

            if (args.NotificationEmails == null || args.NotificationEmails.Length < 1)
            {
                throw new ArgumentNullException("One NotificationEmails required");
            }

            Init(isProduction);
            SetMustUnderstand();

            Raise("Validating arguments", 25);

            try
            {

                Raise("Submitting validation request", 30);


                SoapContext context = _ws.RequestSoapContext;

                DimeAttachment attachment = new DimeAttachment();
                attachment.TypeFormat = TypeFormatEnum.MediaType;
                attachment.Type = "application/octet-stream";
                attachment.Id = Guid.NewGuid().ToString();
                attachment.Stream = new MemoryStream(File.ReadAllBytes(args.DocumentPath));
                context.Attachments.Add(attachment);
 

                _ws.ValidateExAsync(args.Credential.UserName,
                args.Credential.Password,
                string.Empty,
                ValidationType.all,
                _documentType,
                new byte[] { 101, 101, 101 },
                DocumentFormat.zip,
                String.Join(";", args.NotificationEmails), args);

                Raise("Validation request submitted", 40);

            }
            catch (System.Web.Services.Protocols.SoapException sex)
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendFormat("{0}\n", sex.Message);

                if (sex.Detail != null)
                {
                    sb.AppendFormat("{0}\n", sex.Detail.InnerText);
                }
                else
                {
                    sb.AppendFormat("{0}\n", sex.InnerException);
                }

                throw new ApplicationException(sb.ToString(), sex);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ExceptionUtils.GetDeepExceptionMessage(ex));
            }

        }


        void ValidateExCompleted(object sender, ValidateExCompletedEventArgs e)
        {

            Raise("Parsing submission results...", 50);
            LOG.Debug("ValidateExCompleted: " + e);


            if (OnValidationSubmittedEvent != null)
            {

                if (e == null)
                {
                    OnValidationSubmittedEvent(this, new ValidationResultArgs(
                        new ApplicationException("Validation completed but no results were found")));
                }
                else if (e.Error != null)
                {
                    OnValidationSubmittedEvent(this, new ValidationResultArgs(
                        new ApplicationException("Validation error: " 
                            + ExceptionUtils.GetDeepExceptionMessage(e.Error), e.Error)));
                }
                else if (e.Result == null)
                {
                    OnValidationSubmittedEvent(this, new ValidationResultArgs(
                        new ApplicationException("Validation completed but no transaction Id")));
                }
                else
                {
                    OnValidationSubmittedEvent(this, 
                        new ValidationResultArgs(e.Result.transactionId, 
                            e.UserState as ValidationRequestArgs));
                }
            }
        }




        public ValidationReportResult GetReport(ValidationReportRequest request)
        {

            LOG.Debug("ValidationReportRequest: " + request);


            if (request == null)
            {
                throw new ArgumentNullException("Null ValidationReportRequest");
            }

            if (String.IsNullOrEmpty(request.TransactionId))
            {
                throw new ArgumentNullException("Null transactionId");
            }

            if (request.Credential == null)
            {
                throw new ArgumentNullException("Null Credential");
            }


            Raise("Submitting validationreport request...", 10);

            try
            {

                LOG.Debug("Getting report...");
                SetMustUnderstand();
                ValidationResult result = _ws.GetReport(request.Credential.UserName,
                request.Credential.Password,
                request.TransactionId);

                Raise("Parsing validation report...", 20);

                if (result == null)
                {
                    throw new ApplicationException("Null result");
                }

                LOG.Debug("GetReport: " + result);

                ValidationReportResult validationResult = 
                    new ValidationReportResult(request.TransactionId, 
                        (ValidationReportResult.ProcessStatus)
                        Enum.Parse(typeof(ValidationReportResult.ProcessStatus), 
                        result.processStatus.ToString(), true));

                validationResult.Detail = result.results;
                validationResult.DocumentStatus = result.documentStatus.ToString();
                validationResult.Time = result.timeStamp;
                validationResult.ValidationType = result.validationType;

                LOG.Debug("Local Results: " + validationResult);

                return validationResult;

            }
            catch (System.Web.Services.Protocols.SoapException sex)
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendFormat("{0}\n", sex.Message);

                if (sex.Detail != null)
                {
                    sb.AppendFormat("{0}\n", sex.Detail.InnerText);
                }
                else
                {
                    sb.AppendFormat("{0}\n", sex.InnerException);
                }

                throw new ApplicationException(sb.ToString(), sex);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ExceptionUtils.GetDeepExceptionMessage(ex));
            }

        }







        public DocumentType DocumentType
        {
            get { return _documentType; }
            set { _documentType = value; }
        }


        public string TestUrl
        {
            get { return _testUrl; }
            set { _testUrl = value; }
        }

        public string ProdUrl
        {
            get { return _prodUrl; }
            set { _prodUrl = value; }
        }

        public IWebProxy Proxy
        {
            get { return _proxy; }
            set { _proxy = value; }
        }

    }
}

