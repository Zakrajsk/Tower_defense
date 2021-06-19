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
        private int zivljenje;
        private int hitrost;
        private Point lokacija; //stevilo pixlov x in y


        public Napadalec(int zivljenje, int hitrost, Point lokacija)
        {
            this.zivljenje = zivljenje;
            this.hitrost = hitrost;
            this.lokacija = lokacija;
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

        /// <summary>
        /// Prmekane nasprotnika z njegovo hitrostjo v smer, ki je podana z crko smeri neba
        /// S-gor V-desno J-dol Z-levo 
        /// </summary>
        /// <param name="smer"></param>
        public void premik(char smer)
        {
            switch (smer)
            {
                case 'S': { this.Lokacija = new Point(this.Lokacija.X, this.Lokacija.Y - this.hitrost); break; }
                case 'V': { this.Lokacija = new Point(this.Lokacija.X + this.hitrost, this.Lokacija.Y); break; }
                case 'J': { this.Lokacija = new Point(this.Lokacija.X, this.Lokacija.Y + this.hitrost); break; }
                case 'Z': { this.Lokacija = new Point(this.Lokacija.X - this.hitrost, this.Lokacija.Y); break; }
            }
        }
    }
}
