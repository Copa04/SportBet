namespace SportBet.UI
{
    partial class FormPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonMeciuri = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonTicheteleMele = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDepunere = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabelProfil = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabelSold = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButtonIesire = new System.Windows.Forms.ToolStripButton();
            this.listViewMeciuri = new System.Windows.Forms.ListView();
            this.buttonPlaseazaPariu = new System.Windows.Forms.Button();
            this.panelTichet = new System.Windows.Forms.Panel();
            this.labelMeciuri = new System.Windows.Forms.Label();
            this.labelTichetCurent = new System.Windows.Forms.Label();
            this.labelCotaTotala = new System.Windows.Forms.Label();
            this.labelCastigPotential = new System.Windows.Forms.Label();
            this.labelSoldDisponibil = new System.Windows.Forms.Label();
            this.buttonStergePariu = new System.Windows.Forms.Button();
            this.buttonStergeTot = new System.Windows.Forms.Button();
            this.buttonFinalizeazaTichet = new System.Windows.Forms.Button();
            this.labelMesaj = new System.Windows.Forms.Label();
            this.listViewTichetCurent = new System.Windows.Forms.ListView();
            this.labelMizaTotala = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.panelTichet.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonMeciuri,
            this.toolStripButtonTicheteleMele,
            this.toolStripButtonDepunere,
            this.toolStripSeparator1,
            this.toolStripLabelProfil,
            this.toolStripLabelSold,
            this.toolStripButtonIesire});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.Size = new System.Drawing.Size(1487, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonMeciuri
            // 
            this.toolStripButtonMeciuri.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonMeciuri.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonMeciuri.Image")));
            this.toolStripButtonMeciuri.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonMeciuri.Name = "toolStripButtonMeciuri";
            this.toolStripButtonMeciuri.Size = new System.Drawing.Size(51, 22);
            this.toolStripButtonMeciuri.Text = "Meciuri";
            this.toolStripButtonMeciuri.Click += new System.EventHandler(this.toolStripButtonMeciuri_Click);
            // 
            // toolStripButtonTicheteleMele
            // 
            this.toolStripButtonTicheteleMele.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonTicheteleMele.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonTicheteleMele.Image")));
            this.toolStripButtonTicheteleMele.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonTicheteleMele.Name = "toolStripButtonTicheteleMele";
            this.toolStripButtonTicheteleMele.Size = new System.Drawing.Size(88, 22);
            this.toolStripButtonTicheteleMele.Text = "Tichetele mele";
            this.toolStripButtonTicheteleMele.Click += new System.EventHandler(this.toolStripButtonTicheteleMele_Click);
            // 
            // toolStripButtonDepunere
            // 
            this.toolStripButtonDepunere.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonDepunere.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDepunere.Image")));
            this.toolStripButtonDepunere.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDepunere.Name = "toolStripButtonDepunere";
            this.toolStripButtonDepunere.Size = new System.Drawing.Size(62, 22);
            this.toolStripButtonDepunere.Text = "Depunere";
            this.toolStripButtonDepunere.Click += new System.EventHandler(this.toolStripButtonDepunere_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabelProfil
            // 
            this.toolStripLabelProfil.Name = "toolStripLabelProfil";
            this.toolStripLabelProfil.Size = new System.Drawing.Size(35, 22);
            this.toolStripLabelProfil.Text = "Profil";
            // 
            // toolStripLabelSold
            // 
            this.toolStripLabelSold.Name = "toolStripLabelSold";
            this.toolStripLabelSold.Size = new System.Drawing.Size(30, 22);
            this.toolStripLabelSold.Text = "Sold";
            // 
            // toolStripButtonIesire
            // 
            this.toolStripButtonIesire.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonIesire.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonIesire.Image")));
            this.toolStripButtonIesire.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonIesire.Name = "toolStripButtonIesire";
            this.toolStripButtonIesire.Size = new System.Drawing.Size(38, 22);
            this.toolStripButtonIesire.Text = "Ieșire";
            this.toolStripButtonIesire.Click += new System.EventHandler(this.toolStripButtonIesire_Click);
            // 
            // listViewMeciuri
            // 
            this.listViewMeciuri.HideSelection = false;
            this.listViewMeciuri.Location = new System.Drawing.Point(6, 84);
            this.listViewMeciuri.Margin = new System.Windows.Forms.Padding(2);
            this.listViewMeciuri.Name = "listViewMeciuri";
            this.listViewMeciuri.Size = new System.Drawing.Size(813, 250);
            this.listViewMeciuri.TabIndex = 2;
            this.listViewMeciuri.UseCompatibleStateImageBehavior = false;
            this.listViewMeciuri.DoubleClick += new System.EventHandler(this.listViewMeciuri_DoubleClick);
            // 
            // buttonPlaseazaPariu
            // 
            this.buttonPlaseazaPariu.Location = new System.Drawing.Point(32, 327);
            this.buttonPlaseazaPariu.Margin = new System.Windows.Forms.Padding(2);
            this.buttonPlaseazaPariu.Name = "buttonPlaseazaPariu";
            this.buttonPlaseazaPariu.Size = new System.Drawing.Size(86, 31);
            this.buttonPlaseazaPariu.TabIndex = 3;
            this.buttonPlaseazaPariu.Text = "Plasează pariu";
            this.buttonPlaseazaPariu.UseVisualStyleBackColor = true;
            this.buttonPlaseazaPariu.Click += new System.EventHandler(this.buttonPlaseazaPariu_Click);
            // 
            // panelTichet
            // 
            this.panelTichet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTichet.Controls.Add(this.labelMizaTotala);
            this.panelTichet.Controls.Add(this.listViewTichetCurent);
            this.panelTichet.Controls.Add(this.buttonFinalizeazaTichet);
            this.panelTichet.Controls.Add(this.buttonStergePariu);
            this.panelTichet.Controls.Add(this.buttonStergeTot);
            this.panelTichet.Controls.Add(this.buttonPlaseazaPariu);
            this.panelTichet.Controls.Add(this.labelCotaTotala);
            this.panelTichet.Controls.Add(this.labelSoldDisponibil);
            this.panelTichet.Controls.Add(this.labelCastigPotential);
            this.panelTichet.Location = new System.Drawing.Point(871, 84);
            this.panelTichet.Name = "panelTichet";
            this.panelTichet.Size = new System.Drawing.Size(560, 398);
            this.panelTichet.TabIndex = 5;
            // 
            // labelMeciuri
            // 
            this.labelMeciuri.AutoSize = true;
            this.labelMeciuri.Location = new System.Drawing.Point(12, 57);
            this.labelMeciuri.Name = "labelMeciuri";
            this.labelMeciuri.Size = new System.Drawing.Size(41, 13);
            this.labelMeciuri.TabIndex = 6;
            this.labelMeciuri.Text = "Meciuri";
            // 
            // labelTichetCurent
            // 
            this.labelTichetCurent.AutoSize = true;
            this.labelTichetCurent.Location = new System.Drawing.Point(868, 57);
            this.labelTichetCurent.Name = "labelTichetCurent";
            this.labelTichetCurent.Size = new System.Drawing.Size(70, 13);
            this.labelTichetCurent.TabIndex = 7;
            this.labelTichetCurent.Text = "Tichet curent";
            // 
            // labelCotaTotala
            // 
            this.labelCotaTotala.AutoSize = true;
            this.labelCotaTotala.Location = new System.Drawing.Point(29, 227);
            this.labelCotaTotala.Name = "labelCotaTotala";
            this.labelCotaTotala.Size = new System.Drawing.Size(81, 13);
            this.labelCotaTotala.TabIndex = 8;
            this.labelCotaTotala.Text = "labelCotaTotala";
            // 
            // labelCastigPotential
            // 
            this.labelCastigPotential.AutoSize = true;
            this.labelCastigPotential.Location = new System.Drawing.Point(29, 251);
            this.labelCastigPotential.Name = "labelCastigPotential";
            this.labelCastigPotential.Size = new System.Drawing.Size(99, 13);
            this.labelCastigPotential.TabIndex = 11;
            this.labelCastigPotential.Text = "labelCastigPotential";
            // 
            // labelSoldDisponibil
            // 
            this.labelSoldDisponibil.AutoSize = true;
            this.labelSoldDisponibil.Location = new System.Drawing.Point(431, 227);
            this.labelSoldDisponibil.Name = "labelSoldDisponibil";
            this.labelSoldDisponibil.Size = new System.Drawing.Size(95, 13);
            this.labelSoldDisponibil.TabIndex = 12;
            this.labelSoldDisponibil.Text = "labelSoldDisponibil";
            // 
            // buttonStergePariu
            // 
            this.buttonStergePariu.Location = new System.Drawing.Point(168, 327);
            this.buttonStergePariu.Margin = new System.Windows.Forms.Padding(2);
            this.buttonStergePariu.Name = "buttonStergePariu";
            this.buttonStergePariu.Size = new System.Drawing.Size(86, 31);
            this.buttonStergePariu.TabIndex = 13;
            this.buttonStergePariu.Text = "Șterge pariu";
            this.buttonStergePariu.UseVisualStyleBackColor = true;
            this.buttonStergePariu.Click += new System.EventHandler(this.buttonStergePariu_Click);
            // 
            // buttonStergeTot
            // 
            this.buttonStergeTot.Location = new System.Drawing.Point(440, 327);
            this.buttonStergeTot.Margin = new System.Windows.Forms.Padding(2);
            this.buttonStergeTot.Name = "buttonStergeTot";
            this.buttonStergeTot.Size = new System.Drawing.Size(86, 31);
            this.buttonStergeTot.TabIndex = 14;
            this.buttonStergeTot.Text = "Șterge tot";
            this.buttonStergeTot.UseVisualStyleBackColor = true;
            this.buttonStergeTot.Click += new System.EventHandler(this.buttonStergeTot_Click);
            // 
            // buttonFinalizeazaTichet
            // 
            this.buttonFinalizeazaTichet.Location = new System.Drawing.Point(302, 327);
            this.buttonFinalizeazaTichet.Margin = new System.Windows.Forms.Padding(2);
            this.buttonFinalizeazaTichet.Name = "buttonFinalizeazaTichet";
            this.buttonFinalizeazaTichet.Size = new System.Drawing.Size(98, 31);
            this.buttonFinalizeazaTichet.TabIndex = 15;
            this.buttonFinalizeazaTichet.Text = "Finalizează tichet";
            this.buttonFinalizeazaTichet.UseVisualStyleBackColor = true;
            this.buttonFinalizeazaTichet.Click += new System.EventHandler(this.buttonFinalizeazaTichet_Click);
            // 
            // labelMesaj
            // 
            this.labelMesaj.AutoSize = true;
            this.labelMesaj.Location = new System.Drawing.Point(52, 451);
            this.labelMesaj.Name = "labelMesaj";
            this.labelMesaj.Size = new System.Drawing.Size(57, 13);
            this.labelMesaj.TabIndex = 16;
            this.labelMesaj.Text = "labelMesaj";
            // 
            // listViewTichetCurent
            // 
            this.listViewTichetCurent.HideSelection = false;
            this.listViewTichetCurent.Location = new System.Drawing.Point(3, 12);
            this.listViewTichetCurent.Name = "listViewTichetCurent";
            this.listViewTichetCurent.Size = new System.Drawing.Size(552, 191);
            this.listViewTichetCurent.TabIndex = 0;
            this.listViewTichetCurent.UseCompatibleStateImageBehavior = false;
            // 
            // labelMizaTotala
            // 
            this.labelMizaTotala.AutoSize = true;
            this.labelMizaTotala.Location = new System.Drawing.Point(31, 280);
            this.labelMizaTotala.Name = "labelMizaTotala";
            this.labelMizaTotala.Size = new System.Drawing.Size(81, 13);
            this.labelMizaTotala.TabIndex = 16;
            this.labelMizaTotala.Text = "labelMizaTotala";
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1487, 537);
            this.Controls.Add(this.labelMesaj);
            this.Controls.Add(this.labelTichetCurent);
            this.Controls.Add(this.labelMeciuri);
            this.Controls.Add(this.panelTichet);
            this.Controls.Add(this.listViewMeciuri);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormPrincipal";
            this.Text = "FormPrincipal";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelTichet.ResumeLayout(false);
            this.panelTichet.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonMeciuri;
        private System.Windows.Forms.ToolStripButton toolStripButtonTicheteleMele;
        private System.Windows.Forms.ToolStripButton toolStripButtonDepunere;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabelProfil;
        private System.Windows.Forms.ToolStripLabel toolStripLabelSold;
        private System.Windows.Forms.ToolStripButton toolStripButtonIesire;
        private System.Windows.Forms.ListView listViewMeciuri;
        private System.Windows.Forms.Button buttonPlaseazaPariu;
        private System.Windows.Forms.Panel panelTichet;
        private System.Windows.Forms.Label labelMeciuri;
        private System.Windows.Forms.Label labelTichetCurent;
        private System.Windows.Forms.Label labelCotaTotala;
        private System.Windows.Forms.Label labelCastigPotential;
        private System.Windows.Forms.Label labelSoldDisponibil;
        private System.Windows.Forms.Button buttonStergePariu;
        private System.Windows.Forms.Button buttonStergeTot;
        private System.Windows.Forms.Button buttonFinalizeazaTichet;
        private System.Windows.Forms.Label labelMesaj;
        private System.Windows.Forms.ListView listViewTichetCurent;
        private System.Windows.Forms.Label labelMizaTotala;
    }
}