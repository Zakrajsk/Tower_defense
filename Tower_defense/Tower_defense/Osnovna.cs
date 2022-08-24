using System;
using System.Windows.Forms;

namespace Tower_defense
{
    public partial class Osnovna : Form
    {
        public Osnovna()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Se zgodi ob kliknu na gumb zacni
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PritiskZacni(object sender, EventArgs e)
        {
            //Vse nastavitve
            Igra okno_igre = new Igra();
            okno_igre.Show();
        }

        /// <summary>
        /// Se zgodi ob kliku na gubm koncaj
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PritiskKoncaj(object sender, EventArgs e)
        {
            Osnovna.ActiveForm.Close();
        }
    }
}
