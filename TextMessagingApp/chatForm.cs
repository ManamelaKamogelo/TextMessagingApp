using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Firebase.Database;
using Firebase.Database.Query;
using System.Threading.Tasks;
using static TextMessagingApp.Program;

namespace TextMessagingApp
{
    public partial class chatForm : Form
    {
        private FirebaseClient firebaseClient;
        private IFirebaseClient fireSharpClient;
        private string username;
        private HashSet<string> displayedPrivateMessageIds = new HashSet<string>();
        private HashSet<string> displayedGroupMessageIds = new HashSet<string>();


        private IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "AIzaSyCixgFidvTMV9Usl8OBAY17zOaETgkStQc",
            BasePath = "https://textmessagingapp-994ab-default-rtdb.firebaseio.com/"
        };

        public chatForm(string username)
        {
            InitializeComponent();
            this.username = username;
            

            this.Load += async (sender, e) => await InitializeChatAsync();
        }

        private async Task InitializeChatAsync()
        {
            fireSharpClient = new FireSharp.FirebaseClient(config);
            firebaseClient = new FirebaseClient(config.BasePath);

            friendsListBox.SelectedIndexChanged += friendsListBox_SelectedIndexChanged;

            statusLbl.Text = $"{username}, you are currently online"; // 👈 Set status message

            var sanitizedUsername = SanitizeForFirebaseKey(username);
            await FetchConnectedClients(sanitizedUsername);
            ListenForMessages();
            ListenForPrivateMessages(username);
            await LoadUserGroups();
            ListenForNewGroups();
        }


        private string SanitizeForFirebaseKey(string input)
        {
            return input.Replace(".", "_")
                        .Replace("#", "_")
                        .Replace("$", "_")
                        .Replace("[", "_")
                        .Replace("]", "_")
                        .Replace("/", "_")
                        .Replace("@", "_at_")
                        .Replace(" ", "_");
        }

        private async Task FetchConnectedClients(string sanitizedUsername)
        {
            // Load currently connected users
            var clients = await firebaseClient.Child("ConnectedClients").OnceAsync<string>();
            foreach (var client in clients)
            {
                if (!friendsListBox.Items.Contains(client.Key))
                    friendsListBox.Items.Add(client.Key);

                if (!friendCheckedListBox.Items.Contains(client.Key))
                    friendCheckedListBox.Items.Add(client.Key);
            }

            // Load persistent friends from database
            var friends = await firebaseClient.Child("Users").Child(sanitizedUsername).Child("Friends").OnceAsync<string>();
            foreach (var friend in friends)
            {
                if (!friendsListBox.Items.Contains(friend.Key))
                    friendsListBox.Items.Add(friend.Key);

                if (!friendCheckedListBox.Items.Contains(friend.Key))
                    friendCheckedListBox.Items.Add(friend.Key);
            }
        }


        private async Task SendPrivateMessageToFireBase(string message, string recieptUsername)
        {
            var sanitizedReceiver = SanitizeForFirebaseKey(recieptUsername);
            var messageId = Guid.NewGuid().ToString();

            var newMessage = new PrivateMessage
            {
                Id = messageId,
                Text = message,
                Sender = username,
                Receiver = recieptUsername,
                Timestamp = DateTime.UtcNow
            };

            try
            {
                await firebaseClient.Child("MessagesToUsers").Child(sanitizedReceiver).PostAsync(newMessage);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending message: {ex.Message}");
            }
        }

        private async Task SendMessageToFireBase(string message)
        {
            var messageId = Guid.NewGuid().ToString();

            var newMessage = new GroupMessage
            {
                Id = messageId,
                Text = message,
                Username = username,
                Timestamp = DateTime.Now
            };

            try
            {
                await firebaseClient.Child("Group_Messages").PostAsync(newMessage);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending message: {ex.Message}");
            }
        }

        private void ListenForPrivateMessages(string friendUsername)
        {
            var sanitizedCurrentUsername = SanitizeForFirebaseKey(username);

            firebaseClient.Child("MessagesToUsers")
                          .Child(sanitizedCurrentUsername)
                          .AsObservable<PrivateMessage>()
                          .Subscribe(msg =>
                          {
                              if (msg.EventType == Firebase.Database.Streaming.FirebaseEventType.InsertOrUpdate)
                              {
                                  var newMessage = msg.Object;

                                  if (newMessage != null && !displayedPrivateMessageIds.Contains(newMessage.Id))
                                  {
                                      Invoke(new Action(() =>
                                      {
                                          privateMessageListBox.Items.Add($"{newMessage.Sender}: {newMessage.Text} [{newMessage.Timestamp:HH:mm}]");
                                          displayedPrivateMessageIds.Add(newMessage.Id);
                                      }));
                                  }
                              }
                          });
        }


