#region Copyright (c) 2003-2005, Luke T. Maxon

/********************************************************************************************************************
'
' Copyright (c) 2003-2005, Luke T. Maxon
' All rights reserved.
' 
' Redistribution and use in source and binary forms, with or without modification, are permitted provided
' that the following conditions are met:
' 
' * Redistributions of source code must retain the above copyright notice, this list of conditions and the
' 	following disclaimer.
' 
' * Redistributions in binary form must reproduce the above copyright notice, this list of conditions and
' 	the following disclaimer in the documentation and/or other materials provided with the distribution.
' 
' * Neither the name of the author nor the names of its contributors may be used to endorse or 
' 	promote products derived from this software without specific prior written permission.
' 
' THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED
' WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A
' PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR
' ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
' LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
' INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
' OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN
' IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
'
'*******************************************************************************************************************/

#endregion

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MbUnit.Extensions.Forms.TestApplications
{
    /// <summary>
    /// Summary description for TextBoxTestForm.
    /// </summary>
    public class TextBoxTestForm : Form
    {
        private TextBox myTextBox;

        private TextBox anotherTextBox;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private Container components = null;

        public TextBoxTestForm()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                if(components != null)
                {
                    components.Dispose();
                }
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
            this.myTextBox = new TextBox();
            this.anotherTextBox = new TextBox();
            this.SuspendLayout();
            // 
            // myTextBox
            // 
            this.myTextBox.Location = new Point(32, 40);
            this.myTextBox.Name = "myTextBox";
            this.myTextBox.Size = new Size(208, 20);
            this.myTextBox.TabIndex = 0;
            this.myTextBox.Text = "default";
            // 
            // anotherTextBox
            // 
            this.anotherTextBox.Location = new Point(136, 184);
            this.anotherTextBox.Name = "anotherTextBox";
            this.anotherTextBox.TabIndex = 1;
            this.anotherTextBox.Text = "";
            // 
            // TextBoxTestForm
            // 
            this.AutoScaleDimensions = new SizeF(5, 13);
            this.ClientSize = new Size(292, 273);
            this.Controls.Add(this.anotherTextBox);
            this.Controls.Add(this.myTextBox);
            this.Name = "TextBoxTestForm";
            this.Text = "TextBoxTestForm";
            this.ResumeLayout(false);
        }

        #endregion
    }
}