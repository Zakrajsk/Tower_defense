using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tower_defense
{
    /// <summary>
    /// Razred, ki predstavlja vse trenutno žive napadalce
    /// </summary>
    class Napadalci
    {
        private List<Napadalec> vsi_napadalci = new List<Napadalec>();

        public Napadalci()
        {

        }

        public List<Napadalec> VsiNapadalci
        {
            get { return this.vsi_napadalci; }
            set
            {
                this.vsi_napadalci = value;
            }
        }

        /// <summary>
        /// Premakne vse napadalce za hitrost v smer
        /// Če more napadalec spremeniti smer poskrbi tudi za to
        /// </summary>
        /// <param name="pot"></param>
        /// <param name="vel_mreze"></param>
        /// <returns>vrne koliko zivljenj je treba odsteti, saj so prisli napadalci na konec</returns>
        public int PremakniVse(List<Point> pot, Size vel_mreze)
        {
            int izgubljenih_zivljenj = 0;
            List<Napadalec> umrli = new List<Napadalec>();

            foreach(Napadalec posamezni in vsi_napadalci)
            {
                //Ko pride v sredino kvadranta
                if (posamezni.Lokacija.X % (vel_mreze.Width / 2) < posamezni.Hitrost && posamezni.Lokacija.Y % (vel_mreze.Height / 2) < posamezni.Hitrost
                                            && posamezni.Lokacija.X / (vel_mreze.Width / 2) % 2 == 1 
                                            && posamezni.Lokacija.Y / (vel_mreze.Height / 2) % 2 == 1)
                {
                    Point koordinata = new Point(posamezni.Lokacija.X / vel_mreze.Width,
                                                 posamezni.Lokacija.Y / vel_mreze.Height);

                    int indeks = pot.FindIndex(koordinata.Equals);
                    if (indeks != -1) //Napadalec je lahko na ovinku
                    {
                        //Ga poravnamo na sredino za kaksen piksel se premakne
                        posamezni.Lokacija = new Point(koordinata.X * vel_mreze.Width + vel_mreze.Width / 2, koordinata.Y * vel_mreze.Height + vel_mreze.Height / 2);
                        Point kje_je = pot[indeks];
                        if(indeks < pot.Count - 1) //Preverimo ce smo ze na koncu
                        {
                            Point kam_mora = pot[indeks + 1];
                            posamezni.SmerPremika = kam_mora - (Size)kje_je;
                        }
                        else
                        {
                            //napadalec je na koncu, zato ga odstranimo in odstejemo zivljenja
                            izgubljenih_zivljenj += posamezni.Zivljenje;
                            //Dodamo v seznam umrlih, ki jih bomo na koncu premika izbrisali iz seznama vseh napadalcev
                            umrli.Add(posamezni);
                        }

                    }
                }
                posamezni.Premik();
            }
            //izbrisemo vse, ki so  te rundi umrli
            foreach (Napadalec en_umrl in umrli)
            {
                this.VsiNapadalci.Remove(en_umrl);
            }
            return izgubljenih_zivljenj;
        }

        /// <summary>
        /// Generira napadalce glede na stopnjo
        /// </summary>
        /// <param name="stopnja"></param>
        public void GenerirajNapadalce(int stopnja)
        {
            //Spraznemo, ce slucajno se kaj ostane (ne bi smelo do tega priti ampak vseeno)
            this.VsiNapadalci.Clear();

            if (stopnja <= 10) //Prvih 10 lahkih
            {
                if (stopnja % 2 != 0)
                {
                    for (int i = 0; i < stopnja; i++)
                    {
                        this.VsiNapadalci.Add(new Napadalec(1, 1, new Point((-40) * i, 2 * 64 + 32), new Point(1, 0)));
                    }
                }


                if (stopnja % 2 == 0)
                {
                    for (int i = 0; i < stopnja / 2; i++)
                    {
                        this.VsiNapadalci.Add(new Napadalec(2, 2, new Point((-40) * i, 2 * 64 + 32), new Point(1, 0)));
                    }
                }

                if (stopnja % 5 == 0)
                {
                    for (int i = 0; i < stopnja / 2; i++)
                    {
                        this.VsiNapadalci.Add(new Napadalec(3, 2, new Point((-60) * i, 2 * 64 + 32), new Point(1, 0)));
                    }
                }

            }
            else
            {
                for (int i = 0; i < stopnja; i++)
                {
                    this.VsiNapadalci.Add(new Napadalec(3, 3, new Point((-40) * i, 2 * 64 + 32), new Point(1, 0)));
                }

                if (stopnja % 2 != 0)
                {
                    for (int i = 0; i < stopnja; i++)
                    {
                        this.VsiNapadalci.Add(new Napadalec(4, 2, new Point(-160 + (-80) * i, 2 * 64 + 32), new Point(1, 0)));
                    }
                }

                if (stopnja % 2 == 0)
                {
                    for (int i = 0; i < stopnja / 3; i++)
                    {
                        this.VsiNapadalci.Add(new Napadalec(6, 1, new Point(-160 + (-80) * i, 2 * 64 + 32), new Point(1, 0)));
                    }
                }

                if (stopnja % 10 == 0)
                {
                    for (int i = 0; i < stopnja / 10; i++)
                    {
                        this.VsiNapadalci.Add(new Napadalec(20, 1, new Point((-40) * i, 2 * 64 + 32), new Point(1, 0)));
                    }
                }

                if (stopnja % 50 == 0)
                {
                    for (int i = 0; i < stopnja / 10; i++)
                    {
                        this.VsiNapadalci.Add(new Napadalec(50, 1, new Point((-40) * i, 2 * 64 + 32), new Point(1, 0)));
                    }
                }


            }
        }
    }
}
