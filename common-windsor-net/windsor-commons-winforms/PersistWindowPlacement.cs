using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Drawing;
using Microsoft.Win32;

using Windsor.Commons.Core;

namespace Windsor.Commons.WinForms
{
    public class PersistWindowPlacement : System.ComponentModel.Component
    {
        [Serializable]
        private struct SaveWindowState
        {
            public Rectangle bounds;
            public FormWindowState state;
        }
        // event info that allows form to persist extra window state data
        public delegate string RetrieveWindowPlacementDelegate(PersistWindowPlacement sender);
        public delegate void SaveWindowPlacementDelegate(PersistWindowPlacement sender, string placement);
        public event RetrieveWindowPlacementDelegate RetrieveWindowPlacement;
        public event SaveWindowPlacementDelegate SaveWindowPlacement;

        private Form m_parent;

        public PersistWindowPlacement(Form inParent)
        {
            this.Parent = inParent;
        }

        public PersistWindowPlacement(Form inParent,
                                  RetrieveWindowPlacementDelegate retrieveWindowPlacement,
                                  SaveWindowPlacementDelegate saveWindowPlacement)
            : this(inParent)
        {
            if (retrieveWindowPlacement != null)
            {
                RetrieveWindowPlacement += retrieveWindowPlacement;
            }
            if (saveWindowPlacement != null)
            {
                SaveWindowPlacement += saveWindowPlacement;
            }
        }

        public Form Parent
        {
            set
            {
                if (value == null)
                {
                    throw new ArgumentException();
                }
                m_parent = value;

                // subscribe to parent form's events
                m_parent.Closing += new System.ComponentModel.CancelEventHandler(OnClosing);
                m_parent.Load += new System.EventHandler(OnLoad);
            }
            get
            {
                return m_parent;
            }
        }

        private void EnsureWindowIsVisible()
        {
            if (m_parent.WindowState == FormWindowState.Normal)
            {
                Rectangle formBounds = m_parent.Bounds;
                Rectangle workingBounds = Screen.GetWorkingArea(m_parent);
                workingBounds.Inflate(-2, -2);
                bool didAdjust = false;
                int delta = workingBounds.Width - formBounds.Width;
                if (delta < 0)
                {
                    formBounds.Width += delta;
                    didAdjust = true;
                }
                delta = workingBounds.Height - formBounds.Height;
                if (delta < 0)
                {
                    formBounds.Height += delta;
                    didAdjust = true;
                }
                delta = formBounds.Left - workingBounds.X;
                if (delta < 0)
                {
                    formBounds.X += -delta;
                    didAdjust = true;
                }
                else
                {
                    delta = workingBounds.Right - formBounds.Right;
                    if (delta < 0)
                    {
                        formBounds.X += delta;
                        didAdjust = true;
                    }
                }
                delta = formBounds.Top - workingBounds.Y;
                if (delta < 0)
                {
                    formBounds.Y += -delta;
                    didAdjust = true;
                }
                else
                {
                    delta = workingBounds.Bottom - formBounds.Bottom;
                    if (delta < 0)
                    {
                        formBounds.Y += delta;
                        didAdjust = true;
                    }
                }
                if (didAdjust)
                {
                    m_parent.Bounds = formBounds;
                }
            }
        }

        private void OnClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // save position, size and state
            try
            {
                if (SaveWindowPlacement != null)
                {
                    SaveWindowState saveState = new SaveWindowState();
                    if ((m_parent.WindowState == FormWindowState.Minimized) ||
                         (m_parent.WindowState == FormWindowState.Maximized))
                    {
                        saveState.bounds = m_parent.RestoreBounds;
                    }
                    else
                    {
                        saveState.bounds = m_parent.Bounds;
                    }
                    saveState.state = (m_parent.WindowState == FormWindowState.Minimized) ? FormWindowState.Normal : m_parent.WindowState;
                    string serializedString = new SerializationUtils().BinarySerializeToString(saveState);
                    SaveWindowPlacement(this, serializedString);
                }
            }
            catch (Exception)
            {
            }
        }

        private void OnLoad(object sender, System.EventArgs e)
        {
            // attempt to read state from registry
            try
            {
                if (RetrieveWindowPlacement != null)
                {
                    string serializedString = RetrieveWindowPlacement(this);
                    if (!string.IsNullOrEmpty(serializedString))
                    {
                        SaveWindowState saveState = new SerializationUtils().BinaryDeserializeFromString<SaveWindowState>(serializedString);
                        m_parent.Visible = false;
                        m_parent.Bounds = saveState.bounds;
                        EnsureWindowIsVisible();
                        m_parent.WindowState = saveState.state;
                    }
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
