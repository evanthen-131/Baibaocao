namespace C_App.GUI
{
    partial class Login
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
            System.Windows.Forms.Label label1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.Logo = new System.Windows.Forms.PictureBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtTK = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtMK = new System.Windows.Forms.TextBox();
            this.btnDN = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            label1.Cursor = System.Windows.Forms.Cursors.Default;
            label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            label1.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(315, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(229, 41);
            label1.TabIndex = 7;
            label1.Text = "Hệ thống quản lí ";
            label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            label1.UseCompatibleTextRendering = true;
            // 
            // Logo
            // 
            this.Logo.Image = ((System.Drawing.Image)(resources.GetObject("Logo.Image")));
            this.Logo.Location = new System.Drawing.Point(12, 15);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(216, 183);
            this.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Logo.TabIndex = 0;
            this.Logo.TabStop = false;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(260, 68);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(81, 13);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Tên đăng nhập";
            // 
            // txtTK
            // 
            this.txtTK.Location = new System.Drawing.Point(263, 84);
            this.txtTK.Name = "txtTK";
            this.txtTK.Size = new System.Drawing.Size(326, 20);
            this.txtTK.TabIndex = 2;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(260, 115);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(52, 13);
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Text = "Mật khẩu";
            // 
            // txtMK
            // 
            this.txtMK.Location = new System.Drawing.Point(263, 131);
            this.txtMK.Name = "txtMK";
            this.txtMK.Size = new System.Drawing.Size(326, 20);
            this.txtMK.TabIndex = 2;
            // 
            // btnDN
            // 
            this.btnDN.Location = new System.Drawing.Point(329, 172);
            this.btnDN.Name = "btnDN";
            this.btnDN.Size = new System.Drawing.Size(75, 23);
            this.btnDN.TabIndex = 8;
            this.btnDN.Text = "Đăng nhập";
            this.btnDN.UseVisualStyleBackColor = true;
            this.btnDN.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Location = new System.Drawing.Point(455, 172);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(89, 23);
            this.btn_Exit.TabIndex = 9;
            this.btn_Exit.Text = "Thoát";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 212);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btnDN);
            this.Controls.Add(label1);
            this.Controls.Add(this.txtMK);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtTK);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.Logo);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Logo;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtTK;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtMK;
        private System.Windows.Forms.Button btnDN;
        private System.Windows.Forms.Button btn_Exit;
    }
}