using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plivaci
{
    public class Events
    {

        public delegate void  DelegatMenjanjaframe(int p1,int p2, int p3);
        public static DelegatMenjanjaframe EventMenjanja;

        public static void funkcijaMenjanja(int p1,int p2,int p3)
        {
            EventMenjanja?.Invoke(p1 , p2, p3);
        }

        public delegate void DelegatPostavljanjeStilovae(int p1, int p2, int p3);
        public static DelegatPostavljanjeStilovae EventPostavljanjeStilova;

        public static void funkcijaPostavljanjeStilova(int p1, int p2, int p3)
        {
            EventPostavljanjeStilova?.Invoke(p1, p2, p3);
        }

        public delegate void DelegatMenjanjaframe2();
        public static DelegatMenjanjaframe2 EventMenjanja2;

        public static void funkcijaMenjanja2()
        {
            EventMenjanja2?.Invoke();
        }
    }
}
