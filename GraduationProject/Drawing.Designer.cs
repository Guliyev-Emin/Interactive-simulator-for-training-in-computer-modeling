using System;
using System.Drawing;

namespace GraduationProject
{
    partial class Drawing
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
            this.connect_button = new System.Windows.Forms.Button();
            this.step_button = new System.Windows.Forms.Button();
            this.immediately_button = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.remove_button = new System.Windows.Forms.Button();
            this.step_remove_button = new System.Windows.Forms.Button();
            this.read_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // connect_button
            // 
            this.connect_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.connect_button.Location = new System.Drawing.Point(12, 388);
            this.connect_button.Name = "connect_button";
            this.connect_button.Size = new System.Drawing.Size(150, 50);
            this.connect_button.TabIndex = 0;
            this.connect_button.Text = "Подключиться";
            this.connect_button.UseVisualStyleBackColor = true;
            this.connect_button.Click += new System.EventHandler(this.connect_button_Click);
            // 
            // step_button
            // 
            this.step_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.step_button.Location = new System.Drawing.Point(168, 388);
            this.step_button.Name = "step_button";
            this.step_button.Size = new System.Drawing.Size(150, 50);
            this.step_button.TabIndex = 1;
            this.step_button.Text = "По шагам";
            this.step_button.UseVisualStyleBackColor = true;
            this.step_button.Click += new System.EventHandler(this.step_button_Click);
            // 
            // immediately_button
            // 
            this.immediately_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.immediately_button.Location = new System.Drawing.Point(324, 388);
            this.immediately_button.Name = "immediately_button";
            this.immediately_button.Size = new System.Drawing.Size(150, 50);
            this.immediately_button.TabIndex = 2;
            this.immediately_button.Text = "Полностью";
            this.immediately_button.UseVisualStyleBackColor = true;
            this.immediately_button.Click += new System.EventHandler(this.immediately_button_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GraduationProject.Properties.Resources.ImageTask;
            this.pictureBox1.Location = new System.Drawing.Point(252, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(341, 369);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // remove_button
            // 
            this.remove_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.remove_button.Location = new System.Drawing.Point(480, 388);
            this.remove_button.Name = "remove_button";
            this.remove_button.Size = new System.Drawing.Size(150, 50);
            this.remove_button.TabIndex = 4;
            this.remove_button.Text = "Удалить";
            this.remove_button.UseVisualStyleBackColor = true;
            this.remove_button.Click += new System.EventHandler(this.remove_button_Click);
            // 
            // step_remove_button
            // 
            this.step_remove_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.step_remove_button.Location = new System.Drawing.Point(636, 377);
            this.step_remove_button.Name = "step_remove_button";
            this.step_remove_button.Size = new System.Drawing.Size(150, 61);
            this.step_remove_button.TabIndex = 5;
            this.step_remove_button.Text = "Поэтапное удаление";
            this.step_remove_button.UseVisualStyleBackColor = true;
            this.step_remove_button.Click += new System.EventHandler(this.remove_step_button_Click);
            // 
            // read_button
            // 
            this.read_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.read_button.Location = new System.Drawing.Point(792, 388);
            this.read_button.Name = "read_button";
            this.read_button.Size = new System.Drawing.Size(150, 50);
            this.read_button.TabIndex = 6;
            this.read_button.Text = "Чтение";
            this.read_button.UseVisualStyleBackColor = true;
            this.read_button.Click += new EventHandler(this.read_button_Click);
            // 
            // Drawing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 451);
            this.Controls.Add(this.read_button);
            this.Controls.Add(this.step_remove_button);
            this.Controls.Add(this.remove_button);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.immediately_button);
            this.Controls.Add(this.step_button);
            this.Controls.Add(this.connect_button);
            this.Name = "Drawing";
            this.Text = "Drawing";
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button read_button;
        private System.Windows.Forms.Button step_remove_button;
        private System.Windows.Forms.Button remove_button;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button step_button;
        private System.Windows.Forms.Button immediately_button;
        private System.Windows.Forms.Button connect_button;

        #endregion
    }
}