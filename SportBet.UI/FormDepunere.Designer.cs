namespace SportBet.UI
{
    partial class FormDepunere
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
            this.labelSoldCurent = new System.Windows.Forms.Label();
            this.numericUpDownSuma = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelSoldDupa = new System.Windows.Forms.Label();
            this.buttonAnulare = new System.Windows.Forms.Button();
            this.buttonDepunere = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSuma)).BeginInit();
            this.SuspendLayout();
            // 
            // labelSoldCurent
            // 
            this.labelSoldCurent.AutoSize = true;
            this.labelSoldCurent.Location = new System.Drawing.Point(369, 49);
            this.labelSoldCurent.Name = "labelSoldCurent";
            this.labelSoldCurent.Size = new System.Drawing.Size(35, 13);
            this.labelSoldCurent.TabIndex = 0;
            this.labelSoldCurent.Text = "label2";
            // 
            // numericUpDownSuma
            // 
            this.numericUpDownSuma.Location = new System.Drawing.Point(283, 100);
            this.numericUpDownSuma.Name = "numericUpDownSuma";
            this.numericUpDownSuma.Size = new System.Drawing.Size(167, 20);
            this.numericUpDownSuma.TabIndex = 1;
            this.numericUpDownSuma.ValueChanged += new System.EventHandler(this.numericUpDownSuma_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(280, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Suma de depus (RON)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(280, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Sold după depunere: ";
            // 
            // labelSoldDupa
            // 
            this.labelSoldDupa.AutoSize = true;
            this.labelSoldDupa.Location = new System.Drawing.Point(415, 141);
            this.labelSoldDupa.Name = "labelSoldDupa";
            this.labelSoldDupa.Size = new System.Drawing.Size(35, 13);
            this.labelSoldDupa.TabIndex = 4;
            this.labelSoldDupa.Text = "label3";
            // 
            // buttonAnulare
            // 
            this.buttonAnulare.Location = new System.Drawing.Point(283, 170);
            this.buttonAnulare.Name = "buttonAnulare";
            this.buttonAnulare.Size = new System.Drawing.Size(75, 23);
            this.buttonAnulare.TabIndex = 5;
            this.buttonAnulare.Text = "Anulare";
            this.buttonAnulare.UseVisualStyleBackColor = true;
            this.buttonAnulare.Click += new System.EventHandler(this.buttonAnulare_Click);
            // 
            // buttonDepunere
            // 
            this.buttonDepunere.Location = new System.Drawing.Point(375, 170);
            this.buttonDepunere.Name = "buttonDepunere";
            this.buttonDepunere.Size = new System.Drawing.Size(75, 23);
            this.buttonDepunere.TabIndex = 6;
            this.buttonDepunere.Text = "Depunere";
            this.buttonDepunere.UseVisualStyleBackColor = true;
            this.buttonDepunere.Click += new System.EventHandler(this.buttonDepunere_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(280, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Sold curent: ";
            // 
            // FormDepunere
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonDepunere);
            this.Controls.Add(this.buttonAnulare);
            this.Controls.Add(this.labelSoldDupa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDownSuma);
            this.Controls.Add(this.labelSoldCurent);
            this.Name = "FormDepunere";
            this.Text = "FormDepunere";
            this.Load += new System.EventHandler(this.FormDepunere_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSuma)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSoldCurent;
        private System.Windows.Forms.NumericUpDown numericUpDownSuma;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelSoldDupa;
        private System.Windows.Forms.Button buttonAnulare;
        private System.Windows.Forms.Button buttonDepunere;
        private System.Windows.Forms.Label label3;
    }
}