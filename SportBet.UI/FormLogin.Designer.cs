namespace SportBet.UI
{
    partial class FormLogin
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxUtilizator = new System.Windows.Forms.TextBox();
            this.textBoxParola = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.buttonAutentificare = new System.Windows.Forms.Button();
            this.buttonInregistare = new System.Windows.Forms.Button();
            this.buttonAjutor = new System.Windows.Forms.Button();
            this.buttonIesire = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1047, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "SportBet";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1047, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(275, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Conectează-te la contul tău";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1047, 261);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nume utilizator";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1047, 377);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Parolă";
            // 
            // textBoxUtilizator
            // 
            this.textBoxUtilizator.Location = new System.Drawing.Point(1052, 289);
            this.textBoxUtilizator.Name = "textBoxUtilizator";
            this.textBoxUtilizator.Size = new System.Drawing.Size(270, 31);
            this.textBoxUtilizator.TabIndex = 4;
            // 
            // textBoxParola
            // 
            this.textBoxParola.Location = new System.Drawing.Point(1052, 405);
            this.textBoxParola.Name = "textBoxParola";
            this.textBoxParola.PasswordChar = '*';
            this.textBoxParola.Size = new System.Drawing.Size(270, 31);
            this.textBoxParola.TabIndex = 5;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(1052, 453);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(180, 29);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "Ține-mă minte";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // buttonAutentificare
            // 
            this.buttonAutentificare.Location = new System.Drawing.Point(1052, 501);
            this.buttonAutentificare.Name = "buttonAutentificare";
            this.buttonAutentificare.Size = new System.Drawing.Size(270, 46);
            this.buttonAutentificare.TabIndex = 7;
            this.buttonAutentificare.Text = "Autentificare";
            this.buttonAutentificare.UseVisualStyleBackColor = true;
            this.buttonAutentificare.Click += new System.EventHandler(this.buttonAutentificare_Click);
            // 
            // buttonInregistare
            // 
            this.buttonInregistare.Location = new System.Drawing.Point(1052, 573);
            this.buttonInregistare.Name = "buttonInregistare";
            this.buttonInregistare.Size = new System.Drawing.Size(270, 46);
            this.buttonInregistare.TabIndex = 8;
            this.buttonInregistare.Text = "Înregistrare";
            this.buttonInregistare.UseVisualStyleBackColor = true;
            this.buttonInregistare.Click += new System.EventHandler(this.buttonInregistrare_Click);
            // 
            // buttonAjutor
            // 
            this.buttonAjutor.Location = new System.Drawing.Point(844, 697);
            this.buttonAjutor.Name = "buttonAjutor";
            this.buttonAjutor.Size = new System.Drawing.Size(104, 61);
            this.buttonAjutor.TabIndex = 9;
            this.buttonAjutor.Text = "Ajutor";
            this.buttonAjutor.UseVisualStyleBackColor = true;
            // 
            // buttonIesire
            // 
            this.buttonIesire.Location = new System.Drawing.Point(1393, 697);
            this.buttonIesire.Name = "buttonIesire";
            this.buttonIesire.Size = new System.Drawing.Size(104, 61);
            this.buttonIesire.TabIndex = 10;
            this.buttonIesire.Text = "Ieșire";
            this.buttonIesire.UseVisualStyleBackColor = true;
            this.buttonIesire.Click += new System.EventHandler(this.buttonIesire_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.ForeColor = System.Drawing.Color.Red;
            this.labelStatus.Location = new System.Drawing.Point(1047, 643);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(73, 25);
            this.labelStatus.TabIndex = 11;
            this.labelStatus.Text = "Status";
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2404, 952);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.buttonIesire);
            this.Controls.Add(this.buttonAjutor);
            this.Controls.Add(this.buttonInregistare);
            this.Controls.Add(this.buttonAutentificare);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.textBoxParola);
            this.Controls.Add(this.textBoxUtilizator);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormLogin";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxUtilizator;
        private System.Windows.Forms.TextBox textBoxParola;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button buttonAutentificare;
        private System.Windows.Forms.Button buttonInregistare;
        private System.Windows.Forms.Button buttonAjutor;
        private System.Windows.Forms.Button buttonIesire;
        private System.Windows.Forms.Label labelStatus;
    }
}

