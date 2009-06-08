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

        public static byte[] DownloadData(string url)
        {
            return DownloadData(url, null, null);
        }
        public static byte[] DownloadData(string url,
                                          DownloadProgressHandler progressCallback,
                                          object callbackParam)
        {
            if (progressCallback != null)
            {
                bool cancelled = false;
                Exception error = null;
                byte[] data = null;
                bool isFinished = false;

                using (WebClient webClient = new WebClient())
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
                        data = e.Result;
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
                using (WebClient webClient = new WebClient())
                {
                    return webClient.DownloadData(url);
                }
            }
        }
        public static void DownloadFile(string url, string filePath)
        {
            DownloadFile(url, filePath, null, null);
        }
        public static void DownloadFile(string url, string filePath,
                                        DownloadProgressHandler progressCallback,
                                        object callbackParam)
        {
            if (progressCallback != null)
            {
                Exception error = null;
                bool cancelled = false;
                bool isFinished = false;
                using (WebClient webClient = new WebClient())
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
                using (WebClient webClient = new WebClient())
                {
                    webClient.DownloadFile(url, filePath);
                }
            }
        }
    }
}
