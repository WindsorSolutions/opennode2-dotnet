using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Drawing;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel;
using System.Windows.Forms;
using Windsor.Commons.Core;
using System.Collections.Generic;

namespace Windsor.Commons.WinForms
{
    public class UseWaitCursor : DisposableBase
    {
        private static List<UseWaitCursor> s_CurrentUseWaitCursors = new List<UseWaitCursor>();
        private Dictionary<Form, Cursor> m_InitialFormCursors = new Dictionary<Form, Cursor>();

        public UseWaitCursor()
        {
            s_CurrentUseWaitCursors.Add(this);
            foreach (Form form in Application.OpenForms)
            {
                m_InitialFormCursors[form] = form.Cursor;
                form.Cursor = Cursors.WaitCursor;
            }
        }
        protected override void OnDispose(bool inIsDisposing)
        {
            if (inIsDisposing)
            {
                foreach (Form form in Application.OpenForms)
                {
                    Cursor cursor;
                    if (!m_InitialFormCursors.TryGetValue(form, out cursor))
                    {
                        cursor = Cursors.Arrow;
                    }
                    form.Cursor = cursor;
                }
                s_CurrentUseWaitCursors.Remove(this);
            }
        }
        public static void ClearAllWaitCursors()
        {
            for (int i = s_CurrentUseWaitCursors.Count - 1; i >= 0; --i)
            {
                DisposableBase.SafeDispose(s_CurrentUseWaitCursors[i]);
            }
            s_CurrentUseWaitCursors.Clear();
        }
    }
}
