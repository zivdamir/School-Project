namespace Login
{
    partial class FriendChoose
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
            this.FriendSelector = new System.Windows.Forms.ListBox();
            this.AddFrindbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FriendSelector
            // 
            this.FriendSelector.FormattingEnabled = true;
            this.FriendSelector.Location = new System.Drawing.Point(12, 12);
            this.FriendSelector.Name = "FriendSelector";
            this.FriendSelector.Size = new System.Drawing.Size(120, 95);
            this.FriendSelector.TabIndex = 0;
            this.FriendSelector.SelectedIndexChanged += new System.EventHandler(this.FriendSelector_SelectedIndexChanged);
            // 
            // AddFrindbtn
            // 
            this.AddFrindbtn.Location = new System.Drawing.Point(12, 152);
            this.AddFrindbtn.Name = "AddFrindbtn";
            this.AddFrindbtn.Size = new System.Drawing.Size(75, 23);
            this.AddFrindbtn.TabIndex = 1;
            this.AddFrindbtn.Text = "Add Friend";
            this.AddFrindbtn.UseVisualStyleBackColor = true;
            this.AddFrindbtn.Click += new System.EventHandler(this.AddFrindbtn_Click);
            // 
            // FriendChoose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.AddFrindbtn);
            this.Controls.Add(this.FriendSelector);
            this.Name = "FriendChoose";
            this.Text = "FriendChoose";
            this.Load += new System.EventHandler(this.FriendChoose_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox FriendSelector;
        private System.Windows.Forms.Button AddFrindbtn;

    }
}