using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Drawing;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections.Generic;
using Windsor.Commons.Core;


namespace Windsor.Commons.WinForms
{
    public static class ControlUtils
    {
        public static void SetAutoScrollMinSizeToControls(ScrollableControl scrollableControl,
                                                          Control controlToIterate)
        {
            int maxY = 0, maxX = 0;

            foreach (Control control in controlToIterate.Controls)
            {
                if (control.Visible)
                {
                    if (control.Bounds.Bottom > maxY)
                    {
                        maxY = control.Bounds.Bottom;
                    }
                    if (control.Bounds.Right > maxX)
                    {
                        maxX = control.Bounds.Right;
                    }
                }
            }
            scrollableControl.AutoScrollMinSize = new Size(0, maxY);
        }
        public static void CenterControl(Control containerControl, Control controlToCenter)
        {
            int x = (containerControl.Width - controlToCenter.Width) / 2;
            int y = (containerControl.Height - controlToCenter.Height) / 2;
            controlToCenter.Location = new Point(x, y);
        }
        public static Rectangle GetChildControlsBoundingBox(Control parent)
        {
            int top = int.MaxValue, left = int.MaxValue, bottom = int.MinValue, right = int.MinValue;

            foreach (Control control in parent.Controls)
            {
                if (control.Visible)
                {
                    if (control.Bounds.Top < top)
                    {
                        top = control.Bounds.Top;
                    }
                    if (control.Bounds.Bottom > bottom)
                    {
                        bottom = control.Bounds.Bottom;
                    }
                    if (control.Bounds.Left < left)
                    {
                        left = control.Bounds.Left;
                    }
                    if (control.Bounds.Right > right)
                    {
                        right = control.Bounds.Right;
                    }
                }
            }

            return (top == int.MaxValue) ? Rectangle.Empty : new Rectangle(left, top, right, bottom);
        }
        public static void CenterControlsVertically(params Control[] controls)
        {
            if (CollectionUtils.IsNullOrEmpty(controls) || (controls.Length == 1))
            {
                return;
            }
            int minY = controls[0].Top, maxY = controls[0].Bottom;
            for (int i = 1; i < controls.Length; ++i)
            {
                Control control = controls[i];
                if (control.Top < minY)
                {
                    minY = control.Top;
                }
                if (control.Bottom > maxY)
                {
                    maxY = control.Bottom;
                }
            }
            int verticalGap = maxY - minY;
            foreach (Control control in controls)
            {
                control.Top = minY + ((verticalGap - control.Height + 1) / 2);
            }
        }
        public static Control GetDeepChildAtPoint(Control parent, Point point)
        {
            return GetDeepChildAtPoint<Control>(parent, point);
        }
        /// <summary>
        /// Return the deepest subcontrol of parent that is of type T.
        /// </summary>
        public static T GetDeepChildAtPoint<T>(Control parent, Point point) where T : Control
        {
            Control control = parent.GetChildAtPoint(point);
            if (control != null)
            {
                T rtnControl = control as T;
                Point childPoint = control.PointToClient(parent.PointToScreen(point));
                T childControl = GetDeepChildAtPoint<T>(control, childPoint);
                if (childControl != null)
                {
                    return childControl;
                }
                else
                {
                    return rtnControl;
                }
            }
            else
            {
                return null;
            }
        }
        public static Control GetDeepChildAtCursor(Control parent)
        {
            return GetDeepChildAtPoint(parent, parent.PointToClient(Cursor.Position));
        }
        public static T GetDeepChildAtCursor<T>(Control parent) where T : Control
        {
            return GetDeepChildAtPoint<T>(parent, parent.PointToClient(Cursor.Position));
        }
        public static IList<T> GetAllDeepChildrenOfType<T>(Control parent) where T : Control
        {
            List<T> list = new List<T>();
            GetAllDeepChildrenOfType(parent, list);
            return list;
        }
        public static T GetFirstDeepChildOfType<T>(Control parent) where T : Control
        {
            List<T> list = new List<T>();
            GetAllDeepChildrenOfType(parent, list);
            return CollectionUtils.IsNullOrEmpty(list) ? null : list[0];
        }
        public static Rectangle GetControlBoundsInParent(Control control, Control parent)
        {
            Rectangle bounds = control.Bounds;
            bounds.Offset(-bounds.Left, -bounds.Top);
            bounds = control.RectangleToScreen(bounds);
            return parent.RectangleToClient(bounds);
        }
        public static void PlaceControlInParent(Control control, Control parent,
                                                Rectangle bounds)
        {
            control.Parent = parent;
            parent.Controls.SetChildIndex(control, 0/*parent.Controls.Count - 1*/);
            control.Bounds = bounds;
        }
        public static T GetDeepChildWithName<T>(Control parent, string name) where T : Control
        {
            foreach (Control control in parent.Controls)
            {
                T rtnControl = control as T;
                if (rtnControl != null)
                {
                    if (rtnControl.Name == name)
                    {
                        return rtnControl;
                    }
                }
                T foundControl = GetDeepChildWithName<T>(control, name);
                if (foundControl != null)
                {
                    return foundControl;
                }
            }
            return null;
        }
        public static char GetSystemPasswordChar()
        {
            using (TextBox textBox = new TextBox())
            {
                textBox.UseSystemPasswordChar = true;
                return textBox.PasswordChar;
            }
        }
        private static void GetAllDeepChildrenOfType<T>(Control parent, List<T> list) where T : Control
        {
            foreach (Control control in parent.Controls)
            {
                T rtnControl = control as T;
                if (rtnControl != null)
                {
                    list.Add(rtnControl);
                }
                GetAllDeepChildrenOfType<T>(control, list);
            }
        }
        public static bool SetDeepChildText(Control parent, string childName, string text)
        {
            foreach (Control control in parent.Controls)
            {
                if (control.Name == childName)
                {
                    control.Text = text;
                    return true;
                }
            }
            foreach (Control control in parent.Controls)
            {
                if (SetDeepChildText(control, childName, text))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
