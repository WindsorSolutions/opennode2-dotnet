using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Diagnostics;
using System.Reflection;
using Windsor.Commons.WinForms;
using Windsor.Commons.Core;
using DevExpress.XtraEditors;

namespace Windsor.Commons.DeveloperExpress
{
    public class HelpTextController
    {
        private Control _parentControl;
        private Control _helpLabel;
        private string _lastText;
        private MemoEdit _helpLabelEditor;
        private System.Windows.Forms.Timer _timer;
        private Control _currentEditControl;
        private string _originalToolTipText;
        private List<Control> _ignoreControls;
        private Dictionary<Control, string> _tooltips = new Dictionary<Control,string>();

        private static string _toolTipFilePath;
        private static SerializationUtils _serializationUtils = new SerializationUtils();
        private static ToolTipStrings _toolTipStrings;

        public HelpTextController(Control parentControl, Control helpLabel, MemoEdit helpLabelEditor,
                                  params Control[] ignoreControls)
        {
            _parentControl = parentControl;
            _helpLabel = helpLabel;
            _helpLabelEditor = helpLabelEditor;
            _ignoreControls = new List<Control>(ignoreControls);

            if (_toolTipFilePath == null)
            {
                _toolTipFilePath =
                    Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "ToolTipStrings.xml");
            }
            CheckLoadToolTips();

            IList<Control> controlList = ControlUtils.GetAllDeepChildrenOfType<Control>(_parentControl);
            if (!CollectionUtils.IsNullOrEmpty(controlList))
            {
                List<Control> parentMouseUpList = new List<Control>();
                foreach (Control control in controlList)
                {
                    if (IsValidToolTipTextEditControl(control))
                    {
                        string toolTip = _toolTipStrings.GetToolTip(_parentControl, control);
                        if (_helpLabelEditor != null)
                        {
                            if (toolTip == null)
                            {
                                toolTip = control.Name;
                            }
                            control.MouseUp += control_MouseUp;
                            Control parent = control.Parent;
                            while (parent != null)
                            {
                                if (!parentMouseUpList.Contains(parent))
                                {
                                    parent.MouseUp += parentControl_MouseUp;
                                    parentMouseUpList.Add(parent);
                                }
                                parent = parent.Parent;
                            }
                        }
                        SetControlTooltip(control, toolTip);
                    }
                }
                if (_helpLabelEditor != null)
                {
                    _helpLabelEditor.Bounds = _helpLabel.Bounds;
                    _helpLabelEditor.Visible = false;
                    _helpLabel.Visible = true;
                    _helpLabelEditor.LostFocus += HelpLabelEditor_LostFocus;
                    _helpLabelEditor.KeyDown += HelpLabelEditor_KeyDown;
                }
            }
            if (_parentControl != null)
            {
                _parentControl.Disposed += ParentControl_Disposed;
                _timer = new Timer();
                _timer.Interval = 200;
                _timer.Tick += new EventHandler(timer_Tick);
                _timer.Enabled = true;
            }
        }

        void ParentControl_Disposed(object sender, EventArgs e)
        {
            try
            {
                if (_timer != null)
                {
                    _timer.Enabled = false;
                }
                _parentControl = null;
            }
            catch (Exception)
            {
            }
        }

