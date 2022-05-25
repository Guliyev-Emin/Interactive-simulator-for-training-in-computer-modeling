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
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // benchmarkData
            // 
            this.benchmarkData.Location = new System.Drawing.Point(12, 12);
            this.benchmarkData.Multiline = true;
            this.benchmarkData.Name = "benchmarkData";
            this.benchmarkData.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.benchmarkData.Size = new System.Drawing.Size(360, 437);
            this.benchmarkData.TabIndex = 0;
            this.benchmarkData.WordWrap = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(412, 12);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox2.Size = new System.Drawing.Size(360, 437);
            this.textBox2.TabIndex = 1;
            this.textBox2.WordWrap = false;
            // 
            // QualityControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.benchmarkData);
            this.Name = "QualityControl";
            this.Text = "QualityControl";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox benchmarkData;
        private System.Windows.Forms.TextBox textBox2;

        #endregion
    }
}