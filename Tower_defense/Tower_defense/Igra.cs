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

        private Napadalci napadalci= new Napadalci();
        private List<Stolp> postavljeni_stolpi = new List<Stolp>();

        private List<Point> testno_polje = new List<Point>();

        private int izbran_top = -1;  //Spremenljivka za izbiro topa ce je -1 ni izbran noben drugače pa top z to stevilko
        private Image[] slike_topov = new Image[3];
        private Image slika_napake = Image.FromFile(@"E:\Projects\Tower_defense\Tower_defense\Tower_defense\Slike\napaka.png");

        private Point kje_miska = new Point(0, 0);

        public Igra()
        {
            InitializeComponent();
            this.slike_topov[0] = Image.FromFile(@"E:\Projects\Tower_defense\Tower_defense\Tower_defense\Slike\osnovn_krog.png");
            this.slike_topov[1] = Image.FromFile(@"E:\Projects\Tower_defense\Tower_defense\Tower_defense\Slike\top_0.png");
            this.slike_topov[2] = Image.FromFile(@"E:\Projects\Tower_defense\Tower_defense\Tower_defense\Slike\osnovn_krog.png");

            this.testno_polje.Add(new Point(0, 2));
            this.testno_polje.Add(new Point(1, 2));
            this.testno_polje.Add(new Point(2, 2));
            this.testno_polje.Add(new Point(2, 3));
            this.testno_polje.Add(new Point(3, 3));
            this.testno_polje.Add(new Point(4, 3));
            this.testno_polje.Add(new Point(5, 3));
            this.testno_polje.Add(new Point(6, 3));
            this.testno_polje.Add(new Point(7, 3));
            this.testno_polje.Add(new Point(8, 3));
            this.testno_polje.Add(new Point(8, 4));
            this.testno_polje.Add(new Point(8, 5));
            this.testno_polje.Add(new Point(8, 6));
            this.testno_polje.Add(new Point(7, 6));
            this.testno_polje.Add(new Point(6, 6));
            this.testno_polje.Add(new Point(5, 6));
            this.testno_polje.Add(new Point(5, 7));
            this.testno_polje.Add(new Point(5, 8));
            this.testno_polje.Add(new Point(6, 8));
            this.testno_polje.Add(new Point(7, 8));
            this.testno_polje.Add(new Point(8, 8));
            this.testno_polje.Add(new Point(9, 8));
            this.testno_polje.Add(new Point(10, 8));
            this.testno_polje.Add(new Point(10, 7));
            this.testno_polje.Add(new Point(11, 7));
            this.testno_polje.Add(new Point(12, 7));
            this.testno_polje.Add(new Point(12, 6));
            this.testno_polje.Add(new Point(12, 5));
            this.testno_polje.Add(new Point(12, 4));
            this.testno_polje.Add(new Point(13, 4));
            this.testno_polje.Add(new Point(14, 4));
            this.testno_polje.Add(new Point(15, 4));


            this.postavljeni_stolpi.Add(new Stolp(3, 3, new Point(7, 4)));
            this.postavljeni_stolpi.Add(new Stolp(4, 4, new Point(9, 3)));

            picbox_igralna_plosca.Controls.Add(picbox_napadalci); //Zato, da je drugi picturebox transparenten

            IzrisiKomponente();
        }

        public void IzrisiMrezo(Graphics g)
        {
            int st_vrstic = 12;
            int st_stolpcev = 16;

            Pen pen_crno = new Pen(Color.Black);
            pen_crno.Width = 2;

            for (int i = 0; i < st_vrstic; i++)
            {
                for (int j = 0; j < st_stolpcev; j++)
                {
                    int x = this.vel_mreze.Width * j;
                    int y = this.vel_mreze.Height * i;
                    //Narisemo polja kjer ni pote z zeleno in ostale z rjavo barvo
                    if (this.testno_polje.Contains(new Point(j, i)))
                    {
                        g.FillRectangle(new SolidBrush(Color.SandyBrown), x, y, this.vel_mreze.Width - 1, this.vel_mreze.Height - 1);
                    }
                    else
                    {
                        g.DrawRectangle(pen_crno, x, y, this.vel_mreze.Width, this.vel_mreze.Height);
                        g.FillRectangle(new SolidBrush(Color.LightGreen), x, y, this.vel_mreze.Width - 1, this.vel_mreze.Height - 1);
                    }

                }
            }
        }

        /// <summary>
        /// Funkcija, ki izrise vse stolpe, ki so postavljeni
        /// </summary>
        /// <param name="g"></param>
        public void IzrisiStolpe(Graphics g)
        {
            foreach(Stolp posamezni in this.postavljeni_stolpi)
            {
                int x = posamezni.Lokacija.X * this.vel_mreze.Width;
                int y = posamezni.Lokacija.Y * this.vel_mreze.Height;
                g.DrawImage(this.slike_topov[0], x, y, this.vel_mreze.Width, this.vel_mreze.Height);
            }
        }

        /// <summary>
        /// Funkcija, ki izrise vse napadalce, ki so zivi
        /// </summary>
        /// <param name="g"></param>
        public void IzrisiNapadalce(Graphics g)
        {
            
            foreach(Napadalec posamezni in napadalci.VsiNapadalci)
            {
                int x = posamezni.Lokacija.X;
                int y = posamezni.Lokacija.Y;
                g.FillPolygon(new SolidBrush(Color.Black), posamezni.TockeZaIzris(this.vel_mreze));
            }
        }

        /// <summary>
        /// Izrise izbrani top kjer ima uporabnik misko
        /// Poleg njega tudi izriše območje, do katerega ima top doseg
        /// </summary>
        /// <param name="g"></param>
        public void IzrisiIzbranTop(Graphics g)
        {
            int x = kje_miska.X * this.vel_mreze.Width;
            int y = kje_miska.Y * this.vel_mreze.Height;
            lbl_test.Text = "" + x + " "+ y;

            g.DrawImage(this.slike_topov[this.izbran_top], x, y, this.vel_mreze.Width, this.vel_mreze.Height);

            Pen rob_obmocja = new Pen(Color.Black);
            SolidBrush celo_obmocje = new SolidBrush(Color.FromArgb(128, 0, 255, 0));

            g.DrawEllipse(rob_obmocja, x - 50 + this.vel_mreze.Width / 2, y - 50 + this.vel_mreze.Height / 2, 100, 100);
            g.FillEllipse(celo_obmocje, x - 50 + this.vel_mreze.Width / 2, y - 50 + this.vel_mreze.Height / 2, 100, 100);

        }

        /// <summary>
        /// Napolni meni za izbiro topov z toliko gumbi kolikor je različnih topov
        /// gumbom se spreminja velikost glede na veliksot okna
        /// </summary>
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

                //Premaknemo sirini in visino na lokacijo kjer bo naslednji gumb
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

        /// <summary>
        /// Se zgodi ko uporabnik klikne na nek gumb v izbirnem meniju z topovi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IzbiraVMeniju(object sender, EventArgs e)
        {
            Button izbran = (Button)sender;

            this.izbran_top = int.Parse(izbran.Name.Split("_")[2]); //ime gumba btn_meni_{stevilka}
            lbl_test.Text = this.izbran_top.ToString();
        }

        /// <summary>
        /// Prilagodi vse pozicije vseh elementov, ki so narisani
        /// Tako ohranjamo enako sliko ob povecavi osnovnega okna
        /// </summary>
        public void IzrisiKomponente()
        {
            picbox_igralna_plosca.Location = new Point(this.vel_robovi.Width, this.vel_robovi.Height);
            picbox_igralna_plosca.Size = this.vel_plosce;
            picbox_napadalci.Size = this.vel_plosce; //Ker se prekrivata je velikost ista

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
            this.vel_plosce = new Size((int)(sprememba_sirine * 0.80), (int)(sprememba_visine * 0.96));
            this.vel_menija = new Size((int)(sprememba_sirine * 0.1625), (int)(sprememba_visine * 0.52));
            this.vel_meni_robovi = new Size((int)(this.vel_menija.Width * 0.06), (int)(this.vel_menija.Width * 0.06));
            this.vel_meni_gumbi = new Size((int)(this.vel_menija.Width * 0.41), (int)(this.vel_menija.Width * 0.41));
            this.vel_lastnosti = new Size((int)(sprememba_sirine * 0.1625), (int)(sprememba_visine * 0.20));
            this.vel_mreze = new Size((int)(sprememba_sirine * 0.05), (int)(sprememba_visine * 0.08));
            this.vel_ikon = new Size((int)(sprememba_visine * 0.06), (int)(sprememba_visine * 0.06));
            this.vel_nova_runda_gumba = new Size((int)(sprememba_sirine * 0.1625), (int)(sprememba_visine * 0.12));
            this.vel_stevilk = new Size((int)(this.vel_menija.Width * 0.24), (int)(sprememba_visine * 0.04));
            IzrisiKomponente();
            picbox_igralna_plosca.Invalidate();

        }

        /// <summary>
        /// Kadar se z misko premikamo po igralni plosci
        /// V primeru, da imamo izbran top za postavitev se bo le ta risal kjer je miska
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PremikPoPlosci(object sender, MouseEventArgs e)
        {
            //najdemo v katerem kvadrantu je miska
            Point poz_miske =new Point(e.X / this.vel_mreze.Width, e.Y / this.vel_mreze.Height);

            if(poz_miske != this.kje_miska) //premaknili smo se v drug kvadrant na igralnem polju
            {
                kje_miska = poz_miske;
                picbox_igralna_plosca.Invalidate();
            }
            else //se vedno smo na istem kvadrantu
            {

            }
        }

        private void PritisnjenaTipka(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == '\x1b') //Pritisnjena esc tipka
            {
                this.izbran_top = -1; //ponastavimo izbran top
                picbox_igralna_plosca.Invalidate();
            }
        }

        /// <summary>
        /// Se zgodi ob pritistku na gumb za novo rundo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ZacetekNoveRunde(object sender, EventArgs e)
        {
            casovnik.Enabled = !casovnik.Enabled;
        }

        /// <summary>
        /// En tick casovnika
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CasovnaEnota(object sender, EventArgs e)
        {
            this.napadalci.PremakniVse(this.testno_polje, this.vel_mreze);
            picbox_napadalci.Invalidate();

        }

        /// <summary>
        /// Funkcija izrise vse dinamicne objekte, ki se premikajo
        /// To so napadalci, izstrelki
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NarisiDinamicneObjekte(object sender, PaintEventArgs e)
        {
            lbl_test.Text = this.napadalci.VsiNapadalci[0].Lokacija.ToString();
            IzrisiNapadalce(e.Graphics);
        }

        /// <summary>
        /// Funkcija narise vse staticne objekte, ki so na mestu
        /// To so polja, postavljeni stolpi.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NarisiStaticneObjekte(object sender, PaintEventArgs e)
        {

            IzrisiMrezo(e.Graphics);
            IzrisiStolpe(e.Graphics);

            if (this.izbran_top != -1) //uporabnik ima izbran top za postavitev
            {
                IzrisiIzbranTop(e.Graphics);
            }
        }
    }
}
