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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.FileToolStripMenuItem, this.EditorToolStripMenuItem, this.ReadToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(415, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.ConnectionToolStripMenuItem, this.OpenToolStripMenuItem, this.SaveToolStripMenuItem, this.exitToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.FileToolStripMenuItem.Text = "Файл";
            // 
            // ConnectionToolStripMenuItem
            // 
            this.ConnectionToolStripMenuItem.Name = "ConnectionToolStripMenuItem";
            this.ConnectionToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys) (((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) | System.Windows.Forms.Keys.C)));
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
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.exitToolStripMenuItem.Text = "Выход";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // EditorToolStripMenuItem
            // 
            this.EditorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.StepDrawingToolStripMenuItem, this.FullDrawingToolStripMenuItem, this.StepDeleteToolStripMenuItem, this.FullDeleteToolStripMenuItem});
            this.EditorToolStripMenuItem.Name = "EditorToolStripMenuItem";
            this.EditorToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.EditorToolStripMenuItem.Text = "Редактор";
            // 
            // StepDrawingToolStripMenuItem
            // 
            this.StepDrawingToolStripMenuItem.Name = "StepDrawingToolStripMenuItem";
            this.StepDrawingToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys) (((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) | System.Windows.Forms.Keys.W)));
            this.StepDrawingToolStripMenuItem.Size = new System.Drawing.Size(269, 22);
            this.StepDrawingToolStripMenuItem.Text = "Поэтапное черчение";
            this.StepDrawingToolStripMenuItem.Click += new System.EventHandler(this.StepDrawingToolStripMenuItem_Click);
            // 
            // FullDrawingToolStripMenuItem
            // 
            this.FullDrawingToolStripMenuItem.Name = "FullDrawingToolStripMenuItem";
            this.FullDrawingToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys) (((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) | System.Windows.Forms.Keys.F)));
            this.FullDrawingToolStripMenuItem.Size = new System.Drawing.Size(269, 22);
            this.FullDrawingToolStripMenuItem.Text = "Начертить полностью";
            this.FullDrawingToolStripMenuItem.Click += new System.EventHandler(this.FullDrawingToolStripMenuItem_Click);
            // 
            // StepDeleteToolStripMenuItem
            // 
            this.StepDeleteToolStripMenuItem.Name = "StepDeleteToolStripMenuItem";
            this.StepDeleteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys) (((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) | System.Windows.Forms.Keys.S)));
            this.StepDeleteToolStripMenuItem.Size = new System.Drawing.Size(269, 22);
            this.StepDeleteToolStripMenuItem.Text = "Поэтапное удаление";
            this.StepDeleteToolStripMenuItem.Click += new System.EventHandler(this.StepDeleteToolStripMenuItem_Click);
            // 
            // FullDeleteToolStripMenuItem
            // 
            this.FullDeleteToolStripMenuItem.Name = "FullDeleteToolStripMenuItem";
            this.FullDeleteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys) (((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) | System.Windows.Forms.Keys.V)));
            this.FullDeleteToolStripMenuItem.Size = new System.Drawing.Size(269, 22);
            this.FullDeleteToolStripMenuItem.Text = "Полностью удалить";
            this.FullDeleteToolStripMenuItem.Click += new System.EventHandler(this.FullDeleteToolStripMenuItem_Click);
            // 
            // ReadToolStripMenuItem
            // 
            this.ReadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.TreeReadToolStripMenuItem});
            this.ReadToolStripMenuItem.Name = "ReadToolStripMenuItem";
            this.ReadToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.ReadToolStripMenuItem.Text = "Чтение";
            // 
            // TreeReadToolStripMenuItem
            // 
            this.TreeReadToolStripMenuItem.Name = "TreeReadToolStripMenuItem";
            this.TreeReadToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys) (((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) | System.Windows.Forms.Keys.R)));
            this.TreeReadToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.TreeReadToolStripMenuItem.Text = "Чтение дерева";
            this.TreeReadToolStripMenuItem.Click += new System.EventHandler(this.TreeReadToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GraduationProject.Properties.Resources.ImageTask;
            this.pictureBox1.Location = new System.Drawing.Point(34, 44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(341, 369);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // Drawing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 434);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Drawing";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

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

        private System.Windows.Forms.MenuStrip menuStrip1;

        private System.Windows.Forms.PictureBox pictureBox1;

        #endregion
    }
}