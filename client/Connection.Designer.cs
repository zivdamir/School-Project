namespace Login
{
    partial class Connection
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
            this.label1 = new System.Windows.Forms.Label();
            this.Connectbtn = new System.Windows.Forms.Button();
            this.IpConnectionText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter the ip of the server please:";
            // 
            // Connectbtn
            // 
            this.Connectbtn.Location = new System.Drawing.Point(12, 73);
            this.Connectbtn.Name = "Connectbtn";
            this.Connectbtn.Size = new System.Drawing.Size(75, 23);
            this.Connectbtn.TabIndex = 1;
            this.Connectbtn.Text = "Connect!";
            this.Connectbtn.UseVisualStyleBackColor = true;
            this.Connectbtn.Click += new System.EventHandler(this.Connectbtn_Click);
            // 
            // IpConnectionText
            // 
            this.IpConnectionText.Location = new System.Drawing.Point(12, 25);
            this.IpConnectionText.Name = "IpConnectionText";
            this.IpConnectionText.Size = new System.Drawing.Size(283, 20);
            this.IpConnectionText.TabIndex = 2;
            // 
            // Connection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 100);
            this.Controls.Add(this.IpConnectionText);
            this.Controls.Add(this.Connectbtn);
            this.Controls.Add(this.label1);
            this.Name = "Connection";
            this.Text = "Welcome";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Connectbtn;
        private System.Windows.Forms.TextBox IpConnectionText;
    }
}