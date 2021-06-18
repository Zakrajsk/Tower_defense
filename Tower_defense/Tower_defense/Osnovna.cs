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
    public partial class Osnovna : Form
    {
        public Osnovna()
        {
            InitializeComponent();
        }

        private void btn_zacni_Click(object sender, EventArgs e)
        {
            //Vse nastavitve
            Igra okno_igre = new Igra();
            okno_igre.Show();
        }
    }
}
