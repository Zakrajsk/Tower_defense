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

            int kot = 360 / this.zivljenje;

            for(int i = 0; i < this.zivljenje; i++)
            {
                tocke[i] = new PointF(x_sredina + (float)(vel_mreze.Width * 0.3) * (float)Math.Cos(i * kot * Math.PI / 180),
                                     y_sredina + (float)(vel_mreze.Height * 0.3) * (float)Math.Sin(i * kot * Math.PI / 180));
            }

            return tocke;
        }
    }
}
