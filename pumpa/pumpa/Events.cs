using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pumpa
{
    internal class Events
    {
        public delegate void DelegatiPunjeja(Automobil a);
        public static  DelegatiPunjeja EventPunjena;

        public static void funkcijaPunjenja(Automobil a)
        {
            EventPunjena?.Invoke(a); ;
        }
    }
}
