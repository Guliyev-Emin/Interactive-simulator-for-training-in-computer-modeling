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
            this.SolidWorksProjectTree = new System.Windows.Forms.TreeView();
            this.modelControllerTab = new System.Windows.Forms.TabControl();
            this.ProjectTreePage = new System.Windows.Forms.TabPage();
            this.writeToFile = new System.Windows.Forms.Button();
            this.reReading = new System.Windows.Forms.Button();
            this.QualityControllPage = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.initialModelPropertiesGroupBox = new System.Windows.Forms.GroupBox();
            this.initialModelPropertiesTextBox = new System.Windows.Forms.TextBox();
            this.userModelProperties = new System.Windows.Forms.GroupBox();
            this.userModelPropertiesTextBox = new System.Windows.Forms.TextBox();
            this.correctQualityTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.correctQualityResultGroupBox = new System.Windows.Forms.GroupBox();
            this.correctQualityResultTextBox = new System.Windows.Forms.TextBox();
            this.errorQualityResultGroupBox = new System.Windows.Forms.GroupBox();
            this.errorQualityResultTextBox = new System.Windows.Forms.TextBox();
            this.modelControllerTab.SuspendLayout();
            this.ProjectTreePage.SuspendLayout();
            this.QualityControllPage.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.initialModelPropertiesGroupBox.SuspendLayout();
            this.userModelProperties.SuspendLayout();
            this.correctQualityTablePanel.SuspendLayout();
            this.correctQualityResultGroupBox.SuspendLayout();
            this.errorQualityResultGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // exit_button
            // 
            this.exit_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.exit_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exit_button.Location = new System.Drawing.Point(269, 348);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(105, 40);
            this.exit_button.TabIndex = 1;
            this.exit_button.Text = "Выход";
            this.exit_button.UseVisualStyleBackColor = true;
            this.exit_button.Click += new System.EventHandler(this.exit_buttonClick);
            // 
            // SolidWorksProjectTree
            // 
            this.SolidWorksProjectTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.SolidWorksProjectTree.Location = new System.Drawing.Point(8, 6);
            this.SolidWorksProjectTree.Name = "SolidWorksProjectTree";
            this.SolidWorksProjectTree.Size = new System.Drawing.Size(722, 336);
            this.SolidWorksProjectTree.TabIndex = 2;
            // 
            // modelControllerTab
            // 
            this.modelControllerTab.Controls.Add(this.ProjectTreePage);
            this.modelControllerTab.Controls.Add(this.QualityControllPage);
            this.modelControllerTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.modelControllerTab.Location = new System.Drawing.Point(0, 0);
            this.modelControllerTab.Name = "modelControllerTab";
            this.modelControllerTab.SelectedIndex = 0;
            this.modelControllerTab.Size = new System.Drawing.Size(746, 420);
            this.modelControllerTab.TabIndex = 7;
            // 
            // ProjectTreePage
            // 
            this.ProjectTreePage.Controls.Add(this.writeToFile);
            this.ProjectTreePage.Controls.Add(this.reReading);
            this.ProjectTreePage.Controls.Add(this.exit_button);
            this.ProjectTreePage.Controls.Add(this.SolidWorksProjectTree);
            this.ProjectTreePage.Location = new System.Drawing.Point(4, 22);
            this.ProjectTreePage.Name = "ProjectTreePage";
            this.ProjectTreePage.Padding = new System.Windows.Forms.Padding(3);
            this.ProjectTreePage.Size = new System.Drawing.Size(738, 394);
            this.ProjectTreePage.TabIndex = 0;
            this.ProjectTreePage.Text = "Дерево проекта";
            this.ProjectTreePage.UseVisualStyleBackColor = true;
            // 
            // writeToFile
            // 
            this.writeToFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.writeToFile.Location = new System.Drawing.Point(8, 348);
            this.writeToFile.Name = "writeToFile";
            this.writeToFile.Size = new System.Drawing.Size(115, 40);
            this.writeToFile.TabIndex = 5;
            this.writeToFile.Text = "Записать в файл";
            this.writeToFile.UseVisualStyleBackColor = true;
            this.writeToFile.Click += new System.EventHandler(this.writeToFile_Click);
            // 
            // reReading
            // 
            this.reReading.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.reReading.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.reReading.Location = new System.Drawing.Point(129, 348);
            this.reReading.Name = "reReading";
            this.reReading.Size = new System.Drawing.Size(134, 40);
            this.reReading.TabIndex = 3;
            this.reReading.Text = "Повторить чтение";
            this.reReading.UseVisualStyleBackColor = true;
            this.reReading.Click += new System.EventHandler(this.reReading_Click);
            // 
            // QualityControllPage
            // 
            this.QualityControllPage.AutoScroll = true;
            this.QualityControllPage.Controls.Add(this.button1);
            this.QualityControllPage.Controls.Add(this.tableLayoutPanel1);
            this.QualityControllPage.Location = new System.Drawing.Point(4, 22);
            this.QualityControllPage.Name = "QualityControllPage";
            this.QualityControllPage.Size = new System.Drawing.Size(738, 394);
            this.QualityControllPage.TabIndex = 1;
            this.QualityControllPage.Text = "Контроль качества";
            this.QualityControllPage.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(658, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 24);
            this.button1.TabIndex = 1;
            this.button1.Text = "Проверка";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.initialModelPropertiesGroupBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.userModelProperties, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.correctQualityTablePanel, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 383F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(644, 383);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // initialModelPropertiesGroupBox
            // 
            this.initialModelPropertiesGroupBox.Controls.Add(this.initialModelPropertiesTextBox);
            this.initialModelPropertiesGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.initialModelPropertiesGroupBox.Location = new System.Drawing.Point(3, 3);
            this.initialModelPropertiesGroupBox.Name = "initialModelPropertiesGroupBox";
            this.initialModelPropertiesGroupBox.Size = new System.Drawing.Size(208, 377);
            this.initialModelPropertiesGroupBox.TabIndex = 0;
            this.initialModelPropertiesGroupBox.TabStop = false;
            this.initialModelPropertiesGroupBox.Text = "Параметры правильной модели";
            // 
            // initialModelPropertiesTextBox
            // 
            this.initialModelPropertiesTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.initialModelPropertiesTextBox.Location = new System.Drawing.Point(3, 16);
            this.initialModelPropertiesTextBox.Multiline = true;
            this.initialModelPropertiesTextBox.Name = "initialModelPropertiesTextBox";
            this.initialModelPropertiesTextBox.ReadOnly = true;
            this.initialModelPropertiesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.initialModelPropertiesTextBox.Size = new System.Drawing.Size(202, 358);
            this.initialModelPropertiesTextBox.TabIndex = 0;
            // 
            // userModelProperties
            // 
            this.userModelProperties.Controls.Add(this.userModelPropertiesTextBox);
            this.userModelProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userModelProperties.Location = new System.Drawing.Point(217, 3);
            this.userModelProperties.Name = "userModelProperties";
            this.userModelProperties.Size = new System.Drawing.Size(208, 377);
            this.userModelProperties.TabIndex = 1;
            this.userModelProperties.TabStop = false;
            this.userModelProperties.Text = "Параметры пользовательской модели";
            // 
            // userModelPropertiesTextBox
            // 
            this.userModelPropertiesTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userModelPropertiesTextBox.Location = new System.Drawing.Point(3, 16);
            this.userModelPropertiesTextBox.Multiline = true;
            this.userModelPropertiesTextBox.Name = "userModelPropertiesTextBox";
            this.userModelPropertiesTextBox.ReadOnly = true;
            this.userModelPropertiesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.userModelPropertiesTextBox.Size = new System.Drawing.Size(202, 358);
            this.userModelPropertiesTextBox.TabIndex = 0;
            // 
            // correctQualityTablePanel
            // 
            this.correctQualityTablePanel.ColumnCount = 1;
            this.correctQualityTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.correctQualityTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.correctQualityTablePanel.Controls.Add(this.correctQualityResultGroupBox, 0, 0);
            this.correctQualityTablePanel.Controls.Add(this.errorQualityResultGroupBox, 0, 1);
            this.correctQualityTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.correctQualityTablePanel.Location = new System.Drawing.Point(431, 3);
            this.correctQualityTablePanel.Name = "correctQualityTablePanel";
            this.correctQualityTablePanel.RowCount = 2;
            this.correctQualityTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.correctQualityTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.correctQualityTablePanel.Size = new System.Drawing.Size(210, 377);
            this.correctQualityTablePanel.TabIndex = 2;
            // 
            // correctQualityResultGroupBox
            // 
            this.correctQualityResultGroupBox.Controls.Add(this.correctQualityResultTextBox);
            this.correctQualityResultGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.correctQualityResultGroupBox.Location = new System.Drawing.Point(3, 3);
            this.correctQualityResultGroupBox.Name = "correctQualityResultGroupBox";
            this.correctQualityResultGroupBox.Size = new System.Drawing.Size(204, 182);
            this.correctQualityResultGroupBox.TabIndex = 0;
            this.correctQualityResultGroupBox.TabStop = false;
            this.correctQualityResultGroupBox.Text = "Правильные элементы";
            // 
            // correctQualityResultTextBox
            // 
            this.correctQualityResultTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.correctQualityResultTextBox.Location = new System.Drawing.Point(3, 16);
            this.correctQualityResultTextBox.Multiline = true;
            this.correctQualityResultTextBox.Name = "correctQualityResultTextBox";
            this.correctQualityResultTextBox.ReadOnly = true;
            this.correctQualityResultTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.correctQualityResultTextBox.Size = new System.Drawing.Size(198, 163);
            this.correctQualityResultTextBox.TabIndex = 0;
            // 
            // errorQualityResultGroupBox
            // 
            this.errorQualityResultGroupBox.Controls.Add(this.errorQualityResultTextBox);
            this.errorQualityResultGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.errorQualityResultGroupBox.Location = new System.Drawing.Point(3, 191);
            this.errorQualityResultGroupBox.Name = "errorQualityResultGroupBox";
            this.errorQualityResultGroupBox.Size = new System.Drawing.Size(204, 183);
            this.errorQualityResultGroupBox.TabIndex = 1;
            this.errorQualityResultGroupBox.TabStop = false;
            this.errorQualityResultGroupBox.Text = "Неверные элементы";
            // 
            // errorQualityResultTextBox
            // 
            this.errorQualityResultTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.errorQualityResultTextBox.Location = new System.Drawing.Point(3, 16);
            this.errorQualityResultTextBox.Multiline = true;
            this.errorQualityResultTextBox.Name = "errorQualityResultTextBox";
            this.errorQualityResultTextBox.ReadOnly = true;
            this.errorQualityResultTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.errorQualityResultTextBox.Size = new System.Drawing.Size(198, 164);
            this.errorQualityResultTextBox.TabIndex = 0;
            // 
            // ReadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 420);
            this.Controls.Add(this.modelControllerTab);
            this.Name = "ReadForm";
            this.Text = "ReadForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.modelControllerTab.ResumeLayout(false);
            this.ProjectTreePage.ResumeLayout(false);
            this.QualityControllPage.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.initialModelPropertiesGroupBox.ResumeLayout(false);
            this.initialModelPropertiesGroupBox.PerformLayout();
            this.userModelProperties.ResumeLayout(false);
            this.userModelProperties.PerformLayout();
            this.correctQualityTablePanel.ResumeLayout(false);
            this.correctQualityResultGroupBox.ResumeLayout(false);
            this.correctQualityResultGroupBox.PerformLayout();
            this.errorQualityResultGroupBox.ResumeLayout(false);
            this.errorQualityResultGroupBox.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.TextBox errorQualityResultTextBox;

        private System.Windows.Forms.GroupBox errorQualityResultGroupBox;

        private System.Windows.Forms.TextBox correctQualityResultTextBox;

        private System.Windows.Forms.GroupBox correctQualityResultGroupBox;

        private System.Windows.Forms.TableLayoutPanel correctQualityTablePanel;

        private System.Windows.Forms.TextBox userModelPropertiesTextBox;

        private System.Windows.Forms.GroupBox userModelProperties;

        private System.Windows.Forms.TextBox initialModelPropertiesTextBox;

        private System.Windows.Forms.GroupBox initialModelPropertiesGroupBox;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

        private System.Windows.Forms.TabPage QualityControllPage;

        private System.Windows.Forms.Button writeToFile;

        private System.Windows.Forms.Button reReading;

        private System.Windows.Forms.TabControl modelControllerTab;
        private System.Windows.Forms.TabPage ProjectTreePage;

        private System.Windows.Forms.TreeView SolidWorksProjectTree;

        private System.Windows.Forms.Button exit_button;

        #endregion
    }
}