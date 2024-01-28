using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ispitniZadatak1
{
    public class Talas
    {
       
        public double x;
        public double y;
        public float deltaR ;
        public float deltaB;
        public int sirenje;
        public float width = 0;

        public Talas(double x, double y, float q)
            {
            this.x = x;
            this.y = y;
            deltaR = q * 0.05f;
            deltaB = 0.05f / q;
            sirenje = 0;
            width += deltaR;
            }
       
    }
}
