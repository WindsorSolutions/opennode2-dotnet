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
    public class LabelTextController
    {
        private Control _parentControl;
        private MemoEdit _labelWrapEditor;
        private TextEdit _labelEditor;
        private TextEdit _currentLabelEditor;
        private LabelControl _currentLabelControl;
        private string _originalLabelText;
        private List<Control> _ignoreControls;

        private static string _labelStringsFilePath;
        private static SerializationUtils _serializationUtils = new SerializationUtils();
        private static LabelStrings _labelStrings;

        public LabelTextController(Control parentControl, MemoEdit labelWrapEditor,
                                   TextEdit labelEditor, params Control[] ignoreControls)
        {
            ExceptionUtils.ThrowIfNull(parentControl, "parentControl");

            _parentControl = parentControl;
            _labelWrapEditor = labelWrapEditor;
            _labelEditor = labelEditor;
            _ignoreControls = new List<Control>(ignoreControls);

            if ((_labelWrapEditor != null) || (_labelEditor != null))
            {
                ExceptionUtils.ThrowIfNull(labelWrapEditor, "labelWrapEditor");
                ExceptionUtils.ThrowIfNull(labelEditor, "labelEditor");
            }

            if (_labelStringsFilePath == null)
            {
                _labelStringsFilePath =
                    Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "LabelStrings.xml");
            }
            CheckLoadLabelStrings();

            IList<LabelControl> controlList = ControlUtils.GetAllDeepChildrenOfType<LabelControl>(_parentControl);
            if (!CollectionUtils.IsNullOrEmpty(controlList))
            {
                List<Control> parentMouseUpList = new List<Control>();
                foreach (LabelControl control in controlList)
                {
                    string labelString = _labelStrings.GetLabel(_parentControl, control);
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
                    if (labelString != null)
                    {
                        control.Text = labelString;
                    }
                }
                if (_labelWrapEditor != null)
                {
                    _labelWrapEditor.Visible = false;
                    _labelWrapEditor.Properties.WordWrap = true;
                    _labelWrapEditor.Parent = null;
                    _labelWrapEditor.LostFocus += LabelEditor_LostFocus;
                    _labelWrapEditor.KeyDown += LabelEditor_KeyDown;
                    _labelEditor.Visible = false;
                    _labelEditor.Parent = null;
                    _labelEditor.LostFocus += LabelEditor_LostFocus;
                    _labelEditor.KeyDown += LabelEditor_KeyDown;
                }
            }
        }
        private void LabelEditor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (_currentLabelEditor != null)
                {
                    _currentLabelEditor.Text = _originalLabelText;
                    _currentLabelEditor.Visible = false;
                    _currentLabelEditor.Parent = null;
                    _currentLabelEditor = null;
                }
                if (_currentLabelControl != null)
                {
                    _currentLabelControl.Visible = true;
                    _currentLabelControl = null;
                }
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Return)
            {
                SaveLabelEditorText();
                e.SuppressKeyPress = true;
            }
        }

        private void LabelEditor_LostFocus(object sender, EventArgs e)
        {
            SaveLabelEditorText();
        }
        private void SaveLabelEditorText()
        {
            try
            {
                if (_currentLabelControl != null)
                {
                    string text = _currentLabelEditor.Text;
                    if (_originalLabelText != text)
                    {
                        _labelStrings.SetLabel(_parentControl, _currentLabelControl, text);
                        _currentLabelControl.Text = text;
                        SaveLabels();
                    }
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                if (_currentLabelControl != null)
                {
                    _currentLabelControl.Visible = true;
                    _currentLabelControl = null;
                }
                if (_currentLabelEditor != null)
                {
                    _currentLabelEditor.Visible = false;
                    _currentLabelEditor.Parent = null;
                    _currentLabelEditor = null;
                }
            }
        }
        private void parentControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                LabelControl control =
                    ControlUtils.GetDeepChildAtCursor<LabelControl>(_parentControl);
                SetCurrentEditControl(control);
            }
        }
        private void control_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                SetCurrentEditControl(sender as LabelControl);
            }
        }
        private void SetCurrentEditControl(LabelControl labelControl)
        {
            try
            {
                SaveLabelEditorText();

                if ((labelControl != null) && (_labelWrapEditor != null) && 
                    !_ignoreControls.Contains(labelControl))
                {
                    _currentLabelControl = labelControl;
                    _originalLabelText = _currentLabelControl.Text;

                    bool isWrap = (labelControl.Appearance.TextOptions.WordWrap ==
                        DevExpress.Utils.WordWrap.Wrap);

                    if (isWrap)
                    {
                        _currentLabelEditor = _labelWrapEditor;
                    }
                    else
                    {
                        _currentLabelEditor = _labelEditor;
                    }
                    _currentLabelEditor.Text = _originalLabelText;
                    Rectangle bounds = ControlUtils.GetControlBoundsInParent(labelControl, _parentControl);
                    bounds.Inflate(4, 2);
                    //bounds.Width = bounds.Width + 2;
                    ControlUtils.PlaceControlInParent(_currentLabelEditor, _parentControl, bounds);

                    _currentLabelEditor.Properties.Appearance.TextOptions.HAlignment =
                        labelControl.Appearance.TextOptions.HAlignment;
                    _currentLabelEditor.Properties.Appearance.TextOptions.WordWrap =
                        labelControl.Appearance.TextOptions.WordWrap;
                    _currentLabelEditor.Anchor = labelControl.Anchor;

                    _currentLabelEditor.Visible = true;
                    _currentLabelControl.Visible = false;
                    _currentLabelEditor.Select();
                }
            }
            catch (Exception)
            {
                if (_currentLabelControl != null)
                {
                    _currentLabelControl.Visible = true;
                    _currentLabelControl = null;
                }
                if (_currentLabelEditor != null)
                {
                    _currentLabelEditor.Visible = false;
                    _currentLabelEditor.Parent = null;
                    _currentLabelEditor = null;
                }
            }
        }

        private static void CheckLoadLabelStrings()
        {
            if ((_labelStrings == null) && (_labelStringsFilePath != null))
            {
                LoadLabels();
            }
        }
        private static void LoadLabels()
        {
            try
            {
                _labelStrings = _serializationUtils.Deserialize<LabelStrings>(_labelStringsFilePath);
            }
            catch (Exception)
            {
                _labelStrings = new LabelStrings();
            }
        }
        private static void SaveLabels()
        {
            try
            {
                if ((_labelStrings != null) && (_labelStringsFilePath != null))
                {
                    _serializationUtils.Serialize(_labelStrings, _labelStringsFilePath);
                }
            }
            catch (Exception)
            {
            }
        }

        [Serializable]
        public class LabelInfo
        {
            public string Path;

            public string Text;
        }
        [Serializable]
        public class LabelStrings
        {
            public LabelInfo[] LabelList;

            public string GetLabel(Control parent, Control child)
            {
                int index = IndexOfLabel(parent, child);
                if (index >= 0)
                {
                    return LabelList[index].Text;
                }
                else
                {
                    return null;
                }
            }
            public void SetLabel(Control parent, Control child, string text)
            {
                int index = IndexOfLabel(parent, child);
                if (index >= 0)
                {
                    LabelList[index].Text = text;
                }
                else
                {
                    LabelInfo labelInfo = new LabelInfo();
                    labelInfo.Path = MakeLabelPath(parent, child);
                    labelInfo.Text = text;
                    Array.Resize<LabelInfo>(ref LabelList, (LabelList == null) ? 1 : LabelList.Length + 1);
                    LabelList[LabelList.Length - 1] = labelInfo;
                }
            }
            private string MakeLabelPath(Control parent, Control child)
            {
                return parent.Name + "." + child.Name;
            }
            private int IndexOfLabel(Control parent, Control child)
            {
                if (!CollectionUtils.IsNullOrEmpty(LabelList))
                {

                    string path = MakeLabelPath(parent, child);
                    int index = 0;
                    foreach (LabelInfo labelInfo in LabelList)
                    {
                        if (labelInfo.Path == path)
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