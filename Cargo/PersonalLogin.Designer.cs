namespace Cargo
{
    partial class PersonalLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PersonalLogin));
            this.txtauser = new System.Windows.Forms.TextBox();
            this.txtapass = new System.Windows.Forms.TextBox();
            this.btnadminlogin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtauser
            // 
            this.txtauser.Location = new System.Drawing.Point(94, 86);
            this.txtauser.Margin = new System.Windows.Forms.Padding(4);
            this.txtauser.Name = "txtauser";
            this.txtauser.Size = new System.Drawing.Size(279, 28);
            this.txtauser.TabIndex = 0;
            // 
            // txtapass
            // 
            this.txtapass.Location = new System.Drawing.Point(94, 211);
            this.txtapass.Margin = new System.Windows.Forms.Padding(4);
            this.txtapass.Name = "txtapass";
            this.txtapass.Size = new System.Drawing.Size(279, 28);
            this.txtapass.TabIndex = 1;
            // 
            // btnadminlogin
            // 
            this.btnadminlogin.Location = new System.Drawing.Point(143, 296);
            this.btnadminlogin.Margin = new System.Windows.Forms.Padding(4);
            this.btnadminlogin.Name = "btnadminlogin";
            this.btnadminlogin.Size = new System.Drawing.Size(178, 65);
            this.btnadminlogin.TabIndex = 2;
            this.btnadminlogin.Text = "Giriş Yap";
            this.btnadminlogin.UseVisualStyleBackColor = true;
            this.btnadminlogin.Click += new System.EventHandler(this.btnadminlogin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(178, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 22);
            this.label1.TabIndex = 3;
            this.label1.Text = "Kullanıcı Adı";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(200, 171);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 22);
            this.label2.TabIndex = 4;
            this.label2.Text = "Parola";
            // 
            // PersonalLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 409);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnadminlogin);
            this.Controls.Add(this.txtapass);
            this.Controls.Add(this.txtauser);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "PersonalLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Personel Giriş";
            this.Load += new System.EventHandler(this.AdminLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtauser;
        private System.Windows.Forms.TextBox txtapass;
        private System.Windows.Forms.Button btnadminlogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}