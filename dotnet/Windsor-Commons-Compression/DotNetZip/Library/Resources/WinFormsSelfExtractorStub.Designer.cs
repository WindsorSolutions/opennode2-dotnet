#region License
/*
Copyright (c) 2009, The Environmental Council of the States (ECOS)
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions
are met:

 * Redistributions of source code must retain the above copyright
   notice, this list of conditions and the following disclaimer.
 * Redistributions in binary form must reproduce the above copyright
   notice, this list of conditions and the following disclaimer in the
   documentation and/or other materials provided with the distribution.
 * Neither the name of the ECOS nor the names of its contributors may
   be used to endorse or promote products derived from this software
   without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
"AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS
FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE
COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT,
INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING,
BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT
LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN
ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
POSSIBILITY OF SUCH DAMAGE.
*/
#endregion

﻿namespace Ionic.Utils.Zip
{
    partial class WinFormsSelfExtractorStub
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WinFormsSelfExtractorStub));
            this.btnExtract = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtExtractDirectory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDirBrowse = new System.Windows.Forms.Button();
            this.chk_Overwrite = new System.Windows.Forms.CheckBox();
            this.chk_OpenExplorer = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.btnContents = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnExtract
            // 
            this.btnExtract.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExtract.Location = new System.Drawing.Point(386, 209);
            this.btnExtract.Name = "btnExtract";
            this.btnExtract.Size = new System.Drawing.Size(60, 23);
            this.btnExtract.TabIndex = 0;
            this.btnExtract.Text = "Extract";
            this.btnExtract.UseVisualStyleBackColor = true;
            this.btnExtract.Click += new System.EventHandler(this.btnExtract_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(452, 209);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(60, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtExtractDirectory
            // 
            this.txtExtractDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExtractDirectory.Location = new System.Drawing.Point(8, 135);
            this.txtExtractDirectory.Name = "txtExtractDirectory";
            this.txtExtractDirectory.Size = new System.Drawing.Size(473, 20);
            this.txtExtractDirectory.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Extract to Directory:";
            // 
            // btnDirBrowse
            // 
            this.btnDirBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDirBrowse.Location = new System.Drawing.Point(487, 132);
            this.btnDirBrowse.Name = "btnDirBrowse";
            this.btnDirBrowse.Size = new System.Drawing.Size(25, 23);
            this.btnDirBrowse.TabIndex = 4;
            this.btnDirBrowse.Text = "...";
            this.btnDirBrowse.UseVisualStyleBackColor = true;
            this.btnDirBrowse.Click += new System.EventHandler(this.btnDirBrowse_Click);
            // 
            // chk_Overwrite
            // 
            this.chk_Overwrite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chk_Overwrite.AutoSize = true;
            this.chk_Overwrite.Location = new System.Drawing.Point(11, 161);
            this.chk_Overwrite.Name = "chk_Overwrite";
            this.chk_Overwrite.Size = new System.Drawing.Size(130, 17);
            this.chk_Overwrite.TabIndex = 6;
            this.chk_Overwrite.Text = "Overwrite existing files";
            this.chk_Overwrite.UseVisualStyleBackColor = true;
            // 
            // chk_OpenExplorer
            // 
            this.chk_OpenExplorer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chk_OpenExplorer.AutoSize = true;
            this.chk_OpenExplorer.Checked = true;
            this.chk_OpenExplorer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_OpenExplorer.Location = new System.Drawing.Point(11, 180);
            this.chk_OpenExplorer.Name = "chk_OpenExplorer";
            this.chk_OpenExplorer.Size = new System.Drawing.Size(152, 17);
            this.chk_OpenExplorer.TabIndex = 7;
            this.chk_OpenExplorer.Text = "Open Explorer after extract";
            this.chk_OpenExplorer.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Zip Comment: ";
            // 
            // txtComment
            // 
            this.txtComment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComment.Location = new System.Drawing.Point(8, 22);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.ReadOnly = true;
            this.txtComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtComment.Size = new System.Drawing.Size(504, 86);
            this.txtComment.TabIndex = 9;
            // 
            // btnContents
            // 
            this.btnContents.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnContents.Location = new System.Drawing.Point(290, 209);
            this.btnContents.Name = "btnContents";
            this.btnContents.Size = new System.Drawing.Size(90, 23);
            this.btnContents.TabIndex = 10;
            this.btnContents.Text = "Show Contents";
            this.btnContents.UseVisualStyleBackColor = true;
            this.btnContents.Click += new System.EventHandler(this.btnContents_Click);
            // 
            // WinFormsSelfExtractorStub
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 244);
            this.Controls.Add(this.btnContents);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chk_OpenExplorer);
            this.Controls.Add(this.chk_Overwrite);
            this.Controls.Add(this.btnDirBrowse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtExtractDirectory);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnExtract);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WinFormsSelfExtractorStub";
            this.Text = "DotNetZip Self-extractor (www.codeplex.com/DotNetZip)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExtract;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtExtractDirectory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDirBrowse;
        private System.Windows.Forms.CheckBox chk_Overwrite;
        private System.Windows.Forms.CheckBox chk_OpenExplorer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Button btnContents;
    }
}