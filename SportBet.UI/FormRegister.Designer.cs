namespace SportBet.UI
{
    partial class FormRegister
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
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxConfirmaParola = new System.Windows.Forms.TextBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.buttonInregistrare = new System.Windows.Forms.Button();
            this.buttonInapoi = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDownSold = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSold)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1102, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "SportBet";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1102, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Înregistrare";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1102, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nume utilizator";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1102, 303);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Parolă";
            // 
            // textBoxUtilizator
            // 
            this.textBoxUtilizator.Location = new System.Drawing.Point(1107, 217);
            this.textBoxUtilizator.Name = "textBoxUtilizator";
            this.textBoxUtilizator.Size = new System.Drawing.Size(211, 31);
            this.textBoxUtilizator.TabIndex = 4;
            // 
            // textBoxParola
            // 
            this.textBoxParola.Location = new System.Drawing.Point(1107, 331);
            this.textBoxParola.Name = "textBoxParola";
            this.textBoxParola.PasswordChar = '*';
            this.textBoxParola.Size = new System.Drawing.Size(211, 31);
            this.textBoxParola.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1102, 418);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(164, 75);
            this.label5.TabIndex = 6;
            this.label5.Text = "Confirmă parola\r\n\r\n\r\n";
            // 
            // textBoxConfirmaParola
            // 
            this.textBoxConfirmaParola.Location = new System.Drawing.Point(1107, 446);
            this.textBoxConfirmaParola.Name = "textBoxConfirmaParola";
            this.textBoxConfirmaParola.PasswordChar = '*';
            this.textBoxConfirmaParola.Size = new System.Drawing.Size(211, 31);
            this.textBoxConfirmaParola.TabIndex = 7;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.ForeColor = System.Drawing.Color.Red;
            this.labelStatus.Location = new System.Drawing.Point(1102, 637);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(73, 25);
            this.labelStatus.TabIndex = 12;
            this.labelStatus.Text = "Status";
            // 
            // buttonInregistrare
            // 
            this.buttonInregistrare.Location = new System.Drawing.Point(896, 675);
            this.buttonInregistrare.Name = "buttonInregistrare";
            this.buttonInregistrare.Size = new System.Drawing.Size(178, 61);
            this.buttonInregistrare.TabIndex = 13;
            this.buttonInregistrare.Text = "Înregistrare";
            this.buttonInregistrare.UseVisualStyleBackColor = true;
            this.buttonInregistrare.Click += new System.EventHandler(this.buttonInregistrare_Click);
            // 
            // buttonInapoi
            // 
            this.buttonInapoi.Location = new System.Drawing.Point(1356, 675);
            this.buttonInapoi.Name = "buttonInapoi";
            this.buttonInapoi.Size = new System.Drawing.Size(178, 61);
            this.buttonInapoi.TabIndex = 14;
            this.buttonInapoi.Text = "Înapoi";
            this.buttonInapoi.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1102, 506);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 25);
            this.label7.TabIndex = 15;
            this.label7.Text = "Depune";
            // 
            // numericUpDownSold
            // 
            this.numericUpDownSold.Location = new System.Drawing.Point(1107, 543);
            this.numericUpDownSold.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownSold.Name = "numericUpDownSold";
            this.numericUpDownSold.Size = new System.Drawing.Size(211, 31);
            this.numericUpDownSold.TabIndex = 17;
            this.numericUpDownSold.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // FormRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2516, 906);
            this.Controls.Add(this.numericUpDownSold);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.buttonInapoi);
            this.Controls.Add(this.buttonInregistrare);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.textBoxConfirmaParola);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxParola);
            this.Controls.Add(this.textBoxUtilizator);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormRegister";
            this.Text = "FormRegister";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSold)).EndInit();
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxConfirmaParola;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button buttonInregistrare;
        private System.Windows.Forms.Button buttonInapoi;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDownSold;
    }
}