        private async void groupSendBtn_Click(object sender, EventArgs e)
        {
            string message = groupMessageTextBox.Text.Trim();
            string selectedGroup = groupChatsListBox.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(message) || string.IsNullOrEmpty(selectedGroup))
            {
                MessageBox.Show("Please enter a message and select a group.");
                return;
            }

            var newMessage = new GroupMessage
            {
                Id = Guid.NewGuid().ToString(),
                Text = message,
                Username = username,
                Timestamp = DateTime.Now
            };

            string sanitizedGroup = SanitizeForFirebaseKey(selectedGroup);

            try
            {
                await firebaseClient.Child("Group_Messages").Child(sanitizedGroup).PostAsync(newMessage);
                groupMessageTextBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending message: {ex.Message}");
            }
        }

        private async void privateSend_Click(object sender, EventArgs e)
        {
            string message = privateMessageTextBox.Text.Trim();
            string selectedFriend = friendsListBox.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(message) && !string.IsNullOrEmpty(selectedFriend))
            {
                privateMessageTextBox.Clear();
                await SendPrivateMessageToFireBase(message, selectedFriend);
                privateMessageListBox.Items.Add($"{username}: {message} [{DateTime.Now:HH:mm}]");
            }
            else
            {
                MessageBox.Show("Please enter a message and select a friend.");
            }
        }

        private async Task UpdateConnectedClients(bool isConnected)
        {
            try
            {
                var sanitizedUsername = SanitizeForFirebaseKey(username);

                if (isConnected)
                {
                    await firebaseClient.Child("ConnectedClients").Child(sanitizedUsername).PutAsync(true);
                }
                else
                {
                    await firebaseClient.Child("ConnectedClients").Child(sanitizedUsername).DeleteAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating connected clients: {ex.Message}");
            }
        }

        private void chatForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            UpdateConnectedClients(false);
        }

        private async void addFriendsBtn_Click(object sender, EventArgs e)
        {
            string friendUsername = addFriendsTextBox.Text.Trim();k

            if (!string.IsNullOrEmpty(friendUsername))
            {
                var sanitizedFriendUsername = SanitizeForFirebaseKey(friendUsername);
                var sanitizedCurrentUser = SanitizeForFirebaseKey(username);

                friendsListBox.Items.Add(friendUsername);
                friendCheckedListBox.Items.Add(friendUsername);

                try
                {
                    await firebaseClient.Child("Users").Child(sanitizedCurrentUser).Child("Friends").Child(sanitizedFriendUsername).PutAsync(true);
                    MessageBox.Show($"{friendUsername} added successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding friend: {ex.Message}");
                }

                addFriendsTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Please enter a valid friend's username.");
            }
        }

        private void friendsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (friendsListBox.SelectedItem != null)
            {
                string selectedFriend = friendsListBox.SelectedItem.ToString();
                LoadPrivateMessages(selectedFriend);
            }
        }

        private void ListenForMessages()
        {
            firebaseClient.Child("Group_Messages").AsObservable<GroupMessage>().Subscribe(msg =>
            {
                if (msg.EventType == Firebase.Database.Streaming.FirebaseEventType.InsertOrUpdate)
                {
                    var newMessage = msg.Object;

                    if (newMessage != null)
                    {
                        Invoke(new Action(() =>
                        {
                            if (!string.IsNullOrEmpty(newMessage.Username) && !string.IsNullOrEmpty(newMessage.Text))
                            {
                                groupMessageListBox.Items.Add($"{newMessage.Username}: {newMessage.Text} [{newMessage.Timestamp:HH:mm}]");
                            }
                        }));
                    }
                }
            });
        }

        private async void LoadPrivateMessages(string selectedFriend)
        {
            var sanitizedFriendUsername = SanitizeForFirebaseKey(selectedFriend);
            var sanitizedCurrentUsername = SanitizeForFirebaseKey(username);

            privateMessageListBox.Items.Clear();
            displayedPrivateMessageIds.Clear(); // Reset for this chat

            var messages = await firebaseClient.Child("MessagesToUsers")
                                               .Child(sanitizedCurrentUsername)
                                               .OnceAsync<PrivateMessage>();

            foreach (var message in messages)
            {
                var msg = message.Object;

                if ((msg.Sender == selectedFriend || msg.Receiver == selectedFriend) &&
                    !displayedPrivateMessageIds.Contains(msg.Id))
                {
                    privateMessageListBox.Items.Add($"{msg.Sender}: {msg.Text} [{msg.Timestamp:HH:mm}]");
                    displayedPrivateMessageIds.Add(msg.Id);
                }
            }
        }



        private void ListenToGroupMessages(string groupName)
        {
            var sanitizedGroup = SanitizeForFirebaseKey(groupName);

            firebaseClient.Child("Group_Messages").Child(sanitizedGroup)
                .AsObservable<GroupMessage>()
                .Subscribe(msg =>
                {
                    if (msg.EventType == Firebase.Database.Streaming.FirebaseEventType.InsertOrUpdate)
                    {
                        var newMessage = msg.Object;

                        if (newMessage != null && !displayedGroupMessageIds.Contains(newMessage.Id))
                        {
                            Invoke(new Action(() =>
                            {
                                if (!string.IsNullOrEmpty(newMessage.Username) && !string.IsNullOrEmpty(newMessage.Text))
                                {
                                    groupMessageListBox.Items.Add($"{newMessage.Username}: {newMessage.Text} [{newMessage.Timestamp:HH:mm}]");
                                    displayedGroupMessageIds.Add(newMessage.Id);
                                }
                            }));
                        }
                    }
                });
        }

        //Psalm 2:6 "Yet have I set my king upon my holy hill of Zion."
        private async void groupChatsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedGroup = groupChatsListBox.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedGroup)) return;

            string sanitizedGroup = SanitizeForFirebaseKey(selectedGroup);

            groupMessageListBox.Items.Clear();
            
            displayedGroupMessageIds.Clear(); // Add this line
           

            ListenToGroupMessages(selectedGroup);

            var messages = await firebaseClient.Child("Group_Messages").Child(sanitizedGroup).OnceAsync<GroupMessage>();
            foreach (var msg in messages)
            {
                groupMessageListBox.Items.Add($"{msg.Object.Username}: {msg.Object.Text} [{msg.Object.Timestamp:HH:mm}]");
            }
        }



        private async void creatGroupBtn_Click(object sender, EventArgs e)
        {
            string groupTitle = groupTitleTextBox.Text.Trim();

            if (string.IsNullOrEmpty(groupTitle) || friendCheckedListBox.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please enter a group title and select at least one friend.");
                return;
            }

            var sanitizedGroupTitle = SanitizeForFirebaseKey(groupTitle);

            // Collect all group members (current user + selected friends)
            List<string> members = new List<string> { username };
            foreach (var friend in friendCheckedListBox.CheckedItems)
            {
                members.Add(friend.ToString());
            }

            // Prepare group object
            var groupData = new
            {
                Title = groupTitle,
                Members = members
            };

            try
            {
                // Create the group entry in "Groups"
                await firebaseClient.Child("Groups").Child(sanitizedGroupTitle).PutAsync(groupData);


                foreach (var member in members)
                {
                    var sanitizedMember = SanitizeForFirebaseKey(member);

                    // Save group reference under each member's "Groups"
                    await firebaseClient
                        .Child("Users")
                        .Child(sanitizedMember)
                        .Child("Groups")
                        .Child(sanitizedGroupTitle)
                        .PutAsync(true);

                    // Optionally store friends for current user only
                    if (member != username)
                    {
                        var sanitizedCurrentUser = SanitizeForFirebaseKey(username);
                        await firebaseClient
                            .Child("Users")
                            .Child(sanitizedCurrentUser)
                            .Child("Friends")
                            .Child(sanitizedMember)
                            .PutAsync(true);
                    }
                }



                MessageBox.Show("Group successfully created!");

                // Add to current user's list if not already present
                if (!groupChatsListBox.Items.Contains(groupTitle))
                {
                    groupChatsListBox.Items.Add(groupTitle);
                }

                groupTitleTextBox.Clear();
                friendCheckedListBox.ClearSelected();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to create group: {ex.Message}");
            }
        }

        private async Task LoadUserGroups()
        {
            var sanitizedUsername = SanitizeForFirebaseKey(username);

            var groups = await firebaseClient
                .Child("Users")
                .Child(sanitizedUsername)
                .Child("Groups")
                .OnceAsync<bool>();

            foreach (var group in groups)
            {
                if (!groupChatsListBox.Items.Contains(group.Key))
                    groupChatsListBox.Items.Add(group.Key);
            }
        }


        private void ListenForNewGroups()
        {
            var sanitizedUsername = SanitizeForFirebaseKey(username);

            firebaseClient
                .Child("Users")
                .Child(sanitizedUsername)
                .Child("Groups")
                .AsObservable<bool>()
                .Subscribe(group =>
                {
                    if (group.EventType == Firebase.Database.Streaming.FirebaseEventType.InsertOrUpdate)
                    {
                        string newGroupTitle = group.Key;
                        Invoke(new Action(() =>
                        {
                            if (!groupChatsListBox.Items.Contains(newGroupTitle))
                                groupChatsListBox.Items.Add(newGroupTitle);
                        }));
                    }
                });
        }

        private async void LogOutBtn_Click(object sender, EventArgs e)
        {
            await UpdateConnectedClients(false); // Remove from ConnectedClients

            // Optionally clear UI data
            groupChatsListBox.Items.Clear();
            groupMessageListBox.Items.Clear();
            privateMessageListBox.Items.Clear();
            friendsListBox.Items.Clear();
            friendCheckedListBox.Items.Clear();

            // Redirect to login form or close app
            this.Hide(); // or this.Close();
            Form1 login = new Form1(); // Make sure you have one
            login.Show();
        }
    }
}
