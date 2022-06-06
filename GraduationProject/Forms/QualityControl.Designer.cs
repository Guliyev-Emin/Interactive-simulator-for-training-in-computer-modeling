using System.ComponentModel;
using System.Windows.Forms;

namespace GraduationProject
{
    partial class QualityControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.benchmarkData = new System.Windows.Forms.TextBox();
            this.userDataRichTextBox = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // benchmarkData
            // 
            this.benchmarkData.Location = new System.Drawing.Point(12, 12);
            this.benchmarkData.Multiline = true;
            this.benchmarkData.Name = "benchmarkData";
            this.benchmarkData.ReadOnly = true;
            this.benchmarkData.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.benchmarkData.Size = new System.Drawing.Size(360, 437);
            this.benchmarkData.TabIndex = 0;
            this.benchmarkData.WordWrap = false;
            // 
            // userDataRichTextBox
            // 
            this.userDataRichTextBox.Location = new System.Drawing.Point(412, 12);
            this.userDataRichTextBox.Name = "userDataRichTextBox";
            this.userDataRichTextBox.ReadOnly = true;
            this.userDataRichTextBox.Size = new System.Drawing.Size(359, 437);
            this.userDataRichTextBox.TabIndex = 1;
            this.userDataRichTextBox.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(777, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // QualityControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 461);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.userDataRichTextBox);
            this.Controls.Add(this.benchmarkData);
            this.Name = "QualityControl";
            this.Text = "QualityControl";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.RichTextBox userDataRichTextBox;

        private System.Windows.Forms.TextBox benchmarkData;

        #endregion
    }
}