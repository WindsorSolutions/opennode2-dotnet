using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Threading;

using Microsoft.VisualBasic.ApplicationServices;

using Windsor.Commons.Core;

namespace Windsor.Commons.WinForms
{
    /// <summary>
    /// Unfortunately, because of the crappy way WindowsFormsApplicationBase is implemented,
    /// this file must be included as a link in you project and cannot be included in the 
    /// Windsor.Commons.WinForms library for it to work.
    /// </summary>
    public class SingleInstanceApplication : WindowsFormsApplicationBase, IDisposable
    {
        public const string cGlobalKernelObjectPrefix = @"Global\";
        public const string cLocalKernelObjectPrefix = @"Local\";

        public SingleInstanceApplication(string inUniqueId, bool inRunPerWindowsUser)
        {
            this.IsSingleInstance = true;
            this.EnableVisualStyles = true;
            this.ShutdownStyle = ShutdownMode.AfterMainFormCloses;
            string mutexName =
                inRunPerWindowsUser ? inUniqueId : cGlobalKernelObjectPrefix + inUniqueId;
            bool isMutexOwner = false;
            m_StartupMutex = new Mutex(true, mutexName, out isMutexOwner);
            m_IsRunningAlready = !isMutexOwner;
            if (m_IsRunningAlready)
            {
                // If there is already an instance running, set the m_IsRunningAlready flag so that
                // we will exit gracefully.  The Mutex check is needed here since the base class does not check
                // for "global" single-instance apps, only per-user single-instance apps.
                DisposableBase.SafeDispose(ref m_StartupMutex);
            }
        }
        public void Run(System.Windows.Forms.Form inForm)
        {
            m_MainForm = inForm;
            base.Run(new string[0]);
        }
        public void Run(string[] args, System.Windows.Forms.Form inForm)
        {
            m_MainForm = inForm;
            base.Run(args);
        }
        public new System.Windows.Forms.Form MainForm
        {
            get { return base.MainForm; }
        }
        public void Dispose()
        {
            DisposableBase.SafeDispose(ref m_StartupMutex);
        }
        protected override void OnCreateMainForm()
        {
            if (m_StartupMutex != null)
            {
                base.MainForm = m_MainForm;
                m_MainForm = null;
            }
        }
        protected override void OnStartupNextInstance(StartupNextInstanceEventArgs eventArgs)
        {
            base.OnStartupNextInstance(eventArgs);
        }
        protected override bool OnStartup(StartupEventArgs eventArgs)
        {
            if (m_StartupMutex != null)
            {
                return base.OnStartup(eventArgs);
            }
            return false;
        }
        protected override void OnShutdown()
        {
            try
            {
                base.OnShutdown();
            }
            finally
            {
                DisposableBase.SafeDispose(ref m_StartupMutex);
            }
        }
        private System.Windows.Forms.Form m_MainForm;
        private bool m_IsRunningAlready;
        private Mutex m_StartupMutex;
    }
}
