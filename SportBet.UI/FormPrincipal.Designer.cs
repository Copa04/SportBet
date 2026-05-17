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
            this.button2 = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
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
            this.toolStrip1.Size = new System.Drawing.Size(2514, 42);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonMeciuri
            // 
            this.toolStripButtonMeciuri.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonMeciuri.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonMeciuri.Image")));
            this.toolStripButtonMeciuri.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonMeciuri.Name = "toolStripButtonMeciuri";
            this.toolStripButtonMeciuri.Size = new System.Drawing.Size(98, 36);
            this.toolStripButtonMeciuri.Text = "Meciuri";
            this.toolStripButtonMeciuri.Click += new System.EventHandler(this.buttonReincarca_Click);
            // 
            // toolStripButtonTicheteleMele
            // 
            this.toolStripButtonTicheteleMele.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonTicheteleMele.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonTicheteleMele.Image")));
            this.toolStripButtonTicheteleMele.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonTicheteleMele.Name = "toolStripButtonTicheteleMele";
            this.toolStripButtonTicheteleMele.Size = new System.Drawing.Size(175, 36);
            this.toolStripButtonTicheteleMele.Text = "Tichetele mele";
            this.toolStripButtonTicheteleMele.Click += new System.EventHandler(this.toolStripButtonTicheteleMele_Click);
            // 
            // toolStripButtonDepunere
            // 
            this.toolStripButtonDepunere.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonDepunere.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDepunere.Image")));
            this.toolStripButtonDepunere.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDepunere.Name = "toolStripButtonDepunere";
            this.toolStripButtonDepunere.Size = new System.Drawing.Size(124, 36);
            this.toolStripButtonDepunere.Text = "Depunere";
            this.toolStripButtonDepunere.Click += new System.EventHandler(this.toolStripButtonDepunere_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 42);
            // 
            // toolStripLabelProfil
            // 
            this.toolStripLabelProfil.Name = "toolStripLabelProfil";
            this.toolStripLabelProfil.Size = new System.Drawing.Size(69, 36);
            this.toolStripLabelProfil.Text = "Profil";
            // 
            // toolStripLabelSold
            // 
            this.toolStripLabelSold.Name = "toolStripLabelSold";
            this.toolStripLabelSold.Size = new System.Drawing.Size(61, 36);
            this.toolStripLabelSold.Text = "Sold";
            // 
            // toolStripButtonIesire
            // 
            this.toolStripButtonIesire.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonIesire.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonIesire.Image")));
            this.toolStripButtonIesire.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonIesire.Name = "toolStripButtonIesire";
            this.toolStripButtonIesire.Size = new System.Drawing.Size(74, 36);
            this.toolStripButtonIesire.Text = "Ieșire";
            this.toolStripButtonIesire.Click += new System.EventHandler(this.toolStripButtonIesire_Click);
            // 
            // listViewMeciuri
            // 
            this.listViewMeciuri.HideSelection = false;
            this.listViewMeciuri.Location = new System.Drawing.Point(12, 162);
            this.listViewMeciuri.Name = "listViewMeciuri";
            this.listViewMeciuri.Size = new System.Drawing.Size(2416, 477);
            this.listViewMeciuri.TabIndex = 2;
            this.listViewMeciuri.UseCompatibleStateImageBehavior = false;
            this.listViewMeciuri.DoubleClick += new System.EventHandler(this.listViewMeciuri_DoubleClick);
            // 
            // buttonPlaseazaPariu
            // 
            this.buttonPlaseazaPariu.Location = new System.Drawing.Point(1802, 803);
            this.buttonPlaseazaPariu.Name = "buttonPlaseazaPariu";
            this.buttonPlaseazaPariu.Size = new System.Drawing.Size(173, 59);
            this.buttonPlaseazaPariu.TabIndex = 3;
            this.buttonPlaseazaPariu.Text = "Plaseaza pariu";
            this.buttonPlaseazaPariu.UseVisualStyleBackColor = true;
            this.buttonPlaseazaPariu.Click += new System.EventHandler(this.buttonPlaseazaPariu_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(2136, 803);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(143, 59);
            this.button2.TabIndex = 4;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2514, 1032);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonPlaseazaPariu);
            this.Controls.Add(this.listViewMeciuri);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FormPrincipal";
            this.Text = "FormPrincipal";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
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
        private System.Windows.Forms.Button button2;
    }
}