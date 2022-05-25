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
            this.checkLineButton = new System.Windows.Forms.Button();
            this.lineGroupBox = new System.Windows.Forms.GroupBox();
            this.lineCountTextBox = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.ProjectTreePage = new System.Windows.Forms.TabPage();
            this.checkButtonModel = new System.Windows.Forms.Button();
            this.reReading = new System.Windows.Forms.Button();
            this.LinePage = new System.Windows.Forms.TabPage();
            this.lineGroupBox.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.ProjectTreePage.SuspendLayout();
            this.LinePage.SuspendLayout();
            this.SuspendLayout();
            // 
            // exit_button
            // 
            this.exit_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.exit_button.Location = new System.Drawing.Point(428, 432);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(105, 40);
            this.exit_button.TabIndex = 1;
            this.exit_button.Text = "Выход";
            this.exit_button.UseVisualStyleBackColor = true;
            this.exit_button.Click += new System.EventHandler(this.exit_buttonClick);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(8, 6);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(526, 420);
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
            // checkLineButton
            // 
            this.checkLineButton.Location = new System.Drawing.Point(191, 45);
            this.checkLineButton.Name = "checkLineButton";
            this.checkLineButton.Size = new System.Drawing.Size(88, 38);
            this.checkLineButton.TabIndex = 5;
            this.checkLineButton.Text = "Проверить";
            this.checkLineButton.UseVisualStyleBackColor = true;
            this.checkLineButton.Click += new System.EventHandler(this.checkLine_Click);
            // 
            // lineGroupBox
            // 
            this.lineGroupBox.Controls.Add(this.lineCountTextBox);
            this.lineGroupBox.Controls.Add(this.sketchNameComboBox);
            this.lineGroupBox.Controls.Add(this.checkLineButton);
            this.lineGroupBox.Location = new System.Drawing.Point(6, 6);
            this.lineGroupBox.Name = "lineGroupBox";
            this.lineGroupBox.Size = new System.Drawing.Size(287, 92);
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.ProjectTreePage);
            this.tabControl1.Controls.Add(this.LinePage);
            this.tabControl1.Location = new System.Drawing.Point(0, -1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(548, 503);
            this.tabControl1.TabIndex = 7;
            // 
            // ProjectTreePage
            // 
            this.ProjectTreePage.Controls.Add(this.checkButtonModel);
            this.ProjectTreePage.Controls.Add(this.reReading);
            this.ProjectTreePage.Controls.Add(this.exit_button);
            this.ProjectTreePage.Controls.Add(this.treeView1);
            this.ProjectTreePage.Location = new System.Drawing.Point(4, 22);
            this.ProjectTreePage.Name = "ProjectTreePage";
            this.ProjectTreePage.Padding = new System.Windows.Forms.Padding(3);
            this.ProjectTreePage.Size = new System.Drawing.Size(540, 477);
            this.ProjectTreePage.TabIndex = 0;
            this.ProjectTreePage.Text = "Дерево проекта";
            this.ProjectTreePage.UseVisualStyleBackColor = true;
            // 
            // checkButtonModel
            // 
            this.checkButtonModel.Location = new System.Drawing.Point(146, 432);
            this.checkButtonModel.Name = "checkButtonModel";
            this.checkButtonModel.Size = new System.Drawing.Size(136, 40);
            this.checkButtonModel.TabIndex = 4;
            this.checkButtonModel.Text = "Проверить с исходником";
            this.checkButtonModel.UseVisualStyleBackColor = true;
            this.checkButtonModel.Click += new System.EventHandler(this.checkButtonModel_Click);
            // 
            // reReading
            // 
            this.reReading.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.reReading.Location = new System.Drawing.Point(288, 432);
            this.reReading.Name = "reReading";
            this.reReading.Size = new System.Drawing.Size(134, 40);
            this.reReading.TabIndex = 3;
            this.reReading.Text = "Повторить чтение";
            this.reReading.UseVisualStyleBackColor = true;
            this.reReading.Click += new System.EventHandler(this.reReading_Click);
            // 
            // LinePage
            // 
            this.LinePage.Controls.Add(this.lineGroupBox);
            this.LinePage.Location = new System.Drawing.Point(4, 22);
            this.LinePage.Name = "LinePage";
            this.LinePage.Padding = new System.Windows.Forms.Padding(3);
            this.LinePage.Size = new System.Drawing.Size(540, 477);
            this.LinePage.TabIndex = 1;
            this.LinePage.Text = "Отрезок";
            this.LinePage.UseVisualStyleBackColor = true;
            // 
            // ReadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 505);
            this.Controls.Add(this.tabControl1);
            this.Name = "ReadForm";
            this.Text = "ReadForm";
            this.lineGroupBox.ResumeLayout(false);
            this.lineGroupBox.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ProjectTreePage.ResumeLayout(false);
            this.LinePage.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button checkButtonModel;

        private System.Windows.Forms.Button reReading;

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage ProjectTreePage;
        private System.Windows.Forms.TabPage LinePage;

        private System.Windows.Forms.TextBox lineCountTextBox;

        private System.Windows.Forms.GroupBox lineGroupBox;

        private System.Windows.Forms.Button checkLineButton;

        private System.Windows.Forms.ComboBox sketchNameComboBox;

        private System.Windows.Forms.TreeView treeView1;

        private System.Windows.Forms.Button exit_button;

        #endregion
    }
}