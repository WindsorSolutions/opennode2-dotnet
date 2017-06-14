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
using System.Net;
using System.Threading;
using System.ComponentModel;

namespace Windsor.Commons.Core
{
    public static class NetworkUtils
    {
        public static IWebProxy WebProxy { get; set; }
        private static object s_LockObject = new object();

        public static WebClient GetConfiguredWebClient(IEnumerable<KeyValuePair<string, string>> additionalHeaders)
        {
            WebClient webClient = new WebClient();
            webClient.UseDefaultCredentials = true;

            lock (s_LockObject)
            {
                if (WebProxy != null)
                {
                    webClient.Proxy = WebProxy;
                }
                else
                {
                    // Specifically set default web proxy on client:
                    // TSM: Obsolete, this is the default now
                    //System.Net.WebProxy defaultProxy = System.Net.WebProxy.GetDefaultProxy();
                    System.Net.WebProxy defaultProxy = null;
                    if ((defaultProxy == null) || (defaultProxy.Address == null))
                    {
                        webClient.Proxy = null;
                    }
                    else
                    {
                        defaultProxy.UseDefaultCredentials = true;
                        defaultProxy.Credentials = CredentialCache.DefaultCredentials;
                        webClient.Proxy = defaultProxy;
                    }
                }
            }

            if (additionalHeaders != null)
            {
                foreach (var pair in additionalHeaders)
                {
                    webClient.Headers.Add(pair.Key, pair.Value);
                }
            }
            return webClient;
        }

        public static string GetLocalIp()
        {
            IPHostEntry entry = Dns.GetHostEntry(GetHostName());
            IPAddress[] ips = entry.AddressList;
            foreach (IPAddress address in ips)
            {
                if (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    return address.ToString();
                }
            }
            return ips[0].ToString();
        }

        public static string GetHostName()
        {
            return Dns.GetHostName();
        }

        /// <summary>
        /// Download progress callback
        /// </summary>
        /// <param name="percentComplete"></param>
        /// <param name="callbackParam"></param>
        /// <returns>True to continue download, false to stop</returns>
        public delegate bool DownloadProgressHandler(int percentComplete, object callbackParam);

