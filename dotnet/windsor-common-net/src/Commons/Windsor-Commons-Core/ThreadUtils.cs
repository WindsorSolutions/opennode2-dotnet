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
using System.Collections;
using System.Collections.Specialized;
using System.Text;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Threading;

namespace Windsor.Commons.Core
{
	/// <summary>
	/// Basic helper functions for dealing with strings.
	/// </summary>
    public static class ThreadUtils
    {
        public delegate R ThreadRunDelegate<R, T>(T param);

        public static R RunWithTimeout<R, T>(int timeoutInSeconds, T param, ThreadRunDelegate<R, T> del)
        {
            // Command does not support timeout, do a manual timeout here
            Thread thread = null;
            Exception threadException = null;
            try
            {
                R rtnVal = default(R);
                thread = new Thread(delegate()
                {
                    try
                    {
                        rtnVal = del(param);
                    }
                    catch (Exception thEx)
                    {
                        // If the exception is not trapped here, .NET will kill the process since this would
                        // be an unhandled exception, so catch the exception here and pass it along below (outside
                        // of the thread context).
                        threadException = thEx;
                    }
                });
                thread.IsBackground = true;
                thread.Start();
                if (!thread.Join(timeoutInSeconds * 1000))
                {
                    throw new TimeoutException(string.Format("Execution did not finish within {0} seconds",
                                                             timeoutInSeconds.ToString()));
                }
                if (threadException != null)
                {
                    throw threadException;
                }
                return rtnVal;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if ((thread != null) && thread.IsAlive)
                {
                    try
                    {
                        thread.Abort();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }
    }
    public class PermitsSemaphore
    {
        private int _initialPermits;
        private AutoResetEvent _event = new AutoResetEvent(false);

        public PermitsSemaphore(int initialPermits)
        {
            Init(initialPermits);
        }
        public void Init(int initialPermits)
        {
            if (initialPermits > 0)
            {
                initialPermits = -initialPermits;
            }
            _initialPermits = initialPermits;
        }
        public void ReleaseAndWaitForZero()
        {
            Interlocked.Increment(ref _initialPermits);
            while (_initialPermits < 0)
            {
                _event.WaitOne();
            }
            _event.Set();
        }
        public void Release()
        {
            Interlocked.Increment(ref _initialPermits);
            _event.Set();
        }
    }
}
