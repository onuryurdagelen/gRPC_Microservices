namespace gRPC_WFormUI
{
    partial class Ayarlar
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
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPassShow = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Location = new System.Drawing.Point(123, 254);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(275, 47);
            this.btnSaveSettings.TabIndex = 17;
            this.btnSaveSettings.Text = "Kaydet";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click_1);
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(198, 84);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(214, 23);
            this.txtDatabase.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(72, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "Veritabanı";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(198, 41);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(214, 23);
            this.txtServer.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(72, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "Server";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(198, 186);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(214, 23);
            this.txtPassword.TabIndex = 12;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "Şifre";
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(198, 132);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(214, 23);
            this.txtUserId.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Kullanıcı Id";
            // 
            // btnPassShow
            // 
            this.btnPassShow.Location = new System.Drawing.Point(428, 186);
            this.btnPassShow.Name = "btnPassShow";
            this.btnPassShow.Size = new System.Drawing.Size(48, 26);
            this.btnPassShow.TabIndex = 19;
            this.btnPassShow.Text = "Show";
            this.btnPassShow.UseVisualStyleBackColor = true;
            this.btnPassShow.Click += new System.EventHandler(this.btnPassShow_Click);
            // 
            // Ayarlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 450);
            this.Controls.Add(this.btnPassShow);
            this.Controls.Add(this.btnSaveSettings);
            this.Controls.Add(this.txtDatabase);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUserId);
            this.Controls.Add(this.label1);
            this.Name = "Ayarlar";
            this.Text = "Ayarlar";
            this.Load += new System.EventHandler(this.Ayarlar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnSaveSettings;
        private TextBox txtDatabase;
        private Label label4;
        private TextBox txtServer;
        private Label label3;
        private TextBox txtPassword;
        private Label label2;
        private TextBox txtUserId;
        private Label label1;
        private Button btnPassShow;
    }
}