namespace Login
{
    partial class PrivateFriendsChoose
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
            this.components = new System.ComponentModel.Container();
            this.PrivateChatFriendsSelector = new System.Windows.Forms.ListBox();
            this.Sndrequstbtn = new System.Windows.Forms.Button();
            this.FriendsUpdater = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // PrivateChatFriendsSelector
            // 
            this.PrivateChatFriendsSelector.FormattingEnabled = true;
            this.PrivateChatFriendsSelector.Location = new System.Drawing.Point(12, 12);
            this.PrivateChatFriendsSelector.Name = "PrivateChatFriendsSelector";
            this.PrivateChatFriendsSelector.Size = new System.Drawing.Size(119, 160);
            this.PrivateChatFriendsSelector.TabIndex = 0;
            this.PrivateChatFriendsSelector.SelectedIndexChanged += new System.EventHandler(this.PrivateChatFriendsSelector_SelectedIndexChanged);
            // 
            // Sndrequstbtn
            // 
            this.Sndrequstbtn.Location = new System.Drawing.Point(12, 188);
            this.Sndrequstbtn.Name = "Sndrequstbtn";
            this.Sndrequstbtn.Size = new System.Drawing.Size(151, 22);
            this.Sndrequstbtn.TabIndex = 1;
            this.Sndrequstbtn.Text = "Send Request To Chat";
            this.Sndrequstbtn.UseVisualStyleBackColor = true;
            this.Sndrequstbtn.Click += new System.EventHandler(this.Sndrequstbtn_Click);
            // 
            // FriendsUpdater
            // 
            this.FriendsUpdater.Enabled = true;
            this.FriendsUpdater.Interval = 3000;
            this.FriendsUpdater.Tick += new System.EventHandler(this.FriendsUpdater_Tick);
            // 
            // PrivateFriendsChoose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.Sndrequstbtn);
            this.Controls.Add(this.PrivateChatFriendsSelector);
            this.Name = "PrivateFriendsChoose";
            this.Text = "Private Friends Choose";
            this.Load += new System.EventHandler(this.PrivateFriendsChoose_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox PrivateChatFriendsSelector;
        private System.Windows.Forms.Button Sndrequstbtn;
        private System.Windows.Forms.Timer FriendsUpdater;
    }
}