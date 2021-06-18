using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tower_defense
{
    public partial class Igra : Form
    {
        private Size vel_robovi = new Size(16, 16);
        private Size vel_plosce = new Size(1024, 768);
        private Size vel_menija = new Size(208, 408);
        private Size vel_meni_robovi = new Size(12, 12);
        private Size vel_meni_gumbi = new Size(85, 85);
        private Size vel_mreze = new Size(64, 64);
        private Size vel_lastnosti = new Size(208, 160);
        private Size vel_nova_runda_gumba = new Size(208, 96);
        private Size vel_stevilk = new Size(50, 32);
        private Size vel_ikon = new Size(48, 48);
        private Size vel_razmik_st_ikona = new Size(2, 2);

        private Napadalec[] zivi_napadalci = new Napadalec[100];

        private List<Point> testno_polje = new List<Point>();

        private Graphics g;

        private int izbran_top = -1;  //Spremenljivka za izbiro topa ce je -1 ni izbran noben drugače pa top z to stevilko
        private Image[] slike_topov = new Image[3];
        private Image slika_napake = Image.FromFile(@"E:\Projects\Tower_defense\Tower_defense\Tower_defense\Slike\napaka.png");

        public Igra()
        {
            InitializeComponent();
            this.slike_topov[0] = Image.FromFile(@"E:\Projects\Tower_defense\Tower_defense\Tower_defense\Slike\osnovn_krog.png");
            this.slike_topov[1] = Image.FromFile(@"E:\Projects\Tower_defense\Tower_defense\Tower_defense\Slike\osnovn_krog.png");
            this.slike_topov[2] = Image.FromFile(@"E:\Projects\Tower_defense\Tower_defense\Tower_defense\Slike\osnovn_krog.png");
            IzrisiKomponente();
        }

        public void NapolniMrezo(Graphics g)
        {
            int st_vrstic = 12;
            int st_stolpcev = 16;

            Pen risalo = new Pen(Color.Black);

            this.testno_polje.Add(new Point(3, 3));
            this.testno_polje.Add(new Point(3, 4));

            for (int i = 0; i < st_vrstic; i++)
            {
                for (int j = 0; j < st_stolpcev; j++)
                {
                    if (this.testno_polje.Contains(new Point(i, j))){
                        continue;
                    }
                    else //narisemo kvadrat
                    {
                        int x = this.vel_mreze.Width * j;
                        int y = this.vel_mreze.Height * i;
                        g.DrawRectangle(risalo, this.vel_mreze.Width, this.vel_mreze.Height, x, y);
                    }

                }
            }
        }

        public void NapolniMeni()
        {
            pnl_izbirni_meni.Controls.Clear();

            int visina = this.vel_meni_robovi.Height;
            int sirina = this.vel_meni_robovi.Width;

            for (int i = 0; i < this.slike_topov.Length; i++)
            {
                Button button = new Button();
                button.Name = "btn_meni_" + i;
                button.Size = this.vel_meni_gumbi;
                button.BackgroundImageLayout = ImageLayout.Stretch;
                button.BackgroundImage = this.slike_topov[i];
                button.Left = sirina;
                button.Top = visina;
                button.Click += IzbiraVMeniju;
                pnl_izbirni_meni.Controls.Add(button);

                if (i % 2 != 0)
                {
                    sirina = this.vel_meni_robovi.Width;
                    visina += this.vel_meni_gumbi.Height + this.vel_meni_robovi.Height;
                }
                else
                {
                    sirina += this.vel_meni_gumbi.Width + this.vel_meni_robovi.Height;
                }

            }
        }

        private void IzbiraVMeniju(object sender, EventArgs e)
        {
            Button izbran = (Button)sender;

            this.izbran_top = int.Parse(izbran.Name.Split("_")[2]); //ime gumba btn_meni_{stevilka}
            Frame();
        }

        public void IzrisiKomponente()
        {

            int sirina = this.ClientSize.Width;
            int visina = this.ClientSize.Height;

            pnl_igralna_plosca.Location = new Point(this.vel_robovi.Width, this.vel_robovi.Height);
            pnl_igralna_plosca.Size = this.vel_plosce;

            pnl_izbirni_meni.Location = new Point(2 * this.vel_robovi.Width + this.vel_plosce.Width,
                                                  2 * this.vel_robovi.Height + this.vel_ikon.Height);
            pnl_izbirni_meni.Size = this.vel_menija;

            pnl_lastnosti_izbranega.Location = new Point(2 * this.vel_robovi.Width + this.vel_plosce.Width,
                                                         3 * this.vel_robovi.Height + this.vel_menija.Height + this.vel_ikon.Height);
            pnl_lastnosti_izbranega.Size = this.vel_lastnosti;

            btn_nova_runda.Location = new Point(2 * this.vel_robovi.Width + this.vel_plosce.Width,
                                                this.vel_robovi.Height + this.vel_plosce.Height - this.vel_nova_runda_gumba.Height);
            btn_nova_runda.Size = this.vel_nova_runda_gumba;

            picbox_denar.Location = new Point(2 * this.vel_robovi.Width + this.vel_plosce.Width + this.vel_stevilk.Width + this.vel_razmik_st_ikona.Width,
                                              this.vel_robovi.Height);
            picbox_denar.Size = this.vel_ikon;

            picbox_zivljenje.Location = new Point(2 * this.vel_robovi.Width + this.vel_plosce.Width + 2 * this.vel_stevilk.Width + 6 * this.vel_razmik_st_ikona.Width + this.vel_ikon.Width,
                                              this.vel_robovi.Height);
            picbox_zivljenje.Size = this.vel_ikon;

            Font pisava = new Font("Segoe UI", (int)(this.vel_stevilk.Height / 2.4));

            lbl_denar.Location = new Point(2 * this.vel_robovi.Width + this.vel_plosce.Width, (int)(1.5 * this.vel_robovi.Height));
            lbl_denar.Size = this.vel_stevilk;
            lbl_denar.Font = pisava;
            

            lbl_zivljenja.Location = new Point(2 * this.vel_robovi.Width + this.vel_plosce.Width + 4 * this.vel_razmik_st_ikona.Width + this.vel_ikon.Width + this.vel_stevilk.Width,
                                              (int)(1.5 * this.vel_robovi.Height));
            lbl_zivljenja.Size = this.vel_stevilk;
            lbl_zivljenja.Font = pisava;

            NapolniMeni();

        }

        /// <summary>
        /// Se zgodi ko spremenimo velikost okna pri igri, tako se vse komponente ustrezno povečajo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResizeOkna(object sender, EventArgs e)
        {
            int sprememba_visine;
            int sprememba_sirine;
            
            if(this.ClientSize.Height * 0.96 < this.ClientSize.Width * 0.6)
            {
                sprememba_visine = this.ClientSize.Height;
                sprememba_sirine = (int)(this.ClientSize.Height * 1.6);
            }
            else
            {
                sprememba_sirine = this.ClientSize.Width;
                sprememba_visine = (int)(this.ClientSize.Width / 1.6);
            }

            this.vel_robovi = new Size((int)(sprememba_sirine * 0.0125), (int)(sprememba_visine * 0.02));
            this.vel_plosce = new Size((int)(sprememba_sirine * 0.8), (int)(sprememba_visine * 0.96));
            this.vel_menija = new Size((int)(sprememba_sirine * 0.1625), (int)(sprememba_visine * 0.52));
            this.vel_meni_robovi = new Size((int)(this.vel_menija.Width * 0.06), (int)(this.vel_menija.Width * 0.06));
            this.vel_meni_gumbi = new Size((int)(this.vel_menija.Width * 0.41), (int)(this.vel_menija.Width * 0.41));
            this.vel_lastnosti = new Size((int)(sprememba_sirine * 0.1625), (int)(sprememba_visine * 0.20));
            this.vel_mreze = new Size((int)(sprememba_sirine * 0.05), (int)(sprememba_visine * 0.08));
            this.vel_ikon = new Size((int)(sprememba_visine * 0.06), (int)(sprememba_visine * 0.06));
            this.vel_nova_runda_gumba = new Size((int)(sprememba_sirine * 0.1625), (int)(sprememba_visine * 0.12));
            this.vel_stevilk = new Size((int)(this.vel_menija.Width * 0.24), (int)(sprememba_visine * 0.04));

            IzrisiKomponente();
        }

        /// <summary>
        /// Vsak casovni tik poklice vse funkcije za izris stvari na igralno povrsino
        /// </summary>
        private void Frame()
        {
            Bitmap igralna_plosca = new Bitmap(1024, 768);
            Graphics g = Graphics.FromImage(igralna_plosca);

            NapolniMrezo(g);

            pnl_igralna_plosca.BackgroundImage = igralna_plosca;
        }



        private void TestPrikaza(object sender, EventArgs e)
        {
            PictureBox izbran = (PictureBox)sender;
            test_label.Text = izbran.Location.ToString();

            //Najdemo sredisce
            int poz_x = izbran.Location.X + (this.vel_mreze.Height / 2);
            int poz_y = izbran.Location.Y + (this.vel_mreze.Width / 2);
            this.g = pnl_igralna_plosca.CreateGraphics();
            Pen rob_obmocja = new Pen(Color.Black);
            SolidBrush celo_obmocje = new SolidBrush(Color.FromArgb(128, 0, 255, 0));

            g.DrawEllipse(rob_obmocja, poz_x - 50, poz_y - 50, 100, 100);
            g.FillEllipse(celo_obmocje, poz_x - 50, poz_y - 50, 100, 100);

            g.DrawImage(slike_topov[0], new Point(300, 300));

        }

        private void TestPrikazaOdmik(object sender, EventArgs e)
        {
            test_label.Text = "DOL";
            this.g.Clear(pnl_igralna_plosca.BackColor);
            
        }
    }
}
