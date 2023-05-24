using System.ComponentModel;

namespace GraduationProject.CheckForms;

partial class AddTasksForm
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
        this.label1 = new System.Windows.Forms.Label();
        this.comboBox1 = new System.Windows.Forms.ComboBox();
        this.addButton = new System.Windows.Forms.Button();
        this.SuspendLayout();
        // 
        // label1
        // 
        this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        this.label1.Location = new System.Drawing.Point(12, 9);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(213, 27);
        this.label1.TabIndex = 0;
        this.label1.Text = "Куда добавить задачу";
        // 
        // comboBox1
        // 
        this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.comboBox1.FormattingEnabled = true;
        this.comboBox1.Location = new System.Drawing.Point(12, 49);
        this.comboBox1.Name = "comboBox1";
        this.comboBox1.Size = new System.Drawing.Size(213, 21);
        this.comboBox1.TabIndex = 1;
        // 
        // addButton
        // 
        this.addButton.DialogResult = System.Windows.Forms.DialogResult.OK;
        this.addButton.Location = new System.Drawing.Point(236, 49);
        this.addButton.Name = "addButton";
        this.addButton.Size = new System.Drawing.Size(75, 23);
        this.addButton.TabIndex = 2;
        this.addButton.Text = "Добавить\r\n";
        this.addButton.UseVisualStyleBackColor = true;
        this.addButton.Click += new System.EventHandler(this.addButton_Click);
        // 
        // AddTasksForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(316, 84);
        this.Controls.Add(this.addButton);
        this.Controls.Add(this.comboBox1);
        this.Controls.Add(this.label1);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Name = "AddTasksForm";
        this.Text = "Добавление";
        this.ResumeLayout(false);
    }

    private System.Windows.Forms.Button addButton;

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox comboBox1;

    #endregion
}