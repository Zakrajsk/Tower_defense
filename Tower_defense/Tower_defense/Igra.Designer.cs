
namespace Tower_defense
{
    partial class Igra
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
            this.casovnik = new System.Windows.Forms.Timer(this.components);
            this.pnl_izbirni_meni = new System.Windows.Forms.Panel();
            this.pnl_lastnosti_izbranega = new System.Windows.Forms.Panel();
            this.lbl_podatki = new System.Windows.Forms.Label();
            this.btn_nova_runda = new System.Windows.Forms.Button();
            this.lbl_zivljenja = new System.Windows.Forms.Label();
            this.picbox_zivljenje = new System.Windows.Forms.PictureBox();
            this.picbox_denar = new System.Windows.Forms.PictureBox();
            this.lbl_denar = new System.Windows.Forms.Label();
            this.picbox_igralna_plosca = new System.Windows.Forms.PictureBox();
            this.picbox_napadalci = new System.Windows.Forms.PictureBox();
            this.pnl_izgubil = new System.Windows.Forms.Panel();
            this.btn_izg_zapri = new System.Windows.Forms.Button();
            this.lbl_izgubil_si = new System.Windows.Forms.Label();
            this.pnl_lastnosti_izbranega.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbox_zivljenje)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbox_denar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbox_igralna_plosca)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbox_napadalci)).BeginInit();
            this.pnl_izgubil.SuspendLayout();
            this.SuspendLayout();
            // 
            // casovnik
            // 
            this.casovnik.Interval = 5;
            this.casovnik.Tick += new System.EventHandler(this.CasovnaEnota);
            // 
            // pnl_izbirni_meni
            // 
            this.pnl_izbirni_meni.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.pnl_izbirni_meni.Location = new System.Drawing.Point(1056, 80);
            this.pnl_izbirni_meni.Name = "pnl_izbirni_meni";
            this.pnl_izbirni_meni.Size = new System.Drawing.Size(208, 416);
            this.pnl_izbirni_meni.TabIndex = 2;
            // 
            // pnl_lastnosti_izbranega
            // 
            this.pnl_lastnosti_izbranega.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.pnl_lastnosti_izbranega.Controls.Add(this.lbl_podatki);
            this.pnl_lastnosti_izbranega.Location = new System.Drawing.Point(1056, 512);
            this.pnl_lastnosti_izbranega.Name = "pnl_lastnosti_izbranega";
            this.pnl_lastnosti_izbranega.Size = new System.Drawing.Size(208, 160);
            this.pnl_lastnosti_izbranega.TabIndex = 4;
            // 
            // lbl_podatki
            // 
            this.lbl_podatki.AutoSize = true;
            this.lbl_podatki.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_podatki.Location = new System.Drawing.Point(16, 16);
            this.lbl_podatki.Name = "lbl_podatki";
            this.lbl_podatki.Size = new System.Drawing.Size(0, 31);
            this.lbl_podatki.TabIndex = 0;
            // 
            // btn_nova_runda
            // 
            this.btn_nova_runda.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_nova_runda.Location = new System.Drawing.Point(1056, 688);
            this.btn_nova_runda.Name = "btn_nova_runda";
            this.btn_nova_runda.Size = new System.Drawing.Size(208, 96);
            this.btn_nova_runda.TabIndex = 5;
            this.btn_nova_runda.Text = "Začni stopnjo 1";
            this.btn_nova_runda.UseVisualStyleBackColor = true;
            this.btn_nova_runda.Click += new System.EventHandler(this.ZacetekNoveRunde);
            // 
            // lbl_zivljenja
            // 
            this.lbl_zivljenja.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_zivljenja.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_zivljenja.Location = new System.Drawing.Point(1164, 24);
            this.lbl_zivljenja.Name = "lbl_zivljenja";
            this.lbl_zivljenja.Size = new System.Drawing.Size(50, 32);
            this.lbl_zivljenja.TabIndex = 6;
            this.lbl_zivljenja.Text = "NO";
            // 
            // picbox_zivljenje
            // 
            this.picbox_zivljenje.BackColor = System.Drawing.Color.Red;
            this.picbox_zivljenje.Location = new System.Drawing.Point(1216, 16);
            this.picbox_zivljenje.Name = "picbox_zivljenje";
            this.picbox_zivljenje.Size = new System.Drawing.Size(48, 48);
            this.picbox_zivljenje.TabIndex = 7;
            this.picbox_zivljenje.TabStop = false;
            // 
            // picbox_denar
            // 
            this.picbox_denar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.picbox_denar.Location = new System.Drawing.Point(1108, 16);
            this.picbox_denar.Name = "picbox_denar";
            this.picbox_denar.Size = new System.Drawing.Size(48, 48);
            this.picbox_denar.TabIndex = 8;
            this.picbox_denar.TabStop = false;
            // 
            // lbl_denar
            // 
            this.lbl_denar.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_denar.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_denar.Location = new System.Drawing.Point(1056, 24);
            this.lbl_denar.Name = "lbl_denar";
            this.lbl_denar.Size = new System.Drawing.Size(50, 32);
            this.lbl_denar.TabIndex = 9;
            this.lbl_denar.Text = "NO";
            // 
            // picbox_igralna_plosca
            // 
            this.picbox_igralna_plosca.BackColor = System.Drawing.Color.SandyBrown;
            this.picbox_igralna_plosca.Location = new System.Drawing.Point(16, 16);
            this.picbox_igralna_plosca.Name = "picbox_igralna_plosca";
            this.picbox_igralna_plosca.Size = new System.Drawing.Size(1024, 768);
            this.picbox_igralna_plosca.TabIndex = 10;
            this.picbox_igralna_plosca.TabStop = false;
            this.picbox_igralna_plosca.Paint += new System.Windows.Forms.PaintEventHandler(this.NarisiStaticneObjekte);
            this.picbox_igralna_plosca.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PremikPoPlosci);
            // 
            // picbox_napadalci
            // 
            this.picbox_napadalci.BackColor = System.Drawing.Color.Transparent;
            this.picbox_napadalci.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picbox_napadalci.Location = new System.Drawing.Point(2, -3);
            this.picbox_napadalci.Name = "picbox_napadalci";
            this.picbox_napadalci.Size = new System.Drawing.Size(1024, 768);
            this.picbox_napadalci.TabIndex = 11;
            this.picbox_napadalci.TabStop = false;
            this.picbox_napadalci.Click += new System.EventHandler(this.ClickNaPlosco);
            this.picbox_napadalci.Paint += new System.Windows.Forms.PaintEventHandler(this.NarisiDinamicneObjekte);
            this.picbox_napadalci.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PremikPoPlosci);
            // 
            // pnl_izgubil
            // 
            this.pnl_izgubil.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_izgubil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.pnl_izgubil.Controls.Add(this.btn_izg_zapri);
            this.pnl_izgubil.Controls.Add(this.lbl_izgubil_si);
            this.pnl_izgubil.Enabled = false;
            this.pnl_izgubil.Location = new System.Drawing.Point(312, 259);
            this.pnl_izgubil.Name = "pnl_izgubil";
            this.pnl_izgubil.Size = new System.Drawing.Size(560, 265);
            this.pnl_izgubil.TabIndex = 12;
            this.pnl_izgubil.Visible = false;
            // 
            // btn_izg_zapri
            // 
            this.btn_izg_zapri.Location = new System.Drawing.Point(205, 161);
            this.btn_izg_zapri.Name = "btn_izg_zapri";
            this.btn_izg_zapri.Size = new System.Drawing.Size(152, 60);
            this.btn_izg_zapri.TabIndex = 1;
            this.btn_izg_zapri.Text = "Zapri";
            this.btn_izg_zapri.UseVisualStyleBackColor = true;
            this.btn_izg_zapri.Click += new System.EventHandler(this.IzgubilZapri);
            // 
            // lbl_izgubil_si
            // 
            this.lbl_izgubil_si.AutoSize = true;
            this.lbl_izgubil_si.Font = new System.Drawing.Font("Segoe UI", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_izgubil_si.Location = new System.Drawing.Point(161, 26);
            this.lbl_izgubil_si.Name = "lbl_izgubil_si";
            this.lbl_izgubil_si.Size = new System.Drawing.Size(244, 62);
            this.lbl_izgubil_si.TabIndex = 0;
            this.lbl_izgubil_si.Text = "IZGUBIL SI";
            // 
            // Igra
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1280, 800);
            this.Controls.Add(this.pnl_izgubil);
            this.Controls.Add(this.picbox_napadalci);
            this.Controls.Add(this.picbox_igralna_plosca);
            this.Controls.Add(this.lbl_denar);
            this.Controls.Add(this.picbox_denar);
            this.Controls.Add(this.picbox_zivljenje);
            this.Controls.Add(this.lbl_zivljenja);
            this.Controls.Add(this.btn_nova_runda);
            this.Controls.Add(this.pnl_lastnosti_izbranega);
            this.Controls.Add(this.pnl_izbirni_meni);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Name = "Igra";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PritisnjenaTipka);
            this.Resize += new System.EventHandler(this.ResizeOkna);
            this.pnl_lastnosti_izbranega.ResumeLayout(false);
            this.pnl_lastnosti_izbranega.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbox_zivljenje)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbox_denar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbox_igralna_plosca)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbox_napadalci)).EndInit();
            this.pnl_izgubil.ResumeLayout(false);
            this.pnl_izgubil.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer casovnik;
        private System.Windows.Forms.Panel pnl_izbirni_meni;
        private System.Windows.Forms.Panel pnl_lastnosti_izbranega;
        private System.Windows.Forms.Button btn_nova_runda;
        private System.Windows.Forms.Label lbl_zivljenja;
        private System.Windows.Forms.PictureBox picbox_zivljenje;
        private System.Windows.Forms.PictureBox picbox_denar;
        private System.Windows.Forms.Label lbl_denar;
        private System.Windows.Forms.PictureBox picbox_igralna_plosca;
        private System.Windows.Forms.Label lbl_podatki;
        private System.Windows.Forms.PictureBox picbox_napadalci;
        private System.Windows.Forms.Panel pnl_izgubil;
        private System.Windows.Forms.Label lbl_izgubil_si;
        private System.Windows.Forms.Button btn_izg_zapri;
    }
}