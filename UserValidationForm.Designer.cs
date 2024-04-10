namespace File_Handling_Program
{
    partial class UserValidationForm
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
            this.UserName = new System.Windows.Forms.TextBox();
            this.LogIn = new System.Windows.Forms.Button();
            this.Text_Password = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbl_UserID = new System.Windows.Forms.Label();
            this.lbl_Password = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // UserName
            // 
            this.UserName.Location = new System.Drawing.Point(250, 129);
            this.UserName.Multiline = true;
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(264, 35);
            this.UserName.TabIndex = 0;
            // 
            // LogIn
            // 
            this.LogIn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.LogIn.Location = new System.Drawing.Point(328, 256);
            this.LogIn.Name = "LogIn";
            this.LogIn.Size = new System.Drawing.Size(105, 29);
            this.LogIn.TabIndex = 2;
            this.LogIn.Text = "LogIn";
            this.LogIn.UseVisualStyleBackColor = false;
            this.LogIn.Click += new System.EventHandler(this.LogIn_Click);
            // 
            // Text_Password
            // 
            this.Text_Password.Location = new System.Drawing.Point(250, 186);
            this.Text_Password.Multiline = true;
            this.Text_Password.Name = "Text_Password";
            this.Text_Password.PasswordChar = '*';
            this.Text_Password.Size = new System.Drawing.Size(264, 36);
            this.Text_Password.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::File_Handling_Program.Properties.Resources.userddd;
            this.pictureBox1.Location = new System.Drawing.Point(333, 44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 62);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // lbl_UserID
            // 
            this.lbl_UserID.AutoSize = true;
            this.lbl_UserID.Location = new System.Drawing.Point(158, 132);
            this.lbl_UserID.Name = "lbl_UserID";
            this.lbl_UserID.Size = new System.Drawing.Size(49, 16);
            this.lbl_UserID.TabIndex = 5;
            this.lbl_UserID.Text = "UserID";
            // 
            // lbl_Password
            // 
            this.lbl_Password.AutoSize = true;
            this.lbl_Password.Location = new System.Drawing.Point(140, 189);
            this.lbl_Password.Name = "lbl_Password";
            this.lbl_Password.Size = new System.Drawing.Size(67, 16);
            this.lbl_Password.TabIndex = 6;
            this.lbl_Password.Text = "Password";
            // 
            // UserValidationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbl_Password);
            this.Controls.Add(this.lbl_UserID);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Text_Password);
            this.Controls.Add(this.LogIn);
            this.Controls.Add(this.UserName);
            this.Name = "UserValidationForm";
            this.Text = "UserValidation";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UserName;
        private System.Windows.Forms.Button LogIn;
        private System.Windows.Forms.TextBox Text_Password;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl_UserID;
        private System.Windows.Forms.Label lbl_Password;
    }
}