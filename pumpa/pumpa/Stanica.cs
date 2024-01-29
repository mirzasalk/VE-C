using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace pumpa
{
    internal class Stanica
    {
        List<Automobil> RedCekanja;
        List<Pumpa> PumpeStanice = new List<Pumpa>();
        DispatcherTimer dodavanjePumpiTimer = new DispatcherTimer();
        public Stanica()
        {
            RedCekanja = new List<Automobil>();

            for(int i = 0; i < 4; i++)
            {
                Pumpa p = new Pumpa();
                PumpeStanice.Add(p);
            }

            dodavanjePumpiTimer.Tick += dodavanjeAutaPumpi;
            dodavanjePumpiTimer.Interval = TimeSpan.FromMilliseconds(40);
            dodavanjePumpiTimer.Start();
            Events.EventPunjena += dodavanjeAutaPumpi2;
        }

        private void dodavanjeAutaPumpi2(Automobil a)
        {
            
            MessageBox.Show("Gorivo automobila " + a.getId().ToString() + " je napunjeno");


        }

        private void dodavanjeAutaPumpi(object sender, EventArgs e)
        {
            foreach (Pumpa p in PumpeStanice)
            {
                if (p.getAutoPumpe() == null && RedCekanja.Count() > 0)
                {
                    p.preuzimanjeAuta(RedCekanja[0]);
                    RedCekanja.Remove(RedCekanja[0]);
                }
            }
        }

        public void pristizanjeAutaUredCekanja(Automobil a)
        {
            RedCekanja.Add(a);
        }
        public List<Automobil> getRedCekanja()
        {
            return RedCekanja;
        }
        public List<Pumpa> getPumpmeStanice()
        {
            return PumpeStanice;
        }
    }
}
