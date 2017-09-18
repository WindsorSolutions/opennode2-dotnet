namespace Windsor.Commons.DeveloperExpress
{
    partial class ToastForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lifeTimer = new System.Windows.Forms.Timer(this.components);
            this.messageLabel = new DevExpress.XtraEditors.LabelControl();
            this.linkLabel = new System.Windows.Forms.LinkLabel();
            this.imageControl = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // lifeTimer
            // 
            this.lifeTimer.Tick += new System.EventHandler(this.lifeTimer_Tick);
            // 
            // messageLabel
            // 
            this.messageLabel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.messageLabel.Appearance.Options.UseFont = true;
            this.messageLabel.Appearance.Options.UseTextOptions = true;
            this.messageLabel.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.messageLabel.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.messageLabel.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.messageLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.messageLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.messageLabel.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.messageLabel.Location = new System.Drawing.Point(0, 38);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.messageLabel.Size = new System.Drawing.Size(347, 29);
            this.messageLabel.TabIndex = 0;
            this.messageLabel.Text = "labelControl1";
            // 
            // linkLabel
            // 
            this.linkLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.linkLabel.Location = new System.Drawing.Point(0, 67);
            this.linkLabel.Margin = new System.Windows.Forms.Padding(0);
            this.linkLabel.Name = "linkLabel";
            this.linkLabel.Size = new System.Drawing.Size(347, 13);
            this.linkLabel.TabIndex = 1;
            this.linkLabel.TabStop = true;
            this.linkLabel.Text = "linkLabel1";
            this.linkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imageControl
            // 
            this.imageControl.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.imageControl.Appearance.Options.UseFont = true;
            this.imageControl.Appearance.Options.UseTextOptions = true;
            this.imageControl.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.imageControl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.imageControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.imageControl.Location = new System.Drawing.Point(0, 0);
            this.imageControl.Name = "imageControl";
            this.imageControl.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.imageControl.Size = new System.Drawing.Size(347, 38);
            this.imageControl.TabIndex = 2;
            this.imageControl.Text = "imageControl1";
            // 
            // ToastForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 128);
            this.Controls.Add(this.linkLabel);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.imageControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ToastForm";
            this.ShowInTaskbar = false;
            this.Text = "Toast Form";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer lifeTimer;
        private global::DevExpress.XtraEditors.LabelControl messageLabel;
        private System.Windows.Forms.LinkLabel linkLabel;
        private DevExpress.XtraEditors.LabelControl imageControl;
    }
}