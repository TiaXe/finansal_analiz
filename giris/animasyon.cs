using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace giris
{
    public partial class animasyon : Form
    {
        public animasyon()
        {
            InitializeComponent();
        }
        bool islem = false;
        double opacityIncrement = 0.009;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!islem)
            {
                this.Opacity += opacityIncrement;
                if (this.Opacity >= 1.0)
                {
                    islem = true;
                }
            }
            else
            {
                this.Opacity -= opacityIncrement;
                if (this.Opacity <= 0)
                {
                    Form1 frm = new Form1();
                    frm.Show();
                    timer1.Enabled = false;
                    Hide();
                }
            }
        }

    }
}
