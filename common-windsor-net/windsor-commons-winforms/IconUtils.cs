using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.IO;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;

namespace Windsor.Commons.WinForms
{
    public static class IconUtils
    {
        public enum StandardIconType {
            Undefined = 0,
            Error,
            Information,
            Warning,
            Question,
            Shield
        }
        public static Icon GetStandardSystemIcon(StandardIconType type)
        {
        }
    }
}
