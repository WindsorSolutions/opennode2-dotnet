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
    public static class FormScaler
    {
        private static float s_EmFontScaling = 0;
        private static float s_ImageScaling = 0;
        private static float s_EmMinimumFontSize = 0;
        private static bool s_NeedsToScale;
        private const float DEFAULT_DPI = 96;
        private static Dictionary<Form, bool> s_DidScaleForms = new Dictionary<Form, bool>();

        static FormScaler()
        {
            using (Graphics graphics = Graphics.FromHwnd(IntPtr.Zero))
            {
                s_NeedsToScale = (graphics.DpiX != DEFAULT_DPI);
                s_EmFontScaling = (96f / graphics.DpiX);
                //s_EmFontScaling = (80f / graphics.DpiX); //??
                //s_NeedsToScale = true; //??
                s_ImageScaling = 1.0f;
                //IMG_FONT_SCALING = graphics.DpiX / 96f;
            }
            s_EmMinimumFontSize = 8.25f * s_EmFontScaling;
        }
        public static bool NeedsToScale
        {
            get
            {
                return s_NeedsToScale;
            }
        }
        public static float FontScalingRatio
        {
            get
            {
                return s_EmFontScaling;
            }
        }
        public static float ImageScalingRatio
        {
            get
            {
                return s_ImageScaling;
            }
        }
        public static void ScaleFonts(Form parent)
        {
            if (s_NeedsToScale)
            {
                bool isDesignMode = (bool) ReflectionUtils.GetPublicOrPrivatePropertyValue(parent, "DesignMode", false);
                if (!isDesignMode && !s_DidScaleForms.ContainsKey(parent))
                {
                    s_DidScaleForms[parent] = true;
                    ScaleFontsInt(parent);
                }
            }
        }
        private static void ScaleFontsInt(Control parent)
        {
            ScaleControlFont(parent);

            foreach (Control control in parent.Controls)
            {
                ScaleFontsInt(control);
            }
        }
        private static void ScaleControlFont(Control control)
        {
            DevExpress.XtraEditors.LabelControl label = control as DevExpress.XtraEditors.LabelControl;
            if (label != null)
            {
                label.Font = ScaleFont(label.Font);
                return;
            }
            DevExpress.XtraEditors.SimpleButton button = control as DevExpress.XtraEditors.SimpleButton;
            if (button != null)
            {
                button.Font = ScaleFont(button.Font);
                return;
            }
            DevExpress.XtraEditors.LookUpEdit lookupEdit = control as DevExpress.XtraEditors.LookUpEdit;
            if (lookupEdit != null)
            {
                lookupEdit.Font = ScaleFont(lookupEdit.Font);
                return;
            }
            DevExpress.XtraEditors.TextEdit textEdit = control as DevExpress.XtraEditors.TextEdit;
            if (textEdit != null)
            {
                textEdit.Font = ScaleFont(textEdit.Font);
                return;
            }
            DevExpress.XtraEditors.DateEdit dateEdit = control as DevExpress.XtraEditors.DateEdit;
            if (dateEdit != null)
            {
                dateEdit.Font = ScaleFont(dateEdit.Font);
                return;
            }
            DevExpress.XtraGrid.GridControl gridControl = control as DevExpress.XtraGrid.GridControl;
            if (gridControl != null)
            {
                foreach (DevExpress.XtraGrid.Views.Base.BaseView baseView in gridControl.Views)
                {
                    DevExpress.XtraGrid.Views.Grid.GridView gridView = baseView as DevExpress.XtraGrid.Views.Grid.GridView;
                    if (gridView != null)
                    {
                        gridView.Appearance.Row.Font = ScaleFont(gridView.Appearance.Row.Font);
                        gridView.Appearance.HeaderPanel.Font = ScaleFont(gridView.Appearance.HeaderPanel.Font);
                        gridView.Appearance.GroupPanel.Font = ScaleFont(gridView.Appearance.GroupPanel.Font);
                        gridView.Appearance.Empty.Font = ScaleFont(gridView.Appearance.Empty.Font);
                    }
                }
                gridControl.Font = ScaleFont(gridControl.Font);
                return;
            }
            DevExpress.XtraEditors.MemoEdit memoEdit = control as DevExpress.XtraEditors.MemoEdit;
            if (memoEdit != null)
            {
                memoEdit.Font = ScaleFont(memoEdit.Font);
                return;
            }
            DevExpress.XtraEditors.CheckEdit checkEdit = control as DevExpress.XtraEditors.CheckEdit;
            if (checkEdit != null)
            {
                checkEdit.Font = ScaleFont(checkEdit.Font);
                return;
            }
            DevExpress.XtraEditors.GroupControl groupControl = control as DevExpress.XtraEditors.GroupControl;
            if (groupControl != null)
            {
                groupControl.AppearanceCaption.Font = ScaleFont(groupControl.AppearanceCaption.Font, FontStyle.Bold);
                return;
            }
            LinkLabel linkLabel = control as LinkLabel;
            if (linkLabel != null)
            {
                linkLabel.Font = ScaleFont(linkLabel.Font);
                return;
            }
            DevExpress.XtraLayout.LayoutControl layoutControl = control as DevExpress.XtraLayout.LayoutControl;
            if (layoutControl != null)
            {
                ScaleLayoutFonts(layoutControl);
                return;
            }
        }

        public static Font ScaleFont(Font font)
        {
            return ScaleFont(font, font.Style);
        }
        public static Font ScaleFont(Font font, FontStyle fontStyle)
        {
            if (s_NeedsToScale)
            {
                float newSize = FontScalingRatio * font.Size;
                if (newSize < s_EmMinimumFontSize)
                {
                    newSize = s_EmMinimumFontSize;
                }
                return new Font(font.FontFamily, newSize, fontStyle);
            }
            return font;
        }
        private static void ScaleLayoutFonts(DevExpress.XtraLayout.LayoutControl parent)
        {
            foreach (DevExpress.XtraLayout.BaseLayoutItem item in parent.Items)
            {
                ScaleLayoutFonts(item);
            }
        }
        private static void ScaleLayoutFonts(DevExpress.XtraLayout.BaseLayoutItem parent)
        {
            DevExpress.XtraLayout.LayoutControlItem layoutItem = parent as DevExpress.XtraLayout.LayoutControlItem;
            if (layoutItem != null)
            {
                layoutItem.AppearanceItemCaption.Font = ScaleFont(layoutItem.AppearanceItemCaption.Font);
                return;
            }
            DevExpress.XtraLayout.LayoutControlGroup layoutGroup = parent as DevExpress.XtraLayout.LayoutControlGroup;
            if (layoutGroup != null)
            {
                layoutGroup.AppearanceGroup.Font = ScaleFont(layoutGroup.AppearanceGroup.Font, FontStyle.Bold);
                foreach (DevExpress.XtraLayout.BaseLayoutItem item in layoutGroup.Items)
                {
                    ScaleLayoutFonts(item);
                }
                return;
            }
        }
    }
}