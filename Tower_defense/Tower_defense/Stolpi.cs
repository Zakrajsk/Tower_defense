using System;
using System.Collections.Generic;
using System.Drawing;

namespace Tower_defense
{
    class Stolpi
    {
        private List<Stolp> vsi_stolpi = new List<Stolp>();

        public Stolpi()
        {
            //this.vsi_stolpi.Add(new Stolp(0, 300, 1, 50, new Point(7, 4), 10));
            //this.vsi_stolpi.Add(new Stolp(400, 4, 80, new Point(9, 3)));
        }

        public List<Stolp> VsiStolpi
        {
            get { return this.vsi_stolpi; }
        }

        /// <summary>
        /// Postavi nov stolp na izbrano lokacijo
        /// </summary>
        /// <param name="lokacija"></param>
        /// <param name="izbran"></param>
        /// <param name="tip"></param>
        public void PostavitevNovega(Point lokacija, Stolp izbran, int tip)
        {
            // Nastavimo nov stolp ki ima se lokacijo
            Stolp postavljen = new Stolp(tip, izbran.Radij, izbran.Moc, izbran.Hitrost, lokacija, izbran.Cena);
            this.vsi_stolpi.Add(postavljen);
        }

        /// <summary>
        /// Vrne true ali false, ce je lokacija prazna in lahko tja postavimo stolp
        /// </summary>
        /// <param name="lokacija"></param>
        /// <returns></returns>
        public bool AliJeZasedeno(Point lokacija)
        {
            foreach(Stolp posamezn in this.vsi_stolpi)
            {
                if (posamezn.Lokacija == lokacija)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Evklidska razdalja
        /// </summary>
        /// <param name="prva">prva tocka</param>
        /// <param name="druga">druga tocka</param>
        /// <returns></returns>
        public static double Evklidska(Point prva, Point druga)
        {
            double x = Math.Pow((prva.X - druga.X), 2);
            double y = Math.Pow((prva.Y - druga.Y), 2);
            return Math.Sqrt(x + y);
        }

        public List<List<Point>> IzstreliVse(List<Napadalec> vsi_napadalci, Size vel_mreze)
        {

            List<List<Point>> izstelki_za_izris = new List<List<Point>>();

            foreach(Stolp posamezni in this.VsiStolpi)
            {
                // Za vsak stolp pogledamo kateri napadalci so v bližini in najdemo najbližjega! Zaenkrat potem pa še druge opcije

                //Naprej ali sploh lahko strelja v tem koraku
                if (posamezni.AliLahkoStrelja())
                {
                    //Top je pripravljen na streljanje, zato iscemo najblizjo tarco
                    Napadalec najblizji_napadalec = null;
                    double najblizja_razdalja = posamezni.Radij;

                    //Izracun lokacije stolpa, ker je podan v mrezi in ne v pikslih
                    Point realna_lokacija = new Point(posamezni.Lokacija.X * vel_mreze.Width + vel_mreze.Width / 2,
                                                      posamezni.Lokacija.Y * vel_mreze.Height + vel_mreze.Height / 2);

                    foreach (Napadalec en in vsi_napadalci)
                    {
                        
                        double medsebojna_razd = Evklidska(realna_lokacija, en.Lokacija);

                        if(medsebojna_razd < najblizja_razdalja)
                        {
                            //Nasli smo napadalca, ki je se blizje
                            najblizji_napadalec = en;
                            najblizja_razdalja = medsebojna_razd;
                        }
                    }

                    if(najblizji_napadalec!= null && najblizja_razdalja <= posamezni.Radij)
                    {
                        //imamo napadalca, ki ga lahko ustrelimo
                        posamezni.Izstelitev();
                        bool ali_mrtev = najblizji_napadalec.Ustreljen(posamezni.Moc);
                        List<Point> strel = new List<Point>();
                        strel.Add(realna_lokacija);
                        strel.Add(najblizji_napadalec.Lokacija);
                        izstelki_za_izris.Add(strel);

                        if (ali_mrtev)
                        {
                            //Napadalec je mrtev, zato ga odstranimo
                            vsi_napadalci.Remove(najblizji_napadalec);
                        }
                    }
                }
                else
                {
                    //Top se ne more streljati, zato se samo pripravlja
                    posamezni.SePripravlja();
                }
                
            }

            return izstelki_za_izris;
        }
    }

    
}
