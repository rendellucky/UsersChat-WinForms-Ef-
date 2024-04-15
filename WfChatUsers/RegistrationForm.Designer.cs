namespace WfChatUsers
{
    partial class RegistrationForm
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
            tbLogin = new TextBox();
            tbPassword = new TextBox();
            btnRegister = new Button();
            SuspendLayout();
            // 
            // tbLogin
            // 
            tbLogin.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            tbLogin.Location = new Point(55, 67);
            tbLogin.Name = "tbLogin";
            tbLogin.PlaceholderText = "Login";
            tbLogin.Size = new Size(437, 32);
            tbLogin.TabIndex = 0;
            tbLogin.TextChanged += tbLogin_TextChanged;
            // 
            // tbPassword
            // 
            tbPassword.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            tbPassword.Location = new Point(55, 142);
            tbPassword.Name = "tbPassword";
            tbPassword.PlaceholderText = "Password";
            tbPassword.Size = new Size(437, 32);
            tbPassword.TabIndex = 1;
            tbPassword.TextChanged += tbPassword_TextChanged;
            // 
            // btnRegister
            // 
            btnRegister.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            btnRegister.Location = new Point(169, 228);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(176, 51);
            btnRegister.TabIndex = 2;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // RegistrationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRegister);
            Controls.Add(tbPassword);
            Controls.Add(tbLogin);
            Name = "RegistrationForm";
            Text = "RegistrationForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbLogin;
        private TextBox tbPassword;
        private Button btnRegister;
    }
}