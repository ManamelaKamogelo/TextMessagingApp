namespace TextMessagingApp
{
    partial class chatForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(chatForm));
            this.privateSend = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.privateMessageListBox = new System.Windows.Forms.ListBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.friendsListBox = new System.Windows.Forms.ListBox();
            this.LogOutBtn = new System.Windows.Forms.Button();
            this.statusLbl = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.addFriendsTextBox = new System.Windows.Forms.TextBox();
            this.addFriendsBtn = new System.Windows.Forms.Button();
            this.userLbl = new System.Windows.Forms.Label();
            this.privateMessageTextBox = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupMessageListBox = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupChatsListBox = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.friendCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.creatGroupBtn = new System.Windows.Forms.Button();
            this.groupTitleTextBox = new System.Windows.Forms.TextBox();
            this.groupMessageTextBox = new System.Windows.Forms.TextBox();
            this.groupSendBtn = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // privateSend
            // 
            this.privateSend.Location = new System.Drawing.Point(843, 404);
            this.privateSend.Name = "privateSend";
            this.privateSend.Size = new System.Drawing.Size(126, 45);
            this.privateSend.TabIndex = 0;
            this.privateSend.Text = "Send";
            this.privateSend.UseVisualStyleBackColor = true;
            this.privateSend.Click += new System.EventHandler(this.privateSend_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(13, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1024, 541);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage1.Controls.Add(this.groupBox6);
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.LogOutBtn);
            this.tabPage1.Controls.Add(this.statusLbl);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.userLbl);
            this.tabPage1.Controls.Add(this.privateMessageTextBox);
            this.tabPage1.Controls.Add(this.privateSend);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1016, 515);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Private Message";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.privateMessageListBox);
            this.groupBox6.Location = new System.Drawing.Point(247, 128);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(722, 270);
            this.groupBox6.TabIndex = 11;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Messages";
            // 
            // privateMessageListBox
            // 
            this.privateMessageListBox.FormattingEnabled = true;
            this.privateMessageListBox.Location = new System.Drawing.Point(6, 17);
            this.privateMessageListBox.Name = "privateMessageListBox";
            this.privateMessageListBox.Size = new System.Drawing.Size(710, 238);
            this.privateMessageListBox.TabIndex = 1;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.friendsListBox);
            this.groupBox5.Location = new System.Drawing.Point(6, 121);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(229, 329);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Friends";
            // 
            // friendsListBox
            // 
            this.friendsListBox.FormattingEnabled = true;
            this.friendsListBox.Location = new System.Drawing.Point(6, 19);
            this.friendsListBox.Name = "friendsListBox";
            this.friendsListBox.Size = new System.Drawing.Size(212, 303);
            this.friendsListBox.TabIndex = 3;
            this.friendsListBox.SelectedIndexChanged += new System.EventHandler(this.friendsListBox_SelectedIndexChanged);
            // 
            // LogOutBtn
            // 
            this.LogOutBtn.Location = new System.Drawing.Point(866, 99);
            this.LogOutBtn.Name = "LogOutBtn";
            this.LogOutBtn.Size = new System.Drawing.Size(97, 23);
            this.LogOutBtn.TabIndex = 6;
            this.LogOutBtn.Text = "Log Out";
            this.LogOutBtn.UseVisualStyleBackColor = true;
            this.LogOutBtn.Click += new System.EventHandler(this.LogOutBtn_Click);
            // 
            // statusLbl
            // 
            this.statusLbl.AutoSize = true;
            this.statusLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLbl.Location = new System.Drawing.Point(108, 23);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(0, 26);
            this.statusLbl.TabIndex = 9;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.addFriendsTextBox);
            this.groupBox2.Controls.Add(this.addFriendsBtn);
            this.groupBox2.Location = new System.Drawing.Point(6, 53);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(274, 62);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Add A Friend";
            // 
            // addFriendsTextBox
            // 
            this.addFriendsTextBox.Location = new System.Drawing.Point(6, 19);
            this.addFriendsTextBox.Multiline = true;
            this.addFriendsTextBox.Name = "addFriendsTextBox";
            this.addFriendsTextBox.Size = new System.Drawing.Size(168, 28);
            this.addFriendsTextBox.TabIndex = 4;
            // 
            // addFriendsBtn
            // 
            this.addFriendsBtn.Location = new System.Drawing.Point(180, 20);
            this.addFriendsBtn.Name = "addFriendsBtn";
            this.addFriendsBtn.Size = new System.Drawing.Size(85, 27);
            this.addFriendsBtn.TabIndex = 5;
            this.addFriendsBtn.Text = "Add Friend";
            this.addFriendsBtn.UseVisualStyleBackColor = true;
            this.addFriendsBtn.Click += new System.EventHandler(this.addFriendsBtn_Click);
            // 
            // userLbl
            // 
            this.userLbl.AutoSize = true;
            this.userLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userLbl.Location = new System.Drawing.Point(336, 23);
            this.userLbl.Name = "userLbl";
            this.userLbl.Size = new System.Drawing.Size(0, 26);
            this.userLbl.TabIndex = 7;
            // 
            // privateMessageTextBox
            // 
            this.privateMessageTextBox.Location = new System.Drawing.Point(241, 404);
            this.privateMessageTextBox.Multiline = true;
            this.privateMessageTextBox.Name = "privateMessageTextBox";
            this.privateMessageTextBox.Size = new System.Drawing.Size(596, 45);
            this.privateMessageTextBox.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.groupMessageTextBox);
            this.tabPage2.Controls.Add(this.groupSendBtn);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1016, 515);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "GroupChats";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupMessageListBox);
            this.groupBox4.Location = new System.Drawing.Point(179, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(790, 371);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Group Messages";
            // 
            // groupMessageListBox
            // 
            this.groupMessageListBox.FormattingEnabled = true;
            this.groupMessageListBox.Location = new System.Drawing.Point(6, 15);
            this.groupMessageListBox.Name = "groupMessageListBox";
            this.groupMessageListBox.Size = new System.Drawing.Size(778, 342);
            this.groupMessageListBox.TabIndex = 7;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupChatsListBox);
            this.groupBox3.Location = new System.Drawing.Point(15, 177);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(158, 251);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Group Chat";
            // 
            // groupChatsListBox
            // 
            this.groupChatsListBox.FormattingEnabled = true;
            this.groupChatsListBox.Location = new System.Drawing.Point(6, 19);
            this.groupChatsListBox.Name = "groupChatsListBox";
            this.groupChatsListBox.Size = new System.Drawing.Size(142, 225);
            this.groupChatsListBox.TabIndex = 9;
            this.groupChatsListBox.SelectedIndexChanged += new System.EventHandler(this.groupChatsListBox_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.friendCheckedListBox);
            this.groupBox1.Controls.Add(this.creatGroupBtn);
            this.groupBox1.Controls.Add(this.groupTitleTextBox);
            this.groupBox1.Location = new System.Drawing.Point(15, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(158, 164);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Create Group Chat";
            // 
            // friendCheckedListBox
            // 
            this.friendCheckedListBox.FormattingEnabled = true;
            this.friendCheckedListBox.Location = new System.Drawing.Point(6, 55);
            this.friendCheckedListBox.Name = "friendCheckedListBox";
            this.friendCheckedListBox.Size = new System.Drawing.Size(142, 64);
            this.friendCheckedListBox.TabIndex = 12;
            // 
            // creatGroupBtn
            // 
            this.creatGroupBtn.Location = new System.Drawing.Point(6, 125);
            this.creatGroupBtn.Name = "creatGroupBtn";
            this.creatGroupBtn.Size = new System.Drawing.Size(142, 27);
            this.creatGroupBtn.TabIndex = 11;
            this.creatGroupBtn.Text = "Create Group";
            this.creatGroupBtn.UseVisualStyleBackColor = true;
            this.creatGroupBtn.Click += new System.EventHandler(this.creatGroupBtn_Click);
            // 
            // groupTitleTextBox
            // 
            this.groupTitleTextBox.Location = new System.Drawing.Point(6, 15);
            this.groupTitleTextBox.Multiline = true;
            this.groupTitleTextBox.Name = "groupTitleTextBox";
            this.groupTitleTextBox.Size = new System.Drawing.Size(142, 28);
            this.groupTitleTextBox.TabIndex = 10;
            // 
            // groupMessageTextBox
            // 
            this.groupMessageTextBox.Location = new System.Drawing.Point(179, 383);
            this.groupMessageTextBox.Multiline = true;
            this.groupMessageTextBox.Name = "groupMessageTextBox";
            this.groupMessageTextBox.Size = new System.Drawing.Size(631, 45);
            this.groupMessageTextBox.TabIndex = 8;
            // 
            // groupSendBtn
            // 
            this.groupSendBtn.Location = new System.Drawing.Point(816, 383);
            this.groupSendBtn.Name = "groupSendBtn";
            this.groupSendBtn.Size = new System.Drawing.Size(147, 45);
            this.groupSendBtn.TabIndex = 6;
            this.groupSendBtn.Text = "Send";
            this.groupSendBtn.UseVisualStyleBackColor = true;
            this.groupSendBtn.Click += new System.EventHandler(this.groupSendBtn_Click);
            // 
            // chatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TextMessagingApp.Properties.Resources.WhatsApp_Image_2025_05_02_at_15_36_34_584c02f2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1045, 578);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "chatForm";
            this.Text = "chatForm";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button privateSend;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox privateMessageTextBox;
        private System.Windows.Forms.ListBox privateMessageListBox;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button addFriendsBtn;
        private System.Windows.Forms.TextBox addFriendsTextBox;
        private System.Windows.Forms.ListBox friendsListBox;
        private System.Windows.Forms.Button creatGroupBtn;
        private System.Windows.Forms.TextBox groupTitleTextBox;
        private System.Windows.Forms.ListBox groupChatsListBox;
        private System.Windows.Forms.TextBox groupMessageTextBox;
        private System.Windows.Forms.ListBox groupMessageListBox;
        private System.Windows.Forms.Button groupSendBtn;
        private System.Windows.Forms.CheckedListBox friendCheckedListBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button LogOutBtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label userLbl;
        private System.Windows.Forms.Label statusLbl;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}