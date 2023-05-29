using System;
using System.Drawing;
using System.Windows.Forms;

namespace GraduationProject
{
    partial class MainForm
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StepDrawingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FullDrawingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StepDeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FullDeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeReadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProjectTabControl = new System.Windows.Forms.TabControl();
            this.Rendering = new System.Windows.Forms.TabPage();
            this.Reading = new System.Windows.Forms.TabPage();
            this.readingSolidWorksProjectButton = new System.Windows.Forms.Button();
            this.saveModelButton = new System.Windows.Forms.Button();
            this.SolidWorksProjectTree = new System.Windows.Forms.TreeView();
            this.Validation = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.modelValidationButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.initialModelPropertiesGroupBox = new System.Windows.Forms.GroupBox();
            this.initialModelPropertiesTextBox = new System.Windows.Forms.TextBox();
            this.userModelProperties = new System.Windows.Forms.GroupBox();
            this.userModelPropertiesTextBox = new System.Windows.Forms.TextBox();
            this.correctQualityTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.correctQualityResultGroupBox = new System.Windows.Forms.GroupBox();
            this.correctQualityResultTreeView = new System.Windows.Forms.TreeView();
            this.errorQualityResultGroupBox = new System.Windows.Forms.GroupBox();
            this.errorQualityResultTreeView = new System.Windows.Forms.TreeView();
            this.menuStrip.SuspendLayout();
            this.ProjectTabControl.SuspendLayout();
            this.Reading.SuspendLayout();
            this.Validation.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.initialModelPropertiesGroupBox.SuspendLayout();
            this.userModelProperties.SuspendLayout();
            this.correctQualityTablePanel.SuspendLayout();
            this.correctQualityResultGroupBox.SuspendLayout();
            this.errorQualityResultGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.FileToolStripMenuItem, this.EditorToolStripMenuItem, this.ReadToolStripMenuItem });
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(734, 24);
            this.menuStrip.TabIndex = 7;
            this.menuStrip.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.ConnectionToolStripMenuItem, this.OpenToolStripMenuItem, this.SaveToolStripMenuItem, this.exitToolStripMenuItem });
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.FileToolStripMenuItem.Text = "Файл";
            // 
            // ConnectionToolStripMenuItem
            // 
            this.ConnectionToolStripMenuItem.Name = "ConnectionToolStripMenuItem";
            this.ConnectionToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) | System.Windows.Forms.Keys.C)));
            this.ConnectionToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.ConnectionToolStripMenuItem.Text = "Подключиться";
            this.ConnectionToolStripMenuItem.Click += new System.EventHandler(this.ConnectionToolStripMenuItem_Click);
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.OpenToolStripMenuItem.Text = "Открыть";
            this.OpenToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.SaveToolStripMenuItem.Text = "Сохранить";
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) | System.Windows.Forms.Keys.W)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.exitToolStripMenuItem.Text = "Выход";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // EditorToolStripMenuItem
            // 
            this.EditorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.StepDrawingToolStripMenuItem, this.FullDrawingToolStripMenuItem, this.StepDeleteToolStripMenuItem, this.FullDeleteToolStripMenuItem });
            this.EditorToolStripMenuItem.Name = "EditorToolStripMenuItem";
            this.EditorToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.EditorToolStripMenuItem.Text = "Редактор";
            // 
            // StepDrawingToolStripMenuItem
            // 
            this.StepDrawingToolStripMenuItem.Name = "StepDrawingToolStripMenuItem";
            this.StepDrawingToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) | System.Windows.Forms.Keys.Y)));
            this.StepDrawingToolStripMenuItem.Size = new System.Drawing.Size(269, 22);
            this.StepDrawingToolStripMenuItem.Text = "Поэтапное черчение";
            this.StepDrawingToolStripMenuItem.Click += new System.EventHandler(this.StepDrawingToolStripMenuItem_Click);
            // 
            // FullDrawingToolStripMenuItem
            // 
            this.FullDrawingToolStripMenuItem.Name = "FullDrawingToolStripMenuItem";
            this.FullDrawingToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) | System.Windows.Forms.Keys.F)));
            this.FullDrawingToolStripMenuItem.Size = new System.Drawing.Size(269, 22);
            this.FullDrawingToolStripMenuItem.Text = "Начертить полностью";
            this.FullDrawingToolStripMenuItem.Click += new System.EventHandler(this.FullDrawingToolStripMenuItem_Click);
            // 
            // StepDeleteToolStripMenuItem
            // 
            this.StepDeleteToolStripMenuItem.Name = "StepDeleteToolStripMenuItem";
            this.StepDeleteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) | System.Windows.Forms.Keys.S)));
            this.StepDeleteToolStripMenuItem.Size = new System.Drawing.Size(269, 22);
            this.StepDeleteToolStripMenuItem.Text = "Поэтапное удаление";
            this.StepDeleteToolStripMenuItem.Click += new System.EventHandler(this.StepDeleteToolStripMenuItem_Click);
            // 
            // FullDeleteToolStripMenuItem
            // 
            this.FullDeleteToolStripMenuItem.Name = "FullDeleteToolStripMenuItem";
            this.FullDeleteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) | System.Windows.Forms.Keys.V)));
            this.FullDeleteToolStripMenuItem.Size = new System.Drawing.Size(269, 22);
            this.FullDeleteToolStripMenuItem.Text = "Полностью удалить";
            this.FullDeleteToolStripMenuItem.Click += new System.EventHandler(this.FullDeleteToolStripMenuItem_Click);
            // 
            // ReadToolStripMenuItem
            // 
            this.ReadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.TreeReadToolStripMenuItem });
            this.ReadToolStripMenuItem.Name = "ReadToolStripMenuItem";
            this.ReadToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.ReadToolStripMenuItem.Text = "Чтение";
            // 
            // TreeReadToolStripMenuItem
            // 
            this.TreeReadToolStripMenuItem.Name = "TreeReadToolStripMenuItem";
            this.TreeReadToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) | System.Windows.Forms.Keys.R)));
            this.TreeReadToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.TreeReadToolStripMenuItem.Text = "Чтение дерева";
            this.TreeReadToolStripMenuItem.Click += new System.EventHandler(this.TreeReadToolStripMenuItem_Click);
            // 
            // ProjectTabControl
            // 
            this.ProjectTabControl.Controls.Add(this.Rendering);
            this.ProjectTabControl.Controls.Add(this.Reading);
            this.ProjectTabControl.Controls.Add(this.Validation);
            this.ProjectTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProjectTabControl.Location = new System.Drawing.Point(0, 24);
            this.ProjectTabControl.Name = "ProjectTabControl";
            this.ProjectTabControl.SelectedIndex = 0;
            this.ProjectTabControl.Size = new System.Drawing.Size(734, 387);
            this.ProjectTabControl.TabIndex = 8;
            // 
            // Rendering
            // 
            this.Rendering.AutoScroll = true;
            this.Rendering.Location = new System.Drawing.Point(4, 22);
            this.Rendering.Name = "Rendering";
            this.Rendering.Padding = new System.Windows.Forms.Padding(3);
            this.Rendering.Size = new System.Drawing.Size(726, 361);
            this.Rendering.TabIndex = 0;
            this.Rendering.Text = "Отрисовка";
            this.Rendering.UseVisualStyleBackColor = true;
            // 
            // Reading
            // 
            this.Reading.AutoScroll = true;
            this.Reading.Controls.Add(this.readingSolidWorksProjectButton);
            this.Reading.Controls.Add(this.saveModelButton);
            this.Reading.Controls.Add(this.SolidWorksProjectTree);
            this.Reading.Location = new System.Drawing.Point(4, 22);
            this.Reading.Name = "Reading";
            this.Reading.Padding = new System.Windows.Forms.Padding(3);
            this.Reading.Size = new System.Drawing.Size(726, 361);
            this.Reading.TabIndex = 1;
            this.Reading.Text = "Инфо. модели";
            this.Reading.UseVisualStyleBackColor = true;
            // 
            // readingSolidWorksProjectButton
            // 
            this.readingSolidWorksProjectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.readingSolidWorksProjectButton.Location = new System.Drawing.Point(615, 6);
            this.readingSolidWorksProjectButton.Name = "readingSolidWorksProjectButton";
            this.readingSolidWorksProjectButton.Size = new System.Drawing.Size(108, 30);
            this.readingSolidWorksProjectButton.TabIndex = 2;
            this.readingSolidWorksProjectButton.Text = "Чтение модели";
            this.readingSolidWorksProjectButton.UseVisualStyleBackColor = true;
            this.readingSolidWorksProjectButton.Click += new System.EventHandler(this.readingSolidWorksProjectButton_Click);
            // 
            // saveModelButton
            // 
            this.saveModelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveModelButton.Location = new System.Drawing.Point(615, 42);
            this.saveModelButton.Name = "saveModelButton";
            this.saveModelButton.Size = new System.Drawing.Size(108, 28);
            this.saveModelButton.TabIndex = 1;
            this.saveModelButton.Text = "Сохранить";
            this.saveModelButton.UseVisualStyleBackColor = true;
            this.saveModelButton.Click += new System.EventHandler(this.saveModelButton_Click);
            // 
            // SolidWorksProjectTree
            // 
            this.SolidWorksProjectTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.SolidWorksProjectTree.Location = new System.Drawing.Point(3, 3);
            this.SolidWorksProjectTree.Name = "SolidWorksProjectTree";
            this.SolidWorksProjectTree.Size = new System.Drawing.Size(606, 355);
            this.SolidWorksProjectTree.TabIndex = 0;
            // 
            // Validation
            // 
            this.Validation.Controls.Add(this.button1);
            this.Validation.Controls.Add(this.modelValidationButton);
            this.Validation.Controls.Add(this.tableLayoutPanel1);
            this.Validation.Location = new System.Drawing.Point(4, 22);
            this.Validation.Name = "Validation";
            this.Validation.Size = new System.Drawing.Size(726, 361);
            this.Validation.TabIndex = 2;
            this.Validation.Text = "Проверка на правильность";
            this.Validation.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(615, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 35);
            this.button1.TabIndex = 3;
            this.button1.Text = "Отдельная проверка";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // modelValidationButton
            // 
            this.modelValidationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.modelValidationButton.Location = new System.Drawing.Point(615, 47);
            this.modelValidationButton.Name = "modelValidationButton";
            this.modelValidationButton.Size = new System.Drawing.Size(108, 38);
            this.modelValidationButton.TabIndex = 2;
            this.modelValidationButton.Text = "Быстрая проверка";
            this.modelValidationButton.UseVisualStyleBackColor = true;
            this.modelValidationButton.Click += new System.EventHandler(this.modelValidationButton_Click);
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 360F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(609, 360);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // initialModelPropertiesGroupBox
            // 
            this.initialModelPropertiesGroupBox.Controls.Add(this.initialModelPropertiesTextBox);
            this.initialModelPropertiesGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.initialModelPropertiesGroupBox.Location = new System.Drawing.Point(3, 3);
            this.initialModelPropertiesGroupBox.Name = "initialModelPropertiesGroupBox";
            this.initialModelPropertiesGroupBox.Size = new System.Drawing.Size(197, 354);
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
            this.initialModelPropertiesTextBox.Size = new System.Drawing.Size(191, 335);
            this.initialModelPropertiesTextBox.TabIndex = 0;
            this.initialModelPropertiesTextBox.WordWrap = false;
            // 
            // userModelProperties
            // 
            this.userModelProperties.Controls.Add(this.userModelPropertiesTextBox);
            this.userModelProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userModelProperties.Location = new System.Drawing.Point(206, 3);
            this.userModelProperties.Name = "userModelProperties";
            this.userModelProperties.Size = new System.Drawing.Size(197, 354);
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
            this.userModelPropertiesTextBox.Size = new System.Drawing.Size(191, 335);
            this.userModelPropertiesTextBox.TabIndex = 0;
            this.userModelPropertiesTextBox.WordWrap = false;
            // 
            // correctQualityTablePanel
            // 
            this.correctQualityTablePanel.ColumnCount = 1;
            this.correctQualityTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.correctQualityTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.correctQualityTablePanel.Controls.Add(this.correctQualityResultGroupBox, 0, 0);
            this.correctQualityTablePanel.Controls.Add(this.errorQualityResultGroupBox, 0, 1);
            this.correctQualityTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.correctQualityTablePanel.Location = new System.Drawing.Point(409, 3);
            this.correctQualityTablePanel.Name = "correctQualityTablePanel";
            this.correctQualityTablePanel.RowCount = 2;
            this.correctQualityTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.correctQualityTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.correctQualityTablePanel.Size = new System.Drawing.Size(197, 354);
            this.correctQualityTablePanel.TabIndex = 2;
            // 
            // correctQualityResultGroupBox
            // 
            this.correctQualityResultGroupBox.Controls.Add(this.correctQualityResultTreeView);
            this.correctQualityResultGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.correctQualityResultGroupBox.Location = new System.Drawing.Point(3, 3);
            this.correctQualityResultGroupBox.Name = "correctQualityResultGroupBox";
            this.correctQualityResultGroupBox.Size = new System.Drawing.Size(191, 171);
            this.correctQualityResultGroupBox.TabIndex = 0;
            this.correctQualityResultGroupBox.TabStop = false;
            this.correctQualityResultGroupBox.Text = "Правильные элементы";
            // 
            // correctQualityResultTreeView
            // 
            this.correctQualityResultTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.correctQualityResultTreeView.Location = new System.Drawing.Point(3, 16);
            this.correctQualityResultTreeView.Name = "correctQualityResultTreeView";
            this.correctQualityResultTreeView.Size = new System.Drawing.Size(185, 152);
            this.correctQualityResultTreeView.TabIndex = 0;
            // 
            // errorQualityResultGroupBox
            // 
            this.errorQualityResultGroupBox.Controls.Add(this.errorQualityResultTreeView);
            this.errorQualityResultGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.errorQualityResultGroupBox.Location = new System.Drawing.Point(3, 180);
            this.errorQualityResultGroupBox.Name = "errorQualityResultGroupBox";
            this.errorQualityResultGroupBox.Size = new System.Drawing.Size(191, 171);
            this.errorQualityResultGroupBox.TabIndex = 1;
            this.errorQualityResultGroupBox.TabStop = false;
            this.errorQualityResultGroupBox.Text = "Неверные элементы";
            // 
            // errorQualityResultTreeView
            // 
            this.errorQualityResultTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.errorQualityResultTreeView.Location = new System.Drawing.Point(3, 16);
            this.errorQualityResultTreeView.Name = "errorQualityResultTreeView";
            this.errorQualityResultTreeView.Size = new System.Drawing.Size(185, 152);
            this.errorQualityResultTreeView.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 411);
            this.Controls.Add(this.ProjectTabControl);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(750, 450);
            this.Name = "MainForm";
            this.Text = "Контроль моделей";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ProjectTabControl.ResumeLayout(false);
            this.Reading.ResumeLayout(false);
            this.Validation.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.initialModelPropertiesGroupBox.ResumeLayout(false);
            this.initialModelPropertiesGroupBox.PerformLayout();
            this.userModelProperties.ResumeLayout(false);
            this.userModelProperties.PerformLayout();
            this.correctQualityTablePanel.ResumeLayout(false);
            this.correctQualityResultGroupBox.ResumeLayout(false);
            this.errorQualityResultGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.TreeView errorQualityResultTreeView;

        private System.Windows.Forms.TreeView correctQualityResultTreeView;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox initialModelPropertiesGroupBox;
        private System.Windows.Forms.TextBox initialModelPropertiesTextBox;
        private System.Windows.Forms.GroupBox userModelProperties;
        private System.Windows.Forms.TextBox userModelPropertiesTextBox;
        private System.Windows.Forms.TableLayoutPanel correctQualityTablePanel;
        private System.Windows.Forms.GroupBox correctQualityResultGroupBox;
        private System.Windows.Forms.GroupBox errorQualityResultGroupBox;
        private System.Windows.Forms.Button modelValidationButton;

        private System.Windows.Forms.Button saveModelButton;
        private System.Windows.Forms.Button readingSolidWorksProjectButton;

        private System.Windows.Forms.TreeView SolidWorksProjectTree;

        private System.Windows.Forms.TabPage Validation;

        private System.Windows.Forms.TabControl ProjectTabControl;
        private System.Windows.Forms.TabPage Rendering;
        private System.Windows.Forms.TabPage Reading;

        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem StepDeleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FullDeleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ReadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TreeReadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ConnectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FullDrawingToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem StepDrawingToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;

        private System.Windows.Forms.MenuStrip menuStrip;

        #endregion
    }
}