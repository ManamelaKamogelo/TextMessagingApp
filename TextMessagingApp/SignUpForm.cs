using System;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace TextMessagingApp
{
    public partial class SignUpForm : Form
    {
        private IFirebaseClient firebaseClient;

        public SignUpForm()
        {
            InitializeComponent();
            passwordTextBox.UseSystemPasswordChar = true;


            // Configure FireSharp (Realtime Database only)
            var dbConfig = new FirebaseConfig
            {
                AuthSecret = "AIzaSyCixgFidvTMV9Usl8OBAY17zOaETgkStQc",
                BasePath = "https://textmessagingapp-994ab-default-rtdb.firebaseio.com/"
            };
            firebaseClient = new FireSharp.FirebaseClient(dbConfig);

            if (firebaseClient == null)
            {
                MessageBox.Show("Failed to connect to Firebase Realtime Database.");
            }
        }

        private async void registerBtn_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text.Trim();
            string password = passwordTextBox.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            // Check if user already exists
            FirebaseResponse getResponse = await firebaseClient.GetAsync($"Users/{SanitizeKey(username)}");
            var existingUser = getResponse.ResultAs<User>();

            if (existingUser != null)
            {
                MessageBox.Show("Username already exists. Please choose another.");
                return;
            }

            // Register new user
            var newUser = new User
            {
                Username = username,
                Password = password // For demo only – DO NOT store plain passwords in production
            };

            await firebaseClient.SetAsync($"Users/{SanitizeKey(username)}", newUser);

            MessageBox.Show($"User '{username}' registered successfully!");
        }

        private string SanitizeKey(string key)
        {
            // Firebase keys cannot contain '.', '#', '$', '[', or ']'
            return key.Replace(".", "_").Replace("#", "_")
                      .Replace("$", "_").Replace("[", "_").Replace("]", "_");
        }

        public class User
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        private void emailTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void usernameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void showPasswordRdBtn_CheckedChanged(object sender, EventArgs e)
        {
            passwordTextBox.UseSystemPasswordChar = !showPasswordRdBtn.Checked;
        }
    }
}
