using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Drawing;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using Windsor.Commons.Core;

namespace Windsor.Commons.WinForms
{
    public static class GraphicUtils
    {
        public static void Translate(GraphicsPath path, float xDelta, float yDelta)
        {
            Matrix matrix = new Matrix();
            matrix.Translate(xDelta, yDelta);
            path.Transform(matrix);
        }
    }
}
