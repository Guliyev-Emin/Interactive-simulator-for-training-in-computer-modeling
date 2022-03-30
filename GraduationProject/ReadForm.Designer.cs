using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace GraduationProject
{
    partial class ReadForm
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
            this.exit_button = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // exit_button
            // 
            this.exit_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.exit_button.Location = new System.Drawing.Point(404, 444);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(150, 50);
            this.exit_button.TabIndex = 1;
            this.exit_button.Text = "Выход";
            this.exit_button.UseVisualStyleBackColor = true;
            this.exit_button.Click += new EventHandler(this.exit_buttonClick);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 12);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(539, 426);
            this.treeView1.TabIndex = 2;
            // 
            // ReadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 497);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.exit_button);
            this.Name = "ReadForm";
            this.Text = "ReadForm";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TreeView treeView1;

        private System.Windows.Forms.Button exit_button;

        #endregion
    }
}