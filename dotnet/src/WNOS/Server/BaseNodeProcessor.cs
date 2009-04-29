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
using System.Threading;
using System.Reflection;

using System.ComponentModel;
using Common.Logging;
using Windsor.Node2008.WNOSUtility;
using Windsor.Node2008.WNOS.Logic;
using Windsor.Node2008.WNOSProviders;
using Windsor.Node2008.WNOSConnector.Server;
using Windsor.Node2008.WNOS.Utilities;
using Windsor.Node2008.WNOSConnector.Logic;
using Windsor.Commons.Core;
using Windsor.Commons.Logging;

namespace Windsor.Node2008.WNOS.Server
{
    public delegate void WorkerNotifcationHandler(object sender, params string[] args);

    public abstract class BaseNodeProcessor : DisposableLoggerBase, INodeProcessor
    {
        public event WorkerNotifcationHandler OnWorkerNotifcationEvent;
        private Thread _thread;
		private long _stopRequested;
		private bool _startProcessingImmediately;

		private long _processingIntervalInTicks = TimeSpan.FromMinutes(1).Ticks;
		private AutoResetEvent _processingIntervalEvent = new AutoResetEvent(false);
		private readonly object _lockObject = new object();
		private ThreadQueueServer _threadQueueServer;
		private INodeProcessorMutexFactory _nodeProcessorMutexFactory;
		private IPluginLoader _pluginLoader;
        private ISettingsProvider _settingsProvider;
        private IActivityManager _activityManager;

        protected BaseNodeProcessor()
        {
        }
        
        public void Init()
        {
			FieldNotInitializedException.ThrowIfNull(this, ref _threadQueueServer);
			FieldNotInitializedException.ThrowIfNull(this, ref _nodeProcessorMutexFactory);
			FieldNotInitializedException.ThrowIfNull(this, ref _pluginLoader);
            FieldNotInitializedException.ThrowIfNull(this, ref _settingsProvider);
            FieldNotInitializedException.ThrowIfNull(this, ref _activityManager);
        }
        protected override void OnDispose(bool inIsDisposing)
        {
            if (inIsDisposing)
            {
                DisposableBase.SafeDispose(ref _processingIntervalEvent);
            }
        }
		public INodeProcessorMutex GetMutex(string transactionId)
		{
			return CreateMutex(MutexPrefix + transactionId);
		}
		protected abstract string MutexPrefix {
			get;
		}
		internal IPluginLoader PluginLoader {
			get {
				return _pluginLoader;
			}
			set {
				_pluginLoader = value;
			}
		}

		internal INodeProcessorMutexFactory NodeProcessorMutexFactory {
			get {
				return _nodeProcessorMutexFactory;
			}
			set {
				_nodeProcessorMutexFactory = value;
			}
		}

        public IActivityManager ActivityManager
        {
			get {
				return _activityManager;
			}
			set {
				_activityManager = value;
			}
		}
        public ISettingsProvider SettingsProvider
        {
            get { return _settingsProvider; }
            set { _settingsProvider = value; }
        }
        public ThreadQueueServer ThreadQueueServer
        {
			get {
				return _threadQueueServer;
			}
			set {
				_threadQueueServer = value;
			}
		}
		public TimeSpan ProcessingInterval {
			get {
				return new TimeSpan(_processingIntervalInTicks);
			}
			set {
				lock (_lockObject) {
					if ( _processingIntervalInTicks != value.Ticks ) {
						Interlocked.Exchange(ref _processingIntervalInTicks, value.Ticks);
						if ( _thread != null ) {
							Wakeup();
						}
					}
				}
			}
		}
		public bool StartProcessingImmediately {
			get {
				return _startProcessingImmediately;
			}
			set {
				_startProcessingImmediately = value;
			}
		}

        public void Start() {
			lock (_lockObject) {
				if ( _thread == null ) {
					try {
						Interlocked.Exchange(ref _stopRequested, 0);
						if ( _startProcessingImmediately ) {
							_processingIntervalEvent.Set();
						} else {
							_processingIntervalEvent.Reset();
						}
						_thread = new Thread(ThreadProc);
						_thread.Start();
						LOG.Debug("Start() succeeded.");
					}
					catch(Exception e) {
						LOG.Error("Start() failed.", e);
						_thread = null;
						throw;
					}
				}
			}
        }
        public void Wakeup() {
			_processingIntervalEvent.Set();
        }
        public void Stop() {
			RequestStop();
			Join();
        }
        public void RequestStop() {
			Interlocked.Exchange(ref _stopRequested, 1);
			_processingIntervalEvent.Set();
        }
        public void Join() {
			lock (_lockObject) {
				Thread thread = _thread;
				if ( thread != null ) {
					try {
						thread.Join();
					}
					catch(Exception e) {
						LOG.Error("_thread.Join() failed.", e);
						throw;
					}
				}
			}
        }
        internal INodeProcessorMutex CreateMutex(string inUniqueName) {
			return NodeProcessorMutexFactory.CreateMutex(inUniqueName);
        }
        private void ThreadProc() {
			try {
				try {
					DoStart();
				}
				catch(Exception e) {
					LOG.Error("DoStart() threw an exception.", e);
					throw;
				}
				for (;;) {
					TimeSpan waitInterval = new TimeSpan(Interlocked.Read(ref _processingIntervalInTicks));
					_processingIntervalEvent.WaitOne(waitInterval == TimeSpan.MaxValue ? 
													 -1 : (int) waitInterval.TotalMilliseconds, true);
					if ( Interlocked.Read(ref _stopRequested) != 0 ) {
						break;
					}
					try {
						DoProcessing();
					}
					catch(Exception e) {
						LOG.Error("DoProcessing() threw an exception.", e);
					}
				}
			}
			catch(Exception e) {
				LOG.Error("ThreadProc() threw an exception.", e);
			}
			finally {
				try {
					DoStop();
				}
				catch(Exception e) {
					LOG.Error("DoStop() threw an exception.", e);
				}
				_thread = null;
			}
        }
        protected virtual void DoStart() { }
        protected virtual void DoStop() { }
        protected abstract void DoProcessing();

        protected void RaiseOnWorkerNotifcationEvent(params string[] args)
        {
            if (OnWorkerNotifcationEvent != null)
            {
                OnWorkerNotifcationEvent(this, args);
            }
        }

    }
}
