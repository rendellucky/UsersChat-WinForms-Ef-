using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WfChatUsers
{
    public partial class LoginForm : Form
    {
        UserManager userManager;
        public User AuthenticatedUser { get; set; }

        public LoginForm(UserManager userManager)
        {
            InitializeComponent();
            this.userManager = userManager;
            btnLogin.Enabled = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var login = tbLogin.Text;
            var password = tbPassword.Text;
            UserFileHandler userFileHandler = new UserFileHandler();
            if (userFileHandler.IsUserRegistered(login, password))
            {
                AuthenticatedUser = new User { Login = login, Password = password };
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Your login or password is wrong");
                RegistrationForm registrationForm = new RegistrationForm(userManager);
                if (registrationForm.ShowDialog() == DialogResult.OK)
                {
                    AuthenticatedUser = registrationForm.AuthenticatedUser;
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }

        private void tbLogin_TextChanged(object sender, EventArgs e)
        {
            if (tbLogin.Text != "" && tbPassword.Text != "")
                btnLogin.Enabled = true;
            else
                btnLogin.Enabled = false;
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            if (tbLogin.Text != "" && tbPassword.Text != "")
                btnLogin.Enabled = true;
            else
                btnLogin.Enabled = false;
        }
    }
}
