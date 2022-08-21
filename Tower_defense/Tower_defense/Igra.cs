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
        private Stolpi stolpi = new Stolpi();
        private List<List<Point>> izstrelki = new List<List<Point>>();

        private List<Point> testno_polje = new List<Point>();

        private int izbran_top = -1;  //Spremenljivka za izbiro topa ce je -1 ni izbran noben drugače pa top z to stevilko
        private Stolp[] izbira_topov = new Stolp[4];
        private Image[] slike_topov = new Image[4];

        private Point kje_miska = new Point(0, 0);

        private int runda = 1;
        private int st_zivljenj = 100;
        private int st_kovancev = 100;

        private int[] polje_x = { 0, 1, 2, 2, 3, 4, 5, 6, 6, 6, 7, 8, 8, 8, 8, 8, 8, 7, 6, 5, 5, 5, 6, 7, 8, 9, 10, 10, 11, 12, 12, 12, 12, 13, 14, 15, 16 };
        private int[] polje_y = { 2, 2, 2, 3, 3, 3, 3, 3, 2, 1, 1, 1, 2, 3, 4, 5, 6, 6, 6, 6, 7, 8, 8, 8, 8, 8, 8, 7, 7, 7, 6, 5, 4, 4, 4, 4, 4 };

        public Igra()
        {
            InitializeComponent();
            this.slike_topov[0] = Image.FromFile(@"..\..\..\Slike\top_osnoven.png");
            this.slike_topov[1] = Image.FromFile(@"..\..\..\Slike\top_sniper.png");
            this.slike_topov[2] = Image.FromFile(@"..\..\..\Slike\top_mocen.png");
            this.slike_topov[3] = Image.FromFile(@"..\..\..\Slike\top_mitraljez.png");


            this.izbira_topov[0] = new Stolp(0, 100, 1, 50, new Point(0, 0), 10);
            this.izbira_topov[1] = new Stolp(1, 300, 1, 100, new Point(0, 0), 30);
            this.izbira_topov[2] = new Stolp(2, 100, 3, 100, new Point(0, 0), 30);
            this.izbira_topov[3] = new Stolp(2, 100, 1, 10, new Point(0, 0), 100);

            for (int i = 0; i < this.polje_x.Length; i++)
            {
                this.testno_polje.Add(new Point(this.polje_x[i], this.polje_y[i]));
            }

            picbox_igralna_plosca.Controls.Add(picbox_napadalci); //Zato, da je drugi picturebox transparenten

            IzrisiKomponente();
            PosodobiZivljenjaKovance();
        }

        public int StZivljenj
        {
            get { return this.st_zivljenj; }
        }

        public int StKovancev
        {
            get { return this.st_kovancev; }

        }


        /// <summary>
        /// Ko napadalec pride do konca igralec zgubi zivljenja
        /// </summary>
        /// <param name="koliko"></param>
        public void IzgubljenaZivljenja(int koliko)
        {
            this.st_zivljenj -= koliko;
            if (this.st_zivljenj <= 0)
            {
                pnl_izgubil.Enabled = true;
                pnl_izgubil.Visible = true;
                //Da uporabnik ne more klikniti nove runde
                casovnik.Enabled = false;
                btn_nova_runda.Enabled = false;
            }
        }

        /// <summary>
        /// Metoda posodobi zivljenja in kovance pri graficnem izrisu
        /// </summary>
        public void PosodobiZivljenjaKovance()
        {
            lbl_zivljenja.Text = this.StZivljenj.ToString();
            lbl_denar.Text = this.StKovancev.ToString();
        }

        /// <summary>
        /// Izrise celotno mrezo z potjo
        /// </summary>
        /// <param name="g"></param>
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
            foreach(Stolp posamezni in stolpi.VsiStolpi)
            {
                int x = posamezni.Lokacija.X * this.vel_mreze.Width;
                int y = posamezni.Lokacija.Y * this.vel_mreze.Height;
                g.DrawImage(this.slike_topov[posamezni.Tip], x, y, this.vel_mreze.Width, this.vel_mreze.Height);
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
                g.FillPolygon(new SolidBrush(Color.Black), posamezni.TockeZaIzris(this.vel_mreze));
            }
        }

        /// <summary>
        /// Izrise vse izstrelke v tem casu
        /// </summary>
        /// <param name="g"></param>
        public void IzrisiIzstrelke(Graphics g)
        {
            Pen pen_rdece = new Pen(Color.Red);
            pen_rdece.Width = 5;

            foreach (List<Point> posamezn in this.izstrelki)
            {
                g.DrawLine(pen_rdece, posamezn[0], posamezn[1]);
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

            g.DrawImage(this.slike_topov[this.izbran_top], x, y, this.vel_mreze.Width, this.vel_mreze.Height);

            Pen rob_obmocja = new Pen(Color.Black);
            SolidBrush celo_obmocje = new SolidBrush(Color.FromArgb(128, 0, 255, 0));

            int radij = (int)this.izbira_topov[this.izbran_top].Radij;
            g.DrawEllipse(rob_obmocja, x - (radij / 2) + this.vel_mreze.Width / 2, y - (radij / 2) + this.vel_mreze.Height / 2, radij, radij);
            g.FillEllipse(celo_obmocje, x - (radij / 2) + this.vel_mreze.Width / 2, y - (radij / 2) + this.vel_mreze.Height / 2, radij, radij);

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
                button.BackColor = Color.LightGray;
                button.BackgroundImageLayout = ImageLayout.Stretch;
                button.BackgroundImage = this.slike_topov[i];
                button.Left = sirina;
                button.Top = visina;
                button.Click += IzbiraVMeniju;

                if (this.st_kovancev < this.izbira_topov[i].Cena) //Trenutno topa ne moremo kupiti
                {
                    button.Enabled = false;
                    button.BackColor = Color.OrangeRed;
                }

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
            Stolp stolp_podatki = this.izbira_topov[this.izbran_top];
            string podatki = $"Moc: {stolp_podatki.Moc}\nHitrost: {stolp_podatki.Hitrost}\nCena: {stolp_podatki.Cena}";
            lbl_podatki.Text = podatki;
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
                this.kje_miska = poz_miske;
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
                lbl_podatki.Text = "";
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
            //generiramo nove napadalce za naslednjo rundo
            this.napadalci.GenerirajNapadalce(this.runda);

            casovnik.Enabled = true;
            btn_nova_runda.Enabled = false;
            btn_nova_runda.Text = "V teku stopnja: " + this.runda;
        }

        /// <summary>
        /// Ko vsi napadalci umrejo, se runda konca in nastavi na naslednjo
        /// </summary>
        private void KonecRunde()
        {

            //za vsako koncano rundo neka nagrada kovancev
            this.st_kovancev += this.runda;
            PosodobiZivljenjaKovance();

            this.runda++;
            casovnik.Enabled = false;
            btn_nova_runda.Enabled = true;
            btn_nova_runda.Text = "Začni stopnjo: " + this.runda;

            //da pobrisemo se izstrelke in vse
            this.izstrelki.Clear();
            picbox_napadalci.Invalidate();
        }

        /// <summary>
        /// En tick casovnika
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CasovnaEnota(object sender, EventArgs e)
        {
            int izgubljena_zivljenja = this.napadalci.PremakniVse(this.testno_polje, this.vel_mreze);
            this.IzgubljenaZivljenja(izgubljena_zivljenja);
            this.PosodobiZivljenjaKovance();

            this.izstrelki = this.stolpi.IzstreliVse(this.napadalci.VsiNapadalci, this.vel_mreze);
            picbox_napadalci.Invalidate();

            if (this.napadalci.VsiNapadalci.Count == 0)
            {
                
                //Vsi napadalci so mrtvi, zato se runda konca
                this.KonecRunde();
            }

            

        }

        /// <summary>
        /// Funkcija izrise vse dinamicne objekte, ki se premikajo
        /// To so napadalci, izstrelki
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NarisiDinamicneObjekte(object sender, PaintEventArgs e)
        {
            IzrisiNapadalce(e.Graphics);
            IzrisiIzstrelke(e.Graphics);
            
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
                if (!stolpi.AliJeZasedeno(this.kje_miska))
                {
                    IzrisiIzbranTop(e.Graphics);
                }
            }
        }

        /// <summary>
        /// Ko uporabnik klikne na plosco preveri če ima izbran top in ga v tem primeru postavi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickNaPlosco(object sender, EventArgs e)
        {
            if (this.izbran_top != -1) //Uporabnik zeli postaviti top na polje
            {
                //Pogledamo, ali je uporabnik kliknil na zasedeno mesto
                if (!stolpi.AliJeZasedeno(this.kje_miska))
                {
                    stolpi.PostavitevNovega(this.kje_miska, this.izbira_topov[this.izbran_top], this.izbran_top);
                    //Odstejemo denar kolikor je stal top
                    this.st_kovancev -= this.izbira_topov[this.izbran_top].Cena;
                    this.izbran_top = -1;
                    lbl_podatki.Text = "";
                    picbox_igralna_plosca.Invalidate();
                    this.PosodobiZivljenjaKovance();
                    this.NapolniMeni();

                }
            }
        }

        /// <summary>
        /// Ko uporabnik klikne ta gumb zapre trenutno okno in ga pošlje nazaj na glavni meni
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IzgubilZapri(object sender, EventArgs e)
        {
            Igra.ActiveForm.Close();
            Osnovna.ActiveForm.Focus();
        }
    }
}
