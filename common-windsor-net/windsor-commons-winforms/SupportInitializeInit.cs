using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Drawing;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel;
using System.Windows.Forms;
using Windsor.Commons.Core;

namespace Windsor.Commons.WinForms
{
    public class SupportInitializeInit : DisposableBase
    {
        private ISupportInitialize _supportInitialize;

        public SupportInitializeInit(Control control)
        {
            _supportInitialize = control as ISupportInitialize;
            if ( _supportInitialize != null ) {
                _supportInitialize.BeginInit();
            }
        }
        protected override void OnDispose(bool inIsDisposing)
        {
            if (inIsDisposing)
            {
                if (_supportInitialize != null)
                {
                    _supportInitialize.EndInit();
                }
            }
        }
    }
}
