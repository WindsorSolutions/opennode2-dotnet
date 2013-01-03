using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Diagnostics;
using Windsor.Commons.WinForms;
using Windsor.Commons.Core;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using Wintellect.PowerCollections;

namespace Windsor.Commons.DeveloperExpress
{
    public class ControlValuesChangedHelper
    {
        private bool m_AnyControlsChanged;
        private bool m_IsEnabled = true;

        public ControlValuesChangedHelper(Control parentControl)
        {
            Init(parentControl);
        }
        public bool AnyControlsChanged
        {
            get
            {
                return m_AnyControlsChanged;
            }
            set
            {
                m_AnyControlsChanged = value;
            }
        }

        public bool IsEnabled
        {
            get
            {
                return m_IsEnabled;
            }
            set
            {
                m_IsEnabled = value;
            }
        }

        private void Init(Control parentControl)
        {
            foreach (Control control in parentControl.Controls)
            {
                BaseEdit baseEdit = control as BaseEdit;
                if (baseEdit != null)
                {
                    baseEdit.EditValueChanged += BaseEdit_EditValueChanged;
                }
                else
                {
                    IEditValueChanged editValueChanged = control as IEditValueChanged;
                    if (editValueChanged != null)
                    {
                        editValueChanged.EditValueChanged += new EventHandler(editValueChanged_EditValueChanged);
                    }
                    else
                    {
                        Init(control);
                    }
                }
            }
        }

        void editValueChanged_EditValueChanged(object sender, EventArgs e)
        {
            m_AnyControlsChanged = true;
        }

        private void BaseEdit_EditValueChanged(object sender, EventArgs e)
        {
            m_AnyControlsChanged = true;
        }
    }
}