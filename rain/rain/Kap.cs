using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace rain
{
    internal class Kap
    {
        DispatcherTimer timer = new DispatcherTimer();
        int pad = 6 ;
        public int x;
        public int y;
        public float q;
        public Kap(int x, int y, float q)
        {
            this.x = x;
            this.y = y;
            this.q = q;
            timer.Tick += padanje;
            timer.Interval = TimeSpan.FromMilliseconds(500 * q);
            timer.Start();
        }

        private void padanje(object sender, EventArgs e)
        {
            if (pad <= 0)
            {
                Events.funkcijaPadaKapi(this);
                timer.Stop();
            }
            else
            {
                pad--;
               
            }
        }
    }
}
