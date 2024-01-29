using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pumpa
{
    public class Automobil
    {
        Random rand = new Random();
        int id;
        float trenutnaKolicina;
        int kapacitet;
        public Automobil(int id)
        {
            this.id = id;
            kapacitet = 50;
            trenutnaKolicina = (rand.Next(10, 30) * kapacitet) / 100;
        }

        public float getTrenutniKolicina()
        {
            return trenutnaKolicina;
        }
        public int getId()
        {
            return id;
        }

        public int getKapacitet()
        {
            return kapacitet;
        }
        public void punjenje()
        {
            trenutnaKolicina += 1;
        }

    }
}
