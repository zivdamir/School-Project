namespace Login
{
    partial class PrivChat
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
            this.PrivMsgBox = new System.Windows.Forms.TextBox();
            this.PrivChatBox = new System.Windows.Forms.RichTextBox();
            this.TypingLabel = new System.Windows.Forms.Label();
            this.CollectMsgs = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // PrivMsgBox
            // 
            this.PrivMsgBox.Location = new System.Drawing.Point(17, 247);
            this.PrivMsgBox.Name = "PrivMsgBox";
            this.PrivMsgBox.Size = new System.Drawing.Size(243, 20);
            this.PrivMsgBox.TabIndex = 0;
            this.PrivMsgBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.PrivMsgBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PrivateChatSendMsgBox_KeyDown);
            // 
            // PrivChatBox
            // 
            this.PrivChatBox.Location = new System.Drawing.Point(17, 31);
            this.PrivChatBox.Name = "PrivChatBox";
            this.PrivChatBox.ReadOnly = true;
            this.PrivChatBox.Size = new System.Drawing.Size(238, 210);
            this.PrivChatBox.TabIndex = 1;
            this.PrivChatBox.Text = "";
          
            // 
            // TypingLabel
            // 
            this.TypingLabel.AutoSize = true;
            this.TypingLabel.Location = new System.Drawing.Point(14, 9);
            this.TypingLabel.Name = "TypingLabel";
            this.TypingLabel.Size = new System.Drawing.Size(74, 13);
            this.TypingLabel.TabIndex = 2;
            this.TypingLabel.Text = "Private Chat...";
            // 
            // CollectMsgs
            // 
            this.CollectMsgs.Enabled = true;
            this.CollectMsgs.Tick += new System.EventHandler(this.CollectMsgs_Tick);
            // 
            // PrivChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 279);
            this.Controls.Add(this.TypingLabel);
            this.Controls.Add(this.PrivChatBox);
            this.Controls.Add(this.PrivMsgBox);
            this.Name = "PrivChat";
            this.Text = "PrivChat";
            this.Load += new System.EventHandler(this.PrivChat_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox PrivMsgBox;
        private System.Windows.Forms.RichTextBox PrivChatBox;
        private System.Windows.Forms.Label TypingLabel;
        private System.Windows.Forms.Timer CollectMsgs;
    }
}