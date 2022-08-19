using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tower_defense
{
    class Napadalec
    {
        private int zivljenje; //Integer koliko zivljenj ima
        private int hitrost; //v piksih mors spremenit v % polja
        private Point lokacija; //stevilo pixlov x in y
        private Point smer_premika; // (0, 1) (0, -1) (1, 0) (-1 , 0)


        public Napadalec(int zivljenje, int hitrost, Point lokacija, Point smer)
        {
            this.zivljenje = zivljenje;
            this.hitrost = hitrost;
            this.lokacija = lokacija;
            this.smer_premika = smer;
        }

        public int Zivljenje
        {
            get { return this.zivljenje; }
        }

        public int Hitrost
        {
            get { return this.hitrost; }
        }

        public Point Lokacija
        {
            get { return this.lokacija; }
            set
            {
                this.lokacija = value;
            }
        }

        public Point SmerPremika
        {
            get { return this.smer_premika; }
            set
            {
                this.smer_premika = value;
            }
        }

        public void Ustreljen(int moc)
        {
            this.zivljenje -= moc;
        }

        /// <summary>
        /// Prmekane nasprotnika z njegovo hitrostjo v smer, ki je podana z crko smeri neba
        /// S-gor V-desno J-dol Z-levo 
        /// </summary>
        /// <param name="smer"></param>
        public void Premik()
        {
            this.lokacija.Offset(new Point(this.smer_premika.X * this.hitrost, this.smer_premika.Y * this.hitrost));
        }

        /// <summary>
        /// Vrne vse točke za izris lika na igralno plosco
        /// Lik bo imel toliko oglišč, kot ima življenj
        /// </summary>
        /// <param name="vel_mreze"></param>
        /// <returns></returns>
        public PointF[] TockeZaIzris(Size vel_mreze)
        {
            PointF[] tocke = new PointF[this.zivljenje];
            int x_sredina = this.lokacija.X;
            int y_sredina = this.lokacija.Y;

            if (this.zivljenje == 1)
            {
                PointF[] nad_tocke = new PointF[10];
                for (int i = 0; i < 10; i++)
                {
                    nad_tocke[i] = new PointF(x_sredina + (float)(vel_mreze.Width * 0.1) * (float)Math.Cos(i * 36 * Math.PI / 180),
                                         y_sredina + (float)(vel_mreze.Height * 0.1) * (float)Math.Sin(i * 36 * Math.PI / 180));
                }
                tocke = nad_tocke;
            }

            else if (this.zivljenje == 2)
            {
                PointF[] nad_tocke = new PointF[4];
                for (int i = 0; i < 4; i++)
                {
                    nad_tocke[i] = new PointF(x_sredina + (float)(vel_mreze.Width * 0.3) * (float)Math.Cos((45 + i * 90) * Math.PI / 180),
                                         y_sredina + (float)(vel_mreze.Height * 0.1) * (float)Math.Sin((45 + i * 90) * Math.PI / 180));
                }
                tocke = nad_tocke;
            }

            else
            {
                int kot = 360 / this.zivljenje;

                for (int i = 0; i < this.zivljenje; i++)
                {
                    tocke[i] = new PointF(x_sredina + (float)(vel_mreze.Width * 0.3) * (float)Math.Cos(i * kot * Math.PI / 180),
                                         y_sredina + (float)(vel_mreze.Height * 0.3) * (float)Math.Sin(i * kot * Math.PI / 180));
                }
            }
            
            return tocke;
        }
    }
}