        public static byte[] DownloadData(string url, IEnumerable<KeyValuePair<string, string>> additionalHeaders = null)
        {
            return DownloadData(url, null, null, additionalHeaders);
        }
        public static byte[] DownloadData(string url,
                                          DownloadProgressHandler progressCallback,
                                          object callbackParam, IEnumerable<KeyValuePair<string, string>> additionalHeaders = null)
        {
            if (progressCallback != null)
            {
                bool cancelled = false;
                Exception error = null;
                byte[] data = null;
                bool isFinished = false;

                using (WebClient webClient = GetConfiguredWebClient(additionalHeaders))
                {
                    webClient.DownloadProgressChanged += delegate(Object sender,
                                                                  DownloadProgressChangedEventArgs e)
                    {
                        if (!progressCallback(e.ProgressPercentage, callbackParam))
                        {
                            webClient.CancelAsync();
                        }
                    };
                    webClient.DownloadDataCompleted += delegate(Object sender,
                                                                DownloadDataCompletedEventArgs e)
                    {
                        error = e.Error;
                        if (error == null)
                        {
                            data = e.Result;
                        }
                        cancelled = e.Cancelled;
                        isFinished = true;
                    };
                    webClient.DownloadDataAsync(new Uri(url));

                    while (!isFinished)
                    {
                        Thread.Sleep(60);
                    }
                }
                if (cancelled)
                {
                    throw new OperationCanceledException();
                }
                if (error != null)
                {
                    throw error;
                }
                return data;
            }
            else
            {
                using (WebClient webClient = GetConfiguredWebClient(additionalHeaders))
                {
                    return webClient.DownloadData(url);
                }
            }
        }
        public static void DownloadFile(string url, string filePath, IEnumerable<KeyValuePair<string, string>> additionalHeaders = null)
        {
            DownloadFile(url, filePath, null, null, additionalHeaders);
        }
        public static void DownloadFile(string url, string filePath,
                                        DownloadProgressHandler progressCallback,
                                        object callbackParam, IEnumerable<KeyValuePair<string, string>> additionalHeaders = null)
        {
            if (progressCallback != null)
            {
                Exception error = null;
                bool cancelled = false;
                bool isFinished = false;
                using (WebClient webClient = GetConfiguredWebClient(additionalHeaders))
                {
                    webClient.DownloadProgressChanged += delegate(Object sender,
                                                                  DownloadProgressChangedEventArgs e)
                    {
                        if (!progressCallback(e.ProgressPercentage, callbackParam))
                        {
                            webClient.CancelAsync();
                        }
                    };
                    webClient.DownloadFileCompleted += delegate(Object sender,
                                                                AsyncCompletedEventArgs e)
                    {
                        error = e.Error;
                        cancelled = e.Cancelled;
                        isFinished = true;
                    };
                    webClient.DownloadFileAsync(new Uri(url), filePath);

                    while (!isFinished)
                    {
                        Thread.Sleep(60);
                    }
                }
                if (cancelled)
                {
                    throw new OperationCanceledException();
                }
                if (error != null)
                {
                    throw error;
                }
            }
            else
            {
                using (WebClient webClient = GetConfiguredWebClient(additionalHeaders))
                {
                    webClient.DownloadFile(url, filePath);
                }
            }
        }
        public static bool IsConnectedToInternet()
        {
            string stdOutput, stdError;
            ProcessUtils.ExecuteCmd("ipconfig /all", out stdOutput, out stdError);
            if (!string.IsNullOrEmpty(stdOutput))
            {
                if (((GetIpConfigAddress(stdOutput, "IP Address") != null) || (GetIpConfigAddress(stdOutput, "IPv4") != null)) &&
                     (GetIpConfigAddress(stdOutput, "Default Gateway") != null))
                {
                    return true;
                }
            }
            return false;
        }
        public static void VerifyHttpUrl(string url, int timeoutInSeconds)
        {
            //Creating the HttpWebRequest
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Timeout = timeoutInSeconds * 1000;
            //Setting the Request method HEAD, you can also use GET too.
            request.Method = "HEAD";
            //Getting the Web Response.
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                //Returns TURE if the Status code == 200
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new ArgumentException(string.Format("The web server at location \"{0}\" returned an invalid status code: \"{1}\"",
                                                              url, response.StatusCode.ToString()));
                }
            }
        }
        private static IPAddress GetIpConfigAddress(string ipConfigStdOut, string addressName)
        {
            try
            {
                int index = 0;
                do
                {
                    index = ipConfigStdOut.IndexOf(addressName, index, StringComparison.InvariantCultureIgnoreCase);
                    if (index > 0)
                    {
                        index = ipConfigStdOut.IndexOf(':', index + 1);
                        if (index > 0)
                        {
                            int endIndex = index;
                            while (endIndex < (ipConfigStdOut.Length - 1))
                            {
                                ++endIndex;
                                char checkChar = ipConfigStdOut[endIndex];
                                if ((checkChar != ' ') && (checkChar != '.') && !char.IsDigit(checkChar))
                                {
                                    --endIndex;
                                    break;
                                }
                            }
                            if (index < endIndex)
                            {
                                string addrString = ipConfigStdOut.Substring(index + 1, endIndex - index).Trim();
                                IPAddress address;
                                if (IPAddress.TryParse(addrString, out address))
                                {
                                    if (address != IPAddressEmpty)
                                    {
                                        return address;
                                    }
                                }
                            }
                        }
                    }
                } while (index > 0);
            }
            catch (Exception)
            {
            }
            return null;
        }
        static public readonly IPAddress IPAddressEmpty = IPAddress.Parse("0.0.0.0");
    }
}
