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
using System.Reflection;
using System.Diagnostics;
using System.Threading;

namespace Windsor.Commons.Core
{
    public interface IIsDisposed
    {
        bool IsDisposed
        {
            get;
        }
    }

    /// <summary>
    /// Basic functionality for an object implementing IDisposable
    /// </summary>
    public abstract class DisposableBase : IDisposable, IIsDisposed
    {


        private int _disposedCallCount;

        /// <summary>
        /// Safely dispose of an object without allowing exceptions to propogate.
        /// </summary>
        /// <param name="inObject"></param>
        public static void SafeDispose(object inObject)
        {
            IDisposable disposable = inObject as IDisposable;
            if (disposable != null)
            {
                try
                {
                    disposable.Dispose();
                }
                catch (Exception)
                {
                }
            }
        }

        /// <summary>
        /// Safely dispose of an object without allowing exceptions to propogate, and set input
        /// reference to null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ioObject"></param>
        public static void SafeDispose<T>(ref T ioObject) where T : class
        {
            object obj = ioObject;
            ioObject = null;
            SafeDispose(obj);
        }

        ~DisposableBase()
        {
            #if DEBUG
            if (!IsDisposed)
            {
                Assembly entryAssembly = null;
                try
                {
                    entryAssembly = Assembly.GetEntryAssembly();
                    if (entryAssembly == null)
                    {
                        entryAssembly = Assembly.GetExecutingAssembly();
                    }
                }
                catch (Exception)
                {
                }
                DebugUtils.CheckDebuggerBreak();
            }
            #endif // DEBUG

            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of
            // readability and maintainability.
            Dispose(false);
        }

        /// <summary>
        /// IsDisposed
        /// </summary>
        public bool IsDisposed
        {
            get
            {
                return (_disposedCallCount < 0);
            }
        }

        /// <summary>
        /// Implement IDisposable. 
        /// Do not make this method virtual.
        /// A derived class should not be able to override this method.
        /// </summary>
        public void Dispose()
        {

            Dispose(true);
            // Take yourself off the Finalization queue 
            // to prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose(bool disposing) executes in two distinct scenarios.
        /// If disposing equals true, the method has been called directly
        /// or indirectly by a user's code. Managed and unmanaged resources
        /// can be disposed.
        /// If disposing equals false, the method has been called by the 
        /// runtime from inside the finalizer and you should not reference 
        /// other objects. Only unmanaged resources can be disposed.
        /// </summary>
        /// <param name="inIsDisposing"></param>
        protected virtual void Dispose(bool inIsDisposing)
        {

            // Check to see if Dispose has already been called.
            if (Interlocked.Decrement(ref _disposedCallCount) == -1)
            {
                OnDispose(inIsDisposing);
            }
        }

        /// <summary>
        /// This is the method to override in your subclass.
        /// </summary>
        protected abstract void OnDispose(bool inIsDisposing);

    }
}
