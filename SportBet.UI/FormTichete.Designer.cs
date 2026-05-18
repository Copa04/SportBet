namespace SportBet.UI
{
    partial class FormTichete
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
            this.listViewTichete = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelDataPlasare = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelMiza = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelCastigPotential = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelCotaTotala = new System.Windows.Forms.Label();
            this.listViewPariuri = new System.Windows.Forms.ListView();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonInchide = new System.Windows.Forms.Button();
            this.labelMesaj = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewTichete
            // 
            this.listViewTichete.HideSelection = false;
            this.listViewTichete.Location = new System.Drawing.Point(12, 40);
            this.listViewTichete.Name = "listViewTichete";
            this.listViewTichete.Size = new System.Drawing.Size(367, 494);
            this.listViewTichete.TabIndex = 0;
            this.listViewTichete.UseCompatibleStateImageBehavior = false;
            this.listViewTichete.SelectedIndexChanged += new System.EventHandler(this.listViewTichete_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonInchide);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.listViewPariuri);
            this.groupBox1.Controls.Add(this.labelCotaTotala);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.labelStatus);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.labelCastigPotential);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.labelMiza);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.labelDataPlasare);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(491, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(964, 560);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalii tichet selectat";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data plasare:";
            // 
            // labelDataPlasare
            // 
            this.labelDataPlasare.AutoSize = true;
            this.labelDataPlasare.Location = new System.Drawing.Point(29, 62);
            this.labelDataPlasare.Name = "labelDataPlasare";
            this.labelDataPlasare.Size = new System.Drawing.Size(35, 13);
            this.labelDataPlasare.TabIndex = 1;
            this.labelDataPlasare.Text = "label2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Miza:";
            // 
            // labelMiza
            // 
            this.labelMiza.AutoSize = true;
            this.labelMiza.Location = new System.Drawing.Point(29, 112);
            this.labelMiza.Name = "labelMiza";
            this.labelMiza.Size = new System.Drawing.Size(35, 13);
            this.labelMiza.TabIndex = 3;
            this.labelMiza.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Câștig potențial:";
            // 
            // labelCastigPotential
            // 
            this.labelCastigPotential.AutoSize = true;
            this.labelCastigPotential.Location = new System.Drawing.Point(29, 158);
            this.labelCastigPotential.Name = "labelCastigPotential";
            this.labelCastigPotential.Size = new System.Drawing.Size(35, 13);
            this.labelCastigPotential.TabIndex = 5;
            this.labelCastigPotential.Text = "label2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(455, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Status:";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(455, 62);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(35, 13);
            this.labelStatus.TabIndex = 7;
            this.labelStatus.Text = "label2";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(455, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Cota totală:";
            // 
            // labelCotaTotala
            // 
            this.labelCotaTotala.AutoSize = true;
            this.labelCotaTotala.Location = new System.Drawing.Point(455, 112);
            this.labelCotaTotala.Name = "labelCotaTotala";
            this.labelCotaTotala.Size = new System.Drawing.Size(35, 13);
            this.labelCotaTotala.TabIndex = 9;
            this.labelCotaTotala.Text = "label2";
            // 
            // listViewPariuri
            // 
            this.listViewPariuri.HideSelection = false;
            this.listViewPariuri.Location = new System.Drawing.Point(32, 217);
            this.listViewPariuri.Name = "listViewPariuri";
            this.listViewPariuri.Size = new System.Drawing.Size(901, 304);
            this.listViewPariuri.TabIndex = 10;
            this.listViewPariuri.UseCompatibleStateImageBehavior = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Listă tichete:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 189);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Pariurile din tichet:";
            // 
            // buttonInchide
            // 
            this.buttonInchide.Location = new System.Drawing.Point(858, 527);
            this.buttonInchide.Name = "buttonInchide";
            this.buttonInchide.Size = new System.Drawing.Size(75, 23);
            this.buttonInchide.TabIndex = 12;
            this.buttonInchide.Text = "Închide";
            this.buttonInchide.UseVisualStyleBackColor = true;
            this.buttonInchide.Click += new System.EventHandler(this.buttonInchide_Click);
            // 
            // labelMesaj
            // 
            this.labelMesaj.AutoSize = true;
            this.labelMesaj.Location = new System.Drawing.Point(12, 550);
            this.labelMesaj.Name = "labelMesaj";
            this.labelMesaj.Size = new System.Drawing.Size(35, 13);
            this.labelMesaj.TabIndex = 12;
            this.labelMesaj.Text = "label8";
            // 
            // FormTichete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1467, 585);
            this.Controls.Add(this.labelMesaj);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listViewTichete);
            this.Name = "FormTichete";
            this.Text = "FormTichete";
            this.Load += new System.EventHandler(this.FormTichete_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewTichete;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelCastigPotential;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelMiza;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelDataPlasare;
        private System.Windows.Forms.Button buttonInchide;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListView listViewPariuri;
        private System.Windows.Forms.Label labelCotaTotala;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelMesaj;
    }
}