using System;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace TextMessagingApp
{
    public partial class Form1 : Form
    {
        public string Username { get; private set; }
        public string Password { get; private set; }

        private IFirebaseClient firebaseClient;

        public Form1()
        {
            InitializeComponent();
            passwordTxtBox.UseSystemPasswordChar = true;


            // Set up Firebase Realtime Database
            var dbConfig = new FirebaseConfig
            {
                AuthSecret = "AIzaSyCixgFidvTMV9Usl8OBAY17zOaETgkStQc",
                BasePath = "https://textmessagingapp-994ab-default-rtdb.firebaseio.com/"
            };

            firebaseClient = new FireSharp.FirebaseClient(dbConfig);

            if (firebaseClient == null)
            {
                MessageBox.Show("Failed to connect to Firebase.");
            }
        }

        private void signUpBtn_Click(object sender, EventArgs e)
        {
            // Show the sign-up form
            SignUpForm signUpForm = new SignUpForm();
            signUpForm.Show();
        }

        private async void loginBtn_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text.Trim();
            string password = passwordTxtBox.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            try
            {
                FirebaseResponse response = await firebaseClient.GetAsync($"Users/{SanitizeKey(username)}");
                User user = response.ResultAs<User>();

                if (user != null && user.Password == password)
                {
                    this.Username = username;
                    this.Password = password;

                    MessageBox.Show("Login successful!");

                    this.DialogResult = DialogResult.OK;
                    this.Close();  // Return to Program.cs
                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Login error: {ex.Message}");
            }
        }

        private string SanitizeKey(string key)
        {
            return key.Replace(".", "_").Replace("#", "_").Replace("$", "_").Replace("[", "_").Replace("]", "_");
        }

        public class User
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        private void showPasswordRdBtn_CheckedChanged(object sender, EventArgs e)
        {
            passwordTxtBox.UseSystemPasswordChar = !showPasswordRdBtn.Checked;
        }
    }
}
