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
    public partial class RegistrationForm : Form
    {
        public UserManager userManager;
        public User AuthenticatedUser { get; set; }
        public RegistrationForm(UserManager userManager)
        {
            InitializeComponent();
            this.userManager = userManager;
            btnRegister.Enabled = false;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            User newUser = new User
            {
                Login = tbLogin.Text,
                Password = tbPassword.Text,
            };

            UserFileHandler userFileHandler = new UserFileHandler();
            if (userFileHandler.IsUserRegistered(newUser.Login, newUser.Password))
            {
                MessageBox.Show($"{newUser.Login} has already been registered");
                LoginForm loginForm = new LoginForm(userManager);
                loginForm.ShowDialog();
                //Close();
            }
            else
            {
                userManager.Users.Add(newUser);
                userFileHandler.SaveUsersToFile(userManager.Users);
                MainForm mainForm = new MainForm();
                mainForm.UserManager = userManager;
                AuthenticatedUser = newUser;
                DialogResult = DialogResult.OK;
                this.Close();
            }

            tbLogin.Clear();
            tbPassword.Clear();


        }

        private void tbLogin_TextChanged(object sender, EventArgs e)
        {
            if (tbLogin.Text != "" && tbPassword.Text != "")
                btnRegister.Enabled = true;
            else
                btnRegister.Enabled = false;
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            if (tbLogin.Text != "" && tbPassword.Text != "")
                btnRegister.Enabled = true;
            else
                btnRegister.Enabled = false;
        }
    }
}
