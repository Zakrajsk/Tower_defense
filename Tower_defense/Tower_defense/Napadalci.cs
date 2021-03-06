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
            this.vsi_napadalci.Add(new Napadalec(5, 2, new Point(0, 2 * 64 + 32), new Point(1, 0)));
            this.vsi_napadalci.Add(new Napadalec(3, 5, new Point(-50, 2 * 64 + 32), new Point(1, 0)));
            this.vsi_napadalci.Add(new Napadalec(4, 3, new Point(-100, 2 * 64 + 32), new Point(1, 0)));
            this.vsi_napadalci.Add(new Napadalec(8, 1, new Point(-150, 2 * 64 + 32), new Point(1, 0)));
        }

        public List<Napadalec> VsiNapadalci
        {
            get { return this.vsi_napadalci; }
        }

        /// <summary>
        /// Premakne vse napadalce za hitrost v smer
        /// Če more napadalec spremeniti smer poskrbi tudi za to
        /// </summary>
        public void PremakniVse(List<Point> pot, Size vel_mreze)
        {
            foreach(Napadalec posamezni in vsi_napadalci)
            {
                //Ko pride v sredino kvadranta
                //HITROST BOS MOGU SPREMENIT; CE BO PODANA V procentih pikslov
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
                        Point kam_mora = pot[indeks + 1];
                        posamezni.SmerPremika = kam_mora - (Size)kje_je;
                    }
                }

                
                posamezni.Premik();
            }
        }
    }
}
