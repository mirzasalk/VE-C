using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace rain
{
    internal class Talas
    {
       
        public float width ;
        public int boja;
        public int x;
        public int y;
        public float deltaR;
        public float deltaB;
        public Talas(int x, int y, float q)
        {
            
            this.x = x;
            this.y = y;
            deltaR = 0.05f * q;
            deltaB =  0.05f / q;
            width = deltaR;
            Events.EventSirenja += sirenjeTalasa;
        }
        public void sirenjeTalasa(Talas p)
        {
            p.width += p.deltaR;
            
            if (p.boja > 255)
            {
                p.boja = 255;

            }
            else
            {
                p.boja += (int)deltaB;
            }
            
        }
    }
}
