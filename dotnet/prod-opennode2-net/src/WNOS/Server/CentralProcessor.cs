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
using Windsor.Node2008.WNOSConnector.Server;
using Windsor.Commons.Core;
using Windsor.Node2008.WNOSDomain;

namespace Windsor.Node2008.WNOS.Server
{
    public class CentralProcessor : BaseNodeProcessor, ICentralProcessor
	{
		private List<INodeProcessor> _processors;
        private int _threadsPerProcessor = -1;
        private int _maxNumConcurrentThreads = -1;

		#region Init

		new public void Init()
		{
			base.Init();

			FieldNotInitializedException.ThrowIfNull(this, ref _processors);
            if (_threadsPerProcessor <= 0)
            {
                _threadsPerProcessor = 3;
            }
            if (_maxNumConcurrentThreads <= 0)
            {
                _maxNumConcurrentThreads = _threadsPerProcessor * Environment.ProcessorCount;
            }
        }

		#endregion

		public CentralProcessor()
		{
			ProcessingInterval = TimeSpan.MaxValue;
		}

        public void WakeupProcessor(NodeMethod methodProcessorType)
        {
            switch (methodProcessorType)
            {
                case NodeMethod.Submit:
                    WakeProcessors<SubmitProcessor>();
                    break;
                case NodeMethod.Solicit:
                    WakeProcessors<SolicitProcessor>();
                    break;
                case NodeMethod.Task:
                    WakeProcessors<TaskProcessor>();
                    break;
                case NodeMethod.Schedule:
                    WakeProcessors<ScheduleProcessor>();
                    break;
                case NodeMethod.Notify:
                    WakeProcessors<NotifyProcessor>();
                    break;
                case NodeMethod.Execute:
                    WakeProcessors<ExecuteProcessor>();
                    break;
                default:
                    throw new ArgumentException(string.Format("Unrecognized methodProcessorType: {0}", 
                                                              methodProcessorType.ToString()));
            }
        }

        protected void WakeProcessors<T>() where T : class, INodeProcessor
        {
            foreach (INodeProcessor processor in Processors)
            {
                T wakeProcessor = processor as T;
                if (wakeProcessor != null)
                {
                    wakeProcessor.Wakeup();
                }
            }
        }

		protected override string MutexPrefix {
			get { return "CentralProcessor_"; }
		}
		protected override void DoStart()
		{
			try
			{
				// Start thread queue server
				if (!ThreadQueueServer.IsStarted)
				{
					ThreadQueueServer.Run(_maxNumConcurrentThreads, false);
                }

				// Start processor threads
				foreach (INodeProcessor processor in Processors)
				{
					processor.Start();
				}
			}
			catch (Exception e)
			{
				LOG.Error("DoStart() threw an exception.", e);
				DoStop();
				throw;
			}
		}
		protected override void DoStop()
		{
			try
			{
				foreach (INodeProcessor processor in Processors)
				{
					processor.RequestStop();
				}
				foreach (INodeProcessor processor in Processors)
				{
					processor.Join();
				}
				DisposableBase.SafeDispose(ThreadQueueServer);
			}
			catch (Exception e)
			{
				LOG.Error("DoStop() threw an exception.", e);
				throw;
			}
		}
		protected override void DoProcessing()
		{

		}
		internal List<INodeProcessor> Processors
		{
			get { return _processors; }
			set { _processors = value; }
		}
        public int ThreadsPerProcessor
        {
            get { return _threadsPerProcessor; }
            set { _threadsPerProcessor = value; }
        }
        public int MaxNumConcurrentThreads
        {
            get { return _maxNumConcurrentThreads; }
            set { _maxNumConcurrentThreads = value; }
        }

    }
}