        private bool IsValidToolTipTextEditControl(Control control)
        {
            if ( (control != null) &&
                ((control is BaseControl) || (control is DataGridView)) ) {
                return ((control != _helpLabelEditor) && (control != _helpLabel) && !(control is LabelControl) &&
                        !_ignoreControls.Contains(control));
            }
            return false;
        }
        private void HelpLabelEditor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                _currentEditControl = null;
                _helpLabelEditor.Text = _originalToolTipText;
                _helpLabelEditor.Visible = false;
                _helpLabel.Visible = true;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Return)
            {
                SaveHelpLabelEditorText();
                e.SuppressKeyPress = true;
            }
        }

        private void HelpLabelEditor_LostFocus(object sender, EventArgs e)
        {
            SaveHelpLabelEditorText();
        }
        private void SaveHelpLabelEditorText()
        {
            try
            {
                if (_currentEditControl != null)
                {
                    if (_helpLabelEditor != null)
                    {
                        string toolTipText = _helpLabelEditor.Text;
                        if (_originalToolTipText != toolTipText)
                        {
                            _toolTipStrings.SetToolTip(_parentControl, _currentEditControl,
                                                       toolTipText);
                            SetControlTooltip(_currentEditControl, toolTipText);
                            SaveToolTips();
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                _currentEditControl = null;
                if (_helpLabelEditor != null)
                {
                    _helpLabelEditor.Visible = false;
                }
                _helpLabel.Visible = true;
            }
        }
        private void parentControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                Control control =
                    ControlUtils.GetDeepChildAtCursor<Control>(_parentControl);
                if (IsValidToolTipTextEditControl(control))
                {
                    SetCurrentEditControl(control);
                }
            }
        }
        private void control_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                SetCurrentEditControl(sender as Control);
            }
        }
        private string GetControlTooltip(Control control)
        {
            string tooltip = null;
            _tooltips.TryGetValue(control, out tooltip);
            return tooltip;
        }
        private void SetControlTooltip(Control control, string tooltip)
        {
            _tooltips[control] = tooltip;
        }
        private void SetCurrentEditControl(Control baseControl)
        {
            try
            {
                SaveHelpLabelEditorText();

                if ((baseControl != null) && (_helpLabelEditor != null) && 
                    IsValidToolTipTextEditControl(baseControl))
                {
                    _currentEditControl = baseControl;
                    _originalToolTipText = GetControlTooltip(_currentEditControl);
                    _helpLabelEditor.Text = _originalToolTipText;
                    _helpLabelEditor.Visible = true;
                    _helpLabel.Visible = false;
                    _helpLabelEditor.Select();
                }
            }
            catch (Exception)
            {
                _currentEditControl = null;
                if (_helpLabelEditor != null)
                {
                    _helpLabelEditor.Visible = false;
                }
                _helpLabel.Visible = true;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            string text = null;
            if ((_parentControl != null) && _parentControl.Visible)
            {
                Control control =
                    ControlUtils.GetDeepChildAtCursor<Control>(_parentControl);
                if (IsValidToolTipTextEditControl(control))
                {
                    text = GetControlTooltip(control);
                }
            }
            if (!string.Equals(_lastText, text))
            {
                _lastText = text;
                _helpLabel.Text = text;
            }
        }
        private static void CheckLoadToolTips()
        {
            if ((_toolTipStrings == null) && (_toolTipFilePath != null))
            {
                LoadToolTips();
            }
        }
        private static void LoadToolTips()
        {
            try
            {
                _toolTipStrings = _serializationUtils.Deserialize<ToolTipStrings>(_toolTipFilePath);
            }
            catch (Exception)
            {
                _toolTipStrings = new ToolTipStrings();
            }
        }
        private static void SaveToolTips()
        {
            try
            {
                if ((_toolTipStrings != null) && (_toolTipFilePath != null))
                {
                    _serializationUtils.Serialize(_toolTipStrings, _toolTipFilePath);
                }
            }
            catch (Exception)
            {
            }
        }

        [Serializable]
        public class ToolTipInfo
        {
            public string Path;

            public string ToolTip;
        }
        [Serializable]
        public class ToolTipStrings
        {
            public ToolTipInfo[] ToolTipList;

            public string GetToolTip(Control parent, Control child)
            {
                int index = IndexOfToolTip(parent, child);
                if (index >= 0)
                {
                    return ToolTipList[index].ToolTip;
                }
                else
                {
                    return null;
                }
            }
            public void SetToolTip(Control parent, Control child, string toolTip)
            {
                int index = IndexOfToolTip(parent, child);
                if (index >= 0)
                {
                    ToolTipList[index].ToolTip = toolTip;
                }
                else
                {
                    ToolTipInfo toolTipInfo = new ToolTipInfo();
                    toolTipInfo.Path = MakeToolTipPath(parent, child);
                    toolTipInfo.ToolTip = toolTip;
                    Array.Resize<ToolTipInfo>(ref ToolTipList, (ToolTipList == null) ? 1 : ToolTipList.Length + 1);
                    ToolTipList[ToolTipList.Length - 1] = toolTipInfo;
                }
            }
            private string MakeToolTipPath(Control parent, Control child)
            {
                return parent.Name + "." + child.Name;
            }
            private int IndexOfToolTip(Control parent, Control child)
            {
                if (!CollectionUtils.IsNullOrEmpty(ToolTipList))
                {
                    string path = MakeToolTipPath(parent, child);
                    int index = 0;
                    foreach (ToolTipInfo toolTipInfo in ToolTipList)
                    {
                        if (toolTipInfo.Path == path)
                        {
                            return index;
                        }
                        ++index;
                    }
                }
                return -1;
            }
        }
    }
}