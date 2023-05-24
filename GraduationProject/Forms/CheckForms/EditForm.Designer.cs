using System.ComponentModel;

namespace GraduationProject.CheckForms;

partial class EditForm
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
        this.editPanel = new System.Windows.Forms.TableLayoutPanel();
        this.SuspendLayout();
        // 
        // editPanel
        // 
        this.editPanel.ColumnCount = 1;
        this.editPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.editPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.editPanel.Location = new System.Drawing.Point(0, 0);
        this.editPanel.Name = "editPanel";
        this.editPanel.RowCount = 3;
        this.editPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
        this.editPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
        this.editPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
        this.editPanel.Size = new System.Drawing.Size(659, 450);
        this.editPanel.TabIndex = 0;
        // 
        // EditForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(659, 450);
        this.Controls.Add(this.editPanel);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.Name = "EditForm";
        this.Text = "EditForm";
        this.ResumeLayout(false);
    }

    private System.Windows.Forms.TableLayoutPanel editPanel;

    #endregion
}