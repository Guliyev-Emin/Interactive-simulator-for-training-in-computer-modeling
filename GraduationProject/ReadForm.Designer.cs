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
            this.sketchNameComboBox = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.lineGroupBox = new System.Windows.Forms.GroupBox();
            this.lineCountTextBox = new System.Windows.Forms.TextBox();
            this.lineGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // exit_button
            // 
            this.exit_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.exit_button.Location = new System.Drawing.Point(401, 444);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(150, 50);
            this.exit_button.TabIndex = 1;
            this.exit_button.Text = "Выход";
            this.exit_button.UseVisualStyleBackColor = true;
            this.exit_button.Click += new System.EventHandler(this.exit_buttonClick);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 12);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(539, 426);
            this.treeView1.TabIndex = 2;
            // 
            // sketchNameComboBox
            // 
            this.sketchNameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sketchNameComboBox.FormattingEnabled = true;
            this.sketchNameComboBox.Location = new System.Drawing.Point(6, 19);
            this.sketchNameComboBox.Name = "sketchNameComboBox";
            this.sketchNameComboBox.Size = new System.Drawing.Size(135, 21);
            this.sketchNameComboBox.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(191, 45);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 38);
            this.button2.TabIndex = 5;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lineGroupBox
            // 
            this.lineGroupBox.Controls.Add(this.lineCountTextBox);
            this.lineGroupBox.Controls.Add(this.sketchNameComboBox);
            this.lineGroupBox.Controls.Add(this.button2);
            this.lineGroupBox.Location = new System.Drawing.Point(557, 12);
            this.lineGroupBox.Name = "lineGroupBox";
            this.lineGroupBox.Size = new System.Drawing.Size(287, 89);
            this.lineGroupBox.TabIndex = 6;
            this.lineGroupBox.TabStop = false;
            this.lineGroupBox.Text = "Отрезок";
            // 
            // lineCountTextBox
            // 
            this.lineCountTextBox.Location = new System.Drawing.Point(147, 19);
            this.lineCountTextBox.Name = "lineCountTextBox";
            this.lineCountTextBox.Size = new System.Drawing.Size(132, 20);
            this.lineCountTextBox.TabIndex = 6;
            // 
            // ReadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 497);
            this.Controls.Add(this.lineGroupBox);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.exit_button);
            this.Name = "ReadForm";
            this.Text = "ReadForm";
            this.lineGroupBox.ResumeLayout(false);
            this.lineGroupBox.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TextBox lineCountTextBox;

        private System.Windows.Forms.GroupBox lineGroupBox;

        private System.Windows.Forms.Button button2;

        private System.Windows.Forms.ComboBox sketchNameComboBox;

        private System.Windows.Forms.TreeView treeView1;

        private System.Windows.Forms.Button exit_button;

        #endregion
    }
}