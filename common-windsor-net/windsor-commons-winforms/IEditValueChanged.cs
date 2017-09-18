using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Diagnostics;

namespace Windsor.Commons.WinForms
{
    public interface IEditValueChanged
    {
        event EventHandler EditValueChanged;
    }
}