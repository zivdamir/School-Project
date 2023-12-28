namespace Login
{
    partial class HomeStart
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
            this.Hellolabel = new System.Windows.Forms.Label();
            this.Namelbl = new System.Windows.Forms.Label();
            this.PblicChtBtn = new System.Windows.Forms.Button();
            this.PrivChatBtn = new System.Windows.Forms.Button();
            this.LfFbtn = new System.Windows.Forms.Button();
            this.Friend = new System.Windows.Forms.ListBox();
            this.AddBtn = new System.Windows.Forms.Button();
            this.Declinebtn = new System.Windows.Forms.Button();
            this.LogOutBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Hellolabel
            // 
            this.Hellolabel.AutoSize = true;
            this.Hellolabel.Location = new System.Drawing.Point(9, 25);
            this.Hellolabel.Name = "Hellolabel";
            this.Hellolabel.Size = new System.Drawing.Size(98, 13);
            this.Hellolabel.TabIndex = 0;
            this.Hellolabel.Text = "Hello,Your name is:";
            this.Hellolabel.Click += new System.EventHandler(this.Hellolabel_Click);
            // 
            // Namelbl
            // 
            this.Namelbl.AutoSize = true;
            this.Namelbl.Location = new System.Drawing.Point(113, 35);
            this.Namelbl.Name = "Namelbl";
            this.Namelbl.Size = new System.Drawing.Size(0, 13);
            this.Namelbl.TabIndex = 1;
            // 
            // PblicChtBtn
            // 
            this.PblicChtBtn.Location = new System.Drawing.Point(12, 67);
            this.PblicChtBtn.Name = "PblicChtBtn";
            this.PblicChtBtn.Size = new System.Drawing.Size(75, 23);
            this.PblicChtBtn.TabIndex = 2;
            this.PblicChtBtn.Text = "Public Chat";
            this.PblicChtBtn.UseVisualStyleBackColor = true;
            this.PblicChtBtn.Click += new System.EventHandler(this.PblicChtBtn_Click);
            // 
            // PrivChatBtn
            // 
            this.PrivChatBtn.Location = new System.Drawing.Point(12, 121);
            this.PrivChatBtn.Name = "PrivChatBtn";
            this.PrivChatBtn.Size = new System.Drawing.Size(75, 23);
            this.PrivChatBtn.TabIndex = 3;
            this.PrivChatBtn.Text = "Private Chat";
            this.PrivChatBtn.UseVisualStyleBackColor = true;
            this.PrivChatBtn.Click += new System.EventHandler(this.PrivChatBtn_Click);
            // 
            // LfFbtn
            // 
            this.LfFbtn.Location = new System.Drawing.Point(9, 173);
            this.LfFbtn.Name = "LfFbtn";
            this.LfFbtn.Size = new System.Drawing.Size(98, 40);
            this.LfFbtn.TabIndex = 4;
            this.LfFbtn.Text = "Look For Friends";
            this.LfFbtn.UseVisualStyleBackColor = true;
            this.LfFbtn.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Friend
            // 
            this.Friend.FormattingEnabled = true;
            this.Friend.Location = new System.Drawing.Point(152, 20);
            this.Friend.Name = "Friend";
            this.Friend.Size = new System.Drawing.Size(156, 95);
            this.Friend.TabIndex = 5;
            this.Friend.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // AddBtn
            // 
            this.AddBtn.Location = new System.Drawing.Point(152, 121);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(75, 23);
            this.AddBtn.TabIndex = 6;
            this.AddBtn.Text = "Accept";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // Declinebtn
            // 
            this.Declinebtn.Location = new System.Drawing.Point(233, 121);
            this.Declinebtn.Name = "Declinebtn";
            this.Declinebtn.Size = new System.Drawing.Size(75, 23);
            this.Declinebtn.TabIndex = 7;
            this.Declinebtn.Text = "Decline";
            this.Declinebtn.UseVisualStyleBackColor = true;
            this.Declinebtn.Click += new System.EventHandler(this.Declinebtn_Click);
            // 
            // LogOutBtn
            // 
            this.LogOutBtn.Location = new System.Drawing.Point(233, 258);
            this.LogOutBtn.Name = "LogOutBtn";
            this.LogOutBtn.Size = new System.Drawing.Size(75, 23);
            this.LogOutBtn.TabIndex = 8;
            this.LogOutBtn.Text = "Log Out";
            this.LogOutBtn.UseVisualStyleBackColor = true;
            this.LogOutBtn.Click += new System.EventHandler(this.LogOutBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 229);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "*Note that changes will take place in the next login.";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // HomeStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 309);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LogOutBtn);
            this.Controls.Add(this.Declinebtn);
            this.Controls.Add(this.AddBtn);
            this.Controls.Add(this.Friend);
            this.Controls.Add(this.LfFbtn);
            this.Controls.Add(this.PrivChatBtn);
            this.Controls.Add(this.PblicChtBtn);
            this.Controls.Add(this.Namelbl);
            this.Controls.Add(this.Hellolabel);
            this.Name = "HomeStart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.HomeStart_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Hellolabel;
        private System.Windows.Forms.Label Namelbl;
        private System.Windows.Forms.Button PblicChtBtn;
        private System.Windows.Forms.Button PrivChatBtn;
        private System.Windows.Forms.Button LfFbtn;
        private System.Windows.Forms.ListBox Friend;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Button Declinebtn;
        private System.Windows.Forms.Button LogOutBtn;
        private System.Windows.Forms.Label label1;
    }
}