namespace WfChatUsers
{
    partial class MainForm
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
            lbChat = new ListBox();
            tbMessage = new TextBox();
            btnSend = new Button();
            lbContacts = new ListBox();
            tbNewContact = new TextBox();
            btnAddContact = new Button();
            btnUpdateContact = new Button();
            btnDeleteContact = new Button();
            SuspendLayout();
            // 
            // lbChat
            // 
            lbChat.FormattingEnabled = true;
            lbChat.ItemHeight = 15;
            lbChat.Location = new Point(29, 23);
            lbChat.Name = "lbChat";
            lbChat.Size = new Size(421, 319);
            lbChat.TabIndex = 0;
            // 
            // tbMessage
            // 
            tbMessage.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            tbMessage.Location = new Point(29, 361);
            tbMessage.Name = "tbMessage";
            tbMessage.PlaceholderText = "Message";
            tbMessage.Size = new Size(421, 32);
            tbMessage.TabIndex = 1;
            tbMessage.TextChanged += textBox1_TextChanged;
            // 
            // btnSend
            // 
            btnSend.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            btnSend.Location = new Point(133, 399);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(194, 39);
            btnSend.TabIndex = 2;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // lbContacts
            // 
            lbContacts.FormattingEnabled = true;
            lbContacts.ItemHeight = 15;
            lbContacts.Location = new Point(521, 23);
            lbContacts.Name = "lbContacts";
            lbContacts.Size = new Size(267, 214);
            lbContacts.TabIndex = 3;
            // 
            // tbNewContact
            // 
            tbNewContact.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbNewContact.Location = new Point(521, 257);
            tbNewContact.Name = "tbNewContact";
            tbNewContact.PlaceholderText = "Contact Info";
            tbNewContact.Size = new Size(267, 29);
            tbNewContact.TabIndex = 4;
            // 
            // btnAddContact
            // 
            btnAddContact.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnAddContact.Location = new Point(521, 310);
            btnAddContact.Name = "btnAddContact";
            btnAddContact.Size = new Size(267, 32);
            btnAddContact.TabIndex = 5;
            btnAddContact.Text = "Add Contact";
            btnAddContact.UseVisualStyleBackColor = true;
            btnAddContact.Click += btnAddContact_Click;
            // 
            // btnUpdateContact
            // 
            btnUpdateContact.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnUpdateContact.Location = new Point(521, 361);
            btnUpdateContact.Name = "btnUpdateContact";
            btnUpdateContact.Size = new Size(267, 32);
            btnUpdateContact.TabIndex = 6;
            btnUpdateContact.Text = "Update Contact";
            btnUpdateContact.UseVisualStyleBackColor = true;
            btnUpdateContact.Click += btnUpdateContact_Click;
            // 
            // btnDeleteContact
            // 
            btnDeleteContact.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnDeleteContact.Location = new Point(521, 406);
            btnDeleteContact.Name = "btnDeleteContact";
            btnDeleteContact.Size = new Size(267, 32);
            btnDeleteContact.TabIndex = 7;
            btnDeleteContact.Text = "Delete Contact";
            btnDeleteContact.UseVisualStyleBackColor = true;
            btnDeleteContact.Click += btnDeleteContact_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDeleteContact);
            Controls.Add(btnUpdateContact);
            Controls.Add(btnAddContact);
            Controls.Add(tbNewContact);
            Controls.Add(lbContacts);
            Controls.Add(btnSend);
            Controls.Add(tbMessage);
            Controls.Add(lbChat);
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            TextChanged += MainForm_TextChanged;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lbChat;
        private TextBox tbMessage;
        private Button btnSend;
        private ListBox lbContacts;
        private TextBox tbNewContact;
        private Button btnAddContact;
        private Button btnUpdateContact;
        private Button btnDeleteContact;
    }
}