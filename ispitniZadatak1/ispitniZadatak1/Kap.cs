using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ispitniZadatak1
{
    public class Kap
    {
        public double x;
        public double y;
        public float q;
        public int metri;
        public Kap(double x,double y,float q)
        {
            this.q = q;
            this.x = x;
            this.y = y;
            metri = 50;
        }
    }
}
