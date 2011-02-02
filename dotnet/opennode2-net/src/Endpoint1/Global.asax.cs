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
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.SessionState;
using System.Reflection;
using System.IO;
using System.Text;
using Common.Logging;
using Windsor.Commons.Logging;

namespace Windsor.Node2008.Endpoint1
{
    public class Global : System.Web.HttpApplication
    {


        private static readonly ILogEx LOG = LogManagerEx.GetLogger(MethodBase.GetCurrentMethod());
        private static string _saveRequestFileName = null;

        protected void Application_Start(object sender, EventArgs e)
        {
            LOG.Info("Application_Start");
            try
            {
                _saveRequestFileName = System.Configuration.ConfigurationManager.AppSettings["RequestSaveFileName"];
            }
            catch (Exception ex)
            {
                LOG.Error("Failed to get RequestSaveFileName setting: {0}", ex.Message);
            }
        }

        protected void Application_End(object sender, EventArgs e)
        {
            LOG.Info("Application_End");
        }

        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            LOG.Info("Application_BeginRequest");
            SaveRequestToFile();
        }

        protected void SaveRequestToFile()
        {
            try
            {
                if (!string.IsNullOrEmpty(_saveRequestFileName))
                {
                    LOG.Info("SaveRequestToFile");
                    long startPos = Context.Request.InputStream.Position;
                    byte[] requestContents = new byte[Context.Request.InputStream.Length - startPos];
                    Context.Request.InputStream.Read(requestContents, 0, requestContents.Length);
                    Request.InputStream.Position = startPos;

                    string savePath = Path.Combine(Request.PhysicalApplicationPath, _saveRequestFileName);
                    LOG.Info("savePath: {0}", savePath);
                    using (Stream stream = File.Open(savePath, FileMode.Append, FileAccess.Write))
                    {
                        byte[] header =
                            Encoding.UTF8.GetBytes(string.Format("{0}{0}<=========================    {1}    ===================================================================>{0}{0}", 
                                                                 Environment.NewLine, DateTime.Now.ToString()));
                        stream.Write(header, 0, header.Length);
                        stream.Write(requestContents, 0, requestContents.Length);
                    }
                }
            }
            catch (Exception ex)
            {
                LOG.Error("Failed to SaveRequestToFile: {0}", ex.Message);
            }
        }
    }
}