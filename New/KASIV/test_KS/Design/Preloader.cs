using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KSJr
{
    
    public partial class Preloader : UserControl
    {

        private int timerCount = 0;
        public Preloader()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = "로딩중";

            if(++timerCount == 10)
            {
                timer1.Stop();
                progressBar.Enabled = false;
                this.Dispose();
                
            }
        }

        private void Preloader_Load(object sender, EventArgs e)
        {
            progressBar.Style = (MetroFramework.MetroColorStyle)ProgressBarStyle.Blocks;
            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
            progressBar.Step = 1;
            progressBar.Value = 0;

            timer1.Start();
        }
    }
}
