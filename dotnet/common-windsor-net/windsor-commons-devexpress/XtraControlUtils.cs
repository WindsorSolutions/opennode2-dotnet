using XTRA_MSG_BOX = Windsor.Commons.DeveloperExpress.XtraMessageBoxEx;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Drawing;
using Windsor.Commons.Core;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using Windsor.Commons.WinForms;

namespace Windsor.Commons.DeveloperExpress
{
    public static class XtraControlUtils
    {
        public static void FocusAndSelectAll(this DevExpress.XtraEditors.TextEdit textEdit)
        {
            textEdit.Focus();
            textEdit.SelectAll();
            //textEdit.SelectionStart = 0;
            //textEdit.SelectionLength = textEdit.Text.Length;
        }
        public static void FocusAndSelectAll(this DevExpress.XtraEditors.LabelControl label)
        {
            label.Focus();
            label.Select();
            //textEdit.SelectionStart = 0;
            //textEdit.SelectionLength = textEdit.Text.Length;
        }
    }
}