using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Windsor.Commons.DeveloperExpress
{
    public partial class ToastForm : BaseScalableForm
    {
#region Variables

        /// <summary>
        /// The list of currently open ToastForms.
        /// </summary>
        private static List<ToastForm> openForms = new List<ToastForm>();
        private static int maxNumConcurrentOpenForms = 10;

        /// <summary>
        /// Indicates whether the form can receive focus or not.
        /// </summary>
        private bool allowFocus = false;
        /// <summary>
        /// The object that creates the sliding animation.
        /// </summary>
        private FormAnimator animator;
        /// <summary>
        /// The handle of the window that currently has focus.
        /// </summary>
        private IntPtr currentForegroundWindow;

        private bool closeOnLinkClicked = true;

#endregion // Variables

#region APIs

        /// <summary>
        /// Gets the handle of the window that currently has focus.
        /// </summary>
        /// <returns>
        /// The handle of the window that currently has focus.
        /// </returns>
        [DllImport("user32")]
        private static extern IntPtr GetForegroundWindow();

        /// <summary>
        /// Activates the specified window.
        /// </summary>
        /// <param name="hWnd">
        /// The handle of the window to be focused.
        /// </param>
        /// <returns>
        /// True if the window was focused; False otherwise.
        /// </returns>
        [DllImport("user32")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

#endregion // APIs

#region Constructors

        /// <summary>
        /// Creates a new ToastForm object that is displayed for the specified length of time.
        /// </summary>
        /// <param name="lifeTime">
        /// The length of time, in milliseconds, that the form will be displayed.
        /// </param>
        public ToastForm()
        {
            InitializeComponent();

            if (!this.DesignMode)
            {
                this.Load += new System.EventHandler(this.ToastForm_Load);
                this.Shown += new System.EventHandler(this.ToastForm_Shown);
                this.Activated += new System.EventHandler(this.ToastForm_Activated);
                this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ToastForm_FormClosed);
                
                // Set the time for which the form should be displayed and the message to display.
                this.lifeTimer.Interval = 5000;

                // Display the form by sliding up.
                this.animator = new FormAnimator(this,
                                                 FormAnimator.AnimationMethod.Slide,
                                                 FormAnimator.AnimationDirection.Up,
                                                 500);
            }
        }

#endregion // Constructors

#region Methods

        public static int MaxNumConcurrentOpenForms
        {
            get { return ToastForm.maxNumConcurrentOpenForms; }
            set { ToastForm.maxNumConcurrentOpenForms = value; }
        }

        public delegate void LinkClickedHandler(object linkTag);
        public event LinkClickedHandler LinkClicked;

        /// <summary>
        /// Displays the form.
        /// </summary>
        /// <remarks>
        /// Required to allow the form to determine the current foreground window before being displayed.
        /// </remarks>
        public void ShowPopup(string messageText, string linkText, object linkTag, Image messageImage, 
                              int timeout)
        {
            // Determine the current foreground window so it can be reactivated each time this form tries to get the focus.
            currentForegroundWindow = GetForegroundWindow();

            if (!string.IsNullOrEmpty(linkText))
            {
                linkLabel.Text = linkText;
                linkLabel.Tag = linkTag;
                linkLabel.Click += linkLabel_Click;
            }
            else
            {
                messageLabel.Height = messageLabel.Height + (linkLabel.Bottom - messageLabel.Bottom);
                linkLabel.Visible = false;
            }
            imageControl.Text = string.Empty;
            if (messageImage != null)
            {
                imageControl.Appearance.Image = messageImage;
            }
            else
            {
                messageLabel.Top = messageLabel.Top - (messageLabel.Top - imageControl.Top);
                imageControl.Visible = false;
            }
            messageLabel.Text = messageText;

            if (timeout < 0)
            {
            }
            else
            {
                lifeTimer.Interval = timeout;
                lifeTimer.Start();
            }
            // Display the form.
            base.Show();
        }

        private void linkLabel_Click(object sender, EventArgs e)
        {
            if (closeOnLinkClicked)
            {
                CloseViaAnimator(this);
            }
            if (LinkClicked != null)
            {
                LinkClicked(linkLabel.Tag);
            }
        }

#endregion // Methods

#region Event Handlers

        private void ToastForm_Load(object sender, EventArgs e)
        {
            this.Height = linkLabel.Bottom + (this.Bounds.Height - this.ClientRectangle.Height) + 8;

            // Display the form just above the system tray.
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width - 5,
                                      Screen.PrimaryScreen.WorkingArea.Height - this.Height - 5);

            if (openForms.Count >= maxNumConcurrentOpenForms)
            {
                for (int i = openForms.Count - maxNumConcurrentOpenForms; i >= 0; --i)
                {
                    ToastForm formToClose = openForms[i];
                    CloseViaAnimator(formToClose);
                }
            }

            // Move each open form upwards to make room for this one.
            foreach (ToastForm openForm in ToastForm.openForms)
            {
                openForm.Top -= this.Height + 5;
            }

            // Add this form from the open form list.
            ToastForm.openForms.Add(this);
        }

        private void ToastForm_Activated(object sender, EventArgs e)
        {
            // Prevent the form taking focus when it is initially shown.
            if (!this.allowFocus)
            {
                // Activate the window that previously had the focus.
                SetForegroundWindow(this.currentForegroundWindow);
            }
        }

        private void ToastForm_Shown(object sender, EventArgs e)
        {
            // Once the animation has completed the form can receive focus.
            this.allowFocus = true;

            // Close the form by sliding down.
            this.animator.Direction = FormAnimator.AnimationDirection.Down;
        }

        private void ToastForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Move down any open forms above this one.
            foreach (ToastForm openForm in ToastForm.openForms)
            {
                if (openForm == this)
                {
                    // The remaining forms are below this one.
                    break;
                }

                openForm.Top += this.Height + 5;
            }

            // Remove this form from the open form list.
            ToastForm.openForms.Remove(this);
        }

        private void lifeTimer_Tick(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                // The form's lifetime has expired.
                CloseViaAnimator(this);
            }
        }
        private void CloseViaAnimator(ToastForm form)
        {
            form.animator.Duration = form.animator.Duration / 3;
            form.Close();
        }
        protected override void WndProc(ref Message message)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MOVE = 0xF010;

            switch (message.Msg)
            {
                case WM_SYSCOMMAND:
                    // Disable dragging window by title bar
                    int command = message.WParam.ToInt32() & 0xfff0;
                    if (command == SC_MOVE)
                    {
                        return;
                    }
                    break;
            }

            base.WndProc(ref message);
        }

    #endregion // Event Handlers
    }
}