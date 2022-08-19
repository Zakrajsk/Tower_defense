using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tower_defense
{
    class Stolp
    {
        private int tip; //Tip bo dolocal kaksne vrste je top 0 - osnoven 1 - ostrostrelski
        private double radij;
        private int moc;
        private int hitrost;
        private Point lokacija;
        private int cena;

        private int pripravljen; //Ko bo pripravlej na 0 takrat lahko top strelja

        public Stolp(int tip, double radij, int moc, int hitrost, Point lokacija, int cena)
        {
            this.tip = tip;
            this.radij = radij; //Kaksen obseg ima top podan je polmer v pixlih
            this.moc = moc; //Koliko zivljenj izbije ob izstrelku
            this.lokacija = lokacija; //glede na kvadrant
            this.hitrost = hitrost;
            this.cena = cena;

            pripravljen = hitrost;

        }

        public int Tip
        {
            get { return this.tip; }
        }
        public double Radij
        {
            get { return this.radij; }
        }

        public int Moc
        {
            get { return this.moc; }
        }

        public int Hitrost
        {
            get { return this.hitrost; }
        }
        public Point Lokacija
        {
            get { return this.lokacija; }
        }

        public int Cena
        {
            get { return this.cena; }
        }

        /// <summary>
        /// Vrne true, če top lahko strelja v tej potezi
        /// </summary>
        /// <returns></returns>
        public bool AliLahkoStrelja()
        {
            return this.pripravljen == this.Hitrost;
        }

        /// <summary>
        /// Ko top izstreli, ponastavimo pripravljenost
        /// </summary>
        public void Izstelitev()
        {
            this.pripravljen = 0;
        }

        /// <summary>
        /// Top se pripravlja na izstrelek in vsako rundo je blizje hitrosti kar pomeni da bo lahko streljal
        /// </summary>
        public void SePripravlja()
        {
            if (this.pripravljen < this.Hitrost)
            {
                this.pripravljen++;
            }
        }


    }
}
