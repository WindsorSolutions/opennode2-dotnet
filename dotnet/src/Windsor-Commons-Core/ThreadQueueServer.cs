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
using Windsor.Commons.Core;

namespace Windsor.Commons.Core
{
    public interface IBlockingQueueServerWorker
    {
        bool IsHighPriority { get; }
        void DoWork();
    }

    /// <summary>
    /// Class to manage a set of threads that process items placed in a queue.
    /// </summary>
    public class ThreadQueueServer : DisposableBase
    {

        public ThreadQueueServer(int inNumThreads, bool inAreBackgroundThreads)
        {
            Run(inNumThreads, inAreBackgroundThreads);
        }
        public ThreadQueueServer()
        {
        }

        /// <summary>
        /// Run the server with the specified number of threads.
        /// </summary>
        public void Run(int inNumThreads, bool inAreBackgroundThreads)
        {
            DebugUtils.AssertDebuggerBreak(inNumThreads > 0);
            if (inNumThreads < 1)
            {
                throw new System.ArgumentException("inNumThreads must be > 0");
            }
            lock (m_LockObject)
            {
                DebugUtils.AssertDebuggerBreak(m_ThreadPool == null);
                if (m_ThreadPool != null)
                {
                    throw new System.InvalidOperationException("You must call BlockingQueueServer.Shutdown() before calling BlockingQueueServer.Run() again!");
                }
                DebugUtils.AssertDebuggerBreak(m_ThreadPoolQueue == null);
                DebugUtils.AssertDebuggerBreak(m_ShutdownAutoResetEvent == null);
                m_ThreadPoolQueue = new LinkedList<IBlockingQueueServerWorker>();
                try
                {
                    m_ThreadPool = new List<Thread>(inNumThreads);
                    ThreadStart threadStart = new ThreadStart(ThreadLoop);
                    for (int i = 0; i < inNumThreads; ++i)
                    {
                        Thread thread = new Thread(threadStart);
                        m_ThreadPool.Add(thread);
                        thread.Name = string.Format("BlockingQueueServer Thread {0}", i.ToString());
                        thread.IsBackground = inAreBackgroundThreads;
                        thread.Start();
                    }
                }
                catch (Exception)
                {
                    Shutdown(true);
                    throw;
                }
            }
        }
        public bool IsStarted
        {
            get
            {
                lock (m_LockObject)
                {
                    return (m_ThreadPool != null);
                }
            }
        }
        public bool IsStopped
        {
            get
            {
                lock (m_LockObject)
                {
                    return (m_ThreadPool == null);
                }
            }
        }
        public bool BeginShutdown(bool inDeleteAllItemsInQueue)
        {
            bool didStartShutdown = false;
            lock (m_LockObject)
            {
                m_IsPaused = 0;
                if (m_ThreadPool != null)
                {
                    if (m_ShutdownAutoResetEvent != null)
                    {
                        throw new System.InvalidOperationException("Shutdown already started!");
                    }
                    m_ShutdownAutoResetEvent = new AutoResetEvent(false);
                    if (inDeleteAllItemsInQueue)
                    {
                        m_ThreadPoolQueue.Clear();
                    }
                    Enqueue(m_ThreadPoolQueue, null);	// This will cause all threads to exit
                    m_ManualResetEvent.Set();
                    didStartShutdown = true;
                }
            }
            return didStartShutdown;
        }
        public void EndShutdown()
        {
            // Wait for all the worker threads to exit
            lock (m_LockObject)
            {
                if (m_ThreadPool.Remove(Thread.CurrentThread))
                {
                    s_ContinueThreadLoop = false;
                    if ((m_ThreadPool == null) || (m_ThreadPool.Count == 0))
                    {
                        m_ThreadPool = null;
                        m_ShutdownAutoResetEvent.Set();
                    }
                }
            }
            m_ShutdownAutoResetEvent.WaitOne();
            DebugUtils.AssertDebuggerBreak(m_ThreadPool == null);	// All threads should have completed!
            lock (m_LockObject)
            {
                m_ThreadPoolQueue = null;
                DisposableBase.SafeDispose(ref m_ManualResetEvent);
                DisposableBase.SafeDispose(ref m_ShutdownAutoResetEvent);
            }
        }
        /// <summary>
        /// Shutdown the server by ending all threads and deleting all queued (unprocessed) items.
        /// </summary>
        public void Shutdown(bool inDeleteAllItemsInQueue)
        {
            if (BeginShutdown(inDeleteAllItemsInQueue))
            {
                EndShutdown();
            }
        }
        public void ShutdownNoThrow(bool inDeleteAllItemsInQueue)
        {
            try
            {
                Shutdown(inDeleteAllItemsInQueue);
            }
            catch (Exception)
            {
            }
        }
        public bool BeginShutdownNoThrow(bool inDeleteAllItemsInQueue)
        {
            try
            {
                return BeginShutdown(inDeleteAllItemsInQueue);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void EndShutdownNoThrow()
        {
            try
            {
                EndShutdown();
            }
            catch (Exception)
            {
            }
        }
        public void Pause()
        {
            DebugUtils.AssertDebuggerBreak(m_ShutdownAutoResetEvent == null);
            if (m_ShutdownAutoResetEvent == null)
            {
                Thread.VolatileWrite(ref m_IsPaused, 1);
                m_ManualResetEvent.Reset();
            }
        }
        public void Resume()
        {
            DebugUtils.AssertDebuggerBreak(m_ShutdownAutoResetEvent == null);
            if (m_ShutdownAutoResetEvent == null)
            {
                bool isPaused = (Thread.VolatileRead(ref m_IsPaused) != 0);
                if (isPaused)
                {
                    Thread.VolatileWrite(ref m_IsPaused, 0);
                    m_ManualResetEvent.Reset();
                }
            }
        }
        /// <summary>
        /// Returns the number of items that are in the thread queue (waiting to execute)
        /// </summary>
        public int QueueCount
        {
            get
            {
                lock (m_LockObject)
                {
                    return (m_ThreadPoolQueue == null) ? 0 : m_ThreadPoolQueue.Count;
                }
            }
        }
        public int ThreadCount
        {
            get
            {
                lock (m_LockObject)
                {
                    return (m_ThreadPool == null) ? 0 : m_ThreadPool.Count;
                }
            }
        }
        public void Enqueue(IBlockingQueueServerWorker inWorker)
        {
            lock (m_LockObject)
            {
                DebugUtils.AssertDebuggerBreak(m_ThreadPoolQueue != null);
                DebugUtils.AssertDebuggerBreak(m_ShutdownAutoResetEvent == null);
                if (m_ShutdownAutoResetEvent != null)
                {
                    throw new System.InvalidOperationException("Can't enqueue workers while shutting down!");
                }
                Enqueue(m_ThreadPoolQueue, inWorker);
            }
            m_ManualResetEvent.Set();	// Wake up threads to handle the new item in the queue
        }
        public void Enqueue<T>(IEnumerable<T> inWorkers) where T : IBlockingQueueServerWorker
        {

            lock (m_LockObject)
            {
                DebugUtils.AssertDebuggerBreak(m_ThreadPoolQueue != null);
                DebugUtils.AssertDebuggerBreak(m_ShutdownAutoResetEvent == null);
                if (m_ShutdownAutoResetEvent != null)
                {
                    throw new System.InvalidOperationException("Can't enqueue workers while shutting down!");
                }
                foreach (IBlockingQueueServerWorker worker in inWorkers)
                {
                    Enqueue(m_ThreadPoolQueue, worker);
                }
            }
            m_ManualResetEvent.Set();	// Wake up threads to handle the new item in the queue
        }
        protected override void OnDispose(bool inIsDisposing)
        {
            if (inIsDisposing)
            {
                try
                {
                    Shutdown(true);
                }
                catch (Exception)
                {
                }
            }
        }
        private void ThreadLoop()
        {
            s_ContinueThreadLoop = true;
            while (s_ContinueThreadLoop)
            {
                IBlockingQueueServerWorker worker = Dequeue();
                if (worker != null)
                {
                    try
                    {
                        worker.DoWork();
                    }
                    catch (Exception)
                    {

                    }
                    finally
                    {
                        DisposableBase.SafeDispose(ref worker);
                    }
                }
                else
                {
                    // Shutdown the thread: remove ourselves from the thread pool, and exit this loop
                    lock (m_LockObject)
                    {
                        bool didRemove = m_ThreadPool.Remove(Thread.CurrentThread);
                        DebugUtils.AssertDebuggerBreak(didRemove);
                        if ((m_ThreadPool == null) || (m_ThreadPool.Count == 0))
                        {
                            m_ThreadPool = null;
                            m_ShutdownAutoResetEvent.Set();
                        }
                        else
                        {
                            Enqueue(m_ThreadPoolQueue, null); // This will cause all remaining threads to exit
                            m_ManualResetEvent.Set();
                        }
                        break;
                    }
                }
            }
        }
        private static void Enqueue(LinkedList<IBlockingQueueServerWorker> inThreadPoolQueue,
                                    IBlockingQueueServerWorker inWorker)
        {
            if (inWorker == null)
            {
                // This is a shutdown signal, put at very front of queue
                inThreadPoolQueue.AddFirst(inWorker);
            }
            else if (inWorker.IsHighPriority)
            {
                LinkedListNode<IBlockingQueueServerWorker> currentNode = inThreadPoolQueue.First;
                while (currentNode != null)
                {
                    if (currentNode.Value != null)
                    {
                        if (!currentNode.Value.IsHighPriority)
                        {
                            inThreadPoolQueue.AddBefore(currentNode, inWorker);
                            return;
                        }
                    }
                    currentNode = currentNode.Next;
                }
                inThreadPoolQueue.AddLast(inWorker);
            }
            else
            {
                inThreadPoolQueue.AddLast(inWorker);
            }
        }
        private IBlockingQueueServerWorker Dequeue()
        {
            while (true)
            {
                DebugUtils.AssertDebuggerBreak(m_ManualResetEvent != null);
                lock (m_LockObject)
                {
                    if (m_IsPaused == 0)
                    {
                        if (m_ThreadPoolQueue.Count > 0)
                        {
                            IBlockingQueueServerWorker worker = m_ThreadPoolQueue.First.Value;
                            m_ThreadPoolQueue.RemoveFirst();
                            if (m_ThreadPoolQueue.Count > 0)
                            {
                                m_ManualResetEvent.Set();
                            }
                            else
                            {
                                m_ManualResetEvent.Reset();
                            }
                            return worker;
                        }
                        else
                        {
                            m_ManualResetEvent.Reset();
                        }
                    }
                    else
                    {
                        m_ManualResetEvent.Reset();
                    }
                }
                m_ManualResetEvent.WaitOne();	// Wait for an item to enter the queue
            }
        }

        private List<Thread> m_ThreadPool;
        private LinkedList<IBlockingQueueServerWorker> m_ThreadPoolQueue;
        private object m_LockObject = new object();
        private ManualResetEvent m_ManualResetEvent = new ManualResetEvent(false);
        private AutoResetEvent m_ShutdownAutoResetEvent;
        private int m_IsPaused;
        [ThreadStatic]
        private static bool s_ContinueThreadLoop;
    }
}
