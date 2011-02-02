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
using System.Xml;
using System.Xml.XPath;
using System.Net;
using System.IO;
using System.ComponentModel;
using Windsor.Commons.NodeDomain;

namespace Windsor.Node2008.WNOSDomain
{
	public enum ScheduledItemSourceType
	{
		None,
		WebServiceSolicit,
		WebServiceQuery,
		LocalService,
		File
	}
	public enum ScheduledItemTargetType
	{
		None,
		Partner,
		Schematron,
		File,
		Email,
		LocalService,
	}
	public enum ScheduledFrequencyType
	{
		None,
        [Description("Once")]
        Once,
        [Description("Minute")]
        Minute,
        [Description("Hour")]
        Hour,
        [Description("Day")]
        Day,
        [Description("Week")]
        Week,
        [Description("Month")]
        Month,
        OnceThenDelete,
	}
    public enum ScheduleExecuteStatus
    {
        None,
        [Description("Running")]
        Running,
        [Description("Success")]
        CompletedSuccess,
        [Description("Failure")]
        CompletedFailure,
    }
    [Serializable]
    public class ScheduledItemExecuteInfo
    {
        private string _transactionId;
        private string _summary;

        public ScheduledItemExecuteInfo() { }
        public ScheduledItemExecuteInfo(string transactionId, string summary)
        {
            _transactionId = transactionId;
            _summary = summary;
        }

        public string TransactionId
        {
            get { return _transactionId; }
            set { _transactionId = value; }
        }
        public string Summary
        {
            get { return _summary; }
            set { _summary = value; }
        }
    }

	[Serializable]
	public class ScheduledItem : AuditableIdentity
	{
		private string _name;
        private string _flowId;
        private DateTime _startOn = DateTime.MinValue;
		private DateTime _endOn = DateTime.MaxValue;
		private ScheduledItemSourceType _sourceType;
		private string _sourceId;
        private string _sourceFlow;
        private string _sourceRequest;
        private ByIndexOrNameDictionary<string> _sourceArgs;
		private ScheduledItemTargetType _targetType;
		private string _targetId;
        private string _targetFlow;
        private string _targetRequest;
        private string _lastExecuteActivityId;
		private DateTime _lastExecutedOn = DateTime.MinValue;
		private DateTime _nextRunOn = DateTime.MinValue;
		private ScheduledFrequencyType _frequencyType;
		private int _frequency;
		private bool _isActive;
        private ScheduleExecuteStatus _executeStatus;
        private ScheduledItemExecuteInfo _lastExecuteInfo;

		public bool IsActive {
			get {
				return _isActive;
			}
			set {
				_isActive = value;
			}
		}
		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

        public string FlowId
        {
            get { return _flowId; }
            set { _flowId = value; }
        }
        
        public DateTime StartOn
		{
			get { return _startOn; }
			set { _startOn = value; }
		}

		public DateTime EndOn
		{
			get { return _endOn; }
			set { _endOn = value; }
		}

		public ScheduledItemSourceType SourceType
		{
			get { return _sourceType; }
			set { _sourceType = value; }
		}

        public string SourceRequest
        {
            get { return _sourceRequest; }
            set { _sourceRequest = value; }
        }
        public string SourceFlow
        {
            get { return _sourceFlow; }
            set { _sourceFlow = value; }
        }
        public string SourceId
		{
			get { return _sourceId; }
			set { _sourceId = value; }
		}

		public ByIndexOrNameDictionary<string> SourceArgs
		{
			get { return _sourceArgs; }
			set { _sourceArgs = value; }
		}

		public ScheduledItemTargetType TargetType
		{
			get { return _targetType; }
			set { _targetType = value; }
		}

		public string TargetId
		{
			get { return _targetId; }
			set { _targetId = value; }
		}
        public string TargetFlow
        {
            get { return _targetFlow; }
            set { _targetFlow = value; }
        }
        public string TargetRequest
        {
            get { return _targetRequest; }
            set { _targetRequest = value; }
        }

        public string LastExecuteActivityId
		{
			get { return _lastExecuteActivityId; }
			set { _lastExecuteActivityId = value; }
		}

		public DateTime LastExecutedOn {
			get {
				return _lastExecutedOn;
			}
			set {
				_lastExecutedOn = value;
			}
		}
		public DateTime NextRunOn
		{
			get { return _nextRunOn; }
			set { _nextRunOn = value; }
		}

		public ScheduledFrequencyType FrequencyType
		{
			get { return _frequencyType; }
			set { _frequencyType = value; }
		}
		public int Frequency
		{
			get { return _frequency; }
			set { _frequency = value; }
		}
        public ScheduleExecuteStatus ExecuteStatus
        {
            get { return _executeStatus; }
            set { _executeStatus = value; }
        }
        public ScheduledItemExecuteInfo LastExecuteInfo
        {
            get { return _lastExecuteInfo; }
            set { _lastExecuteInfo = value; }
        }
        public static DateTime CalcNextRunTime(DateTime nextRunOn, ScheduledFrequencyType frequencyType,
                                               int frequency, bool hasRunOnceAlready)
        {
            DateTime now = DateTime.Now;
            if (frequency <= 0)
            {
                frequency = 1;
            }
            DateTime newDate;
            switch (frequencyType)
            {
                case ScheduledFrequencyType.Once:
                    if (hasRunOnceAlready)
                    {
                        return DateTime.MaxValue;
                    }
                    else
                    {
                        return nextRunOn;
                    }
                case ScheduledFrequencyType.Minute:
                    newDate = nextRunOn;
                    while (newDate < now) newDate = newDate.AddMinutes(frequency);
                    return newDate;
                case ScheduledFrequencyType.Hour:
                    newDate = nextRunOn;
                    while (newDate < now) newDate = newDate.AddHours(frequency);
                    return newDate;
                case ScheduledFrequencyType.Day:
                    newDate = nextRunOn;
                    while (newDate < now) newDate = newDate.AddDays(frequency);
                    return newDate;
                case ScheduledFrequencyType.Week:
                    newDate = nextRunOn;
                    while (newDate < now) newDate = newDate.AddDays(frequency * 7);
                    return newDate;
                case ScheduledFrequencyType.Month:
                    newDate = nextRunOn;
                    while (newDate < now) newDate = newDate.AddMonths(frequency);
                    return newDate;
                default:
                    return DateTime.MaxValue;
            }
        }
    }
}
