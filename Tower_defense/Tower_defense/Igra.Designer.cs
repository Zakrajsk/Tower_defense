
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
            this.Casovnik = new System.Windows.Forms.Timer(this.components);
            this.pnl_izbirni_meni = new System.Windows.Forms.Panel();
            this.pnl_lastnosti_izbranega = new System.Windows.Forms.Panel();
            this.test_label = new System.Windows.Forms.Label();
            this.pnl_igralna_plosca = new System.Windows.Forms.Panel();
            this.btn_nova_runda = new System.Windows.Forms.Button();
            this.lbl_zivljenja = new System.Windows.Forms.Label();
            this.picbox_zivljenje = new System.Windows.Forms.PictureBox();
            this.picbox_denar = new System.Windows.Forms.PictureBox();
            this.lbl_denar = new System.Windows.Forms.Label();
            this.pnl_igralna_plosca.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbox_zivljenje)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbox_denar)).BeginInit();
            this.SuspendLayout();
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
            this.pnl_lastnosti_izbranega.Location = new System.Drawing.Point(1056, 512);
            this.pnl_lastnosti_izbranega.Name = "pnl_lastnosti_izbranega";
            this.pnl_lastnosti_izbranega.Size = new System.Drawing.Size(208, 160);
            this.pnl_lastnosti_izbranega.TabIndex = 4;
            // 
            // test_label
            // 
            this.test_label.AutoSize = true;
            this.test_label.Location = new System.Drawing.Point(754, 63);
            this.test_label.Name = "test_label";
            this.test_label.Size = new System.Drawing.Size(91, 20);
            this.test_label.TabIndex = 4;
            this.test_label.Text = "Za testiranje";
            // 
            // pnl_igralna_plosca
            // 
            this.pnl_igralna_plosca.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnl_igralna_plosca.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnl_igralna_plosca.Controls.Add(this.test_label);
            this.pnl_igralna_plosca.Location = new System.Drawing.Point(16, 16);
            this.pnl_igralna_plosca.Name = "pnl_igralna_plosca";
            this.pnl_igralna_plosca.Size = new System.Drawing.Size(1024, 768);
            this.pnl_igralna_plosca.TabIndex = 0;
            // 
            // btn_nova_runda
            // 
            this.btn_nova_runda.Location = new System.Drawing.Point(1056, 688);
            this.btn_nova_runda.Name = "btn_nova_runda";
            this.btn_nova_runda.Size = new System.Drawing.Size(208, 96);
            this.btn_nova_runda.TabIndex = 5;
            this.btn_nova_runda.Text = "Start";
            this.btn_nova_runda.UseVisualStyleBackColor = true;
            // 
            // lbl_zivljenja
            // 
            this.lbl_zivljenja.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_zivljenja.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_zivljenja.Location = new System.Drawing.Point(1164, 24);
            this.lbl_zivljenja.Name = "lbl_zivljenja";
            this.lbl_zivljenja.Size = new System.Drawing.Size(50, 32);
            this.lbl_zivljenja.TabIndex = 6;
            this.lbl_zivljenja.Text = "999";
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
            this.lbl_denar.Text = "999";
            // 
            // Igra
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1280, 800);
            this.Controls.Add(this.lbl_denar);
            this.Controls.Add(this.picbox_denar);
            this.Controls.Add(this.picbox_zivljenje);
            this.Controls.Add(this.lbl_zivljenja);
            this.Controls.Add(this.btn_nova_runda);
            this.Controls.Add(this.pnl_lastnosti_izbranega);
            this.Controls.Add(this.pnl_izbirni_meni);
            this.Controls.Add(this.pnl_igralna_plosca);
            this.Name = "Igra";
            this.Resize += new System.EventHandler(this.ResizeOkna);
            this.pnl_igralna_plosca.ResumeLayout(false);
            this.pnl_igralna_plosca.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbox_zivljenje)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbox_denar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer Casovnik;
        private System.Windows.Forms.Panel pnl_izbirni_meni;
        private System.Windows.Forms.Panel pnl_lastnosti_izbranega;
        private System.Windows.Forms.Label test_label;
        private System.Windows.Forms.Panel pnl_igralna_plosca;
        private System.Windows.Forms.Button btn_nova_runda;
        private System.Windows.Forms.Label lbl_zivljenja;
        private System.Windows.Forms.PictureBox picbox_zivljenje;
        private System.Windows.Forms.PictureBox picbox_denar;
        private System.Windows.Forms.Label lbl_denar;
    }
}