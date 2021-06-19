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
        private double radij;
        private int moc;
        private Point lokacija;

        public Stolp(double radij, int moc, Point lokacija)
        {
            this.radij = radij;
            this.moc = moc;
            this.lokacija = lokacija; //glede na kvadrant
        }

        public double Radij
        {
            get { return this.radij; }
        }

        public int Moc
        {
            get { return this.moc; }
        }

        public Point Lokacija
        {
            get { return this.lokacija; }
        }


    }
}
