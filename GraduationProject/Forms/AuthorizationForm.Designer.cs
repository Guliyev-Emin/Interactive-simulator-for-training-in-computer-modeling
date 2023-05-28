using System.ComponentModel;

namespace GraduationProject;

partial class AuthorizationForm
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
        this.authorizationButton = new System.Windows.Forms.Button();
        this.label1 = new System.Windows.Forms.Label();
        this.userName = new System.Windows.Forms.Label();
        this.userNameText = new System.Windows.Forms.TextBox();
        this.passwordText = new System.Windows.Forms.TextBox();
        this.password = new System.Windows.Forms.Label();
        this.SuspendLayout();
        // 
        // authorizationButton
        // 
        this.authorizationButton.Location = new System.Drawing.Point(276, 113);
        this.authorizationButton.Margin = new System.Windows.Forms.Padding(4);
        this.authorizationButton.Name = "authorizationButton";
        this.authorizationButton.Size = new System.Drawing.Size(100, 28);
        this.authorizationButton.TabIndex = 0;
        this.authorizationButton.Text = "Войти";
        this.authorizationButton.UseVisualStyleBackColor = true;
        this.authorizationButton.Click += new System.EventHandler(this.authorizationButton_Click);
        // 
        // label1
        // 
        this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
        this.label1.Location = new System.Drawing.Point(13, 9);
        this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(363, 28);
        this.label1.TabIndex = 1;
        this.label1.Text = "Вход";
        this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // userName
        // 
        this.userName.AutoSize = true;
        this.userName.Location = new System.Drawing.Point(13, 54);
        this.userName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        this.userName.Name = "userName";
        this.userName.Size = new System.Drawing.Size(131, 17);
        this.userName.TabIndex = 2;
        this.userName.Text = "Имя пользователя";
        this.userName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // userNameText
        // 
        this.userNameText.Location = new System.Drawing.Point(152, 51);
        this.userNameText.Margin = new System.Windows.Forms.Padding(4);
        this.userNameText.Name = "userNameText";
        this.userNameText.Size = new System.Drawing.Size(224, 23);
        this.userNameText.TabIndex = 3;
        // 
        // passwordText
        // 
        this.passwordText.Location = new System.Drawing.Point(152, 82);
        this.passwordText.Margin = new System.Windows.Forms.Padding(4);
        this.passwordText.Name = "passwordText";
        this.passwordText.PasswordChar = '*';
        this.passwordText.Size = new System.Drawing.Size(224, 23);
        this.passwordText.TabIndex = 4;
        // 
        // password
        // 
        this.password.AutoSize = true;
        this.password.Location = new System.Drawing.Point(13, 85);
        this.password.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        this.password.Name = "password";
        this.password.Size = new System.Drawing.Size(57, 17);
        this.password.TabIndex = 5;
        this.password.Text = "Пароль";
        this.password.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // AuthorizationForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(389, 158);
        this.Controls.Add(this.password);
        this.Controls.Add(this.passwordText);
        this.Controls.Add(this.userNameText);
        this.Controls.Add(this.userName);
        this.Controls.Add(this.label1);
        this.Controls.Add(this.authorizationButton);
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
        this.Margin = new System.Windows.Forms.Padding(4);
        this.Name = "AuthorizationForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Авторизация";
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private System.Windows.Forms.Button authorizationButton;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label userName;
    private System.Windows.Forms.TextBox userNameText;
    private System.Windows.Forms.TextBox passwordText;
    private System.Windows.Forms.Label password;

    #endregion
}