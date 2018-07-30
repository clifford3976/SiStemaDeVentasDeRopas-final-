namespace SistemaDeVentas
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
            this.components = new System.ComponentModel.Container();
            this.LogInerrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.ClavetextBox = new System.Windows.Forms.TextBox();
            this.UsuariologtextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Loginbutton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.LogInerrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // LogInerrorProvider
            // 
            this.LogInerrorProvider.ContainerControl = this;
            // 
            // ClavetextBox
            // 
            this.ClavetextBox.Location = new System.Drawing.Point(81, 222);
            this.ClavetextBox.MaxLength = 6;
            this.ClavetextBox.Name = "ClavetextBox";
            this.ClavetextBox.PasswordChar = '*';
            this.ClavetextBox.Size = new System.Drawing.Size(190, 20);
            this.ClavetextBox.TabIndex = 21;
            // 
            // UsuariologtextBox
            // 
            this.UsuariologtextBox.Location = new System.Drawing.Point(81, 167);
            this.UsuariologtextBox.Name = "UsuariologtextBox";
            this.UsuariologtextBox.Size = new System.Drawing.Size(190, 20);
            this.UsuariologtextBox.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(146, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Contrasena";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(155, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Usuario";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SistemaDeVentas.Properties.Resources._595d28b49c63372473d313967a3f2ce6;
            this.pictureBox1.Location = new System.Drawing.Point(45, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(280, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // Loginbutton
            // 
            this.Loginbutton.Image = global::SistemaDeVentas.Properties.Resources.icons8_Lock_32;
            this.Loginbutton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Loginbutton.Location = new System.Drawing.Point(137, 252);
            this.Loginbutton.Name = "Loginbutton";
            this.Loginbutton.Size = new System.Drawing.Size(83, 49);
            this.Loginbutton.TabIndex = 22;
            this.Loginbutton.Text = "Log in";
            this.Loginbutton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Loginbutton.UseVisualStyleBackColor = true;
            this.Loginbutton.Click += new System.EventHandler(this.Loginbutton_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(371, 307);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Loginbutton);
            this.Controls.Add(this.ClavetextBox);
            this.Controls.Add(this.UsuariologtextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(387, 346);
            this.MinimumSize = new System.Drawing.Size(387, 346);
            this.Name = "Login";
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.LogInerrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider LogInerrorProvider;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Loginbutton;
        private System.Windows.Forms.TextBox ClavetextBox;
        private System.Windows.Forms.TextBox UsuariologtextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}