namespace Login
{
    partial class PublicChat
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
            this.MsgBox = new System.Windows.Forms.TextBox();
            this.MessageShowText = new System.Windows.Forms.RichTextBox();
            this.CollectMsgs = new System.Windows.Forms.Timer(this.components);
            this.TypingLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // MsgBox
            // 
            this.MsgBox.Location = new System.Drawing.Point(35, 278);
            this.MsgBox.Name = "MsgBox";
            this.MsgBox.Size = new System.Drawing.Size(259, 20);
            this.MsgBox.TabIndex = 0;
            this.MsgBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.MsgBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // MessageShowText
            // 
            this.MessageShowText.Location = new System.Drawing.Point(35, 33);
            this.MessageShowText.Name = "MessageShowText";
            this.MessageShowText.ReadOnly = true;
            this.MessageShowText.Size = new System.Drawing.Size(259, 239);
            this.MessageShowText.TabIndex = 1;
            this.MessageShowText.Text = "";
            this.MessageShowText.TextChanged += new System.EventHandler(this.MessageShowText_TextChanged);
            // 
            // CollectMsgs
            // 
            this.CollectMsgs.Enabled = true;
            this.CollectMsgs.Interval = 10;
            this.CollectMsgs.Tick += new System.EventHandler(this.CollectMsgs_Tick);
            // 
            // TypingLabel
            // 
            this.TypingLabel.AutoSize = true;
            this.TypingLabel.Location = new System.Drawing.Point(35, 14);
            this.TypingLabel.Name = "TypingLabel";
            this.TypingLabel.Size = new System.Drawing.Size(70, 13);
            this.TypingLabel.TabIndex = 2;
            this.TypingLabel.Text = "Public Chat...";
            this.TypingLabel.Click += new System.EventHandler(this.TypingLabel_Click);
            // 
            // PublicChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 331);
            this.Controls.Add(this.TypingLabel);
            this.Controls.Add(this.MessageShowText);
            this.Controls.Add(this.MsgBox);
            this.Name = "PublicChat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PublicChat";
            this.Load += new System.EventHandler(this.PublicChat_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox MsgBox;
        private System.Windows.Forms.RichTextBox MessageShowText;
        private System.Windows.Forms.Timer CollectMsgs;
        private System.Windows.Forms.Label TypingLabel;
    }
}