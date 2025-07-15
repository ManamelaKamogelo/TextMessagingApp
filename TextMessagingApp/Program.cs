using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextMessagingApp
{

    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (Form1 loginForm = new Form1())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // Credentials passed via properties
                    string username = loginForm.Username;
                    string password = loginForm.Password;

                    // Run the main form of the app
                    Application.Run(new chatForm(username));
                }
                else
                {
                    // Exit if login was canceled or failed
                    Application.Exit();
                }
            }
        }
        //Define the message class to match the structure of Firebase database
        public class PrivateMessage
        {
            public string Id { get; set; }
            public string Text { get; set; }
            public string Sender { get; set; }
            public string Receiver { get; set; }
            public DateTime Timestamp { get; set; }
            public string Email { get; set; }
        }
        public class GroupMessage
        {
            public string Id { get; set; }
            public string Text { get; set; }
            public string Username { get; set; }
            public DateTime Timestamp { get; set; }
        }
    }
}

