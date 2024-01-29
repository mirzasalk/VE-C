using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace pumpa
{
    internal class Pumpa
    {
        protected Automobil a = null;
        DispatcherTimer punjenjeTimer = new DispatcherTimer();

        public void preuzimanjeAuta(Automobil auto)
        {
            a = auto;
            punjenjeTimer.Tick += punjenje;
            punjenjeTimer.Interval = TimeSpan.FromMilliseconds(100);
            punjenjeTimer.Start();
        }

        private void punjenje(object sender, EventArgs e)
        {
            if (a != null)
            {

                if (a.getTrenutniKolicina() < a.getKapacitet())
                {
                    a.punjenje();
                }
                else
                {
                    Events.funkcijaPunjenja(a);
                    a = null;
                    
                }
            }
        }

        

        public Automobil getAutoPumpe()
        {
            return a;
        }
    }
}
