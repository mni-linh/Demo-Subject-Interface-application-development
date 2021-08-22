namespace PhatTrienUngDungGiaoDien
{
    partial class LoginForm
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
            this.lblLogin = new System.Windows.Forms.Label();
            this.lblUsr = new System.Windows.Forms.Label();
            this.lblPwd = new System.Windows.Forms.Label();
            this.tbUsr = new System.Windows.Forms.TextBox();
            this.tbPwd = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.rbStudent = new System.Windows.Forms.RadioButton();
            this.rbTeacher = new System.Windows.Forms.RadioButton();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.BackColor = System.Drawing.Color.White;
            this.lblLogin.Font = new System.Drawing.Font("Times New Roman", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogin.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblLogin.Location = new System.Drawing.Point(150, 10);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(280, 49);
            this.lblLogin.TabIndex = 1;
            this.lblLogin.Text = "ĐĂNG NHẬP";
            // 
            // lblUsr
            // 
            this.lblUsr.AutoSize = true;
            this.lblUsr.BackColor = System.Drawing.Color.White;
            this.lblUsr.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsr.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblUsr.Location = new System.Drawing.Point(15, 85);
            this.lblUsr.Name = "lblUsr";
            this.lblUsr.Size = new System.Drawing.Size(142, 35);
            this.lblUsr.TabIndex = 2;
            this.lblUsr.Text = "Tài khoản";
            // 
            // lblPwd
            // 
            this.lblPwd.AutoSize = true;
            this.lblPwd.BackColor = System.Drawing.Color.White;
            this.lblPwd.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPwd.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblPwd.Location = new System.Drawing.Point(15, 137);
            this.lblPwd.Name = "lblPwd";
            this.lblPwd.Size = new System.Drawing.Size(136, 35);
            this.lblPwd.TabIndex = 3;
            this.lblPwd.Text = "Mật khẩu";
            // 
            // tbUsr
            // 
            this.tbUsr.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUsr.Location = new System.Drawing.Point(181, 85);
            this.tbUsr.Name = "tbUsr";
            this.tbUsr.Size = new System.Drawing.Size(249, 34);
            this.tbUsr.TabIndex = 4;
            // 
            // tbPwd
            // 
            this.tbPwd.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPwd.Location = new System.Drawing.Point(181, 138);
            this.tbPwd.Name = "tbPwd";
            this.tbPwd.PasswordChar = '*';
            this.tbPwd.Size = new System.Drawing.Size(249, 34);
            this.tbPwd.TabIndex = 5;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.LightYellow;
            this.btnLogin.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnLogin.Location = new System.Drawing.Point(181, 235);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(190, 43);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // rbStudent
            // 
            this.rbStudent.AutoSize = true;
            this.rbStudent.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbStudent.Location = new System.Drawing.Point(181, 189);
            this.rbStudent.Name = "rbStudent";
            this.rbStudent.Size = new System.Drawing.Size(105, 26);
            this.rbStudent.TabIndex = 7;
            this.rbStudent.TabStop = true;
            this.rbStudent.Text = "Sinh viên";
            this.rbStudent.UseVisualStyleBackColor = true;
            // 
            // rbTeacher
            // 
            this.rbTeacher.AutoSize = true;
            this.rbTeacher.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTeacher.Location = new System.Drawing.Point(313, 189);
            this.rbTeacher.Name = "rbTeacher";
            this.rbTeacher.Size = new System.Drawing.Size(117, 26);
            this.rbTeacher.TabIndex = 8;
            this.rbTeacher.TabStop = true;
            this.rbTeacher.Text = "Giảng viên";
            this.rbTeacher.UseVisualStyleBackColor = true;
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.White;
            this.pnlContent.Controls.Add(this.rbTeacher);
            this.pnlContent.Controls.Add(this.rbStudent);
            this.pnlContent.Controls.Add(this.btnLogin);
            this.pnlContent.Controls.Add(this.tbPwd);
            this.pnlContent.Controls.Add(this.tbUsr);
            this.pnlContent.Controls.Add(this.lblPwd);
            this.pnlContent.Controls.Add(this.lblUsr);
            this.pnlContent.Controls.Add(this.lblLogin);
            this.pnlContent.Location = new System.Drawing.Point(0, -1);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(557, 302);
            this.pnlContent.TabIndex = 1;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 302);
            this.Controls.Add(this.pnlContent);
            this.Name = "LoginForm";
            this.Text = "Đăng nhập";
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label lblLogin;
        public System.Windows.Forms.Label lblUsr;
        public System.Windows.Forms.Label lblPwd;
        public System.Windows.Forms.TextBox tbUsr;
        public System.Windows.Forms.TextBox tbPwd;
        public System.Windows.Forms.Button btnLogin;
        public System.Windows.Forms.RadioButton rbStudent;
        public System.Windows.Forms.RadioButton rbTeacher;
        public System.Windows.Forms.Panel pnlContent;
    }
}

