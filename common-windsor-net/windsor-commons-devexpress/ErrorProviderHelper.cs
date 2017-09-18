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
    public class ErrorProviderHelper
    {
        private DXErrorProvider m_ErrorProvider;
        private bool m_Enabled = true;
        private MultiDictionary<BaseEdit, BaseEdit> m_AssociatedControls;

        public ErrorProviderHelper(Control parentControl, DXErrorProvider errorProvider)
        {
            Init(parentControl);
            m_ErrorProvider = errorProvider;
        }
        public bool Enabled
        {
            get
            {
                return m_Enabled;
            }
            set
            {
                m_Enabled = value;
            }
        }

        public void AssociateControls(Control control1, Control control2, params Control[] moreControls)
        {
            List<BaseEdit> controls = new List<BaseEdit>(2 + moreControls.Length);
            BaseEdit baseEdit = control1 as BaseEdit;
            if (baseEdit != null)
            {
                controls.Add(baseEdit);
            }
            else
            {
                ControlUtils.GetAllDeepChildrenOfType<BaseEdit>(control1, controls);
            }
            baseEdit = control2 as BaseEdit;
            if (baseEdit != null)
            {
                controls.Add(baseEdit);
            }
            else
            {
                ControlUtils.GetAllDeepChildrenOfType<BaseEdit>(control2, controls);
            }
            CollectionUtils.ForEach(moreControls, delegate(Control control)
            {
                baseEdit = control as BaseEdit;
                if (baseEdit != null)
                {
                    controls.Add(baseEdit);
                }
                else
                {
                    ControlUtils.GetAllDeepChildrenOfType<BaseEdit>(control, controls);
                }
            });
            AssociateControls(controls);
        }
        public void AssociateEditControls(BaseEdit control1, BaseEdit control2, params BaseEdit[] moreControls)
        {
            if (m_AssociatedControls == null)
            {
                m_AssociatedControls = new MultiDictionary<BaseEdit, BaseEdit>(true);
            }
            List<BaseEdit> controls = new List<BaseEdit>(2 + moreControls.Length);
            controls.Add(control1);
            controls.Add(control2);
            controls.AddRange(moreControls);
            AssociateControls(controls);
        }
        private void AssociateControls(IEnumerable<BaseEdit> controls)
        {
            if (m_AssociatedControls == null)
            {
                m_AssociatedControls = new MultiDictionary<BaseEdit, BaseEdit>(true);
            }
            foreach (BaseEdit keyControl in controls)
            {
                foreach (BaseEdit valueControl in controls)
                {
                    if (keyControl != valueControl)
                    {
                        m_AssociatedControls.Add(keyControl, valueControl);
                    }
                }
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
                    baseEdit.EnabledChanged += BaseEdit_EnabledChanged;
                }
                else
                {
                    Init(control);
                }
            }
        }

        private void BaseEdit_EnabledChanged(object sender, EventArgs e)
        {
            RemoveError(sender);
        }

        private void BaseEdit_EditValueChanged(object sender, EventArgs e)
        {
            RemoveError(sender);
        }
        private void RemoveError(object sender)
        {
            if ((m_ErrorProvider != null) && Enabled)
            {
                BaseEdit control = sender as BaseEdit;
                if (control != null)
                {
                    m_ErrorProvider.SetError(control, string.Empty);
                    if ((m_AssociatedControls != null) && m_AssociatedControls.ContainsKey(control))
                    {
                        foreach (BaseEdit associatedControl in m_AssociatedControls[control])
                        {
                            m_ErrorProvider.SetError(associatedControl, string.Empty);
                        }
                    }
                }
            }
        }
    }
    public static class DXErrorProviderExtensions
    {
        public static void SetErrorFormat(this DXErrorProvider errorProvider, Control control, string errorText, params object[] args)
        {
            errorProvider.SetError(control, string.Format(errorText, args));
        }
    }
}