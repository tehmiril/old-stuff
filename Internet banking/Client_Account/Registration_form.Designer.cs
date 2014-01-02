namespace Client_Account
{
    partial class Registration_form
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
            this.textBox_residence = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_username = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.textBox_accNo = new System.Windows.Forms.TextBox();
            this.label_password = new System.Windows.Forms.Label();
            this.label_account = new System.Windows.Forms.Label();
            this.button_registration = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // textBox_residence
            // 
            this.textBox_residence.Location = new System.Drawing.Point(134, 108);
            this.textBox_residence.Name = "textBox_residence";
            this.textBox_residence.Size = new System.Drawing.Size(137, 20);
            this.textBox_residence.TabIndex = 38;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Residence";
            // 
            // textBox_username
            // 
            this.textBox_username.Location = new System.Drawing.Point(134, 47);
            this.textBox_username.Name = "textBox_username";
            this.textBox_username.Size = new System.Drawing.Size(137, 20);
            this.textBox_username.TabIndex = 36;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "Username";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 213);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "label1";
            // 
            // textBox_password
            // 
            this.textBox_password.Location = new System.Drawing.Point(134, 73);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.PasswordChar = '*';
            this.textBox_password.Size = new System.Drawing.Size(137, 20);
            this.textBox_password.TabIndex = 33;
            // 
            // textBox_accNo
            // 
            this.textBox_accNo.Location = new System.Drawing.Point(134, 18);
            this.textBox_accNo.Name = "textBox_accNo";
            this.textBox_accNo.Size = new System.Drawing.Size(137, 20);
            this.textBox_accNo.TabIndex = 32;
            // 
            // label_password
            // 
            this.label_password.AutoSize = true;
            this.label_password.Location = new System.Drawing.Point(35, 76);
            this.label_password.Name = "label_password";
            this.label_password.Size = new System.Drawing.Size(53, 13);
            this.label_password.TabIndex = 31;
            this.label_password.Text = "Password";
            // 
            // label_account
            // 
            this.label_account.AutoSize = true;
            this.label_account.Location = new System.Drawing.Point(35, 18);
            this.label_account.Name = "label_account";
            this.label_account.Size = new System.Drawing.Size(67, 13);
            this.label_account.TabIndex = 30;
            this.label_account.Text = "Account_No";
            // 
            // button_registration
            // 
            this.button_registration.Location = new System.Drawing.Point(134, 156);
            this.button_registration.Name = "button_registration";
            this.button_registration.Size = new System.Drawing.Size(137, 44);
            this.button_registration.TabIndex = 29;
            this.button_registration.Text = "Register";
            this.button_registration.UseVisualStyleBackColor = true;
            this.button_registration.Click += new System.EventHandler(this.button_registration_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(29, 142);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(41, 17);
            this.listBox1.TabIndex = 39;
            // 
            // Registration_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 245);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.textBox_residence);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_username);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_password);
            this.Controls.Add(this.textBox_accNo);
            this.Controls.Add(this.label_password);
            this.Controls.Add(this.label_account);
            this.Controls.Add(this.button_registration);
            this.Name = "Registration_form";
            this.Text = "Registration";
            this.Load += new System.EventHandler(this.Registration_GUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_residence;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_username;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.TextBox textBox_accNo;
        private System.Windows.Forms.Label label_password;
        private System.Windows.Forms.Label label_account;
        private System.Windows.Forms.Button button_registration;
        private System.Windows.Forms.ListBox listBox1;

    }
}