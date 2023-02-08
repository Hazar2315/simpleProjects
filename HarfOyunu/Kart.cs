using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarfOyunu
{
    public class Kart
    {
        private char deger;
        private Boolean tahmin = false;
       // private int hamle = 0;

        public Kart(char deger)
        {
            this.deger = deger;
        }

        public char getDeger()
        {
            return deger;
        }

        public void setDeger(char deger)
        {
            this.deger = deger;
        }

        public Boolean getTahmin()
        {
            return tahmin;
        }

        public void setTahmin(Boolean tahmin)
        {
            this.tahmin = tahmin;
        }


    }
}