using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rain
{
    internal class Events
    {
        public  delegate void DelegatSirenja(Talas p);
        public static DelegatSirenja EventSirenja;

        public static void funkcijaSirenja(Talas p)
        {
            EventSirenja?.Invoke(p);
        }
        public delegate void DelegadPadaKapi(Kap k);
        public static DelegadPadaKapi EventPadaKapi;

        public static void funkcijaPadaKapi(Kap k)
        {
            EventPadaKapi?.Invoke(k);
        }
    }
}
