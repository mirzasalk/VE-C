using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ispitniZadatak1
{
    class Events
    {
        public delegate void DelegatSirenja();
        public static event DelegatSirenja EventSirenja;    

        public static void funkcijaSirenja()
        {
            EventSirenja?.Invoke();
        }
    }
}
